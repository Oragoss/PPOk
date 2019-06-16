using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PPOkNoJavascript.Data;
using System;
using System.Linq;

namespace PPOkNoJavascript.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Items.Any())
                {
                    return;   // DB has been seeded
                }

                context.Items.AddRange(
                    new Item
                    {
                        Amount = 12.00m,
                        Type = "Deposit",
                        TransactionDate = DateTime.Parse("2017-2-12"),
                    },

                    new Item
                    {
                        Amount = -7.00m,
                        Type = "Fee",
                        TransactionDate = DateTime.Parse("2017-2-11"),
                    },

                    new Item
                    {
                        Amount = 85.00m,
                        Type = "Deposit",
                        TransactionDate = DateTime.Parse("2017-2-02"),
                    },

                   new Item
                   {
                       Amount = -3.00m,
                       Type = "Expense",
                       TransactionDate = DateTime.Parse("2017-8-12"),
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
