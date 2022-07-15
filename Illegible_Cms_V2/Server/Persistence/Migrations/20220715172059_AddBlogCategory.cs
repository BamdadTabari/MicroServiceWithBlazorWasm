using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Illegible_Cms_V2.Server.Persistence.Migrations
{
    public partial class AddBlogCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Summery",
                table: "WeblogPosts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "WeblogPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "WeblogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "WeblogPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdaterId",
                table: "WeblogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeblogPostCategoryId",
                table: "WeblogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WeblogPostCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CategoryIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    UpdaterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeblogPostCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeblogPosts_WeblogPostCategoryId",
                table: "WeblogPosts",
                column: "WeblogPostCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeblogPosts_WeblogPostCategory_WeblogPostCategoryId",
                table: "WeblogPosts",
                column: "WeblogPostCategoryId",
                principalTable: "WeblogPostCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeblogPosts_WeblogPostCategory_WeblogPostCategoryId",
                table: "WeblogPosts");

            migrationBuilder.DropTable(
                name: "WeblogPostCategory");

            migrationBuilder.DropIndex(
                name: "IX_WeblogPosts_WeblogPostCategoryId",
                table: "WeblogPosts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "WeblogPosts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "WeblogPosts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "WeblogPosts");

            migrationBuilder.DropColumn(
                name: "UpdaterId",
                table: "WeblogPosts");

            migrationBuilder.DropColumn(
                name: "WeblogPostCategoryId",
                table: "WeblogPosts");

            migrationBuilder.AlterColumn<string>(
                name: "Summery",
                table: "WeblogPosts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
