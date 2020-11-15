using DeviceAssigment.Application.Common.Models;
using DeviceAssigment.Application.Employee.Dtos;
using DeviceAssigment.Application.Employee.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceAssignment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<EmployeeDto>>> GetEmpployees()
        {
            return await _employeeRepository.GetEmployees();
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<EmployeeDto>> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] CreateEmployeeDto createEmployeeDto, CancellationToken cancellationToken)
        {
            _employeeRepository.Add(createEmployeeDto);
            if (!await _employeeRepository.Save(cancellationToken))
            {
                return BadRequest();
            }

            return Ok(createEmployeeDto);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditEmployee(int id, [FromBody] EmployeeDto employeeDto, CancellationToken cancellationToken)
        {
            if (id != employeeDto.Id)
            {
                return BadRequest();
            }

            _employeeRepository.Update(employeeDto);
            if (!await _employeeRepository.Save(cancellationToken))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveEmployee(int id, CancellationToken cancellationToken)
        {
            _employeeRepository.Remove(id);
            if (! await _employeeRepository.Save(cancellationToken))
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
