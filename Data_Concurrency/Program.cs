using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

ApplicationDbContext context = new();
#region Data Concurrency Nedir?
//Geliştirdiğimiz uyğulamalarda ister istemez veriseL olarak tutarsızlıklar meydana gelebilmektedir.Örneğin; birden fazla uygulamanın yahut cLient 'ın aynı veritabanı üzerinde eşzamanı olarak çalıltığı durumlarda verişel- anlamda uyuglamadan uygulamaya yahut cLient 'tan cLienta tutarsızlıklar meydana gelebilir. 
//Data Concurrency kavramı, uygulamalardaki veri tutarsızlığı durumlarına karşılık yönetilebilirliği sağlayacak olan davranışları kapsayan bir kavramdır.
//Bir uygulamada veri tutarsızlığının olması demek o uygulamayı kullanan kullanıcıları yanıltmak demektir.
//Veri tutarsızlığının olduğu uygulamalarda istatistiksel olarak yanlış sonuçlar elde edilebilir...
#endregion
#region Stale & Dirty (Bayat ve Kirli) Data Nedir?
// Stale Data : Veri tutarsızlığına sebebiyet verebilecek güncellenmemiş yahut zamanı geçmiş olan verileri ifade etmektedir. Örneğin; bir ürünün stok durumu sıfırlandığı halde arayüz üzerinde bunu ifade eden bir güncelleme durumu söz konusu değilse işte bu stale data durumuna bir örnektir.

//Dirty Data : Veri tutarszılığına sebebiyet verebilecek verinin hatalı yahut yanlış olduğunu ifade etmektedir. Örneğin; adı 'Ahmet' olan bir kuLLanıcının veritabanında 'Mehmet' olarak tutulması dirty data örneklendirmesidir.

#endregion
#region Last In Wins (Son Gelen Kazanır)
//Bir veri yapısında son yapı Lan aksiyona göre en güncel verinin en üstte bulunmasını/varlığını korumasını ifade eden bir deyimsel terimdir.
#endregion
#region Pessimistic Lock (Kötümser Kilitleme)
//Bir transaction sürecinde elde edilen veriler üzerinde farklı sorgularla değişiklik yapılmasını engellemek için ilgili veriLerin kitlenmesini(locking) sağlayarak değişikliğe karşı direnç oluşturulmasını ifade eden bir yöntemdir.

//Bu verilerin kilitlenmesi durumu iLgiLi transaction 'ın commit ya da roLLback-edi1mesi ile sınırlıdır.
#region Deadlock Nedir ?(Kilitleme Çıkmazı - Ölüm Kilitlenmesi)
//Kitlenmiş olan bir verinin veirtabanı seviyesinde meydana gelen sistemsel bir hatadan dolayı kilidinin çözülememesi yahut döngüsel olarak kilitlenme durumunun meydana gelmesini ifade eden bir terimdir.

//Pessimistic Lock yönteminde deadlock durumunu yaşamanız bir ihtimaldir. 0 yüzden değerIendirLmesi gereken ve iyi düşünülerek tercih edilmesi gerken bir yaklaşımdır pessimistic Lock yaklaşımı.
#endregion
#region WITH(XLOCK)
//var transaction= await context.Database.BeginTransactionAsync();
//var person = await  context.Persons.FromSql($"Select * from Persons With (Xlock) where PersonId=5 ").FirstOrDefaultAsync();
//Console.WriteLine();
//await transaction.CommitAsync();
#endregion
#endregion
#region Optimistic Lock (iyimser Kilitleme)
//Bir verinin stale olup olmadığını anlamak için herhangi bir Locking işlemi olmaksızın versiyon mantığıonda çalışmamızı sağlayan yaklaşımdır.
//0ptimistic Lock yönteminde, Pessimistic lock'da olduğu gibi„veriler üzerinde tutarsızlığa mahal olabilecek değişiklikler fiziksel olarak engellenmemektedir. Yani veriler tutarsızlığı sağlayacak şekilde değiştirilebilir.
//Amma velakin Optimistic Lock yaklaşımı ile bu veriler üzerindeki tutarsızlık durumunu takip edebilmek için versiyon bilgisini kullanıyoruz. Bunu da şöyle kullanıyoruz;
//Her bir veriye karşılık bir versiyon bilgisi üretiliyor. Bu bilgi ister metinsel istersekte sayısal olabilir. Bu versiyon bilgisi veri üzerinde yapılan her bir değişiklik neticesinde güncellenecektir. Dolayısıyla bu güncellemeyi daha kolay bir şekild egerçkeleştirebilmek için sayısal olmasını tercih ederiz .
//EF Core üzerinden verileri sorgularken ilgili verilerin versiyon bilgilerini de in-memory'e alıyoruz. Ardından veri üzerinde bir değişiklik yapılırsa eğer bu inmemory ' deki versiyon bilgisi ile verityabanındaki versiyon bilgisini karşılaştıroyruz. Eğer ki bu karşılaştırma doğrulanıyorsa yapılan aksiyon geçerli olacaktır, yok eğer doğrulanmıyorsa demek ki verinin değeri değişmiş anlamına gelecek yani bir tutarsızlık durumu olduğu anlaşılacaktır. İşte bu durumda bir hata fırlatılacak ve aksiyon gerçekleştirilmeyecektir.

