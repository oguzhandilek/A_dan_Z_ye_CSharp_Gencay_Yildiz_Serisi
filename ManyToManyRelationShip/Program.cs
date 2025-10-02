// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");
#region Default Convention
// İki entity arasındaki ilişkiyi navigation propertyler üzerinden çoğul olarak kurmalıyız. (IC011ection, List)
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
//CTlda composite primary keyli data ile manuel kuramıyoruz. Bunun için de FLuent API 'da çalışma yaopmamız gerekiyor.
//Cross tabLela karşılık bir entity modeli oluşturuyorsak eğer bunu context sınıfı içerisinde DbSet property 'si olarka bildirmek mecburiyetinde değiliz!
#endregion
public class Yazar
{
    public int Id { get; set; }
    public string YazarAdi { get; set; }


    public ICollection<KitapYazar> Kitaplar { get; set; }
}
public class Kitap
{
    public int Id { get; set; }
    public string KitapAdi { get; set; }

    public ICollection<KitapYazar> Yazarlar { get; set; }
}
public class KitapYazar
{
    [Key]
    public int KitapId { get; set; }
    [Key]
    public int YazarId { get; set; }

    public Yazar Yazar { get; set; }
    public Kitap Kitap { get; set; }
}
public class EKitapDbContext : DbContext
{
    public DbSet<Yazar> Yazarlar { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=EKitapDb;Trusted_Connection=True;");

    }
}