using System.Collections.Generic;

namespace DeviceAssigment.Application.Common.Models
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
