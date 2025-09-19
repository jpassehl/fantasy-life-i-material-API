using fantasy_life_i_material_API.Data;
using fantasy_life_i_material_API.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace fantasy_life_i_material_API.Repositories
{
    public class MaterialRepository : BaseRepository, IMaterialRepository
    {
        public MaterialRepository(MaterialDbContext context)
            : base(context) { }

        public async Task<IEnumerable<Material>> ListAsync()
        {
            return await _context.Materials.ToListAsync();

        }

        public async Task<Material?> FindByIdAsync(int id)
        {
            return await _context.Materials.FindAsync(id);
        }


        public async Task AddAsync(Material material)
        {
            await _context.Materials.AddAsync(material);
        }

        public void Update(Material material)
        {
            _context.Materials.Update(material);
        }
        public void Remove(Material material)
        {
            _context.Materials.Remove(material);
        }
    }
}
