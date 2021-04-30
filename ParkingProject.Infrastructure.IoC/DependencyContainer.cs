using Microsoft.Extensions.DependencyInjection;
using ParkingProject.Application.Interfaces;
using ParkingProject.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingProject.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void AddIoCService(this IServiceCollection services)
        {
            // application
            services.AddScoped<IGarageService, GarageService>();
            
            //  domain.interfaces-> infrastructure.data

        }
    }
}
