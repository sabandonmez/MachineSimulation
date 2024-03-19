using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
    public class MachineLog :BaseEntity
    {
        public int MachineId { get; set; }
        public string Action { get; set; } // "Bağlandı" veya "Kopartıldı"
        public DateTime Timestamp { get; set; }
    }
}
