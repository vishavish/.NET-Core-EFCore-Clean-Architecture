using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeviceAssigment.Application.Common.Exceptions;
using DeviceAssigment.Application.Common.Interfaces;
using DeviceAssigment.Application.Common.Models;
using DeviceAssigment.Application.Device.Dtos;
using DeviceAssigment.Application.Device.Interfaces;
using DeviceAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceAssignment.Infrastracture.Services
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeviceRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<DeviceDto>>> GetDevices()
        {
            var deviceList = await _context.Devices
                .AsNoTracking()
                .ProjectTo<DeviceDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new ServiceResponse<IEnumerable<DeviceDto>>()
            {
                Data = deviceList,
                IsSuccess = true,
                Message = "Successfully retrieved device list."
            };
        }

        public async Task<ServiceResponse<DeviceDto>> GetDevice(int id)
        {
            var deviceObj = await _context.Devices.FindAsync(id);
            if (deviceObj == null)
                throw new NotFoundException(nameof(Device), id);

            var deviceDto = _mapper.Map<DeviceDto>(deviceObj);

            return new ServiceResponse<DeviceDto>()
            {
                Data = deviceDto,
                IsSuccess = true,
                Message = $"Sucessfully retrieved device with id: { id }"
            };
        }

        public async Task<bool> Save(CancellationToken cancellationToken)
        {
            return (await _context.SaveChangesAsync(cancellationToken) > 0);
        }

        public void Add(CreateDeviceDto newDevice)
        {
            var deviceObj = _mapper.Map<Device>(newDevice);
            _context.Devices.Add(deviceObj);
        }

        public void Update(DeviceDto deviceDto)
        {
            var deviceObj = _mapper.Map<Device>(deviceDto);
            _context.Devices.Add(deviceObj);
        }

        public void Remove(int id)
        {
            var device = _context.Devices.Find(id);
            if (device == null)
            {
                throw new NotFoundException(nameof(Device), id);
            }

            _context.Devices.Remove(device);
        }
    }
}
