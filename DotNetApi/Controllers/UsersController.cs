using DotNetApi.Data;
using DotNetApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DotNetApi.Controllers;

[Authorize]
// [Authorize] is active for all the class until add allowanonymous for specfic end point
// [AllowAnonymous] we can't use authorize for any end point if the class is  allowanonymous
public class UsersController : BasApiController
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;

    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<AppUser>>> getUsers() // api/Users
    {

        var Users = await _context.users.ToListAsync();

        return Users;

    }

    // [Authorize]
    // [AllowAnonymous]
    [HttpGet("{id}")]

    public async Task<ActionResult<AppUser>> Getuser(int id) // api/Users/1
    {

        var user = await _context.users.FindAsync(id);

        return user;

    }



}
