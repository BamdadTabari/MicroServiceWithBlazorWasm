using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Illegible_Cms_V2.Identity.Persistence.Migrations
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    IsMobileConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastPasswordChangeTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedLoginCount = table.Column<int>(type: "int", nullable: false),
                    LockoutEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    SecurityStamp = table.Column<string>(type: "nchar(32)", fixedLength: true, maxLength: 32, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLockedOut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "Name", "Title", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2483), "UserManagement", "مدیریت کاربران", new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2486), "identity.users.command" },
                    { 2, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2493), "RoleManagement", "مدیریت نقش‌ها", new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2494), "identity.roles.command" },
                    { 3, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2497), "ClaimManagement", "مدیریت دسترسی ها", new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2499), "identity.claims.command" },
                    { 4, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2501), "UserView", "نمایش  مدیریت کاربران", new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2503), "identity.users.query" },
                    { 5, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2596), "RoleView", "نمایش  مدیریت نقش ها", new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2597), "identity.roles.query" },
                    { 6, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2603), "ClaimView", "نمایش  مدیریت دسترسی ها", new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2605), "identity.claims.query" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 7, 18, 3, 46, 32, 185, DateTimeKind.Local).AddTicks(8793), "Owner", new DateTime(2022, 7, 18, 3, 46, 32, 185, DateTimeKind.Local).AddTicks(8795) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Email", "FailedLoginCount", "IsEmailConfirmed", "IsLockedOut", "IsMobileConfirmed", "LastLoginDate", "LastPasswordChangeTime", "LockoutEndTime", "Mobile", "PasswordHash", "SecurityStamp", "State", "UpdatedAt", "Username" },
                values: new object[] { 1, "G69XK0PR5HCGH7GSAB1VQII8JBZBE3QT", new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2275), "mohammadJavadtabari1024@outlook.com", 0, false, false, false, null, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2262), null, "09301724389", "xf4G1N5C1auE8SW4dMTX7CYD6yI1a4BPgp6dQ1hanBM=.iY4eRAgDxbuJ7mnzYfauEw==", "2L27V1RGVN9KPV68QKLVEW786TL6EE7C", "Active", new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2278), "Illegible_Owner" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2708), new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2711) },
                    { 2, 1, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2768), new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2770) },
                    { 3, 1, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2772), new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2774) },
                    { 4, 1, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2776), new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2777) },
                    { 5, 1, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2779), new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2781) },
                    { 6, 1, new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2784), new DateTime(2022, 7, 18, 3, 46, 32, 195, DateTimeKind.Local).AddTicks(2785) }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2022, 7, 18, 3, 46, 32, 185, DateTimeKind.Local).AddTicks(8727), new DateTime(2022, 7, 18, 3, 46, 32, 185, DateTimeKind.Local).AddTicks(8761) });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_UserId",
                table: "Claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
