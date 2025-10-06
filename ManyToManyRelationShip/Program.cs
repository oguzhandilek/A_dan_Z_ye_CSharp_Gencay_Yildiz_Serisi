// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");
#region Default Convention
// İki entity arasındaki ilişkiyi navigation propertyler üzerinden çoğul olarak kurmalıyız. (ICollection, List)
//DefauLt Convention 'da cross tabLe'ı manuel oluşturmak zorunda değiliz. EF Core tasarıma uygun bir şekilde cross table'ı kendisi otomatik basacak ve generate edecektir. 
// Ve oluşturulan cross table içerisinde composite primary key'i de otomatik oluşturmuş olacaktır.
//public class Yazar
//{
//    public int Id { get; set; }
//    public string YazarAdi { get; set; }

//    public ICollection<Kitap> Kitaplar { get; set; }

//}
//public class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdi { get; set; }

//    public ICollection<Yazar> Yazarlar { get; set; }
//}

//public class EKitapDbContext : DbContext
//{
//    public DbSet<Yazar> Yazarlar { get; set; }
//    public DbSet<Kitap> Kitaplar { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {

//        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=EKitapDb;Trusted_Connection=True;");
//    }
//}
#endregion

#region Data Annotations
//Cross table manuel olarak oluşturulmak zorundadır.
//Entity'Ierde oluşturduğumuz cross table entity si ile bire çok bir ilişki kurulmalı.
//CTlda composite primary key'i data ile manuel kuramıyoruz. Bunun için de FLuent API 'da çalışma yapmamız gerekiyor.
//Cross table'a karşılık bir entity modeli oluşturuyorsak eğer bunu context sınıfı içerisinde DbSet property 'si olarkta bildirmek mecburiyetinde değiliz!
//public class Yazar
//{
//    public int Id { get; set; }
//    public string YazarAdi { get; set; }


//    public ICollection<KitapYazar> Kitaplar { get; set; }
//}
//public class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdi { get; set; }

//    public ICollection<KitapYazar> Yazarlar { get; set; }
//}
//public class KitapYazar
//{

//    public int KitapId { get; set; }

//    public int YazarId { get; set; }
//    //[ForeignKey(nameof(Kitap))]
//    //public int KId { get; set; }
//    //[ForeignKey(nameof(Yazar))]
//    //public int YId { get; set; }

//    public Yazar Yazar { get; set; }
//    public Kitap Kitap { get; set; }
//}
//public class EKitapDbContext : DbContext
//{
//    public DbSet<Yazar> Yazarlar { get; set; }
//    public DbSet<Kitap> Kitaplar { get; set; }

//    //KitapYazar Dbset'ini oluşturmaya gerek yok açıklamasaı yukarıda
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {

//        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=EKitapDb;Trusted_Connection=True;");

//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<KitapYazar>()
//            .HasKey(ky => new { ky.KitapId, ky.YazarId });
//    }
//}
#endregion

#region Fluent API
//Cross table manuel oluşturulmalı
//DbSet olarak eklenmesine lüzum yok,
//Composite PK Haskey metodu ile kurulmalı!

//public class Yazar
//{
//    public int Id { get; set; }
//    public string YazarAdi { get; set; }

//    public ICollection<KitapYazar> Kitaplar { get; set; }

//}

//public class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdi { get; set; }

//    public ICollection<KitapYazar> Yazarlar { get; set; }
//}

//public class KitapYazar
//{
//    public int YazarId { get; set; }
//    public int KitapId { get; set; }

//    public Yazar Yazar { get; set; }
//    public Kitap Kitap { get; set; }

//}
//public class EKitapDbContext:DbContext
//{
//    public DbSet<Yazar> Yazarlar { get; set; }
//    public DbSet<Kitap> Kitaplar { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=EKitapDb;Trusted_Connection=True;");
//    }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<KitapYazar>()
//            .HasKey(ky => new { ky.KitapId, ky.YazarId });
//        modelBuilder.Entity<KitapYazar>()
//            .HasOne(ky => ky.Kitap)
//            .WithMany(k => k.Yazarlar)
//            .HasForeignKey(ky=> ky.KitapId);

//        modelBuilder.Entity<KitapYazar>()
//            .HasOne(ky=> ky.Yazar)
//            .WithMany(y=> y.Kitaplar)
//            .HasForeignKey(ky=> ky.YazarId);

//    }
//}
#endregion
