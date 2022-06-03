using Cybertek.Entities.Entities;
using System.Collections.Generic;

namespace Cybertek.MVC.Models
{
    public class ProductViewModel
    {
        public string SearchText { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}
