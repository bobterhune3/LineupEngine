using System;
using somReporter;
using System.Collections.Generic;

namespace LineupEngine
{
    public class LineupEngine
    {
        public static CalculatorFactory.CalculatorType USAGE_CALCULATOR = CalculatorFactory.CalculatorType.ALL_PITCHERS_AND_SCHEDULE;
        public enum POSITIONS { CATCHER = 1, FIRSTBASE, SECONDBASE, THIRDBASE, SHORTSTOP, LEFTFIELD, CENTERFIELD, RIGHTFIELD, DH };
 
        public LineupEngine()
        {

        }

        public void initialize(String fileLocation)
        {
            BalanceAtBats = new List<Dictionary<int, int>>();

            // Load Stored data from database file
            StoredLineups = LineupPersistence.loadDatabase();

            TeamReportFile = new SOMTeamReportFile(fileLocation, StoredLineups, new Config());
            TeamReportFile.parse();

            CompleteListOfTeams = TeamReportFile.getTeams();

            TeamLineupData = TeamInformation.loadDatabase();
        }


        public List<Team> CompleteListOfTeams { get; set; }

        public TeamInfo TeamLineupData { get; set; }

        public Dictionary<String, TeamLineup> StoredLineups { get; set; }

        public SOMTeamReportFile TeamReportFile { get; set; }

        // 0=Righties, 1=Lefties, Map is balance ("9L) and Projected At Bats
        public List<Dictionary<int, int>> BalanceAtBats { get; set; }

        public void saveDatabase()
        {
            TeamInformation.saveDatabase(TeamLineupData);
        }

    }
}
