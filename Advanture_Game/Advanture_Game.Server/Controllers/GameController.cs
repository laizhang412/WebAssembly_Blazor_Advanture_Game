using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Advanture_Game.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Advanture_Game.Server.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private static GameModel gm = new GameModel();
        // GET: api/values
        public List<GameModel> list;
        public GameController()
        {
            list = new List<GameModel>();
            list.Add(gm);
        }
        [HttpGet]
        public IEnumerable<GameModel> Get()
        {
            return list;
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private int[,] getGrid(int difficulty)
        {
            int[,] grid = new int[difficulty, difficulty];
            Random r = new Random();
            for (int i = 0; i < difficulty; i++) for (int j = 0; j < difficulty; j++) grid[i, j] = r.Next(-10, 3);
            return grid;
        }

        
    }
}
