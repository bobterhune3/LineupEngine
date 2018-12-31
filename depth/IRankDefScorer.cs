

namespace LineupEngine
{
    public interface IRankDefScorer
    {
        double calculateCatcherDefScore(int range, int eRating);
        double calculateFirstBaseDefScore(int range, int eRating);
        double calculateSecondBaseDefScore(int range, int eRating);
        double calculateThirdBaseDefScore(int range, int eRating);
        double calculateShortStopDefScore(int range, int eRating);
        double calculateLeftFieldDefScore(int range, int eRating);
        double calculateCenterFieldDefScore(int range, int eRating);
        double calculateRightFieldDefScore(int range, int eRating);
    }
}
