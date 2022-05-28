using Cybertek.Entities.Entities;
using System.Collections.Generic;

namespace Cybertek.MVC.Models
{
    public class CategoryViewModel
    {
        public string SearchText { get; set; }
        public List<CategoryEntity> Categories { get; set; }
    }
}
