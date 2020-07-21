using MDIS.api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniDronIdentifySystem.Service
{
    public interface IDronService
    {
        Task<IEnumerable<TbDrone>> GetTbDrones();

        Task<TbDrone> GetDrone(string dronId);
    }
}
