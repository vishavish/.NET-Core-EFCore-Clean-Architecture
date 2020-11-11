using System;
using System.Collections.Generic;
using DeviceAssigment.Application.Device.Dtos;

namespace DeviceAssigment.Application.Employee.Dtos
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string MobileNo { get; set; }
        public DateTime EmploymentDate { get; set; }
        public ICollection<DeviceDto> Devices { get; private set; }
    }
}