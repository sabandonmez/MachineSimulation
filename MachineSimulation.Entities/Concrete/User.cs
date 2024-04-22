using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }

}
