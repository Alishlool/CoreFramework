using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetApi.Data;
using DotNetApi.interfaces;
using DotNetApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services, IConfiguration config)
        {
            Services.AddDbContext<DataContext>(item => item.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            Services.AddCors();
            Services.AddScoped<ITokenService, TokenService>();
            return Services;
        }
    }
}