using DeviceAssignment.Domain.Enums;

namespace DeviceAssigment.Application.Device.Dtos
{
    public class CreateDeviceDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Condition Condition { get; set; }
        public int? EmployeeId { get; set; }
    }
}