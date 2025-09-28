// See https://aka.ms/new-console-template for more information
using ChangeTracker;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("AlbeyazımSoft");
EticaretContext context = new();

#region Change Tracking Neydi?
//Context nesnesi üzerinden gelen tüm nesneler/veriler otomatik olarak bir takip mekanizması tarafından izlenirler. İşte bu takip mekanizmasına Change Tracker denir. Change Traker i Le nesneler üzerindeki değişiklikler/ işlemler takip edilerek netice itibariyle bu işlemlerin fıtratına uygun sqL sorgucukları generate edilir. işte bu işleme de Chan e Trackin denir.
#endregion

#region ChangeTracker Propertysi
// Takip edilen nesnelere erişebilmemizi sağlayan ve gerektiği taktirde işlemler gerçekşetirmemizi sağlayan bir propertydir. 
//context sınıfının base cLass'ı olan DbContext sınıfının bir member' ıdır.

//var urunler = await context.Urunlers.ToListAsync();
//urunler[6].UrunAdi = "Değişik Ürün";
//urunler[7].Fiyat = 10;
//context.Urunlers.Remove(urunler[8]);
//var datas = context.ChangeTracker.Entries();

#region DetectChanges Metod
//EF Core, context nesnesi tarafından izlenen tüm nesnelerdeki değişiklikleri Change Tracker sayesinde takip edebilmekte ve nesnelerde olan veriseL değişiklikler yakalanarak bunların anlık görüntüleri(snapshot) ini oluşturabilir.
// Yapılan değişikliklerin veritabanına gönderilmeden önce algılandığından emin olmak gerekir. SaveChanges fonksiyonu çağrıldığı anda nesneler EF Core tarafından otomatik kontrol edilirler.
//Ancak, yapılan operasyonlarda güncel tracking verilerinden emin olabilmek için değişişikLerin algılanmasını opsiyonel olarak gerçekleştirmek isteyebiliriz. İşte bunun için DetectChanges fonksiyonu kullanılabilir ve her nel kadar EF Core değişikleri otomatik algılıyor olsa da siz yine de iradenizle kontrole zorlayabilirsiniz.

//var urun =await context.Urunlers.FirstOrDefaultAsync(u=> u.Id==3);
//urun.Fiyat = 123;
//context.ChangeTracker.DetectChanges();
//await context.SaveChangesAsync();
#endregion

#region AutoDetectChangesEnabLed Property' si
//İLgi1i metotLar(SaveChanges, Entries) tarafından DetectChanges metodunun otomatik olarak tetiklenmesinin konfigürasyonunu yapmamızı sağlayan proeportydir.
//SaveChanges fonksiyonu tetiklendiğinde DetectChanges metodunu içerisinde default olarak çağırmaktadır. Bu durumdaDetectChanges fonksiyonunun kullanımını irademizle yönetmek ve maliyet/performans optimizasyonu yapmak istediğimiz durumlarda AutoDetectChangesEnab1ed özelliğini kapatabiliriz.
#endregion

#region  Entries Metodu
//Context'te ki Entry metodunun koleksiyonel versiyonudur.
//Change Tracker mekanizması tarafından izlenen her entity nesnesinin bigisini EntityEntry türünden elde etmemizi sav Lar ve belirli islemler a abilmemize olanak tanır.
//Entries metodu, DetectChanges metodunu tetikler. Bu durum da tıpkı SaveChanges 'da olduğu gibi bir maliyettir.Buradaki maliyetten kaçınmak için AuthoDetectChangesEnabLed özelliğine false değeri verilebilir.
//var urunler = await context.Urunlers.ToListAsync();
//urunler.FirstOrDefault(u => u.Id == 7).Fiyat = 2222;
//urunler.FirstOrDefault(u => u.Id == 8).UrunAdi = "Başka Ürün";
//context.Remove(urunler.FirstOrDefault(u => u.Id == 10));
//context.ChangeTracker.Entries().ToList().ForEach(entry =>
//{
//    if (entry.State==EntityState.Unchanged)
//    {
//        ///..
//    }
//    else if (entry.State==EntityState.Deleted)
//    {
//        //....
//    }

//});
#endregion

