using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // http//:localhost:3000/api/users

public class UsersController : ControllerBase
{
    //private readonly DataContext context;
    private readonly DataContext _context;
    
    public UsersController(DataContext context)
    {
       // this.context = context;
       _context = context;
    }

    // Index
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }
    
    // Show
    [HttpGet("{id}")] //   api/users/1
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);;
    }
}