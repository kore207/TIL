using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NetcusF.Dac;

namespace MiniDronWEB.DB
{
    public class FlyingDac : DacBase
    {
        public DataTable GetFlyingList(string flyingID, string dronID, ref int R_TotalCount)
        {
            DataTable dt = new DataTable();
            DataParameterCollection param = new DataParameterCollection();

            try
            {
                param.Add(new SqlParameter("@FLYING_ID", flyingID));
                param.Add(new SqlParameter("@Dron_ID", dronID));
                R_TotalCount = this.Fill("USP_FLYING_SL", param, dt, CommandType.StoredProcedure, false); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable GetFlyingList(ref int R_TotalCount)
        {
            DataTable dt = new DataTable();
            DataParameterCollection param = new DataParameterCollection();

            try
            {
                R_TotalCount = this.Fill("USP_FLYING_SL", param, dt, CommandType.StoredProcedure, false);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return dt;
        }
    }
}
