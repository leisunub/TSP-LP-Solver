using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ILOG.Concert;
using ILOG.CPLEX;

namespace TSPsolvers
{
    class SolveN5LP
    {
        public static string commentsX;
        public static string commentsY;
        public static double[, ,] yValues;
        public static double[, , , ,] xValues;
        public static int[] numVarCons;
        public static string solveTime; // seconds

        public static double GetN5LPopt(Node[] nodes, CplexParam simplexMethod, bool ModelOnly, string filePath)
        {
            // start Cplex*********************************************************************************
            try
            {
                Cplex cplex = new Cplex();

                IMPModeler model = cplex;

                // variable x
                INumVar[, , , ,] x = new INumVar[nodes.Length, nodes.Length, nodes.Length, nodes.Length, nodes.Length];
                for (int i = 0; i < nodes.Length; i++)
                    for (int r = 0; r < nodes.Length; r++)
                        for (int j = 0; j < nodes.Length; j++)
                            for (int p = 0; p < nodes.Length; p++)
                                for (int k = 0; k < nodes.Length; k++)
                                    x[i, r, j, p, k] = model.NumVar(0, Double.MaxValue, "x[" + i.ToString() + "," + r.ToString() + "," + j.ToString() + "," + p.ToString() + "," + k.ToString() + "]");

                // variable y
                INumVar[, ,] y = new INumVar[nodes.Length, nodes.Length, nodes.Length];
                for (int i = 0; i < nodes.Length; i++)
                    for (int r = 0; r < nodes.Length; r++)
                        for (int j = 0; j < nodes.Length; j++)
                            y[i, r, j] = model.NumVar(0, Double.MaxValue, "y[" + i.ToString() + "," + r.ToString() + "," + j.ToString() + "]");

                // the objective
                INumExpr sumobj = model.Prod(0.0, x[0, 0, 0, 0, 0]); // initial
                for (int r = 1; r < nodes.Length - 1; r++)
                    for (int i = 1; i < nodes.Length; i++)
                        for (int j = 1; j < nodes.Length; j++)
                        {
                            if (i != j)
                            {
                                sumobj = model.Sum(sumobj, model.Prod(nodes[i].costFromThis[j], y[i, r, j]));
                            }
                        }
                for (int i = 1; i < nodes.Length; i++)
                    for (int j = 1; j < nodes.Length; j++)
                    {
                        if (i != j)
                        {
                            sumobj = model.Sum(sumobj, model.Prod(nodes[0].costFromThis[i], y[i, 1, j]));
                            sumobj = model.Sum(sumobj, model.Prod(nodes[j].costFromThis[0], y[i, nodes.Length - 2, j]));
                        }
                    }
                model.AddMinimize(sumobj);

                // Constraint (1) Initial flow
                for (int cons = 0; cons < 1; cons++)
                {
                    INumExpr sumxs = model.Prod(0.0, x[0, 0, 0, 0, 0]);
                    for (int i = 1; i < nodes.Length; i++)
                        for (int j = 1; j < nodes.Length; j++)
                            for (int k = 1; k < nodes.Length; k++)
                            {
                                if (i != j && k != j && k != i)
                                    sumxs = model.Sum(sumxs, x[i, 1, j, 2, k]);
                            }
                    IRange rng = model.AddEq(sumxs, 1);
                }

                // Constraint (2) Mass Balance/GKE
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 2; r++)
                        for (int j = 1; j < nodes.Length; j++)
                        {
                            INumExpr sumxs = model.Prod(1.0, x[i, r, i, r, j]);
                            for (int k = 1; k < nodes.Length; k++)
                                if (k != i && k != j)
                                    sumxs = model.Sum(sumxs, model.Prod(-1.0, x[i, r, j, r + 1, k]));
                            IRange rng = model.AddEq(sumxs, 0);
                        }

                // Constraint (3) Mass Balance/GKE
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 3; r < nodes.Length; r++)
                        for (int j = 1; j < nodes.Length; j++)
                        {
                            INumExpr sumxs = model.Prod(1.0, x[i, r, j, r - 1, i]);
                            for (int k = 1; k < nodes.Length; k++)
                                if (k != i && k != j)
                                    sumxs = model.Sum(sumxs, model.Prod(-1.0, x[i, r, k, r - 2, j]));
                            IRange rng = model.AddEq(sumxs, 0);
                        }

                // Constraint (4) Mass Balance/GKE
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 2; r < nodes.Length - 1; r++)
                    {
                        INumExpr sumxs = model.Prod(0.0, x[0, 0, 0, 0, 0]);
                        for (int k = 1; k < nodes.Length; k++)
                            if (k != i)
                            {
                                sumxs = model.Sum(sumxs, x[i, r, k, r - 1, i]);
                                sumxs = model.Sum(sumxs, model.Prod(-1.0, x[i, r, i, r, k]));
                            }
                        IRange rng = model.AddEq(sumxs, 0);
                    }

