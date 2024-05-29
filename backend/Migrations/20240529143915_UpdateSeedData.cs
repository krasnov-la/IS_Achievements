using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Password", "Refresh", "RefreshExpire" },
                values: new object[] { "AQAAAAIAAYagAAAAEETyaxS08KjbEL4Dbbk7nacWglX1RF/HtPfY9t+t/SCREycaUxAKYgdtcfaOfLhzMg==", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 6, 28, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4466) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user1",
                columns: new[] { "Password", "Refresh", "RefreshExpire" },
                values: new object[] { "AQAAAAIAAYagAAAAEETyaxS08KjbEL4Dbbk7nacWglX1RF/HtPfY9t+t/SCREycaUxAKYgdtcfaOfLhzMg==", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 6, 28, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4473) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user2",
                columns: new[] { "Password", "Refresh", "RefreshExpire" },
                values: new object[] { "AQAAAAIAAYagAAAAEETyaxS08KjbEL4Dbbk7nacWglX1RF/HtPfY9t+t/SCREycaUxAKYgdtcfaOfLhzMg==", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 6, 28, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4476) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user3",
                columns: new[] { "Password", "Refresh", "RefreshExpire" },
                values: new object[] { "AQAAAAIAAYagAAAAEETyaxS08KjbEL4Dbbk7nacWglX1RF/HtPfY9t+t/SCREycaUxAKYgdtcfaOfLhzMg==", "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b", new DateTime(2024, 6, 28, 14, 39, 14, 994, DateTimeKind.Utc).AddTicks(4478) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: new Guid("38584614-4726-44e9-8417-7546e4375a90"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b645f67e-e671-4b87-946e-dfbbfc94055a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("db26ef54-2b17-4aea-b31d-05a140b726ac"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
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

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "AdminLogin", "Datetime", "Link", "Name" },
                values: new object[,]
                {
                    { new Guid("07a9ca17-6aae-424b-875b-3fb1a60952b3"), "admin", new DateTime(2024, 5, 29, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5935), "http://example.com/activity1", "Sample Activity 1" },
                    { new Guid("6e7441a7-d3ee-4c12-90ab-849bbdfff559"), "admin", new DateTime(2024, 5, 29, 6, 17, 14, 939, DateTimeKind.Utc).AddTicks(5939), "http://example.com/activity3", "Sample Activity 3" },
                    { new Guid("9009581c-c4b1-426e-8b77-4f6fb0ffc2ae"), "admin", new DateTime(2024, 5, 29, 7, 17, 14, 939, DateTimeKind.Utc).AddTicks(5937), "http://example.com/activity2", "Sample Activity 2" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "admin",
                columns: new[] { "Password", "Refresh", "RefreshExpire" },
                values: new object[] { "admin_password", "admin_refresh_token", new DateTime(2024, 6, 28, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5665) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user1",
                columns: new[] { "Password", "Refresh", "RefreshExpire" },
                values: new object[] { "user1_password", "user1_refresh_token", new DateTime(2024, 6, 28, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5671) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user2",
                columns: new[] { "Password", "Refresh", "RefreshExpire" },
                values: new object[] { "user2_password", "user2_refresh_token", new DateTime(2024, 6, 28, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5672) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "user3",
                columns: new[] { "Password", "Refresh", "RefreshExpire" },
                values: new object[] { "user3_password", "user3_refresh_token", new DateTime(2024, 6, 28, 8, 17, 14, 939, DateTimeKind.Utc).AddTicks(5674) });

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
    }
}
