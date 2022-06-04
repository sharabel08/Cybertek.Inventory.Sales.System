using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cybertek.Entities.Entities
{
    [Table("Purchasing", Schema = "data")]
    public class PurchasingEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid PurchasingId { get; set; }

        [StringLength(100)]
        [Required]
        public string DRNo { get; set; }

        [StringLength(100)]
        [Required]
        public string CategoryName { get; set; }
        
        [StringLength(100)]
        [Required]
        public string ProductName { get; set; }

        
        [Required]
        public DateTime DatePurchased { get; set; }

        [StringLength(100)]
        [Required]
        public string SupplierName { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Total { get; set; }
        [StringLength(200)]
        public string Notes { get; set; }
    }
}
