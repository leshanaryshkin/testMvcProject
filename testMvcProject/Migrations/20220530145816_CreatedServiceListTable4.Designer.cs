﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testMvcProject.DataBase;

namespace testMvcProject.Migrations
{
    [DbContext(typeof(DBContext2))]
    [Migration("20220530145816_CreatedServiceListTable4")]
    partial class CreatedServiceListTable4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("testMvcProject.DataBase.AdditionalService", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ServiceName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ServicePrice")
                        .HasColumnType("int");

                    b.HasKey("ServiceID");

                    b.HasIndex("ServiceName")
                        .IsUnique()
                        .HasFilter("[ServiceName] IS NOT NULL");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("testMvcProject.DataBase.Balance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("currencyBalance")
                        .HasColumnType("int");

                    b.Property<string>("currencyName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.HasIndex("currencyName")
                        .IsUnique()
                        .HasFilter("[currencyName] IS NOT NULL");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("testMvcProject.DataBase.Furniture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("costPrice")
                        .HasColumnType("int");

                    b.Property<bool>("isActualPosition")
                        .HasColumnType("bit");

                    b.Property<int>("onStock")
                        .HasColumnType("int");

                    b.Property<int>("pricePerOnce")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Furnitures");
                });

            modelBuilder.Entity("testMvcProject.DataBase.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("testMvcProject.DataBase.OrderContent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ID");

                    b.ToTable("OrderContents");
                });

            modelBuilder.Entity("testMvcProject.DataBase.Profile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("costPrice")
                        .HasColumnType("int");

                    b.Property<bool>("isActualPosition")
                        .HasColumnType("bit");

                    b.Property<int>("onStock")
                        .HasColumnType("int");

                    b.Property<int>("pricePerMeter")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("testMvcProject.DataBase.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("telephone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID");

                    b.HasIndex("telephone")
                        .IsUnique()
                        .HasFilter("[telephone] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("testMvcProject.DataBase.UserLoginPassword", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<bool>("Is_admin")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("UsersLoginsPasswords");
                });

            modelBuilder.Entity("testMvcProject.DataBase.Order", b =>
                {
                    b.HasOne("testMvcProject.DataBase.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("testMvcProject.DataBase.UserLoginPassword", b =>
                {
                    b.HasOne("testMvcProject.DataBase.User", "User")
                        .WithMany()
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
