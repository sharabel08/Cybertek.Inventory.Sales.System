using Cybertek.Entities.Entities;
using System.Collections.Generic;

namespace Cybertek.MVC.Models
{
    public class PurchasingViewModel
    {
        public string SearchText { get; set; }
        public List<PurchasingEntity> Purchasings { get; set; }
    }
}
