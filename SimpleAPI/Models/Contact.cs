using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Models;

[Table("Contacts")]
[Index(nameof(Email), IsUnique = true)]
public class Contact
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [Column("FirstName")]
    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column("LastName")]
    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [Required]
    [Column("Email")]
    [StringLength(200)]
    public string Email { get; set; } = null!;

    [Column("AccountName")]
    [StringLength(200)]
    public string? AccountName { get; set; } = null!;

    [ForeignKey("AccountName")]
    public Account Account { get; set; } = null!;
}
