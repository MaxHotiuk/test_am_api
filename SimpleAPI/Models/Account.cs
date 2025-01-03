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
    [Column("IncidentName")]
    [ForeignKey("Incident")]
    [StringLength(255)]
    public string IncidentName { get; set; } = null!;

    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    public Incident Incident { get; set; } = null!;
}