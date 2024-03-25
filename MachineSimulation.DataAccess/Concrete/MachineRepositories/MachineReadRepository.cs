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
                MachineType = machine.MachineType,
                ProductionCount = machine.ProductionCount,
                ImageUrl = machine.ImageUrl,
                Parameters = machine.Parameters.Select(p => new ParameterDto
                {
                    ParameterName = p.ParameterName,
                    ValueType = p.ValueType
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
                                          ValueType = p.ValueType,
                                          ParameterValue = p.OperationParameters
                                                            .Select(op => op.ParameterValue)
                                                            .ToList()
                                      })
                                      .ToList();

            return parameters;
        }

    }
}
