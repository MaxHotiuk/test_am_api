namespace SimpleAPI.DTOs;

public class ContactDto
{
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? AccountName { get; set; }
}