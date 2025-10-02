// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

Console.WriteLine("Hello, World!");
#region Default Convention
// Her iki entity 'de Navigation Property ile birbirlerini tekil olarak referans ederek fiziksel bir ilişkinin olacağı ifade edilir.
//0ne to One ilişki türünde, dependent entity' nin hangisi olduğunu default olarak belirleyebilmek pek kolay değildir. Bu durumda fiziksel olarak bir foreign Rey'e karşılık property / koLon tanımlayarak çözüm getirebiliyoruz
// Böylece _foreign key'e karşılık property tanımlayarak Lüzumsuz bir kolon oluşturmuş oluyoruz.
//public class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }

//    public CalisanAdresi CalisanAdresi { get; set; }
//}
//public class CalisanAdresi
//{
//    public int Id { get; set; }
//    public int CalisanId { get; set; }
//    public string Adres { get; set; }

//    public Calisan Calisan { get; set; }
//}

//public class ESirketDbContext:DbContext
//{
//    public DbSet<Calisan> Calisanlar { get; set; }
//    public DbSet<CalisanAdresi> CalisanAdresleri { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ESirket;Trusted_Connection=True;");
//    }
//}
#endregion

#region Data Annotations
// Navigation Property' ler tanımlanmalıdır . 
// Foreign kolonunun ismi default convention'ın dışında bir kolon olacaksa eğer ForeignKey attribute ile bunu bildirebiliriz . 
// Foreign Key kolonu oluşturulmak zorunda değildir. 
// 1' e 1 ilişkide ekstradan foreign key kolonuna ihtiyaç olmayacağından dolayı dependent entity deki id kolonunun hem foreign key hem de primary key olarak kullanmayı tercih ediyoruz ve bu duruma özen gösterilmelidir diyoruz.
//public class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }

//    public CalisanAdresi CalisanAdresi { get; set; }
//}
//public class CalisanAdresi
//{
//    [Key,ForeignKey(nameof(Calisan))]
//    public int Id { get; set; }
//    //[ForeignKey(nameof(Calisan))] Bu iptal 
//    //public int CalisanId { get; set; } Bu iptal 
//    public string Adres { get; set; }

//    public Calisan Calisan { get; set; }
//}

//public class ESirketDbContext : DbContext
//{
//    public DbSet<Calisan> Calisanlar { get; set; }
//    public DbSet<CalisanAdresi> CalisanAdresleri { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ESirket;Trusted_Connection=True;");
//    }
//}
#endregion

#region Fluent API
// Model 'Ların(entity) veritabanında generate edilecek yapıları bu fonksiyonda içerisinde konfigüre edilir.
// Navigation Proeprtyler tanımlanmalı !
//FLeunt API yönteminde entity'ler arasındaki ilişki context sınıfı içerisinde OnModeLCreating fonksiyonun override edilerek metotlar aracılığıyla tasarlanması gerekmektedir. Yani tüm sorumluluk bu fonksiyon içerisindeki çalışmalardadır.
public class Calisan
{
    public int Id { get; set; }
    public string Adi { get; set; }

    public CalisanAdresi CalisanAdresi { get; set; }
}
public class CalisanAdresi
{
    public int Id { get; set; }


    public string Adres { get; set; }

    public Calisan Calisan { get; set; }
}

public class ESirketDbContext : DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<CalisanAdresi> CalisanAdresleri { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ESirket;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calisan>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Calisan>()
            .HasOne(c => c.CalisanAdresi)
            .WithOne(c => c.Calisan)
            .HasForeignKey<CalisanAdresi>(c => c.Id);
    }
}
#endregion