namespace SimpleAPI.DTOs;

public class IncidentDto
{
    public required string AccountName { get; set; }
    public required string ContactFirstName { get; set; }
    public required string ContactLastName { get; set; }
    public required string ContactEmail { get; set; }
    public required string Description { get; set; }
}