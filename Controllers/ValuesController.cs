using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    // http://localhost:5000/api/[values]
    // Convention based 
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // Because private field add underscore _ infront of variable name, it's a style convention.
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        /**
         * IEnumerable is just a collection of things. Ex IEnumberable<string> is a collection of strings. 
         * I action result allows us to us Ok which will return a http 200 response
         * */ 
        
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync(); // get values from database
            return Ok(values); // return to values to client with http 200 response
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id) // inputted from query param matching var name id
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id); // Exceptions are expensive so FirstorDefault is better
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
