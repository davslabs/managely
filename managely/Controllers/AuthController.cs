using System.Security.Claims;
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Models.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Managely.Controllers;

public class AuthController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public AuthController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity is { IsAuthenticated: true })
        {
            return base.Redirect("/Home/Index");
        }
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequestDto user)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    ModelState.SelectMany(x =>
                        x.Value!.Errors.Select(y => y.ErrorMessage)).ToList()
                );
            }
            
            Employee? employee = await _unitOfWork.Employees.GetEmployeeByEmail(user.Email);
            if (employee == null) return StatusCode(404, new { message = "Usuario no encontrado" });
            
            if (!employee.Password.Equals(user.Password)) return BadRequest(new { message = "Contraseña incorrecta" });

            List<RolePermission> permissions = await _unitOfWork.Roles.GetRolePermissions(employee.Role.Name);

            var identity = new ClaimsIdentity(
                CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimTypes.Name,
                ClaimTypes.Role
            );
            
            identity.AddClaim(new Claim(ClaimTypes.GivenName, employee.DisplayName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, employee.EmployeeId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, employee.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, employee.Role.Name.ToString()));

            foreach (var p in permissions)
            {
                identity.AddClaim(new Claim("Permission", p.Permission.Name.ToString()));
            }
            
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = true }
            );

            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/");
    }
}