// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;
ApplicationDbContext context = new();
#region Query Log Nedir?
//LINQ soprguları neticesinde generate edilen sorguları izleyebilmek ve olası teknik hataları ayıklayabilmek amacıyla query Log mekanizmasından istifade etmekteyiz.
#endregion
#region Nasıl Konfigüre Edilir?
//Microsoft.Extensions.Logging.Console Nugetten yüklenmelidir.
//Microsoft.Extensions.Logging diğer platformlar için loglama çeşitlerine ayrıca bakınız.
#endregion
#region Filtreleme Nasıl Yapılır?

#endregion

//var datas= await context.Set<Person>().ToListAsync();
var datas=await context.Persons.ToListAsync();
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
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=Query_Log;Trusted_Connection=True;");
        //2.Adım
        optionsBuilder.UseLoggerFactory(loggerFactory);
       
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

        //1. adım
      // Create a logger factory with a console provider
       readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder
       .AddFilter((category,level)=>
       {
           return  category==DbLoggerCategory.Database.Command.Name && level==LogLevel.Information;
       }
       )
       .AddConsole());

}