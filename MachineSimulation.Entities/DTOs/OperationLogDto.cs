using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.DTOs
{
    public class OperationLogDto
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string OperationName { get; set; } 
        public DateTime Timestamp { get; set; }
    }
}
