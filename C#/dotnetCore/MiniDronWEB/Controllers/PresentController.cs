using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MiniDronWEB.DataContext;
using MiniDronWEB.Facade;
using MiniDronWEB.Models;


namespace MiniDronWEB.Controllers
{
    public class DronPosition
    {
        public double ta = 0; //= 36.393997;
        public double tb = 0; // = 127.353001;
        //1.방향 거리 설정 
        //2. 이동 
        public int direction; // 0:w 1:e 2:n 3:s 4:nw 5:sw 6: se 7: en  (0~7)
        public int length; // 1~99
        public int lengCnt = 0;

        public const double moveLength = 0.000003;
        public void moveCopr()
        {

            if (this.lengCnt == 0)
            {
                Random rand = new Random();
                this.direction = rand.Next(0, 9);
                this.length = rand.Next(300, 500);
            }
            switch (direction)
            {
                case 0:
                    this.ta += moveLength;
                    this.lengCnt++;
                    break;
                case 1:
                    this.ta -= moveLength;
                    this.lengCnt++;
                    break;
                case 2:
                    this.tb += moveLength;
                    this.lengCnt++;
                    break;
                case 3:
                    this.tb -= moveLength;
                    this.lengCnt++;
                    break;
                case 4:
                    this.ta += moveLength;
                    this.tb += moveLength;
                    this.lengCnt++;
                    break;
                case 5:
                    this.ta += moveLength;
                    this.tb -= moveLength;
                    this.lengCnt++;
                    break;
                case 6:
                    this.ta -= moveLength;
                    this.tb += moveLength;
                    this.lengCnt++;
                    break;
                case 7:
                    this.ta -= moveLength;
                    this.tb -= moveLength;
                    this.lengCnt++;
                    break;
                case 8://식별 에러 상태
                    this.ta -= moveLength;
                    this.tb -= moveLength;
                    this.lengCnt++;
                    break;
                default:
                    break;
            }

            if (this.lengCnt == this.length)
                this.lengCnt = 0;
        }
    }


    public class PresentController : Controller
    {
        public IActionResult PMap()
        {
            return View();
        }

        public IActionResult PDronSearch()
        {
            return View();
        }

        public IActionResult AntennaSearch()
        {
            return View();
        }

        public IActionResult DronData()
        {
            var model = new DronData { };

            return PartialView("_DronDataModalPartial", model);

        }



        static DronPosition DP1 = new DronPosition();
        static DronPosition DP2 = new DronPosition();
        static DronPosition DP3 = new DronPosition();

        [Route("/Present/AddDronInfo/{dCnt}")]
        public IActionResult AddDronInfo(int dCnt)
        {
            //Random rand = new Random();            
            //int a = rand.Next(-999, 999);
            //ta += (a * 0.000000001);
            //tb -= (a * 0.000000001);
            if (dCnt < 1)
                DP1.moveCopr();
            if (dCnt < 2)
                DP2.moveCopr();
            if (dCnt < 3)
                DP3.moveCopr();


            var dronInfo = new List<DronData>()
            {
                new DronData(){
                    dronID = "dron 1",
                    regNumber = "1111-1111",
                    dronType = "normal",
                    latitude = /* 36.3935713 + */ DP1.ta,
                    longitude =/* 127.3542514 + */DP1.tb,
                    altitude = 113,
                    speed = 23,
                    identyDevice = "식별기A",
                    direction = DP1.direction,
                },
                new DronData() {
                    dronID = "dron 2",
                    regNumber = "2222-2221",
                    dronType = "normal",
                    latitude = /*36.3955713 +*/ DP2.ta ,
                    longitude = /*127.3562514 +*/ DP2.tb,
                    altitude = 76,
                    speed = 24,
                    identyDevice ="식별기A",
                    direction = DP2.direction,
                },
                new DronData() {
                    dronID = "dron3",
                    regNumber = "3333-1313",
                    dronType = "normal",
                    latitude = /*36.3955713+*/ DP3.ta,
                    longitude = /*127.3522514 +*/ DP3.tb,
                    altitude = 213,
                    speed = 22,
                    identyDevice ="식별기B",
                    direction = DP3.direction,
                },


            };

            return new JsonResult(dronInfo);
        }

        [Route("/Present/AddControllerInfo/{dCnt}")]
        public IActionResult AddControllerInfo(int dCnt)
        {
            var controllerInfo = new List<ControllerData>()
            {
                new ControllerData()
                {
                    ControllerID = "controller1",
                    Controllerlatitude = 36.3935713,
                    Controllerlongitude = 127.3542514,
                },

                new ControllerData()
                {
                    ControllerID = "controller2",
                    Controllerlatitude = 36.3955713,
                    Controllerlongitude = 127.3562514,
                },

                new ControllerData()
                {
                    ControllerID = "controller3",
                    Controllerlatitude = 36.3955713,
                    Controllerlongitude = 127.3522514,
                }


            };

            return new JsonResult(controllerInfo);
        }

        //[Route("/Present/Pmap")]
        //public JsonResult GetDronDB()
        //{
        //    string jsonString;

        //    using(var db = new MinidronDbContext())
        //    {
        //        var list = db.TB_DRONE;
        //        jsonString = JsonSerializer.Serialize(list);
        //        return Json(jsonString);
        //    }                        
        //}
        private FlyingFacade ff = new FlyingFacade();

        public IActionResult GetDronDB()
        {
            int a = 0;
            ff.GetFlyingList("dronA", "dronID", ref a);
        
            using (var db = new MinidronDbContext())
            {
                var list = db.TB_DRONE.ToList();
                //controllerInfo = JsonSerializer.Serialize(list);
                return Json(list);
            }
            
        }
    }
}
