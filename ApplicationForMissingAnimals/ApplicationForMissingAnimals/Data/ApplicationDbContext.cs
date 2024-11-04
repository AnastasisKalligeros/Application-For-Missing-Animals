using Microsoft.EntityFrameworkCore;
using ApplicationForMissingAnimals.Models;

namespace ApplicationForMissingAnimals.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }
        public DbSet<Animal> NewAnimals { get; set; }
    }
}
