using MachineSimulation.DataAccess.Abstract.ParameterRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class ParameterManager :IParameterService
    {
        private readonly IParameterReadRepository _parameterReadRepository;
        private readonly IParameterWriteRepository _parameterWriteRepository;
        public ParameterManager(IParameterReadRepository parameterReadRepository, IParameterWriteRepository parameterWriteRepository)
        {
            _parameterReadRepository = parameterReadRepository;
            _parameterWriteRepository = parameterWriteRepository;
        }


    }
}
