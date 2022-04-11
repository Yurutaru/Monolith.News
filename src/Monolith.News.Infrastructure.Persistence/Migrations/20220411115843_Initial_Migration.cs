using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Monolith.News.Infrastructure.Persistence.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_note", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    BackgroundColor = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Color = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TNoteTag",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "integer", nullable: false),
                    note_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_t_note_tag", x => new { x.note_id, x.tag_id });
                    table.ForeignKey(
                        name: "fk_t_note_tag_t_note_note_id",
                        column: x => x.note_id,
                        principalTable: "TNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_t_note_tag_t_tag_tag_id",
                        column: x => x.tag_id,
                        principalTable: "TTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_t_note_tag_tag_id",
                table: "TNoteTag",
                column: "tag_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TNoteTag");

            migrationBuilder.DropTable(
                name: "TNote");

            migrationBuilder.DropTable(
                name: "TTag");
        }
    }
}
