using Cybertek.Entities.Entities;
using Cybertek.Entities.Repositories.Interfaces;

namespace Cybertek.Entities.Repositories
{
    public class SalesEntityRepository : BaseEntityRepository<SalesEntity>, ISalesEntityRepository
    {
        internal SalesEntityRepository(CybertekDbContext context)
            : base(context)
        {
        }

        private CybertekDbContext CybertekDbContext
        {
            get { return _context as CybertekDbContext; }
        }

    }


}
