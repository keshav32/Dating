using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(DataContext dataContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUser(){
                 var users =  dataContext.Users.ToListAsync();
                 return Ok(users);
    }

    [HttpGet("{id}")]
    public async  Task<ActionResult<AppUser>> GetUser(int id){
                 var user =  dataContext.Users.FindAsync(id);

                 if(user == null) return NotFound();
                 return Ok(user);
    }

}