using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TSPsolvers
{
    public partial class FormTSPsolvers : Form
    {
        public FormTSPsolvers()
        {
            InitializeComponent();
            this.Lb_ReadMe.Text = @"TSP LP Solver is a software package which builds a linear programming model for the traveling salesman problem and calls CPLEX to solve it as an LP.

For those with CPLEX 12.5:
All functions in this program are available.

For those with different versions of CPLEX:
You may have problems when calling CPLEX to solve. If so, you need adjust references in the source code to rebuild the program.

For those without CPLEX or with difficulties in source code:
You can choose the Model Only button to build a .lp file (no requirement to use CPLEX), and then solve the .lp file with the software of your choice.

For any questions, concerns or comments about the related papers and codes, please contact:
Moustapha Diaby - moustapha.diaby@business.uconn.edu
Mark H. Karwan - mkarwan@buffalo.edu
Lei Sun - leisun@buffalo.edu";
        }

        private void Bt_TSP_Click(object sender, EventArgs e)
        {
            Main();
        }

        private void Main()
        {
            Random rand = new Random();
            int numReps = 1;

            string resultFile = "Results\\";
            if (this.Rb_ReadCostFile.Checked)
                resultFile += "Tests on given cost files.txt";
            else
            {
                numReps = Convert.ToInt32(this.Tb_NumGroups.Text);
                resultFile += "Tests on " + this.Tb_NumNodes.Text + "-node random cases.txt";
            }

            CplexParam simplexMethod = SetCplexParam();
            for (int k = 0; k < numReps; k++)
            {
                // create a network
                Node[] nodes;
                if (this.Rb_ReadCostFile.Checked)
                    nodes = ReadData();
                else
                    nodes = RandomData(rand);

                // save records
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(resultFile, true))
                {
                    file.WriteLine("");
                    file.WriteLine("Route ID: " + k.ToString() + " @ Time: " + DateTime.Now.ToString());
                    if (this.Rb_ReadCostFile.Checked)
                        file.WriteLine(this.Tb_CostFile.Text + " @ Time: " + DateTime.Now.ToString());
                    else if(this.Rb_EucBase.Checked)
                    {
                        string strCoordinates = "";
                        for (int i = 0; i < nodes.Length; i++)
                            strCoordinates += "(" + nodes[i].x.ToString() + "," + nodes[i].y.ToString() + ");";
                        file.WriteLine(strCoordinates);
                    }
                }
                if (this.Cb_XmlAll.Checked)
                    Operations.ExportCostMatrix("Results\\TSP" + k.ToString() + ".xml", nodes);

                // build the MTZ model without CPLEX
                if (this.Rb_ModelClassic.Checked)
                    ModelOnly.MTZ(nodes, "Results\\MTZ.lp");
                // build and solve the MTZ model with CPLEX
                double resMTZ = -100.0;
                if (this.Rb_SolveClassic.Checked)
                {
                    resMTZ = SolveMTZ.GetMTZopt(nodes, false, "Results\\MTZ.lp");
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(resultFile, true))
                    {
                        file.WriteLine("Time: " + DateTime.Now.ToString());
                        file.WriteLine("MTZ: " + resMTZ.ToString());
                        if (resMTZ == -1.0)
                            file.WriteLine("(-1 is the default value if MTZ model was not solved correctly.)");
                    }
                }

                // build the N5 model without CPLEX
                if (this.Rb_ModelLP.Checked)
                    ModelOnly.N5LP(nodes, "Results\\N5LP.lp");
                // build and solve the N5 LP (XY) model
                if (this.Rb_SolveLP.Checked)
                {
                    double optCost = SolveN5LP.GetN5LPopt(nodes, simplexMethod, false, "Results\\N5LP.lp");

                    bool showXML = false;
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(resultFile, true))
                    {
                        file.WriteLine("Time: " + DateTime.Now.ToString());
                        file.WriteLine("Solving time: " + SolveN5LP.solveTime);
                        file.WriteLine("N5LP: " + optCost.ToString());
                        file.WriteLine("# Variables: " + SolveN5LP.numVarCons[0].ToString() + "; # Constraints: " + SolveN5LP.numVarCons[1].ToString());
                        if (this.Cb_ShowY.Checked)
                            file.WriteLine("Y Variables: " + SolveN5LP.commentsY);
                        if (this.Cb_ShowX.Checked)
                            file.WriteLine("X Variables: " + SolveN5LP.commentsX);
                        if (this.Cb_SplitSol.Checked)
                        {
                            //SplitRoutes.EnumerSplitByY(SolveN5LP.yValues, nodes.Length, "Results\\split.lp");
                            SplitRoutes.SplitRoutesByY(SolveN5LP.yValues, nodes.Length);
                            file.WriteLine("Optimal Route(s): " + SplitRoutes.optRoutes);

                            if (SplitRoutes.optRoutes.Contains("EnumerSplitByY()"))
                                showXML = true;
                        }
                    }
                    if (resMTZ != -1 && this.Rb_SolveClassic.Checked)
                        if (Math.Abs(resMTZ - optCost) > 0.00001) // accuracy
                            showXML = true;
                    // if MTZ and N5 LP result in different opt obj values, or only a portion of opt routes are displayed, create the cost matrix in an XML file
                    if (showXML)
                        Operations.ExportCostMatrix("Results\\RemarkTSP" + k.ToString() + ".xml", nodes);
                }
            }

            MessageBox.Show("Done!\n" + DateTime.Now.ToString());
        }

        private Node[] RandomData(Random rand)
        {
            Node[] nodes = new Node[Convert.ToInt32(this.Tb_NumNodes.Text)];

            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node(rand);
                nodes[i].Id = i;
            }

            // create basic cost matrix
            if (this.Rb_EucBase.Checked)
            {
                for (int i = 0; i < nodes.Length; i++)
                    nodes[i].CreateCosts(nodes, rand, Convert.ToDouble(this.Tb_PerRange1.Text) / 100.0, Convert.ToDouble(this.Tb_PerRange2.Text) / 100.0);
            }
            else
            {
                for (int i = 0; i < nodes.Length; i++)
                    nodes[i].CreateCosts(nodes.Length, rand, Convert.ToDouble(this.Tb_Range1.Text), Convert.ToDouble(this.Tb_Range2.Text));
            }

            if (this.Cb_Integer.Checked)
            {
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = 0; j < nodes.Length; j++)
                        nodes[i].costFromThis[j] = Convert.ToInt32(nodes[i].costFromThis[j]);
            }

            if (!this.Cb_Asymmetric.Checked)
            {
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = i + 1; j < nodes.Length; j++)
                        nodes[i].costFromThis[j] = nodes[j].costFromThis[i];
            }

            if (this.Cb_Triangle.Checked)
            {
                double[,] L = new double[nodes.Length, nodes.Length];
                for (int i = 0; i < nodes.Length; i++)
                    for (int j = 0; j < nodes.Length; j++)
                        L[i, j] = nodes[i].costFromThis[j];

                Dijkstra dijkstra = new Dijkstra();

                for (int i = 0; i < (int)Math.Sqrt(L.Length); i++)
                {
                    dijkstra.DijkstraRun((int)Math.Sqrt(L.Length), L, i);
                    for (int j = 0; j < (int)Math.Sqrt(L.Length); j++)
                    {
                        nodes[i].costFromThis[j] = dijkstra.D[j];
                    }
                }
            }

            return nodes;
        }

        private Node[] ReadData()
        {
            double[,] costMatrix;
            if (this.Tb_CostFile.Text.Substring(this.Tb_CostFile.Text.Length - 4).ToLower() == ".xml")
                costMatrix = Operations.GetCostMatrix(this.Tb_CostFile.Text);
            else if (this.Tb_CostFile.Text.Substring(this.Tb_CostFile.Text.Length - 4).ToLower() == ".csv")
                costMatrix = Operations.ReadCSVdata(this.Tb_CostFile.Text);
            else
            {
                costMatrix = new double[0, 0]; // no use
                MessageBox.Show("Unrecognized file!");
            }
            int numNodes = Convert.ToInt32(Math.Sqrt(costMatrix.Length));

            Node[] nodes = new Node[numNodes];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node();
                nodes[i].Id = i;
            }

            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i].costFromThis = new double[numNodes];
                for (int j = 0; j < nodes.Length; j++)
                    nodes[i].costFromThis[j] = costMatrix[i, j];
            }

            return nodes;
        }

        private CplexParam SetCplexParam()
        {
            CplexParam simplexMethod = new CplexParam();

            if (this.Rb_simplexPrimal.Checked)
            {
                simplexMethod.rootAlg[0] = 1;
                simplexMethod.rootAlg[1] = 1;
            }
            else if (this.Rb_simpelxDual.Checked)
            {
                simplexMethod.rootAlg[0] = 1;
                simplexMethod.rootAlg[1] = 2;
            }
            else if (this.Rb_simplexInterior.Checked)
            {
                simplexMethod.rootAlg[0] = 1;
                simplexMethod.rootAlg[1] = 4;
            }
            else if (this.Rb_BarrierNoCross.Checked)
            {
                simplexMethod.rootAlg[0] = 1;
                simplexMethod.rootAlg[1] = 4;
                simplexMethod.barCrossAlg[0] = 1;
                simplexMethod.barCrossAlg[1] = -1;
            }
            else if (this.Rb_BarrierPrimalCross.Checked)
            {
                simplexMethod.rootAlg[0] = 1;
                simplexMethod.rootAlg[1] = 4;
                simplexMethod.barCrossAlg[0] = 1;
                simplexMethod.barCrossAlg[1] = 1;
            }
            else if (this.Rb_BarrierDualCross.Checked)
            {
                simplexMethod.rootAlg[0] = 1;
                simplexMethod.rootAlg[1] = 4;
                simplexMethod.barCrossAlg[0] = 1;
                simplexMethod.barCrossAlg[1] = 2;
            }

            if(this.Tb_BarEpComp.Text!="")
            {
                simplexMethod.barEpComp[0] = 1;
                simplexMethod.barEpComp[1] = Convert.ToDouble(this.Tb_BarEpComp.Text);
            }
            if (this.Tb_BarMaxCor.Text != "")
            {
                simplexMethod.barMaxCor[0] = 1;
                simplexMethod.barMaxCor[1] = Convert.ToInt32(this.Tb_BarMaxCor.Text);
            }
            if (this.Tb_EpMrk.Text != "")
            {
                simplexMethod.epMrk[0] = 1;
                simplexMethod.epMrk[1] = Convert.ToDouble(this.Tb_EpMrk.Text);
            }
            if (this.Tb_EpOpt.Text != "")
            {
                simplexMethod.epOpt[0] = 1;
                simplexMethod.epOpt[1] = Convert.ToDouble(this.Tb_EpOpt.Text);
            }
            if (this.Tb_NumericalEmphasis.Text != "")
            {
                simplexMethod.numericalEmphasis[0] = true;
                simplexMethod.numericalEmphasis[1] = Convert.ToBoolean(this.Tb_NumericalEmphasis.Text);
            }
            if (this.Tb_WorkMem.Text != "")
            {
                simplexMethod.workMem[0] = 1;
                simplexMethod.workMem[1] = Convert.ToDouble(this.Tb_WorkMem.Text);
            }

            return simplexMethod;
        }

        private void Rb_RandGen_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Rb_RandGen.Checked)
            {
                this.Gb_RandCost.Enabled = true;
                this.Gb_ReadCost.Enabled = false;
            }
            else
            {
                this.Gb_RandCost.Enabled = false;
                this.Gb_ReadCost.Enabled = true;
            }
        }

        private void Rb_EucBase_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Rb_EucBase.Checked)
            {
                this.Tb_PerRange1.Enabled = true;
                this.Tb_PerRange2.Enabled = true;
                this.Tb_Range1.Enabled = false;
                this.Tb_Range2.Enabled = false;
            }
            else
            {
                this.Tb_PerRange1.Enabled = false;
                this.Tb_PerRange2.Enabled = false;
                this.Tb_Range1.Enabled = true;
                this.Tb_Range2.Enabled = true;
            }
        }

        private void Rb_SolveLP_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Rb_SolveLP.Checked)
            {
                this.Cb_SplitSol.Enabled = true;
                this.Cb_ShowX.Enabled = true;
                this.Cb_ShowY.Enabled = true;
            }
            else
            {
                this.Cb_SplitSol.Enabled = false;
                this.Cb_ShowX.Enabled = false;
                this.Cb_ShowY.Enabled = false;
            }
        }

        private void Bt_FilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Supported Formats|*.xml;*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
                this.Tb_CostFile.Text = ofd.FileName;
        }
    }
}
