using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace Managely.Controllers;

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
        Employee? employee = await _unitOfWork.Employees.GetEmployeeById(employeeId);
        if (employee == null) throw new InvalidOperationException("El empleado no existe");
        EmployeeProfileViewModel evm = _mapper.Map<EmployeeProfileViewModel>(employee);

        return View("Employee", evm);
    }
}