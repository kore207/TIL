using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniDron.Models;


//운용 현황 컨트롤러 

namespace MiniDron.Controllers
{    
    public class DronPosition
    {
        public  double ta = 0; //= 36.393997;
        public  double tb = 0; // = 127.353001;
        //1.방향 거리 설정 
        //2. 이동 
        public  int direction; // 0:w 1:e 2:n 3:s 4:nw 5:sw 6: se 7: en  (0~7)
        public  int length; // 1~99
        public  int lengCnt = 0;

        public const double moveLength = 0.000003;
        public void moveCopr()
        {
            Console.Write(this.ta);
            if (this.lengCnt == 0)
            {
                Random rand = new Random();
                this.direction = rand.Next(0, 7);
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

        public IActionResult Contact()
        {
            var model = new Contact { };

            return PartialView("_ContactModalPartial", model);
            
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
            if(dCnt < 1)
                DP1.moveCopr();
            if (dCnt < 2)
                DP2.moveCopr();
            if (dCnt < 3)
                DP3.moveCopr();
            

            var dronInfo = new List<Contact>()
            {
                new Contact(){
                    dronID = "dron 1",
                    regNumber = "1111-1111",
                    dronType = "normal",
                    latitude =  36.3935713 + DP1.ta,
                    longitude = 127.3542514 + DP1.tb
                },
                new Contact() {
                    dronID = "dron 2",
                    regNumber = "2222-2221",
                    dronType = "normal",
                    latitude = 36.3955713 +DP2.ta ,
                    longitude = 127.3562514 + DP2.tb
                },
                new Contact() {
                    dronID = "dron3",
                    regNumber = "3333-1313",
                    dronType = "normal",
                    latitude = 36.3955713+ DP3.ta,
                    longitude = 127.3522514 + DP3.tb
                }
            };

            return new JsonResult(dronInfo);
        }
    }
}