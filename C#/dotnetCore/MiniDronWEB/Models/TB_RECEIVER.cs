using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDronWEB.Models
{
    public class TB_RECEIVER
    {
        [Key]
        public string RECEIVER_ID { get; set; } //식별기 ID
        public string RECEIVER_NAME { get; set; }
        public string DEVICE_TYPE { get; set; }
        public string MANUFACTURER { get; set; }
        public string MODEL { get; set; }
        public string SERIALNO{ get; set; }
        public string ISUSE { get; set; }
        public string SATATUS_CODE { get; set; }
        public double DRONENUM { get; set; }
        public string WORKINGTYPE { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }



    }
    
}
