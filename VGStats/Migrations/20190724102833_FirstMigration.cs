using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VGStats.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataRevision = table.Column<int>(nullable: false),
                    StationName = table.Column<string>(nullable: false),
                    MapName = table.Column<string>(nullable: false),
                    CrewScore = table.Column<int>(nullable: false),
                    SurvivingHeads = table.Column<int>(nullable: false),
                    SurvivingBorgs = table.Column<int>(nullable: false),
                    Nuked = table.Column<bool>(nullable: false),
                    CratesOrdered = table.Column<int>(nullable: false),
                    BloodSpilled = table.Column<int>(nullable: false),
                    ArtifactsDiscovered = table.Column<int>(nullable: false),
                    TechTotal = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BadassBundles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    MindName = table.Column<string>(nullable: true),
                    MindKey = table.Column<string>(nullable: true),
                    BuyerRoleType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadassBundles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BadassBundles_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deaths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    MindKey = table.Column<string>(nullable: true),
                    MindName = table.Column<string>(nullable: true),
                    TypePath = table.Column<string>(nullable: true),
                    SpecialRole = table.Column<string>(nullable: true),
                    AssignedRole = table.Column<string>(nullable: true),
                    From_Suicide = table.Column<bool>(nullable: false),
                    DeathLocation_X = table.Column<int>(nullable: false),
                    DeathLocation_Y = table.Column<int>(nullable: false),
                    DeathLocation_Z = table.Column<int>(nullable: false),
                    Damage_DamageBrute = table.Column<int>(nullable: false),
                    Damage_DamageFire = table.Column<int>(nullable: false),
                    Damage_DamageToxin = table.Column<int>(nullable: false),
                    Damage_DamageOxygen = table.Column<int>(nullable: false),
                    Damage_DamageClone = table.Column<int>(nullable: false),
                    Damage_DamageBrain = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deaths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deaths_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Explosions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    Epicenter_X = table.Column<int>(nullable: false),
                    Epicenter_Y = table.Column<int>(nullable: false),
                    Epicenter_Z = table.Column<int>(nullable: false),
                    LightImpactRange = table.Column<int>(nullable: false),
                    HeavyImpactRange = table.Column<int>(nullable: false),
                    DevestationRange = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explosions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Explosions_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MatchId = table.Column<int>(nullable: false),
                    FactionName = table.Column<string>(nullable: false),
                    FactionType = table.Column<string>(nullable: false),
                    Won = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => new { x.Id, x.MatchId });
                    table.ForeignKey(
                        name: "FK_Factions_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MalfModules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    ModuleBuyerKey = table.Column<string>(nullable: true),
                    ModuleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MalfModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MalfModules_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PopulationSnapshots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    PopCount = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationSnapshots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PopulationSnapshots_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survivors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    MindName = table.Column<string>(nullable: false),
                    MindKey = table.Column<string>(nullable: false),
                    MobTypepath = table.Column<string>(nullable: false),
                    Damage_DamageBrute = table.Column<int>(nullable: false),
                    Damage_DamageFire = table.Column<int>(nullable: false),
                    Damage_DamageToxin = table.Column<int>(nullable: false),
                    Damage_DamageOxygen = table.Column<int>(nullable: false),
                    Damage_DamageClone = table.Column<int>(nullable: false),
                    Damage_DamageBrain = table.Column<int>(nullable: false),
                    Location_X = table.Column<int>(nullable: false),
                    Location_Y = table.Column<int>(nullable: false),
                    Location_Z = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survivors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survivors_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UplinkBuys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    MindName = table.Column<string>(nullable: true),
                    MindKey = table.Column<string>(nullable: true),
                    BuyerRole = table.Column<string>(nullable: true),
                    BundlePath = table.Column<string>(nullable: true),
                    ItemPath = table.Column<string>(nullable: true),
                    ItemCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UplinkBuys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UplinkBuys_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BadassBundleItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BadassBundleId = table.Column<int>(nullable: false),
                    ItemPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadassBundleItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BadassBundleItem_BadassBundles_BadassBundleId",
                        column: x => x.BadassBundleId,
                        principalTable: "BadassBundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    MatchRoleId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false),
                    FactionId = table.Column<string>(nullable: false),
                    FactionId1 = table.Column<string>(nullable: true),
                    FactionMatchId = table.Column<int>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    MindName = table.Column<string>(nullable: true),
                    MindKey = table.Column<string>(nullable: true),
                    Won = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => new { x.MatchRoleId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_Roles_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roles_Factions_FactionId1_FactionMatchId",
                        columns: x => new { x.FactionId1, x.FactionMatchId },
                        principalTable: "Factions",
                        principalColumns: new[] { "Id", "MatchId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false),
                    RoleMatchRoleId = table.Column<int>(nullable: true),
                    RoleMatchId = table.Column<int>(nullable: true),
                    ObjectiveType = table.Column<string>(nullable: false),
                    ObjectiveDescription = table.Column<string>(nullable: false),
                    ObjectiveSuccessful = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => new { x.Id, x.MatchId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Objectives_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objectives_Roles_RoleMatchRoleId_RoleMatchId",
                        columns: x => new { x.RoleMatchRoleId, x.RoleMatchId },
                        principalTable: "Roles",
                        principalColumns: new[] { "MatchRoleId", "MatchId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BadassBundleItem_BadassBundleId",
                table: "BadassBundleItem",
                column: "BadassBundleId");

            migrationBuilder.CreateIndex(
                name: "IX_BadassBundles_MatchId",
                table: "BadassBundles",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Deaths_MatchId",
                table: "Deaths",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Explosions_MatchId",
                table: "Explosions",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_MatchId",
                table: "Factions",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MalfModules_MatchId",
                table: "MalfModules",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_MatchId",
                table: "Objectives",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_RoleMatchRoleId_RoleMatchId",
                table: "Objectives",
                columns: new[] { "RoleMatchRoleId", "RoleMatchId" });

            migrationBuilder.CreateIndex(
                name: "IX_PopulationSnapshots_MatchId",
                table: "PopulationSnapshots",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_MatchId",
                table: "Roles",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_FactionId1_FactionMatchId",
                table: "Roles",
                columns: new[] { "FactionId1", "FactionMatchId" });

            migrationBuilder.CreateIndex(
                name: "IX_Survivors_MatchId",
                table: "Survivors",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_UplinkBuys_MatchId",
                table: "UplinkBuys",
                column: "MatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BadassBundleItem");

            migrationBuilder.DropTable(
                name: "Deaths");

            migrationBuilder.DropTable(
                name: "Explosions");

            migrationBuilder.DropTable(
                name: "MalfModules");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "PopulationSnapshots");

            migrationBuilder.DropTable(
                name: "Survivors");

            migrationBuilder.DropTable(
                name: "UplinkBuys");

            migrationBuilder.DropTable(
                name: "BadassBundles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
