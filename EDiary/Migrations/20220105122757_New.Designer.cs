﻿// <auto-generated />
using System;
using EDiary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EDiary.Migrations
{
    [DbContext(typeof(EDContext))]
    [Migration("20220105122757_New")]
    partial class New
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EDiary.Models.Admin", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adminRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("adminUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("adminId");

                    b.HasIndex("adminRole");

                    b.HasIndex("adminUser");

                    b.ToTable("admins");

                    b.HasData(
                        new
                        {
                            adminId = 1,
                            adminRole = "admin",
                            adminUser = "4"
                        });
                });

            modelBuilder.Entity("EDiary.Models.Lesson", b =>
                {
                    b.Property<int>("lessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("lessonDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("tsubjectId")
                        .HasColumnType("int");

                    b.HasKey("lessonId");

                    b.HasIndex("tsubjectId");

                    b.ToTable("lessons");
                });

            modelBuilder.Entity("EDiary.Models.Mark", b =>
                {
                    b.Property<int>("markId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("mark")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("markId");

                    b.ToTable("marks");
                });

            modelBuilder.Entity("EDiary.Models.Student", b =>
                {
                    b.Property<int>("studentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("studentGroup")
                        .HasColumnType("int");

                    b.Property<string>("studentLastname")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("studentName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<byte[]>("studentPic")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("studentRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("studentSurname")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("studentUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("studentId");

                    b.HasIndex("studentGroup");

                    b.HasIndex("studentRole");

                    b.HasIndex("studentUser");

                    b.ToTable("students");

                    b.HasData(
                        new
                        {
                            studentId = 1,
                            studentGroup = 2,
                            studentLastname = "Андреевич",
                            studentName = "Александр",
                            studentRole = "student",
                            studentSurname = "Купреенко",
                            studentUser = "3"
                        },
                        new
                        {
                            studentId = 2,
                            studentGroup = 2,
                            studentLastname = "Александровна",
                            studentName = "Валерия",
                            studentRole = "student",
                            studentSurname = "Липская",
                            studentUser = "9"
                        });
                });

            modelBuilder.Entity("EDiary.Models.Subject", b =>
                {
                    b.Property<int>("subjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("subjectName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("subjectId");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("EDiary.Models.Teacher", b =>
                {
                    b.Property<int>("teacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("teacherLastname")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("teacherName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<byte[]>("teacherPic")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("teacherRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("teacherSurname")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("teacherUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("teacherId");

                    b.HasIndex("teacherRole");

                    b.HasIndex("teacherUser");

                    b.ToTable("teachers");

                    b.HasData(
                        new
                        {
                            teacherId = 1,
                            teacherLastname = "Владимировна",
                            teacherName = "Валентина",
                            teacherRole = "teacher",
                            teacherSurname = "Тынкович",
                            teacherUser = "1"
                        },
                        new
                        {
                            teacherId = 2,
                            teacherLastname = "Александровна",
                            teacherName = "Екатерина",
                            teacherRole = "teacher",
                            teacherSurname = "Лазицкас",
                            teacherUser = "2"
                        },
                        new
                        {
                            teacherId = 3,
                            teacherLastname = "Николаевна",
                            teacherName = "Ольга",
                            teacherRole = "teacher",
                            teacherSurname = "Терешко",
                            teacherUser = "5"
                        },
                        new
                        {
                            teacherId = 4,
                            teacherLastname = "Александрович",
                            teacherName = "Сергей",
                            teacherRole = "teacher",
                            teacherSurname = "Апанасевич",
                            teacherUser = "6"
                        },
                        new
                        {
                            teacherId = 5,
                            teacherLastname = "Валерьевна",
                            teacherName = "Дарья",
                            teacherRole = "teacher",
                            teacherSurname = "Карпович",
                            teacherUser = "7"
                        },
                        new
                        {
                            teacherId = 6,
                            teacherLastname = "Владимировна",
                            teacherName = "Анастасия",
                            teacherRole = "teacher",
                            teacherSurname = "Гордеюк",
                            teacherUser = "8"
                        });
                });

            modelBuilder.Entity("EDiary.Models.collegeGroup", b =>
                {
                    b.Property<int>("groupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("curatorId")
                        .HasColumnType("int");

                    b.Property<string>("groupName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("groupId");

                    b.HasIndex("curatorId");

                    b.ToTable("groups");

                    b.HasData(
                        new
                        {
                            groupId = 1,
                            curatorId = 6,
                            groupName = "8к2491"
                        },
                        new
                        {
                            groupId = 2,
                            curatorId = 2,
                            groupName = "8к2492"
                        },
                        new
                        {
                            groupId = 3,
                            curatorId = 5,
                            groupName = "8к2493"
                        });
                });

            modelBuilder.Entity("EDiary.Models.setMark", b =>
                {
                    b.Property<int>("setmarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("lessonId")
                        .HasColumnType("int");

                    b.Property<int>("markId")
                        .HasColumnType("int");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("setmarkId");

                    b.HasIndex("lessonId");

                    b.HasIndex("markId");

                    b.HasIndex("studentId");

                    b.ToTable("setMarks");
                });

            modelBuilder.Entity("EDiary.Models.subjectTaught", b =>
                {
                    b.Property<int>("tsubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.Property<int>("teacherId")
                        .HasColumnType("int");

                    b.HasKey("tsubjectId");

                    b.HasIndex("groupId");

                    b.HasIndex("subjectId");

                    b.HasIndex("teacherId");

                    b.ToTable("subjectTaughts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "admin",
                            ConcurrencyStamp = "aa23bea4-e585-4cff-afda-245852dee491",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "teacher",
                            ConcurrencyStamp = "23b87f12-170b-43d9-ac1a-60b93641f606",
                            Name = "teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = "student",
                            ConcurrencyStamp = "9054f801-b92b-4db9-8185-a9815ee9caa2",
                            Name = "student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1912d316-b9fb-4cc9-82f3-3dd7eac01aae",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "TR000001",
                            PasswordHash = "AQAAAAEAACcQAAAAED04ISWqjADxRi5dmfJmNU1C9IVzQ5uRc66IY5B2YFne4BUFx5jjwNxiVYKQ/nsD1A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c4332d0e-1a3e-4163-a9c8-742b0b5b0524",
                            TwoFactorEnabled = false,
                            UserName = "tr000001"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fdab9e34-b6e3-4272-a63e-bbd4acf3a795",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "TR000002",
                            PasswordHash = "AQAAAAEAACcQAAAAEEboihG0gyGOftBbocu/PRVekkHyP2VGKr75PmrFznoGimyF5TfZhlEbXGnMALniqQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d24e8397-18bc-4f58-8cc9-170010e6343b",
                            TwoFactorEnabled = false,
                            UserName = "tr000002"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "296518e8-a14a-4a9d-a0f4-84b1bba5bfe8",
                            Email = "kuper2468@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "ST000001",
                            PasswordHash = "AQAAAAEAACcQAAAAEG7Xj+SJf188Jsd3YecheDfz1E/6R7yOHJU53IaSGOihEjuyaZel3cgCdKrkGr1Fag==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2018ed4d-efeb-4a3e-b002-faa9589b97fa",
                            TwoFactorEnabled = false,
                            UserName = "st000001"
                        },
                        new
                        {
                            Id = "9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6220a04a-93a2-4c29-beed-227725116884",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "ST000002",
                            PasswordHash = "AQAAAAEAACcQAAAAEDSxUmSSqS2zgnmMp/TWQgscUwSpxuBA/7FaHAdFtymwnuhNlvVu+iCWsHCI6ym5vw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ac68bc80-7311-4a2f-bc2d-80716e04f88d",
                            TwoFactorEnabled = false,
                            UserName = "st000002"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4f7eb3e9-1d7d-4a68-a1df-8aa49276585f",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEAdVJPJg0lJWTW+AI4vKpfqh3m02srHuBaS73HgKHlk+LZfEBpPfHy1fkdahw7wz2A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ec4af896-65cc-4a20-bb81-d897341c807a",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d6a9d4d9-b85a-4fea-82ad-4f1644415918",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "TR000003",
                            PasswordHash = "AQAAAAEAACcQAAAAEPdT1H0lcN+vxqs+OrZ2XAMUiW0nwQpZflvOjD4uDtimTOr9ewBNqKrJVhx5lSMJLQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "73acb203-815e-4b2b-bf95-3baeec502415",
                            TwoFactorEnabled = false,
                            UserName = "tr000003"
                        },
                        new
                        {
                            Id = "6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6b6ffb5d-bbbb-4360-9ee5-c94ed329cfcb",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "TR000004",
                            PasswordHash = "AQAAAAEAACcQAAAAEHLEu51VCCuZLxbp2gtKDC9cIPGe95fb0UL/LWAcDGBJeLfj+S+Aa4StxvDLZzlGww==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0a0fbbb5-592a-416f-91bf-f311732a437b",
                            TwoFactorEnabled = false,
                            UserName = "tr000004"
                        },
                        new
                        {
                            Id = "7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6c58e395-b119-404d-b334-88e169e621dc",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "TR000005",
                            PasswordHash = "AQAAAAEAACcQAAAAEEoY0isyUpKI691r9XQWMi89F3XytQRXjxm82kQJZ75t2yCjEiSoaqi0D9XsaewGCA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6c380747-2a9f-471c-945a-e5ade3aef3c3",
                            TwoFactorEnabled = false,
                            UserName = "tr000005"
                        },
                        new
                        {
                            Id = "8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bb4ef528-c881-4821-af51-a3ec4ab0d08e",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "TR000006",
                            PasswordHash = "AQAAAAEAACcQAAAAEFfJuzBlAMqPhtgjoq4f5Lx/L9+ETdIkWOL0fDqztZnMl7z7CcDPMuwR8JeHlefEdA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d583f79e-5906-443c-9cb2-a8ee4fb37315",
                            TwoFactorEnabled = false,
                            UserName = "tr000006"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EDiary.Models.Admin", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "role")
                        .WithMany()
                        .HasForeignKey("adminRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "adUser")
                        .WithMany()
                        .HasForeignKey("adminUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("adUser");

                    b.Navigation("role");
                });

            modelBuilder.Entity("EDiary.Models.Lesson", b =>
                {
                    b.HasOne("EDiary.Models.subjectTaught", "subjectTaught")
                        .WithMany()
                        .HasForeignKey("tsubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("subjectTaught");
                });

            modelBuilder.Entity("EDiary.Models.Student", b =>
                {
                    b.HasOne("EDiary.Models.collegeGroup", "group")
                        .WithMany()
                        .HasForeignKey("studentGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "role")
                        .WithMany()
                        .HasForeignKey("studentRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "user")
                        .WithMany()
                        .HasForeignKey("studentUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("group");

                    b.Navigation("role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EDiary.Models.Teacher", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "role")
                        .WithMany()
                        .HasForeignKey("teacherRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "user")
                        .WithMany()
                        .HasForeignKey("teacherUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EDiary.Models.collegeGroup", b =>
                {
                    b.HasOne("EDiary.Models.Teacher", "teacher")
                        .WithMany()
                        .HasForeignKey("curatorId");

                    b.Navigation("teacher");
                });

            modelBuilder.Entity("EDiary.Models.setMark", b =>
                {
                    b.HasOne("EDiary.Models.Lesson", "lesson")
                        .WithMany()
                        .HasForeignKey("lessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDiary.Models.Mark", "mark")
                        .WithMany()
                        .HasForeignKey("markId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDiary.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lesson");

                    b.Navigation("mark");

                    b.Navigation("student");
                });

            modelBuilder.Entity("EDiary.Models.subjectTaught", b =>
                {
                    b.HasOne("EDiary.Models.collegeGroup", "group")
                        .WithMany()
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDiary.Models.Subject", "subject")
                        .WithMany()
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EDiary.Models.Teacher", "teacher")
                        .WithMany()
                        .HasForeignKey("teacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("group");

                    b.Navigation("subject");

                    b.Navigation("teacher");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
