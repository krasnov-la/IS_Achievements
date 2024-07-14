﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240714142722_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Models.Achievement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdminLogin")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.Property<DateTime>("VerificationDatetime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AdminLogin");

                    b.HasIndex("RequestId");

                    b.ToTable("Achievements");

                    b.HasData(
                        new
                        {
                            Id = new Guid("265c2de4-c75b-4b88-9ce8-a42e62031ff2"),
                            AdminLogin = "admin",
                            RequestId = new Guid("a2fd4433-c8f6-497e-b5c9-1596a1e00832"),
                            Score = 95.5f,
                            VerificationDatetime = new DateTime(2024, 7, 14, 14, 27, 21, 404, DateTimeKind.Utc).AddTicks(639)
                        },
                        new
                        {
                            Id = new Guid("35f57901-f7ec-4662-912a-11081507c27f"),
                            AdminLogin = "admin",
                            RequestId = new Guid("2238eb35-8c92-4dce-8ed1-8d0ca6a29aeb"),
                            Score = 88f,
                            VerificationDatetime = new DateTime(2024, 7, 14, 13, 27, 21, 404, DateTimeKind.Utc).AddTicks(643)
                        },
                        new
                        {
                            Id = new Guid("e14b2240-aca5-426e-8a01-2d59a8125fa0"),
                            AdminLogin = "admin",
                            RequestId = new Guid("678f12ee-7528-45b4-adda-e9733e77f9e6"),
                            Score = 92.3f,
                            VerificationDatetime = new DateTime(2024, 7, 14, 12, 27, 21, 404, DateTimeKind.Utc).AddTicks(648)
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdminLogin")
                        .IsRequired()
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(2100)
                        .HasColumnType("character varying(2100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Preview")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("AdminLogin");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0de4ad0b-3ef9-4ef1-98c9-0356c4d905bb"),
                            AdminLogin = "admin",
                            Datetime = new DateTime(2024, 7, 14, 14, 27, 21, 404, DateTimeKind.Utc).AddTicks(735),
                            Link = "http://example.com/activity1",
                            Name = "Sample Activity 1",
                            Preview = "00000000-0000-0000-0000-000000000000"
                        },
                        new
                        {
                            Id = new Guid("5a1c1ab2-011c-4389-bdff-282aceefce6e"),
                            AdminLogin = "admin",
                            Datetime = new DateTime(2024, 7, 14, 13, 27, 21, 404, DateTimeKind.Utc).AddTicks(746),
                            Link = "http://example.com/activity2",
                            Name = "Sample Activity 2",
                            Preview = "00000000-0000-0000-0000-000000000000"
                        },
                        new
                        {
                            Id = new Guid("9c7a598d-1392-4381-8edd-e896d380b7fc"),
                            AdminLogin = "admin",
                            Datetime = new DateTime(2024, 7, 14, 12, 27, 21, 404, DateTimeKind.Utc).AddTicks(753),
                            Link = "http://example.com/activity3",
                            Name = "Sample Activity 3",
                            Preview = "00000000-0000-0000-0000-000000000000"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b2f79a4f-936c-446f-8dc7-bd8344b94b8a"),
                            Datetime = new DateTime(2024, 7, 14, 14, 27, 21, 404, DateTimeKind.Utc).AddTicks(829),
                            RequestId = new Guid("a2fd4433-c8f6-497e-b5c9-1596a1e00832"),
                            Text = "This is a sample comment 1."
                        },
                        new
                        {
                            Id = new Guid("27f6fb52-4e82-44b5-bc56-7ac01a8401bb"),
                            Datetime = new DateTime(2024, 7, 14, 13, 27, 21, 404, DateTimeKind.Utc).AddTicks(835),
                            RequestId = new Guid("2238eb35-8c92-4dce-8ed1-8d0ca6a29aeb"),
                            Text = "This is a sample comment 2."
                        },
                        new
                        {
                            Id = new Guid("0441411b-4627-4b3c-aaba-9b6f9cdf168c"),
                            Datetime = new DateTime(2024, 7, 14, 12, 27, 21, 404, DateTimeKind.Utc).AddTicks(841),
                            RequestId = new Guid("678f12ee-7528-45b4-adda-e9733e77f9e6"),
                            Text = "This is a sample comment 3."
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Image", b =>
                {
                    b.Property<string>("FileName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uuid");

                    b.HasKey("FileName");

                    b.HasIndex("RequestId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            FileName = "45fecdab-ac5c-41a7-aa50-ba1a0e2c4d0b",
                            RequestId = new Guid("a2fd4433-c8f6-497e-b5c9-1596a1e00832")
                        },
                        new
                        {
                            FileName = "2e910ebc-3c30-49bb-9b3f-8cd9d04487b9",
                            RequestId = new Guid("2238eb35-8c92-4dce-8ed1-8d0ca6a29aeb")
                        },
                        new
                        {
                            FileName = "ed54b1ca-9625-4de8-acb6-1ccd87479082",
                            RequestId = new Guid("678f12ee-7528-45b4-adda-e9733e77f9e6")
                        },
                        new
                        {
                            FileName = "75bd1119-b00a-416c-aeed-cb5b6c2bf8da",
                            RequestId = new Guid("3219160c-0333-4ed7-836c-33652c720a3a")
                        });
                });

            modelBuilder.Entity("DataAccess.Models.User", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("AvatarImage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Refresh")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime>("RefreshExpire")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Login");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Login = "admin",
                            AvatarImage = "00000000-0000-0000-0000-000000000000",
                            Nickname = "Administrator",
                            Password = "$2a$11$QBOwTM/1G3zIqQBll7vQDel21tMOmMngs20z0bxrVLEqxyY3tHT02",
                            Refresh = "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b",
                            RefreshExpire = new DateTime(2024, 8, 13, 14, 27, 21, 403, DateTimeKind.Utc).AddTicks(7988),
                            Role = "Admin"
                        },
                        new
                        {
                            Login = "user1",
                            AvatarImage = "00000000-0000-0000-0000-000000000000",
                            Nickname = "User One",
                            Password = "$2a$11$b63c2UhfmVGeeUWTnHlas.bk32AEQffYtnGdcX.NT0vzlNCLdZZVm",
                            Refresh = "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b",
                            RefreshExpire = new DateTime(2024, 8, 13, 14, 27, 21, 403, DateTimeKind.Utc).AddTicks(8003),
                            Role = "User"
                        },
                        new
                        {
                            Login = "user2",
                            AvatarImage = "00000000-0000-0000-0000-000000000000",
                            Nickname = "User Two",
                            Password = "$2a$11$PW7Dapz13EKI/xGqXjK.Y.DJgkGU39nz79UQyUr6bc4I1UNoUJCey",
                            Refresh = "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b",
                            RefreshExpire = new DateTime(2024, 8, 13, 14, 27, 21, 403, DateTimeKind.Utc).AddTicks(8010),
                            Role = "User"
                        },
                        new
                        {
                            Login = "user3",
                            AvatarImage = "00000000-0000-0000-0000-000000000000",
                            Nickname = "User Three",
                            Password = "$2a$11$ACFe85jXeKSHr7m3uycOsu4QN9/FbLb/YgTQ/v7UlR22DvoSX5gbW",
                            Refresh = "42af99f8-7c91-4fdb-8b72-0e12b7e6b74b",
                            RefreshExpire = new DateTime(2024, 8, 13, 14, 27, 21, 403, DateTimeKind.Utc).AddTicks(8015),
                            Role = "User"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.VerificationRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<string>("OwnerLogin")
                        .IsRequired()
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerLogin");

                    b.ToTable("VerificationRequests");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2fd4433-c8f6-497e-b5c9-1596a1e00832"),
                            DateTime = new DateTime(2024, 7, 14, 14, 27, 21, 404, DateTimeKind.Utc).AddTicks(503),
                            Description = "Sample verification request description 1",
                            EventName = "Sample Event 1",
                            IsOpen = false,
                            OwnerLogin = "user1"
                        },
                        new
                        {
                            Id = new Guid("2238eb35-8c92-4dce-8ed1-8d0ca6a29aeb"),
                            DateTime = new DateTime(2024, 7, 14, 12, 27, 21, 404, DateTimeKind.Utc).AddTicks(512),
                            Description = "Sample verification request description 2",
                            EventName = "Sample Event 2",
                            IsOpen = false,
                            OwnerLogin = "user2"
                        },
                        new
                        {
                            Id = new Guid("678f12ee-7528-45b4-adda-e9733e77f9e6"),
                            DateTime = new DateTime(2024, 7, 14, 10, 27, 21, 404, DateTimeKind.Utc).AddTicks(547),
                            Description = "Sample verification request description 3",
                            EventName = "Sample Event 3",
                            IsOpen = false,
                            OwnerLogin = "user2"
                        },
                        new
                        {
                            Id = new Guid("3219160c-0333-4ed7-836c-33652c720a3a"),
                            DateTime = new DateTime(2024, 7, 14, 10, 27, 21, 404, DateTimeKind.Utc).AddTicks(553),
                            Description = "Sample verification request description 4",
                            EventName = "Sample Event 4",
                            IsOpen = true,
                            OwnerLogin = "user3"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Achievement", b =>
                {
                    b.HasOne("DataAccess.Models.User", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminLogin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.VerificationRequest", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("DataAccess.Models.Activity", b =>
                {
                    b.HasOne("DataAccess.Models.User", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminLogin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("DataAccess.Models.Comment", b =>
                {
                    b.HasOne("DataAccess.Models.VerificationRequest", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("DataAccess.Models.Image", b =>
                {
                    b.HasOne("DataAccess.Models.VerificationRequest", "Request")
                        .WithMany("Images")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("DataAccess.Models.VerificationRequest", b =>
                {
                    b.HasOne("DataAccess.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerLogin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DataAccess.Models.VerificationRequest", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}