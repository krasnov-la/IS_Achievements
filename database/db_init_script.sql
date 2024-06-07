CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Users" (
    "Login" character varying(256) NOT NULL,
    "Nickname" character varying(256) NOT NULL,
    "Role" character varying(128) NOT NULL,
    "Password" character varying(128) NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Login")
);

CREATE TABLE "Activities" (
    "Id" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
    "Datetime" timestamp with time zone NOT NULL,
    "Link" character varying(2100) NOT NULL,
    "AdminLogin" character varying(256) NOT NULL,
    CONSTRAINT "PK_Activities" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Activities_Users_AdminLogin" FOREIGN KEY ("AdminLogin") REFERENCES "Users" ("Login") ON DELETE CASCADE
);

CREATE TABLE "VerificationRequests" (
    "Id" uuid NOT NULL,
    "OwnerLogin" character varying(256) NOT NULL,
    "EventName" character varying(200) NOT NULL,
    "Description" character varying(2000) NOT NULL,
    "DateTime" timestamp with time zone NOT NULL,
    "IsOpen" boolean NOT NULL,
    CONSTRAINT "PK_VerificationRequests" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_VerificationRequests_Users_OwnerLogin" FOREIGN KEY ("OwnerLogin") REFERENCES "Users" ("Login") ON DELETE CASCADE
);

