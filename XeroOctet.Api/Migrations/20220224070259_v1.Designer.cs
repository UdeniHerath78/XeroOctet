﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XeroOctet.Data.DBContext;

namespace XeroOctet.Api.Migrations
{
    [DbContext(typeof(XeroDBContext))]
    [Migration("20220224070259_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("XeroOctet.Data.Models.Invoice", b =>
                {
                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("InvoiceAmount")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)");

                    b.Property<DateTime>("InvoiceIssueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OutstandingAmount")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InvoiceNumber");

                    b.ToTable("Invoice");
                });
#pragma warning restore 612, 618
        }
    }
}
