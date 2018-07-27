namespace Employees.App
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    using Core.Contracts;
    using Core;
    using Employees.Data;
    using Employees.Services.Contracts;
    using Employees.Services;
    using Employees.App.Core.Controllers;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigServiceProvider();

            ICommandInterpreter commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();

            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<EmployeesContext>(option => option.UseSqlServer(Configuration.ConnectionString));

            services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());

            services.AddTransient<ICommandInterpreter, CommandInterpreter>();
            services.AddTransient<IDbInitializerService, DbInitializerService>();
            services.AddTransient<IEmployeeControler, EmployeeControler>();
            services.AddTransient<IManagerControler, ManagerControler>();

            IServiceProvider provider = services.BuildServiceProvider();

            return provider;
        }
    }
}