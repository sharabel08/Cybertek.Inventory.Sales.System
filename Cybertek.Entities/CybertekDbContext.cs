using Cybertek.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cybertek.Entities
{
    public class CybertekDbContext : DbContext
    {
        public CybertekDbContext(DbContextOptions<CybertekDbContext> options) 
            : base(options)
        {
        }

        internal DbSet<ProductEntity> Products { get; set; }
        internal DbSet<SupplierEntity> Suppliers { get; set; }
        internal DbSet<PurchasingEntity> Purchasings { get; set; }
        internal DbSet<CategoryEntity> Categories { get; set; }
        internal DbSet<SalesEntity> Sales { get; set; }

    }
}
