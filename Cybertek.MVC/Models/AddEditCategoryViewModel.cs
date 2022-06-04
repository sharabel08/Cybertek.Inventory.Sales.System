using Cybertek.Entities.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cybertek.MVC.Models
{
    public class AddEditCategoryViewModel
    {
        public CategoryEntity Category { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
