using MDIS.api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDIS.api.Data
{
    public class DronRepository : IDronRepository
    {
        private readonly MDISDBContext mdisDbContext;
        public DronRepository(MDISDBContext mdisDbContext)
        {
            this.mdisDbContext = mdisDbContext;
        }
        public async Task<TbDrone> GetDrone(string dronID)
        {
            return await mdisDbContext.TbDrone.FirstOrDefaultAsync(e => e.DroneMid == dronID);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<TbDrone>> GetDrones()
        {            
            return await mdisDbContext.TbDrone.ToListAsync();
            //throw new NotImplementedException();
        }
    }
}
