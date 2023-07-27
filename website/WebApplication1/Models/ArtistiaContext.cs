using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1;

public partial class ArtistiaContext : DbContext
{
    public ArtistiaContext()
    {
    }

    public ArtistiaContext(DbContextOptions<ArtistiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<UserData> UserDatas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Artistia;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => new { e.ImageId, e.UserId }).HasName("PK__tmp_ms_x__A46E7BC861652238");

            entity.ToTable("Cart");

            entity.HasOne(d => d.Image).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Images");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_UserData");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Images__3214EC07F603EB52");

            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.ImgLink).HasMaxLength(100);
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

            entity.HasOne(d => d.Owner).WithMany(p => p.Images)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ForeignImageOwner");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Owner__3214EC078F2295A4");

            entity.ToTable("Owner");

            entity.Property(e => e.Details).HasMaxLength(500);
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsFixedLength();
        });
        modelBuilder.Entity<UserData>(entity =>
        {
            entity.ToTable("UserData"); // Replace "YourTableName" with the actual table name
            entity.HasKey(e => e.Id).HasName("PK_UserDatas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
