using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LabsWeek3
{
    class Program
    {
        static void Main(string[] args)
        {
            UseBackupCopy();


            ReadLine();
        }
        private static void UseBackupCopy()
        {
            //Flash samsung16 = new Flash(64, "SanDisk");
            //samsung16.copyFiles(-51);

            Flash flashCard128, flashCard256;
            HDD hardDisk512, hardDisk1024;
            DVD dvdDisk1, dvdDisk2;

            flashCard128 = new Flash(128, "Samsung");
            flashCard256 = new Flash(256, "SanDisk");
            hardDisk512 = new HDD(512, "Toshiba");
            hardDisk1024 = new HDD(1024, "Cisco");
            dvdDisk1 = new DVD();
            dvdDisk2 = new DVD(2);

            Storage[] dataCarrier = new Storage[] {flashCard128,flashCard256,hardDisk512,hardDisk1024,dvdDisk1,dvdDisk2 };

            double totalMemory = 0;
            foreach (var elem in dataCarrier)
                totalMemory += elem.getCapacity();

            //foreach (var elem in dataCarrier)
            //    elem.showInfo();

            Menu:
            double infoForCopySizeGB = 565;//element size is 780 mb (0,76 GB)
            Clear();
            Write("\tMenu:\n1. Show total capacity of all devices\n2. Copy info on devices\n3. " +
                "Info about time for copying\n4. Choose devices for copy\n\tOption: ");
            int varMenu = int.Parse(ReadLine());
            switch (varMenu)
            {
                case 1:
                    {
                        WriteLine($"\n{totalMemory}GB available");
                    }
                    break;
                case 2:
                    {
                        if (infoForCopySizeGB <= totalMemory)//opportunity of optimisation - flash cards (if available) go first, then order by capacity;
                        {
                            while (infoForCopySizeGB > 0)
                            {
                                for (int i = 0; i < dataCarrier.Length;)
                                {
                                    int rez;
                                    do
                                    {
                                        rez = dataCarrier[i].copyFiles(0.76);
                                        infoForCopySizeGB -= 0.76;
                                    } while (rez != 0);
                                    i++;
                                }
                            }
                            WriteLine("Copied successfully");
                        }
                        else WriteLine("Not enough space, add devices");
                    }break;
                case 3:
                    {
                        WriteLine($"\nCopying {infoForCopySizeGB} GB of files takes ~\n--> {infoForCopySizeGB * flashCard128.getSpeed() / 60} " +
                            $"min. copying of flash cards,\n--> {infoForCopySizeGB * dvdDisk1.getSpeed() / 60} min. copying on CD-disks,\n" +
                            $"--> {infoForCopySizeGB * hardDisk512.getSpeed() / 60} min. copying on external hard disks");
                    }
                    break;
                case 4:
                    {
                        int countDevices;
                        foreach (var elem in dataCarrier)
                        {
                            countDevices = Convert.ToInt32(infoForCopySizeGB / elem.getCapacity());
                            WriteLine($"\nYou need ~ {countDevices} {elem}(s) of {elem.getCapacity()} volume to make this copy");
                        }
                    }break;
            }
            WriteLine("Do you want to continue? true/false");
            bool continueFlag = bool.Parse(ReadLine());
            if (continueFlag == true)
                goto Menu;
            else WriteLine("\t-Ok, bye");

            //FUNCTIONALITY:

            //all devices storage
            //copy info on devices
            //info about time for copy
            //how many devices of these types are needed for copy
        }
      
    }
}
