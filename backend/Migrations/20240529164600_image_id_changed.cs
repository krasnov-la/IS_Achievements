using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class image_id_changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("0cf5d7f3-7f4b-459e-9f60-2c2dc3c69ca1"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("66627ae3-db75-4968-be27-191471a37ea4"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("e9d7de43-da2c-4987-86cf-8bb45e57c6d3"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("13498067-f6d5-4119-9177-7ef36b72baba"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("16598089-f9c7-4148-8156-d053de59e77a"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("51132e40-443d-41b5-a473-b8f18bfd022f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("05c52dd0-ad34-4e98-9ddc-c945ee61a695"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("39363588-c412-4517-ac5e-dd2d9ea5c93f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9bd87f5d-1d18-47ad-b4a6-5920eecf6419"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("38584614-4726-44e9-8417-7546e4375a90"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("b645f67e-e671-4b87-946e-dfbbfc94055a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("db26ef54-2b17-4aea-b31d-05a140b726ac"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("fb63c831-346f-4705-991e-bdef6c86e741"));

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("2331975a-8c2e-4f35-9de2-61c79f6ffdf0"));

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("2afa5cce-fbcb-45ff-8f5c-96c5c911075d"));

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("75b0911d-b08f-4129-b005-759980534a69"));

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("b3099f97-b15d-41ae-b741-8a434354b604"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "FileName");

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "AdminLogin", "Datetime", "Link", "Name" },
                values: new object[,]
                {
                    { new Guid("c12300c3-5bfd-43e9-874b-001ef716836a"), "admin", new DateTime(2024, 5, 29, 14, 45, 57, 832, DateTimeKind.Utc).AddTicks(6878), "http://example.com/activity3", "Sample Activity 3" },
                    { new Guid("c8ff3cca-d3a8-4846-8aca-a156fa9905c4"), "admin", new DateTime(2024, 5, 29, 16, 45, 57, 832, DateTimeKind.Utc).AddTicks(6865), "http://example.com/activity1", "Sample Activity 1" },
                    { new Guid("cedb16da-c3d4-406f-85c1-95fdc1b04407"), "admin", new DateTime(2024, 5, 29, 15, 45, 57, 832, DateTimeKind.Utc).AddTicks(6873), "http://example.com/activity2", "Sample Activity 2" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "admin",
                column: "RefreshExpire",
                value: new DateTime(2024, 6, 28, 16, 45, 57, 832, DateTimeKind.Utc).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user1",
                column: "RefreshExpire",
                value: new DateTime(2024, 6, 28, 16, 45, 57, 832, DateTimeKind.Utc).AddTicks(6096));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user2",
                column: "RefreshExpire",
                value: new DateTime(2024, 6, 28, 16, 45, 57, 832, DateTimeKind.Utc).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user3",
                column: "RefreshExpire",
                value: new DateTime(2024, 6, 28, 16, 45, 57, 832, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.InsertData(
                table: "VerificationRequests",
                columns: new[] { "Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin" },
                values: new object[,]
                {
                    { new Guid("207fd7b5-d5e5-43e8-80b8-d4c672669797"), new DateTime(2024, 5, 29, 12, 45, 57, 832, DateTimeKind.Utc).AddTicks(6684), "Sample verification request description 3", "Sample Event 3", false, "user2" },
                    { new Guid("590f67f1-3dc0-4984-849d-7042411ee438"), new DateTime(2024, 5, 29, 16, 45, 57, 832, DateTimeKind.Utc).AddTicks(6638), "Sample verification request description 1", "Sample Event 1", false, "user1" },
                    { new Guid("b5778724-4834-4a5c-855c-7fdc8f26f041"), new DateTime(2024, 5, 29, 12, 45, 57, 832, DateTimeKind.Utc).AddTicks(6690), "Sample verification request description 4", "Sample Event 4", true, "user3" },
                    { new Guid("cb2951d9-028a-4f0b-b97e-4edea80e6023"), new DateTime(2024, 5, 29, 14, 45, 57, 832, DateTimeKind.Utc).AddTicks(6674), "Sample verification request description 2", "Sample Event 2", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime" },
                values: new object[,]
                {
                    { new Guid("10178a65-ed05-45df-bb46-4233eee50705"), "admin", new Guid("590f67f1-3dc0-4984-849d-7042411ee438"), 95.5f, new DateTime(2024, 5, 29, 16, 45, 57, 832, DateTimeKind.Utc).AddTicks(6777) },
                    { new Guid("5440db13-c5c2-4a1c-93d3-01b0a548447f"), "admin", new Guid("207fd7b5-d5e5-43e8-80b8-d4c672669797"), 92.3f, new DateTime(2024, 5, 29, 14, 45, 57, 832, DateTimeKind.Utc).AddTicks(6794) },
                    { new Guid("cbf0502a-bf83-4012-9676-3e2a4fcacf56"), "admin", new Guid("cb2951d9-028a-4f0b-b97e-4edea80e6023"), 88f, new DateTime(2024, 5, 29, 15, 45, 57, 832, DateTimeKind.Utc).AddTicks(6782) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Datetime", "RequestId", "Text" },
                values: new object[,]
                {
                    { new Guid("0335093a-beec-44a7-b49a-e98e2fc49246"), new DateTime(2024, 5, 29, 15, 45, 57, 832, DateTimeKind.Utc).AddTicks(6965), new Guid("cb2951d9-028a-4f0b-b97e-4edea80e6023"), "This is a sample comment 2." },
                    { new Guid("90ec30a9-8b4d-45f3-ae51-3fcf2be63606"), new DateTime(2024, 5, 29, 16, 45, 57, 832, DateTimeKind.Utc).AddTicks(6959), new Guid("590f67f1-3dc0-4984-849d-7042411ee438"), "This is a sample comment 1." },
                    { new Guid("f01a8f2c-06a3-4ef1-a4d0-315d843782cc"), new DateTime(2024, 5, 29, 14, 45, 57, 832, DateTimeKind.Utc).AddTicks(6970), new Guid("207fd7b5-d5e5-43e8-80b8-d4c672669797"), "This is a sample comment 3." }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "FileName", "RequestId" },
                values: new object[,]
                {
                    { "5f65d779-b75a-4e2d-82c7-af7863247a59", new Guid("590f67f1-3dc0-4984-849d-7042411ee438") },
                    { "8f8976f5-226f-4c2a-b21b-e7cb7990a4c8", new Guid("207fd7b5-d5e5-43e8-80b8-d4c672669797") },
                    { "91a15f15-a233-425e-86e5-58880814e245", new Guid("b5778724-4834-4a5c-855c-7fdc8f26f041") },
                    { "a9d28d38-ac96-4106-9474-442cb75bd7a8", new Guid("cb2951d9-028a-4f0b-b97e-4edea80e6023") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("10178a65-ed05-45df-bb46-4233eee50705"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("5440db13-c5c2-4a1c-93d3-01b0a548447f"));

            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "Id",
                keyValue: new Guid("cbf0502a-bf83-4012-9676-3e2a4fcacf56"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("c12300c3-5bfd-43e9-874b-001ef716836a"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("c8ff3cca-d3a8-4846-8aca-a156fa9905c4"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("cedb16da-c3d4-406f-85c1-95fdc1b04407"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("0335093a-beec-44a7-b49a-e98e2fc49246"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("90ec30a9-8b4d-45f3-ae51-3fcf2be63606"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f01a8f2c-06a3-4ef1-a4d0-315d843782cc"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "FileName",
                keyColumnType: "text",
                keyValue: "5f65d779-b75a-4e2d-82c7-af7863247a59");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "FileName",
                keyColumnType: "text",
                keyValue: "8f8976f5-226f-4c2a-b21b-e7cb7990a4c8");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "FileName",
                keyColumnType: "text",
                keyValue: "91a15f15-a233-425e-86e5-58880814e245");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "FileName",
                keyColumnType: "text",
                keyValue: "a9d28d38-ac96-4106-9474-442cb75bd7a8");

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("207fd7b5-d5e5-43e8-80b8-d4c672669797"));

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("590f67f1-3dc0-4984-849d-7042411ee438"));

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("b5778724-4834-4a5c-855c-7fdc8f26f041"));

            migrationBuilder.DeleteData(
                table: "VerificationRequests",
                keyColumn: "Id",
                keyValue: new Guid("cb2951d9-028a-4f0b-b97e-4edea80e6023"));

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Images",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "AdminLogin", "Datetime", "Link", "Name" },
                values: new object[,]
                {
                    { new Guid("13498067-f6d5-4119-9177-7ef36b72baba"), "admin", new DateTime(2024, 5, 29, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4887), "http://example.com/activity1", "Sample Activity 1" },
                    { new Guid("16598089-f9c7-4148-8156-d053de59e77a"), "admin", new DateTime(2024, 5, 29, 12, 39, 14, 994, DateTimeKind.Utc).AddTicks(4894), "http://example.com/activity3", "Sample Activity 3" },
                    { new Guid("51132e40-443d-41b5-a473-b8f18bfd022f"), "admin", new DateTime(2024, 5, 29, 13, 39, 14, 994, DateTimeKind.Utc).AddTicks(4890), "http://example.com/activity2", "Sample Activity 2" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "admin",
                column: "RefreshExpire",
                value: new DateTime(2024, 6, 28, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4466));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user1",
                column: "RefreshExpire",
                value: new DateTime(2024, 6, 28, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user2",
                column: "RefreshExpire",
                value: new DateTime(2024, 6, 28, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user3",
                column: "RefreshExpire",
                value: new DateTime(2024, 6, 28, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.InsertData(
                table: "VerificationRequests",
                columns: new[] { "Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin" },
                values: new object[,]
                {
                    { new Guid("2331975a-8c2e-4f35-9de2-61c79f6ffdf0"), new DateTime(2024, 5, 29, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4722), "Sample verification request description 1", "Sample Event 1", false, "user1" },
                    { new Guid("2afa5cce-fbcb-45ff-8f5c-96c5c911075d"), new DateTime(2024, 5, 29, 12, 39, 14, 994, DateTimeKind.Utc).AddTicks(4726), "Sample verification request description 2", "Sample Event 2", false, "user2" },
                    { new Guid("75b0911d-b08f-4129-b005-759980534a69"), new DateTime(2024, 5, 29, 10, 39, 14, 994, DateTimeKind.Utc).AddTicks(4754), "Sample verification request description 4", "Sample Event 4", true, "user3" },
                    { new Guid("b3099f97-b15d-41ae-b741-8a434354b604"), new DateTime(2024, 5, 29, 10, 39, 14, 994, DateTimeKind.Utc).AddTicks(4750), "Sample verification request description 3", "Sample Event 3", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime" },
                values: new object[,]
                {
                    { new Guid("0cf5d7f3-7f4b-459e-9f60-2c2dc3c69ca1"), "admin", new Guid("2afa5cce-fbcb-45ff-8f5c-96c5c911075d"), 88f, new DateTime(2024, 5, 29, 13, 39, 14, 994, DateTimeKind.Utc).AddTicks(4843) },
                    { new Guid("66627ae3-db75-4968-be27-191471a37ea4"), "admin", new Guid("b3099f97-b15d-41ae-b741-8a434354b604"), 92.3f, new DateTime(2024, 5, 29, 12, 39, 14, 994, DateTimeKind.Utc).AddTicks(4846) },
                    { new Guid("e9d7de43-da2c-4987-86cf-8bb45e57c6d3"), "admin", new Guid("2331975a-8c2e-4f35-9de2-61c79f6ffdf0"), 95.5f, new DateTime(2024, 5, 29, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4840) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Datetime", "RequestId", "Text" },
                values: new object[,]
                {
                    { new Guid("05c52dd0-ad34-4e98-9ddc-c945ee61a695"), new DateTime(2024, 5, 29, 13, 39, 14, 994, DateTimeKind.Utc).AddTicks(4939), new Guid("2afa5cce-fbcb-45ff-8f5c-96c5c911075d"), "This is a sample comment 2." },
                    { new Guid("39363588-c412-4517-ac5e-dd2d9ea5c93f"), new DateTime(2024, 5, 29, 12, 39, 14, 994, DateTimeKind.Utc).AddTicks(4942), new Guid("b3099f97-b15d-41ae-b741-8a434354b604"), "This is a sample comment 3." },
                    { new Guid("9bd87f5d-1d18-47ad-b4a6-5920eecf6419"), new DateTime(2024, 5, 29, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4936), new Guid("2331975a-8c2e-4f35-9de2-61c79f6ffdf0"), "This is a sample comment 1." }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "RequestId" },
                values: new object[,]
                {
                    { new Guid("38584614-4726-44e9-8417-7546e4375a90"), new Guid("b3099f97-b15d-41ae-b741-8a434354b604") },
                    { new Guid("b645f67e-e671-4b87-946e-dfbbfc94055a"), new Guid("75b0911d-b08f-4129-b005-759980534a69") },
                    { new Guid("db26ef54-2b17-4aea-b31d-05a140b726ac"), new Guid("2331975a-8c2e-4f35-9de2-61c79f6ffdf0") },
                    { new Guid("fb63c831-346f-4705-991e-bdef6c86e741"), new Guid("2afa5cce-fbcb-45ff-8f5c-96c5c911075d") }
                });
        }
    }
}
