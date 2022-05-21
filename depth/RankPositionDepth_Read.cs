using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace LineupEngine
{
    public class RankPositionDepth_Read : IRankDefScorer
    {
        // Key =Position
        //         List of [Range -1]
        //               Efactor = Score
        private Dictionary<String, List<Dictionary<int, double>>> scoring = new Dictionary<String, List<Dictionary<int, double>>>();
        private enum RANGES {  RANGE_1=0, RANGE_2=1, RANGE_3=2, RANGE_4=3, RANGE_5=4 };

        //"POS,EFACTOR,ONE,TWO,THREE,FOUR,FIVE"
        internal RankPositionDepth_Read()
        {
            var assembly = Assembly.GetExecutingAssembly();
            String dataFile = Properties.Resources.ReadEFactorCompare;
            byte[] byteArray = Encoding.ASCII.GetBytes(dataFile);
            MemoryStream stream = new MemoryStream(byteArray);
            Boolean firstLine = true;
            List<string[]> lines = new List<string[]>();
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }
                    string[] values = line.Split(',');

                    lines.Add(values);
                }
            }

            foreach( string[] line in lines)
            {
                string pos = line[0];
                int efact = Int32.Parse(line[1]);
                double range1score = Double.Parse(line[2]);
                double range2score = Double.Parse(line[3]);
                double range3score = Double.Parse(line[4]);
                double range4score = Double.Parse(line[5]);
                double range5score = Double.Parse(line[6]);

                if(!scoring.ContainsKey(pos))
                {
                    scoring.Add(pos, new List<Dictionary<int, double>>());
                    List<Dictionary<int, double>> tempData = scoring[pos];
                    tempData.Add(new Dictionary<int, double>());  // Range One
                    tempData.Add(new Dictionary<int, double>());  // Range Two
                    tempData.Add(new Dictionary<int, double>());  // Range Three
                    tempData.Add(new Dictionary<int, double>());  // Range Four
                    tempData.Add(new Dictionary<int, double>());  // Range Five
                }

                List<Dictionary<int, double>> positionData = scoring[pos];
                positionData[(int)RANGES.RANGE_1].Add(efact, range1score);
                positionData[(int)RANGES.RANGE_2].Add(efact, range2score);
                positionData[(int)RANGES.RANGE_3].Add(efact, range3score);
                positionData[(int)RANGES.RANGE_4].Add(efact, range4score);
                positionData[(int)RANGES.RANGE_5].Add(efact, range5score);
            }
        }

        public double calculateCatcherDefScore(int range, int eRating, int throwinArm)
        {
            return throwinArm * -1;
        }

        public double calculateCenterFieldDefScore(int range, int eRating, int throwingArm)
        {
            return lookItUp("CF", range, eRating, throwingArm);
        }

        public double calculateFirstBaseDefScore(int range, int eRating)
        {
            return lookItUp("1B", range, eRating);
        }

        public double calculateLeftFieldDefScore(int range, int eRating, int throwingArm)
        {
            return lookItUp("LF", range, eRating, throwingArm);
        }

        public double calculateRightFieldDefScore(int range, int eRating, int throwingArm)
        {
            return lookItUp("RF", range, eRating, throwingArm);
        }

        public double calculateSecondBaseDefScore(int range, int eRating)
        {
            return lookItUp("2B", range, eRating);
        }

        public double calculateShortStopDefScore(int range, int eRating)
        {
            return lookItUp("SS", range, eRating);
        }

        public double calculateThirdBaseDefScore(int range, int eRating)
        {
            return lookItUp("3B", range, eRating);
        }

        private double lookItUp(String pos, int range, int eRating)
        {
            return lookItUp(pos, range, eRating, 0);
        }

        private double lookItUp(String pos, int range, int eRating, int throwingArm)
        {
            String tempPos = pos;
            if (pos.Equals("LF") || pos.Equals("RF"))
                tempPos = "OF";

            if (scoring[tempPos][range - 1].ContainsKey(eRating))
            {
                double arm = 0;
                if( pos.Equals("LF")) {  //LF - Arm give 1/2 point credit/penality
                    arm = (double)throwingArm / 2.0;
                }
                else if (pos.Equals("CF") || pos.Equals("RF"))
                {  //CF & RF- Arm give 1 point credit/penality
                    arm = throwingArm;
                }
                return scoring[tempPos][range - 1][eRating] + arm;
            }
            else
            {
                System.Console.WriteLine("Position Def is missing: " + tempPos + " " + range + "e" + eRating);
                return 0;
            }
        }

    }


}
