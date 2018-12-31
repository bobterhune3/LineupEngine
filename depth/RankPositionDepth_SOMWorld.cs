using System;
using System.Collections.Generic;
using System.Text;

/*


range	P	 C	   1B	  2B	  3B	 SS	      LF	  CF	  RF
1	  0.0	1.4   0.0	 0.0	 0.0 	 0.0	 0.0	 0.0	 0.0
2	  5.6	1.4	  5.6	16.8	 8.4	19.6	 8.4	12.6	 8.4
3	  8.4	1.4	 11.2	33.6	16.8	39.2	16.8	25.2	16.8
4	 16.8	1.4	 16.8	50.4	25.2	58.8	30.8	46.2	30.8
5 	 22.4	1.4	 22.4	67.2	33.6	78.4	42.0	63.0	42.0

	
    */


namespace LineupEngine
{
    class RankPositionDepth_SOMWorld : IRankDefScorer
    {
        private static double[] catcherMult = { 1.4,  1.4,  1.4,  1.4,  1.4 };
        private static double[] firstMult   = {   0,  5.6, 11.2, 16.8, 22.4 };
        private static double[] secondMult  = {   0, 16.8, 33.6, 50.4, 67.2 };
        private static double[] thirdMult   = {   0,  8.4, 16.8, 25.2, 33.6 };
        private static double[] shortMult   = {   0, 19.6, 39.2, 58.8, 78.4 };
        private static double[] leftMult    = {   0,  8.4, 16.8, 30.8, 42.0 };
        private static double[] centerMult  = {   0, 12.6, 25.2, 46.2, 63.0 };
        private static double[] rightMult   = {   0,  8.4, 16.8, 30.8, 42.0 };

        public double calculateCatcherDefScore(int range, int eRating)
        {
            return catcherMult[range - 1] + eRating;
        }
        public double calculateFirstBaseDefScore(int range, int eRating)
        {
            return firstMult[range - 1] + eRating;
        }
        public double calculateSecondBaseDefScore(int range, int eRating)
        {
            return secondMult[range - 1] + eRating;
        }
        public double calculateThirdBaseDefScore(int range, int eRating)
        {
            return thirdMult[range - 1] + eRating;
        }
        public double calculateShortStopDefScore(int range, int eRating)
        {
            return shortMult[range - 1] + eRating;
        }
        public double calculateLeftFieldDefScore(int range, int eRating)
        {
            return leftMult[range - 1] + eRating;
        }
        public double calculateCenterFieldDefScore(int range, int eRating)
        {
            return centerMult[range - 1] + eRating;
        }
        public double calculateRightFieldDefScore(int range, int eRating)
        {
            return rightMult[range - 1] + eRating;
        }
    }
}
