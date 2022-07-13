using AutoMapper;
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Managely.Controllers;

[Authorize]
public class CollaboratorsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CollaboratorsController(
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> Index()
    {
        IEnumerable<Employee> employees = await _unitOfWork.Employees.GetAllEmployees();
        IEnumerable<CollaboratorViewModel> collaborators = _mapper.Map<IEnumerable<CollaboratorViewModel>>(employees);
        return View(collaborators);
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin, Manager")]
    public async Task<IActionResult> AddNewEmployee()
    {
        List<Employee> employees = await _unitOfWork.Employees.GetAllEmployees();
        List<EmployeeProfileViewModel> evm = _mapper.Map<List<EmployeeProfileViewModel>>(employees);
        List<Role> roles = await _unitOfWork.Roles.GetAllRoles();
        List<RoleViewModel> rvm = _mapper.Map<List<RoleViewModel>>(roles);
        List<Department> departments = await _unitOfWork.Departments.GetAllDepartments();
        List<DepartmentViewModel> dvm = _mapper.Map<List<DepartmentViewModel>>(departments);
        List<JobPosition> jobPositions = await _unitOfWork.JobPositions.GetAllJobPositions();
        List<JobPositionViewModel> jvm = _mapper.Map<List<JobPositionViewModel>>(jobPositions);
        
        AddCollaboratorViewModel acvm = new AddCollaboratorViewModel
        {
            Employees = evm,
            Roles = rvm,
            Departments = dvm,
            JobPositions = jvm
        };
        
        return PartialView("AddCollab", acvm);
    }

    [HttpGet]
    public IActionResult Organization()
    {
        return View("OrgChart");
    }
}