using Microsoft.EntityFrameworkCore;
using APIArduino.Models;

namespace APIArduino.Data
{
    public class SensoresContext : DbContext
    {
        public DbSet<Ultrasonico> Ultrasonicos { get; set; }
        public DbSet<Temperatura> Temperaturas { get; set; }

        public SensoresContext(DbContextOptions<SensoresContext> options)
            : base(options)
        {
        }
    }
}
