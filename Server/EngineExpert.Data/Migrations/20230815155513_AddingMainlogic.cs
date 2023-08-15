using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineExpert.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingMainlogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientCarId",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Repairs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "LastKilometers",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Repairs",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "ClientsCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "ClientsCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Kilometers",
                table: "ClientsCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cars",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CarTypeId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Cars",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "EngineTypeId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EuroStandard",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HorsePowers",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ShiftTypeId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarType",
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
                    table.PrimaryKey("PK_CarType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EngineType",
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
                    table.PrimaryKey("PK_EngineType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShiftType",
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
                    table.PrimaryKey("PK_ShiftType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ClientCarId",
                table: "Repairs",
                column: "ClientCarId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsCars_CarId",
                table: "ClientsCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsCars_ClientId",
                table: "ClientsCars",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarTypeId",
                table: "Cars",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineTypeId",
                table: "Cars",
                column: "EngineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ShiftTypeId",
                table: "Cars",
                column: "ShiftTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarType_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "CarType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_EngineType_EngineTypeId",
                table: "Cars",
                column: "EngineTypeId",
                principalTable: "EngineType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ShiftType_ShiftTypeId",
                table: "Cars",
                column: "ShiftTypeId",
                principalTable: "ShiftType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsCars_Cars_CarId",
                table: "ClientsCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsCars_Clients_ClientId",
                table: "ClientsCars",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_ClientsCars_ClientCarId",
                table: "Repairs",
                column: "ClientCarId",
                principalTable: "ClientsCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarType_CarTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_EngineType_EngineTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ShiftType_ShiftTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientsCars_Cars_CarId",
                table: "ClientsCars");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientsCars_Clients_ClientId",
                table: "ClientsCars");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_ClientsCars_ClientCarId",
                table: "Repairs");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropTable(
                name: "EngineType");

            migrationBuilder.DropTable(
                name: "ShiftType");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_ClientCarId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_ClientsCars_CarId",
                table: "ClientsCars");

            migrationBuilder.DropIndex(
                name: "IX_ClientsCars_ClientId",
                table: "ClientsCars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarTypeId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_EngineTypeId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ShiftTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ClientCarId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "LastKilometers",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "ClientsCars");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ClientsCars");

            migrationBuilder.DropColumn(
                name: "Kilometers",
                table: "ClientsCars");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EngineTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EuroStandard",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "HorsePowers",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ShiftTypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Cars");
        }
    }
}
