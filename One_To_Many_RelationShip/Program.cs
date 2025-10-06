// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");
#region Default Convention 
//DefauLt convention yönteminde bire çok iLişkiyi kurarken foreign key kolonuna karşılık gelen bir property tanımlamak mecburiyetinde değiliz. Eğer tanımlamazsak EF Core bunu kendisi tamamlayacak yok eğer tanımlarsak, tanımladığımızı baz alacaktır.
//class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }


//    public Depertman Depertman { get; set; }

//}
//class Depertman
//{
//    public int Id { get; set; }
//    public string DepertmanAdi { get; set; }

//    public ICollection<Calisan> Calisanlar { get; set; }
//}

//class ESirketDbContext : DbContext
//{
//    public DbSet<Calisan> Calisanlar { get; set; }
//    public DbSet<Depertman> Depertmanlar { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ESirket;Trusted_Connection=True;");
//    }
//}
#endregion

#region Data Annotations
//DefauLt convention yönteminde foreign key kolonuna karşılık gelen property'i tanımladığımızda bu property ismi temel geleneksel entity tanımlama kurallarına uymuyorsa eğer Data Annotations I Lar ile müdahalede bulunabiliriz .

//class Calisan
//{
//    public int Id { get; set; }
//    [ForeignKey(nameof(Depertman))]
//    public int DId { get; set; }
//    public string Adi { get; set; }


//    public Depertman Depertman { get; set; }

//}
//class Depertman
//{
//    public int Id { get; set; }
//    public string DepertmanAdi { get; set; }

//    public ICollection<Calisan> Calisanlar { get; set; }
//}

//class ESirketDbContext : DbContext
//{
//    public DbSet<Calisan> Calisanlar { get; set; }
//    public DbSet<Depertman> Depertmanlar { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ESirket;Trusted_Connection=True;");
//    }
//}

#endregion

#region Fluent API

#endregion

class Calisan
{
    public int Id { get; set; }
    
    public string Adi { get; set; }


    public Depertman Depertman { get; set; }

}
class Depertman
{
    public int Id { get; set; }
    public string DepertmanAdi { get; set; }

    public ICollection<Calisan> Calisanlar { get; set; }
}

class ESirketDbContext:DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<Depertman> Depertmanlar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ESirket;Trusted_Connection=True;");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Depertman>().HasKey(d=> d.Id);

        modelBuilder.Entity<Calisan>()
            .HasOne(c => c.Depertman)
            .WithMany(c => c.Calisanlar)
            .HasForeignKey(c => c.Id);
    }
}