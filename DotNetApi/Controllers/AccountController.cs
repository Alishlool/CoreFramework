using System.Security.Cryptography;
using System.Text;
using DotNetApi.Data;
using DotNetApi.DTOs;
using DotNetApi.Entities;
using DotNetApi.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetApi;
public class AccountController : BasApiController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExist(registerDto.UserName))

            return BadRequest("UserName is already taken");

        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            UserName = registerDto.UserName.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.PassWord)),
            PasswordSalt = hmac.Key
        };

        _context.users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };


    }


    
    [HttpPost("Login")]

    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {

        var user = await _context.users.FirstOrDefaultAsync(x => x.UserName == loginDto.username);
        if (user == null) return Unauthorized("Invalid UserName");

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.PassWord));

        for (int i = 0; i < ComputeHash.Length; i++)
        {
            if (ComputeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
        }

        return new UserDto
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };

    }
    public async Task<bool> UserExist(string username)
    {

        return await _context.users.AnyAsync(x => x.UserName == username.ToLower());
    }
}
