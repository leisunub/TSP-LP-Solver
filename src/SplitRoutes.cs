using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ILOG.Concert;
using ILOG.CPLEX;

namespace TSPsolvers
{
    class SplitRoutes
    {
        public static string optRoutes;

        public static void SplitRoutesByY(double[, ,] yValues, int numNodes)
        {
            optRoutes = "";
            double accuracy = 0.000001;

            do
            {
                List<int> singleRoute = new List<int>();
                singleRoute.Add(0);

                // initial
                for (int i = 1; i < numNodes; i++)
                {
                    for (int j = 1; j < numNodes; j++)
                        if (i != j)
                            if (yValues[i, 1, j] > accuracy)
                            {
                                singleRoute.Add(i);
                                singleRoute.Add(j);
                                break;
                            }
                    if (singleRoute.Count > 1)
                        break;
                }

                // the remaining part of this route
                List<int>[] banlist = new List<int>[numNodes];
                banlist[0] = new List<int>();
                banlist[1] = new List<int>();
                banlist[2] = new List<int>();
                banlist[3] = new List<int>();
                for (int r = 3; r < numNodes; r++)
                {
                    for (int k = r + 1; k < numNodes; k++)
                        banlist[k] = new List<int>(); // clear all ban lists after position r

                    for (int j = 1; j < numNodes; j++)
                    {
                        if (singleRoute.Contains(j) || banlist[r].Contains(j))
                            continue;
                        if (yValues[singleRoute[r - 1], r - 1, j] > accuracy)
                        {
                            singleRoute.Add(j);
                            break;
                        }
                    }

                    if (singleRoute.Count == r) // nothing found for position r, then put the city at r-1 to the ban list
                    {
                        banlist[r - 1].Add(singleRoute[r - 1]);
                        singleRoute.RemoveAt(r - 1);
                        r = r - 2;
                    }

                    if (r == 1)
                        break; // fail to find a route
                }

                if (singleRoute.Count != numNodes)
                {
                    optRoutes += "Use EnumerSplitByY() method to find more (all) routes.";
                    //for (int i = 1; i < numNodes; i++)
                    //    for (int r = 1; r < numNodes; r++)
                    //        for (int j = 1; j < numNodes; j++)
                    //            if (i != j)
                    //            {
                    //                if (yValues[i, r, j] > 0)
                    //                    optRoutes += ";y[" + i.ToString() + "," + r.ToString() + "," + j.ToString() + "]=" + yValues[i, r, j].ToString();
                    //            }
                    break;
                }
                else
                {
                    optRoutes += "0";
                    for (int i = 1; i < numNodes; i++)
                        optRoutes += "-" + singleRoute[i].ToString();
                    optRoutes += ";";
                }

                // update y
                double minY = Double.MaxValue;
                for (int i = 1; i < numNodes - 1; i++)
                    if (minY > yValues[singleRoute[i], i, singleRoute[i + 1]])
                        minY = yValues[singleRoute[i], i, singleRoute[i + 1]];
                for (int i = 1; i < numNodes - 1; i++)
                    yValues[singleRoute[i], i, singleRoute[i + 1]] -= minY;
                double maxYvalue = Double.MinValue;
                for (int i = 1; i < numNodes; i++)
                    for (int r = 1; r < numNodes; r++)
                        for (int j = 1; j < numNodes; j++)
                            if (i != j)
                            {
                                // check if empty
                                if (maxYvalue < yValues[i, r, j])
                                    maxYvalue = yValues[i, r, j];
                            }
                if (maxYvalue < accuracy)
                    break;

            } while (true);
        }

