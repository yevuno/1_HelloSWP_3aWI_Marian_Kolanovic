using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace SchoolManagement.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
    {
        public SchoolDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            var connectionString = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), "..", "SchoolManagement.API", "school.db")}";
            optionsBuilder.UseSqlite(connectionString);

            return new SchoolDbContext(optionsBuilder.Options);
        }
    }
}