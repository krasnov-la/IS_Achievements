using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Login = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Nickname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    AvatarImage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Refresh = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    RefreshExpire = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Preview = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Datetime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Link = table.Column<string>(type: "character varying(2100)", maxLength: 2100, nullable: false),
                    AdminLogin = table.Column<string>(type: "character varying(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Users_AdminLogin",
                        column: x => x.AdminLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificationRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerLogin = table.Column<string>(type: "character varying(256)", nullable: false),
                    EventName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificationRequests_Users_OwnerLogin",
                        column: x => x.OwnerLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    VerificationDatetime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdminLogin = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Users_AdminLogin",
                        column: x => x.AdminLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Achievements_VerificationRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "VerificationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Datetime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Text = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_VerificationRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "VerificationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    FileName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.FileName);
                    table.ForeignKey(
                        name: "FK_Images_VerificationRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "VerificationRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "AvatarImage", "Nickname", "Password", "Refresh", "RefreshExpire", "Role" },
                values: new object[,]
                {
                    { "admin", "00000000-0000-0000-0000-000000000000", "Administrator", "$2a$11$QBOwTM/1G3zIqQBll7vQDel21tMOmMngs20z0bxrVLEqxyY3tHT02", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 16, 4, 56, 49, 752, DateTimeKind.Utc).AddTicks(9116), "Admin" },
                    { "user1", "00000000-0000-0000-0000-000000000000", "User One", "$2a$11$b63c2UhfmVGeeUWTnHlas.bk32AEQffYtnGdcX.NT0vzlNCLdZZVm", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 16, 4, 56, 49, 752, DateTimeKind.Utc).AddTicks(9129), "User" },
                    { "user2", "00000000-0000-0000-0000-000000000000", "User Two", "$2a$11$PW7Dapz13EKI/xGqXjK.Y.DJgkGU39nz79UQyUr6bc4I1UNoUJCey", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 16, 4, 56, 49, 752, DateTimeKind.Utc).AddTicks(9135), "User" },
                    { "user3", "00000000-0000-0000-0000-000000000000", "User Three", "$2a$11$ACFe85jXeKSHr7m3uycOsu4QN9/FbLb/YgTQ/v7UlR22DvoSX5gbW", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 16, 4, 56, 49, 752, DateTimeKind.Utc).AddTicks(9140), "User" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "AdminLogin", "Datetime", "Link", "Name", "Preview" },
                values: new object[,]
                {
                    { new Guid("58ade9e3-d6fa-4748-979e-b02958c5d08b"), "admin", new DateTime(2024, 7, 17, 3, 56, 49, 752, DateTimeKind.Utc).AddTicks(9592), "http://example.com/activity2", "Sample Activity 2", "00000000-0000-0000-0000-000000000000" },
                    { new Guid("6cab54aa-b430-4c4b-81b7-102c7a04482b"), "admin", new DateTime(2024, 7, 17, 4, 56, 49, 752, DateTimeKind.Utc).AddTicks(9583), "http://example.com/activity1", "Sample Activity 1", "00000000-0000-0000-0000-000000000000" },
                    { new Guid("e715aaff-b3a5-45f8-b3a7-7b6e28a3b8af"), "admin", new DateTime(2024, 7, 17, 2, 56, 49, 752, DateTimeKind.Utc).AddTicks(9603), "http://example.com/activity3", "Sample Activity 3", "00000000-0000-0000-0000-000000000000" }
                });

            migrationBuilder.InsertData(
                table: "VerificationRequests",
                columns: new[] { "Id", "DateTime", "Description", "EventName", "OwnerLogin", "Status" },
                values: new object[,]
                {
                    { new Guid("204c2e0e-d8e0-4b14-b28a-45ef4a3c6795"), new DateTime(2024, 7, 17, 2, 56, 49, 752, DateTimeKind.Utc).AddTicks(9514), "Sample verification request description 2", "Sample Event 2", "user2", "Approved" },
                    { new Guid("2a027747-8613-4970-81f4-ceca937824d7"), new DateTime(2024, 7, 17, 0, 56, 49, 752, DateTimeKind.Utc).AddTicks(9525), "Sample verification request description 4", "Sample Event 4", "user3", "InProgress" },
                    { new Guid("4ffada79-a804-486b-bdb2-07d5d06c059a"), new DateTime(2024, 7, 17, 4, 56, 49, 752, DateTimeKind.Utc).AddTicks(9489), "Sample verification request description 1", "Sample Event 1", "user1", "Approved" },
                    { new Guid("e64d7198-8edd-4631-8513-e21cb880267f"), new DateTime(2024, 7, 17, 0, 56, 49, 752, DateTimeKind.Utc).AddTicks(9520), "Sample verification request description 3", "Sample Event 3", "user2", "Approved" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_AdminLogin",
                table: "Achievements",
                column: "AdminLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_RequestId",
                table: "Achievements",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AdminLogin",
                table: "Activities",
                column: "AdminLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_RequestId",
                table: "Images",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationRequests_OwnerLogin",
                table: "VerificationRequests",
                column: "OwnerLogin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "VerificationRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
