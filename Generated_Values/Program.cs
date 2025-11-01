


#region Generated Value Nedir?
//EF Core' da üretilen değerlerle ilgili çeşitli modellerin ayrıntılarını yapılandırmamızı sağlayan bir konfigurasyondur.

#endregion

#region Default Values

//EF Core herhangi bir tablonun herhangi bir kolonuna yazılım tarafından bir değer gönderilmediği taktirde bu kolona hangi değerin(default value) üretilip yazdırılacağını belirleyen yapılanmalardır.
#region HasDefaultValue
// Stat ic veri veriyor.
#endregion

#region HasDefaultValueSql
//Sql cümleciği
#endregion
#endregion

#region Computed Columns

#endregion

using Microsoft.EntityFrameworkCore;
ApplicationDbContext context = new();

Person person = new()
{
    Name="Oğuzhan",
    Surname="Dilek",
    Premium=10,
    TotalGain=110,
    PersonCode=1

};
await context.AddAsync(person);
await context.SaveChangesAsync();
Console.WriteLine("Hello, World!");
public class Person
{
    public int PersonId { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }

    public int Salary { get; set; }
    public int Premium { get; set; }
    public int TotalGain { get; set; }
    public int PersonCode { get; set; }
}

public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ApplicationDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasKey(p => p.PersonId);
        modelBuilder.Entity<Person>()
            .Property(p => p.Salary)
            .HasDefaultValue(100);
            
    }
}

