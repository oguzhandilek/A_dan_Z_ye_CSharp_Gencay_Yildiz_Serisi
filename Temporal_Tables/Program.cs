// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

ApplicationDbContext context = new();

#region Temporal Tables Nedir?
// Veri değişikliği süreçlerinde kayıtları depolayan ve zaman içinde Farklı noktalardaki tablo verilerinin analizi için kullanılan ve sistem tarafından yönetilen tablolardır.
//EF Core 6.0'dan itibaren desteklenmektedir.
#endregion

#region Temporal Tables Özelliğiyle Nasıl Çalışılır?
//EF Core'daki migration yapıları sayesinde temporal table'lar oluşturulup veritabanında üretilebilmektedir.
//Mevcut tabloları migration'lar aracılığıyla Temporal Table'lara dönüştürülebilmektedir.
//Herhangi bir tablonun verisel olarak geçmişini rahatlıkla sorgulayabiliriz.
//Herhangi bir tablodaki bir verinin geçmişteki herhangi bir T anındaki haLi/duırumu/veriLeri geri getirilebilmektedir.
#endregion

#region Temporal Table Nasıl Uygulanır?

#region IsTemporal Yapılandırması
//EF Core bu yapılandırma fonksiyonu sayesinde ilgili entity'e karşılık üretilecek tabloda temporaL table oluşturacağını anlamaktadır. Yahut önceden ilgili tablo üretilmişse eğer onu temporal table'a dönüştürecektir.
#endregion
#endregion

#region Temporal Table'ı Test Edelim

#region Veri Eklerken
// Temporal Table'a veri ekleme süreçlerinde herhangi bir kayıt atılmaz! TemporaL Table 'ın yapısı, var olan veirler üzerindeki zamansal deği imleri taki etmek üzerine kuruludur!
//var persons = new List<Person>()
//{
//    new() {Name="Zehra",Surname="Dilek",BirthDate=DateOnly.FromDateTime(DateTime.UtcNow)},
//    new() {Name="Rumeysa",Surname="Dilek",BirthDate=DateOnly.FromDateTime(DateTime.UtcNow)},
//    new() {Name="Sutlaç",Surname="Dilek",BirthDate=DateOnly.FromDateTime(DateTime.UtcNow)},
//    new() {Name="Oğuzhan",Surname="Dilek",BirthDate=DateOnly.FromDateTime(DateTime.UtcNow)},
//};
//await context.AddRangeAsync(persons);
//await context.SaveChangesAsync();
#endregion
#region Veri Güncellereken
//var person = await context.Persons.FindAsync(3);
//person.Name = "Sütlaç Sıdıka";
//context.Update(person);
//await context.SaveChangesAsync();
#endregion

#region Veri Silerken
//var person = await context.Persons.FindAsync(5);
//context.Remove(person);
//await context.SaveChangesAsync();
#endregion
#endregion

#region Temporal Table Üzerinden Geçmiş Verisel İzleri Sorgulama

#region TemporalAsOf
//Be1ir1i bir zaman için değişikiğe döndüren bir fonksiyondur.
//var datas= await context.Persons
//    .TemporalAsOf(new DateTime(2025,12,23,11,14,41)) //PeriodEnd'deki bir zamanı aldık
//    .Select(p => new
//    {
//        Id = p.Id,
//        Name = p.Name,
//        PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
//        PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd"),
//    }).ToListAsync();
//foreach (var data in datas)
//{
//    Console.WriteLine($"Id: {data.Id} | Name: {data.Name} | PeriodStart: {data.PeriodStart} | PeriodEnd: {data.PeriodEnd}");
//}
#endregion
#region TemporalAll
//Güncellenmiş yahut silinmiş olan tüm verilerin geçmiş sürümlerini veya geçerli durumlarını döndüren bir -Fonksiyondur.
//var datas= await context.Persons.TemporalAll()
//        .Select(p=> new
//        {
//            p.Id,
//            p.Name,
//            PeriodStart=EF.Property<DateTime>(p,"PeriodStart"),
//            PeriodEnd=EF.Property<DateTime>(p,"PeriodEnd"),
//        }).ToListAsync();
//foreach (var data in datas)
//{
//    Console.WriteLine($"Id: {data.Id} | Name: {data.Name} | PeriodStart: {data.PeriodStart} | PeriodEnd: {data.PeriodEnd}");
//}
#endregion
#region TemporalFromTo
//BeLirLi bir zaman aralığı içerisindeLki verileri döndüren fonksiyondur. Başlangıç ve bitiş zamanı dahil değildir.
//var baslangic = "2025-12-23 11:10:53.0165062";
//var bitis = "2025-12-23 11:21:55.8939105";
//var datas = await context.Persons.TemporalFromTo(DateTime.Parse(baslangic), DateTime.Parse(bitis))

