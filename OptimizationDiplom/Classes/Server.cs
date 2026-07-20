using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationDiplom.Classes
{
    /*
     * Класс сервера с заданными лимитами ресурсов и энергопотреблением
     */
    public class Server
    {
        public int Id { get; }
        public double CpuCap { get; }
        public double RamCap { get; }
        public double DiskCap { get; }
        public double EIdle { get; }  // Энергопотребление в режиме простоя
        public double EMax { get; }
        public Server(int id, double cpuCap, double ramCap, double diskCap, double eIdle, double eMax)
            => (Id, CpuCap, RamCap, DiskCap, EIdle, EMax) = (id, cpuCap, ramCap, diskCap, eIdle, eMax);
    }
}
