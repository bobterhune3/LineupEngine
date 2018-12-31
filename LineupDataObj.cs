using System;

namespace LineupEngine
{

    [Serializable()]
    public class LineupData
    {
        public LineupData(long Id, String arm, LineupBalanceItem to, LineupBalanceItem from, int atBats)
        {
            PitcherArm = arm;
            BalanceItemTo = to;
            BalanceItemFrom = from;
            EstimatedAtBats = atBats;
        }

        public LineupData(long Id, String arm, LineupBalanceItem to, LineupBalanceItem from, int atBats, long id)
        {
            PitcherArm = arm;
            BalanceItemTo = to;
            BalanceItemFrom = from;
            EstimatedAtBats = atBats;
            Id = id;
        }


        public long Id { get; set; }

        public String PitcherArm { get; set; }
        public LineupBalanceItem BalanceItemTo { get; set; }
        public LineupBalanceItem BalanceItemFrom { get; set; }
        public int EstimatedAtBats { get; set; }
//        public Guid lineupGuid { get; set; }

        public override String ToString()
        {
            if (PitcherArm.Equals("X"))
                return "";
            return PitcherArm + " " + BalanceItemFrom + "-" + BalanceItemTo;
        }

    }
}
