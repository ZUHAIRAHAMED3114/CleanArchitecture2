
using CleanArch.Infra.Data.Context;
using MediatR;
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

        public static IServiceCollection DomainService(this IServiceCollection services)
        {
            services.AddScoped<Domain.Core.Bus.IMediatorHandler, Bus.InMemoryBus>();
            services.AddScoped<IRequestHandler<Domain.Commands.CreateCourseCommand, bool>
                                                , Domain.CommandHandler.CourseCommandHandler>();


            return services;
        }

        public static IServiceCollection ApplicationService(this IServiceCollection services)
        {
            services.AddScoped<Application.Interfaces.ICourseService, 
                               Application.Services.CourseServices>();
            return services;
        }

        public static IServiceCollection InfraStructureService(this IServiceCollection services,string connectionString) {

            services.AddDbContext<UniversityDBContext>(Options =>
            {
                Options.UseSqlServer(connectionString);
            });
            services.AddScoped<Domain.Interfaces.ICourseRepository, 
                               Data.Repository.CourseRepository>();
            return services;
        }

    }
}
