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
                    => opt.MapFrom((s => (int)s.Condition)))
                .ReverseMap();
            
            CreateMap<DeviceAssignment.Domain.Entities.Device, CreateDeviceDto>()
                .ForMember(d => d.Condition, opt 
                    => opt.MapFrom(s => (int)s.Condition))
                .ReverseMap();

            CreateMap<DeviceAssignment.Domain.Entities.Employee, EmployeeDto>().ReverseMap();
            CreateMap<DeviceAssignment.Domain.Entities.Employee, CreateEmployeeDto>().ReverseMap();            
        }
    }
}    