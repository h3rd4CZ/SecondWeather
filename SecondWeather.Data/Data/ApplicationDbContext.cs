using Microsoft.EntityFrameworkCore;
using SecondWeather.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeather.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public static string? appDataDirPath;
        public DbSet<UserSettings> UserSettings { get; set; } = default!;
        public DbSet<Log> Logs { get; set; } = default!;
        public ApplicationDbContext() : base(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite().Options) { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ArgumentNullException.ThrowIfNull(appDataDirPath, nameof(appDataDirPath));
                string dbPath = Path.Combine(appDataDirPath, DataConstants.DbFileName);
                optionsBuilder.UseSqlite($"Filename={dbPath}");
            }

        }
    }
}
