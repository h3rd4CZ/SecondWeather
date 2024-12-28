using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeather.Data.Data
{
    public class DatabaseInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //var dbCreated = dbContext.Database.EnsureCreated();
            
            //foreach (var migration in dbContext.Database.GetPendingMigrations())
            //{
                try
                {
                    dbContext.Database.Migrate();
                }
                catch(Exception ex)
                {
                    LogMigrationFailed(ex, dbContext, default!);
                }
            //}
        }

        static void LogMigrationFailed(Exception ex, ApplicationDbContext db, string migration)
        {
            try
            {
                db.Logs.Add(new Model.Log { Date = DateTime.Now, Message = $"Could not apply migration : {migration} : {ex}" });
                db.SaveChanges();
            }
            catch { }
        }
    }
}
