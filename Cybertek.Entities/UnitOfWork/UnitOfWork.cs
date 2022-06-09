using Cybertek.Entities.Repositories;
using Cybertek.Entities.Repositories.Interfaces;
using Cybertek.Entities.UnitOfWork.Interfaces;

namespace Cybertek.Entities.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly CybertekDbContext _context;

        public UnitOfWork(CybertekDbContext context)
        {
            _context = context;

            Categories = new CategoryEntityRepository(_context);
            Products = new ProductEntityRepository(_context);
            Suppliers = new SupplierEntityRepository(_context);
            Purchases = new PurchasingEntityRepository(_context);
            Sales = new SalesEntityRepository(_context);
        }
       
        public ICategoryEntityRepository Categories { get; private set; }
        public IProductEntityRepository Products { get; private set; }
        public ISupplierEntityRepository Suppliers { get; private set; }
        public IPurchasingEntityRepository Purchases { get; private set; }
        public ISalesEntityRepository Sales { get; private set; }
        public int CompleteUOW()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
