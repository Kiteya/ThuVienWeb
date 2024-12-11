using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThuVienWeb.Models;

public partial class QlthuVienContext : DbContext
{
    public QlthuVienContext()
    {
    }

    public QlthuVienContext(DbContextOptions<QlthuVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TBanSaoSach> TBanSaoSaches { get; set; }

    public virtual DbSet<TDocGium> TDocGia { get; set; }

    public virtual DbSet<TLoaiSach> TLoaiSaches { get; set; }

    public virtual DbSet<TMuonTra> TMuonTras { get; set; }

    public virtual DbSet<TNgonNgu> TNgonNgus { get; set; }

    public virtual DbSet<TNhaXb> TNhaXbs { get; set; }

    public virtual DbSet<TSach> TSaches { get; set; }

    public virtual DbSet<TTheDocGium> TTheDocGia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-ARHUM8Q\\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TBanSaoSach>(entity =>
        {
            entity.HasKey(e => e.MaBanSao);

            entity.ToTable("tBanSaoSach");

            entity.Property(e => e.MaBanSao)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Anh)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.MaSach)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TinhTrangSach).HasMaxLength(250);
            entity.Property(e => e.ViTri).HasMaxLength(100);

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.TBanSaoSaches)
                .HasForeignKey(d => d.MaSach)
                .HasConstraintName("FK_tBanSaoSach_tSach");
        });

        modelBuilder.Entity<TDocGium>(entity =>
        {
            entity.HasKey(e => e.MaDg);

            entity.ToTable("tDocGia");

            entity.Property(e => e.MaDg)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDG");
            entity.Property(e => e.Anh)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.HoDem).HasMaxLength(50);
            entity.Property(e => e.NoiCongTac).HasMaxLength(200);
            entity.Property(e => e.SoCmnd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SoCMND");
            entity.Property(e => e.TenDg)
                .HasMaxLength(50)
                .HasColumnName("TenDG");
        });

        modelBuilder.Entity<TLoaiSach>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("tLoaiSach");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenLoai).HasMaxLength(155);
        });

        modelBuilder.Entity<TMuonTra>(entity =>
        {
            entity.HasKey(e => new { e.MaThe, e.MaBanSao });

            entity.ToTable("tMuonTra");

            entity.Property(e => e.MaThe)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaBanSao)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayMuon).HasColumnType("datetime");
            entity.Property(e => e.NgayPhaiTra).HasColumnType("datetime");
            entity.Property(e => e.NgayTra).HasColumnType("datetime");
            entity.Property(e => e.TinhTrangSach).HasMaxLength(155);

            entity.HasOne(d => d.MaBanSaoNavigation).WithMany(p => p.TMuonTras)
                .HasForeignKey(d => d.MaBanSao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tMuonTra_tBanSaoSach");

            entity.HasOne(d => d.MaTheNavigation).WithMany(p => p.TMuonTras)
                .HasForeignKey(d => d.MaThe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tMuonTra_tTheDocGia");
        });

        modelBuilder.Entity<TNgonNgu>(entity =>
        {
            entity.HasKey(e => e.MaNgonNgu);

            entity.ToTable("tNgonNgu");

            entity.Property(e => e.MaNgonNgu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNgonNgu).HasMaxLength(100);
        });

        modelBuilder.Entity<TNhaXb>(entity =>
        {
            entity.HasKey(e => e.MaNxb);

            entity.ToTable("tNhaXB");

            entity.Property(e => e.MaNxb)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNXB");
            entity.Property(e => e.TenNxb)
                .HasMaxLength(155)
                .HasColumnName("TenNXB");
        });

        modelBuilder.Entity<TSach>(entity =>
        {
            entity.HasKey(e => e.MaSach);

            entity.ToTable("tSach");

            entity.Property(e => e.MaSach)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FileAnh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GioiThieu).HasColumnType("text");
            entity.Property(e => e.LanXb)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LanXB");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNgonNgu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNxb)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNXB");
            entity.Property(e => e.NamXb)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NamXB");
            entity.Property(e => e.TacGia).HasMaxLength(150);
            entity.Property(e => e.Tap)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenSach).HasMaxLength(155);
            entity.Property(e => e.TongSoTap)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TongSoTrang)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.TSaches)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_tSach_tLoaiSach");

            entity.HasOne(d => d.MaNgonNguNavigation).WithMany(p => p.TSaches)
                .HasForeignKey(d => d.MaNgonNgu)
                .HasConstraintName("FK_tSach_tNgonNgu");

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.TSaches)
                .HasForeignKey(d => d.MaNxb)
                .HasConstraintName("FK_tSach_tNhaXB");
        });

        modelBuilder.Entity<TTheDocGium>(entity =>
        {
            entity.HasKey(e => e.MaThe);

            entity.ToTable("tTheDocGia");

            entity.Property(e => e.MaThe)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Anh)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.MaDg)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDG");

            entity.HasOne(d => d.MaDgNavigation).WithMany(p => p.TTheDocGia)
                .HasForeignKey(d => d.MaDg)
                .HasConstraintName("FK_tTheDocGia_tDocGia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
