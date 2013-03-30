using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace TestingProject
{
    [TestClass]
    public class InsertionSortTest
    {
        [TestMethod]
        public void testInesrtionIntSorting()
        {
            SortingTest testClass = new SortingTest(new InesrtionSort());
            testClass.testIntSorting();
        }

        /*
        [TestMethod]
        public void testItsQuadraticTime()
        {
            SortingTest testClass = new SortingTest(new SelectionSort());
            double growth = testClass.performanceGrowth();
            Assert.AreEqual(2, growth, 0.05);
        }
        */
    }
}
