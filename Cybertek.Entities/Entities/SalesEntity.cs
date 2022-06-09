﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cybertek.Entities.Entities
{
    [Table("Sales", Schema = "data")]
    public class SalesEntity
    {      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid SalesId { get; set; }

        [StringLength(100)]
        [Required]
        public string  CustomerName { get; set; }

        [StringLength(100)]
        [Required]
        public string  CategoryName { get; set; }

        [StringLength(100)]
        [Required]
        public string  ProductName { get; set; }

        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
