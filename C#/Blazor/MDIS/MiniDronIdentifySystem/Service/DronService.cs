using MDIS.api.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiniDronIdentifySystem.Service
{
    public class DronService : IDronService
    {
        private readonly HttpClient httpClient;

        public DronService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<TbDrone> GetDrone(string dronId)
        {
            return await httpClient.GetJsonAsync<TbDrone>($"api/Drones/{dronId}");            
        }

        public async Task<IEnumerable<TbDrone>> GetTbDrones()
        {
            return await httpClient.GetJsonAsync<TbDrone[]>("api/Drones");
        }
    }
}
