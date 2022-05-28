using Cybertek.Entities.Entities;
using Cybertek.Entities.Repositories.Interfaces;

namespace Cybertek.Entities.Repositories
{
    public class CategoryEntityRepository : BaseEntityRepository<CategoryEntity>, ICategoryEntityRepository
    {
        internal CategoryEntityRepository(CybertekDbContext context)
            : base(context)
        {
        }

        private CybertekDbContext CybertekDbContext
        {
            get { return _context as CybertekDbContext; }
        }
            
    }
}
