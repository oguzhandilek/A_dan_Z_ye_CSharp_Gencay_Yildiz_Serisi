
using Microsoft.EntityFrameworkCore;
Console.WriteLine();




#region OnConfiguring İle Konfigürasyon Ayarlarını Gerçekleştirmek
//EF Core tool'unu yapılandırmak için kullandığımız bir metottur.
//Context nesnesinde override edilerek kuLLanıLmaktadır.

//Provider
//ConnectionString
//Lazy Loading
#endregion
#region Basit Düzeyde Entity Tanımlama Kuralları
//EF Core, her tablonun default olarak bir primary key kolonu olması gerektiğini kabul eder!
//HaliyLe, bu kolonu temsil eden bir property tanımlamadığımız taktirde hata verecektir!
// Default olarak Id veya <ClassName>Id isimlendirmesini arar!
#endregion

#region Veri Nasıl Eklenir?
//ETicaretDbContext context = new ();
//Urun urun = new Urun();
//urun.UrunAdi = "Iphone 15";
//urun.Fiyatı = 30000;
#region context.AddAsync Fonksiyonu
//await context.AddAsync(urun); //Asenkron olarak ekleme yapar.
#endregion
#region context.DbSet.AddAsync Fonksiyonu
//await context.Urunler.AddAsync(urun); //Asenkron olarak ekleme yapar.
#endregion

//await context.SaveChangesAsync();

#endregion

#region SaveChanges Nedir?
//SaveChanges; insert, update ve deLete sorgularını oluşturup bir transaction eşliğinde veri tabanına gönderip execute eden fonksiyodur. Eğer ki oluşturulan sorgulardan herhangi biri başarısız olursa tüm işlemleri geri alır(roLIback)
#endregion

#region  EF Core Açısından Bir Verinin Eklenmesi Gerektiği Nasıl Anlaşılıyor?
//ETicaretDbContext context = new();
//Urun urun = new();
//{
//    urun.UrunAdi = "Iphone 15";
//    urun.Fiyatı = 30000;

//}
//Console.WriteLine(context.Entry(urun).State);
//await context.AddAsync(urun);
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync();
//Console.WriteLine(context.Entry(urun).State);
#endregion

#region Birden Fazla Veri Eklerken Nelere Dikkat Edilmelidir?
#region SaveChanges'1 Verimli Kullanalım!
//SaveChanges fonksiyonu her tetiklendiğinde bir transaction oluşituracağından dolayı EF Core iLe yapılan her bir işleme özel kullanmaktan kaçınmalıyız! Çünkü her işleme özel transaction veritaanı açısından ekstradan maliyet yüzden mümkün mertebe tüm işlemlerimizi tek bir transaction eşliğinde veritabanına gönderebilmek için demektir. O savechanges'ı aşağıdaki gibi tek seferde kullanmak hem maliyet hem de yönetilebilirlik açısından katkıda bulunmuş olacaktır.
//ETicaretDbContext context = new();
//Urun urun1 = new Urun();
//{
//    urun1.UrunAdi = "Iphone 15";
//    urun1.Fiyatı = 30000;
//}
//Urun urun2 = new Urun();
//{
//    urun2.UrunAdi = "Samsung S24";
//    urun2.Fiyatı = 35000;
//}
//Urun urun3 = new Urun();
//{
//    urun3.UrunAdi = "Xiaomi 14";
//    urun3.Fiyatı = 25000;
//}
//await context.AddAsync(urun1);
//await context.AddAsync(urun2);
//await context.AddAsync(urun3);
//await context.SaveChangesAsync();
#endregion
#region AddRange
//ETicaretDbContext contetx = new();
//Urun urun1 = new Urun();
//urun1.UrunAdi = "A";
//urun1.Fiyatı = 1000;

//Urun urun2 = new Urun();
//urun2.UrunAdi = "B";
//urun2.Fiyatı= 2000;

//Urun urun3 = new Urun();
//urun3.UrunAdi= "C";
//urun3.Fiyatı = 3000;

////await contetx.AddRangeAsync(urun1,urun2,urun3); //tip güvensiz
//await contetx.Urunler.AddRangeAsync(urun1, urun2, urun3); // tip güvenli
//await contetx.SaveChangesAsync();


#endregion
#endregion

#region Eklenen Verinin Generate Edilen id'sini Elde Etme
//ETicaretDbContext db = new();
//Urun u = new();
//u.UrunAdi = "E";
//u.Fiyatı = 6000;

//await db.Urunler.AddAsync(u);
//await db.SaveChangesAsync();
//Console.WriteLine(u.UrunId);
//Console.WriteLine(u.UrunAdi,u.Fiyatı);
#endregion

