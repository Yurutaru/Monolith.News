using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.News.Domain.Entities;

namespace Monolith.News.Infrastructure.Persistence.Configurations
{
    public class NoteEntityTypeConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("TNote");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("Id");

            builder.Property(t => t.Subject)
                .HasColumnName("Subject")
                .HasMaxLength(256);

            builder.Property(t => t.Body)
                .HasColumnName("Body");
        }
    }
}
