using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class SelectionSort : ISort
    {
        public override void Sort<T>(T[] arr) 
        {
            for (int i = 0, L = arr.Length; i < L; i++)
            {
                T min = arr[i];
                int minPos = i;

                for (int j = i+1; j < L; j++)
                {
                    if (min.CompareTo(arr[j]) > 0)
                    {
                        min = arr[j];
                        minPos = j;
                    }
                }

                if (minPos > i)
                    exch(arr, i, minPos);
            }
        }
    }
}
