using MachineSimulation.DataAccess.Abstract;
using MachineSimulation.DataAccess.Abstract.MachineLogRepositories;
using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.DataAccess.Abstract.OperationRepositories;
using MachineSimulation.DataAccess.Abstract.ParameterRepositories;
using MachineSimulation.DataAccess.Concrete;
using MachineSimulation.DataAccess.Concrete.MachineLogRepositories;
using MachineSimulation.DataAccess.Concrete.MachineRepositories;
using MachineSimulation.DataAccess.Concrete.OperationParameterRepositories;
using MachineSimulation.DataAccess.Concrete.OperationRepositories;
using MachineSimulation.DataAccess.Concrete.ParameterRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddDbContext<MachineSimulationContext>(options => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MachineSimDb;Trusted_Connection=true;"));
            services.AddScoped<IMachineReadRepository,MachineReadRepository>();
            services.AddScoped<IMachineWriteRepository, MachineWriteRepository>();
            services.AddScoped<IMachineLogReadRepository,MachineLogReadRepository>();
            services.AddScoped<IMachineLogWriteRepository, MachineLogWriteRepository>();
            services.AddScoped<IOperationReadRepository,OperationReadRepository>();
            services.AddScoped<IOperationWriteRepository,OperationWriteRepository>();
            services.AddScoped<IParameterReadRepository,ParameterReadRepository>();
            services.AddScoped<IParameterWriteRepository,ParameterWriteRepository>();
            services.AddScoped<IOperationParameterReadRepository,OperationParameterReadRepository>();
            services.AddScoped<IOperationParameterWriteRepository,OperationParameterWriteRepository>();
        }
    }
}
