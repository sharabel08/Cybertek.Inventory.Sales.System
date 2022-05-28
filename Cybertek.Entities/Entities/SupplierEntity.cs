using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertek.Entities.Entities
{
    [Table("Supplier", Schema = "master")]
    public class SupplierEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid SupplierId { get; set; }

        [StringLength(100)]
        [Required]
        public string SupplierCode { get; set; }


        [StringLength(200)]
        [Required]
        public string SupplierName { get; set; }

        [StringLength(100)]
        [Required]
        public string Owner { get; set; }

        [StringLength(100)]
        [Required]
        public string ContactPerson { get; set; }

        [StringLength(100)]
        [Required]
        public string  ContactNumber { get; set; }

        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }

        [StringLength(200)]
        [Required]
        public string Address { get; set; }

        [StringLength(200)]
        [Required]
        public string  Notes { get; set; }
        
        [Required]
        public bool Active { get; set; }


    }
}
