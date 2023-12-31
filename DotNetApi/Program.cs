using System.Text;
using DotNetApi.Data;
using DotNetApi.Extensions;
using DotNetApi.interfaces;
using DotNetApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddDbContext<DataContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddCors();
// builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {

//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),  // Ensure correct encoding
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };
//     });
var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
