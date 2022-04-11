using Autofac;
using Monolith.News.Core.Mappers;
using Monolith.News.Core.Mappers.Interfaces;

namespace Monolith.News.API.Modules
{
    public class MappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TagMapper>().As<ITagMapper>().InstancePerLifetimeScope();
            builder.RegisterType<NoteMapper>().As<INoteMapper>().InstancePerLifetimeScope();
            builder.RegisterType<NoteTagMapper>().As<INoteTagMapper>().InstancePerLifetimeScope();
        }
    }
}
