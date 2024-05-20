using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
	public class OperationName:BaseEntity
	{
		public string Name { get; set; }
		public virtual ICollection<Operation> Operations { get; set; }
	}
}
