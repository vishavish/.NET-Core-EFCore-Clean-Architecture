using System.Reflection;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceAssigment.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}