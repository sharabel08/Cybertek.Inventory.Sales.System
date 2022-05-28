using Cybertek.Entities.Repositories.Interfaces;
using System;

namespace Cybertek.Entities.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryEntityRepository Categories { get; }
        IProductEntityRepository Products { get; }
        IPurchasingEntityRepository Purchases { get; }
        ISupplierEntityRepository Suppliers { get; }

        int CompleteUOW();
    }
}
