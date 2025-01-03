using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Data;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.DTOs;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IncidentDbContext context) : ControllerBase
{
    private readonly IncidentDbContext _context = context;

    [HttpPost("create")]
    public async Task<IActionResult> CreateAccount([FromBody] AccountDto account)
    {
        var newAccount = new Account
        {
            Name = account.Name
        };

        var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Name == newAccount.Name);
        if (existingAccount != null)
        {
            return BadRequest("Account already exists");
        }

        var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == account.ContactEmail);
        if (existingContact == null)
        {
            return NotFound("Contact not found");
        }

        _context.Accounts.Add(newAccount);
        await _context.SaveChangesAsync();

        return Ok("Account created successfully");
    }
}