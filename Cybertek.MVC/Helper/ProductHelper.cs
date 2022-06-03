﻿using Cybertek.Entities.Entities;
using Cybertek.Entities.UnitOfWork;
using Cybertek.MVC.Helper.Interfaces;
using Cybertek.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertek.MVC.Helper
{
    public class ProductHelper : IProductHelper
    {
        private readonly UnitOfWork _uow;

        public ProductHelper(UnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task DeleteProduct(Guid prodId)
        {
            var entity = await _uow.Products.GetAsync(prodId);
            _uow.Products.Remove(entity);
            _uow.CompleteUOW();
        }

        public async Task<AddEditProductViewModel> GetAddEditProductViewModel(Guid prodId)
        {
            var model = new AddEditProductViewModel();
            model.Product = await _uow.Products.GetAsync(w => w.ProductId == prodId);
            return model;
        }

        public async Task<IEnumerable<ProductEntity>> GetProducts(bool active)
        {
            return await _uow.Products.GetAllAsync(w => w.Active == active);
        }

        public ProductViewModel GetProductViewModel(string searchText, bool active)
        {
            var model = new ProductViewModel();
            model.SearchText = searchText ?? "";
            model.Products = _uow.Products.GetAllAsync(w => w.Active == active && w.ProductName
            .Contains(model.SearchText)).Result.ToList();
            return model;
        }

        public async Task SaveProduct(AddEditProductViewModel model)
        {
            if (model.Product.ProductId == Guid.Empty)
            {
                await _uow.Products.AddAsync(model.Product);
            }
            else
            {
                _uow.Products.Update(model.Product);
            }
            _uow.CompleteUOW();
        }
    }
}
