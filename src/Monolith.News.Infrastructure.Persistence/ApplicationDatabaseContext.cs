using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Monolith.News.Domain.Entities;
using Monolith.News.Infrastructure.Persistence.Settings;
using System.Reflection;

namespace Monolith.News.Infrastructure.Persistence
{
    public class ApplicationDatabaseContext : DbContext
    {
        public DbSet<Note>? Notes { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<NoteTag>? NoteTags { get; set; }

        private readonly DatabaseSettings settings;

        public ApplicationDatabaseContext(IOptions<DatabaseSettings> settings)
        {
            this.settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = settings?.ConnectionString ?? throw new ArgumentNullException(nameof(settings.ConnectionString));
            optionsBuilder
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
