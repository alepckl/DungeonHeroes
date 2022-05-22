﻿// <auto-generated />
using System;
using DungeonHeros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DbContext = DungeonHeros.Models.DbContext;

#nullable disable

namespace DungeonHeros.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20220514205233_heroClasseRaceLink")]
    partial class heroClasseRaceLink
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.3.22175.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DungeonHeros.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"), 1L, 1);

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            ClassName = "Magician"
                        },
                        new
                        {
                            ClassId = 2,
                            ClassName = "Thief"
                        },
                        new
                        {
                            ClassId = 3,
                            ClassName = "Warrior"
                        },
                        new
                        {
                            ClassId = 4,
                            ClassName = "Archer"
                        });
                });

            modelBuilder.Entity("DungeonHeros.Models.Dungeon", b =>
                {
                    b.Property<int>("DungeonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DungeonId"), 1L, 1);

                    b.Property<string>("DungeonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DungeonId");

                    b.ToTable("Dungeons");
                });

            modelBuilder.Entity("DungeonHeros.Models.Hero", b =>
                {
                    b.Property<int>("HeroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HeroId"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Level")
                        .HasColumnType("float");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("Stamina")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("HeroId");

                    b.HasIndex("ClassId");

                    b.HasIndex("RaceId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("DungeonHeros.Models.Monster", b =>
                {
                    b.Property<int>("MonsterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonsterId"), 1L, 1);

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonsterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("Stamina")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("MonsterId");

                    b.ToTable("Monsters");

                    b.HasData(
                        new
                        {
                            MonsterId = 1,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Spider",
                            RaceId = 6,
                            Stamina = 2,
                            Strength = 2
                        },
                        new
                        {
                            MonsterId = 2,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Ogre",
                            RaceId = 7,
                            Stamina = 3,
                            Strength = 1
                        },
                        new
                        {
                            MonsterId = 3,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Grougaloragran",
                            RaceId = 5,
                            Stamina = 12,
                            Strength = 4
                        },
                        new
                        {
                            MonsterId = 4,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Serwaul",
                            RaceId = 8,
                            Stamina = 1,
                            Strength = 7
                        },
                        new
                        {
                            MonsterId = 5,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Bat",
                            RaceId = 6,
                            Stamina = 2,
                            Strength = 1
                        },
                        new
                        {
                            MonsterId = 6,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Giant Wolf",
                            RaceId = 6,
                            Stamina = 3,
                            Strength = 4
                        },
                        new
                        {
                            MonsterId = 7,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Efrit",
                            RaceId = 7,
                            Stamina = 4,
                            Strength = 4
                        },
                        new
                        {
                            MonsterId = 8,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Bone Golem",
                            RaceId = 7,
                            Stamina = 3,
                            Strength = 5
                        },
                        new
                        {
                            MonsterId = 9,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Hydra",
                            RaceId = 7,
                            Stamina = 11,
                            Strength = 5
                        },
                        new
                        {
                            MonsterId = 10,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Kobold",
                            RaceId = 7,
                            Stamina = 4,
                            Strength = 2
                        },
                        new
                        {
                            MonsterId = 11,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Fafnir",
                            RaceId = 5,
                            Stamina = 7,
                            Strength = 9
                        },
                        new
                        {
                            MonsterId = 12,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Dark Lord",
                            RaceId = 8,
                            Stamina = 20,
                            Strength = 20
                        },
                        new
                        {
                            MonsterId = 13,
                            ImagePath = "https://eldenring.wiki.fextralife.com/file/Elden-Ring/rotten_stray_1_enemies_elden_ring_wiki_600px.jpg",
                            MonsterName = "Vouivre",
                            RaceId = 5,
                            Stamina = 15,
                            Strength = 10
                        });
                });

            modelBuilder.Entity("DungeonHeros.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RaceId"), 1L, 1);

                    b.Property<int>("IsForUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RaceId");

                    b.ToTable("Races");

                    b.HasData(
                        new
                        {
                            RaceId = 1,
                            IsForUser = 1,
                            Name = "Human"
                        },
                        new
                        {
                            RaceId = 2,
                            IsForUser = 1,
                            Name = "Dwarf"
                        },
                        new
                        {
                            RaceId = 3,
                            IsForUser = 1,
                            Name = "Elf"
                        },
                        new
                        {
                            RaceId = 4,
                            IsForUser = 1,
                            Name = "Orc"
                        },
                        new
                        {
                            RaceId = 5,
                            IsForUser = 0,
                            Name = "Dragon"
                        },
                        new
                        {
                            RaceId = 6,
                            IsForUser = 0,
                            Name = "Animal"
                        },
                        new
                        {
                            RaceId = 7,
                            IsForUser = 0,
                            Name = "Monster"
                        },
                        new
                        {
                            RaceId = 8,
                            IsForUser = 0,
                            Name = "Demon"
                        });
                });

            modelBuilder.Entity("DungeonHeros.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"), 1L, 1);

                    b.Property<string>("FounderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TeamId");

                    b.HasIndex("FounderId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DungeonMonster", b =>
                {
                    b.Property<int>("DungeonsDungeonId")
                        .HasColumnType("int");

                    b.Property<int>("MonstersMonsterId")
                        .HasColumnType("int");

                    b.HasKey("DungeonsDungeonId", "MonstersMonsterId");

                    b.HasIndex("MonstersMonsterId");

                    b.ToTable("DungeonMonster");
                });

            modelBuilder.Entity("DungeonTeam", b =>
                {
                    b.Property<int>("FightedDungeonsDungeonId")
                        .HasColumnType("int");

                    b.Property<int>("TeamFightersTeamId")
                        .HasColumnType("int");

                    b.HasKey("FightedDungeonsDungeonId", "TeamFightersTeamId");

                    b.HasIndex("TeamFightersTeamId");

                    b.ToTable("DungeonTeam");
                });

            modelBuilder.Entity("HeroTeam", b =>
                {
                    b.Property<int>("HeroesHeroId")
                        .HasColumnType("int");

                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("int");

                    b.HasKey("HeroesHeroId", "TeamsTeamId");

                    b.HasIndex("TeamsTeamId");

                    b.ToTable("HeroTeam");
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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DungeonHeros.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("HeroForeignKey")
                        .HasColumnType("int");

                    b.Property<string>("HeroName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("HeroForeignKey")
                        .IsUnique()
                        .HasFilter("[HeroForeignKey] IS NOT NULL");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("DungeonHeros.Models.Hero", b =>
                {
                    b.HasOne("DungeonHeros.Models.Class", "Class")
                        .WithMany("Heroes")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DungeonHeros.Models.Race", "Race")
                        .WithMany("Heroes")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("DungeonHeros.Models.Team", b =>
                {
                    b.HasOne("DungeonHeros.Models.User", "Founder")
                        .WithMany()
                        .HasForeignKey("FounderId");

                    b.Navigation("Founder");
                });

            modelBuilder.Entity("DungeonMonster", b =>
                {
                    b.HasOne("DungeonHeros.Models.Dungeon", null)
                        .WithMany()
                        .HasForeignKey("DungeonsDungeonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DungeonHeros.Models.Monster", null)
                        .WithMany()
                        .HasForeignKey("MonstersMonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DungeonTeam", b =>
                {
                    b.HasOne("DungeonHeros.Models.Dungeon", null)
                        .WithMany()
                        .HasForeignKey("FightedDungeonsDungeonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DungeonHeros.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamFightersTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HeroTeam", b =>
                {
                    b.HasOne("DungeonHeros.Models.Hero", null)
                        .WithMany()
                        .HasForeignKey("HeroesHeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DungeonHeros.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("DungeonHeros.Models.User", b =>
                {
                    b.HasOne("DungeonHeros.Models.Hero", "Hero")
                        .WithOne("User")
                        .HasForeignKey("DungeonHeros.Models.User", "HeroForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("DungeonHeros.Models.Class", b =>
                {
                    b.Navigation("Heroes");
                });

            modelBuilder.Entity("DungeonHeros.Models.Hero", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("DungeonHeros.Models.Race", b =>
                {
                    b.Navigation("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}
