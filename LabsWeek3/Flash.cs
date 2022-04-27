using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsWeek3
{
    class Flash : Storage
    {
        double speedUSB3 = 0.625;
        double capacityGB;
        double freeCapacityGB;
        public Flash(string model) : base(nameof(Flash), model)
        {
            capacityGB = 16;
            freeCapacityGB = capacityGB;
        }
        public Flash(double mem, string model):base(nameof(Flash), model)
        {
            if (mem > 0)
                capacityGB = mem;
            freeCapacityGB = capacityGB;
        }
        public double getSpeed() { return speedUSB3; }
        public override int copyFiles(double size)
        {
            if (size > 0)
            {
                if (size <= freeCapacityGB)
                {
                    freeCapacityGB = freeCapacityGB - size;
                    //Console.WriteLine($"Copied {size}GB of files! Memory left: {freeCapacityGB}GB" +
                    //    $"\nTime spent: {size * speedUSB3 / 60} min.");
                    return 1;
                }
                else
                {
                    //Console.WriteLine("Not enought memory");
                    return 0;
                }
            }
            else Console.WriteLine("incorrect amount");
            return -1;
        }
        public override double getCapacity()
        {
            return capacityGB;
        }
        public override void showInfo()
        {
            Console.WriteLine($"\tUSB 3.0 FLASH card:\nModel:\t{base.model}\nSpeed:\t{speedUSB3} Gb/s" +
                $"\nCapacity:\t{capacityGB}GB\nFree space:\t{freeCapacityGB}GB\n");
        }
        public override string ToString()
        {
            return ("Flash card");
        }
    }
}
