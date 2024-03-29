﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monolith.News.Infrastructure.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Monolith.News.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    [Migration("20220411115843_Initial_Migration")]
    partial class Initial_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Monolith.News.Domain.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .HasColumnType("text")
                        .HasColumnName("Body");

                    b.Property<string>("Subject")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Subject");

                    b.HasKey("Id")
                        .HasName("pk_t_note");

                    b.ToTable("TNote", (string)null);
                });

            modelBuilder.Entity("Monolith.News.Domain.Entities.NoteTag", b =>
                {
                    b.Property<int>("NoteId")
                        .HasColumnType("integer")
                        .HasColumnName("note_id");

                    b.Property<int>("TagId")
                        .HasColumnType("integer")
                        .HasColumnName("tag_id");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.HasKey("NoteId", "TagId")
                        .HasName("pk_t_note_tag");

                    b.HasIndex("TagId")
                        .HasDatabaseName("ix_t_note_tag_tag_id");

                    b.ToTable("TNoteTag", (string)null);
                });

            modelBuilder.Entity("Monolith.News.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundColor")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("BackgroundColor");

                    b.Property<string>("Color")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Color");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("pk_t_tag");

                    b.ToTable("TTag", (string)null);
                });

            modelBuilder.Entity("Monolith.News.Domain.Entities.NoteTag", b =>
                {
                    b.HasOne("Monolith.News.Domain.Entities.Note", "Note")
                        .WithMany("NoteTags")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_t_note_tag_t_note_note_id");

                    b.HasOne("Monolith.News.Domain.Entities.Tag", "Tag")
                        .WithMany("NoteTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_t_note_tag_t_tag_tag_id");

                    b.Navigation("Note");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Monolith.News.Domain.Entities.Note", b =>
                {
                    b.Navigation("NoteTags");
                });

            modelBuilder.Entity("Monolith.News.Domain.Entities.Tag", b =>
                {
                    b.Navigation("NoteTags");
                });
#pragma warning restore 612, 618
        }
    }
}
