using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LabsWeek3
{
    class RangeOfArray
    {
        int lowerBound;
        int upperBound;

        public RangeOfArray()
        {
            lowerBound = 0;
            upperBound = int.MaxValue;
        }
        public RangeOfArray(int low, int top)
        {
            if(top < low)
            {
                int tmp = low;
                low = top;
                top = tmp;
            }
            lowerBound = low;
            upperBound = top;
        }
        public void initialize(ref int[] array)
        {
            WriteLine($"\nEnter {upperBound - lowerBound} values");
            int elemCount = lowerBound;
            upperBound = (upperBound - lowerBound) > array.Length ? upperBound :lowerBound + array.Length;

            for (int i = 0; elemCount + 1 <= upperBound; i++, elemCount++)
            {
                Write($"Enter {elemCount} element: ");
                array[i] = int.Parse(ReadLine());
            }
        }
        public void show(int[] arr)
        {
            int elemCount = lowerBound;
            WriteLine();
            for (int i = 0; elemCount + 1<= upperBound; i++, elemCount++)
            {
                WriteLine($"{elemCount} element: {arr[i]}");
            }
        }
        public void showLower(int[] arr)
        {
            WriteLine($"First element is {arr[0]}");
        }
        public void showUpper(int[] arr)
        {
            if (arr.Length <= upperBound)
            {
                WriteLine("Error (size)");
                return;
            }
            WriteLine($"Last element is {arr[upperBound]}");
        }
    }
}
