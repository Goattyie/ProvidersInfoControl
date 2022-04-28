using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProvidersInfoControl.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAbonents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: false),
                    AbonentTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonents_AbonentTypes_AbonentTypeId",
                        column: x => x.AbonentTypeId,
                        principalTable: "AbonentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonents_AbonentTypeId",
                table: "Abonents",
                column: "AbonentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Abonents_Address",
                table: "Abonents",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Abonents_Email",
                table: "Abonents",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonents");
        }
    }
}
