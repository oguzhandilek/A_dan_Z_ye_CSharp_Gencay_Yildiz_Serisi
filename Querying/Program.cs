// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
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

#region Diğer Sorgulama Fonksiyonları

#region CountAsync
//01uşturuLan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak (int)bizlere bildiren fonksiyondur.
//var urunCount = (await context.Urunler.ToListAsync()).Count(); // Bu şekilede IEnumerable 'da önce veritabanından tüm sorguyu çekip sonra memory'de satır sayısını sadık. bu işlem maliyetlidir tercih edilmemeli.
//var urunCount = await context.Urunler.CountAsync(u=> u.Id>200);
//Console.WriteLine(urunCount);
#endregion

#region LongCountAsync
//01uşturuLan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak (long)bizlere bildiren fonksiyondur.
//var countUrun = await context.Urunler.LongCountAsync();
//Console.WriteLine(countUrun);
#endregion

#region AnyAsync
// Sorgu neticesinde verinin gelip gelmediğini bool türünde dönen fonksiyondur. SQL'de Existis fonksiyonuna eş değerdir.
//var checkOut = await context.Urunler.AnyAsync(u => u.UrunAdi.Contains("1"));
//var checkIn = await context.Urunler.Where(u=> u.UrunAdi.Contains("2")).AnyAsync();
//Console.WriteLine(checkOut);
//Console.WriteLine(checkIn);
#endregion

#region MaxAsync
//VeriLen kolondaki max değeri getirir.
//var maxFiayat = await context.Urunler.MaxAsync(u => u.Fiyat);
//Console.WriteLine(maxFiayat);
#endregion

#region MinAsync
//VeriLen kolondaki min değeri getirir.
//var minFiyat = await context.Urunler.MinAsync(u => u.Fiyat);
//Console.WriteLine(minFiyat);
#endregion

#region Distinct
// Sorguda mükerrer kayıtlar varsa bunları tekilleştiren bir işleve sahip fonksiyondur.
//var tekilGetir = await context.Urunler.Distinct().ToListAsync();

#endregion

#region AllAsync
//Bir sorgu neticesinde gelen verilerin, verilen şarta uyup uymadığını kontrol etmektedir. Eğer ki tüm veriler şarta uyuyorsa true, uymuyorsa false döndürecektir. SQL'deki Not Exists iel eşdeğerdir.
//var notExists = await context.Urunler.AllAsync(u => u.Fiyat > 1500);
//Console.WriteLine(notExists);
#endregion

#region SumAsync
//Vermiş olduğumuz sayısal proeprtynin toplamını alır.
//var toplamFiyat = await context.Urunler.SumAsync(u=> u.Fiyat);
//Console.WriteLine(toplamFiyat);
#endregion

#region AvarageAsync
// Vermiş olduğumuz sayısal proeprtynin aritmatik ortalamasını aLır.
//var ortlamaFiyat= await context.Urunler.AverageAsync(u=> u.Fiyat);
//Console.WriteLine(ortlamaFiyat);
#endregion

#region Contains
// Like '%... %' sorgusu oluşturmamızı sağlar.
//var icinde = await context.Urunler
//    .Where(u => u.UrunAdi.Contains("5"))
//    .ToListAsync();
//foreach (var item in icinde)
//{
//    Console.WriteLine(item.UrunAdi);
//}
#endregion

#region StartsWith
// Like '... %' sorgusu oluşturmamızı sağlar.
//var basinda = await context.Urunler
//    .Where(u => u.UrunAdi.StartsWith("Ü"))
//    .ToListAsync();
//foreach (var item in basinda)
//{
//    Console.WriteLine(item.UrunAdi);
//}
#endregion

#region EndsWith
// Like '%...' sorgusu oluşturmamızı sağlar.
//var sonunda = await context.Urunler
//    .Where(u => u.UrunAdi.EndsWith("Ü"))
//    .ToListAsync();
//foreach (var item in sonunda)
//{
//    Console.WriteLine(item.UrunAdi);
//}
#endregion
#endregion

