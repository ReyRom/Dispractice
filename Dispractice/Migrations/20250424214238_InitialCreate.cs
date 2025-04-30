using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dispractice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: true),
                    ParentUnitId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Units_ParentUnitId",
                        column: x => x.ParentUnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: true),
                    UnitId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicemans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Patronomic = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Rank = table.Column<string>(type: "TEXT", nullable: false),
                    IsNaval = table.Column<bool>(type: "INTEGER", nullable: false),
                    PositionId = table.Column<int>(type: "INTEGER", nullable: true),
                    ServiceStartYear = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicemans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicemans_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Commendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServicemanId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DateAwarded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AwardedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commendations_Servicemans_ServicemanId",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penalties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServicemanId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    OffenseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateApplied = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateExecuted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AppliedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CommendationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalties_Commendations_CommendationId",
                        column: x => x.CommendationId,
                        principalTable: "Commendations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Penalties_Servicemans_ServicemanId",
                        column: x => x.ServicemanId,
                        principalTable: "Servicemans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name", "ParentUnitId", "ShortName" },
                values: new object[] { 1, "Воинская часть", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Commendations_ServicemanId",
                table: "Commendations",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_CommendationId",
                table: "Penalties",
                column: "CommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_ServicemanId",
                table: "Penalties",
                column: "ServicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_UnitId",
                table: "Positions",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicemans_PositionId",
                table: "Servicemans",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_ParentUnitId",
                table: "Units",
                column: "ParentUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Penalties");

            migrationBuilder.DropTable(
                name: "Commendations");

            migrationBuilder.DropTable(
                name: "Servicemans");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
