using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VacancyName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FullUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Comment", "CompanyName", "DateCreated", "FullUrl", "IsActive", "IsDeleted", "LastModifiedDate", "VacancyName" },
                values: new object[] { 1, "Comment", "Google", new DateTime(2023, 7, 3, 21, 18, 49, 474, DateTimeKind.Utc).AddTicks(6229), "https://google.com", true, false, new DateTime(2023, 6, 13, 21, 18, 49, 474, DateTimeKind.Utc).AddTicks(6231), "Developer" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyName",
                table: "Jobs",
                column: "CompanyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
