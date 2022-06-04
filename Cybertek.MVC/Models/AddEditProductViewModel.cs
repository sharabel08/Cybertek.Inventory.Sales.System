using Cybertek.Entities.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cybertek.MVC.Models
{
    public class AddEditProductViewModel
    {
        public ProductEntity Product { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
