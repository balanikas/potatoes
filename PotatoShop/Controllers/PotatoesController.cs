using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PotatoShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PotatoesController : ControllerBase
    {
        private readonly AppContext _context;

        public PotatoesController(
            AppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Potato>> Get()
        {
            return Ok(_context.Potatoes.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Potato> Get(int id)
        {
            return Ok(_context.Potatoes.SingleOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult<Potato> Post(Potato potato)
        {
            _context.Potatoes.Add(potato);
            _context.SaveChanges();
            return Ok(potato);
        }

        [HttpPut]
        public IActionResult Put(Potato potato)
        {
            _context.Potatoes.Update(potato);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var potato = _context.Potatoes.Single(x => x.Id == id);
            _context.Potatoes.Remove(potato);
            _context.SaveChanges();

            return Ok();
        }
    }
}
