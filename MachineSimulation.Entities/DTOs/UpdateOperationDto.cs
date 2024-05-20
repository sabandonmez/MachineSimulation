
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.DTOs
{
    public class UpdateOperationDto
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int OperationNameId { get; set; }
        public int? ModbusIp { get; set; }
        public List<SelectListItem> OperationNames { get; set; }
    }

}