#region Sorgu Sonucu Dönüşüm Fonksiyonlar
//Bu fonksiyonlar ile sorgu neticesinde elde edilen verileri isteğimiz doğrultuusnda Çarklı türlerde projecsiyon edebiliyoruz .

#region ToDictionaryAsync
// Sorgu neticesinde gelecek olan veriyi eğer bir dictioanry olarak elde etmek/tutmak/karşılamak istiyorsak  kullanılır!
//var keyValue = await context.Urunler.ToDictionaryAsync(u => u.UrunAdi, f => f.Fiyat);
//foreach (var item in keyValue)
//{
//    Console.WriteLine(item.Key,item.Value);
//}
//ToList ile aynı amaca hizmet etmektedir. Yani, oluşturulan sorguyu execute edip neticesini alırlar.
//ToList : Gelen sorgu neticesini entity türünde bir <TEntity> dönüştürmekteyken ,
//ToDictionary ise : Gelen sorgu neticesini Dictionary türünden bir koleksiyona dönüştürecektir.
//JavaScript'teki map(key,value) e eşdeğerdir.
#endregion

#region ToArrayAsync
//0Luşturu1an sorguyu dizi olarak elde eder.
//ToList ile muadil amaca hizmet eder. Yani sorguyu execute eder lakin gelen sonucu entity dizisi olarak elde eder.
//var urunDizisi= await context.Urunler.ToArrayAsync();
#endregion

#region Select
// Select fonksiyonunun işlevsel olarak birden -Fazla davranışı söz konusudur,
// 1. Select fonksiyonu, generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır.

//var urunler = await context.Urunler
//    .Select(u=> new Urun
//    {
//        Id = u.Id,
//        UrunAdi=u.UrunAdi
//    })
//    .ToListAsync();

// 2. Select fonksiyonu, gelen verileri farklı türlerde karşılamamızı sağlar. T, anonim
//var urunler = await context.Urunler
//    .Select(u => new 
//    {
//        Id = u.Id,
//        UrunAdi = u.UrunAdi
//    })
//    .ToListAsync();

#endregion

#region SelectMany
// Select ile aynı-amaca hizmet eder. Lakin, ilişkisel tablolar neticesinde gelen koleksiyonel verileri de tekilleştirip projeksiyon etmemizi sağlar.
//var urunler = await context.Urunler
//    .Include(u=> u.Parcalar)
//    .SelectMany(u=> u.Parcalar,(u,p)=> new
//    {
//        u.Id,
//        u.UrunAdi,
//        p.ParcaAdi,
//    }).ToListAsync();
#endregion

#region GroupBy
//GrupIama yapmamızı sağlayan -Fonksiyondur.

#region Method Syntax
//var datas= await context.Urunler
//    .GroupBy(u=> u.Fiyat)
//    .Select(group=> new
//    {
//        Count=group.Count(),
//        Fiyat=group.Key
//    }).ToListAsync();

//having nasıl olacak
#endregion

#region Query Syntax
//var datas = await (from urun in context.Urunler
//                   group urun by urun.Fiyat
//          into g
//                   select new
//                   {
//                       Fiyat = g.Key,
//                       Count = g.Count()
//                   }).ToListAsync();
#endregion
#endregion

#region Foreach Fonksiyonu
//Bir sorgulama fonksiyonu fezan değildir!
// Sorgulama neticesinde elde edilen koleksiyonel veriler üzerinde iterasyonel olarak dönmemizi ve teker teker verileri elde edip işlemler yapabilmemizi sağlayan bir fonksiyondur. Çoreach döngüsünün metot halidir!
//foreach (var item in datas)
//{
    
//};
//datas.ForEach(data => { 
//});
#endregion
#endregion



Console.WriteLine();
public class ETİcaretContext:DbContext
{
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Parca> Parcalar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ETicaret;User Id=TestUser;Password=Test_123;");
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ETicaret;Trusted_Connection=True;");

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