        public static void EnumerSplitByY(double[, ,] yValues, int numNodes, string filePath)
        {
            List<int[]> enumeration = new List<int[]>();

            var arr = new int[numNodes - 1];
            for (int i = 0; i < numNodes - 1; i++)
                arr[i] = i + 1;

            int[] comb = new int[arr.Length + 1];
            comb[0] = 0;
            for (int i = 0; i < arr.Length; i++)
                comb[i + 1] = arr[i];
            enumeration.Add(comb);

            while (!NextPermutation(arr))
            {
                comb = new int[arr.Length + 1];
                comb[0] = 0;
                for (int i = 0; i < arr.Length; i++)
                    comb[i + 1] = arr[i];
                enumeration.Add(comb);
            }

            // enumerate all
            int[][, ,] ys = new int[enumeration.Count][, ,];
            for (int k = 0; k < enumeration.Count; k++)
            {
                ys[k] = new int[numNodes, numNodes, numNodes];
                for (int r = 1; r < numNodes - 1; r++)
                    ys[k][enumeration[k][r], r, enumeration[k][r + 1]] = 1;
            }

            EnumerSplitByYSolve(ys, yValues, numNodes, enumeration, filePath);
        }
        private static void EnumerSplitByYSolve(int[][, ,] ys, double[, ,] yValues, int numNodes, List<int[]> enumeration, string filePath)
        {
            optRoutes = "";
            double eps = 0.0000001;
            // start Cplex*********************************************************************************
            try
            {
                Cplex cplex = new Cplex();
                IMPModeler model = cplex;

                // variable x
                INumVar[] x = new INumVar[ys.Length];
                for (int i = 0; i < ys.Length; i++)
                    x[i] = model.NumVar(0, Double.MaxValue, "x[" + i.ToString() + "]");


                // the objective
                INumExpr sumobj = model.Prod(1.0, x[1]); // initial
                model.AddMinimize(sumobj);

                // Constraint
                for (int i = 0; i < numNodes; i++)
                    for (int r = 0; r < numNodes; r++)
                        for (int j = 0; j < numNodes; j++)
                        {
                            double weightTotal = 0.0;
                            for (int k = 0; k < ys.Length; k++)
                                weightTotal += ys[k][i, r, j];
                            if (weightTotal == 0.0)
                                continue;
                            INumExpr sumxs = model.Prod(0.0, x[0]);
                            for (int k = 0; k < ys.Length; k++)
                                sumxs = model.Sum(sumxs, model.Prod(ys[k][i, r, j], x[k]));
                            IRange rng1 = model.AddLe(sumxs, yValues[i, r, j] + eps);
                            IRange rng2 = model.AddGe(sumxs, yValues[i, r, j] - eps);
                        }

                // write the .lp file
                cplex.ExportModel(filePath);


                // solve by splex
                if (cplex.Solve())
                {
                    for (int i = 0; i < ys.Length; i++)
                    {
                        try
                        {
                            double temp = cplex.GetValue(x[i]);
                            if (temp > 0.000001)
                            {
                                optRoutes += "0";
                                for (int j = 1; j < enumeration[i].Length; j++)
                                    optRoutes += "-" + enumeration[i][j].ToString();
                                optRoutes += ";";
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                else
                    System.Windows.Forms.MessageBox.Show("Enumeration method failed!");

                cplex.End();
            }
            catch (ILOG.Concert.Exception err)
            {
                System.Windows.Forms.MessageBox.Show("Concert exception '" + err + "' caught");
            }
            // end CPLEX *************************************************************
        }

        private static bool NextPermutation<T>(T[] elements) where T : IComparable<T>
        {
            // More efficient to have a variable instead of accessing a property
            var count = elements.Length;

            // Indicates whether this is the last lexicographic permutation
            var done = true;

            // Go through the array from last to first
            for (var i = count - 1; i > 0; i--)
            {
                var curr = elements[i];

                // Check if the current element is less than the one before it
                if (curr.CompareTo(elements[i - 1]) < 0)
                {
                    continue;
                }

                // An element bigger than the one before it has been found,
                // so this isn't the last lexicographic permutation.
                done = false;

                // Save the previous (bigger) element in a variable for more efficiency.
                var prev = elements[i - 1];

                // Have a variable to hold the index of the element to swap
                // with the previous element (the to-swap element would be
                // the smallest element that comes after the previous element
                // and is bigger than the previous element), initializing it
                // as the current index of the current item (curr).
                var currIndex = i;

                // Go through the array from the element after the current one to last
                for (var j = i + 1; j < count; j++)
                {
                    // Save into variable for more efficiency
                    var tmp = elements[j];

                    // Check if tmp suits the "next swap" conditions:
                    // Smallest, but bigger than the "prev" element
                    if (tmp.CompareTo(curr) < 0 && tmp.CompareTo(prev) > 0)
                    {
                        curr = tmp;
                        currIndex = j;
                    }
                }

                // Swap the "prev" with the new "curr" (the swap-with element)
                elements[currIndex] = prev;
                elements[i - 1] = curr;

                // Reverse the order of the tail, in order to reset it's lexicographic order
                for (var j = count - 1; j > i; j--, i++)
                {
                    var tmp = elements[j];
                    elements[j] = elements[i];
                    elements[i] = tmp;
                }

                // Break since we have got the next permutation
                // The reason to have all the logic inside the loop is
                // to prevent the need of an extra variable indicating "i" when
                // the next needed swap is found (moving "i" outside the loop is a
                // bad practice, and isn't very readable, so I preferred not doing
                // that as well).
                break;
            }

            // Return whether this has been the last lexicographic permutation.
            return done;
        }
    }
}
