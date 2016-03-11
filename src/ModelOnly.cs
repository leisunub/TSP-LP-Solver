using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSPsolvers
{
    class ModelOnly
    {
        public static void MTZ(Node[] nodes, string filePath)
        {
            string[,] varX = new string[nodes.Length, nodes.Length];
            string[] varU = new string[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
                for (int j = 0; j < nodes.Length; j++)
                    varX[i, j] = "x(" + i.ToString() + "," + j.ToString() + ")";
            for (int i = 0; i < nodes.Length; i++)
                varU[i] = "u(" + i.ToString() + ")";
            int consNum = 0;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, false))
            {
                file.WriteLine("\\Problem name: MTZ model for TSP");
                file.WriteLine("\\Built on: " + DateTime.Now.ToString());
                file.WriteLine();

                // the objective
                file.WriteLine("Minimize");
                string obj = " obj: ";
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        if (i != j)
                        {
                            if (obj != " obj: ")
                                obj += " + ";
                            obj += nodes[i].costFromThis[j].ToString() + " " + varX[i, j];
                        }
                    }
                file.WriteLine(obj);

                file.WriteLine("Subject To");
                // constraints
                for (int i = 0; i < nodes.Length; i++)
                {
                    string cons = " c" + consNum.ToString() + ": ";
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        if (i != j)
                        {
                            if (cons != " c" + consNum.ToString() + ": ")
                                cons += " + ";
                            cons += varX[i, j];
                        }
                    }
                    cons += " = 1";
                    file.WriteLine(cons);
                    consNum++;
                }
                for (int i = 0; i < nodes.Length; i++)
                {
                    string cons = " c" + consNum.ToString() + ": ";
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        if (i != j)
                        {
                            if (cons != " c" + consNum.ToString() + ": ")
                                cons += " + ";
                            cons += varX[j, i];
                        }
                    }
                    cons += " = 1";
                    file.WriteLine(cons);
                    consNum++;
                }
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        if (i != j)
                        {
                            if (i > 0 && j > 0)
                            {
                                string cons = " c" + consNum.ToString() + ": ";
                                cons += (nodes.Length - 1).ToString() + " " + varX[i, j];
                                cons += " + " + varU[i];
                                cons += " - " + varU[j];
                                cons += " <= " + (nodes.Length - 2).ToString();
                                file.WriteLine(cons);
                                consNum++;
                            }
                        }
                    }

                file.WriteLine("Bounds");
                // variables
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = 0; j < nodes.Length; j++)
                        if (i != j)
                            file.WriteLine("0 <= " + varX[i, j] + " <= 1");
                for (int i = 1; i < nodes.Length; i++)
                    file.WriteLine("1 <= " + varU[i] + " <= " + (nodes.Length - 1).ToString());
                file.WriteLine("Generals");
                string vars = "";
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = 0; j < nodes.Length; j++)
                        if (i != j)
                            vars += varX[i, j] + " ";
                file.WriteLine(vars);

                file.WriteLine("End");
            }
        }

        public static void N5LP(Node[] nodes, string filePath)
        {
            int consNum = 0;

            string[, , , ,] x = new string[nodes.Length, nodes.Length, nodes.Length, nodes.Length, nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
                for (int r = 0; r < nodes.Length; r++)
                    for (int j = 0; j < nodes.Length; j++)
                        for (int p = 0; p < nodes.Length; p++)
                            for (int k = 0; k < nodes.Length; k++)
                                x[i, r, j, p, k] = "x(" + i.ToString() + "," + r.ToString() + "," + j.ToString() + "," + p.ToString() + "," + k.ToString() + ")";
            string[, ,] y = new string[nodes.Length, nodes.Length, nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
                for (int r = 0; r < nodes.Length; r++)
                    for (int j = 0; j < nodes.Length; j++)
                        y[i, r, j] = "y(" + i.ToString() + "," + r.ToString() + "," + j.ToString() + ")";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, false))
            {
                file.WriteLine("\\Problem name: N5LP model for TSP");
                file.WriteLine("\\Built on: " + DateTime.Now.ToString());
                file.WriteLine();

                // the objective
                file.WriteLine("Minimize");
                string obj = " obj: ";
                for (int r = 1; r < nodes.Length - 1; r++)
                    for (int i = 1; i < nodes.Length; i++)
                        for (int j = 1; j < nodes.Length; j++)
                        {
                            if (i != j)
                            {
                                if (obj != " obj: ")
                                    obj += " + ";
                                obj += nodes[i].costFromThis[j].ToString() + " " + y[i, r, j];
                            }
                        }
                for (int i = 1; i < nodes.Length; i++)
                    for (int j = 1; j < nodes.Length; j++)
                    {
                        if (i != j)
                        {
                            obj += " + " + nodes[0].costFromThis[i] + " " + y[i, 1, j];
                            obj += " + " + nodes[j].costFromThis[0] + " " + y[i, nodes.Length - 2, j];
                        }
                    }
                file.WriteLine(obj);

                file.WriteLine("Subject To");
                // Constraint (1) Initial flow
                for (int cons = 0; cons < 1; cons++)
                {
                    string sumxs = " c" + consNum.ToString() + ": ";
                    for (int i = 1; i < nodes.Length; i++)
                        for (int j = 1; j < nodes.Length; j++)
                            for (int k = 1; k < nodes.Length; k++)
                            {
                                if (i != j && k != j && k != i)
                                {
                                    if (sumxs != " c" + consNum.ToString() + ": ")
                                        sumxs += " + ";
                                    sumxs += x[i, 1, j, 2, k];
                                }
                            }
                    file.WriteLine(sumxs + " = 1");
                    consNum++;
                }

                // Constraint (2) Mass Balance/GKE
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 2; r++)
                        for (int j = 1; j < nodes.Length; j++)
                        {
                            string sumxs = " c" + consNum.ToString() + ": ";
                            sumxs += x[i, r, i, r, j];
                            for (int k = 1; k < nodes.Length; k++)
                                if (k != i && k != j)
                                    sumxs += " - " + x[i, r, j, r + 1, k];
                            file.WriteLine(sumxs + " = 0");
                            consNum++;
                        }

                // Constraint (3) Mass Balance/GKE
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 3; r < nodes.Length; r++)
                        for (int j = 1; j < nodes.Length; j++)
                        {
                            string sumxs = " c" + consNum.ToString() + ": ";
                            sumxs += x[i, r, j, r - 1, i];
                            for (int k = 1; k < nodes.Length; k++)
                                if (k != i && k != j)
                                    sumxs += " - " + x[i, r, k, r - 2, j];
                            file.WriteLine(sumxs + " = 0");
                            consNum++;
                        }

                // Constraint (4) Mass Balance/GKE
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 2; r < nodes.Length - 1; r++)
                    {
                        string sumxs = " c" + consNum.ToString() + ": ";
                        for (int k = 1; k < nodes.Length; k++)
                            if (k != i)
                            {
                                if (sumxs != " c" + consNum.ToString() + ": ")
                                    sumxs += " + ";
                                sumxs += x[i, r, k, r - 1, i] + " - " + x[i, r, i, r, k];
                            }
                        file.WriteLine(sumxs + " = 0");
                        consNum++;
                    }

                // Constraint (5) Mass Balance/GKE
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length; r++)
                        for (int u = 1; u < nodes.Length; u++)
                            for (int p = 2; p < nodes.Length - 1; p++)
                            {
                                if (r != p - 1 && r != p && i != u && r != p + 1)
                                {
                                    string sumxs = " c" + consNum.ToString() + ": ";
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (u != k && k != i)
                                        {
                                            if (sumxs != " c" + consNum.ToString() + ": ")
                                                sumxs += " + ";
                                            sumxs += x[i, r, k, p - 1, u] + " - " + x[i, r, u, p, k];
                                        }
                                    file.WriteLine(sumxs + " = 0");
                                    consNum++;
                                }
                            }

                // Constraint (6) Node-pair Reciprocities
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 2; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            for (int k = 1; k < nodes.Length; k++)
                                if (i != j && i != k && j != k)
                                {
                                    string sumxs = " c" + consNum.ToString() + ": ";
                                    sumxs += x[i, r, k, r + 1, j] + " - " + x[j, r + 2, i, r, k];
                                    file.WriteLine(sumxs + " = 0");
                                    consNum++;
                                }

                // Constraint (7) Node-pair Reciprocities
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 2; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            for (int s = r + 3; s < nodes.Length; s++)
                                if (i != j)
                                {
                                    string sumxs = " c" + consNum.ToString() + ": ";
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != j && k != i)
                                        {
                                            if (sumxs != " c" + consNum.ToString() + ": ")
                                                sumxs += " + ";
                                            sumxs += x[i, r, k, s - 1, j] + " - " + x[j, s, i, r, k];
                                        }
                                    file.WriteLine(sumxs + " = 0");
                                    consNum++;
                                }

                // Constraint (8) Flow Consistencies
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 1; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            if (i != j)
                            {
                                string sumxs = " c" + consNum.ToString() + ": ";
                                sumxs += y[i, r, j] + " - " + x[i, r, i, r, j];
                                file.WriteLine(sumxs + " = 0");
                                consNum++;
                            }

                // Constraint (9) Flow Consistencies
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 1; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            if (i != j)
                            {
                                string sumxs = " c" + consNum.ToString() + ": ";
                                sumxs += y[i, r, j] + " - " + x[j, r + 1, i, r, j];
                                file.WriteLine(sumxs + " = 0");
                                consNum++;
                            }

                // Constraint (10) Visit Requirements for Arcs
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 1; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            for (int s = 1; s < nodes.Length; s++)
                                if (i != j && s != r && s != r + 1)
                                {
                                    string sumxs = " c" + consNum.ToString() + ": ";
                                    sumxs += y[i, r, j];
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != j && k != i)
                                            sumxs += " - " + x[k, s, i, r, j];
                                    file.WriteLine(sumxs + " = 0");
                                    consNum++;
                                }

                // Constraint (11) Visit Requirements for Arcs
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 1; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            for (int u = 1; u < nodes.Length; u++)
                                if (i != j && i != u && j != u)
                                {
                                    string sumxs = " c" + consNum.ToString() + ": ";
                                    sumxs += y[i, r, j];
                                    for (int s = 1; s < nodes.Length; s++)
                                        if (s != r && s != r + 1)
                                            sumxs += " - " + x[u, s, i, r, j];
                                    file.WriteLine(sumxs + " = 0");
                                    consNum++;
                                }

                // Constraint (12) Visit Requirements for Nodes
                for (int i = 2; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length; r++)
                        for (int u = 2; u < nodes.Length; u++)
                            if (i != u)
                            {
                                string sumxs = " c" + consNum.ToString() + ": ";
                                if (r != 1)
                                {
                                    if (sumxs != " c" + consNum.ToString() + ": ")
                                        sumxs += " + ";
                                    sumxs += x[i, r, u, r - 1, i] + " - " + x[i, r, 1, r - 1, i];
                                }
                                if (r != nodes.Length - 1)
                                {
                                    if (sumxs != " c" + consNum.ToString() + ": ")
                                        sumxs += " + ";
                                    sumxs += x[i, r, i, r, u] + " - " + x[i, r, i, r, 1];
                                }

                                for (int p = 1; p < r - 1; p++)
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != u && k != i)
                                        {
                                            if (sumxs != " c" + consNum.ToString() + ": ")
                                                sumxs += " + ";
                                            sumxs += x[i, r, u, p, k];
                                        }
                                for (int p = r + 1; p < nodes.Length - 1; p++)
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != u && k != i)
                                        {
                                            if (sumxs != " c" + consNum.ToString() + ": ")
                                                sumxs += " + ";
                                            sumxs += x[i, r, k, p, u];
                                        }
                                for (int q = 1; q < r - 1; q++)
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != 1 && k != i)
                                        {
                                            if (sumxs != " c" + consNum.ToString() + ": ")
                                                sumxs += " - ";
                                            sumxs += x[i, r, 1, q, k];
                                        }
                                for (int q = r + 1; q < nodes.Length - 1; q++)
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != 1 && k != i)
                                        {
                                            if (sumxs != " c" + consNum.ToString() + ": ")
                                                sumxs += " - ";
                                            sumxs += x[i, r, k, q, 1];
                                        }
                                file.WriteLine(sumxs + " = 0");
                                consNum++;
                            }

                // Constraint (13) Visit Requirements for Nodes
                for (int r = 1; r < nodes.Length; r++)
                    for (int u = 3; u < nodes.Length; u++)
                    {
                        string sumxs = " c" + consNum.ToString() + ": ";
                        if (r != 1)
                        {
                            if (sumxs != " c" + consNum.ToString() + ": ")
                                sumxs += " + ";
                            sumxs += x[1, r, u, r - 1, 1] + " - " + x[1, r, 2, r - 1, 1];
                        }
                        if (r != nodes.Length - 1)
                        {
                            if (sumxs != " c" + consNum.ToString() + ": ")
                                sumxs += " + ";
                            sumxs += x[1, r, 1, r, u] + " - " + x[1, r, 1, r, 2];
                        }

                        for (int p = 1; p < r - 1; p++)
                            for (int k = 2; k < nodes.Length; k++)
                                if (k != u && k != 1)
                                {
                                    if (sumxs != " c" + consNum.ToString() + ": ")
                                        sumxs += " + ";
                                    sumxs += x[1, r, u, p, k];
                                }
                        for (int p = r + 1; p < nodes.Length - 1; p++)
                            for (int k = 2; k < nodes.Length; k++)
                                if (k != u && k != 1)
                                {
                                    if (sumxs != " c" + consNum.ToString() + ": ")
                                        sumxs += " + ";
                                    sumxs += x[1, r, k, p, u];
                                }
                        for (int q = 1; q < r - 1; q++)
                            for (int k = 3; k < nodes.Length; k++)
                            {
                                if (sumxs != " c" + consNum.ToString() + ": ")
                                    sumxs += " - ";
                                sumxs += x[1, r, 2, q, k];
                            }
                        for (int q = r + 1; q < nodes.Length - 1; q++)
                            for (int k = 3; k < nodes.Length; k++)
                            {
                                if (sumxs != " c" + consNum.ToString() + ": ")
                                    sumxs += " - ";
                                sumxs += x[1, r, k, q, 2];
                            }
                        file.WriteLine(sumxs + " = 0");
                        consNum++;
                    }

                file.WriteLine("End");
            }
        }
    }
}
