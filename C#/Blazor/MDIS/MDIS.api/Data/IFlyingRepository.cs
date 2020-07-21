using MDIS.api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDIS.api.Data
{
    public interface IFlyingRepository
    {
        IEnumerable<TbFlying> GetFlyings();
        TbFlying GetFlying(string flyingId);
    }
}
