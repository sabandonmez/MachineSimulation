using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
    public class OperationParameter : BaseEntity
    {
        public int OperationId { get; set; }
        public int ParameterId { get; set; }
        public string Value { get; set; } // Parametrenin değeri.
        public virtual Operation Operation { get; set; }
        public virtual Parameter Parameter { get; set; }
    }
}
