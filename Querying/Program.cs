// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("AlbeyazımSoft!");
ETİcaretContext context = new();

#region En Temel Basit Bir Sorgulama Nasıl Yapılır?

#region Method Syntax
//Linq Fonksiyonalrı
//var urunler= await context.Urunler.ToListAsync();
#endregion

#region Query Syntax
//Linq Query
//var urunler2 = await (from urun in context.Urunler 
//                      select urun).ToListAsync();
#endregion

#endregion

#region Sorguyu Execute Etmek İçin Ne Yapmamız Gerekmektedir?
#region ToListAsync
#region Method Syntax
//var urunler= await context.Urunler.ToListAsync();
#endregion
#region Query Syntax
//var urunler = await (from urun in context.Urunler
//              select urun).ToListAsync();
#endregion
#endregion

//int urunId = 5;
//string urunAdi = "2";
//var urunler = from urun in context.Urunler
//              where urun.Id > urunId && urun.UrunAdi.Contains(urunAdi)
//              select urun;
//urunId = 200;
//urunAdi = "4";

//await urunler.ToListAsync();
#region Foreach
//foreach (Urun urun1 in urunler)
//{
//    Console.WriteLine(urun1.UrunAdi);
//}
#region Deferred Execution(ErteIenmiş Çalışma)
//IQueryable çalışmalarında ilgili kod yazıldığı noktada tetiklenmez/çaLıştırılmaz yani ilgili kod yazıldığı noktada sorguyu generate etmez! Nerede eder? Çalıştırıldığı/execute edildiği noktada tetiklenir! İşte bu durumada ertelenmiş çalışma denir!
#endregion
#endregion

#endregion

#region IQueryab1e ve 1Enumerab1e Nedir? Basit Olarak!

//var urunler = await (from urun in context.Urunler
//              select urun).ToListAsync();


#region IQueyable
// Sorguya karşılık gelir.
// Ef core üzerinden yapılmış olan sorgunun execute edilmemiş halini ifade eder.
#endregion
#region IEnumerable
// Sorgunun çalıştırılıp/execute edilip verilerin in memorye yüklenmiş halini ifade eder.
#endregion
#endregion

#region Çoğul Veri Getiren Sorgulama Fonksiyonları

#region ToListAsync
//üretilen sorguyu execute ettirmemizi sağlayan fonksiyondur.
#region Method Syntax
//var urunler=await context.Urunler.ToListAsync();
#endregion
#region Query Syntax
//var urunler2 = await (from urun in context.Urunler
//               select urun).ToListAsync();
//var urunler3 = from urun in context.Urunler
//               select urun;
//var datas=await urunler3.ToListAsync();

#endregion
#endregion

#region Where
//O1uşturu1an sorguya where şartı eklememizi sağlayan bir fonksiyondur.

#region Method Syntax
//var urunler=await context.Urunler
//    .Where(u => u.Id > 100 && u.UrunAdi.Contains("5"))
//    .ToListAsync();
//Console.WriteLine();

#endregion

#region Query Syntax
//var urunler = from urun in context.Urunler
//              where urun.Id > 50 && urun.UrunAdi.StartsWith("7")
//              select urun;
//var datas=await urunler.ToListAsync();

#endregion
#endregion

#region OrderBy
// Sorgu üzerinde sıralama yapmamızı sağlayan bir fonksiyondur.(Ascending)
#region Method Syntax
//var urunler = await context.Urunler
//   .Where(u=> u.Id>50)
//   .OrderBy(u=> u.UrunAdi) 
//   .ToListAsync();
#endregion
#region Query Syntax
//var urunler2 = from urun in context.Urunler
//               where urun.Id>20 && urun.UrunAdi.EndsWith("5")
//               orderby urun.UrunAdi 
//               select urun;
//await urunler2.ToListAsync();

#endregion

#endregion

#region ThenBy
//OrderBy üzerinde yapılan sıralama işlemini farklı kolonlarada uygulamamızı sağlayan bir fonksiyondur.(Ascending)
//var urunler = context.Urunler
//    .Where(u => u.Id > 100)
//    .OrderBy(u => u.UrunAdi)
//    .ThenBy(u => u.Fiyat);
//await urunler.ToListAsync();

//var urunler=from urun in context.Urunler
//where urun.UrunAdi.Contains("20") && urun.Fiyat < 50
//orderby urun.Fiyat, urun.Id
//select urun;

#endregion

#region OrderByDescending && ThenByDescending
//Descending olarak sıralama yapmamızı sağlayan bir fonksiyondur.
#region Method Syntax
//var urunler = context.Urunler
//    .OrderByDescending(u => u.Id)
//    .ThenByDescending(u=> u.Fiyat);
#endregion
#region Query Syntax
//var urunler = from urun in context.Urunler
//              orderby urun.Id,urun.Fiyat descending
//              select urun;

