using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDronWEB.Models
{
    public class TB_DRONE
    {
        [Key]
        public string DRONE_MID { get; set; } //드론 관리 ID 
        public string DRONE_ID { get; set; } //드론 식별 ID 
        public string DRONE_TYPE { get; set; } //드론 종류
        public string ID_TYPE { get; set; } //식별 ID 종류
        public string ISAUTH { get; set; } //허가여부
        public string ISVALID { get; set; } //식별 ID 유효성 여부
        public string ISFAULTFLYING { get; set; } //비행 금지 위반 여부
        public string ISUSE { get; set; } //사용 여부
        public string STATUS_CODE { get; set; } //현재 상태 코드
        public double LATITUDE { get; set; } //위도
        public double LONGITUDE { get; set; } //경도
        public double ALTITUDE { get; set; } //고도
        public string HEIGHT_TYPE { get; set; } //고도 타입
        public double SPEED { get; set; }
        public double DIRECTION { get; set; }
        public string POSTNO { get; set; } //우편번호(현재위치)
        public double LATITUDE_OPEN { get; set; }
        public double LONGITUDE_OPEN { get; set; }
        public double ALTITUDE_OPEN { get; set; }
        public string POSTNO_OPEN { get; set; }
        public DateTime UPDATE_TIME { get; set; }
        public DateTime CREATE_TIME { get; set; }

    }
    
}
