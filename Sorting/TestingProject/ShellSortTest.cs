using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace TestingProject
{
    [TestClass]
    public class ShellSortTest
    {
        [TestMethod]
        public void testShellIntSorting()
        {
            SortingTest testClass = new SortingTest(new InesrtionSort());
            testClass.testIntSorting();
        }

        [TestMethod]
        public void testShellHugeIntArray()
        {
            SortingTest testClass = new SortingTest(new InesrtionSort());
            testClass.testIntSorting(5000);
        }
    }
}
