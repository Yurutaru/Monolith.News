using Autofac;
using Monolith.News.Core.Helpers;
using Monolith.News.Core.Helpers.Interfaces;

namespace Monolith.News.API.Modules
{
    public class HelperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>().InstancePerLifetimeScope();
        }
    }
}
