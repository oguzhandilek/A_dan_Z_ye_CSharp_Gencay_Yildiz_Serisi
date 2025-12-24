using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;

ApplicationDbContext context = new();
#region Neden Loglama Yaparız?
//ÇaLışan bir sistemin runtime 'da nasıl davranış gerçekleştirdiğini gözlemleyebilmek için log mekanizmalarından istifade ederiz.
#endregion
#region Neleri Loglarız?
// Yapılan sorguların çalışma süreçlerindeki davranışları. 
//Gerekirse hassas veriler üzerinde de logLama işlemleri gerçekleştiriyoruz .
#endregion
#region Basit Olarak Loglama Nasıl Yapılır?
//Minumum yapılandırma gerektirmesi.
//Herhangi bir nuget paketine ihtiyaç duyulmaksızın LogLamanın yapılabilmesi.
//bool checkConnect =context.Database.CanConnect();
//context.Database.CloseConnection();
 var datas= await context.Persons.ToListAsync();

#region Debug Penceresine Log Nasıl Atılır?
//optionsBuilder.LogTo(Console.WriteLine);//Dbcontex sınıfında yer alan OnConfiguring metodunda kullanılır
#endregion
#region Bir Dosyaya Log Nasıl Atılır?
//NormaLde consoLe yahut debug pencerelerine atılan logLar pek takip edilebilir nitelikte olmamaktadır. 
//Log1arı kalıcı hale getirmek istediğimiz durumlarda en basit halyile bu logları harici bir dosyaya atmak isteyebiliriz.
#endregion

#endregion
#region Hassas Verilerin Loglanması - EnableSensetiveDataLogging
//Default,oİarak EF Core Log mesajlarında herhangi bir verinin değerini içermemektedir. Bunun nedeni, gizlilik teşkil- edebilecek verilerin LogLama sürecinde yanlışlıklada olsa açığa çıkmamasıdır.
//Bazen alınan hatalarda verinin değerini bilmek hatayı debug edebilmek için oldukça yardımcı olabilmektedir. Bu durumda hassas verilerinde loglamasını sağlayabiliriz.
//.EnableSensitiveDataLogging() 

#endregion
#region Exception Ayrıntısını Loglama - EnableDetailedErrors
//.EnableDetailedErrors();
#endregion
#region Log Levels
//EF Core default olarak Debug sevisinin üstündeki(debug dahi) tüm davranıuşları logLar.
#endregion
Console.WriteLine("Hello, World!");
public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

public class Order
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }

    public Person Person { get; set; } = default!;

}

public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(locald)\\local;Database=EfCoreLogging;Trusted_Connection=True;");
        //optionsBuilder.LogTo(Console.WriteLine);

        //optionsBuilder.LogTo(message=> Debug.WriteLine(message));

        //optionsBuilder.LogTo(message=> _log.WriteLine(message));
        optionsBuilder.LogTo(async message=> await _log.WriteLineAsync(message),LogLevel.Warning)
            .EnableSensitiveDataLogging()//Hassas verilerin açık hale getirmesi
            .EnableDetailedErrors(); //Hata deatylarını açık hale getirilmesi
    }
    StreamWriter _log=new StreamWriter("logs.txt",append:true); //Buradaki log.txt dısyasını StreamWriter tükettiğimiz için farkllı bir uygulama/kullanııc/işletim sistemi tarafından kullanılabilmesi için bu Stream'den kopması grekecektir. Bu nedenle aşağıdaki Dispose metodlarını çağırarak _log' u dispose ediyoruz.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    public override void Dispose()
    {
        base.Dispose();
        _log.Dispose();
    }
    public override async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();
        await _log.DisposeAsync();
    }

}
