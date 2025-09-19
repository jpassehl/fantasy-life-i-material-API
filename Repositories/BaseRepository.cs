using fantasy_life_i_material_API.Data;
using System;

namespace fantasy_life_i_material_API.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MaterialDbContext _context;

        public BaseRepository(MaterialDbContext context)
        {
            _context = context;
        }
    }
}