#endregion
#endregion
//foreach (var u in urunler)
//{
//    Console.WriteLine($"Id:{u.Id} Urun Adı: {u.UrunAdi} Fiyatı: {u.Fiyat}");
//}
#endregion

#region Tekil Veri Getiren Sorgulama Fonksiyonları
// Yapılan sorguda sade ve sadece tek bir verinin gelmesi amaçlanıyorsa Single ya da SingLe0rDefauLt fonksiyonları kullanılabilir.
#region SingleAsync
//Eğer ki, sorgu neticesinde birden fazla veri geliyorsa ya da hiç gelmiyorsa her iki durumda da exception fırlatır.
#region Tek Kayıt Geldiğinde
//var urun = await context.Urunler.SingleAsync(u => u.Id == 25);
//Console.WriteLine(urun.Fiyat);
#endregion
#region Hiç Kayıt Gelmediğinde
//var urun = await context.Urunler.SingleAsync(u => u.Id == 5555);
//Console.WriteLine(urun.UrunAdi);
#endregion
#region Çok Kayıt Geldiğinde
//var urun = await context.Urunler.SingleAsync(u => u.Id > 10);
//Console.WriteLine(urun.Fiyat);
#endregion
#endregion

#region Sing1eOrDefauLtAsync
//Eğer ki, sorgu neticesinde birden fazla veri geliyorsa exception fırlatır, hiç veri gelmiyorsa null döner.
#region Tek Kayıt Geldiğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id==2);
//Console.WriteLine(urun?.UrunAdi);
#endregion
#region Hiç Kayıt Gelmediğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.UrunAdi == "Q");
//Console.WriteLine(urun?.UrunAdi);
#endregion
#region Çok Kayıt Geldiğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id > 2);
//Console.WriteLine(urun?.UrunAdi);
#endregion
#endregion

// Yapılan sorguda tek bir verinin gelmesi amaçlanıyorsa First ya da FirstOrDefauLt fonksiyonları kullanılabilir. 
#region FirstAsync
// Sorgu neticesinde elde edilen verilerden ilkini getirir. Eğer ki hiç veri gelmiyorsa hata fırlatır.
#region Tek Kayıt Geldiğinde
//var urun= await context.Urunler.FirstAsync(u=> u.Id==6);
#endregion
#region Hiç Kayıt Gelmediğinde
//var urun = await context.Urunler.FirstAsync(u => u.Id == 3333);
#endregion
#region Çok Kayıt Geldiğinde
//var urun = await context.Urunler.FirstAsync(u=> u.Id>10);
#endregion
#endregion

#region FirstOrDefaultAsync
// Sorgu neticesinde elde edilen verilerden ilkini getirir. Eğer ki hiç veri gelmiyorsa null döner.
#region Tek Kayıt Geldiğinde
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 6);
#endregion
#region Hiç Kayıt Gelmediğinde
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3333);
#endregion
#region Çok Kayıt Geldiğinde
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id > 10);
#endregion
#endregion


#region FindAsync
//Find fonksiyonu, primary key kolonuna özel hızlı bir şekilde sorgulama yapmamızı sağlayan bir fonksiyondur.
//Sorgulama sürecince önce içerisini kontrol eder, kaydı bulamadığı taktirde sorguyu yeritabanına gönderir.
//Yalnızca pyimqru key alanlarını sorgulayabilir.
//Kayıt bulunamazsa döndürür.
//Urun urun = await context.Urunler.FindAsync(55);
//Console.WriteLine(urun.UrunAdi);
#region Composite Primary key Durumu
//Parca parca = await context.Parcalar.FindAsync(2, 5); //(UrunId,ParcaId)
#endregion
#endregion

#region LastAsync
// Sorgu neticesinde elde edilen verilerden sonuncusunu getirir. Eğer ki hiç veri gelmiyorsa hata fırlatır.
//Ancak OrderBy kullanmak zorunludur

//var urun=await context.Urunler.OrderBy(u=> u.Fiyat).LastAsync(u=> u.Id>55);

#endregion

#region LastOrDefaultAsync
// Sorgu neticesinde gelen verilerden en sonuncusunu getirir. Eğer ki hiç veri gelmiyorsa null döner. OrderBy kullanılması mecburidir.
//var urun = await context.Urunler.OrderBy(u => u.Fiyat).LastOrDefaultAsync(u => u.Id > 55);
#endregion



#endregion
Console.WriteLine();
public class ETİcaretContext:DbContext
{
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Parca> Parcalar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ETicaret;User Id=TestUser;Password=Test_123;");
    }
}

public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }
    public ICollection<Parca> Parcalar { get; set; }
}

public class Parca
{
    public int Id { get; set; }
    public string ParcaAdi { get; set; }
}