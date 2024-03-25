﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trader.EF.Db;

#nullable disable

namespace Trader.EF.Migrations
{
    [DbContext(typeof(TraderDbContext))]
    [Migration("20240325121816_addMissingColumnstoUsers")]
    partial class addMissingColumnstoUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trader.Domain.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Trader.Domain.Models.AssetTransactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPurchased")
                        .HasColumnType("bit");

                    b.Property<double>("ShareAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AssetTransactions");
                });

            modelBuilder.Entity("Trader.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateProcessed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Trader.Domain.Models.Account", b =>
                {
                    b.HasOne("Trader.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Trader.Domain.Models.AssetTransactions", b =>
                {
                    b.HasOne("Trader.Domain.Models.Account", "Account")
                        .WithMany("AssetTransactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Trader.Domain.Models.Stock", "Stock", b1 =>
                        {
                            b1.Property<Guid>("AssetTransactionsId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("PricePerShare")
                                .HasColumnType("float");

                            b1.Property<string>("Symbol")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AssetTransactionsId");

                            b1.ToTable("AssetTransactions");

                            b1.WithOwner()
                                .HasForeignKey("AssetTransactionsId");
                        });

                    b.Navigation("Account");

                    b.Navigation("Stock")
                        .IsRequired();
                });

            modelBuilder.Entity("Trader.Domain.Models.Account", b =>
                {
                    b.Navigation("AssetTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
