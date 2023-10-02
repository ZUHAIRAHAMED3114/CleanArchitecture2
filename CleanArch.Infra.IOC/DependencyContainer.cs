using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CleanArch.Infra.IOC
{
    public static class DependencyContainer
    {
     

        public static IServiceCollection ApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseServices>();
            return services;
        }

        public static IServiceCollection InfraStructureService(this IServiceCollection services,string connectionString) {

            services.AddDbContext<UniversityDBContext>(Options =>
            {
                Options.UseSqlServer(connectionString);
            });
            services.AddScoped<ICourseRepository, CourseRepository>();
            return services;
        }

    }
}
