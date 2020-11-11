using DeviceAssigment.Application.Common.Interfaces;
using System;

namespace DeviceAssignment.Infrastracture.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
