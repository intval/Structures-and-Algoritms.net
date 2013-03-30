using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public abstract class ISort
    {
        public abstract void Sort<T>(T[] arr) where T : IComparable;

        protected void exch<T>(T[] array, int from, int to)
        {
            T temp = array[to];
            array[to] = array[from];
            array[from] = temp;
        }
    }
}
