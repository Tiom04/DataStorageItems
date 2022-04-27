using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsWeek3
{
    class DVD : Storage
    {

        double speed = 0.058;
        int type;
        double capacity;
        double freeCapacity;
        public DVD():base(nameof(DVD), "1-side")
        {
            type = 1;
            capacity = 4.7;
            freeCapacity = capacity;
        }
        public DVD(int type) : base(nameof(DVD), $"{type}-side")//
        {
            if (type > 0 && type < 3)
            {
                this.type = type;
            }
            else
            {
                Console.WriteLine("Wrong type!");
                this.type = 1;
            }
            if (type == 2)
            {
                capacity = 9;
            }
            if (type == 1)
            {
                capacity = 4.7;
            }
            freeCapacity = capacity;
        }
        public double getSpeed() { return speed; }
        public override int copyFiles(double size)
        {
            if (size > 0)
            {
                if (size <= freeCapacity)
                {
                    freeCapacity = freeCapacity - size;
                    //Console.WriteLine($"Copied {size}GB of files! Memory left: {freeCapacity}GB" +
                    //    $"\nTime spent: {size * speed / 60} min.");
                    return 1;
                }
                else
                {
                    //Console.WriteLine("Not enought memory");
                    return 0;
                }
            }
            else Console.WriteLine("wrong amount");
            return -1;
        }
        public override double getCapacity()
        {
            if (type == 1)
                return 4.7;
            if (type == 2)
                return 9;
            else return 0;
        }
        public override void showInfo()
        {
            Console.WriteLine($"\tCD Disk:\nModel:\t{base.model}\nSpeed:\t{speed} Gb/s" +
                $"\nCapacity:\t{capacity}GB\nFree space:\t{freeCapacity}GB\n");
        }
        public override string ToString()
        {
            return ("DVD disk");
        }
    }
}
