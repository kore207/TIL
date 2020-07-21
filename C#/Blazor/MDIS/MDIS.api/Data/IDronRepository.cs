using MDIS.api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDIS.api.Data
{
    public interface IDronRepository
    {
        Task<IEnumerable<TbDrone>> GetDrones();
        Task<TbDrone> GetDrone(string dronID);
    }
}
