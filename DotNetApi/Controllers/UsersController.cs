using DotNetApi.Data;
using DotNetApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DotNetApi.Controllers;

[ApiController]
[Route("api/[Controller]")]  //api/Users
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;

    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<AppUser>>> getUsers() // api/Users
    {

        var Users = await _context.users.ToListAsync();

        return Users;

    }

    [HttpGet("{id}")]

    public async Task<ActionResult<AppUser>> Getuser(int id) // api/Users/1
    {

        var user = await _context.users.FindAsync(id);

        return user;

    }



}
