using Cybertek.Entities.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cybertek.MVC.Models
{
    public class AddEditPurchasingViewModel
    {
        public PurchasingEntity Purchasing { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Products { get; set; }
        public List<SelectListItem> Suppliers { get; set; }

    }
}
