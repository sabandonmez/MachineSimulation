using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
    public class Operation : BaseEntity
    {
        public int MachineId { get; set; }
        public string OperationName { get; set; } // Örneğin: "Başlatma", "Duraklama", "Hazırlık" vs.
        public int  ModbusIp { get; set; }
        public int Event { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual ICollection<OperationParameter> OperationParameters { get; set; }
   

    }
}
