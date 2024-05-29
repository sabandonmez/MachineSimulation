using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.DataAccess.Abstract.OperationRepositories;
using MachineSimulation.DataAccess.Abstract.ParameterRepositories;
using MachineSimulation.DataAccess.Concrete.MachineRepositories;
using MachineSimulation.DataAccess.Concrete.OperationParameterRepositories;
using MachineSimulation.DataAccess.Concrete.OperationRepositories;
using MachineSimulation.DataAccess.Concrete.ParameterRepositories;
using MachineSimulation.DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineSimulation.Business.Abstract;
using MachineSimulation.Services.Concrete;
using MachineSimulation.Business.Concrete;

namespace MachineSimulation.Business
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IMachineService, MachineManager>();
            services.AddScoped<IOperationService, OperationManager>();
            services.AddScoped<IParameterService, ParameterManager>();
            services.AddScoped<IOperationParameterService, OperationParameterManager>(); 
            services.AddScoped<IMachineLogService, MachineLogManager>();
            services.AddScoped<IOperationLogService, OperationLogManager>();
            services.AddScoped<IModbusConnectionService, ModbusConnectionManager>();
            services.AddScoped<IStoppageService,StoppageManager>();
            services.AddScoped<IAuthService,AuthManager>();
            services.AddScoped<IModbusAddressService, ModbusAddressManager>();

        }
    }
}
