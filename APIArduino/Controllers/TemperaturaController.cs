using Microsoft.AspNetCore.Mvc;
using APIArduino.Models;
using APIArduino.Data;
using System.Linq;

namespace APIArduino.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperaturaController : Controller
    {
        private readonly SensoresContext _context;

        public TemperaturaController(SensoresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _context.Temperaturas.ToList();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Temperatura temp)
        {
            _context.Temperaturas.Add(temp);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = temp.ID }, temp);
        }
    }
}
