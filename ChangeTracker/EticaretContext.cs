using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChangeTracker;

public partial class EticaretContext : DbContext
{
    public EticaretContext()
    {
    }

    public EticaretContext(DbContextOptions<EticaretContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Parcalar> Parcalars { get; set; }

    public virtual DbSet<Urunler> Urunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ETicaret;Trusted_Connection=True;");
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       var entries= ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            if (entry.State==EntityState.Added)
            {
                //..Örnek identity değerini  özel tanımlama ile değişip ekleme yap
            }

        }
        ;
        return base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parcalar>(entity =>
        {
            entity.ToTable("Parcalar");

            entity.HasIndex(e => e.UrunId, "IX_Parcalar_UrunId");

            entity.HasOne(d => d.Urun).WithMany(p => p.Parcalars).HasForeignKey(d => d.UrunId);
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.ToTable("Urunler");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
