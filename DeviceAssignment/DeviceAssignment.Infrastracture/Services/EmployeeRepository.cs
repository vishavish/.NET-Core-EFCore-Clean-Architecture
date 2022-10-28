using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeviceAssigment.Application.Common.Exceptions;
using DeviceAssigment.Application.Common.Interfaces;
using DeviceAssigment.Application.Common.Models;
using DeviceAssigment.Application.Device.Interfaces;
using DeviceAssigment.Application.Employee.Dtos;
using DeviceAssigment.Application.Employee.Interfaces;
using DeviceAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceAssignment.Infrastracture.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employeeList = await _context.Employees
                .AsNoTracking()
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new ServiceResponse<IEnumerable<EmployeeDto>>()
            {
                Data = employeeList,
                IsSuccess = true,
                Message = "Successfully retrieved employee list."
            };
        }

        public async Task<ServiceResponse<EmployeeDto>> GetEmployee(int id)
        {
            var employeeObj = await _context.Employees
                                        .Include(e => e.Devices)
                                        .FirstOrDefaultAsync(e => e.Id == id);
            if (employeeObj == null) 
                throw new NotFoundException(nameof(Employee), id);

            var employeeDto = _mapper.Map<EmployeeDto>(employeeObj);

            return new ServiceResponse<EmployeeDto>()
            {
                Data = employeeDto,
                IsSuccess = true,
                Message = $"Successfully retrieved employee with id: { id }."
            };
        }

        public async Task<bool> Save(CancellationToken token)
        {
            return (await _context.SaveChangesAsync(token) > 0);
        }

        public void Add(CreateEmployeeDto newEmployee)
        {
            var employeeObj = _mapper.Map<Employee>(newEmployee);
            _context.Employees.Add(employeeObj);
        }

        public void Update(EmployeeDto employeeDto)
        {
            var employeeObj = _mapper.Map<Employee>(employeeDto);
            _context.Employees.Update(employeeObj);
        }

        public void Remove(int id)
        {
            var employeeObj = _context.Employees.Find(id);
            _context.Employees.Remove(employeeObj);
        }
    }
}
