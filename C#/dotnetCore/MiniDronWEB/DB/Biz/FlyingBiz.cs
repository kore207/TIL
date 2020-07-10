using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using NetcusF.Biz;

namespace MiniDronWEB.DB
{
    public class FlyingBiz : BizBase
    {
        public DataTable GetFlyingList(string flyingID, string dronID, ref int R_TotalCount)
        {
            FlyingDac dac = new FlyingDac();
            return dac.GetFlyingList(flyingID, dronID, ref R_TotalCount);
        }

        public DataTable GetFlyingList(ref int R_TotalCount)
        {
            FlyingDac dac = new FlyingDac();
            return dac.GetFlyingList(ref R_TotalCount);
        }
    }
}
