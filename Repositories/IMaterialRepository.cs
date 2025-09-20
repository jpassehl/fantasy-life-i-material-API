using fantasy_life_i_material_API.Models;

namespace fantasy_life_i_material_API.Repositories
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> ListAsync();
        Task<Material?> FindByIdAsync(int id);
        //Task AddAsync(Material material);
        //void Update(Material material);
        //void Remove(Material material);
    }
}
