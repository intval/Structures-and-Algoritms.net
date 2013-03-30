using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /*
     * Shell Sort is the same like insertion sort, but with larger steps.
     * First we sort every 5th element, then every 3rd element, the every 1st element
     * that we get "almost sorted" array to the moment we get to the every single element sort
     */

    class ShellSort : ISort
    {
        public override void Sort<T>(T[] arr) 
        {
            int Length = arr.Length;
            int Gap = Length / 3;

            while (Gap > 0)
            {
                for (int i = 0; i < Gap; i++)
                {
                    for (int j = i; j > Gap && j < Length; j += Gap)
                    {
                        if (arr[j].CompareTo(arr[j - Gap]) > 0)
                            exch(arr, j, j-Gap);
                    }
                }

                Gap = Gap / 3;
            }
        }
    }
}
