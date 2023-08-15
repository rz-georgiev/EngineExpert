using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineExpert.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendingCarModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilometers",
                table: "ClientsCars");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Repairs",
                newName: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "RepairTypeId",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RepairType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedByUserId = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastUpdatedByUserId = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_RepairTypeId",
                table: "Repairs",
                column: "RepairTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_RepairType_RepairTypeId",
                table: "Repairs",
                column: "RepairTypeId",
                principalTable: "RepairType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_RepairType_RepairTypeId",
                table: "Repairs");

            migrationBuilder.DropTable(
                name: "RepairType");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_RepairTypeId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "RepairTypeId",
                table: "Repairs");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Repairs",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Kilometers",
                table: "ClientsCars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
