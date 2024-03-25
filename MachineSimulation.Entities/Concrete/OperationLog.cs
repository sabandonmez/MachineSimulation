using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
    public class OperationLog :BaseEntity
    {
        public int MachineId { get; set; }
        public int OperationId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
