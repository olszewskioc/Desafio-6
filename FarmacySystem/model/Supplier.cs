using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmacySystem.model
{
    [Table("suppliers")]
    public class Supplier
    {
        [Column("id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("cnpj")]
        [Required]
        public string Cnpj { get; set; } = string.Empty;

        [Column("phone")]
        [Required]
        public string Phone { get; set; } = string.Empty;

        [Column("zip_code")]
        [Required]
        public string ZipCode { get; set; } = string.Empty;

        [Column("number")]  // Addres number
        [Required]
        public int Number { get; set; }

        // Relacionamento N:N
        [InverseProperty("Supplier")]
        public List<SupplierMedicine> SupplierMedicines { get; set; } = new();
        
    }
}