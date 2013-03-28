using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace TestingProject
{
    [TestClass]
    public class OrderOfGrowthTest
    {
        [TestMethod]
        public void testMyMathIsCorrect1()
        {
            var Mock = new Mock<Sorting.ISort>();
            SortingTest st = new SortingTest(Mock.Object);

            int[] xScale = { 16, 32, 64, 128, 256, 512, 1024 };
            double[] yScale = new double[xScale.Length];

            for (int i = 0; i < xScale.Length; i++)
            {
                yScale[i] = Math.Pow(xScale[i], 2);
            }

            double growth = st.growthSlope(xScale, yScale);
            Assert.AreEqual(2, growth);
        }

        [TestMethod]
        public void testMyMathIsCorrect2()
        {
            var Mock = new Mock<Sorting.ISort>();
            SortingTest st = new SortingTest(Mock.Object);

            int[] xScale = { 16, 32, 64, 128, 256, 512, 1024 };
            double[] yScale = new double[xScale.Length];

            for (int i = 0; i < xScale.Length; i++)
            {
                yScale[i] = Math.Pow(xScale[i], 4) + 3 * xScale[i] + 11;
            }

            double growth = st.growthSlope(xScale, yScale);
            Assert.AreEqual(4, growth, .05);
        }
    }
}
