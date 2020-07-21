using MDIS.api.Data;
using MDIS.api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MDIS.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronesController : ControllerBase
    {
        private readonly IDronRepository dronRepository;

        public DronesController(IDronRepository dronRepository)
        {
            this.dronRepository = dronRepository;
        }

        [HttpGet]        
        public async Task<ActionResult> GetDrones()
        {            
            try
            {                                
                return Ok(await dronRepository.GetDrones());
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "DB 에러");
            }            
        }
        
        [HttpGet("{dronId}")]
        public async Task<ActionResult<TbDrone>> GetDrone(string dronId)
        {
            try
            {
                var result = await dronRepository.GetDrone(dronId);

                //cors 설정 안하고 jsonp 로 반환 해야하는 경우 
                //string json = null;
                //using (var ms = new MemoryStream())
                //{
                //    var serializer = new DataContractJsonSerializer(typeof(TbDrone));
                //    serializer.WriteObject(ms, await dronRepository.GetDrone(dronId));
                //    json = Encoding.UTF8.GetString(ms.ToArray());
                //}

                //if (json == null)
                //{
                //    return NotFound();
                //}                

                //var jsonp = string.Format("callback({0});", json);
                //Response.ContentType = "application/javascript";
                //return Content(jsonp); //cors 문제로 인해 jsonp 형태로 보낸다. 

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "DB 에러");
            }
        }
    }
}
