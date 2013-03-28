using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class SelectionSort : ISort
    {
        public void Sort<T>(T[] array) where T: IComparable
        {
            for (int i = 0, L = array.Length; i < L; i++)
            {
                T min = array[i];
                int minPos = i;

                for (int j = i+1; j < L; j++)
                {
                    if (min.CompareTo(array[j]) > 0)
                    {
                        min = array[j];
                        minPos = j;
                    }
                }

                if (minPos > i)
                    exch(array, i, minPos);
            }
        }

        private void exch<T>(T[] array, int from, int to)
        {
            T temp = array[to];
            array[to] = array[from];
            array[from] = temp;
        }
    }
}
