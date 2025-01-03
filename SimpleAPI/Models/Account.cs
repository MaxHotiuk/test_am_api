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

    public ICollection<Incident> Incidents { get; set; } = new List<Incident>();
    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}