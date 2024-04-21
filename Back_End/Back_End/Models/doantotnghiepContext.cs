using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Back_End.Models
{
    public partial class doantotnghiepContext : DbContext
    {
        public doantotnghiepContext()
        {
        }

        public doantotnghiepContext(DbContextOptions<doantotnghiepContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anhsanpham> Anhsanphams { get; set; } = null!;
        public virtual DbSet<Chinhsach> Chinhsaches { get; set; } = null!;
        public virtual DbSet<Chitiethoadonban> Chitiethoadonbans { get; set; } = null!;
        public virtual DbSet<Chitiethoadonnhap> Chitiethoadonnhaps { get; set; } = null!;
        public virtual DbSet<Gioithieu> Gioithieus { get; set; } = null!;
        public virtual DbSet<Hoadonban> Hoadonbans { get; set; } = null!;
        public virtual DbSet<Hoadonnhap> Hoadonnhaps { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Lienhe> Lienhes { get; set; } = null!;
        public virtual DbSet<Loainongsan> Loainongsans { get; set; } = null!;
        public virtual DbSet<Loaitintuc> Loaitintucs { get; set; } = null!;
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<Quyen> Quyens { get; set; } = null!;
        public virtual DbSet<Sanpham> Sanphams { get; set; } = null!;
        public virtual DbSet<Slide> Slides { get; set; } = null!;
        public virtual DbSet<Tintuc> Tintucs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=doantotnghiep;user=root;password=admin@123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Anhsanpham>(entity =>
            {
                entity.ToTable("anhsanpham");

                entity.HasIndex(e => e.SanPhamId, "SanPham_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DuongDanAnh).HasMaxLength(255);

                entity.Property(e => e.SanPhamId).HasColumnName("SanPham_Id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.Anhsanphams)
                    .HasForeignKey(d => d.SanPhamId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("anhsanpham_ibfk_1");
            });

            modelBuilder.Entity<Chinhsach>(entity =>
            {
                entity.ToTable("chinhsach");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NoiDung).HasColumnType("text");

                entity.Property(e => e.TieuDe).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Chitiethoadonban>(entity =>
            {
                entity.ToTable("chitiethoadonban");

                entity.HasIndex(e => e.HoaDonBanId, "HoaDonBan_Id");

                entity.HasIndex(e => e.SanPhamId, "SanPham_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GiaBan).HasDefaultValueSql("'0'");

                entity.Property(e => e.HoaDonBanId).HasColumnName("HoaDonBan_Id");

                entity.Property(e => e.SanPhamId).HasColumnName("SanPham_Id");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("'0'");

                entity.Property(e => e.ThanhTien).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.HoaDonBan)
                    .WithMany(p => p.Chitiethoadonbans)
                    .HasForeignKey(d => d.HoaDonBanId)
                    .HasConstraintName("chitiethoadonban_ibfk_2");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.Chitiethoadonbans)
                    .HasForeignKey(d => d.SanPhamId)
                    .HasConstraintName("chitiethoadonban_ibfk_1");
            });

            modelBuilder.Entity<Chitiethoadonnhap>(entity =>
            {
                entity.ToTable("chitiethoadonnhap");

                entity.HasIndex(e => e.HoaDonNhapId, "HoaDonNhap_Id");

                entity.HasIndex(e => e.SanPhamId, "SanPham_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GiaNhap).HasDefaultValueSql("'0'");

                entity.Property(e => e.HoaDonNhapId).HasColumnName("HoaDonNhap_Id");

                entity.Property(e => e.SanPhamId).HasColumnName("SanPham_Id");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("'0'");

                entity.Property(e => e.ThanhTien).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.HoaDonNhap)
                    .WithMany(p => p.Chitiethoadonnhaps)
                    .HasForeignKey(d => d.HoaDonNhapId)
                    .HasConstraintName("chitiethoadonnhap_ibfk_2");

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.Chitiethoadonnhaps)
                    .HasForeignKey(d => d.SanPhamId)
                    .HasConstraintName("chitiethoadonnhap_ibfk_1");
            });

            modelBuilder.Entity<Gioithieu>(entity =>
            {
                entity.ToTable("gioithieu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GioiThieu1)
                    .HasColumnType("text")
                    .HasColumnName("GioiThieu");
            });

            modelBuilder.Entity<Hoadonban>(entity =>
            {
                entity.ToTable("hoadonban");

                entity.HasIndex(e => e.KhachHangId, "hoadonban_ibfk_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiaChi).HasColumnType("text");

                entity.Property(e => e.GhiChu).HasColumnType("text");

                entity.Property(e => e.HoTen).HasMaxLength(255);

                entity.Property(e => e.KhachHangId).HasColumnName("KhachHang_Id");

                entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(255);

                entity.Property(e => e.TrangThaiDonHang).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.KhachHang)
                    .WithMany(p => p.Hoadonbans)
                    .HasForeignKey(d => d.KhachHangId)
                    .HasConstraintName("hoadonban_ibfk_1");
            });

            modelBuilder.Entity<Hoadonnhap>(entity =>
            {
                entity.ToTable("hoadonnhap");

                entity.HasIndex(e => e.NhaCungCapId, "NhaCungCap_Id");

                entity.HasIndex(e => e.NhanVienId, "NhanVien_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NhaCungCapId).HasColumnName("NhaCungCap_Id");

                entity.Property(e => e.NhanVienId).HasColumnName("NhanVien_Id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.NhaCungCap)
                    .WithMany(p => p.Hoadonnhaps)
                    .HasForeignKey(d => d.NhaCungCapId)
                    .HasConstraintName("hoadonnhap_ibfk_1");

                entity.HasOne(d => d.NhanVien)
                    .WithMany(p => p.Hoadonnhaps)
                    .HasForeignKey(d => d.NhanVienId)
                    .HasConstraintName("hoadonnhap_ibfk_2");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.ToTable("khachhang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiaChi).HasColumnType("text");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.HoTen).HasMaxLength(255);

                entity.Property(e => e.PassWord).HasMaxLength(255);

                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(255)
                    .HasColumnName("refreshToken");

                entity.Property(e => e.RefreshTokenExpiryTime).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .HasColumnType("text")
                    .HasColumnName("token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            modelBuilder.Entity<Lienhe>(entity =>
            {
                entity.ToTable("lienhe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BanDo).HasColumnType("text");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiaChi).HasColumnType("text");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Loainongsan>(entity =>
            {
                entity.ToTable("loainongsan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TenLoai).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Loaitintuc>(entity =>
            {
                entity.ToTable("loaitintuc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TenLoaiTin).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.ToTable("nhacungcap");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiaChi).HasColumnType("text");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.TenNhaCungCap).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.ToTable("nhanvien");

                entity.HasIndex(e => e.RoleId, "role_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar).HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DiaChi).HasColumnType("text");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.GioiTinh).HasMaxLength(255);

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName(" HoTen");

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.PassWord).HasMaxLength(255);

                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(255)
                    .HasColumnName("refreshToken");

                entity.Property(e => e.RefreshTokenExpiryTime)
                    .HasColumnType("datetime")
                    .HasColumnName("refreshTokenExpiryTime");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(255)
                    .HasColumnName(" SoDienThoai");

                entity.Property(e => e.Token)
                    .HasColumnType("text")
                    .HasColumnName("token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("nhanvien_ibfk_1");
            });

            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.ToTable("quyen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TenQuyen).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.ToTable("sanpham");

                entity.HasIndex(e => e.LoaiId, "Loai_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DonViTinh).HasMaxLength(255);

                entity.Property(e => e.LoaiId).HasColumnName("Loai_Id");

                entity.Property(e => e.MoTa).HasColumnType("text");

                entity.Property(e => e.TenSanPham).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Loai)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.LoaiId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sanpham_ibfk_1");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.ToTable("slide");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DuongDanAnh).HasColumnType("text");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Tintuc>(entity =>
            {
                entity.ToTable("tintuc");

                entity.HasIndex(e => e.LoaiTinId, "LoaiTin_Id");

                entity.HasIndex(e => e.NguoiVietId, "NguoiViet_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DuongDanAnh).HasMaxLength(255);

                entity.Property(e => e.LoaiTinId).HasColumnName("LoaiTin_Id");

                entity.Property(e => e.NguoiVietId).HasColumnName("NguoiViet_Id");

                entity.Property(e => e.NoiDung).HasColumnType("longtext");

                entity.Property(e => e.TieuDe).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.LoaiTin)
                    .WithMany(p => p.Tintucs)
                    .HasForeignKey(d => d.LoaiTinId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tintuc_ibfk_1");

                entity.HasOne(d => d.NguoiViet)
                    .WithMany(p => p.Tintucs)
                    .HasForeignKey(d => d.NguoiVietId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tintuc_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
