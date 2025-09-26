
using Azure;
using fantasy_life_i_material_API.Data;
using fantasy_life_i_material_API.Models;
using fantasy_life_i_material_API.Repositories;
using Microsoft.Extensions.Logging;

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
        public async Task<Material> GetAsync(int id)
        {
            return await _materialRepository.FindByIdAsync(id);
        }
        public async Task<Material> SaveAsync(Material material)
        {
            try
            {
                var existingMaterial = await _materialRepository.FindByIdAsync(material.Id);

                await _materialRepository.AddAsync(material);
                await _unitOfWork.CompleteAsync();

                return existingMaterial;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                throw; // Ensure the exception is propagated to maintain proper error handling.
            }
        }
        public async Task<Material> UpdateAsync(int id, Material material)
        {
            var existingMaterial = await _materialRepository.FindByIdAsync(id);

            existingMaterial.Name = material.Name;
            existingMaterial.Crafted = material.Crafted;
            existingMaterial.GatheredFrom = material.GatheredFrom;
            existingMaterial.LifeRequired = material.LifeRequired;
            existingMaterial.Category = material.Category;

            try
            {
                _materialRepository.Update(existingMaterial);
                await _unitOfWork.CompleteAsync();

                return existingMaterial;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                throw; // Ensure the exception is propagated to maintain proper error handling.
            }
        }
        public async Task<Material> DeleteAsync(int id)
        {
            var existingMaterial = await _materialRepository.FindByIdAsync(id);

            try
            {
                _materialRepository.Remove(existingMaterial);
                await _unitOfWork.CompleteAsync();

                return existingMaterial;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                throw; // Ensure the exception is propagated to maintain proper error handling.
            }
        }

    }
}
