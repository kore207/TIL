using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDron.Models
{
    public class DronData
    {
        public string dronID { get; set; }
        public string regNumber { get; set; }
        public string dronType { get; set; }
        public double latitude { get; set; }        
        public double longitude { get; set; }
        public int speed { get; set; }
        public string identyDevice { get; set; }        
        public int altitude { get; set; }
        public int direction { get; set; }

                    }

    public class ControllerData
    {
        //드론 조종기 관련
        public string ControllerID { get; set; }
        public double Controllerlatitude { get; set; }
        public double Controllerlongitude { get; set; }
    }
}
