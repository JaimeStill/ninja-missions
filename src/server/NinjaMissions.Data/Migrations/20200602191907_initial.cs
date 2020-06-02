using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaMissions.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ninja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NinjaSkill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NinjaId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NinjaSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NinjaSkill_Ninja_NinjaId",
                        column: x => x.NinjaId,
                        principalTable: "Ninja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NinjaSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(nullable: false),
                    Ranking = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mission_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamNinja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NinjaId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    IsLeader = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamNinja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamNinja_Ninja_NinjaId",
                        column: x => x.NinjaId,
                        principalTable: "Ninja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamNinja_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mission_TeamId",
                table: "Mission",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_NinjaSkill_NinjaId",
                table: "NinjaSkill",
                column: "NinjaId");

            migrationBuilder.CreateIndex(
                name: "IX_NinjaSkill_SkillId",
                table: "NinjaSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamNinja_NinjaId",
                table: "TeamNinja",
                column: "NinjaId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamNinja_TeamId",
                table: "TeamNinja",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "NinjaSkill");

            migrationBuilder.DropTable(
                name: "TeamNinja");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Ninja");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
