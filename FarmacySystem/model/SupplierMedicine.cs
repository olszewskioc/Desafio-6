using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmacySystem.model
{
    [Table("suppliers_medicines")]
    public class SupplierMedicine
    {
        [Column("id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("supplier_id")]
        [Required]
        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }

        [Column("mediciner_id")]
        [Required]
        [ForeignKey(nameof(Medicine))]
        public int MedicineId { get; set; }

        public Supplier? Supplier { get; set; }
        public Medicine? Medicine { get; set; }
    }
}