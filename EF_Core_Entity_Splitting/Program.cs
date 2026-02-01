// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();
#region Entity Splitting 
// Birden faz La fiziksel tabloyu Entity Framework Core kısmında tek bir entity ile temsil etmemizi sağlayan bir özelliktir.
#endregion
#region Ornek Veri Ekleme
//Person person = new()
//{
//    Name="Zehra",
//    Surname="Dilek",
//    City="Ankara",
//    Country="Türkiye",
//    PhoneNumber="23154555",
//    PostCode="2525",
//    Street="Caddesii"
//};
//await context.Persons.AddAsync(person); 
//await context.SaveChangesAsync();
#endregion
#region Veri Okuma
Person person = await context.Persons.FindAsync(1);
Console.WriteLine(person.PhoneNumber);
#endregion
Console.WriteLine("Hello, World!");

public class Person
{
    #region Persons Tablosu
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    #endregion
    #region Adress Tablosu
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Street { get; set; }
    public string? PostCode { get; set; }
    #endregion
    #region Phone tablosu
    public string? PhoneNumber { get; set; }
    #endregion
}

public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SplittingDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entityBuilder=>
        {


            entityBuilder.ToTable("Persons")
                .SplitToTable("PhoneNumbers", tableBuilder =>
                {
                    tableBuilder.Property(p => p.Id).HasColumnName("PersonId");
                    tableBuilder.Property(p => p.PhoneNumber);
                })
                .SplitToTable("Adresses", tableBuilder =>
                {
                    tableBuilder.Property(p => p.Id).HasColumnName("PersonId");
                    tableBuilder.Property(p => p.Street);
                    tableBuilder.Property(p=> p.PostCode);
                    tableBuilder.Property(p=> p.City);
                    tableBuilder.Property(p=> p.Country);

                });
                        
                
                
        });
    }
}