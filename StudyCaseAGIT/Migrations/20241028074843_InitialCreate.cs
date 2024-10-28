using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyCaseAGIT.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monday = table.Column<int>(type: "int", nullable: false),
                    Tuesday = table.Column<int>(type: "int", nullable: false),
                    Wednesday = table.Column<int>(type: "int", nullable: false),
                    Thursday = table.Column<int>(type: "int", nullable: false),
                    Friday = table.Column<int>(type: "int", nullable: false),
                    PlanDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionAdjustments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionPlanId = table.Column<int>(type: "int", nullable: false),
                    Monday = table.Column<int>(type: "int", nullable: false),
                    Tuesday = table.Column<int>(type: "int", nullable: false),
                    Wednesday = table.Column<int>(type: "int", nullable: false),
                    Thursday = table.Column<int>(type: "int", nullable: false),
                    Friday = table.Column<int>(type: "int", nullable: false),
                    AdjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionAdjustments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionAdjustments_ProductionPlans_ProductionPlanId",
                        column: x => x.ProductionPlanId,
                        principalTable: "ProductionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionAdjustments_ProductionPlanId",
                table: "ProductionAdjustments",
                column: "ProductionPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionAdjustments");

            migrationBuilder.DropTable(
                name: "ProductionPlans");
        }
    }
}
