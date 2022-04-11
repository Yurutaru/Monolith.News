using Autofac;
using Microsoft.EntityFrameworkCore;
using Monolith.News.Domain.Entities.Interfaces;
using Monolith.News.Domain.Interfaces;
using Monolith.News.Infrastructure.Persistence;
using Monolith.News.Infrastructure.Persistence.Infrastructure;
using Monolith.News.Infrastructure.Persistence.Infrastructure.Interfaces;
using Monolith.News.Persistence.Repositories;

namespace Monolith.News.API.Modules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EntityFrameworkRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDatabaseContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseMigrationApplier>().As<IDatabaseMigrationApplier>().InstancePerLifetimeScope();
        }
    }
}
