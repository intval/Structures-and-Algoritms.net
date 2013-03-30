using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public class QuickUnion : IUnionFindImpl
    {
        private int[] grid;

        public QuickUnion(int Size)
        {
            grid = new int[Size];
            Parallel.For(0, Size, (i) => grid[i] = i);
        }

        /*
         * This creates a tall tree con(1,2), con(2,3), con(3,4), etc..
         * Finding the root of a leaf might eventually become N
         * To avoid that, we can use WeighedUnion which will put the smaller tree
         * asd child of the bigger tree.
         * See WeighedUnion
         */

        public void connect(int p, int q)
        {
            grid[p] = grid[q];
        }

        public bool isConnected(int p, int q)
        {
            return root(p) == root(q);
        }

        private int root(int key)
        {
            while (grid[key] != key)
                key = grid[key];

            return key;
        }
    }
}
