using DeviceAssigment.Application.Common.Models;
using DeviceAssigment.Application.Device.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceAssigment.Application.Device.Interfaces
{
    public interface IDeviceRepository
    {
        Task<ServiceResponse<IEnumerable<DeviceDto>>> GetDevices();
        Task<ServiceResponse<DeviceDto>> GetDevice(int id);
        Task<bool> Save(CancellationToken cancellationToken);
        void Add(CreateDeviceDto newDevice);
        void Update(DeviceDto deviceDto);
        void Remove(DeviceDto deviceDto);
    }
}
