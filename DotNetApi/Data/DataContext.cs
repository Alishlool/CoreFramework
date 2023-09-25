using DotNetApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<AppUser> users { get; set; }
}
