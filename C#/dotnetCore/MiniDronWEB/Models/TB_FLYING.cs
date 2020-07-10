using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDronWEB.Models
{
    public class TB_FLYING
    {
        public string FLYING_ID { get; set; }
        public string DRONE_ID { get; set; }
        public float AvgSpeed { get; set; }
        public float FlyingTime { get; set; }
        public float FlyingDistance { get; set; }
        public DateTime FLYING_START_TIME { get; set; }
        public DateTime FLYING_END_TIME { get; set; }
        public string POSTNO { get; set; }
        public string CM_POSTNO { get; set; }
        public float ControlDistance { get; set; }

        public void SetData(DataRow dr)
        {
            this.FLYING_ID = dr["FLYING_ID"].ToString();
            this.DRONE_ID = dr["DRONE_ID"].ToString();
            this.AvgSpeed = Int64.Parse(dr["AvgSpeed"].ToString());
            this.FlyingTime = Int64.Parse(dr["FlyingTime"].ToString());
            this.FlyingDistance = Int64.Parse(dr["FlyingDistance"].ToString());

            //this.FLYING_START_TIME = dr["FLYING_START_TIME"].ToString();
            //this.FLYING_END_TIME = dr["FLYING_END_TIME"].ToString();
            this.POSTNO = dr["POSTNO"].ToString();
            this.CM_POSTNO = dr["CM_POSTNO"].ToString();
            this.ControlDistance = Int64.Parse(dr["ControlDistance"].ToString());
        }

    }
}
