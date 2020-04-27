using DronMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DronMap.ViewModels
{
    public class CustomDronViewModel
    {
        public DronIndex DronIndex { get; set; }
        public List<Dron> Dron { get; set; }
    }
}
