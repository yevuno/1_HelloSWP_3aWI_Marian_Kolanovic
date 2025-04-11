using Microsoft.EntityFrameworkCore;
using _01_MyFirstWebApplication.Models;

namespace _01_MyFirstWebApplication.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Schularbeit> Schularbeiten { get; set; }
}