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
    "Refresh" character varying(64) NOT NULL,
    "RefreshExpire" timestamp without time zone NOT NULL,
    "Password" character varying(128) NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Login")
);

CREATE TABLE "Activities" (
    "Id" uuid NOT NULL,
    "Name" character varying(256) NOT NULL,
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
    "IsOpen" boolean NOT NULL,
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
    "FileName" text NOT NULL,
    "RequestId" uuid NOT NULL,
    CONSTRAINT "PK_Images" PRIMARY KEY ("FileName"),
    CONSTRAINT "FK_Images_VerificationRequests_RequestId" FOREIGN KEY ("RequestId") REFERENCES "VerificationRequests" ("Id") ON DELETE CASCADE
);

INSERT INTO "Users" ("Login", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('admin', 'Administrator', '$2a$11$QBOwTM/1G3zIqQBll7vQDel21tMOmMngs20z0bxrVLEqxyY3tHT02', '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', TIMESTAMP '2024-07-07T15:33:25.926426', 'Admin');
INSERT INTO "Users" ("Login", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('user1', 'User One', '$2a$11$b63c2UhfmVGeeUWTnHlas.bk32AEQffYtnGdcX.NT0vzlNCLdZZVm', '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', TIMESTAMP '2024-07-07T15:33:25.926427', 'User');
INSERT INTO "Users" ("Login", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('user2', 'User Two', '$2a$11$PW7Dapz13EKI/xGqXjK.Y.DJgkGU39nz79UQyUr6bc4I1UNoUJCey', '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', TIMESTAMP '2024-07-07T15:33:25.926427', 'User');
INSERT INTO "Users" ("Login", "Nickname", "Password", "Refresh", "RefreshExpire", "Role")
VALUES ('user3', 'User Three', '$2a$11$ACFe85jXeKSHr7m3uycOsu4QN9/FbLb/YgTQ/v7UlR22DvoSX5gbW', '42af99f8-7c91-4fdb-8b72-0e12b7e6b74b', TIMESTAMP '2024-07-07T15:33:25.926428', 'User');

INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('18dfa727-8a33-44cb-a4e1-38029ff5c197', 'admin', TIMESTAMP '2024-06-07T13:33:25.926494', 'http://example.com/activity3', 'Sample Activity 3');
INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('4293fc75-bd33-4ce2-8adc-6c58ed59d45a', 'admin', TIMESTAMP '2024-06-07T15:33:25.926492', 'http://example.com/activity1', 'Sample Activity 1');
INSERT INTO "Activities" ("Id", "AdminLogin", "Datetime", "Link", "Name")
VALUES ('fefacaab-abcd-4ddd-822b-77834ab388bb', 'admin', TIMESTAMP '2024-06-07T14:33:25.926493', 'http://example.com/activity2', 'Sample Activity 2');

INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('07ca9911-9553-425c-aa1c-c0843d524f46', TIMESTAMP '2024-06-07T11:33:25.926472', 'Sample verification request description 4', 'Sample Event 4', TRUE, 'user3');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('34f6a61f-3e13-4dfc-9340-759c8ee147bd', TIMESTAMP '2024-06-07T11:33:25.926472', 'Sample verification request description 3', 'Sample Event 3', FALSE, 'user2');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('620859cd-4ed4-451d-b1e9-be0d9cec8ad5', TIMESTAMP '2024-06-07T15:33:25.926468', 'Sample verification request description 1', 'Sample Event 1', FALSE, 'user1');
INSERT INTO "VerificationRequests" ("Id", "DateTime", "Description", "EventName", "IsOpen", "OwnerLogin")
VALUES ('88e1ab02-9b81-42a1-9f0c-1454b08e678f', TIMESTAMP '2024-06-07T13:33:25.926469', 'Sample verification request description 2', 'Sample Event 2', FALSE, 'user2');

INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('2562254f-9425-42b2-b181-0a1440d74749', 'admin', '88e1ab02-9b81-42a1-9f0c-1454b08e678f', 88, TIMESTAMP '2024-06-07T14:33:25.926482');
INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('256742f7-f3e4-411d-baa4-06def7e0e38a', 'admin', '620859cd-4ed4-451d-b1e9-be0d9cec8ad5', 95.5, TIMESTAMP '2024-06-07T15:33:25.926482');
INSERT INTO "Achievements" ("Id", "AdminLogin", "RequestId", "Score", "VerificationDatetime")
VALUES ('3400efb5-d8dc-4da0-8663-ac812128ea08', 'admin', '34f6a61f-3e13-4dfc-9340-759c8ee147bd', 92.3, TIMESTAMP '2024-06-07T13:33:25.926483');

INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('24c0d96d-30e8-4ef9-a409-87cdc1ab46d7', TIMESTAMP '2024-06-07T14:33:25.926503', '88e1ab02-9b81-42a1-9f0c-1454b08e678f', 'This is a sample comment 2.');
INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('5b8dca55-bf4a-4256-8cbd-49548177efc3', TIMESTAMP '2024-06-07T15:33:25.926502', '620859cd-4ed4-451d-b1e9-be0d9cec8ad5', 'This is a sample comment 1.');
INSERT INTO "Comments" ("Id", "Datetime", "RequestId", "Text")
VALUES ('6faa9405-264c-4e1f-b38f-ddbadb4c6c09', TIMESTAMP '2024-06-07T13:33:25.926503', '34f6a61f-3e13-4dfc-9340-759c8ee147bd', 'This is a sample comment 3.');

INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('578cc1e8-cd47-4e63-b045-fd661a63affb', '620859cd-4ed4-451d-b1e9-be0d9cec8ad5');
INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('95806d77-3214-4a78-96c5-d2ada6d311fc', '34f6a61f-3e13-4dfc-9340-759c8ee147bd');
INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('a54e6d85-dc0c-4114-8e6f-5600ff69b9c7', '88e1ab02-9b81-42a1-9f0c-1454b08e678f');
INSERT INTO "Images" ("FileName", "RequestId")
VALUES ('f772f9b2-a484-46de-91d1-3b9ab31d24b4', '07ca9911-9553-425c-aa1c-c0843d524f46');

CREATE INDEX "IX_Achievements_AdminLogin" ON "Achievements" ("AdminLogin");

CREATE INDEX "IX_Achievements_RequestId" ON "Achievements" ("RequestId");

CREATE INDEX "IX_Activities_AdminLogin" ON "Activities" ("AdminLogin");

CREATE INDEX "IX_Comments_RequestId" ON "Comments" ("RequestId");

CREATE INDEX "IX_Images_RequestId" ON "Images" ("RequestId");

CREATE INDEX "IX_VerificationRequests_OwnerLogin" ON "VerificationRequests" ("OwnerLogin");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240607153326_init', '8.0.4');

COMMIT;

