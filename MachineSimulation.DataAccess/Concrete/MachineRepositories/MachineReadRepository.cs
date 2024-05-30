using MachineSimulation.Core.DataAccessLayer.EntityFramework;
using MachineSimulation.DataAccess.Abstract.MachineRepositories;
using MachineSimulation.Entities.Concrete;
using MachineSimulation.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.DataAccess.Concrete.MachineRepositories
{
    public class MachineReadRepository : ReadRepository<Machine>, IMachineReadRepository
    {
        private readonly MachineSimulationContext _context;
        public MachineReadRepository(MachineSimulationContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Machine> GetAllMachineList()
        {
            return _context.Machines;
        }

        public MachineDetailsDto GetMachineDetails(int machineId)
        {
            var machine = _context.Machines.Include(m => m.Parameters).FirstOrDefault(m => m.Id == machineId);

            if (machine == null)
            {
                // Makine bulunamadı işlemi
            }

            var machineDto = new MachineDetailsDto
            {
                MachineName = machine.MachineName,
                ImageUrl = machine.ImageUrl,
                Stopages=machine.Stopages.Select(p=>new StoppageDto 
                {
                    MachineId = machineId,
                    ReasonStoppageName = p.ReasonStoppageName,
                    ReasonStoppageValue=p.ReasonStoppageValue
                }).ToList(),
                Parameters = machine.Parameters.Select(p => new ParameterDto
                {
                    ParameterName = p.ParameterName,
    
                }).ToList()
            };

            return machineDto;
        }

        public List<ParameterDto> GetParameters(int machineId)
        {
            var parameters = _context.Parameters
                                      .Where(p => p.MachineId == machineId)
                                      .Select(p => new ParameterDto
                                      {
                                          ParameterName = p.ParameterName,
                                      
                                          ParameterValue = p.OperationParameters
                                                            .Select(op => op.ParameterValue)
                                                            .ToList()
                                      })
                                      .ToList();

            return parameters;
        }

        public List<StoppageDto> GetStoppages(int machineId)
        {
            var stoppages=_context.Stoppages
                                  .Where(s=>s.MachineId==machineId)
                                  .Select(s=>new StoppageDto
                                  {
                                      ReasonStoppageName=s.ReasonStoppageName,
                                      ReasonStoppageValue = s.ReasonStoppageValue
                                  }).ToList();
            return stoppages;                        
        }
    }
}
