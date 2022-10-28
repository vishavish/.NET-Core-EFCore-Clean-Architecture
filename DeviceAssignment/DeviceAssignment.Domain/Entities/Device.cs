using DeviceAssignment.Domain.Common;
using DeviceAssignment.Domain.Enums;

namespace DeviceAssignment.Domain.Entities
{
    public class Device : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Condition Condition { get; set; }
        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }
    }
}