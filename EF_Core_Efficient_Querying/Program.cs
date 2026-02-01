using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

ApplicationDbContext context = new();
#region EF Core Select Sorgularını Güçlendirme Teknikleri

#region IQueryable - IEnumerable Farkı
//IQueryabIe, bu arayüz üzerinde yapılan işlemler direkt generate edilecek olan sorguya yansıtılacaktır.
//IEnumerabLe, bu arayüz üzerinde yapılan işlemler temel sorgu neticesinde gelen ve in—memorye yüklenen instance 'lar üzerinde gerçekleştirilir. Yani sorguya yansıtılmaz.
//IQueryabLe ile yapılan sorgulama çalışmalarında sqL sorguyu hedef verileri elde edecek şekilde generate edilecekken, 1EnumerabIe i Le yapılan sorgulama çalışmalarında sql daha geniş verileri getirebilecek şekilde execute edilerek hedef veriler in—memorylde ayıklanır.
//IQueryab1e hedef verileri getirirken, hedef verilerden daha fazlasını getirip in—memory'de ayıklar.

#region IQueryable
//var getPersons = await context.Persons
//                       .Where(p => p.Name.Contains("e"))
//                       .Take(3)
//                       .Skip(2)
//                       .ToListAsync();

#endregion
#region IEnumerable
//var getPersonList = context.Persons
//   .Where(p => p.Name.Contains("e"))
//   .AsEnumerable()
//   .Where(p => p.Name.EndsWith("e"))
//   .ToList();

#endregion

#region AsQeuryable 

#endregion
#region AsEnumareble

#endregion
#endregion

#region Yanlızca İhtiyaç Olan Kolonları Listeleyin-Select
//var persons = await context.Persons
//                   .Select(p => new
//                   {
//                       p.Name

//                   })
//                   .ToListAsync();
#endregion

#region Result'ı Limitleyin - Take
//await context.Persons
//   .Take(10)
//   .ToListAsync();
#endregion

#region Join Sorgularında Eager Loading Sürecinde Verileri Filtreleyin
//var persons = await context.Persons
//                    .Include(p => p.Orders.Where(o => o.Id % 2 == 0)
//                                          .OrderByDescending(o => o.Id)
//                                          .Take(4))
//                    .ToListAsync();
#endregion

#region Şartlara Bağlı Join Yapılcaksa Explicit Loading Kullanın
//var person= await context.Persons.FirstOrDefaultAsync(p=> p.Id == 1);
//if (person.Name== "Muhiyittin")
//{
//    //Order'larını getir.
//    await context.Entry(person).Collection(p=> p.Orders).LoadAsync();
//}
#endregion

#region Lazy Loading  Kullanırken Dikkatli Olun

#endregion

#region İhtiyaç Noktalarında Ham Sql -Kullanın - FromSql

#endregion

#region Asenkron Fonksiyonları Tercih Edin

#endregion
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