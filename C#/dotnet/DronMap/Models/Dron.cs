using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronMap.Models
{
    public class Dron
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        
    }
}
