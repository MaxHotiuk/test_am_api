using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SimpleAPI.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("Name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Column("IncidentName")]
    [StringLength(255)]
    public string? IncidentName { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("IncidentName")]
    public Incident? Incident { get; set; }

    public ICollection<Contact> Contacts { get; set; } = [];
}