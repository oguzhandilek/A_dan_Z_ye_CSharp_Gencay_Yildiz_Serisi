// See https://aka.ms/new-console-template for more information
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
ApplicationDbContext context = new();

#region ExecuteUpdate
await context.Persons
        .Where(p => p.Id > 3)
        .ExecuteUpdateAsync(p => p.SetProperty(p => p.Name, v => v.Name + ".Yeni"));//ExecuteUpate eya delettte $"{}" kullanılmaz
#endregion
#region ExecuteDelete
await context.Persons
    .Where(p => p.Name.Contains("z"))
    .ExecuteDeleteAsync();
#endregion

//ExecuteUpdate ve ExecuteDeLete fonksiyonları ile bulk(toplu) veri güncelleme ve silme işlemleri gerçekleştirirken SaveChanges fonksiyonunu çağırmanız gerekmemektedir. Çünkü b fonksiyonlar adları üzerinde Execute... fonksiyonlarıdır. Yani direkt verittaanına fiziksel etkide bulunurlar.
//Eğer ki istyorsanız transaction kontrolünü ele alarak bu fonksiyonların işlevlerini de süreçte kontrol- edebilirsiniz.

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
public class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }

    private readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    builder
    .AddFilter((category, level) =>
    {
        return category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information;
    })
    .AddConsole());
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EfficientQueryDb;Trusted_Connection=True;");
        optionsBuilder.UseLoggerFactory(loggerFactory);

    }
}