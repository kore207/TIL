using DronMap.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DronMap.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions options) : base(options) {}
        public DbSet<Dron> Drons { get; set; }
        public DbSet<DronIndex> DronIndexs { get; set; }
    }
}
