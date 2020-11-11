using System;
using System.Collections.Generic;
using DeviceAssignment.Domain.Common;

namespace DeviceAssignment.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string MobileNo { get; set; }
        public DateTime EmploymentDate { get; set; }
        public ICollection<Device> Devices { get; private set; }

        public Employee()
        {
            Devices = new List<Device>();
        }
    }
}