#region Veri Nasıl Güncellenir?
//ETicaretDbContext db = new();
//Urun urun= await db.Urunler.FirstOrDefaultAsync(u => u.UrunId == 3);
//urun.UrunAdi = "K";
//urun.Fiyatı = 9999;
//await db.SaveChangesAsync();
//Console.WriteLine(urun.UrunAdi);
#endregion

#region ChangeTracker Nedir ? Kısaca!
////ChangeTracker, context üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır. Bu takip mekanizması sayesinde context üzerinden gelen verilerle ilgili işlemler neticesinde update yahut delete sorgularının oluşturulacağı anlaşılır!

#endregion

#region Takip Edilmeyen Nesneler Nasıl Güncellenir?
//ETicaretDbContext db = new();
//Urun u = new() { UrunId = 1,
//UrunAdi="Yeni Ürün",
//Fiyatı=1234};

#endregion

#region Update Fonksiyonu
//ChangeTracker mekanizması tarafından takip edilmeyen nesnelerin güncellenebilmesi için Update fonksiyonu kullanılır!
//Update fonksiyonunu kullanabilmek için kesinlikle iLgiLi nesnede Id değeri verilmelidir! Bu değer güncellenecek(update sorgusu oluşturulacak) verinin hangisi oldunınu ifade edecektir.
// db.Urunler.Update(u);
//await db.SaveChangesAsync();

#endregion

#region EntityState Nedir?
//Bir entity instance'ının durumunu ifade eden bir referanstır.
//ETicaretDbContext context = new();
//Urun u = new();
//Console.WriteLine(context.Entry(u).State);
#endregion

#region EF Core Açısından Bir Verinin Güncellenmesi Gerektiği Nasıl Anlaşılıyor?
//ETicaretDbContext context = new();
//Urun urun = await context.Urunler.FirstOrDefaultAsync(u => u.UrunId == 3);
//Console.WriteLine(context.Entry(urun).State);
//urun.UrunAdi="Hilmi";
//Console.WriteLine(context.Urunler.Entry(urun).State);
//await context.SaveChangesAsync();
//Console.WriteLine(context.Urunler.Entry(urun).State);
#endregion

#region Birden Fazla Veri Güncellenirken Nelere Dikkat Edilmelidir?
//Her SaveChanges çağrıldığında bir transaction oluştuğundan dolayı mümkün mertebe tüm işlemlerimizi tek bir transaction eşliğinde veritabanına gönderebilmek için tek seferde SaveChanges'ı kullanmak hem maliyet hem de yönetilebilirlik açısından katkıda bulunmuş olacaktır.

//ETicaretDbContext context = new();

//var urunler= await context.Urunler.ToListAsync();
//foreach (var urun in urunler)
//{
//    urun.UrunAdi += " *";

//    Console.WriteLine(urun.UrunAdi);
//}
// await context.SaveChangesAsync();

#endregion

#region Veri Nasıl Silinir?
//ETicaretDbContext context = new();
//Urun urun= await context.Urunler.FirstOrDefaultAsync(u => u.UrunId == 1);
//Console.WriteLine(urun.UrunAdi);
//context.Urunler.Remove(urun);
//Console.WriteLine(context.Urunler.Entry(urun).State);
//await context.SaveChangesAsync();
#endregion

#region Silme IşLemınde ChangeTracker'ın Rolü
////ChangeTracker, context üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır. Bu takip mekanizması sayesinde context üzerinden gelen verilerle ilgili işlemler neticesinde update yahut delete sorgularının oluşturulacağı anlaşılır!
#endregion

#region Takip Edilmeyen Nesneler Nasıl Silinir?
//ETicaretDbContext context = new();
//Urun u = new() { UrunId = 2 };
//context.Urunler.Remove(u);
//await context.SaveChangesAsync();
#endregion

#region EntityState ile Silme İşlemi
//ETicaretDbContext context = new();
//Urun u = new() { UrunId = 3 };
//context.Urunler.Entry(u).State = EntityState.Deleted;
//await context.SaveChangesAsync();
#endregion

#region Birden Fazla Veriyi Silerken Nelere Dikkat Edilmelidir?
//Her SaveChanges çağrıldığında bir transaction oluştuğundan dolayı mümkün mertebe tüm işlemlerimizi tek bir transaction eşliğinde veritabanına gönderebilmek için tek seferde SaveChanges'ı kullanmak hem maliyet hem de yönetilebilirlik açısından katkıda bulunmuş olacaktır.
#region RemoveRange
//ETicaretDbContext context = new();
//List<Urun> urunler= await context.Urunler.Where(u=> u.UrunId>=3 &&  u.UrunId<=4).ToListAsync();
//context.Urunler.RemoveRange(urunler);
//context.SaveChanges();
#endregion
#endregion





public class ETicaretDbContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ETicaret;User Id=TestUser;Password=Test_123");
    }
}
public class Urun
{
    public int UrunId { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyatı { get; set; }
}


