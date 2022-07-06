using AutoMapper;
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Models.DTO;
using Managely.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Managely.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                IEnumerable<Employee> employees = await _unitOfWork.Employees.GetAllEmployees();
                HashSet<EmployeeProfileViewModel> employeeList = new HashSet<EmployeeProfileViewModel>();
            
                foreach (Employee employee in employees)
                {
                    EmployeeProfileViewModel employeeProfile = _mapper.Map<EmployeeProfileViewModel>(employee);

                    employeeList.Add(employeeProfile);
                }
            
                return Ok(employeeList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeDto addEmployeeDto) 
        {
            try
            {
                Employee? reporter = null;
                if(addEmployeeDto.ReportsTo != null)
                {
                    reporter = await _unitOfWork.Employees.GetEmployeeById((Guid)addEmployeeDto.ReportsTo);
                }

                Role? role = await _unitOfWork.Roles.GetByValue(addEmployeeDto.Role);           
                Department? department = await _unitOfWork.Departments.GetByValue(addEmployeeDto.Department);
                JobPosition? jobPosition = await _unitOfWork.JobPositions.GetByValue(addEmployeeDto.JobPosition);


                Employee newEmployee = new Employee()
                {
                    Name = addEmployeeDto.Name,
                    LastName = addEmployeeDto.LastName,
                    Email = addEmployeeDto.Email,
                    Phone = addEmployeeDto.Phone,
                    Password = addEmployeeDto.Password, 
                    Location = addEmployeeDto.Location,
                    Role = role,
                    Department = department,
                    JobPosition = jobPosition,
                    ReportsTo = reporter,
                    ReportsToId = addEmployeeDto.ReportsTo
                };

                var result = _unitOfWork.Employees.Add(newEmployee);
                if (result == null) throw new Exception(result?.Exception?.Message);
                _unitOfWork.Complete();

                return Ok("Created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDto updateEmployeeDto, Guid employeeId)
        {
            try
            {
                Employee? employee = await _unitOfWork.Employees.GetEmployeeById(employeeId);
                if (employee is null) return NotFound("El empleado no existe");


                if (updateEmployeeDto.ReportsTo != null)
                    employee.ReportsTo = await _unitOfWork.Employees.Get((Guid)updateEmployeeDto.ReportsTo);
                if (!string.IsNullOrEmpty(updateEmployeeDto.Phone)) employee.Phone = updateEmployeeDto.Phone;
                if (!string.IsNullOrEmpty(updateEmployeeDto.Location)) employee.Location = updateEmployeeDto.Location;

                _unitOfWork.Employees.Update(employee);
                _unitOfWork.Complete();

                return Ok("Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{employeeId}")]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            try
            {
                Employee? employee = await _unitOfWork.Employees.GetEmployeeById(employeeId);
                
                if (employee == null) throw new Exception("El empleado no existe");

                return Ok(_mapper.Map<EmployeeProfileViewModel>(employee));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{employeeId}/relationships")]
        public async Task<IActionResult> GetRelatedEmployees(Guid employeeId)
        {
            try 
            {
                IEnumerable<Employee> employees = await _unitOfWork.Employees.GetRelatedEmployees(employeeId);
                HashSet<EmployeeProfileViewModel> relatedEmployees = new HashSet<EmployeeProfileViewModel>();

                foreach(var employee in employees)
                {
                    var employeeProfile = _mapper.Map<EmployeeProfileViewModel>(employee);
                    relatedEmployees.Add(employeeProfile);
                }

                return Ok(relatedEmployees);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
