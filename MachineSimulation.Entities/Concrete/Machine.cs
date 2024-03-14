using MachineSimulation.Core.EntitiesLayer;
using MachineSimulation.Entities.Concrete.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
    public class Machine : BaseEntity
    {
        public string MachineName { get; set; }
        public string MachineType { get; set; }
        public MachineState State { get; set; } = MachineState.Stopped; 
        public int ProductionCount { get; set; } // Tamamlanan operasyon sayısını tutar.
        public virtual ICollection<Parameter> Parameters { get; set; } // Bir makinenin birden çok parametresi olabilir.
        public virtual ICollection<Operation> Operations { get; set; } // Bir makinenin birden çok operasyonu olabilir.
    }
}
