using DeviceAssigment.Application.Common.Models;
using DeviceAssigment.Application.Employee.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceAssigment.Application.Employee.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<ServiceResponse<IEnumerable<EmployeeDto>>> GetEmployees();
        Task<ServiceResponse<EmployeeDto>> GetEmployee(int id);
        Task<bool> Save(CancellationToken token);
        void Add(CreateEmployeeDto newEmployee);
        void Update(EmployeeDto employeeDto);
        void Remove(int id);
    }
}