                // Constraint (5) Mass Balance/GKE
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length; r++)
                        for (int u = 1; u < nodes.Length; u++)
                            for (int p = 2; p < nodes.Length - 1; p++)
                            {
                                if (r != p - 1 && r != p && i != u && r != p + 1)
                                {
                                    INumExpr sumxs = model.Prod(0.0, x[0, 0, 0, 0, 0]);
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (u != k && k != i)
                                        {
                                            sumxs = model.Sum(sumxs, x[i, r, k, p - 1, u]);
                                            sumxs = model.Sum(sumxs, model.Prod(-1.0, x[i, r, u, p, k]));
                                        }
                                    IRange rng = model.AddEq(sumxs, 0);
                                }
                            }

                // Constraint (6) Node-pair Reciprocities
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 2; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            for (int k = 1; k < nodes.Length; k++)
                                if (i != j && i != k && j != k)
                                {
                                    INumExpr sumxs = model.Sum(x[i, r, k, r + 1, j], model.Prod(-1.0, x[j, r + 2, i, r, k]));
                                    IRange rng = model.AddEq(sumxs, 0);
                                }

                // Constraint (7) Node-pair Reciprocities
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 2; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            for (int s = r + 3; s < nodes.Length; s++)
                                if (i != j)
                                {
                                    INumExpr sumxs = model.Prod(0.0, x[0, 0, 0, 0, 0]);
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != j && k != i)
                                        {
                                            sumxs = model.Sum(sumxs, x[i, r, k, s - 1, j]);
                                            sumxs = model.Sum(sumxs, model.Prod(-1.0, x[j, s, i, r, k]));
                                        }
                                    IRange rng = model.AddEq(sumxs, 0);
                                }

                // Constraint (8) Flow Consistencies
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 1; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            if (i != j)
                            {
                                INumExpr sumxs = model.Sum(y[i, r, j], model.Prod(-1.0, x[i, r, i, r, j]));
                                IRange rng = model.AddEq(sumxs, 0);
                            }

                // Constraint (9) Flow Consistencies
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 1; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            if (i != j)
                            {
                                INumExpr sumxs = model.Sum(y[i, r, j], model.Prod(-1.0, x[j, r + 1, i, r, j]));
                                IRange rng = model.AddEq(sumxs, 0);
                            }

                // Constraint (10) Visit Requirements for Arcs
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 1; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            for (int s = 1; s < nodes.Length; s++)
                                if (i != j && s != r && s != r + 1)
                                {
                                    INumExpr sumxs = model.Prod(1.0, y[i, r, j]);
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != j && k != i)
                                            sumxs = model.Sum(sumxs, model.Prod(-1.0, x[k, s, i, r, j]));
                                    IRange rng = model.AddEq(sumxs, 0);
                                }

                // Constraint (11) Visit Requirements for Arcs
                for (int i = 1; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length - 1; r++)
                        for (int j = 1; j < nodes.Length; j++)
                            for (int u = 1; u < nodes.Length; u++)
                                if (i != j && i != u && j != u)
                                {
                                    INumExpr sumxs = model.Prod(1.0, y[i, r, j]);
                                    for (int s = 1; s < nodes.Length; s++)
                                        if (s != r && s != r + 1)
                                            sumxs = model.Sum(sumxs, model.Prod(-1.0, x[u, s, i, r, j]));
                                    IRange rng = model.AddEq(sumxs, 0);
                                }

                // Constraint (12) Visit Requirements for Nodes
                for (int i = 2; i < nodes.Length; i++)
                    for (int r = 1; r < nodes.Length; r++)
                        for (int u = 2; u < nodes.Length; u++)
                            if (i != u)
                            {
                                INumExpr sumxs = model.Prod(0.0, x[0, 0, 0, 0, 0]);
                                if (r != 1)
                                    sumxs = model.Sum(sumxs, model.Sum(x[i, r, u, r - 1, i], model.Prod(-1.0, x[i, r, 1, r - 1, i])));
                                if (r != nodes.Length - 1)
                                    sumxs = model.Sum(sumxs, model.Sum(x[i, r, i, r, u], model.Prod(-1.0, x[i, r, i, r, 1])));

                                for (int p = 1; p < r - 1; p++)
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != u && k != i)
                                            sumxs = model.Sum(sumxs, x[i, r, u, p, k]);
                                for (int p = r + 1; p < nodes.Length - 1; p++)
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != u && k != i)
                                            sumxs = model.Sum(sumxs, x[i, r, k, p, u]);
                                for (int q = 1; q < r - 1; q++)
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != 1 && k != i)
                                            sumxs = model.Sum(sumxs, model.Prod(-1.0, x[i, r, 1, q, k]));
                                for (int q = r + 1; q < nodes.Length - 1; q++)
                                    for (int k = 1; k < nodes.Length; k++)
                                        if (k != 1 && k != i)
                                            sumxs = model.Sum(sumxs, model.Prod(-1.0, x[i, r, k, q, 1]));
                                IRange rng = model.AddEq(sumxs, 0);
                            }

                // Constraint (13) Visit Requirements for Nodes
                for (int r = 1; r < nodes.Length; r++)
                    for (int u = 3; u < nodes.Length; u++)
                    {
                        INumExpr sumxs = model.Prod(0.0, x[0, 0, 0, 0, 0]);
                        if (r != 1)
                            sumxs = model.Sum(sumxs, model.Sum(x[1, r, u, r - 1, 1], model.Prod(-1.0, x[1, r, 2, r - 1, 1])));
                        if (r != nodes.Length - 1)
                            sumxs = model.Sum(sumxs, model.Sum(x[1, r, 1, r, u], model.Prod(-1.0, x[1, r, 1, r, 2])));

                        for (int p = 1; p < r - 1; p++)
                            for (int k = 2; k < nodes.Length; k++)
                                if (k != u && k != 1)
                                    sumxs = model.Sum(sumxs, x[1, r, u, p, k]);
                        for (int p = r + 1; p < nodes.Length - 1; p++)
                            for (int k = 2; k < nodes.Length; k++)
                                if (k != u && k != 1)
                                    sumxs = model.Sum(sumxs, x[1, r, k, p, u]);
                        for (int q = 1; q < r - 1; q++)
                            for (int k = 3; k < nodes.Length; k++)
                                sumxs = model.Sum(sumxs, model.Prod(-1.0, x[1, r, 2, q, k]));
                        for (int q = r + 1; q < nodes.Length - 1; q++)
                            for (int k = 3; k < nodes.Length; k++)
                                sumxs = model.Sum(sumxs, model.Prod(-1.0, x[1, r, k, q, 2]));
                        IRange rng = model.AddEq(sumxs, 0);
                    }

                // write the .lp file
                cplex.ExportModel(filePath);

                // solve by splex
                double optCost = -1.0;
                numVarCons = new int[2];
                numVarCons[0] = cplex.Ncols - 1; // exclude x[0,0,0,0,0]
                numVarCons[1] = cplex.Nrows;

                if (!ModelOnly)
                {
                    if (simplexMethod.rootAlg[0] == 1)
                        cplex.SetParam(Cplex.IntParam.RootAlg, simplexMethod.rootAlg[1]);
                    if (simplexMethod.barCrossAlg[0] == 1)
                        cplex.SetParam(Cplex.IntParam.BarCrossAlg, simplexMethod.barCrossAlg[1]);
                    if (simplexMethod.barEpComp[0] == 1)
                        cplex.SetParam(Cplex.DoubleParam.BarEpComp, simplexMethod.barEpComp[1]);
                    if (simplexMethod.barMaxCor[0] == 1)
                        cplex.SetParam(Cplex.IntParam.BarMaxCor, simplexMethod.barMaxCor[1]);
                    if (simplexMethod.epMrk[0] == 1)
                        cplex.SetParam(Cplex.DoubleParam.EpMrk, simplexMethod.epMrk[1]);
                    if (simplexMethod.epOpt[0] == 1)
                        cplex.SetParam(Cplex.DoubleParam.EpOpt, simplexMethod.epOpt[1]);
                    if (simplexMethod.numericalEmphasis[0])
                        cplex.SetParam(Cplex.BooleanParam.NumericalEmphasis, simplexMethod.numericalEmphasis[1]);
                    if (simplexMethod.workMem[0] == 1)
                        cplex.SetParam(Cplex.DoubleParam.WorkMem, simplexMethod.workMem[1]);

                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    if (cplex.Solve())
                    {
                        solveTime = sw.Elapsed.TotalSeconds.ToString() + " seconds";
                        sw.Stop();
                        // output the results
                        optCost = cplex.GetObjValue();

                        double accuracy = 0.000001;
                        yValues = new double[nodes.Length, nodes.Length, nodes.Length];
                        commentsY = "";
                        for (int i = 1; i < nodes.Length; i++)
                            for (int r = 1; r < nodes.Length; r++)
                                for (int j = 1; j < nodes.Length; j++)
                                    if (i != j)
                                    {
                                        try
                                        {
                                            double temp = cplex.GetValue(y[i, r, j]);
                                            if (temp > accuracy)
                                            {
                                                commentsY += y[i, r, j].Name + ":" + temp.ToString() + ";";
                                                yValues[i, r, j] = temp;
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }
                        xValues = new double[nodes.Length, nodes.Length, nodes.Length, nodes.Length, nodes.Length];
                        commentsX = "";
                        for (int i = 1; i < nodes.Length; i++)
                            for (int r = 1; r < nodes.Length; r++)
                                for (int j = 1; j < nodes.Length; j++)
                                    for (int p = 1; p < nodes.Length; p++)
                                        for (int k = 1; k < nodes.Length; k++)
                                            if (r != p && r != p + 1 && p + 1 != nodes.Length)
                                            {
                                                try
                                                {
                                                    double temp = cplex.GetValue(x[i, r, j, p, k]);
                                                    if (temp > accuracy)
                                                    {
                                                        commentsX += x[i, r, j, p, k].Name + ":" + temp.ToString() + ";";
                                                        xValues[i, r, j, p, k] = temp;
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
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
