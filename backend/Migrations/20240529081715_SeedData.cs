using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "VerificationRequests",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshExpire",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datetime",
                table: "Comments",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datetime",
                table: "Activities",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VerificationDatetime",
                table: "Achievements",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "Nickname", "Password", "Refresh", "RefreshExpire", "Role" },
                values: new object[,]
                {
                    { "admin", "Administrator", "admin_password", "admin_refresh_token", new DateTime(2024, 6, 28, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5665), "Admin" },
                    { "user1", "User One", "user1_password", "user1_refresh_token", new DateTime(2024, 6, 28, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5671), "User" },
                    { "user2", "User Two", "user2_password", "user2_refresh_token", new DateTime(2024, 6, 28, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5672), "User" },
                    { "user3", "User Three", "user3_password", "user3_refresh_token", new DateTime(2024, 6, 28, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5674), "User" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "AdminLogin", "Datetime", "Link", "Name" },
                values: new object[,]
                {
                    { new Guid("07a9ca17-6aae-424b-875b-3fb1a60952b3"), "admin", new DateTime(2024, 5, 29, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5935), "http://example.com/activity1", "Sample Activity 1" },
                    { new Guid("6e7441a7-d3ee-4c12-90ab-849bbdfff559"), "admin", new DateTime(2024, 5, 29, 6, 17, 14, 939, DateTimeKind.Utc).AddTicks(5939), "http://example.com/activity3", "Sample Activity 3" },
                    { new Guid("9009581c-c4b1-426e-8b77-4f6fb0ffc2ae"), "admin", new DateTime(2024, 5, 29, 7, 17, 14, 939, DateTimeKind.Utc).AddTicks(5937), "http://example.com/activity2", "Sample Activity 2" }
                });

            migrationBuilder.InsertData(
                table: "VerificationRequests",
                columns: new[] { "Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin" },
                values: new object[,]
                {
                    { new Guid("1495665f-c673-4c99-a519-4cad151377c4"), new DateTime(2024, 5, 29, 6, 17, 14, 939, DateTimeKind.Utc).AddTicks(5867), "Sample verification request description 2", "Sample Event 2", false, "user2" },
                    { new Guid("54020c93-8355-4d58-a337-457d4968b9fe"), new DateTime(2024, 5, 29, 4, 17, 14, 939, DateTimeKind.Utc).AddTicks(5887), "Sample verification request description 4", "Sample Event 4", false, "user3" },
                    { new Guid("5a7db9e6-054a-454f-baf7-5b35b94c4f6b"), new DateTime(2024, 5, 29, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5865), "Sample verification request description 1", "Sample Event 1", false, "user1" },
                    { new Guid("ea4967f7-b69a-4dcf-bb33-e86273238af2"), new DateTime(2024, 5, 29, 4, 17, 14, 939, DateTimeKind.Utc).AddTicks(5870), "Sample verification request description 3", "Sample Event 3", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime" },
                values: new object[,]
                {
                    { new Guid("30e21ab5-698c-4595-af68-4705bde5c534"), "admin", new Guid("ea4967f7-b69a-4dcf-bb33-e86273238af2"), 92.3f, new DateTime(2024, 5, 29, 6, 17, 14, 939, DateTimeKind.Utc).AddTicks(5914) },
                    { new Guid("78fae1a7-c1e6-4a9f-8811-4948c9f390b4"), "admin", new Guid("5a7db9e6-054a-454f-baf7-5b35b94c4f6b"), 95.5f, new DateTime(2024, 5, 29, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5911) },
                    { new Guid("92a09857-8a63-472d-90ef-a6d81f3e12bb"), "admin", new Guid("1495665f-c673-4c99-a519-4cad151377c4"), 88f, new DateTime(2024, 5, 29, 7, 17, 14, 939, DateTimeKind.Utc).AddTicks(5912) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Datetime", "RequestId", "Text" },
                values: new object[,]
                {
                    { new Guid("1e7edaf3-b99c-486f-bfb1-8db726edc7a4"), new DateTime(2024, 5, 29, 7, 17, 14, 939, DateTimeKind.Utc).AddTicks(5964), new Guid("1495665f-c673-4c99-a519-4cad151377c4"), "This is a sample comment 2." },
                    { new Guid("51deb0d3-31f7-4e9e-b2cb-8997188167a2"), new DateTime(2024, 5, 29, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5962), new Guid("5a7db9e6-054a-454f-baf7-5b35b94c4f6b"), "This is a sample comment 1." },
                    { new Guid("f395c12e-fe57-47c9-8c9f-443b63dfe9d8"), new DateTime(2024, 5, 29, 6, 17, 14, 939, DateTimeKind.Utc).AddTicks(5966), new Guid("ea4967f7-b69a-4dcf-bb33-e86273238af2"), "This is a sample comment 3." }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "RequestId" },
                values: new object[,]
                {
                    { new Guid("13d3bf86-5072-48f5-8352-b563a6dd8e7e"), new Guid("1495665f-c673-4c99-a519-4cad151377c4") },
                    { new Guid("303e3d6f-a792-4b5e-a6b1-3c02054accc1"), new Guid("5a7db9e6-054a-454f-baf7-5b35b94c4f6b") },
                    { new Guid("df1f5b4c-cb0d-43c1-909b-3ec0f08b63bb"), new Guid("ea4967f7-b69a-4dcf-bb33-e86273238af2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("30e21ab5-698c-4595-af68-4705bde5c534"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("78fae1a7-c1e6-4a9f-8811-4948c9f390b4"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("92a09857-8a63-472d-90ef-a6d81f3e12bb"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("07a9ca17-6aae-424b-875b-3fb1a60952b3"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("6e7441a7-d3ee-4c12-90ab-849bbdfff559"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("9009581c-c4b1-426e-8b77-4f6fb0ffc2ae"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("1e7edaf3-b99c-486f-bfb1-8db726edc7a4"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("51deb0d3-31f7-4e9e-b2cb-8997188167a2"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f395c12e-fe57-47c9-8c9f-443b63dfe9d8"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("13d3bf86-5072-48f5-8352-b563a6dd8e7e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("303e3d6f-a792-4b5e-a6b1-3c02054accc1"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("df1f5b4c-cb0d-43c1-909b-3ec0f08b63bb"));

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("54020c93-8355-4d58-a337-457d4968b9fe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user3");

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("1495665f-c673-4c99-a519-4cad151377c4"));

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("5a7db9e6-054a-454f-baf7-5b35b94c4f6b"));

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("ea4967f7-b69a-4dcf-bb33-e86273238af2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "VerificationRequests",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshExpire",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datetime",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datetime",
                table: "Activities",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VerificationDatetime",
                table: "Achievements",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
