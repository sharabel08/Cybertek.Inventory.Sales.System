using Cybertek.Entities.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cybertek.MVC.Models
{
    public class AddEditSalesViewModel
    {
        public SalesEntity Sale { get; set; }

        public List<SelectListItem> Sales { get; set; }
    }
}
