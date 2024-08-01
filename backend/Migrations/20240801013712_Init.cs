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
                    { "admin", "00000000-0000-0000-0000-000000000000", "Administrator", "$2a$11$QBOwTM/1G3zIqQBll7vQDel21tMOmMngs20z0bxrVLEqxyY3tHT02", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 31, 1, 37, 12, 109, DateTimeKind.Utc).AddTicks(8374), "Admin" },
                    { "user1", "00000000-0000-0000-0000-000000000000", "User One", "$2a$11$b63c2UhfmVGeeUWTnHlas.bk32AEQffYtnGdcX.NT0vzlNCLdZZVm", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 31, 1, 37, 12, 109, DateTimeKind.Utc).AddTicks(8381), "User" },
                    { "user2", "00000000-0000-0000-0000-000000000000", "User Two", "$2a$11$PW7Dapz13EKI/xGqXjK.Y.DJgkGU39nz79UQyUr6bc4I1UNoUJCey", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 31, 1, 37, 12, 109, DateTimeKind.Utc).AddTicks(8389), "User" },
                    { "user3", "00000000-0000-0000-0000-000000000000", "User Three", "$2a$11$ACFe85jXeKSHr7m3uycOsu4QN9/FbLb/YgTQ/v7UlR22DvoSX5gbW", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 31, 1, 37, 12, 109, DateTimeKind.Utc).AddTicks(8440), "User" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "AdminLogin", "Datetime", "Link", "Name", "Preview" },
                values: new object[,]
                {
                    { new Guid("49dbe9e4-9448-4633-b20c-d0d0740186d0"), "admin", new DateTime(2024, 8, 1, 0, 37, 12, 109, DateTimeKind.Utc).AddTicks(8809), "http://example.com/activity2", "Sample Activity 2", "00000000-0000-0000-0000-000000000000" },
                    { new Guid("a08c574b-ea04-439c-8dc2-a8a8d269894b"), "admin", new DateTime(2024, 7, 31, 23, 37, 12, 109, DateTimeKind.Utc).AddTicks(8812), "http://example.com/activity3", "Sample Activity 3", "00000000-0000-0000-0000-000000000000" },
                    { new Guid("be05aabd-8489-40e4-b8f8-30c7030e3500"), "admin", new DateTime(2024, 8, 1, 1, 37, 12, 109, DateTimeKind.Utc).AddTicks(8803), "http://example.com/activity1", "Sample Activity 1", "00000000-0000-0000-0000-000000000000" }
                });

            migrationBuilder.InsertData(
                table: "VerificationRequests",
                columns: new[] { "Id", "DateTime", "Description", "EventName", "OwnerLogin", "Status" },
                values: new object[,]
                {
                    { new Guid("2e754ad1-58a6-4d4c-b821-923c230973ba"), new DateTime(2024, 7, 31, 23, 37, 12, 109, DateTimeKind.Utc).AddTicks(8713), "Sample verification request description 2", "Sample Event 2", "user2", "Approved" },
                    { new Guid("318fd119-df20-4e3d-86dc-e75f3ba95440"), new DateTime(2024, 7, 31, 21, 37, 12, 109, DateTimeKind.Utc).AddTicks(8720), "Sample verification request description 4", "Sample Event 4", "user3", "InProgress" },
                    { new Guid("793a4459-5027-4387-bec4-9e394e632d9a"), new DateTime(2024, 8, 1, 1, 37, 12, 109, DateTimeKind.Utc).AddTicks(8690), "Sample verification request description 1", "Sample Event 1", "user1", "Approved" },
                    { new Guid("7b14ca69-5352-471c-9f65-b9fd655c5b07"), new DateTime(2024, 7, 31, 21, 37, 12, 109, DateTimeKind.Utc).AddTicks(8717), "Sample verification request description 3", "Sample Event 3", "user2", "Approved" }
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime" },
                values: new object[,]
                {
                    { new Guid("5f1f8a13-7234-4d2e-8818-ec3372b9e297"), "admin", new Guid("793a4459-5027-4387-bec4-9e394e632d9a"), 95.5f, new DateTime(2024, 8, 1, 1, 37, 12, 109, DateTimeKind.Utc).AddTicks(8756) },
                    { new Guid("f2fae233-6521-413b-acf4-c199fbfe9011"), "admin", new Guid("7b14ca69-5352-471c-9f65-b9fd655c5b07"), 92.3f, new DateTime(2024, 7, 31, 23, 37, 12, 109, DateTimeKind.Utc).AddTicks(8768) },
                    { new Guid("fdaf067f-4ecb-4090-814a-7c8e34342182"), "admin", new Guid("2e754ad1-58a6-4d4c-b821-923c230973ba"), 88f, new DateTime(2024, 8, 1, 0, 37, 12, 109, DateTimeKind.Utc).AddTicks(8760) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Datetime", "RequestId", "Text" },
                values: new object[,]
                {
                    { new Guid("76762e47-63e0-403d-af9f-0fbf508a7a86"), new DateTime(2024, 7, 31, 23, 37, 12, 109, DateTimeKind.Utc).AddTicks(8860), new Guid("7b14ca69-5352-471c-9f65-b9fd655c5b07"), "This is a sample comment 3." },
                    { new Guid("a5603c74-14b4-4504-976f-ed98044b221b"), new DateTime(2024, 8, 1, 1, 37, 12, 109, DateTimeKind.Utc).AddTicks(8853), new Guid("793a4459-5027-4387-bec4-9e394e632d9a"), "This is a sample comment 1." },
                    { new Guid("b12da4cd-6990-41c5-bd62-dc8c78b294d9"), new DateTime(2024, 8, 1, 0, 37, 12, 109, DateTimeKind.Utc).AddTicks(8856), new Guid("2e754ad1-58a6-4d4c-b821-923c230973ba"), "This is a sample comment 2." }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "FileName", "RequestId" },
                values: new object[,]
                {
                    { "642b33aa-4696-4578-9fe3-a7e4affbf441", new Guid("2e754ad1-58a6-4d4c-b821-923c230973ba") },
                    { "72ae54df-3dee-4d56-932c-fe8fe1768dfa", new Guid("7b14ca69-5352-471c-9f65-b9fd655c5b07") },
                    { "a167d1ab-afe9-434d-9f2d-bafc34f1e085", new Guid("793a4459-5027-4387-bec4-9e394e632d9a") },
                    { "a92094d9-a3da-4e4b-b5ac-30a2d5e9ecec", new Guid("318fd119-df20-4e3d-86dc-e75f3ba95440") }
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
