
using Microsoft.EntityFrameworkCore;

#region Table Per Hierarchy (TPH) Nedir?
//KaLıtımsaL ilişkiye sahip olan entityLerin olduğu senaryolarda her bir hiyerarşiye karşılık bir tablo oluşturan davranıştır.
#endregion

#region Neden Table Per Hierarchy Yaklaşımında Bir Tabloya İhtiyacımız Olur?
// İçerisinde benzer alanlara sahip olan entityLeri migrate ettiğimizde her entitye karşılık bir tablo oluşturmaktansa bu entityleri tek bir tabloda modellemek isteyebilir ve bu tablodaki kayıtları discriminator kolonu üzerinden birbirlerinden ayırabiliriz. İşte bu tarz bir tablonun oluşturulması ve bu tarz bir tabloya göre sorgulama, veri ekleme, silme vs. gibi operasyonların şekillendirilmesi için T PH davranışını kullanabiliriz .
#endregion

#region TPH NAsıl Uygulanır?
// EF Core 'da entity aransında temel bir kalıtımsal ilişki söz konusuysa eğer default oalrak kabul edilen davranıştır.
//O yüzden herhangi bir konfigüreasyon gerektirmez!
//Entity1er kendi aralarında kalıtımsal ilişkiye sahip olmalı ve bu entityLerin hepsi DbContext nesnesine DbSet olarak eklenmelidir.
#endregion

#region Discriminator Kolonu Nedir?
// Table Per Hierarchy yaklaşımı neticesinde kümülatif olarak inşa edilmiş tablonun hangi entitye karşılık veri tuttuğunu ayırt edebilmemizi sağlayan bir kolondur. 
//EF Core tarafından otomatik olarak tabloya yerleştirilir. 
//DefauLt olarak içerisinde entity isimlerini tutar. 
//Discriminator kolonunu komple özelleştirebiliriz.
#endregion

#region Discriminator Kolon Adı Nasıl Değiştirilir?
//ÖnceIik1e hiyerarşinin başında hangi sınıf varsa onun Fluent API Ida konfigürasyonuna gidilmeli . 
// Ardından HasDiscriminator fonksiyonu ile özelleştirilmeli.
#endregion


#region Discriminator Değerleri Nasıl Değiştirilir?
// Yine hiyearşinin bşaındaki entity konfigürasyonlarına gelip, HasDiscriminator fonksiyonu ile özelleştirmede bulunarak ardından HasVaLue fonksiyonu ile hangi entitye karşılık hangi değerin girieceğini belirtilen türde ifade edebilirsiniz.
#endregion



ApplicationDbContext context = new();

Employee employee = new() { Name = "Oğuzhan", Department="Yazılım Şube" };
await context.AddAsync(employee);
await context.SaveChangesAsync();
Console.WriteLine("Hello, World!");
public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
public class Employee:Person
{
    public string? Department { get; set; }
}
public class Customer:Person
{
    public string? CompanyName { get; set; }    
}

public class Technician:Employee
{
    public string? Branch { get; set; }
}

public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Technician> Technicians { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ApplicationDb;Trusted_Connection=True;");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasDiscriminator<int>("ServisTip")
            .HasValue<Person>(1)
            .HasValue<Employee>(2)
            .HasValue<Customer>(3)
            .HasValue<Technician>(4);
    }
}