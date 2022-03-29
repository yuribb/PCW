using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCW.Data.SQLite.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EntireName = table.Column<string>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCardTag",
                columns: table => new
                {
                    PostCardId = table.Column<long>(type: "INTEGER", nullable: false),
                    TagId = table.Column<long>(type: "INTEGER", nullable: false),
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    PostCardId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCardTag", x => new { x.PostCardId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostCardTag_PostCards_PostCardId1",
                        column: x => x.PostCardId1,
                        principalTable: "PostCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostCardTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCardTag_PostCardId1",
                table: "PostCardTag",
                column: "PostCardId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostCardTag_TagId",
                table: "PostCardTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCardTag");

            migrationBuilder.DropTable(
                name: "PostCards");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
