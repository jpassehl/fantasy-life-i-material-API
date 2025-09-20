using fantasy_life_i_material_API.Models;
using Microsoft.EntityFrameworkCore;

namespace fantasy_life_i_material_API.Data
{
    public class MaterialDbContext(DbContextOptions<MaterialDbContext> options) : DbContext(options)
    {
        public DbSet<Material> Materials => Set<Material>();

        /* Automatically Insert (add seed data) into the database.
        |  When we add another migration and update the database these entities
        |  will be included. (ex: Add-Migration Seeding) */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Material>().HasData(
                new Material
                {
                    Id = 1,
                    Name = "Starry Log",
                    Type = "Log",
                    Gatherable = true,
                    GatheredFrom = ["Starry Tree", "Great Starry Tree"],
                    LifeRequired = "Woodcuter",
                    Category = "Carpentry Material"
                },
            new Material
            {
                Id = 2,
                Name = "Swolean Gold",
                Type = "Ore",
                Gatherable = true,
                GatheredFrom = [
                    "Gold Deposit","Great Gold Deposit",
                    "Superior Gold Deposit","Amazing Gold Deposit"
                    ],
                LifeRequired = "Miner",
                Category = "Smithing Material"
            },
            new Material
            {
                Id = 3,
                Name = "Sunny Puff",
                Type = "Plant",
                Gatherable = true,
                GatheredFrom = ["Ground"],
                LifeRequired = null,
                Category = "Tailoring Material"
            },
            new Material
            {
                Id = 4,
                Name = "Red Anthurium",
                Type = "Plant",
                Gatherable = true,
                GatheredFrom = ["Ground"],
                LifeRequired = null,
                Category = "Artistry Material"
            }
           );
        }

    }
}
