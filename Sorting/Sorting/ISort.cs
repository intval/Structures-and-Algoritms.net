using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public interface ISort
    {
        void Sort<T>(T[] arr) where T : IComparable;
    }
}
