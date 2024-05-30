using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
    public class ModbusAddress : BaseEntity
    {
        public ushort Address { get; set; }
        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; }
    }


}
