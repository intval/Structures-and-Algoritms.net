using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnionFind
{
    class SharedTests
    {
        IUnionFindImpl uf;

        public SharedTests(IUnionFindImpl impl)
        {
            uf = impl;
        }

        public void testBasicConnection()
        {
            Assert.IsFalse(uf.isConnected(1, 2));
            uf.connect(1, 2);
            Assert.IsTrue(uf.isConnected(1, 2));
        }

        public void testTwoSubGroupsConnection()
        {
            Assert.IsFalse(uf.isConnected(1, 4));
            uf.connect(1, 2);
            uf.connect(3, 4);
            uf.connect(2, 3);
            Assert.IsTrue(uf.isConnected(1, 4));
        }

    }
}
