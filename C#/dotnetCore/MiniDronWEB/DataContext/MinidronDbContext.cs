using Microsoft.EntityFrameworkCore;
using MiniDronWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDronWEB.DataContext
{
    public class MinidronDbContext : DbContext
    {
        public DbSet<TB_DRONE> TB_DRONE { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-N7C1AVE;Database=MDISDB;User Id=sa;Password=1764");
        }
        
    }
}
