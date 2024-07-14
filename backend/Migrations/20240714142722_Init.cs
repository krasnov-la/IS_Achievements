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
                    IsOpen = table.Column<bool>(type: "boolean", nullable: false)
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
                    { "admin", "00000000-0000-0000-0000-000000000000", "Administrator", "$2a$11$QBOwTM/1G3zIqQBll7vQDel21tMOmMngs20z0bxrVLEqxyY3tHT02", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 13, 14, 27, 21, 403, DateTimeKind.Utc).AddTicks(7988), "Admin" },
                    { "user1", "00000000-0000-0000-0000-000000000000", "User One", "$2a$11$b63c2UhfmVGeeUWTnHlas.bk32AEQffYtnGdcX.NT0vzlNCLdZZVm", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 13, 14, 27, 21, 403, DateTimeKind.Utc).AddTicks(8003), "User" },
                    { "user2", "00000000-0000-0000-0000-000000000000", "User Two", "$2a$11$PW7Dapz13EKI/xGqXjK.Y.DJgkGU39nz79UQyUr6bc4I1UNoUJCey", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 13, 14, 27, 21, 403, DateTimeKind.Utc).AddTicks(8010), "User" },
                    { "user3", "00000000-0000-0000-0000-000000000000", "User Three", "$2a$11$ACFe85jXeKSHr7m3uycOsu4QN9/FbLb/YgTQ/v7UlR22DvoSX5gbW", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 8, 13, 14, 27, 21, 403, DateTimeKind.Utc).AddTicks(8015), "User" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "AdminLogin", "Datetime", "Link", "Name", "Preview" },
                values: new object[,]
                {
                    { new Guid("0de4ad0b-3ef9-4ef1-98c9-0356c4d905bb"), "admin", new DateTime(2024, 7, 14, 14, 27, 21, 404, DateTimeKind.Utc).AddTicks(735), "http://example.com/activity1", "Sample Activity 1", "00000000-0000-0000-0000-000000000000" },
                    { new Guid("5a1c1ab2-011c-4389-bdff-282aceefce6e"), "admin", new DateTime(2024, 7, 14, 13, 27, 21, 404, DateTimeKind.Utc).AddTicks(746), "http://example.com/activity2", "Sample Activity 2", "00000000-0000-0000-0000-000000000000" },
                    { new Guid("9c7a598d-1392-4381-8edd-e896d380b7fc"), "admin", new DateTime(2024, 7, 14, 12, 27, 21, 404, DateTimeKind.Utc).AddTicks(753), "http://example.com/activity3", "Sample Activity 3", "00000000-0000-0000-0000-000000000000" }
                });

            migrationBuilder.InsertData(
                table: "VerificationRequests",
                columns: new[] { "Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin" },
                values: new object[,]
                {
                    { new Guid("2238eb35-8c92-4dce-8ed1-8d0ca6a29aeb"), new DateTime(2024, 7, 14, 12, 27, 21, 404, DateTimeKind.Utc).AddTicks(512), "Sample verification request description 2", "Sample Event 2", false, "user2" },
                    { new Guid("3219160c-0333-4ed7-836c-33652c720a3a"), new DateTime(2024, 7, 14, 10, 27, 21, 404, DateTimeKind.Utc).AddTicks(553), "Sample verification request description 4", "Sample Event 4", true, "user3" },
                    { new Guid("678f12ee-7528-45b4-adda-e9733e77f9e6"), new DateTime(2024, 7, 14, 10, 27, 21, 404, DateTimeKind.Utc).AddTicks(547), "Sample verification request description 3", "Sample Event 3", false, "user2" },
                    { new Guid("a2fd4433-c8f6-497e-b5c9-1596a1e00832"), new DateTime(2024, 7, 14, 14, 27, 21, 404, DateTimeKind.Utc).AddTicks(503), "Sample verification request description 1", "Sample Event 1", false, "user1" }
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime" },
                values: new object[,]
                {
                    { new Guid("265c2de4-c75b-4b88-9ce8-a42e62031ff2"), "admin", new Guid("a2fd4433-c8f6-497e-b5c9-1596a1e00832"), 95.5f, new DateTime(2024, 7, 14, 14, 27, 21, 404, DateTimeKind.Utc).AddTicks(639) },
                    { new Guid("35f57901-f7ec-4662-912a-11081507c27f"), "admin", new Guid("2238eb35-8c92-4dce-8ed1-8d0ca6a29aeb"), 88f, new DateTime(2024, 7, 14, 13, 27, 21, 404, DateTimeKind.Utc).AddTicks(643) },
                    { new Guid("e14b2240-aca5-426e-8a01-2d59a8125fa0"), "admin", new Guid("678f12ee-7528-45b4-adda-e9733e77f9e6"), 92.3f, new DateTime(2024, 7, 14, 12, 27, 21, 404, DateTimeKind.Utc).AddTicks(648) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Datetime", "RequestId", "Text" },
                values: new object[,]
                {
                    { new Guid("0441411b-4627-4b3c-aaba-9b6f9cdf168c"), new DateTime(2024, 7, 14, 12, 27, 21, 404, DateTimeKind.Utc).AddTicks(841), new Guid("678f12ee-7528-45b4-adda-e9733e77f9e6"), "This is a sample comment 3." },
                    { new Guid("27f6fb52-4e82-44b5-bc56-7ac01a8401bb"), new DateTime(2024, 7, 14, 13, 27, 21, 404, DateTimeKind.Utc).AddTicks(835), new Guid("2238eb35-8c92-4dce-8ed1-8d0ca6a29aeb"), "This is a sample comment 2." },
                    { new Guid("b2f79a4f-936c-446f-8dc7-bd8344b94b8a"), new DateTime(2024, 7, 14, 14, 27, 21, 404, DateTimeKind.Utc).AddTicks(829), new Guid("a2fd4433-c8f6-497e-b5c9-1596a1e00832"), "This is a sample comment 1." }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "FileName", "RequestId" },
                values: new object[,]
                {
                    { "2e910ebc-3c30-49bb-9b3f-8cd9d04487b9", new Guid("2238eb35-8c92-4dce-8ed1-8d0ca6a29aeb") },
                    { "45fecdab-ac5c-41a7-aa50-ba1a0e2c4d0b", new Guid("a2fd4433-c8f6-497e-b5c9-1596a1e00832") },
                    { "75bd1119-b00a-416c-aeed-cb5b6c2bf8da", new Guid("3219160c-0333-4ed7-836c-33652c720a3a") },
                    { "ed54b1ca-9625-4de8-acb6-1ccd87479082", new Guid("678f12ee-7528-45b4-adda-e9733e77f9e6") }
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
