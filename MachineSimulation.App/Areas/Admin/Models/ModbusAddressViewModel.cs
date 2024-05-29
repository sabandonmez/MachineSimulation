using MachineSimulation.Entities.Concrete;

namespace MachineSimulation.App.Areas.Admin.Models
{
    public class ModbusAddressViewModel
    {
        public IEnumerable<ModbusAddress> Addresses { get; set; }
        public ModbusAddress NewAddress { get; set; }
    }

}
