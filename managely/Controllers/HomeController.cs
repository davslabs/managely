using System.Security.Claims;
using AutoMapper;
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Managely.Controllers;

public class HomeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public HomeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            Guid? employeeId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))!.Value);
            if(employeeId.Value == Guid.Empty)
            {
                return RedirectToAction("Login", "Auth");
            }
            
            Employee? currentEmployee = await _unitOfWork.Employees.GetEmployeeById((Guid)employeeId);
            if(currentEmployee == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            
            EmployeeProfileViewModel employeeProfileViewModel = _mapper.Map<EmployeeProfileViewModel>(currentEmployee);
            return View(employeeProfileViewModel);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}