using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LockFreeStack;
using System.Threading.Tasks;

namespace StackTest
{
    [TestClass]
    public class UnitTest1
    {

        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void CheckItWorks()
        {
            Stack s = new Stack();
            s.Push(1);
            s.Push(2);

            Assert.AreEqual(2, s.Pop());
            Assert.AreEqual(1, s.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EmptyStackThrows()
        {
            Stack s = new Stack();
            s.Pop();
        }

        [TestMethod]
        public void ParallelInsertion()
        {
            int min = 1, max = 200;

            var s = new Stack();

            var options = new ParallelOptions() 
            { 
                MaxDegreeOfParallelism = 30
            };

            Parallel.For(min, max, options, i => { s.Push(i); });

            for (int i = min; i < max; i++)
            {
                int item = s.Pop();
                Assert.IsTrue(item >= min && item < max);
            }

            bool caught = false;

            try
            {
                s.Pop();
            }
            catch (NullReferenceException)
            {
                caught = true;
            }

            Assert.IsTrue(caught, "Should not have more items in stack then parallel for has insterted");
        }

        [TestMethod]
        public void interMixedInsertionDeletion()
        {
            int min = 1, max = 300;

            var s = new Stack();

            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 30
            };

            Parallel.For(min, max, options, i => {

                s.Push(i);

                if (i % 3 == 0)
                    s.Pop();
            
            });
        }

    }
}
