using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    //1. Why we dont use constructor via dependency injection? - because it is static class
    //2. Why we use dbContext instead of repository? - because we use this class to generate migrations to sql server database, it is much easier this way
    public static class PrepDb
    {
        //This constructor is called in Startup class?
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                     new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                      new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already habe data");
            }
        }
    }
}