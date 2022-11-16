﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OwnApropos;

#nullable disable

namespace OwnApropos.Migrations
{
    [DbContext(typeof(MementoMoriContext))]
    [Migration("20221116060006_InitialCreateInventariesAdded")]
    partial class InitialCreateInventariesAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OwnApropos.Models.BudgetHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Action")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FillialId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FillialId");

                    b.ToTable("BudgetHistories");
                });

            modelBuilder.Entity("OwnApropos.Models.Fillial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Budget")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fillials");
                });

            modelBuilder.Entity("OwnApropos.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FillialId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FillialId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("OwnApropos.Models.Personal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FillialId")
                        .HasColumnType("int");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("TelefonNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FillialId");

                    b.ToTable("Personals");
                });

            modelBuilder.Entity("OwnApropos.Models.BudgetHistory", b =>
                {
                    b.HasOne("OwnApropos.Models.Fillial", "Fillial")
                        .WithMany()
                        .HasForeignKey("FillialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fillial");
                });

            modelBuilder.Entity("OwnApropos.Models.Inventory", b =>
                {
                    b.HasOne("OwnApropos.Models.Fillial", "Fillial")
                        .WithMany()
                        .HasForeignKey("FillialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fillial");
                });

            modelBuilder.Entity("OwnApropos.Models.Personal", b =>
                {
                    b.HasOne("OwnApropos.Models.Fillial", "Fillial")
                        .WithMany()
                        .HasForeignKey("FillialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fillial");
                });
#pragma warning restore 612, 618
        }
    }
}
