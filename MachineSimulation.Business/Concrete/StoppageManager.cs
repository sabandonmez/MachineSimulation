using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.StoppageRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class StoppageManager:IStoppageService
    {
        private readonly IStoppageReadRepository _stoppageReadRepository;
        private readonly IStoppageWriteRepository _stoppageWriteRepository;
        public StoppageManager(IStoppageReadRepository stoppageReadRepository, IStoppageWriteRepository stoppageWriteRepository)
        {
            _stoppageReadRepository = stoppageReadRepository;
            _stoppageWriteRepository = stoppageWriteRepository;
        }

        
    }
}
