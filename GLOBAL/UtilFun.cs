using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Global
{
    public class UtilFun
    {
        public static long GetTimeSLasTamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }
    }
}
