using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cybertek.Entities.Entities
{
    [Table("Category", Schema = "master")]
    public class CategoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid CategoryId { get; set; }

        [StringLength(50)]
        [Required]
        public string CategoryCode { get; set; }

        [StringLength(100)]
        [Required]
        public string CategoryName { get; set; }

        [StringLength(200)]
        [Required]
        public string Description { get; set; }
        
        [Required]
        public bool Active { get; set; }

    }
}
