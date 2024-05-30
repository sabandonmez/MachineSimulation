using MachineSimulation.Entities.Concrete;

namespace MachineSimulation.App.Areas.Admin.Models
{
    public class ModbusAddressViewModel
    {
        public List<ModbusAddress> Addresses { get; set; }
        public ModbusAddress NewAddress { get; set; }
        public List<Machine> Machines { get; set; }
    }


}
