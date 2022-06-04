using Cybertek.Entities.Entities;
using Cybertek.Entities.UnitOfWork.Interfaces;
using Cybertek.MVC.Helper.Interfaces;
using Cybertek.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertek.MVC.Helper
{
    public class PurchasingHelper : IPurchasingHelper
    {
        private readonly IUnitOfWork _uow;

        public PurchasingHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task DeletePurchasing(Guid purchId)
        {
            var entity = await _uow.Purchases.GetAsync(purchId);
            _uow.Purchases.Remove(entity);
            _uow.CompleteUOW();
        }

        public async Task<AddEditPurchasingViewModel> GetAddEditPurchasingViewModel(Guid purchId)
        {
            var model = new AddEditPurchasingViewModel();
            
            if(purchId != Guid.Empty)
            {
                model.Purchasing = await _uow.Purchases.GetAsync(w => w.PurchasingId == purchId);
            }

            var categories = await _uow.Categories.GetAllAsync();
            model.Categories = new List<SelectListItem>();

            foreach (var cat in categories)
            {
                var listitem = new SelectListItem();
                listitem.Text = cat.CategoryName;
                model.Categories.Add(listitem);
            }
            
            var product = await _uow.Products.GetAllAsync();
            model.Products = new List<SelectListItem>();

            foreach (var prod in product)
            {
                var listitem = new SelectListItem();
                listitem.Text = prod.ProductName;
                model.Products.Add(listitem);
            }

            var supplier = await _uow.Suppliers.GetAllAsync();
            model.Suppliers = new List<SelectListItem>();

            foreach (var sup in supplier)
            {
                var listitem = new SelectListItem();
                listitem.Text = sup.SupplierName;
                model.Suppliers.Add(listitem);
            }
            return model;
        }

        public async Task<IEnumerable<PurchasingEntity>> GetPurchasings(bool active)
        {
            return await _uow.Purchases.GetAllAsync();
        }

        public PurchasingViewModel GetPurchasingViewModel(string searchText, bool active)
        {
            var model = new PurchasingViewModel();
            model.SearchText = searchText ?? "";
            model.Purchasings = _uow.Purchases.GetAllAsync().Result.ToList();
            return model;
        }

        public async Task SavePurchasing(AddEditPurchasingViewModel model)
        {
            if (model.Purchasing.PurchasingId == Guid.Empty)
            {
                await _uow.Purchases.AddAsync(model.Purchasing);
            }
            else
            {
                _uow.Purchases.Update(model.Purchasing);
            }
            _uow.CompleteUOW();
        }
    }
}
