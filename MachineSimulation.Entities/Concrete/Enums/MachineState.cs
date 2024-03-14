using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Entities.Concrete.Enums
{
    public enum MachineState
    {
        Ready, //Hazır
        Running, //Çalışıyor
        Paused, //Duraklatıldı
        Completed, //Tamamlandı
        Cooling, //Soğutma
        Maintenance, //Bakım
        Stopped
    }
}
