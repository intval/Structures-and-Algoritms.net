using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public class WeighedQuickUnion : IUnionFindImpl
    {
        int[] grid;
        int[] treeSizes;

        public WeighedQuickUnion(int Size)
        {
            grid = new int[Size];
            treeSizes = new int[Size];
            Parallel.For(0, Size, i => grid[i] = i);
        }

        public void connect(int p, int q)
        {
            if (treeSizes[p] < treeSizes[q])
            {
                treeSizes[p]++;
                grid[q] = grid[p];
            }
            else
            {
                treeSizes[q]++;
                grid[p] = grid[q];
            }
        }

        public bool isConnected(int p, int q)
        {
            return root(p) == root(q);
        }

        private int root(int p)
        {
            while (grid[p] != p)
                p = grid[p];

            return p;
        }
    }
}
