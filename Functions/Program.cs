
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection;

ApplicationDbContext context = new();
#region Scalar Functions Nedir?
// Geriye herhangi bir türde değer döndüren fonksiyonlardır.
#endregion
#region Scalar Function Oluşturma
//1.Adım: Bpş bir migration oluşturulacak
//2.Adım : bu migration içerisinde Up metodunda Sql metodu eşliğinde fonksiyonun create kodları yazılacak, Down metodu içerisinde de Drop kodları yazılacaktır.
//3.Adım: Migrate edilmeli
#endregion
#region Scalar Function'u EF Core'a Entegre Etme
#region HasDbFunction
// Veritabanı seviyesindeki herhangi bir fonksiyonu EF Core/yazıLım kısmında bir metoda bind etmemizi sağlayan fonksiyondur.
#endregion

//var persons = await (from person in context.Persons
//             where context.GetPersonTotalOrderPrice(person.Id)>500
//             select person).ToListAsync();
//Console.WriteLine("");
#endregion

#region Inline Functions Nedir?
//Geriye bir değer değil, tablo döndüren fonksiyonlardır.
#endregion
#region Inline Function Oluşturma
//1.Adım: Bpş bir migration oluşturulacak
//2.Adım : bu migration içerisinde Up metodunda Sql metodu eşliğinde fonksiyonun create kodları yazılacak, Down metodu içerisinde de Drop kodları yazılacaktır.
//3.Adım: Migrate edilmeli
#endregion
#region Inline Function'u  EF Core'a Entegre Etme
var person1= await context.BestSellingStaff().ToListAsync();
var persons= await context.BestSellingStaff(500).ToListAsync();
foreach (var person in persons)
{
    Console.WriteLine($"Name: {person.Name} | OrderCount: {person.OrderCount} | TotalPrice: {person.TotalOrderPrice}");
}
Console.WriteLine();
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
public class BestSellingStaff
{
    public string? Name { get; set; }
    public int OrderCount { get; set; }
    public int TotalOrderPrice { get; set; }
}

    public class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FunctionDb;Trusted_Connection=True;");
    }
    #region Scalar Functions
    public int GetPersonTotalOrderPrice(int personId)
        => throw new Exception();
    #endregion
    public IQueryable<BestSellingStaff> BestSellingStaff(int totalOrederPrice=1000)
        => FromExpression(() => BestSellingStaff(totalOrederPrice));
    #region Inline Functions

    #endregion
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        #region Scalar
        modelBuilder.HasDbFunction(typeof(ApplicationDbContext).GetMethod(nameof(ApplicationDbContext.GetPersonTotalOrderPrice), new[] {typeof(int)}))
            .HasName("ufn_getPersonTotalOrderPrice");
        #endregion
        #region Inline
        modelBuilder.HasDbFunction(typeof(ApplicationDbContext).GetMethod(nameof(ApplicationDbContext.BestSellingStaff), new[] { typeof(int) })).HasName("tvf_bestSellingStaff");
        modelBuilder.Entity<BestSellingStaff>()
            .HasNoKey();
        #endregion
            
    }
}
