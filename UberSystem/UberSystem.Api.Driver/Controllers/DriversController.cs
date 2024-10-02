using Microsoft.AspNetCore.Mvc;

namespace UberSystem.Api.Driver.Controllers
{
    [Route("api/uber-system")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        // GET: api/<DriversController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DriversController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DriversController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DriversController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DriversController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
