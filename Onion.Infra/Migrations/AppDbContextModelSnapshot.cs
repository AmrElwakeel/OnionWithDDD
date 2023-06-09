﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Onion.Infra.DbContexts;

#nullable disable

namespace Onion.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Onion.Domain.BusinessDomain.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("newid()");

                    b.Property<byte>("CustomerStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Onion.Domain.BusinessDomain.Customer", b =>
                {
                    b.OwnsOne("Onion.Domain.BusinessDomain.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasDefaultValue("")
                                .HasColumnName("city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasDefaultValue("")
                                .HasColumnName("country");

                            b1.Property<string>("State")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasDefaultValue("")
                                .HasColumnName("state");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasDefaultValue("")
                                .HasColumnName("street");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasDefaultValue("")
                                .HasColumnName("zip_code");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsMany("Onion.Domain.BusinessDomain.CustomerContact", "CustomerContacts", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("Id")
                                .HasDefaultValueSql("newid()");

                            b1.Property<string>("ContactInfo")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("ContactType")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.HasKey("CustomerId", "Id");

                            b1.ToTable("CustomerContacts", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("CustomerContacts");
                });
#pragma warning restore 612, 618
        }
    }
}
