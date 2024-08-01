Build started...
Build succeeded.
The Entity Framework tools version '8.0.3' is older than that of the runtime '8.0.4'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Users" (
    "Login" character varying(256) NOT NULL,
    "Nickname" character varying(256) NOT NULL,
    "AvatarImage" character varying(50) NOT NULL,
    "Role" character varying(128) NOT NULL,
    "Refresh" character varying(64) NOT NULL,
    "RefreshExpire" timestamp without time zone NOT NULL,
    "Password" character varying(128) NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Login")
);

CREATE TABLE "Activities" (
    "Id" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
    "Preview" character varying(50) NOT NULL,
    "Datetime" timestamp without time zone NOT NULL,
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
    "DateTime" timestamp without time zone NOT NULL,
    "Status" character varying(16) NOT NULL,
    CONSTRAINT "PK_VerificationRequests" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_VerificationRequests_Users_OwnerLogin" FOREIGN KEY ("OwnerLogin") REFERENCES "Users" ("Login") ON DELETE CASCADE
);

CREATE TABLE "Achievements" (
    "Id" uuid NOT NULL,
    "Score" real NOT NULL,
    "VerificationDatetime" timestamp without time zone NOT NULL,
    "RequestId" uuid NOT NULL,
    "AdminLogin" character varying(256) NOT NULL,
    CONSTRAINT "PK_Achievements" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Achievements_Users_AdminLogin" FOREIGN KEY ("AdminLogin") REFERENCES "Users" ("Login") ON DELETE CASCADE,
    CONSTRAINT "FK_Achievements_VerificationRequests_RequestId" FOREIGN KEY ("RequestId") REFERENCES "VerificationRequests" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Comments" (
    "Id" uuid NOT NULL,
    "Datetime" timestamp without time zone NOT NULL,
    "Text" character varying(2000) NOT NULL,
    "RequestId" uuid NOT NULL,
    CONSTRAINT "PK_Comments" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Comments_VerificationRequests_RequestId" FOREIGN KEY ("RequestId") REFERENCES "VerificationRequests" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Images" (
    "FileName" character varying(50) NOT NULL,
    "RequestId" uuid NOT NULL,
    CONSTRAINT "PK_Images" PRIMARY KEY ("FileName"),
    CONSTRAINT "FK_Images_VerificationRequests_RequestId" FOREIGN KEY ("RequestId") REFERENCES "VerificationRequests" ("Id") ON DELETE CASCADE
);

INSERT INTO "Users" ("Login", "AvatarImage", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('admin', '00000000-0000-0000-0000-000000000000', 'Administrator', '$2a$11$QBOwTM/1G3zIqQBll7vQDel21tMOmMngs20z0bxrVLEqxyY3tHT02', '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', TIMESTAMP '2024-08-31T01:37:12.109837', 'Admin');
INSERT INTO "Users" ("Login", "AvatarImage", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('user1', '00000000-0000-0000-0000-000000000000', 'User One', '$2a$11$b63c2UhfmVGeeUWTnHlas.bk32AEQffYtnGdcX.NT0vzlNCLdZZVm', '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', TIMESTAMP '2024-08-31T01:37:12.109838', 'User');
INSERT INTO "Users" ("Login", "AvatarImage", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('user2', '00000000-0000-0000-0000-000000000000', 'User Two', '$2a$11$PW7Dapz13EKI/xGqXjK.Y.DJgkGU39nz79UQyUr6bc4I1UNoUJCey', '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', TIMESTAMP '2024-08-31T01:37:12.109838', 'User');
INSERT INTO "Users" ("Login", "AvatarImage", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('user3', '00000000-0000-0000-0000-000000000000', 'User Three', '$2a$11$ACFe85jXeKSHr7m3uycOsu4QN9/FbLb/YgTQ/v7UlR22DvoSX5gbW', '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', TIMESTAMP '2024-08-31T01:37:12.109844', 'User');

INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name", "Preview")
VALUES ('49dbe9e4-9448-4633-b20c-d0d0740186d0', 'admin', TIMESTAMP '2024-08-01T00:37:12.10988', 'http://example.com/activity2', 'Sample Activity 2', '00000000-0000-0000-0000-000000000000');
INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name", "Preview")
VALUES ('a08c574b-ea04-439c-8dc2-a8a8d269894b', 'admin', TIMESTAMP '2024-07-31T23:37:12.109881', 'http://example.com/activity3', 'Sample Activity 3', '00000000-0000-0000-0000-000000000000');
INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name", "Preview")
VALUES ('be05aabd-8489-40e4-b8f8-30c7030e3500', 'admin', TIMESTAMP '2024-08-01T01:37:12.10988', 'http://example.com/activity1', 'Sample Activity 1', '00000000-0000-0000-0000-000000000000');

INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "OwnerLogin", "Status")
VALUES ('2e754ad1-58a6-4d4c-b821-923c230973ba', TIMESTAMP '2024-07-31T23:37:12.109871', 'Sample verification request description 2', 'Sample Event 2', 'user2', 'Approved');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "OwnerLogin", "Status")
VALUES ('318fd119-df20-4e3d-86dc-e75f3ba95440', TIMESTAMP '2024-07-31T21:37:12.109872', 'Sample verification request description 4', 'Sample Event 4', 'user3', 'InProgress');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "OwnerLogin", "Status")
VALUES ('793a4459-5027-4387-bec4-9e394e632d9a', TIMESTAMP '2024-08-01T01:37:12.109869', 'Sample verification request description 1', 'Sample Event 1', 'user1', 'Approved');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "OwnerLogin", "Status")
VALUES ('7b14ca69-5352-471c-9f65-b9fd655c5b07', TIMESTAMP '2024-07-31T21:37:12.109871', 'Sample verification request description 3', 'Sample Event 3', 'user2', 'Approved');

INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('5f1f8a13-7234-4d2e-8818-ec3372b9e297', 'admin', '793a4459-5027-4387-bec4-9e394e632d9a', 95.5, TIMESTAMP '2024-08-01T01:37:12.109875');
INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('f2fae233-6521-413b-acf4-c199fbfe9011', 'admin', '7b14ca69-5352-471c-9f65-b9fd655c5b07', 92.3, TIMESTAMP '2024-07-31T23:37:12.109876');
INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('fdaf067f-4ecb-4090-814a-7c8e34342182', 'admin', '2e754ad1-58a6-4d4c-b821-923c230973ba', 88, TIMESTAMP '2024-08-01T00:37:12.109876');

INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('76762e47-63e0-403d-af9f-0fbf508a7a86', TIMESTAMP '2024-07-31T23:37:12.109886', '7b14ca69-5352-471c-9f65-b9fd655c5b07', 'This is a sample comment 3.');
INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('a5603c74-14b4-4504-976f-ed98044b221b', TIMESTAMP '2024-08-01T01:37:12.109885', '793a4459-5027-4387-bec4-9e394e632d9a', 'This is a sample comment 1.');
INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('b12da4cd-6990-41c5-bd62-dc8c78b294d9', TIMESTAMP '2024-08-01T00:37:12.109885', '2e754ad1-58a6-4d4c-b821-923c230973ba', 'This is a sample comment 2.');

INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('642b33aa-4696-4578-9fe3-a7e4affbf441', '2e754ad1-58a6-4d4c-b821-923c230973ba');
INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('72ae54df-3dee-4d56-932c-fe8fe1768dfa', '7b14ca69-5352-471c-9f65-b9fd655c5b07');
INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('a167d1ab-afe9-434d-9f2d-bafc34f1e085', '793a4459-5027-4387-bec4-9e394e632d9a');
INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('a92094d9-a3da-4e4b-b5ac-30a2d5e9ecec', '318fd119-df20-4e3d-86dc-e75f3ba95440');

CREATE INDEX "IX_Achievements_AdminLogin" ON "Achievements" ("AdminLogin");

CREATE INDEX "IX_Achievements_RequestId" ON "Achievements" ("RequestId");

CREATE INDEX "IX_Activities_AdminLogin" ON "Activities" ("AdminLogin");

CREATE INDEX "IX_Comments_RequestId" ON "Comments" ("RequestId");

CREATE INDEX "IX_Images_RequestId" ON "Images" ("RequestId");

CREATE INDEX "IX_VerificationRequests_OwnerLogin" ON "VerificationRequests" ("OwnerLogin");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240801013712_Init', '8.0.4');

COMMIT;


