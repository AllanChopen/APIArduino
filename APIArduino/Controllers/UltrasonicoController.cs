using Microsoft.AspNetCore.Mvc;
using APIArduino.Models;
using APIArduino.Data;
using System.Linq;

namespace APIArduino.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UltrasonicoController : Controller
    {
        private readonly SensoresContext _context;

        public UltrasonicoController(SensoresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _context.Ultrasonicos.ToList();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ultrasonico sensor)
        {
            _context.Ultrasonicos.Add(sensor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = sensor.ID }, sensor);
        }
    }
}
