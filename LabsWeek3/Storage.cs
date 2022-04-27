using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsWeek3
{
    abstract class Storage
    {
        string name;
        protected string model;

        public Storage(string nm, string mod)
        {
            name = nm;
            model = mod;
        }
        public abstract double getCapacity();
        public abstract int copyFiles(double size);
        public abstract void showInfo();
    }
}
