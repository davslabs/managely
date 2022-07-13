using System.Security.Claims;
using AutoMapper;
using Managely.Domain.Interfaces;
using Managely.Domain.Models;
using Managely.Models.DTO;
using Managely.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Managely.Controllers
{
    [Authorize]
    [Route("/api/employees")]
    [ApiController]
    public class TimeOffController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TimeOffController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("time-off")]
        public async Task<IActionResult> GetWhoIsOnTimeOff()
        {
            try
            {
                var employees = await _unitOfWork.Employees.GetWhoIsOnTimeOff();
                var employeesOnTimeOff = _mapper.Map<IEnumerable<EmployeeOnTimeOffDto>>(employees);
                return Ok(employeesOnTimeOff);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("{employeeId}/time-off")]
        public async Task<IActionResult> AddEmployeeTimeOff([FromBody] AddTimeOffDto addTimeOffDto, Guid employeeId)
        {
            try
            {
                //Si el empleado no es manager o admin,
                //y el id del empleado no es el mismo que el del usuario logueado,
                //no puede agregar una solicitud de vacaciones.
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (!User.IsInRole("Manager") && !User.IsInRole("Admin") && userId != employeeId.ToString())
                {
                    return Unauthorized(new { message = "No tienes permisos para cargar tiempo fuera de oficina de este empleado" });
                }
                
                Employee? employee = await _unitOfWork.Employees.GetEmployeeById(employeeId);
                if (employee == null) throw new Exception("El empleado no existe");

                TimeOff timeOff = new TimeOff()
                {
                    Reason = addTimeOffDto.Reason,
                    FromDate = addTimeOffDto.FromDate,
                    ThruDate = addTimeOffDto.ThruDate
                };

                employee.EmployeeTimeOffs.Add(new EmployeeTimeOff
                {
                    Employee = employee,
                    TimeOff = timeOff,
                });

                await _unitOfWork.TimeOffs.Add(timeOff);
                _unitOfWork.Employees.Update(employee);

                _unitOfWork.Complete();

                return Ok();
            } 
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet]
        [Route("{employeeId}/time-off")]
        public async Task<IActionResult> GetEmployeeTimeOff(Guid employeeId)
        {
            try
            {
                Employee? employee = await _unitOfWork.Employees.GetEmployeeById(employeeId);
                if (employee == null) throw new Exception("El empleado no existe");
            
                ICollection<TimeOff> employeeTimeOffs = await _unitOfWork.Employees.GetEmployeeTimeOff(employeeId);
                List<EmployeeTimeOffViewModel> employeeTimeOffList = new List<EmployeeTimeOffViewModel>();
                
                foreach(var employeeTimeOff in employeeTimeOffs)
                {
                    var et = _mapper.Map<EmployeeTimeOffViewModel>(employeeTimeOff);
                    employeeTimeOffList.Add(et);
                }

                return Ok(employeeTimeOffList);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
