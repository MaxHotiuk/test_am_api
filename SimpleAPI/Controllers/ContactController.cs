using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IncidentDbContext _context;

    public ContactController(IncidentDbContext context)
    {
        _context = context;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateContact([FromBody] Contact contact)
    {
        if (string.IsNullOrEmpty(contact.Email))
        {
            return BadRequest("Contact email is required.");
        }

        var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == contact.Email);
        if (existingContact != null)
        {
            return Conflict("Contact already exists.");
        }

        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Contact created successfully." });
    }
}