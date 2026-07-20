using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationDiplom.Classes
{
    /*
     * Класс виртуальной машины с заданием требуемых свойств
     */
    public class VirtualMachine
    {
        public int Id { get; }
        public double Cpu { get; }
        public double Ram { get; }
        public double Disk { get; }
        public VirtualMachine(int id, double cpu, double ram, double disk)
            => (Id, Cpu, Ram, Disk) = (id, cpu, ram, disk);
    }
}
