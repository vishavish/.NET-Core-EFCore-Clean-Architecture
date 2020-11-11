namespace DeviceAssigment.Application.Common.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}