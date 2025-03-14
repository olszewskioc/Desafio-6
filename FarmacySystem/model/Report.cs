using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmacySystem.model
{
    [Table("reports")]
    public class Report
    {
        [Column("id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("description")]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set;}

        [Column("user_id")]
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set;}

        public User? User { get; set; }
    }
}