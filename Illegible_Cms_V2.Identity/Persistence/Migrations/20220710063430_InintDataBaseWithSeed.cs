using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Illegible_Cms_V2.Identity.Persistence.Migrations
{
    public partial class InintDataBaseWithSeed : Migration
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
                    Id = table.Column<int>(type: "int", nullable: false),
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
                    { 1, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9801), "UserManagement", "مدیریت کاربران", new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9806), "identity.users.command" },
                    { 2, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9814), "RoleManagement", "مدیریت نقش‌ها", new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9816), "identity.roles.command" },
                    { 3, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9819), "ClaimManagement", "مدیریت دسترسی ها", new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9821), "identity.claims.command" },
                    { 4, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9825), "UserView", "نمایش  مدیریت کاربران", new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9827), "identity.users.query" },
                    { 5, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9830), "RoleView", "نمایش  مدیریت نقش ها", new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9831), "identity.roles.query" },
                    { 6, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9838), "ClaimView", "نمایش  مدیریت دسترسی ها", new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9839), "identity.claims.query" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 7, 9, 23, 34, 29, 726, DateTimeKind.Local).AddTicks(4497), "Owner", new DateTime(2022, 7, 9, 23, 34, 29, 726, DateTimeKind.Local).AddTicks(4501) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Email", "FailedLoginCount", "IsEmailConfirmed", "IsLockedOut", "IsMobileConfirmed", "LastLoginDate", "LastPasswordChangeTime", "LockoutEndTime", "Mobile", "PasswordHash", "SecurityStamp", "State", "UpdatedAt", "Username" },
                values: new object[] { 1, "1I66FRJPSZ1D0M5M3UGPQAI625QUV5PF", new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9505), "mohammadJavadtabari1024@outlook.com", 0, false, false, false, null, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9484), null, "09301724389", "IQwO265q8doSbB9xfpJwHn3f3qV5B2Pu7n307Z+wv0I=.zhWV9D2fW99FwItkl6oWDA==", "T98N35ZX62RQRCFV84M8BP87XZXNSXUH", "Active", new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9509), "Illegible_Owner" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9929), new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9932) },
                    { 2, 1, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9938), new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9940) },
                    { 3, 1, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9943), new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9945) },
                    { 4, 1, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9948), new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9949) },
                    { 5, 1, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9952), new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9954) },
                    { 6, 1, new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9958), new DateTime(2022, 7, 9, 23, 34, 29, 743, DateTimeKind.Local).AddTicks(9960) }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedAt", "Id", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2022, 7, 9, 23, 34, 29, 726, DateTimeKind.Local).AddTicks(4402), 1, new DateTime(2022, 7, 9, 23, 34, 29, 726, DateTimeKind.Local).AddTicks(4446) });

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
