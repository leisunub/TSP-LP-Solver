using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSPsolvers
{
    class CplexParam
    {
        // [2]: first number is 1 or 0: use or not; second number is the parameter
        public int[] rootAlg;
        public int[] barCrossAlg;
        public double[] barEpComp;
        public int[] barMaxCor;
        public double[] epMrk;
        public double[] epOpt;
        public bool[] numericalEmphasis;
        public double[] workMem;

        public CplexParam()
        {
            rootAlg = new int[2];
            barCrossAlg = new int[2];
            barEpComp = new double[2];
            barMaxCor = new int[2];
            epMrk = new double[2];
            epOpt = new double[2];
            numericalEmphasis = new bool[2] { false, false };
            workMem = new double[2];
        }
    }
}
