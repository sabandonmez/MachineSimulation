using MachineSimulation.Core.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete
{
    public class Machine : BaseEntity
    {
        public Machine()
        {
            Parameters = new HashSet<Parameter>();
            Stopages = new HashSet<Stoppage>();
            Operations = new HashSet<Operation>();
            ModbusAddresses = new HashSet<ModbusAddress>();
        }

        private string? imageUrl;

        [Required(ErrorMessage = "MachineName is required!")]
        public string MachineName { get; set; }

        [Required(ErrorMessage = "ModbusId is required!")]
        public int ModbusId { get; set; }

        public string? ImageUrl
        {
            get => imageUrl ?? $"{MachineName.Replace(" ", "")}.jpg";
            set => imageUrl = value;
        }

        public virtual ICollection<Parameter> Parameters { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Stoppage> Stopages { get; set; }
        public virtual ICollection<ModbusAddress> ModbusAddresses { get; set; }
    }

}
