using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    FileName = table.Column<string>(type: "text", nullable: false),
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
                columns: new[] { "Login", "Nickname", "Password", "Refresh", "RefreshExpire", "Role" },
                values: new object[,]
                {
                    { "admin", "Administrator", "$2a$11$QBOwTM/1G3zIqQBll7vQDel21tMOmMngs20z0bxrVLEqxyY3tHT02", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 7, 7, 15, 33, 25, 926, DateTimeKind.Utc).AddTicks(4260), "Admin" },
                    { "user1", "User One", "$2a$11$b63c2UhfmVGeeUWTnHlas.bk32AEQffYtnGdcX.NT0vzlNCLdZZVm", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 7, 7, 15, 33, 25, 926, DateTimeKind.Utc).AddTicks(4274), "User" },
                    { "user2", "User Two", "$2a$11$PW7Dapz13EKI/xGqXjK.Y.DJgkGU39nz79UQyUr6bc4I1UNoUJCey", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 7, 7, 15, 33, 25, 926, DateTimeKind.Utc).AddTicks(4277), "User" },
                    { "user3", "User Three", "$2a$11$ACFe85jXeKSHr7m3uycOsu4QN9/FbLb/YgTQ/v7UlR22DvoSX5gbW", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 7, 7, 15, 33, 25, 926, DateTimeKind.Utc).AddTicks(4281), "User" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "AdminLogin", "Datetime", "Link", "Name" },
                values: new object[,]
                {
                    { new Guid("18dfa727-8a33-44cb-a4e1-38029ff5c197"), "admin", new DateTime(2024, 6, 7, 13, 33, 25, 926, DateTimeKind.Utc).AddTicks(4940), "http://example.com/activity3", "Sample Activity 3" },
                    { new Guid("4293fc75-bd33-4ce2-8adc-6c58ed59d45a"), "admin", new DateTime(2024, 6, 7, 15, 33, 25, 926, DateTimeKind.Utc).AddTicks(4926), "http://example.com/activity1", "Sample Activity 1" },
                    { new Guid("fefacaab-abcd-4ddd-822b-77834ab388bb"), "admin", new DateTime(2024, 6, 7, 14, 33, 25, 926, DateTimeKind.Utc).AddTicks(4934), "http://example.com/activity2", "Sample Activity 2" }
                });

            migrationBuilder.InsertData(
                table: "VerificationRequests",
                columns: new[] { "Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin" },
                values: new object[,]
                {
                    { new Guid("07ca9911-9553-425c-aa1c-c0843d524f46"), new DateTime(2024, 6, 7, 11, 33, 25, 926, DateTimeKind.Utc).AddTicks(4727), "Sample verification request description 4", "Sample Event 4", true, "user3" },
                    { new Guid("34f6a61f-3e13-4dfc-9340-759c8ee147bd"), new DateTime(2024, 6, 7, 11, 33, 25, 926, DateTimeKind.Utc).AddTicks(4721), "Sample verification request description 3", "Sample Event 3", false, "user2" },
                    { new Guid("620859cd-4ed4-451d-b1e9-be0d9cec8ad5"), new DateTime(2024, 6, 7, 15, 33, 25, 926, DateTimeKind.Utc).AddTicks(4680), "Sample verification request description 1", "Sample Event 1", false, "user1" },
                    { new Guid("88e1ab02-9b81-42a1-9f0c-1454b08e678f"), new DateTime(2024, 6, 7, 13, 33, 25, 926, DateTimeKind.Utc).AddTicks(4690), "Sample verification request description 2", "Sample Event 2", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime" },
                values: new object[,]
                {
                    { new Guid("2562254f-9425-42b2-b181-0a1440d74749"), "admin", new Guid("88e1ab02-9b81-42a1-9f0c-1454b08e678f"), 88f, new DateTime(2024, 6, 7, 14, 33, 25, 926, DateTimeKind.Utc).AddTicks(4829) },
                    { new Guid("256742f7-f3e4-411d-baa4-06def7e0e38a"), "admin", new Guid("620859cd-4ed4-451d-b1e9-be0d9cec8ad5"), 95.5f, new DateTime(2024, 6, 7, 15, 33, 25, 926, DateTimeKind.Utc).AddTicks(4824) },
                    { new Guid("3400efb5-d8dc-4da0-8663-ac812128ea08"), "admin", new Guid("34f6a61f-3e13-4dfc-9340-759c8ee147bd"), 92.3f, new DateTime(2024, 6, 7, 13, 33, 25, 926, DateTimeKind.Utc).AddTicks(4835) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Datetime", "RequestId", "Text" },
                values: new object[,]
                {
                    { new Guid("24c0d96d-30e8-4ef9-a409-87cdc1ab46d7"), new DateTime(2024, 6, 7, 14, 33, 25, 926, DateTimeKind.Utc).AddTicks(5033), new Guid("88e1ab02-9b81-42a1-9f0c-1454b08e678f"), "This is a sample comment 2." },
                    { new Guid("5b8dca55-bf4a-4256-8cbd-49548177efc3"), new DateTime(2024, 6, 7, 15, 33, 25, 926, DateTimeKind.Utc).AddTicks(5028), new Guid("620859cd-4ed4-451d-b1e9-be0d9cec8ad5"), "This is a sample comment 1." },
                    { new Guid("6faa9405-264c-4e1f-b38f-ddbadb4c6c09"), new DateTime(2024, 6, 7, 13, 33, 25, 926, DateTimeKind.Utc).AddTicks(5038), new Guid("34f6a61f-3e13-4dfc-9340-759c8ee147bd"), "This is a sample comment 3." }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "FileName", "RequestId" },
                values: new object[,]
                {
                    { "578cc1e8-cd47-4e63-b045-fd661a63affb", new Guid("620859cd-4ed4-451d-b1e9-be0d9cec8ad5") },
                    { "95806d77-3214-4a78-96c5-d2ada6d311fc", new Guid("34f6a61f-3e13-4dfc-9340-759c8ee147bd") },
                    { "a54e6d85-dc0c-4114-8e6f-5600ff69b9c7", new Guid("88e1ab02-9b81-42a1-9f0c-1454b08e678f") },
                    { "f772f9b2-a484-46de-91d1-3b9ab31d24b4", new Guid("07ca9911-9553-425c-aa1c-c0843d524f46") }
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
