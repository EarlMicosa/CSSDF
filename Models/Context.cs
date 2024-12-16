using Microsoft.EntityFrameworkCore;

namespace PetManager.Model
{
    public class PetContext : DbContext
    {

        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }

    }
}
