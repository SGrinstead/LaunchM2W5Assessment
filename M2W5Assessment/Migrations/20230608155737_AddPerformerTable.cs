using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace M2W5Assessment.Migrations
{
    public partial class AddPerformerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "performers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_performers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "concert_performer",
                columns: table => new
                {
                    concerts_id = table.Column<int>(type: "integer", nullable: false),
                    performers_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_concert_performer", x => new { x.concerts_id, x.performers_id });
                    table.ForeignKey(
                        name: "fk_concert_performer_concerts_concerts_id",
                        column: x => x.concerts_id,
                        principalTable: "concerts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_concert_performer_performers_performers_id",
                        column: x => x.performers_id,
                        principalTable: "performers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_concert_performer_performers_id",
                table: "concert_performer",
                column: "performers_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "concert_performer");

            migrationBuilder.DropTable(
                name: "performers");
        }
    }
}
