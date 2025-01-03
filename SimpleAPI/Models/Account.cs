using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAPI.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("Name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Required]
    public int ContactId { get; set; }

    [ForeignKey("ContactId")]
    public Contact Contact { get; set; } = null!;

    public ICollection<Incident> Incidents { get; set; } = new List<Incident>();
}