#region AcceptALIChanges Metodu
//SaveChanges() veya SaveChanges(true) tetiklendiğinde EF Core herşeyin yolunda olduğunu varsayarak track ettiği verilerin takibini keser yeni değişikliklerin takip edilmesini bekler. Böyle bir durumda beklenmeyen bir durum/olası bir hata söz konusu olursa eğer EF Core takip ettiği nesneleri bırakacağı için bir düzeltme mevzu bahis olamayacaktır.
//HaLiy1e bu durumda devreye SaveChanges(false)  ve AcceptAllChanges metotları girecektir.
//SaveChanges(Fa1se), EF Core'a gerekli veritabanı komutlarını yürütmesini söyler ancak gerektiğinde yeniden oynatılabilmesi için değişikleri beklemeye/nesneleri takip etmeye devam eder. Taa ki AcceptAllChanges metodunu irademizle çağırana kadar!
//SaveChanges(false) ile işlemin başarılı olduğundan emin olursanız AcceptAllChanges metodu ile nesnelerden takibi kesebilirsiniz .

//await context.SaveChangesAsync(false);
//context.ChangeTracker.AcceptAllChanges();

#endregion

#region HasChanges Metodu
// Takip edilen nesneler arasından değişiklik yapılanların olup olmadığının bilgisini verir.
//Arkap1anda DetectChanges metodunu tetikler.
//var result=context.ChangeTracker.HasChanges();
#endregion

#endregion

#region Entity States
//Entity nesnelerinin durumlarını ifade eder.
#region Detached
//Nesnenin change tracker mekanizması tarafıdnan takip edilmediğini ifade eder.

//Urunler urun = new();
//urun.UrunAdi="kdjfklsfl"
//Console.WriteLine(context.Urunlers.Entry(urun).State);

#endregion

#region Added
//Veritabanına eklenecek nesneyi ifade eder. Adeed henüz veritabanına işlenmeyen veriyi ifade eder. SaveChanges fonksiyonu insert sor usu oluşturulacağı anlamını gelir.

//Urunler u = new()
//{
//    UrunAdi = "Eklenen Ürün",
//    Fiyat=98745,
//};
//Console.WriteLine(context.Urunlers.Entry(u).State);
// await context.Urunlers.AddAsync(u);
//Console.WriteLine( context.Urunlers.Entry(u).State);
//await context.SaveChangesAsync();
//u.Fiyat = 111111; //not normalde add olamsaydı burda nesne taip ediemeyecekti. ancak add ile takip mekanizmasına girdi.
//Console.WriteLine(context.Urunlers.Entry(u).State);
//await context.SaveChangesAsync();
#endregion

#region Unchanged
// Veritabanından sorgulaTndığından beri nesne üzerinde herhangi bir değişiklik yapılmadığını ifade eder. Sorgu neticesinde elde edilen tüm nesneler başlangıçta bu state değerindedir.
#endregion
#region Modified
//Nesne üzerinde değşiikLik/güncelIeme yapıldığını ifade eder. SaveChanges fonksiyonu çağrıldığında update sorgusu oluşturulacağı anlamına gelir .
#endregion
#region Deleted
//Nesnenin silindiğini ifade eder. SaveChanges fonksiyonu çağrıldığında delete sorgusu oluşturuculağı anlamına
#endregion
#endregion

#region Context Nesnesi Üzerinden Change Tracker

//var urun = await context.Urunlers.FirstOrDefaultAsync(u => u.Id == 69);
//urun.Fiyat = 1236;
//urun.UrunAdi = "Değişen Urün";

#region Entry Metodu
#region OriginalVaLues Property ' si
//var urunFiyati = context.Entry(urun).OriginalValues.GetValue<float>(nameof(Urunler.Fiyat));
//var urunAdi = context.Entry(urun).OriginalValues.GetValue<string>(nameof(Urunler.UrunAdi));

#endregion
#region CurrentValues Property'si
//var urunMevcutAdi = context.Entry(urun).CurrentValues.GetValue<string>(nameof(Urunler.UrunAdi)); //Yukaırda modified | update olduğu için heap'teki deeğer gelmiş oldu.
#endregion
#region GetDatabaseValues Metodu
//var _urunAdiDatabase= await context.Entry(urun).GetDatabaseValuesAsync();
#endregion
#endregion

#endregion

#region Change Tracker'ın Interceptor Olarak Kullanılması
//SaveChanges() fonk.nunu override ederek interceptor mantığında opeasyonlar gerçekleştirebiliriz.
//Yani veritabanına gönderilemdem önce Changetracker ile takip edip işlem yapılcak verinin durumunda göre değişiklik yapıp veritababnına commit edeviliriz örenği bu proje içinde ETİcaretCotext.cs içindedir.
#endregion

Console.WriteLine( );