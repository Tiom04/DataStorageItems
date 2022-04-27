using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsWeek3
{
    class HDD : Storage
    {
        double speedUSB2 = 0.480;
        int numberOfPartitions = 1;
        double totalCapacityGB;
        double totalFreeCapacityGB;
        public HDD(string model):base(nameof(HDD), model)
        {
            totalCapacityGB = 120;
            totalFreeCapacityGB = totalCapacityGB;
        }
        public HDD(double cap, string model):base(nameof(HDD), model)
        {
            if (cap > 0)
            {
                totalCapacityGB = cap;
                totalFreeCapacityGB = totalCapacityGB;
            }
            else Console.WriteLine("Wrong capacity");
        }
        public double getSpeed() { return speedUSB2; }
        public void addPartition(int num)
        {
            if(num > 0)
                numberOfPartitions += num;
        }//
        public override int copyFiles(double size)
        {
            if (size > 0)
            {
                if (size <= totalFreeCapacityGB)
                {
                    totalFreeCapacityGB = totalFreeCapacityGB - size;
                    //Console.WriteLine($"Copied {size}GB of files! Memory left: {totalFreeCapacityGB}GB" +
                    //    $"\nTime spent: {size * speedUSB2 / 60} min.");
                    return 1;
                }
                else
                {
                    //Console.WriteLine("Not enought memory");
                    return 0;
                }
            }
            else Console.WriteLine("incorrect size");
            return -1;
        }
        public override double getCapacity()
        {
            return totalCapacityGB;
        }
        public override void showInfo()
        {
            Console.WriteLine($"\tExternal HDD Disk:\nModel:\t{base.model}\nSpeed:\t{speedUSB2} Gb/s" +
                $"\nCapacity:\t{totalCapacityGB}GB\nPartitions:\t{numberOfPartitions}\nFree space:\t{totalFreeCapacityGB}GB\n");
        }
        public override string ToString()
        {
            return ("External HDD");
        }
    }
}
