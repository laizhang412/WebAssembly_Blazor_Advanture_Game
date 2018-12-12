using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Advanture_Game.Shared;
using System.Net.Http;
using Newtonsoft.Json;

namespace Advanture_Game.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        // GET: api/Step
        public static List<Step> list = new List<Step>();

        
        [HttpGet]
        public async Task<IEnumerable<Step>> Get()
        //public IEnumerable<Step> Get()
        {
            if (list.Count == 0)
            {
                string baseAddress = "http://localhost:5000/api/game";
                using (var httpClient = new HttpClient())
                {
                    string json = await httpClient.GetStringAsync(baseAddress);
                    GameModel[] gm = JsonConvert.DeserializeObject<GameModel[]>(json);
                    Step first = new Step();
                    first.x = 0;
                    first.y = 0;
                    first.remain = gm[0].initial;
                    first.difficulty = gm[0].difficulty;
                    first.alive = true;
                    list.Add(first);
                }
            }
            
            return list;
        }

        // GET: api/Step/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Step
        [HttpPost]
        public void Post([FromBody] Step step)
        {
            if(step.alive)
                list.Add(step);
            else
            {
                Step first = list[0];
                list.Clear();
                list.Add(first);
            }
        }

        // PUT: api/Step/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
