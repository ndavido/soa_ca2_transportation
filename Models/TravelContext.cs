using Microsoft.EntityFrameworkCore;

namespace soa_ca2.Models
{
    public class TravelContext : DbContext
    {
        public DbSet<Travel> Travel { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public string DbPath { get; }

        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }
    }
}
