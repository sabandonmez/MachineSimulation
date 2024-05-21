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
        public int OperationNameId { get; set; }
        public int? ModbusIp { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual OperationName OperationName { get; set; }
        public virtual ICollection<OperationParameter> OperationParameters { get; set; }
    }
}
