using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cybertek.Entities.Entities
{
    [Table("Product", Schema = "master")]
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid ProductId { get; set; }

        [StringLength(100)]
        [Required]
        public string ProductName { get; set; }
        
        [StringLength(100)]
        [Required]
        public string CategoryName { get; set; }

        [StringLength(100)]
        [Required]
        public string  Type { get; set; }

        [StringLength(100)]
        [Required]
        public string  Brand { get; set; }

        [StringLength(200)]
        [Required]
        public string Description { get; set; }

        [StringLength(100)]
        [Required]
        public string  Condition { get; set; }
        
        [Required]
        public bool Active { get; set; }




    }
}
