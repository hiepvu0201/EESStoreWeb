﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Migrations
{
    [DbContext(typeof(EESStoreContext))]
    partial class EESStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebProject.Models.Category", b =>
                {
                    b.Property<string>("maDM")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("tenDM")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("tongSoLuongSP")
                        .HasColumnType("int");

                    b.HasKey("maDM");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebProject.Models.Customer", b =>
                {
                    b.Property<string>("maKH")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PurchaseHistorymaPurchaseHistory")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("maGiaoDich")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("maThanhVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("tenKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("maKH");

                    b.HasIndex("PurchaseHistorymaPurchaseHistory");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebProject.Models.Product", b =>
                {
                    b.Property<string>("maSP")
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("giaGoc")
                        .HasColumnType("int");

                    b.Property<int>("giaKhuyenMai")
                        .HasColumnType("int");

                    b.Property<byte[]>("hinhAnh")
                        .IsRequired()
                        .HasColumnType("image");

                    b.Property<string>("maNSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("maNSX")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("soLuongSP")
                        .HasColumnType("int");

                    b.Property<string>("tenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("trangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("maSP");

                    b.HasIndex("maNSP");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebProject.Models.ProductGroup", b =>
                {
                    b.Property<string>("maNSP")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("maDM")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("soLuongSpMoiNhom")
                        .HasColumnType("int");

                    b.Property<string>("tenNSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("maNSP");

                    b.HasIndex("maDM");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("WebProject.Models.Receipt", b =>
                {
                    b.Property<string>("maHD")
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("donGia")
                        .HasColumnType("int");

                    b.Property<string>("maKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("maSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("ngayGiaoDich")
                        .HasColumnType("datetime");

                    b.Property<int>("soLuongSP")
                        .HasColumnType("int");

                    b.Property<string>("tenKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("thanhTieh")
                        .HasColumnType("int");

                    b.Property<int>("tongTien")
                        .HasColumnType("int");

                    b.HasKey("maHD");

                    b.HasIndex("maKH");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("WebProject.Models.purchaseHistory", b =>
                {
                    b.Property<string>("maPurchaseHistory")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("maHD")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("maPurchaseHistory");

                    b.ToTable("PurchaseHistories");
                });

            modelBuilder.Entity("WebProject.Models.Customer", b =>
                {
                    b.HasOne("WebProject.Models.purchaseHistory", "PurchaseHistory")
                        .WithMany()
                        .HasForeignKey("PurchaseHistorymaPurchaseHistory");
                });

            modelBuilder.Entity("WebProject.Models.Product", b =>
                {
                    b.HasOne("WebProject.Models.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("maNSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProject.Models.Receipt", "Receipt")
                        .WithMany("Products")
                        .HasForeignKey("maSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebProject.Models.ProductGroup", b =>
                {
                    b.HasOne("WebProject.Models.Category", "Category")
                        .WithMany("ProductGroups")
                        .HasForeignKey("maDM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebProject.Models.Receipt", b =>
                {
                    b.HasOne("WebProject.Models.purchaseHistory", "PurchaseHistory")
                        .WithMany("Receipts")
                        .HasForeignKey("maHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProject.Models.Customer", "Customer")
                        .WithMany("Receipts")
                        .HasForeignKey("maKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
