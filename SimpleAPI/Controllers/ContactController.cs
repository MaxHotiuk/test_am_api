using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Data;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.DTOs;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController(IncidentDbContext context) : ControllerBase
{
    private readonly IncidentDbContext _context = context;

    [HttpPost("create")]
    public async Task<IActionResult> CreateContact([FromBody] ContactDto contact)
    {
        var newContact = new Contact
        {
            Email = contact.Email,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            AccountName = contact.AccountName
        };

        var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == newContact.Email);
        if (existingContact != null)
        {
            return BadRequest("Email already in use");
        }

        _context.Contacts.Add(newContact);
        await _context.SaveChangesAsync();

        return Ok("Contact created successfully");
    }
}