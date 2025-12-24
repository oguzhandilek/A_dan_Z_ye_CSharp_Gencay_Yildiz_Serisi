// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

ApplicationDbContext context = new();

#region Connection Resiliency Nedir?
//EF Core üzerinde yapılan veritabanı çalışmaları sürecinde ister istemez veritabanı bağlantısında kopuşlar/ kesintiler vs. meydana gelebilmektedir.

//Connection Resiliency ile kopan bağlantıyı tekrar kurmak için gerekli tekrar bağlantı taleplerinde bulunabilir ve biryandan da execution strategy dediğimiz davranış modellerini belirleyerek bağlantıların kopması durumunda tekrar edecek olan sorguları baştan sona yeniden tetikleyebiliriz.
#endregion

#region EnableRetryOnFailure
//Uygu1ama sürecinde veritabanı bağlantısı koptuğu taktirde bu yapılandırma sayesinde bağlantıyı tekrardan kurmaya çalışabiliyirouz .

//while (true)
//{
//    await Task.Delay(2000);
//   var persons= await context.Persons.ToListAsync();
//    persons.ForEach(p=> Console.WriteLine(p.Name));
//    Console.WriteLine("*****************");

//}


#region MaxRetryCount
// Yeniden bağlantı sağlanması durumunun kaç kere gerçekleştirlecğeini bildirmektedir.
//Default değerş 6'dır
#endregion
#region MaxRetryDelay
// Yeniden bağlantı sağlanması periyodunu bildirmektedir.
//Default değeri 30' sn'dir.
#endregion
#endregion

#region Execution Strategies
//EF Core ile yapılan bir işlem sürecinde veritabanı bağlatışı koptuğu taktirde yeniden bağlantı denenirken yapılan davranışa/ alınan aksiyona Execution Strategy denmektedir.
// Bu stratejiyi default dğerLerde kullanabieceğimiz gibi custom olarak da kendimize göre özelleştireibilir ve bağlantı koptuğu durumlarda istediğimiz aksiyonları alabiliriz.

#region Default Execution Strategy
//Eğer ki Connection ResiLiencyr için EnableRetryOnFaiIure metodunu kullanıyorsak bu defauLt execution stratgy karşılık gelecektir.
// MaxRetryCount: 6 adet
//De1ay : 30 sn
//Defau1t değerlerin kullanıLaiLmesi için EnabLeRetryOnFaiIure metodunun parametresis overload'ının kullanılması gerekmektedir.
#endregion
#region Custom Execution Strategy

#region Oluşturma
//public class CustomExecutionStrategy : ExecutionStrategy
//{
//    public CustomExecutionStrategy(DbContext context, int maxRetryCount, TimeSpan maxRetryDelay) : base(context, maxRetryCount, maxRetryDelay)
//    {
//    }

//    public CustomExecutionStrategy(ExecutionStrategyDependencies dependencies, int maxRetryCount, TimeSpan maxRetryDelay) : base(dependencies, maxRetryCount, maxRetryDelay)
//    {
//    }
//    int retryCount = 0;
//    protected override bool ShouldRetryOn(Exception exception)
//    {
//        // Yeniden bağlantı durumunun söz konusu olduğu anlarda yapılacak işlemler...
//        Console.WriteLine($"#{++retryCount}. Bağlantı tekrar kuruluyor...");
//        return true;
//    }
//}
#endregion
#region Kullanma - ExecutionStrategy

#endregion
#endregion
#region Bağlantı Koptuğu Anda Execute Edilmesi Gereken Tüm Çalışmaları Tekrar İşlemek
//EF Core ile yapılan çalışma sürecinde veritabanı bağlantısının kesildiği durumlarda, bazen bağlantının tekrardan kurulması tek başına yetmemekte, keszintinin olduğu çalışmanın da baştan tekrardan işlenmesi gerekebilmetkedir. işte bu tarz durumlara karşılık EF Core Execute — ExecuteAsync fonksiyonunu bizlere sunmaktadır. 

//Execute fonksiyonu, içerisine vermiş olduğumuz kodları commit edilene kadar işleyecektir. Eğer ki bağlantı kesilmesi meydana gelirse, bağlantının tekrardan kurulması durumunda Execute içerisindeki çalışmalar tekrar baştan işlenecek ve böylece yapı Lan işlemin tutarlılığı için gerekli çalışma sağlanmış olacaktır.


//var strategy =  context.Database.CreateExecutionStrategy();
//await strategy.ExecuteAsync(async () =>
//{
//    using var transaction = await context.Database.BeginTransactionAsync();
//    await context.Persons.AddAsync(new Person() { Name = "Cumali" });
//    await context.SaveChangesAsync();
//    await context.Persons.AddAsync(new Person() { Name = "Cankat" });
//    await context.SaveChangesAsync();

//    await transaction.CommitAsync();
//});
#endregion
#region Execution Strategy Hangi Durumlarda Kullanılır?
// Veritabanının şifresi belirli periyotlarda otomatik olarak değişen uygulamalarda güncel şifreyle connection stringli sağlayacak bir operasyonu custom Fxecution strategy belirleyerek gerçekleştitrebilirsiniz.
#endregion
#endregion


public class Person
{
    public int PersonId { get; set; }
    public string? Name { get; set; }
}
public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #region Default Execution Strategy
        //optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ConnectionResiliencyD;Trusted_Connection=True;",
        //    builder =>
        //    builder.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(2), errorNumbersToAdd: new[] { 4060 }))
        //    .LogTo(filter: (eventId, level) => eventId.Id == CoreEventId.ExecutionStrategyRetrying,
        //    logger: eventData =>
        //    {
        //        Console.WriteLine($"Bağlantı kurulmaktadır");
        //    }
        //    );
        #endregion
        #region Custom Execution Strategy
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ConnectionResiliencyD;Trusted_Connection=True;",
            builder=> builder.ExecutionStrategy(dependecies=> new
            CustomExecutionStrategy(dependecies,3,TimeSpan.FromSeconds(15))));

        #endregion
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Person>()
            .HasData(
           new Person() {PersonId=1, Name="Ahmet"},
           new Person() {PersonId=2, Name="Hikmet"},
           new Person() {PersonId=3, Name="Zehmet"},
           new Person() {PersonId=4, Name="Melehat"}
            );
    }
}

public class CustomExecutionStrategy : ExecutionStrategy
{
    public CustomExecutionStrategy(DbContext context, int maxRetryCount, TimeSpan maxRetryDelay) : base(context, maxRetryCount, maxRetryDelay)
    {
    }

    public CustomExecutionStrategy(ExecutionStrategyDependencies dependencies, int maxRetryCount, TimeSpan maxRetryDelay) : base(dependencies, maxRetryCount, maxRetryDelay)
    {
    }
    int retryCount = 0;
    protected override bool ShouldRetryOn(Exception exception)
    {
        // Yeniden bağlantı durumunun söz konusu olduğu anlarda yapılacak işlemler...
        Console.WriteLine($"#{++retryCount}. Bağlantı tekrar kuruluyor...");
        return true;
    }
}