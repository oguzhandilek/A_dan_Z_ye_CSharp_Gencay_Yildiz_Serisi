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

#endregion
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