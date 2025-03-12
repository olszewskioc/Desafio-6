using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmacySystem.model
{
    [Table("medicines")]
    public class Medicine
    {
        [Column("id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Column("type")]
        [Required]
        public string Type { get; set; } = string.Empty;

        [Column("price")]
        [Required]
        public decimal Price { get; set; }

        [Column("expiration_date")]
        [Required]
        public DateTime? ExpirationDate { get; set;}

        // Relacionamento N:N
        [InverseProperty("Medicine")]
        public List<SupplierMedicine> SuppliersMedicines { get; set; } = new();
    }
}