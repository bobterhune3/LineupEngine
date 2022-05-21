

namespace LineupEngine
{
    public interface IRankDefScorer
    {
        double calculateCatcherDefScore(int range, int eRating, int throwingRating);
        double calculateFirstBaseDefScore(int range, int eRating);
        double calculateSecondBaseDefScore(int range, int eRating);
        double calculateThirdBaseDefScore(int range, int eRating);
        double calculateShortStopDefScore(int range, int eRating);
        double calculateLeftFieldDefScore(int range, int eRating, int throwingRating);
        double calculateCenterFieldDefScore(int range, int eRating, int throwingRating);
        double calculateRightFieldDefScore(int range, int eRating, int throwingRating);
    }
}
