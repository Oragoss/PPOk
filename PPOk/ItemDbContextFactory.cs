using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PPOk.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PPOk
{
    //https://stackoverflow.com/questions/45782446/unable-to-create-migrations-after-upgrading-to-asp-net-core-2-0
    public class ItemDbContextFactory : IDesignTimeDbContextFactory<ItemDbContext>
    {
        public ItemDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<ItemDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ItemDbContext(builder.Options);
        }
    }
}
