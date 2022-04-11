using Autofac;
using Monolith.News.Core.Services;
using Monolith.News.Core.Services.Interfaces;

namespace Monolith.News.API.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NoteService>().As<INoteService>().InstancePerLifetimeScope();
            builder.RegisterType<TagService>().As<ITagService>().InstancePerLifetimeScope();
            builder.RegisterType<NoteTagService>().As<INoteTagService>().InstancePerLifetimeScope();
        }
    }
}
