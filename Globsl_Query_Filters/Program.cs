
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Globalization;

ApplicationDbContext context = new();

#region Global Query Filters Nedir
//Bir entity'e özel uygulama şeviyesinde genel/ön kabullü şartlar oluşturmamızı ve böylece verileri global bir şekilde -Filtrelememeizi sağlayan bir özelliktir. 
//BöyLece belirtilen entity üzerinden yapılan tm sorgulamalarda ekstradan bir şart ifadesine gerek kalmaksızın filtreleri otomatik uygulayarak hızlıca sorgulama yapmamızı sağlamaktadır.

//Gene11ikLe uygulama bazında aktif(IsActive) gibi verilerle çalışıldığı durumlarda,
//MuLtiTenancy uygulamalarda Tenantld tanımlarken vs. kuLLanıLabilir
#endregion
#region Global Query Filters Nasıl Uygulanır
//await context.Persons.ToListAsync();
//await context.Persons.Where(p=> p.Name.Contains("a") || p.Id==3).ToListAsync();
#endregion
#region Navigation Property Uzerinde Global Query FiLters Kullanımı
//Örenk olarak her personelin enz bir satışı şart olsun ve her sorguda aykırı bir duurm yoksa bu iş kuralı geçerli olsun.
// Bu durumda aşağıdaki gibi her sorguda bu şartı koymaktansa tek sefer OnModelCreating için de Hasquerry filter ile default bir sorgulama yapabiliriz.
//var p= await context.Persons
//        .Include(p=> p.Orders)
//        .Where(p=> p.Orders.Count>0)
//        .ToListAsync();
//Config ettikten sonra aşağıdaki sorguyu sade bir şekilde yazmamız yeterli
//var ps =await context.Persons.ToListAsync();
#endregion
#region Global Query Filters Nasıl Ignore Edilir
var person = await context.Persons.IgnoreQueryFilters()
    //.AsNoTracking()
    .ToListAsync();
var person2 = await context.Persons
    //.AsNoTracking()
    .ToListAsync();
#endregion
#region Dikkat Edilmesi Gereken Hususlar
//G1obaL Query FiLter uygulanmış bir kolona Çarkında olmaksızın şart uygulanabilmektedir. Bu duruma dikkat edilmelidir.
await context.Persons.Where(p=> p.IsActive).ToListAsync();  //Bu sorgu şartı Onmodel Creating de de olduğu için aynı şart iki kez tekrar edilmiş oldu. Logdan bakabilirsiniz.
#endregion

Console.WriteLine("Hello, World!");

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }

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
    readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=Global_Query_Filter;Trusted_Connection=True;");
        optionsBuilder.UseLoggerFactory(loggerFactory);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Person>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Order>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Person>()
            .HasMany(p => p.Orders)
            .WithOne(p => p.Person)
            .HasForeignKey(p => p.PersonId);

        modelBuilder.Entity<Person>()
            .HasData(new Person[]
            {
                new() { Id = 1,Name="Muhiyittin",IsActive=true },
                new() { Id = 2,Name="Sedrettin",IsActive=false },
                new() { Id = 3,Name="Mugime",IsActive=false},
                new() { Id = 4,Name="Cucume",IsActive=true},
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

        modelBuilder.Entity<Person>().HasQueryFilter(p => p.IsActive);
        //modelBuilder.Entity<Person>().HasQueryFilter(p => p.Orders.Count > 0);
    }
}