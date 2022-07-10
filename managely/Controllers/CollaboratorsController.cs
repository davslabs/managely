using AutoMapper;
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Managely.Controllers;

public class CollaboratorsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CollaboratorsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        IEnumerable<Employee> employees = await _unitOfWork.Employees.GetAllEmployees();
        IEnumerable<CollaboratorViewModel> collaborators = _mapper.Map<IEnumerable<CollaboratorViewModel>>(employees);
        return View(collaborators);
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