using Dispractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Dispractice;

public class MilitaryServiceContextFactory : IDesignTimeDbContextFactory<MilitaryServiceContext>
{
    public MilitaryServiceContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<MilitaryServiceContext>();
        optionsBuilder.UseSqlite(configuration["ConnectionStrings:DefaultConnection"]);

        return new MilitaryServiceContext(optionsBuilder.Options);
    }
}