using Cybertek.Entities.Entities;
using Cybertek.Entities.Repositories.Interfaces;

namespace Cybertek.Entities.Repositories
{
    public class SupplierEntityRepository : BaseEntityRepository<SupplierEntity>, ISupplierEntityRepository
    {
        internal SupplierEntityRepository(CybertekDbContext context)
            : base(context)
        {
        }

        private CybertekDbContext CybertekDbContext
        {
            get { return _context as CybertekDbContext; }
        }
    }
}
