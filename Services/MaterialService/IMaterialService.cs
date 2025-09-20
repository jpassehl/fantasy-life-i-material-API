using fantasy_life_i_material_API.Models;
using Microsoft.Extensions.Logging;

namespace fantasy_life_i_material_API.Services.MaterialService
{
    public interface IMaterialService
    {
        Task<IEnumerable<Material>> ListAsync();
        Task<Material> GetAsync(int id);
        Task<Material> SaveAsync(Material material);

    }
}
