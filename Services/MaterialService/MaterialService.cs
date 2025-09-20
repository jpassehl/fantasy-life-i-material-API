
using Azure;
using fantasy_life_i_material_API.Data;
using fantasy_life_i_material_API.Models;
using fantasy_life_i_material_API.Repositories;

namespace fantasy_life_i_material_API.Services.MaterialService
{
    public class MaterialService : IMaterialService
    {
        private IMaterialRepository _materialRepository;
        private IUnitOfWork _unitOfWork;
        public MaterialService(IMaterialRepository materialRepository, IUnitOfWork unitOfWork)
        {
            this._materialRepository = materialRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Material>> ListAsync()
        {
            return await _materialRepository.ListAsync();
        }
        public async Task<Material> GetMaterialAsync(int id)
        {
            return await _materialRepository.FindByIdAsync(id);
        }

    }
}