CREATE TABLE "Achievements" (
    "Id" uuid NOT NULL,
    "Score" real NOT NULL,
    "VerificationDatetime" timestamp with time zone NOT NULL,
    "RequestId" uuid NOT NULL,
    "AdminLogin" character varying(256) NOT NULL,
    CONSTRAINT "PK_Achievements" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Achievements_Users_AdminLogin" FOREIGN KEY ("AdminLogin") REFERENCES "Users" ("Login") ON DELETE CASCADE,
    CONSTRAINT "FK_Achievements_VerificationRequests_RequestId" FOREIGN KEY ("RequestId") REFERENCES "VerificationRequests" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Comments" (
    "Id" uuid NOT NULL,
    "Datetime" timestamp with time zone NOT NULL,
    "Text" character varying(2000) NOT NULL,
    "RequestId" uuid NOT NULL,
    CONSTRAINT "PK_Comments" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Comments_VerificationRequests_RequestId" FOREIGN KEY ("RequestId") REFERENCES "VerificationRequests" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Images" (
    "Id" uuid NOT NULL,
    "RequestId" uuid NOT NULL,
    CONSTRAINT "PK_Images" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Images_VerificationRequests_RequestId" FOREIGN KEY ("RequestId") REFERENCES "VerificationRequests" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Achievements_AdminLogin" ON "Achievements" ("AdminLogin");

CREATE INDEX "IX_Achievements_RequestId" ON "Achievements" ("RequestId");

CREATE INDEX "IX_Activities_AdminLogin" ON "Activities" ("AdminLogin");

CREATE INDEX "IX_Comments_RequestId" ON "Comments" ("RequestId");

CREATE INDEX "IX_Images_RequestId" ON "Images" ("RequestId");

CREATE INDEX "IX_VerificationRequests_OwnerLogin" ON "VerificationRequests" ("OwnerLogin");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240527101208_firstVerDb', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "Users" ADD "Refresh" character varying(64) NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240528132532_user_refresh', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "Users" ADD "RefreshExpire" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240528140711_refresh_exp', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "VerificationRequests" ALTER COLUMN "DateTime" TYPE timestamp without time zone;

ALTER TABLE "Users" ALTER COLUMN "RefreshExpire" TYPE timestamp without time zone;

ALTER TABLE "Comments" ALTER COLUMN "Datetime" TYPE timestamp without time zone;

ALTER TABLE "Activities" ALTER COLUMN "Datetime" TYPE timestamp without time zone;

ALTER TABLE "Achievements" ALTER COLUMN "VerificationDatetime" TYPE timestamp without time zone;

INSERT INTO "Users" ("Login", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('admin', 'Administrator', 'admin_password', 'admin_refresh_token', TIMESTAMP '2024-06-28T08:17:14.939566', 'Admin');
INSERT INTO "Users" ("Login", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('user1', 'User One', 'user1_password', 'user1_refresh_token', TIMESTAMP '2024-06-28T08:17:14.939567', 'User');
INSERT INTO "Users" ("Login", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('user2', 'User Two', 'user2_password', 'user2_refresh_token', TIMESTAMP '2024-06-28T08:17:14.939567', 'User');
INSERT INTO "Users" ("Login", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('user3', 'User Three', 'user3_password', 'user3_refresh_token', TIMESTAMP '2024-06-28T08:17:14.939567', 'User');

INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('07a9ca17-6aae-424b-875b-3fb1a60952b3', 'admin', TIMESTAMP '2024-05-29T08:17:14.939593', 'http://example.com/activity1', 'Sample Activity 1');
INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('6e7441a7-d3ee-4c12-90ab-849bbdfff559', 'admin', TIMESTAMP '2024-05-29T06:17:14.939593', 'http://example.com/activity3', 'Sample Activity 3');
INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('9009581c-c4b1-426e-8b77-4f6fb0ffc2ae', 'admin', TIMESTAMP '2024-05-29T07:17:14.939593', 'http://example.com/activity2', 'Sample Activity 2');

INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('1495665f-c673-4c99-a519-4cad151377c4', TIMESTAMP '2024-05-29T06:17:14.939586', 'Sample verification request description 2', 'Sample Event 2', FALSE, 'user2');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('54020c93-8355-4d58-a337-457d4968b9fe', TIMESTAMP '2024-05-29T04:17:14.939588', 'Sample verification request description 4', 'Sample Event 4', FALSE, 'user3');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('5a7db9e6-054a-454f-baf7-5b35b94c4f6b', TIMESTAMP '2024-05-29T08:17:14.939586', 'Sample verification request description 1', 'Sample Event 1', FALSE, 'user1');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('ea4967f7-b69a-4dcf-bb33-e86273238af2', TIMESTAMP '2024-05-29T04:17:14.939587', 'Sample verification request description 3', 'Sample Event 3', FALSE, 'user2');

INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('30e21ab5-698c-4595-af68-4705bde5c534', 'admin', 'ea4967f7-b69a-4dcf-bb33-e86273238af2', 92.3, TIMESTAMP '2024-05-29T06:17:14.939591');
INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('78fae1a7-c1e6-4a9f-8811-4948c9f390b4', 'admin', '5a7db9e6-054a-454f-baf7-5b35b94c4f6b', 95.5, TIMESTAMP '2024-05-29T08:17:14.939591');
INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('92a09857-8a63-472d-90ef-a6d81f3e12bb', 'admin', '1495665f-c673-4c99-a519-4cad151377c4', 88, TIMESTAMP '2024-05-29T07:17:14.939591');

INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('1e7edaf3-b99c-486f-bfb1-8db726edc7a4', TIMESTAMP '2024-05-29T07:17:14.939596', '1495665f-c673-4c99-a519-4cad151377c4', 'This is a sample comment 2.');
INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('51deb0d3-31f7-4e9e-b2cb-8997188167a2', TIMESTAMP '2024-05-29T08:17:14.939596', '5a7db9e6-054a-454f-baf7-5b35b94c4f6b', 'This is a sample comment 1.');
INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('f395c12e-fe57-47c9-8c9f-443b63dfe9d8', TIMESTAMP '2024-05-29T06:17:14.939596', 'ea4967f7-b69a-4dcf-bb33-e86273238af2', 'This is a sample comment 3.');

INSERT INTO "Images" ("Id", "RequestId")
VALUES ('13d3bf86-5072-48f5-8352-b563a6dd8e7e', '1495665f-c673-4c99-a519-4cad151377c4');
INSERT INTO "Images" ("Id", "RequestId")
VALUES ('303e3d6f-a792-4b5e-a6b1-3c02054accc1', '5a7db9e6-054a-454f-baf7-5b35b94c4f6b');
INSERT INTO "Images" ("Id", "RequestId")
VALUES ('df1f5b4c-cb0d-43c1-909b-3ec0f08b63bb', 'ea4967f7-b69a-4dcf-bb33-e86273238af2');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240529081715_SeedData', '8.0.4');

COMMIT;

START TRANSACTION;

DELETE FROM "Achievements"
WHERE "Id" = '30e21ab5-698c-4595-af68-4705bde5c534';

DELETE FROM "Achievements"
WHERE "Id" = '78fae1a7-c1e6-4a9f-8811-4948c9f390b4';

DELETE FROM "Achievements"
WHERE "Id" = '92a09857-8a63-472d-90ef-a6d81f3e12bb';

DELETE FROM "Activities"
WHERE "Id" = '07a9ca17-6aae-424b-875b-3fb1a60952b3';

DELETE FROM "Activities"
WHERE "Id" = '6e7441a7-d3ee-4c12-90ab-849bbdfff559';

DELETE FROM "Activities"
WHERE "Id" = '9009581c-c4b1-426e-8b77-4f6fb0ffc2ae';

DELETE FROM "Comments"
WHERE "Id" = '1e7edaf3-b99c-486f-bfb1-8db726edc7a4';

DELETE FROM "Comments"
WHERE "Id" = '51deb0d3-31f7-4e9e-b2cb-8997188167a2';

DELETE FROM "Comments"
WHERE "Id" = 'f395c12e-fe57-47c9-8c9f-443b63dfe9d8';

DELETE FROM "Images"
WHERE "Id" = '13d3bf86-5072-48f5-8352-b563a6dd8e7e';

DELETE FROM "Images"
WHERE "Id" = '303e3d6f-a792-4b5e-a6b1-3c02054accc1';

DELETE FROM "Images"
WHERE "Id" = 'df1f5b4c-cb0d-43c1-909b-3ec0f08b63bb';

DELETE FROM "VerificationRequests"
WHERE "Id" = '54020c93-8355-4d58-a337-457d4968b9fe';

DELETE FROM "VerificationRequests"
WHERE "Id" = '1495665f-c673-4c99-a519-4cad151377c4';

DELETE FROM "VerificationRequests"
WHERE "Id" = '5a7db9e6-054a-454f-baf7-5b35b94c4f6b';

DELETE FROM "VerificationRequests"
WHERE "Id" = 'ea4967f7-b69a-4dcf-bb33-e86273238af2';

INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('13498067-f6d5-4119-9177-7ef36b72baba', 'admin', TIMESTAMP '2024-05-29T14:39:14.994488', 'http://example.com/activity1', 'Sample Activity 1');
INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('16598089-f9c7-4148-8156-d053de59e77a', 'admin', TIMESTAMP '2024-05-29T12:39:14.994489', 'http://example.com/activity3', 'Sample Activity 3');
INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('51132e40-443d-41b5-a473-b8f18bfd022f', 'admin', TIMESTAMP '2024-05-29T13:39:14.994489', 'http://example.com/activity2', 'Sample Activity 2');

UPDATE "Users" SET "Password" = 'AQAAAAIAAYagAAAAEETyaxS08KjbEL4Dbbk7nacWglX1RF/HtPfY9t+t/SCREycaUxAKYgdtcfaOfLhzMg==', "Refresh" = '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', "RefreshExpire" = TIMESTAMP '2024-06-28T14:39:14.994446'
WHERE "Login" = 'admin';

UPDATE "Users" SET "Password" = 'AQAAAAIAAYagAAAAEETyaxS08KjbEL4Dbbk7nacWglX1RF/HtPfY9t+t/SCREycaUxAKYgdtcfaOfLhzMg==', "Refresh" = '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', "RefreshExpire" = TIMESTAMP '2024-06-28T14:39:14.994447'
WHERE "Login" = 'user1';

UPDATE "Users" SET "Password" = 'AQAAAAIAAYagAAAAEETyaxS08KjbEL4Dbbk7nacWglX1RF/HtPfY9t+t/SCREycaUxAKYgdtcfaOfLhzMg==', "Refresh" = '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', "RefreshExpire" = TIMESTAMP '2024-06-28T14:39:14.994447'
WHERE "Login" = 'user2';

UPDATE "Users" SET "Password" = 'AQAAAAIAAYagAAAAEETyaxS08KjbEL4Dbbk7nacWglX1RF/HtPfY9t+t/SCREycaUxAKYgdtcfaOfLhzMg==', "Refresh" = '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', "RefreshExpire" = TIMESTAMP '2024-06-28T14:39:14.994447'
WHERE "Login" = 'user3';

INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('2331975a-8c2e-4f35-9de2-61c79f6ffdf0', TIMESTAMP '2024-05-29T14:39:14.994472', 'Sample verification request description 1', 'Sample Event 1', FALSE, 'user1');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('2afa5cce-fbcb-45ff-8f5c-96c5c911075d', TIMESTAMP '2024-05-29T12:39:14.994472', 'Sample verification request description 2', 'Sample Event 2', FALSE, 'user2');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('75b0911d-b08f-4129-b005-759980534a69', TIMESTAMP '2024-05-29T10:39:14.994475', 'Sample verification request description 4', 'Sample Event 4', TRUE, 'user3');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('b3099f97-b15d-41ae-b741-8a434354b604', TIMESTAMP '2024-05-29T10:39:14.994475', 'Sample verification request description 3', 'Sample Event 3', FALSE, 'user2');

INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('0cf5d7f3-7f4b-459e-9f60-2c2dc3c69ca1', 'admin', '2afa5cce-fbcb-45ff-8f5c-96c5c911075d', 88, TIMESTAMP '2024-05-29T13:39:14.994484');
INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('66627ae3-db75-4968-be27-191471a37ea4', 'admin', 'b3099f97-b15d-41ae-b741-8a434354b604', 92.3, TIMESTAMP '2024-05-29T12:39:14.994484');
INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('e9d7de43-da2c-4987-86cf-8bb45e57c6d3', 'admin', '2331975a-8c2e-4f35-9de2-61c79f6ffdf0', 95.5, TIMESTAMP '2024-05-29T14:39:14.994484');

INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('05c52dd0-ad34-4e98-9ddc-c945ee61a695', TIMESTAMP '2024-05-29T13:39:14.994493', '2afa5cce-fbcb-45ff-8f5c-96c5c911075d', 'This is a sample comment 2.');
INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('39363588-c412-4517-ac5e-dd2d9ea5c93f', TIMESTAMP '2024-05-29T12:39:14.994494', 'b3099f97-b15d-41ae-b741-8a434354b604', 'This is a sample comment 3.');
INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('9bd87f5d-1d18-47ad-b4a6-5920eecf6419', TIMESTAMP '2024-05-29T14:39:14.994493', '2331975a-8c2e-4f35-9de2-61c79f6ffdf0', 'This is a sample comment 1.');

INSERT INTO "Images" ("Id", "RequestId")
VALUES ('38584614-4726-44e9-8417-7546e4375a90', 'b3099f97-b15d-41ae-b741-8a434354b604');
INSERT INTO "Images" ("Id", "RequestId")
VALUES ('b645f67e-e671-4b87-946e-dfbbfc94055a', '75b0911d-b08f-4129-b005-759980534a69');
INSERT INTO "Images" ("Id", "RequestId")
VALUES ('db26ef54-2b17-4aea-b31d-05a140b726ac', '2331975a-8c2e-4f35-9de2-61c79f6ffdf0');
INSERT INTO "Images" ("Id", "RequestId")
VALUES ('fb63c831-346f-4705-991e-bdef6c86e741', '2afa5cce-fbcb-45ff-8f5c-96c5c911075d');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240529143915_UpdateSeedData', '8.0.4');

COMMIT;

START TRANSACTION;

ALTER TABLE "Images" DROP CONSTRAINT "PK_Images";

DELETE FROM "Achievements"
WHERE "Id" = '0cf5d7f3-7f4b-459e-9f60-2c2dc3c69ca1';

DELETE FROM "Achievements"
WHERE "Id" = '66627ae3-db75-4968-be27-191471a37ea4';

DELETE FROM "Achievements"
WHERE "Id" = 'e9d7de43-da2c-4987-86cf-8bb45e57c6d3';

DELETE FROM "Activities"
WHERE "Id" = '13498067-f6d5-4119-9177-7ef36b72baba';

DELETE FROM "Activities"
WHERE "Id" = '16598089-f9c7-4148-8156-d053de59e77a';

DELETE FROM "Activities"
WHERE "Id" = '51132e40-443d-41b5-a473-b8f18bfd022f';

DELETE FROM "Comments"
WHERE "Id" = '05c52dd0-ad34-4e98-9ddc-c945ee61a695';

DELETE FROM "Comments"
WHERE "Id" = '39363588-c412-4517-ac5e-dd2d9ea5c93f';

DELETE FROM "Comments"
WHERE "Id" = '9bd87f5d-1d18-47ad-b4a6-5920eecf6419';

DELETE FROM "Images"
WHERE "Id" = '38584614-4726-44e9-8417-7546e4375a90';

DELETE FROM "Images"
WHERE "Id" = 'b645f67e-e671-4b87-946e-dfbbfc94055a';

DELETE FROM "Images"
WHERE "Id" = 'db26ef54-2b17-4aea-b31d-05a140b726ac';

DELETE FROM "Images"
WHERE "Id" = 'fb63c831-346f-4705-991e-bdef6c86e741';

DELETE FROM "VerificationRequests"
WHERE "Id" = '2331975a-8c2e-4f35-9de2-61c79f6ffdf0';

DELETE FROM "VerificationRequests"
WHERE "Id" = '2afa5cce-fbcb-45ff-8f5c-96c5c911075d';

DELETE FROM "VerificationRequests"
WHERE "Id" = '75b0911d-b08f-4129-b005-759980534a69';

DELETE FROM "VerificationRequests"
WHERE "Id" = 'b3099f97-b15d-41ae-b741-8a434354b604';

ALTER TABLE "Images" DROP COLUMN "Id";

ALTER TABLE "Images" ADD "FileName" text NOT NULL DEFAULT '';

ALTER TABLE "Images" ADD CONSTRAINT "PK_Images" PRIMARY KEY ("FileName");

INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('c12300c3-5bfd-43e9-874b-001ef716836a', 'admin', TIMESTAMP '2024-05-29T14:45:57.832687', 'http://example.com/activity3', 'Sample Activity 3');
INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('c8ff3cca-d3a8-4846-8aca-a156fa9905c4', 'admin', TIMESTAMP '2024-05-29T16:45:57.832686', 'http://example.com/activity1', 'Sample Activity 1');
INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('cedb16da-c3d4-406f-85c1-95fdc1b04407', 'admin', TIMESTAMP '2024-05-29T15:45:57.832687', 'http://example.com/activity2', 'Sample Activity 2');

UPDATE "Users" SET "RefreshExpire" = TIMESTAMP '2024-06-28T16:45:57.832608'
WHERE "Login" = 'admin';

UPDATE "Users" SET "RefreshExpire" = TIMESTAMP '2024-06-28T16:45:57.832609'
WHERE "Login" = 'user1';

UPDATE "Users" SET "RefreshExpire" = TIMESTAMP '2024-06-28T16:45:57.83262'
WHERE "Login" = 'user2';

UPDATE "Users" SET "RefreshExpire" = TIMESTAMP '2024-06-28T16:45:57.83262'
WHERE "Login" = 'user3';

INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('207fd7b5-d5e5-43e8-80b8-d4c672669797', TIMESTAMP '2024-05-29T12:45:57.832668', 'Sample verification request description 3', 'Sample Event 3', FALSE, 'user2');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('590f67f1-3dc0-4984-849d-7042411ee438', TIMESTAMP '2024-05-29T16:45:57.832663', 'Sample verification request description 1', 'Sample Event 1', FALSE, 'user1');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('b5778724-4834-4a5c-855c-7fdc8f26f041', TIMESTAMP '2024-05-29T12:45:57.832669', 'Sample verification request description 4', 'Sample Event 4', TRUE, 'user3');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('cb2951d9-028a-4f0b-b97e-4edea80e6023', TIMESTAMP '2024-05-29T14:45:57.832667', 'Sample verification request description 2', 'Sample Event 2', FALSE, 'user2');

INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('10178a65-ed05-45df-bb46-4233eee50705', 'admin', '590f67f1-3dc0-4984-849d-7042411ee438', 95.5, TIMESTAMP '2024-05-29T16:45:57.832677');
INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('5440db13-c5c2-4a1c-93d3-01b0a548447f', 'admin', '207fd7b5-d5e5-43e8-80b8-d4c672669797', 92.3, TIMESTAMP '2024-05-29T14:45:57.832679');
INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('cbf0502a-bf83-4012-9676-3e2a4fcacf56', 'admin', 'cb2951d9-028a-4f0b-b97e-4edea80e6023', 88, TIMESTAMP '2024-05-29T15:45:57.832678');

INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('0335093a-beec-44a7-b49a-e98e2fc49246', TIMESTAMP '2024-05-29T15:45:57.832696', 'cb2951d9-028a-4f0b-b97e-4edea80e6023', 'This is a sample comment 2.');
INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('90ec30a9-8b4d-45f3-ae51-3fcf2be63606', TIMESTAMP '2024-05-29T16:45:57.832695', '590f67f1-3dc0-4984-849d-7042411ee438', 'This is a sample comment 1.');
INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('f01a8f2c-06a3-4ef1-a4d0-315d843782cc', TIMESTAMP '2024-05-29T14:45:57.832697', '207fd7b5-d5e5-43e8-80b8-d4c672669797', 'This is a sample comment 3.');

INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('5f65d779-b75a-4e2d-82c7-af7863247a59', '590f67f1-3dc0-4984-849d-7042411ee438');
INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('8f8976f5-226f-4c2a-b21b-e7cb7990a4c8', '207fd7b5-d5e5-43e8-80b8-d4c672669797');
INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('91a15f15-a233-425e-86e5-58880814e245', 'b5778724-4834-4a5c-855c-7fdc8f26f041');
INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('a9d28d38-ac96-4106-9474-442cb75bd7a8', 'cb2951d9-028a-4f0b-b97e-4edea80e6023');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240529164600_image_id_changed', '8.0.4');

COMMIT;

