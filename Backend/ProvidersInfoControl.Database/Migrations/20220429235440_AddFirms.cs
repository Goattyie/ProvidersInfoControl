using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProvidersInfoControl.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddFirms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirmId",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Telephone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    StartWorkingYear = table.Column<short>(type: "smallint", nullable: false),
                    OwnTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firms_OwnTypes_OwnTypeId",
                        column: x => x.OwnTypeId,
                        principalTable: "OwnTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_FirmId",
                table: "Services",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_OwnTypeId",
                table: "Firms",
                column: "OwnTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Firms_FirmId",
                table: "Services",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Firms_FirmId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.DropIndex(
                name: "IX_Services_FirmId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FirmId",
                table: "Services");
        }
    }
}
