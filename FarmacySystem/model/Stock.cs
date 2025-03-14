using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmacySystem.model
{
    [Table("stocks")]
    public class Stock
    {
        [Column("id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("quantity")]
        [Required]
        public int Quantity { get; set; }

        [Column("updated_at")]
        [Required]
        public DateTime? UpdatedAt { get; set;}

        [Column("medicine_id")]
        [Required]
        [ForeignKey(nameof(Medicine))]
        public int MedicineId { get; set; }

        // Relacionamento N:N
        [InverseProperty("Stock")]
        public List<SaleMedicine> SalesStocks { get; set; } = new();

        public Medicine? Medicine { get; set; }
    }
}