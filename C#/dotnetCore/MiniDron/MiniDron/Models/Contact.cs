using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDron.Models
{
    public class Contact
    {
        public string dronID { get; set; }
        public string regNumber { get; set; }
        public string dronType { get; set; }

        public double latitude { get; set; }
        
        public double longitude { get; set; }
    }
}
