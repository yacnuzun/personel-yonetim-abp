using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PersonelYonetim.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class PersonelYonetimDbContextFactory : IDesignTimeDbContextFactory<PersonelYonetimDbContext>
{
    public PersonelYonetimDbContext CreateDbContext(string[] args)
    {
        PersonelYonetimEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<PersonelYonetimDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));

        return new PersonelYonetimDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PersonelYonetim.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
