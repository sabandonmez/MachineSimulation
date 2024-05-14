using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.DTOs
{
    public class StoppageDto
    {
        public int Id { get; set; }
        public int? MachineId { get; set; }
        public string? ReasonStoppageName { get; set; }
        public int? ReasonStoppageValue { get; set; }
    }
}
