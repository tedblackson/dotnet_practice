using FormulaOneApp.Data;
using FormulaOneApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneApp.Controllers;


[Route(template: "api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase



{

    private static ApiDbContext _context;

    public TeamsController(ApiDbContext context){
        _context = context;
    }
    

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var teams = await _context.Teams.ToListAsync();
        return Ok(teams);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

        if (team == null)
            return BadRequest(error: "invalid id");


       
        return Ok(team);
    }

    [HttpPost]

    public async Task<IActionResult> Post(Team team)

    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Get", team.Id, team);

    }

    [HttpPatch]
    public async Task<IActionResult> Patch(int id, string country)
    {

        var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

        if (team == null)
            return BadRequest(error: "Invalid Id");
        team.Country = country;
        await _context.SaveChangesAsync();
        return NoContent();

    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

        if (team == null)
            return BadRequest(error: "Invalid Id");
        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        return NoContent(); 
    }
   

    
   

 
    

}

