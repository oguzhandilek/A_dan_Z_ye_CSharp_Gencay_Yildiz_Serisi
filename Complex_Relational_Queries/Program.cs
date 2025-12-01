
using System.Reflection;
using Microsoft.EntityFrameworkCore;
ApplicationDbContext context = new();
#region CompLext Query Operators

#region Join
#region Query Syntax

#endregion
#region Method Syntax

#endregion
#endregion
#endregion
Console.WriteLine("Hello, World!");

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public Gender Gender { get; set; }
    public Photo Photo { get; set; }

    public ICollection<Order> Orders { get; set; }


}
public class Photo
{
    public int PersonId { get; set; }
    public string? Url { get; set; }


    public Person Person { get; set; }

}
public enum Gender
{
    Man=1,
    Woman=2
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
    public DbSet<Photo> Photos  { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ComplexQueries;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}