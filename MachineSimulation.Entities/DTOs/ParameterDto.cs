using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.DTOs
{
    public class ParameterDto
    {
        public string ParameterName { get; set; }
        public string ValueType { get; set; }

        public List<string> ParameterValue { get; set; }
    }
}
