using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InesrtionSort : ISort
    {
        public override void Sort<T>(T[] arr) 
        {
            for (int i = 1; i < arr.Length; i++)
                for (int j = i - 1; j >= 0; j--)
                    if (arr[i].CompareTo(arr[j]) < 1)
                        exch(arr, i, j);
        }
    }
}
