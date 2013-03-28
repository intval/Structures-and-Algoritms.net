using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;
using System.Timers;
using System.Diagnostics;
using System.Linq;

namespace TestingProject
{
    public class SortingTest
    {
        ISort sorter;

        public SortingTest(ISort sorter)
        {
            this.sorter = sorter;
        }


        public void testIntSorting()
        {
            int[] arr = {0, 1, 22, 3, 2, 1, 0};
            int[] refArray = (int[]) arr.Clone();
            
            Array.Sort(refArray);
            sorter.Sort(arr);

            CollectionAssert.AreEquivalent(refArray, arr);
        }

        public double performanceGrowth()
        {
            int[] sizes = { 10, 100, 1000, 10000, 100000 };
            Stopwatch t = new Stopwatch();
            double[] timingResults = new double[sizes.Length];

            for(int i = 0; i < sizes.Length; i++)
            {
                int[] arr = getRandomArrayOfSize(sizes[i]);

                GC.Collect(0);
                GC.Collect(1);
                GC.Collect(2);
                
                t.Start();
                sorter.Sort(arr);
                t.Stop();
                timingResults[i] = (double) t.ElapsedMilliseconds;
            }

            return growthSlope(sizes, timingResults);
        }

        private int[] getRandomArrayOfSize(int size)
        {
            int[] ret = new int[size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                ret[i] = rand.Next();
            }

            return ret;
        }

        public double growthSlope(int[] xScale, double[] yScale)
        {
            // Figure best fit line with
            // http://hotmath.com/hotmath_help/topics/line-of-best-fit.html

            double xSum = 0, ySum = 0, XbyY =0, sqrX = 0;
            int size = xScale.Length;

            for (int i = 0; i < size; i++)
            {
                double x = Math.Log(xScale[i], 2);
                double y = Math.Log(yScale[i], 2);

                xSum += x; 
                ySum += y;
                sqrX += x * x;
                XbyY += x * y;
            }

            return (XbyY - xSum * ySum / size)  / (sqrX - xSum * xSum / size);
        }
    }
}
