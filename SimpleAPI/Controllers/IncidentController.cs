using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Data;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.DTOs;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentController(IncidentDbContext context) : ControllerBase
{
    private readonly IncidentDbContext _context = context;

    [HttpPost("create")]
    public async Task<IActionResult> CreateIncident([FromBody] IncidentDto incident)
    {
        var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Name == incident.AccountName);
        if (existingAccount == null)
        {
            return NotFound("Account not found");
        }

        var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == incident.ContactEmail);
        if (existingContact != null)
        {
            existingContact.FirstName = incident.ContactFirstName;
            existingContact.LastName = incident.ContactLastName;
            existingContact.Account = existingAccount;
        }
        else
        {
            var newContact = new Contact
            {
                FirstName = incident.ContactFirstName,
                LastName = incident.ContactLastName,
                Email = incident.ContactEmail,
                Account = existingAccount
            };

            _context.Contacts.Add(newContact);
        }

        var newIncident = new Incident
        {
            Description = incident.Description
        };

        existingAccount.Incident = newIncident;

        _context.Incidents.Add(newIncident);
        await _context.SaveChangesAsync();

        return Ok($"Incident created successfully with name {newIncident.IncidentName}");
    }
}
