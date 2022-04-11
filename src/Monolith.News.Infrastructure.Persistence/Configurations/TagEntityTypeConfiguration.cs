using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monolith.News.Domain.Entities;

namespace Monolith.News.Infrastructure.Persistence.Configurations
{
    public class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("TTag");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("Id");

            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(256);

            builder.Property(t => t.BackgroundColor)
               .HasColumnName("BackgroundColor")
               .HasMaxLength(256);

            builder.Property(t => t.Color)
                .HasColumnName("Color")
                .HasMaxLength(256);

            builder.HasMany(p => p.Notes)
                .WithMany(p => p.Tags)
                .UsingEntity<NoteTag>(
                j => j
                    .HasOne<Note>(pt => pt.Note)
                    .WithMany(t => t.NoteTags)
                    .HasForeignKey(pt => pt.NoteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(),
                j => j
                    .HasOne<Tag>(pt => pt.Tag)
                    .WithMany(p => p.NoteTags)
                    .HasForeignKey(pt => pt.TagId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired(),
                j =>
                {
                    j.ToTable("TNoteTag");
                    j.HasKey(t => new { t.NoteId, t.TagId });
                    j.Property(pt => pt.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                }) ;
        }
    }
}
