using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ILOG.Concert;
using ILOG.CPLEX;

namespace TSPsolvers
{
    class SolveMTZ
    {
        private static int[] optOrder;
        public static double GetMTZopt(Node[] nodes, bool ModelOnly, string filePath)
        {
            // start Cplex*********************************************************************************
            try
            {
                Cplex cplex = new Cplex();

                INumVar[][] var = new INumVar[2][];
                IRange[][] rng = new IRange[3][];

                IMPModeler model = cplex;

                // variable x
                int numVarX = nodes.Length * (nodes.Length - 1);
                int[] xlb = new int[numVarX];
                int[] xub = new int[numVarX];
                string[] varNameX = new string[numVarX];
                numVarX = 0;
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        if (i != j)
                        {
                            xlb[numVarX] = 0;
                            xub[numVarX] = 1;
                            varNameX[numVarX] = "x[" + i.ToString() + "," + j.ToString() + "]";
                            numVarX++;
                        }
                    }
                var[0] = model.IntVarArray(numVarX, xlb, xub, varNameX);

                // variable u
                int numVarU = nodes.Length - 1;
                double[] ulb = new double[numVarU];
                double[] uub = new double[numVarU];
                string[] varNameU = new string[numVarU];
                numVarU = 0;
                for (int i = 0; i < nodes.Length - 1; i++)
                {
                    ulb[numVarU] = 1;
                    uub[numVarU] = nodes.Length - 1;
                    varNameU[numVarU] = "u[" + (i + 1).ToString() + "]";
                    numVarU++;
                }
                var[1] = model.NumVarArray(numVarU, ulb, uub, varNameU);

                // the objective
                INumExpr sumobj = model.Prod(0.0, var[0][0]); // initial
                numVarX = 0;
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        if (i != j)
                        {
                            double dist = nodes[i].costFromThis[j];
                            sumobj = model.Sum(model.Prod(dist, var[0][numVarX]), sumobj);
                            numVarX++;
                        }
                    }
                model.AddMinimize(sumobj);

                // the constraints (1)
                rng[0] = new IRange[nodes.Length];
                for (int cons = 0; cons < nodes.Length; cons++)
                {
                    INumExpr sumxs = model.Prod(0.0, var[0][0]);

                    numVarX = 0;
                    for (int i = 0; i < nodes.Length; i++)
                        for (int j = 0; j < nodes.Length; j++)
                        {
                            if (i != j)
                            {
                                if (i == cons)
                                    sumxs = model.Sum(sumxs, var[0][numVarX]);
                                numVarX++;
                            }
                        }
                    rng[0][cons] = model.AddEq(sumxs, 1);
                }

                // the constraints (2)
                rng[1] = new IRange[nodes.Length];
                for (int cons = 0; cons < nodes.Length; cons++)
                {
                    INumExpr sumxs = model.Prod(0.0, var[0][0]);

                    numVarX = 0;
                    for (int i = 0; i < nodes.Length; i++)
                        for (int j = 0; j < nodes.Length; j++)
                        {
                            if (i != j)
                            {
                                if (j == cons)
                                    sumxs = model.Sum(sumxs, var[0][numVarX]);
                                numVarX++;
                            }
                        }
                    rng[1][cons] = model.AddEq(sumxs, 1);
                }

                // the constraints (3)
                rng[2] = new IRange[(nodes.Length - 1) * (nodes.Length - 2)];
                numVarX = 0;
                int consNum = 0;
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        if (i != j)
                        {
                            if (i > 0 && j > 0)
                            {
                                INumExpr sumorder = model.Prod(nodes.Length - 1, var[0][numVarX]);
                                sumorder = model.Sum(model.Prod(-1.0, var[1][j - 1]), sumorder);
                                sumorder = model.Sum(var[1][i - 1], sumorder);
                                rng[2][consNum] = model.AddLe(sumorder, nodes.Length - 2);
                                consNum++;
                            }
                            numVarX++;
                        }
                    }

                // write the .lp file
                cplex.ExportModel(filePath);

                // solve by splex
                double optCost = -1.0;
                if (!ModelOnly)
                {
                    optOrder = new int[nodes.Length];
                    if (cplex.Solve())
                    {
                        // output the results
                        optCost = cplex.GetObjValue();

                        double[] uValues = cplex.GetValues(var[1]);
                        for (int i = 0; i < uValues.Length; i++)
                            optOrder[Convert.ToInt32(uValues[i])] = i + 1;
                    }
                }
                cplex.End();
                return optCost;
            }
            catch (ILOG.Concert.Exception err)
            {
                System.Windows.Forms.MessageBox.Show("Concert exception '" + err + "' caught");
                return -100.0;
            }
            // end CPLEX *************************************************************
        }
    }
}
