using Cybertek.Entities.Entities;
using Cybertek.Entities.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertek.Entities.Repositories
{
    public class PurchasingEntityRepository : BaseEntityRepository<PurchasingEntity>, IPurchasingEntityRepository
    {
        internal PurchasingEntityRepository(CybertekDbContext context)
            :base(context)
        {
        }

        private CybertekDbContext CybertekDbContext
        {
            get { return _context as CybertekDbContext; }
        }
    }
}
