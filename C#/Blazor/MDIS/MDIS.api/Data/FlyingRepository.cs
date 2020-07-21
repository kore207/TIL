using MDIS.api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDIS.api.Data
{
    public class FlyingRepository : IFlyingRepository
    {
        private readonly MDISDBContext mdisDbContext;

        public FlyingRepository(MDISDBContext mdisDbContext)
        {
            this.mdisDbContext = mdisDbContext;
        }

        public TbFlying GetFlying(string flyingId)
        {
            return mdisDbContext.TbFlying
                .FirstOrDefault(f => f.FlyingId == flyingId);
        }

        public IEnumerable<TbFlying> GetFlyings()
        {
            return mdisDbContext.TbFlying;
        }
    }
}
