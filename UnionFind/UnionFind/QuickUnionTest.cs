using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnionFind
{
    [TestClass]
    public class QuickUnionTest
    {
        SharedTests testClient;

        [TestInitialize()]
        public void Startup()
        {
            testClient = new SharedTests(new QuickUnion(5));
        }

        [TestMethod]
        public void testBasicConnection()
        {
            testClient.testBasicConnection();
        }

        [TestMethod]
        public void testTwoSubGroupsConnection()
        {
            testClient.testTwoSubGroupsConnection();
        }
    }
}
