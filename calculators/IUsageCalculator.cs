using System;
using System.Collections.Generic;


namespace LineupEngine
{
    public interface IUsageCalculator
    {
        List<Dictionary<int, int>> calculate();
        List<Dictionary<int, int>> calculate(Func<int, String, int, int, int, int, int> createRowFunc);

        void setOptions(String key, Object value);
    }
}
