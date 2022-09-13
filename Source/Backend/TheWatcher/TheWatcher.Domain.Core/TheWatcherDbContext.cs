using Microsoft.EntityFrameworkCore;
using TheWatcher.Domain.Core.Configurations;
using TheWatcher.Domain.Core.Models;
using Environment = TheWatcher.Domain.Core.Models.Environment;

namespace TheWatcher.Domain.Core
{
    public class TheWatcherDbContext : DbContext
    {
        public TheWatcherDbContext(DbContextOptions<TheWatcherDbContext> options)
            : base(options)
        {
        }

        public DbSet<Watcher> Watcher { get; set; }

        public DbSet<WatcherParameter> WatcherParameter { get; set; }

        public DbSet<ResourceCategory> ResourceCategory { get; set; }

        public DbSet<Resource> Resource { get; set; }

        public DbSet<Environment> Environment { get; set; }

        public DbSet<ResourceWatch> ResourceWatch { get; set; }

        public DbSet<ResourceWatchParameter> ResourceWatchParameter { get; set; }

        public DbSet<ResourceWatchLog> ResourceWatchLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations for tables

            // Schema 'dbo'
            modelBuilder
                .ApplyConfiguration(new WatcherConfiguration())
                .ApplyConfiguration(new WatcherParameterConfiguration())
                .ApplyConfiguration(new ResourceCategoryConfiguration())
                .ApplyConfiguration(new ResourceConfiguration())
                .ApplyConfiguration(new EnvironmentConfiguration())
                .ApplyConfiguration(new ResourceWatchConfiguration())
                .ApplyConfiguration(new ResourceWatchParameterConfiguration())
                .ApplyConfiguration(new ResourceWatchLogConfiguration())
            ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
