using System;

namespace fantasy_life_i_material_API.Data
{
    public class UnitOfWork(MaterialDbContext context) : IUnitOfWork
    {
        private readonly MaterialDbContext _context = context;

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
