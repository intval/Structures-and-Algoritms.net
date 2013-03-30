using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnionFind
{
    public class QuickFind : IUnionFindImpl
    {
        int[] grid;
        
        public QuickFind(int Size)
        {
            grid = new int[Size];

            for (int i = 1; i < Size; i++)
                grid[i] = i;
        }

        public void connect(int p, int q)
        {
            if (p < 0 || p > grid.Length || q < 0 || q > grid.Length)
                throw new ArgumentOutOfRangeException();

            int oldGroup = grid[p];
            int newGroup = grid[q];

            Parallel.For(0, grid.Length, (i) => { 
                Interlocked.CompareExchange(ref grid[i], newGroup, oldGroup);
            });
        }

        public bool isConnected(int p, int q)
        {
            if (p < 0 || p > grid.Length || q < 0 || q > grid.Length)
                throw new ArgumentOutOfRangeException();

            return grid[p] == grid[q];
        }
    }
}
