using System;
namespace LineupEngine
{
    public class RankDepthFactory
    {
        public enum DEPTH_ALGO { SOMWORD, READ, NONE }
        private static IRankDefScorer cachedObj = null;
        private static DEPTH_ALGO lastSelected = DEPTH_ALGO.NONE;

        public static IRankDefScorer createDepthFactory(DEPTH_ALGO algorhthm)
        {
            if(lastSelected == algorhthm)
            {
                return cachedObj;
            }

            if (algorhthm == DEPTH_ALGO.SOMWORD)
                cachedObj=  new RankPositionDepth_SOMWorld();
            else
                cachedObj = new RankPositionDepth_Read();

            return cachedObj;
        }
    }
}
