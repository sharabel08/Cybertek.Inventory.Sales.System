using Cybertek.Entities.Entities;
using System.Collections.Generic;

namespace Cybertek.MVC.Models
{
    public class SupplierViewModel
    {
        public string SearchText { get; set; }
        public List<SupplierEntity> Suppliers { get; set; }
    }
}
