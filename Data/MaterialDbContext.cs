using fantasy_life_i_material_API.Models;
using Microsoft.EntityFrameworkCore;

namespace fantasy_life_i_material_API.Data
{
    public class MaterialDbContext(DbContextOptions<MaterialDbContext> options) : DbContext(options)
    {
        public DbSet<Material> Materials => Set<Material>();

    }
}
