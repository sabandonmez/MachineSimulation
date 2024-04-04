using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.DTOs
{
    public class OperationEventValueDto
    {
        public int MachineId { get; set; }
        public string OperationName { get; set; } 
        public int ModbusIp { get; set; }
        public int Event { get; set; }
    }
}
