namespace TSPsolvers
{
    partial class FormTSPsolvers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Tb_NumNodes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tb_NumGroups = new System.Windows.Forms.TextBox();
            this.Cb_Asymmetric = new System.Windows.Forms.CheckBox();
            this.Rb_simplexPrimal = new System.Windows.Forms.RadioButton();
            this.Rb_simplexInterior = new System.Windows.Forms.RadioButton();
            this.Rb_simplexAuto = new System.Windows.Forms.RadioButton();
            this.Cb_Integer = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tb_CostFile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Gb_ReadCost = new System.Windows.Forms.GroupBox();
            this.Bt_FilePath = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.Gb_RandCost = new System.Windows.Forms.GroupBox();
            this.Rb_ValueBase = new System.Windows.Forms.RadioButton();
            this.Cb_Triangle = new System.Windows.Forms.CheckBox();
            this.Rb_EucBase = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.Tb_PerRange1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Tb_PerRange2 = new System.Windows.Forms.TextBox();
            this.Tb_Range2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Tb_Range1 = new System.Windows.Forms.TextBox();
            this.Rb_ReadCostFile = new System.Windows.Forms.RadioButton();
            this.Cb_XmlAll = new System.Windows.Forms.CheckBox();
            this.Rb_RandGen = new System.Windows.Forms.RadioButton();
            this.Tb_NumericalEmphasis = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Tb_EpOpt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Tb_EpMrk = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Tb_BarMaxCor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Tb_BarEpComp = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Rb_BarrierDualCross = new System.Windows.Forms.RadioButton();
            this.Rb_BarrierPrimalCross = new System.Windows.Forms.RadioButton();
            this.Rb_BarrierNoCross = new System.Windows.Forms.RadioButton();
            this.Rb_simpelxDual = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Rb_ModelLP = new System.Windows.Forms.RadioButton();
            this.Rb_SolveLP = new System.Windows.Forms.RadioButton();
            this.Cb_SplitSol = new System.Windows.Forms.CheckBox();
            this.Cb_ShowY = new System.Windows.Forms.CheckBox();
            this.Cb_ShowX = new System.Windows.Forms.CheckBox();
            this.Bt_TSP = new System.Windows.Forms.Button();
            this.tabmain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Rb_ModelClassic = new System.Windows.Forms.RadioButton();
            this.Rb_SolveClassic = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.Tb_WorkMem = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Lb_ReadMe = new System.Windows.Forms.Label();
            this.Rb_NoClassic = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.Gb_ReadCost.SuspendLayout();
            this.Gb_RandCost.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabmain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Cities:";
            // 
            // Tb_NumNodes
            // 
            this.Tb_NumNodes.Location = new System.Drawing.Point(51, 19);
            this.Tb_NumNodes.Name = "Tb_NumNodes";
            this.Tb_NumNodes.Size = new System.Drawing.Size(41, 20);
            this.Tb_NumNodes.TabIndex = 1;
            this.Tb_NumNodes.Text = "7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "# Replications:";
            // 
            // Tb_NumGroups
            // 
            this.Tb_NumGroups.Location = new System.Drawing.Point(173, 19);
            this.Tb_NumGroups.Name = "Tb_NumGroups";
            this.Tb_NumGroups.Size = new System.Drawing.Size(43, 20);
            this.Tb_NumGroups.TabIndex = 4;
            this.Tb_NumGroups.Text = "1";
            // 
            // Cb_Asymmetric
            // 
            this.Cb_Asymmetric.AutoSize = true;
            this.Cb_Asymmetric.Location = new System.Drawing.Point(9, 123);
            this.Cb_Asymmetric.Name = "Cb_Asymmetric";
            this.Cb_Asymmetric.Size = new System.Drawing.Size(79, 17);
            this.Cb_Asymmetric.TabIndex = 6;
            this.Cb_Asymmetric.Text = "Asymmetric";
            this.Cb_Asymmetric.UseVisualStyleBackColor = true;
            // 
            // Rb_simplexPrimal
            // 
            this.Rb_simplexPrimal.AutoSize = true;
            this.Rb_simplexPrimal.Location = new System.Drawing.Point(119, 19);
            this.Rb_simplexPrimal.Name = "Rb_simplexPrimal";
            this.Rb_simplexPrimal.Size = new System.Drawing.Size(92, 17);
            this.Rb_simplexPrimal.TabIndex = 7;
            this.Rb_simplexPrimal.Text = "Primal Simplex";
            this.Rb_simplexPrimal.UseVisualStyleBackColor = true;
            // 
            // Rb_simplexInterior
            // 
            this.Rb_simplexInterior.AutoSize = true;
            this.Rb_simplexInterior.Location = new System.Drawing.Point(18, 42);
            this.Rb_simplexInterior.Name = "Rb_simplexInterior";
            this.Rb_simplexInterior.Size = new System.Drawing.Size(155, 17);
            this.Rb_simplexInterior.TabIndex = 8;
            this.Rb_simplexInterior.Text = "Barrier Automatic Crossover";
            this.Rb_simplexInterior.UseVisualStyleBackColor = true;
            // 
            // Rb_simplexAuto
            // 
            this.Rb_simplexAuto.AutoSize = true;
            this.Rb_simplexAuto.Checked = true;
            this.Rb_simplexAuto.Location = new System.Drawing.Point(18, 19);
            this.Rb_simplexAuto.Name = "Rb_simplexAuto";
            this.Rb_simplexAuto.Size = new System.Drawing.Size(59, 17);
            this.Rb_simplexAuto.TabIndex = 9;
            this.Rb_simplexAuto.TabStop = true;
            this.Rb_simplexAuto.Text = "Default";
            this.Rb_simplexAuto.UseVisualStyleBackColor = true;
            // 
            // Cb_Integer
            // 
            this.Cb_Integer.AutoSize = true;
            this.Cb_Integer.Location = new System.Drawing.Point(94, 123);
            this.Cb_Integer.Name = "Cb_Integer";
            this.Cb_Integer.Size = new System.Drawing.Size(59, 17);
            this.Cb_Integer.TabIndex = 10;
            this.Cb_Integer.Text = "Integer";
            this.Cb_Integer.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Select an XML or CSV file:";
            // 
            // Tb_CostFile
            // 
            this.Tb_CostFile.Location = new System.Drawing.Point(6, 39);
            this.Tb_CostFile.Name = "Tb_CostFile";
            this.Tb_CostFile.Size = new System.Drawing.Size(162, 20);
            this.Tb_CostFile.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Gb_ReadCost);
            this.groupBox1.Controls.Add(this.Gb_RandCost);
            this.groupBox1.Controls.Add(this.Rb_ReadCostFile);
            this.groupBox1.Controls.Add(this.Cb_XmlAll);
            this.groupBox1.Controls.Add(this.Rb_RandGen);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 227);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // Gb_ReadCost
            // 
            this.Gb_ReadCost.Controls.Add(this.Bt_FilePath);
            this.Gb_ReadCost.Controls.Add(this.Tb_CostFile);
            this.Gb_ReadCost.Controls.Add(this.label3);
            this.Gb_ReadCost.Controls.Add(this.label17);
            this.Gb_ReadCost.Enabled = false;
            this.Gb_ReadCost.Location = new System.Drawing.Point(246, 43);
            this.Gb_ReadCost.Name = "Gb_ReadCost";
            this.Gb_ReadCost.Size = new System.Drawing.Size(199, 113);
            this.Gb_ReadCost.TabIndex = 35;
            this.Gb_ReadCost.TabStop = false;
            this.Gb_ReadCost.Text = "File";
            // 
            // Bt_FilePath
            // 
            this.Bt_FilePath.Location = new System.Drawing.Point(169, 37);
            this.Bt_FilePath.Name = "Bt_FilePath";
            this.Bt_FilePath.Size = new System.Drawing.Size(24, 23);
            this.Bt_FilePath.TabIndex = 32;
            this.Bt_FilePath.Text = "...";
            this.Bt_FilePath.UseVisualStyleBackColor = true;
            this.Bt_FilePath.Click += new System.EventHandler(this.Bt_FilePath_Click);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(162, 40);
            this.label17.TabIndex = 31;
            this.label17.Text = "* See the attached Sample.xml and Sample.csv for data format.";
            // 
            // Gb_RandCost
            // 
            this.Gb_RandCost.Controls.Add(this.Cb_Asymmetric);
            this.Gb_RandCost.Controls.Add(this.Cb_Integer);
            this.Gb_RandCost.Controls.Add(this.Rb_ValueBase);
            this.Gb_RandCost.Controls.Add(this.Cb_Triangle);
            this.Gb_RandCost.Controls.Add(this.Rb_EucBase);
            this.Gb_RandCost.Controls.Add(this.label8);
            this.Gb_RandCost.Controls.Add(this.Tb_PerRange1);
            this.Gb_RandCost.Controls.Add(this.label4);
            this.Gb_RandCost.Controls.Add(this.label5);
            this.Gb_RandCost.Controls.Add(this.label7);
            this.Gb_RandCost.Controls.Add(this.label1);
            this.Gb_RandCost.Controls.Add(this.Tb_NumNodes);
            this.Gb_RandCost.Controls.Add(this.Tb_PerRange2);
            this.Gb_RandCost.Controls.Add(this.label2);
            this.Gb_RandCost.Controls.Add(this.Tb_Range2);
            this.Gb_RandCost.Controls.Add(this.Tb_NumGroups);
            this.Gb_RandCost.Controls.Add(this.label6);
            this.Gb_RandCost.Controls.Add(this.Tb_Range1);
            this.Gb_RandCost.Location = new System.Drawing.Point(15, 43);
            this.Gb_RandCost.Name = "Gb_RandCost";
            this.Gb_RandCost.Size = new System.Drawing.Size(225, 174);
            this.Gb_RandCost.TabIndex = 34;
            this.Gb_RandCost.TabStop = false;
            this.Gb_RandCost.Text = "Options";
            // 
            // Rb_ValueBase
            // 
            this.Rb_ValueBase.AutoSize = true;
            this.Rb_ValueBase.Location = new System.Drawing.Point(9, 97);
            this.Rb_ValueBase.Name = "Rb_ValueBase";
            this.Rb_ValueBase.Size = new System.Drawing.Size(14, 13);
            this.Rb_ValueBase.TabIndex = 35;
            this.Rb_ValueBase.UseVisualStyleBackColor = true;
            // 
            // Cb_Triangle
            // 
            this.Cb_Triangle.AutoSize = true;
            this.Cb_Triangle.Location = new System.Drawing.Point(9, 146);
            this.Cb_Triangle.Name = "Cb_Triangle";
            this.Cb_Triangle.Size = new System.Drawing.Size(142, 17);
            this.Cb_Triangle.TabIndex = 11;
            this.Cb_Triangle.Text = "Triangle inequality holds.";
            this.Cb_Triangle.UseVisualStyleBackColor = true;
            // 
            // Rb_EucBase
            // 
            this.Rb_EucBase.AutoSize = true;
            this.Rb_EucBase.Checked = true;
            this.Rb_EucBase.Location = new System.Drawing.Point(9, 70);
            this.Rb_EucBase.Name = "Rb_EucBase";
            this.Rb_EucBase.Size = new System.Drawing.Size(14, 13);
            this.Rb_EucBase.TabIndex = 34;
            this.Rb_EucBase.TabStop = true;
            this.Rb_EucBase.UseVisualStyleBackColor = true;
            this.Rb_EucBase.CheckedChanged += new System.EventHandler(this.Rb_EucBase_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(127, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "(Interval Limits)";
            // 
            // Tb_PerRange1
            // 
            this.Tb_PerRange1.Location = new System.Drawing.Point(29, 67);
            this.Tb_PerRange1.Name = "Tb_PerRange1";
            this.Tb_PerRange1.Size = new System.Drawing.Size(28, 20);
            this.Tb_PerRange1.TabIndex = 16;
            this.Tb_PerRange1.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Cost Range (Uniform Distribution):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "% ~ ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "~";
            // 
            // Tb_PerRange2
            // 
            this.Tb_PerRange2.Location = new System.Drawing.Point(86, 67);
            this.Tb_PerRange2.Name = "Tb_PerRange2";
            this.Tb_PerRange2.Size = new System.Drawing.Size(28, 20);
            this.Tb_PerRange2.TabIndex = 19;
            this.Tb_PerRange2.Text = "100";
            // 
            // Tb_Range2
            // 
            this.Tb_Range2.Enabled = false;
            this.Tb_Range2.Location = new System.Drawing.Point(84, 93);
            this.Tb_Range2.Name = "Tb_Range2";
            this.Tb_Range2.Size = new System.Drawing.Size(37, 20);
            this.Tb_Range2.TabIndex = 22;
            this.Tb_Range2.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(114, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "% of Euclidean Dist.";
            // 
            // Tb_Range1
            // 
            this.Tb_Range1.Enabled = false;
            this.Tb_Range1.Location = new System.Drawing.Point(29, 93);
            this.Tb_Range1.Name = "Tb_Range1";
            this.Tb_Range1.Size = new System.Drawing.Size(37, 20);
            this.Tb_Range1.TabIndex = 21;
            this.Tb_Range1.Text = "0";
            // 
            // Rb_ReadCostFile
            // 
            this.Rb_ReadCostFile.AutoSize = true;
            this.Rb_ReadCostFile.Location = new System.Drawing.Point(257, 20);
            this.Rb_ReadCostFile.Name = "Rb_ReadCostFile";
            this.Rb_ReadCostFile.Size = new System.Drawing.Size(127, 17);
            this.Rb_ReadCostFile.TabIndex = 12;
            this.Rb_ReadCostFile.Text = "Read costs from a file";
            this.Rb_ReadCostFile.UseVisualStyleBackColor = true;
            // 
            // Cb_XmlAll
            // 
            this.Cb_XmlAll.AutoSize = true;
            this.Cb_XmlAll.Location = new System.Drawing.Point(257, 189);
            this.Cb_XmlAll.Name = "Cb_XmlAll";
            this.Cb_XmlAll.Size = new System.Drawing.Size(165, 17);
            this.Cb_XmlAll.TabIndex = 15;
            this.Cb_XmlAll.Text = "Export XML for all replications";
            this.Cb_XmlAll.UseVisualStyleBackColor = true;
            // 
            // Rb_RandGen
            // 
            this.Rb_RandGen.AutoSize = true;
            this.Rb_RandGen.Checked = true;
            this.Rb_RandGen.Location = new System.Drawing.Point(23, 20);
            this.Rb_RandGen.Name = "Rb_RandGen";
            this.Rb_RandGen.Size = new System.Drawing.Size(145, 17);
            this.Rb_RandGen.TabIndex = 0;
            this.Rb_RandGen.TabStop = true;
            this.Rb_RandGen.Text = "Randomly generate costs";
            this.Rb_RandGen.UseVisualStyleBackColor = true;
            this.Rb_RandGen.CheckedChanged += new System.EventHandler(this.Rb_RandGen_CheckedChanged);
            // 
            // Tb_NumericalEmphasis
            // 
            this.Tb_NumericalEmphasis.Location = new System.Drawing.Point(113, 207);
            this.Tb_NumericalEmphasis.Name = "Tb_NumericalEmphasis";
            this.Tb_NumericalEmphasis.Size = new System.Drawing.Size(100, 20);
            this.Tb_NumericalEmphasis.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "NumericalEmphasis=";
            // 
            // Tb_EpOpt
            // 
            this.Tb_EpOpt.Location = new System.Drawing.Point(113, 181);
            this.Tb_EpOpt.Name = "Tb_EpOpt";
            this.Tb_EpOpt.Size = new System.Drawing.Size(100, 20);
            this.Tb_EpOpt.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(68, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "EpOpt=";
            // 
            // Tb_EpMrk
            // 
            this.Tb_EpMrk.Location = new System.Drawing.Point(113, 155);
            this.Tb_EpMrk.Name = "Tb_EpMrk";
            this.Tb_EpMrk.Size = new System.Drawing.Size(100, 20);
            this.Tb_EpMrk.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(66, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "EpMrk=";
            // 
            // Tb_BarMaxCor
            // 
            this.Tb_BarMaxCor.Location = new System.Drawing.Point(112, 129);
            this.Tb_BarMaxCor.Name = "Tb_BarMaxCor";
            this.Tb_BarMaxCor.Size = new System.Drawing.Size(100, 20);
            this.Tb_BarMaxCor.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "BarMaxCor=";
            // 
            // Tb_BarEpComp
            // 
            this.Tb_BarEpComp.Location = new System.Drawing.Point(112, 103);
            this.Tb_BarEpComp.Name = "Tb_BarEpComp";
            this.Tb_BarEpComp.Size = new System.Drawing.Size(100, 20);
            this.Tb_BarEpComp.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "BarEpComp=";
            // 
            // Rb_BarrierDualCross
            // 
            this.Rb_BarrierDualCross.AutoSize = true;
            this.Rb_BarrierDualCross.Location = new System.Drawing.Point(230, 65);
            this.Rb_BarrierDualCross.Name = "Rb_BarrierDualCross";
            this.Rb_BarrierDualCross.Size = new System.Drawing.Size(130, 17);
            this.Rb_BarrierDualCross.TabIndex = 13;
            this.Rb_BarrierDualCross.TabStop = true;
            this.Rb_BarrierDualCross.Text = "Barrier Dual Crossover";
            this.Rb_BarrierDualCross.UseVisualStyleBackColor = true;
            // 
            // Rb_BarrierPrimalCross
            // 
            this.Rb_BarrierPrimalCross.AutoSize = true;
            this.Rb_BarrierPrimalCross.Location = new System.Drawing.Point(18, 65);
            this.Rb_BarrierPrimalCross.Name = "Rb_BarrierPrimalCross";
            this.Rb_BarrierPrimalCross.Size = new System.Drawing.Size(136, 17);
            this.Rb_BarrierPrimalCross.TabIndex = 12;
            this.Rb_BarrierPrimalCross.TabStop = true;
            this.Rb_BarrierPrimalCross.Text = "Barrier Primal Crossover";
            this.Rb_BarrierPrimalCross.UseVisualStyleBackColor = true;
            // 
            // Rb_BarrierNoCross
            // 
            this.Rb_BarrierNoCross.AutoSize = true;
            this.Rb_BarrierNoCross.Location = new System.Drawing.Point(230, 42);
            this.Rb_BarrierNoCross.Name = "Rb_BarrierNoCross";
            this.Rb_BarrierNoCross.Size = new System.Drawing.Size(142, 17);
            this.Rb_BarrierNoCross.TabIndex = 11;
            this.Rb_BarrierNoCross.TabStop = true;
            this.Rb_BarrierNoCross.Text = "Barrier without Crossover";
            this.Rb_BarrierNoCross.UseVisualStyleBackColor = true;
            // 
            // Rb_simpelxDual
            // 
            this.Rb_simpelxDual.AutoSize = true;
            this.Rb_simpelxDual.Location = new System.Drawing.Point(230, 19);
            this.Rb_simpelxDual.Name = "Rb_simpelxDual";
            this.Rb_simpelxDual.Size = new System.Drawing.Size(86, 17);
            this.Rb_simpelxDual.TabIndex = 10;
            this.Rb_simpelxDual.TabStop = true;
            this.Rb_simpelxDual.Text = "Dual Simplex";
            this.Rb_simpelxDual.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Rb_ModelLP);
            this.groupBox5.Controls.Add(this.Rb_SolveLP);
            this.groupBox5.Controls.Add(this.Cb_SplitSol);
            this.groupBox5.Controls.Add(this.Cb_ShowY);
            this.groupBox5.Controls.Add(this.Cb_ShowX);
            this.groupBox5.Location = new System.Drawing.Point(7, 239);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(239, 95);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "N5 LP Model";
            // 
            // Rb_ModelLP
            // 
            this.Rb_ModelLP.AutoSize = true;
            this.Rb_ModelLP.Checked = true;
            this.Rb_ModelLP.Location = new System.Drawing.Point(130, 20);
            this.Rb_ModelLP.Name = "Rb_ModelLP";
            this.Rb_ModelLP.Size = new System.Drawing.Size(78, 17);
            this.Rb_ModelLP.TabIndex = 28;
            this.Rb_ModelLP.TabStop = true;
            this.Rb_ModelLP.Text = "Model Only";
            this.Rb_ModelLP.UseVisualStyleBackColor = true;
            // 
            // Rb_SolveLP
            // 
            this.Rb_SolveLP.AutoSize = true;
            this.Rb_SolveLP.Location = new System.Drawing.Point(22, 20);
            this.Rb_SolveLP.Name = "Rb_SolveLP";
            this.Rb_SolveLP.Size = new System.Drawing.Size(95, 17);
            this.Rb_SolveLP.TabIndex = 27;
            this.Rb_SolveLP.Text = "Solve (CPLEX)";
            this.Rb_SolveLP.UseVisualStyleBackColor = true;
            this.Rb_SolveLP.CheckedChanged += new System.EventHandler(this.Rb_SolveLP_CheckedChanged);
            // 
            // Cb_SplitSol
            // 
            this.Cb_SplitSol.AutoSize = true;
            this.Cb_SplitSol.Checked = true;
            this.Cb_SplitSol.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Cb_SplitSol.Enabled = false;
            this.Cb_SplitSol.Location = new System.Drawing.Point(22, 68);
            this.Cb_SplitSol.Name = "Cb_SplitSol";
            this.Cb_SplitSol.Size = new System.Drawing.Size(85, 17);
            this.Cb_SplitSol.TabIndex = 24;
            this.Cb_SplitSol.Text = "Show routes";
            this.Cb_SplitSol.UseVisualStyleBackColor = true;
            // 
            // Cb_ShowY
            // 
            this.Cb_ShowY.AutoSize = true;
            this.Cb_ShowY.Checked = true;
            this.Cb_ShowY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Cb_ShowY.Enabled = false;
            this.Cb_ShowY.Location = new System.Drawing.Point(22, 45);
            this.Cb_ShowY.Name = "Cb_ShowY";
            this.Cb_ShowY.Size = new System.Drawing.Size(105, 17);
            this.Cb_ShowY.TabIndex = 23;
            this.Cb_ShowY.Text = "Show y solutions";
            this.Cb_ShowY.UseVisualStyleBackColor = true;
            // 
            // Cb_ShowX
            // 
            this.Cb_ShowX.AutoSize = true;
            this.Cb_ShowX.Enabled = false;
            this.Cb_ShowX.Location = new System.Drawing.Point(130, 45);
            this.Cb_ShowX.Name = "Cb_ShowX";
            this.Cb_ShowX.Size = new System.Drawing.Size(105, 17);
            this.Cb_ShowX.TabIndex = 22;
            this.Cb_ShowX.Text = "Show x solutions";
            this.Cb_ShowX.UseVisualStyleBackColor = true;
            // 
            // Bt_TSP
            // 
            this.Bt_TSP.Location = new System.Drawing.Point(194, 340);
            this.Bt_TSP.Name = "Bt_TSP";
            this.Bt_TSP.Size = new System.Drawing.Size(79, 23);
            this.Bt_TSP.TabIndex = 25;
            this.Bt_TSP.Text = "Solve TSP";
            this.Bt_TSP.UseVisualStyleBackColor = true;
            this.Bt_TSP.Click += new System.EventHandler(this.Bt_TSP_Click);
            // 
            // tabmain
            // 
            this.tabmain.Controls.Add(this.tabPage1);
            this.tabmain.Controls.Add(this.tabPage3);
            this.tabmain.Controls.Add(this.tabPage2);
            this.tabmain.Location = new System.Drawing.Point(12, 12);
            this.tabmain.Name = "tabmain";
            this.tabmain.SelectedIndex = 0;
            this.tabmain.Size = new System.Drawing.Size(472, 403);
            this.tabmain.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.Bt_TSP);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(464, 377);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TSP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Rb_NoClassic);
            this.groupBox2.Controls.Add(this.Rb_ModelClassic);
            this.groupBox2.Controls.Add(this.Rb_SolveClassic);
            this.groupBox2.Location = new System.Drawing.Point(252, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 95);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Miller–Tucker–Zemlin Model";
            // 
            // Rb_ModelClassic
            // 
            this.Rb_ModelClassic.AutoSize = true;
            this.Rb_ModelClassic.Checked = true;
            this.Rb_ModelClassic.Location = new System.Drawing.Point(14, 20);
            this.Rb_ModelClassic.Name = "Rb_ModelClassic";
            this.Rb_ModelClassic.Size = new System.Drawing.Size(78, 17);
            this.Rb_ModelClassic.TabIndex = 8;
            this.Rb_ModelClassic.TabStop = true;
            this.Rb_ModelClassic.Text = "Model Only";
            this.Rb_ModelClassic.UseVisualStyleBackColor = true;
            // 
            // Rb_SolveClassic
            // 
            this.Rb_SolveClassic.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Rb_SolveClassic.Location = new System.Drawing.Point(14, 45);
            this.Rb_SolveClassic.Name = "Rb_SolveClassic";
            this.Rb_SolveClassic.Size = new System.Drawing.Size(179, 31);
            this.Rb_SolveClassic.TabIndex = 7;
            this.Rb_SolveClassic.Text = "Solve (CPLEX; Show objective value)";
            this.Rb_SolveClassic.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.Tb_WorkMem);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.Tb_NumericalEmphasis);
            this.tabPage3.Controls.Add(this.Rb_simplexAuto);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.Rb_simplexInterior);
            this.tabPage3.Controls.Add(this.Tb_EpOpt);
            this.tabPage3.Controls.Add(this.Rb_simplexPrimal);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.Rb_simpelxDual);
            this.tabPage3.Controls.Add(this.Tb_EpMrk);
            this.tabPage3.Controls.Add(this.Rb_BarrierNoCross);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.Rb_BarrierPrimalCross);
            this.tabPage3.Controls.Add(this.Tb_BarMaxCor);
            this.tabPage3.Controls.Add(this.Rb_BarrierDualCross);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.Tb_BarEpComp);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(464, 377);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CPLEX Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(220, 237);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "MB (default: 128 MB)";
            // 
            // Tb_WorkMem
            // 
            this.Tb_WorkMem.Location = new System.Drawing.Point(113, 234);
            this.Tb_WorkMem.Name = "Tb_WorkMem";
            this.Tb_WorkMem.Size = new System.Drawing.Size(100, 20);
            this.Tb_WorkMem.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(50, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "WorkMem=";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(219, 210);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 13);
            this.label22.TabIndex = 28;
            this.label22.Text = "(0 or 1; default: 0)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(219, 184);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(135, 13);
            this.label21.TabIndex = 27;
            this.label21.Text = "(1e-9 to 1e-1; default: 1e-6)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(220, 157);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(153, 13);
            this.label20.TabIndex = 26;
            this.label20.Text = "(.0001 to .99999; default: 0.01)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(219, 132);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 13);
            this.label19.TabIndex = 25;
            this.label19.Text = "(-1 to +integer; default: -1)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(219, 106);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(141, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "(1e-12 to 1e-8; default: 1e-8)";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Lb_ReadMe);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(464, 377);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Read Me";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Lb_ReadMe
            // 
            this.Lb_ReadMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_ReadMe.Location = new System.Drawing.Point(12, 10);
            this.Lb_ReadMe.Name = "Lb_ReadMe";
            this.Lb_ReadMe.Size = new System.Drawing.Size(441, 374);
            this.Lb_ReadMe.TabIndex = 0;
            this.Lb_ReadMe.Text = "Read me";
            // 
            // Rb_NoClassic
            // 
            this.Rb_NoClassic.AutoSize = true;
            this.Rb_NoClassic.Location = new System.Drawing.Point(99, 20);
            this.Rb_NoClassic.Name = "Rb_NoClassic";
            this.Rb_NoClassic.Size = new System.Drawing.Size(79, 17);
            this.Rb_NoClassic.TabIndex = 9;
            this.Rb_NoClassic.TabStop = true;
            this.Rb_NoClassic.Text = "Do Nothing";
            this.Rb_NoClassic.UseVisualStyleBackColor = true;
            // 
            // FormTSPsolvers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 427);
            this.Controls.Add(this.tabmain);
            this.Name = "FormTSPsolvers";
            this.Text = "TSP LP Solver v1.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Gb_ReadCost.ResumeLayout(false);
            this.Gb_ReadCost.PerformLayout();
            this.Gb_RandCost.ResumeLayout(false);
            this.Gb_RandCost.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabmain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_NumNodes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tb_NumGroups;
        private System.Windows.Forms.CheckBox Cb_Asymmetric;
        private System.Windows.Forms.RadioButton Rb_simplexPrimal;
        private System.Windows.Forms.RadioButton Rb_simplexInterior;
        private System.Windows.Forms.RadioButton Rb_simplexAuto;
        private System.Windows.Forms.CheckBox Cb_Integer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tb_CostFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Rb_ReadCostFile;
        private System.Windows.Forms.RadioButton Rb_RandGen;
        private System.Windows.Forms.CheckBox Cb_XmlAll;
        private System.Windows.Forms.CheckBox Cb_Triangle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Tb_Range2;
        private System.Windows.Forms.TextBox Tb_Range1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tb_PerRange2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tb_PerRange1;
        private System.Windows.Forms.RadioButton Rb_BarrierDualCross;
        private System.Windows.Forms.RadioButton Rb_BarrierPrimalCross;
        private System.Windows.Forms.RadioButton Rb_BarrierNoCross;
        private System.Windows.Forms.RadioButton Rb_simpelxDual;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox Cb_ShowY;
        private System.Windows.Forms.CheckBox Cb_ShowX;
        private System.Windows.Forms.CheckBox Cb_SplitSol;
        private System.Windows.Forms.TextBox Tb_BarEpComp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Tb_BarMaxCor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Tb_EpMrk;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Tb_EpOpt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Tb_NumericalEmphasis;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Bt_TSP;
        private System.Windows.Forms.TabControl tabmain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label Lb_ReadMe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox Gb_RandCost;
        private System.Windows.Forms.RadioButton Rb_ValueBase;
        private System.Windows.Forms.RadioButton Rb_EucBase;
        private System.Windows.Forms.RadioButton Rb_ModelLP;
        private System.Windows.Forms.RadioButton Rb_SolveLP;
        private System.Windows.Forms.RadioButton Rb_ModelClassic;
        private System.Windows.Forms.RadioButton Rb_SolveClassic;
        private System.Windows.Forms.GroupBox Gb_ReadCost;
        private System.Windows.Forms.Button Bt_FilePath;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Tb_WorkMem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton Rb_NoClassic;
    }
}

