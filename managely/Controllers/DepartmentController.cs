using AutoMapper;
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Managely.Controllers
{
    [Authorize]
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesByDepartment()
        {
            try
            {
                var departments = await _unitOfWork.Departments.GetAll();
                List<EmployeeDepartmentViewModel> edv = new List<EmployeeDepartmentViewModel>();
                foreach (var department in departments)
                {
                    var employees = await _unitOfWork.Employees
                        .GetEmployeesByDepartment(department.DepartmentId);
                    ICollection<EmployeeProfileViewModel> employeeProfileViewModels =
                        new List<EmployeeProfileViewModel>();

                    foreach (var employee in employees)
                    {
                        employeeProfileViewModels.Add(_mapper.Map<EmployeeProfileViewModel>(employee));
                    }

                    edv.Add(new EmployeeDepartmentViewModel
                    {
                        Department = department.Name,
                        Employees = employeeProfileViewModels
                    });
                }
            
                return Ok(edv);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        } 
    }
}