﻿using Monolith.News.Infrastructure.Persistence.Infrastructure.Interfaces;

namespace Monolith.News.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var migrationApplier = scope.ServiceProvider.GetRequiredService<IDatabaseMigrationApplier>();
                migrationApplier.ApplyMigrations();
            }
        }
    }
}
