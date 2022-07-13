using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AutoMapper;
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Managely.Controllers;

[Authorize]
public class EmployeeController: Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeeProfile([Required] Guid employeeId)
    {
        //Si el empleado no es manager o admin,
        //y el id del empleado no es el mismo que el del usuario logueado,
        //no puede ver el perfil del empleado
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (!User.IsInRole("Manager") && !User.IsInRole("Admin") && userId != employeeId.ToString())
        {
            //Redirigimos a /Home/Index
            return RedirectToAction("Index", "Home");
        }
        
        Employee? employee = await _unitOfWork.Employees.GetEmployeeById(employeeId);
        if (employee == null) throw new InvalidOperationException("El empleado no existe");
        EmployeeProfileViewModel evm = _mapper.Map<EmployeeProfileViewModel>(employee);

        return View("Employee", evm);
    }
}