//    .Select(p => new
//    {
//        p.Id,
//        p.Name,
//        PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
//        PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd"),
//    })
//    .Where(p => EF.Property<DateTime>(p, "PeriodEnd").Year < 2026)
//    .ToListAsync();
//foreach (var data in datas)
//{
//    Console.WriteLine($"Id: {data.Id} | Name: {data.Name} | PeriodStart: {data.PeriodStart} | PeriodEnd: {data.PeriodEnd}");
//}
#endregion
#region TemporalBetween
//Be1irIi bir zaman aralığı içerisindelki verileri döndüren fonksiyondur. Başlangıç verisi dahil değil ve bitiş zamanı ise dahildir.
//var baslangic = "2025-12-23 11:10:53.0165062";
//var bitis = "2025-12-23 11:21:55.8939105";
//var datas = await context.Persons.TemporalBetween(DateTime.Parse(baslangic), DateTime.Parse(bitis))

//    .Select(p => new
//    {
//        p.Id,
//        p.Name,
//        PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
//        PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd"),
//    })
//    .Where(p => EF.Property<DateTime>(p, "PeriodEnd").Year < 2026)
//    .ToListAsync();
//foreach (var data in datas)
//{
//    Console.WriteLine($"Id: {data.Id} | Name: {data.Name} | PeriodStart: {data.PeriodStart} | PeriodEnd: {data.PeriodEnd}");
//}
#endregion
#region TemporalContainedIn
//var baslangic = "2025-12-23 11:10:53.0165062";
//var bitis = "2025-12-23 11:21:55.8939105";
//var datas = await context.Persons.TemporalContainedIn(DateTime.Parse(baslangic), DateTime.Parse(bitis))

//    .Select(p => new
//    {
//        p.Id,
//        p.Name,
//        PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
//        PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd"),
//    })
//    .ToListAsync();
//foreach (var data in datas)
//{
//    Console.WriteLine($"Id: {data.Id} | Name: {data.Name} | PeriodStart: {data.PeriodStart} | PeriodEnd: {data.PeriodEnd}");
//}

#endregion
#endregion

#region Silinmiş Bir Veriyi Temporal Table'dan Geri Getirme
//Si1inmiş bir veriyi temporaL table'dan getirebilmek için öncelikle yapılması gereken ilgili verinin silindiği tarihi bulmamız gerekmektedir. Ardından TemporaLAsOf fonksiyonu ile silinen verinin geçmiş değeri elde edilebilir ve fiziksel tabloya bu veri taşınabilir.

//Silindiği Tarih
var dateOdDelete=await context.Persons.TemporalAll()
    .Where(x => x.Id == 5)
    .OrderByDescending(x => EF.Property<DateTime>(x, "PeriodEnd"))
    .Select(x => EF.Property<DateTime>(x, "PeriodEnd"))
    .FirstAsync();
var deletedPerson= await context.Persons.TemporalAsOf(dateOdDelete.AddMicroseconds(-1))
    .FirstOrDefaultAsync(p=> p.Id==5);

await context.AddAsync(deletedPerson);

await context.Database.OpenConnectionAsync();
await context.Database.ExecuteSqlInterpolatedAsync($"SET IDENTITY_INSERT dbo.Persons ON");
await context.SaveChangesAsync();
await context.Database.ExecuteSqlInterpolatedAsync($"SET IDENTITY_INSERT dbo.Persons OFF");
#endregion

#region SET IDENTITY_INSERT Konfigürasyonu
// Id ile veri ekleme sürecinde ilgili verinin id sütununa kayıt işleyebilmek için veriyi fiziksel tabloya taşıma işleminden önce veritabanı seviyesinde SET IDENTİTY_INSERT komutu eşliğinde id bazlı veri ekleme işlemi aktifleştirilmelidir.
#endregion

Console.WriteLine("Hello, World!");

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateOnly BirthDate { get; set; }
}

public class Empoleyee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Empoleyee> Empoleyees { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=TemporalDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Empoleyee>().ToTable("Employees",builder=> builder.IsTemporal());
       modelBuilder.Entity<Person>().ToTable("Persons",builder=> builder.IsTemporal());
    }
}