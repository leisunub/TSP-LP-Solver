using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSPsolvers
{
    class Node
    {
        public int Id;
        public double x;
        public double y;

        public double[] costFromThis;

        public Node()
        {
            x = 0;
            y = 0;
        }

        public Node(Random r)
        {
            x = r.Next(0, 100);
            y = r.Next(0, 100);
        }

        public void CoordinateReset(double x1, double y1)
        {
            x = x1;
            y = y1;
        }

        public void CreateCosts(Node[] nds, Random r, double perRange1, double perRange2)
        {
            costFromThis = new double[nds.Length];
            for (int i = 0; i < nds.Length; i++)
            {
                double distance = Math.Sqrt((x - nds[i].x) * (x - nds[i].x) + (y - nds[i].y) * (y - nds[i].y));
                if (perRange1 == 1.0 && perRange2 == 1.0)
                    costFromThis[i] = distance;
                else
                    costFromThis[i] = distance * (r.NextDouble() * (perRange2 - perRange1) + perRange1);
            }
        }

        public void CreateCosts(int numNodes,Random r, double range1, double range2)
        {
            costFromThis = new double[numNodes];
            for (int i = 0; i < numNodes; i++)
            {
                costFromThis[i] = r.NextDouble() * (range2 - range1) + range1;
            }
        }
    }
}
