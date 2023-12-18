using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetNTierArchitecture.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "TeamName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 18, 22, 25, 30, 776, DateTimeKind.Local).AddTicks(536), "Development", null },
                    { 2, new DateTime(2023, 12, 18, 22, 25, 30, 776, DateTimeKind.Local).AddTicks(546), "Sales", null },
                    { 3, new DateTime(2023, 12, 18, 22, 25, 30, 776, DateTimeKind.Local).AddTicks(547), "Marketing", null },
                    { 4, new DateTime(2023, 12, 18, 22, 25, 30, 776, DateTimeKind.Local).AddTicks(547), "HR", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "TeamId", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 18, 22, 25, 30, 776, DateTimeKind.Local).AddTicks(798), "ayseyildiz@gmail.com", "123456", 1, null, "ayseyildiz" },
                    { 2, new DateTime(2023, 12, 18, 22, 25, 30, 776, DateTimeKind.Local).AddTicks(800), "aliyilmaz@gmail.com", "112233", 2, null, "aliyilmaz" },
                    { 3, new DateTime(2023, 12, 18, 22, 25, 30, 776, DateTimeKind.Local).AddTicks(801), "elifdemir@gmail.com", "123123", 3, null, "elifdemir" },
                    { 4, new DateTime(2023, 12, 18, 22, 25, 30, 776, DateTimeKind.Local).AddTicks(802), "ahmetkaya@gmail.com", "456789", 4, null, "ahmetkaya" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "FirstName", "LastName", "NickName", "UserId" },
                values: new object[,]
                {
                    { 1, "Ayşe", "Yıldız", "ayse", 1 },
                    { 2, "Ali", "Yılmaz", "ali", 2 },
                    { 3, "Elif", "Demir", "elif", 3 },
                    { 4, "Ahmet", "Kaya", "ahmet", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
