﻿using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.DTOs
{
    public class MachineDetailsDto
    {
        public string MachineName { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<MachineLog> MachineLogs { get; set; }
        public IEnumerable<OperationLogDto>  OperationLogs { get; set; }
        public List<ParameterDto> Parameters { get; set; }
        public List<StoppageDto> Stopages { get; set; }


    }
}
