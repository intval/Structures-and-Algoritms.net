using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public interface IUnionFindImpl
    {
        void connect(int p, int q);
        bool isConnected(int p, int q);
    }
}
