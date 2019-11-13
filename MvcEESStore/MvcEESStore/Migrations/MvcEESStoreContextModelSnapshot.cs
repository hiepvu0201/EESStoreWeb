﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcEESStore.Data;

namespace MvcEESStore.Migrations
{
    [DbContext(typeof(MvcEESStoreContext))]
    partial class MvcEESStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcEESStore.Models.Category", b =>
                {
                    b.Property<string>("maDM")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("tenDM")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("tongSoLuongSP")
                        .HasColumnType("int");

                    b.HasKey("maDM");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MvcEESStore.Models.Customer", b =>
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

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("MvcEESStore.Models.Product", b =>
                {
                    b.Property<string>("maSP")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ProductGroupmaNSP")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ReceiptmaHD")
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

                    b.HasIndex("ProductGroupmaNSP");

                    b.HasIndex("ReceiptmaHD");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MvcEESStore.Models.ProductGroup", b =>
                {
                    b.Property<string>("maNSP")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CategorymaDM")
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

                    b.HasIndex("CategorymaDM");

                    b.ToTable("ProductGroup");
                });

            modelBuilder.Entity("MvcEESStore.Models.PurchaseHistory", b =>
                {
                    b.Property<string>("maPurchaseHistory")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("maHD")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("maPurchaseHistory");

                    b.ToTable("PurchaseHistory");
                });

            modelBuilder.Entity("MvcEESStore.Models.Receipt", b =>
                {
                    b.Property<string>("maHD")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CustomermaKH")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PurchaseHistorymaPurchaseHistory")
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

                    b.HasIndex("CustomermaKH");

                    b.HasIndex("PurchaseHistorymaPurchaseHistory");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("MvcEESStore.Models.Customer", b =>
                {
                    b.HasOne("MvcEESStore.Models.PurchaseHistory", "PurchaseHistory")
                        .WithMany()
                        .HasForeignKey("PurchaseHistorymaPurchaseHistory");
                });

            modelBuilder.Entity("MvcEESStore.Models.Product", b =>
                {
                    b.HasOne("MvcEESStore.Models.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("ProductGroupmaNSP");

                    b.HasOne("MvcEESStore.Models.Receipt", "Receipt")
                        .WithMany("Products")
                        .HasForeignKey("ReceiptmaHD");
                });

            modelBuilder.Entity("MvcEESStore.Models.ProductGroup", b =>
                {
                    b.HasOne("MvcEESStore.Models.Category", "Category")
                        .WithMany("ProductGroups")
                        .HasForeignKey("CategorymaDM");
                });

            modelBuilder.Entity("MvcEESStore.Models.Receipt", b =>
                {
                    b.HasOne("MvcEESStore.Models.Customer", "Customer")
                        .WithMany("Receipts")
                        .HasForeignKey("CustomermaKH");

                    b.HasOne("MvcEESStore.Models.PurchaseHistory", "PurchaseHistory")
                        .WithMany("Receipts")
                        .HasForeignKey("PurchaseHistorymaPurchaseHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
