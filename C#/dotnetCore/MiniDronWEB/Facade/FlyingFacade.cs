using MiniDronWEB.DB;
using MiniDronWEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDronWEB.Facade
{
    public class FlyingFacade
    {
        public TB_FLYING SelectFlyingData(string flyingID, string dronID)
        {
            TB_FLYING flyingData = null;

            int R_TotalCount = 0;
            DataTable dt = GetFlyingList(flyingID, dronID, ref R_TotalCount);
            if(dt != null && dt.Rows.Count > 0)
            {
                flyingData = new TB_FLYING();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    flyingData.SetData(dt.Rows[i]);
                }
            }

            return flyingData;
        }

        public DataTable SelectFlyingData()
        {
            int R_TotalCount = 0;
            return GetFlyingList(null, null, ref R_TotalCount);
        }

        public DataTable GetFlyingList(string flyingID, string dronID, ref int R_TotalCount)
        {
            FlyingBiz flyingBiz = new FlyingBiz();
            return flyingBiz.GetFlyingList(flyingID, dronID, ref R_TotalCount);
        }


    }
}
