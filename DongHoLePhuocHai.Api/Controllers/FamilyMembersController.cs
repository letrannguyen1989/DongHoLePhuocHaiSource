using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DongHoLePhuocHai.Api.Data;
using DongHoLePhuocHai.Api.Models;
using DongHoLePhuocHai.Models;

namespace DongHoLePhuocHai.Api.Controllers;

[ApiController]
[Route("api/family/[controller]")]
public class MembersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MembersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/family/members
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FamilyMemberDto>>> GetMembers()
    {
        var members = await _context.FamilyMembers
                .Include(m => m.Parent)
                .Select(m => new FamilyMemberDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    BirthYear = m.BirthYear,
                    DeathYear = m.DeathYear,
                    IsAlive = m.IsAlive,
                    Gender = m.Gender,
                    ParentId = m.ParentId,
                    ParentName = m.Parent == null ? null : m.Parent.Name,
                    Generation = m.Generation
                })
                .ToListAsync();

        return Ok(members);
    }

    // GET: api/family/members/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FamilyMember>> GetMember(int id)
    {
        var member = await _context.FamilyMembers
            .Include(m => m.Parent)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (member == null)
        {
            return NotFound();
        }

        return member;
    }

    // POST: api/family/members
    [HttpPost]
    public async Task<ActionResult<FamilyMember>> CreateMember(FamilyMember member)
    {
        _context.FamilyMembers.Add(member);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMember), new { id = member.Id }, member);
    }

    // PUT: api/family/members/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMember(int id, FamilyMember member)
    {
        if (id != member.Id)
        {
            return BadRequest();
        }

        _context.Entry(member).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MemberExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/family/members/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMember(int id)
    {
        var member = await _context.FamilyMembers.FindAsync(id);
        if (member == null)
        {
            return NotFound();
        }

        _context.FamilyMembers.Remove(member);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MemberExists(int id)
    {
        return _context.FamilyMembers.Any(e => e.Id == id);
    }
} 