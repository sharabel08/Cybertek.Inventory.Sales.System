﻿using Cybertek.Entities.Entities;
using System.Collections.Generic;

namespace Cybertek.MVC.Models
{
    public class SalesViewModel
    {
        public string SearchText { get; set; }
        public List<SalesEntity> Sales { get; set; }
    }
}
