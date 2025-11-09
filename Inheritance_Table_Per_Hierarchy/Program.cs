
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
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Department { get; set; }
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
}