using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SimpleAPI.Models;

[Table("Incidents")]
public class Incident
{
    [Key]
    [Column("IncidentName")]
    [StringLength(255)]
    public string IncidentName { get; set; } = null!;

    [Required]
    [Column("Description")]
    public string Description { get; set; } = null!;

    [Required]
    [StringLength(200)]
    public string AccountName { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("AccountName")]
    public Account Account { get; set; } = null!;
}