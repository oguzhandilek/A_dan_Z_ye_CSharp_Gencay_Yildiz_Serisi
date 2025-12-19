// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Common;
ApplicationDbContext context = new();

#region Query Tags Nedir?
//EF Core ile generate edilen sorgulara açıklama eklememizi sağlayarak; SQL Profiler, Query Log vs. gibi yapılarda bu açıklamalar eşliğinde sorguları gözlemlememizi sağlayan bir özelltir.
#endregion

#region TagWith Metodu
await context.Persons.TagWith("Örnek bir açıklama..").ToListAsync();
#endregion

#region Multiple TagWith
await context.Orders.TagWith("Orderları getir").TagWith("Herehangi bir filtre yok").ToListAsync();

await context.Persons.TagWith("Personelleri çek")
    .Include(p=> p.Orders).TagWith("Personle satışşlarınıda getir")
    .Where(p=> p.Name.Contains("a")).TagWith("İsminde a harfi bulunan personelleri filtrelesin")
    .ToListAsync();
#endregion

#region TagWithCallSite Metodu
//01uşturuLan sorguya açıklama satırı ekler ve ek olarak bu sorgunun bu dosyada (.cs) hangi satırda üretildiğini bilgisini de verir.
await context.Persons.TagWithCallSite("Personelleri çek")
    .Include(p => p.Orders).TagWithCallSite("Personle satışşlarınıda getir")
    .Where(p => p.Name.Contains("a")).TagWithCallSite("İsminde a harfi bulunan personelleri filtrelesin")
    .ToListAsync();
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
    readonly ILoggerFactory loggerFactory= LoggerFactory.Create(builder=> builder.AddConsole());
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=Query_Tags;Trusted_Connection=True;");
        optionsBuilder.UseLoggerFactory(loggerFactory);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Order>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Person>()
            .HasMany(p=> p.Orders)
            .WithOne(p=> p.Person)
            .HasForeignKey(p=> p.PersonId);

        modelBuilder.Entity<Person>()
            .HasData(new Person[]
            {
                new() { Id = 1,Name="Muhiyittin" },
                new() { Id = 2,Name="Sedrettin" },
                new() { Id = 3,Name="Mugime"},
                new() { Id = 4,Name="Cucume"},
            });
        modelBuilder.Entity<Order>()
             .HasData(new Order[]
                   {
                new Order { Id = 1,PersonId = 1,Description="...",Price=200},
                new Order { Id = 2,PersonId = 1,Description="...",Price=210},
                new Order { Id = 3,PersonId = 2,Description="...",Price=220},
                new Order { Id = 4,PersonId = 2,Description="...",Price=230},
                new Order { Id = 5,PersonId = 2,Description="...",Price=240},
                new Order { Id = 6,PersonId = 3,Description="...",Price=250},
                new Order { Id = 7,PersonId = 4,Description="...",Price=260},
                new Order { Id = 8,PersonId = 4,Description="...",Price=270},
                new Order { Id = 9,PersonId = 3,Description="...",Price=270},
                new Order { Id = 10,PersonId = 3,Description="...",Price=280},
                   });
    }
}