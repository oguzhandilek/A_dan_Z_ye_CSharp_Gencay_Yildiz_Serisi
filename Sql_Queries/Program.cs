using System.Reflection;
using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();


//Eğer ki, sorgunuzu LINQ ile ifade edemiyorsanız yahut LINQ'in ürettiği sorguya nazaran daha optimize bir sorguyu manuel geliştirmek ve EF Core üzerinden execute etmek istiyorsanız EF Core 'un bu davrnaışı desteklediğini bilmelisiniz .

//Manuel bir şekilde/ tarafımızca oluşturulmuş olan sorguları EF Core tarafından execute edebilmek için o sorgunun sonucunu karşılayacak bir entity model'in tasarlanmış ve bunun DbSet olarak context nesnesine tanımlanmış olması gerekiyor.


#region FromSqlInterpolated
// EF Core 7.0 sürümünden önce ham sorguları execute edebildiğimiz fonksiyondur.
var persons = await context.Persons.FromSqlInterpolated($"Select * From Persons").ToListAsync();
#endregion


Console.WriteLine("Hello, World!");

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Order> Orders { get; set; }


}

public class Order
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string? Description { get; set; }

    public Person Person { get; set; }

}

public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SqlQueries;Trusted_Connection=True;");
    }
}