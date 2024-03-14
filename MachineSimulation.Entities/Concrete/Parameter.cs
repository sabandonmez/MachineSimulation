using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
    public class Parameter : BaseEntity
    {
        public int MachineId { get; set; }
        public string ParameterName { get; set; }
        public string ValueType { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual ICollection<OperationParameter> OperationParameters { get; set; } // Bir parametre birden çok operasyon parametresine sahip olabilir.
    }
}
