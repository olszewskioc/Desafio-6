using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmacySystem.model
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("role")]
        [Required]
        public string Role { get; set; } = string.Empty;

        [Column("login")]
        [Required]
        public string Login { get; set; } = string.Empty;

        [Column("password")]
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}