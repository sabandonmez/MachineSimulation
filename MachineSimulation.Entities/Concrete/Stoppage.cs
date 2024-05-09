using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
    public class Stoppage :BaseEntity
    {
        public int? MachineId { get; set; }
        public string? ReasonStoppageName { get; set; }
        public int? ReasonStoppageValue { get; set; }
        public virtual Machine Machine { get; set; }
    }
}
