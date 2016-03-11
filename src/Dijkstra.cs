using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSPsolvers
{
    class Dijkstra
    {
        private int rank = 0;
        private double[,] L;
        private int[] C;
        public double[] D;
        public void DijkstraRun(int paramRank, double[,] paramArray, int startNode)
        {
            L = new double[paramRank, paramRank];
            C = new int[paramRank];
            D = new double[paramRank];
            rank = paramRank;
            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank; j++)
                {
                    L[i, j] = paramArray[i, j];
                }
            }

            for (int i = 0; i < rank; i++)
            {
                C[i] = i;
            }
            C[startNode] = -1;
            for (int i = 0; i < rank; i++)
                if (i != startNode)
                    D[i] = L[startNode, i];

            for (int trank = 1; trank < rank; trank++)
                DijkstraSolving();
        }

        private void DijkstraSolving()
        {
            double minValue = Double.MaxValue;
            int minNode = 0;
            for (int i = 0; i < rank; i++)
            {
                if (C[i] == -1)
                    continue;
                if (D[i] < minValue)
                {
                    minValue = D[i];
                    minNode = i;
                }
            }
            C[minNode] = -1;
            for (int i = 0; i < rank; i++)
            {
                if ((D[minNode] + L[minNode, i]) < D[i])
                    D[i] = minValue + L[minNode, i];
            }
        }
    }
}
