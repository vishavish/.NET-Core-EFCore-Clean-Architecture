using AutoMapper;
using DeviceAssigment.Application.Device.Dtos;
using DeviceAssigment.Application.Employee.Dtos;

namespace DeviceAssigment.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeviceAssignment.Domain.Entities.Device, DeviceDto>()
                .ForMember(d => d.Condition, opt
                    => opt.MapFrom((s => s.Condition)))
                .ReverseMap();

            CreateMap<CreateDeviceDto, DeviceAssignment.Domain.Entities.Device>()
                .ForMember(d => d.EmployeeId, opt
                    => opt.MapFrom(s => s.EmployeeId > 0 ? s.EmployeeId : null));

            CreateMap<DeviceAssignment.Domain.Entities.Employee, EmployeeDto>().ReverseMap();
            CreateMap<DeviceAssignment.Domain.Entities.Employee, CreateEmployeeDto>().ReverseMap();            
        }
    }
}    