//EF Core Optimistic Lock yaklaşımı için genetinde yapısal bir özellik barındırmaktadır.
#region Property Based Configuration (ConcurrencyCheck Attribute)
//Verisel tutarlılığın kontrol edilmek istendiği proeprtyLer ConcurrencyCheck attribute'u ile işaretlenir. Bu işaretleme neticesinde her bir entity 'nin instance'ı için in—memory'de bir token değeri üretilecektir. Üretilen bu token değeri alınan aksiyon süreçlerinde EF Core tarafından doğrulacnacak ve eğer ki herhangi bir değişiklik yoksa aksiyon başarıyla sonlandırılmış olacaktır. Yok eğer transaction sürecinde ilgili veri üzerinde(ConcurrencyCheck attribute ile işaretlenmiş propertylerde) herhangi bir değişiklik durumu söz konusuysa o taktirde üretilen token 'da değiştirilecek ve haliyle doğrulama sürecinde geçerli olmayacağı anlaşılacağı için veri tutarsızlığı durumu olduğu anlaşılacak ve hata fırlatılacaktır.

//İster Entity'de ki property ye     [ConcurrencyCheck] attribute'nu ekleyerek isterseniz fluent api'de IsConcurrencyToken(); ile onmodelcreating metodunda konfiügre edebilirsiniz.


//var person = await context.Persons.FindAsync(3);
//context.Entry(person).State=EntityState.Modified;
//await context.SaveChangesAsync();
#endregion
#region RowVersion Column
//Bu yaklaşımda ise veritabanındaki her bir satıra karşılık versiyon bilgisi fiziksel olarak oluşturulmaktadır.

//Bu yapılandırmada öncelikle Entitye    public byte[] RowVersion { get; set; } propunu eklemeniz gerekir. daha sonra ister atttribute ile ister fluent api ile konfigüre edebilirsiniz.
var person = await context.Persons.FindAsync(3);
context.Entry(person).State = EntityState.Modified;
await context.SaveChangesAsync();
#endregion
#endregion


Console.WriteLine("Hello, World!");

public class Person
{
    public int PersonId { get; set; }
    //[ConcurrencyCheck]
    public string Name { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}

public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }

    readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder
      .AddFilter((category, level) =>
      {
          return category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information;
      }
      )
      .AddConsole());
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=Data_Concurrency;Trusted_Connection=True;");
        optionsBuilder.UseLoggerFactory(loggerFactory);


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Person>().Property(p=> p.Name).IsConcurrencyToken();
        modelBuilder.Entity<Person>().Property(p => p.RowVersion).IsRowVersion();
        modelBuilder.Entity<Person>().HasKey(p=> p.PersonId);
        modelBuilder.Entity<Person>()
            .HasData( new Person[]
            {
                new(){PersonId=1,Name="Rıfkı"},
                new(){PersonId=2,Name="Hikmet"},
                new(){PersonId=3,Name="Rızaettin"},
                new(){PersonId=4,Name="Tanju"},
                new(){PersonId=5,Name="Mahmut"},
                new(){PersonId=6,Name="Tansel"},
                new(){PersonId=7,Name="Cugulii"}
            });
    }
}