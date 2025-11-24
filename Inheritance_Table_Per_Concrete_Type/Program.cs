
using Microsoft.EntityFrameworkCore;
ApplicationDbContext context = new();
#region Table Per Concrete Type (TPC) Nedir?
//TPC davranışı, kalıtımsal ilişkiye sahip olan entitylerin olduğu çalışmalarda sadece concrete/somut olan entity'lere karşılık bir tablo oluşturacak davranış modelidir.
//TPC, TPT'nin daha performanslı versiyonudur.
#endregion

#region TPC Nasıl Uygulanır?
//Hiyerarşik düzlemde abstract olan yapılar üzerinden OnModelCreating üzerinden Entity fonskiyonuyla konfigürasyona girip ardından UseTpcMappingStrategy fonksiyonu eşliğinde davranışın TPC olacağını belirleyebiliriz .

#endregion

#region TPC'de Veri Ekleme

//await context.Technicians.AddAsync(new() { Name = "Mırtaza", Surname = "Aynayabakan", Department = "İnşaat", Branch = "Elektrikçi" });
//await context.Technicians.AddAsync(new() { Name = "Yakup", Surname = "Sülük", Department = "İnşaat", Branch = "Tesisatçı" });
//await context.Technicians.AddAsync(new() { Name = "Necati", Surname = "Neco", Department = "İnşaat", Branch = "Boyacı" });
//await context.Technicians.AddAsync(new() { Name = "Ayvaz", Surname = "Köroğlu", Department = "İnşaat", Branch = "Sıvacı" });
//await context.SaveChangesAsync();
#endregion

#region TPC'de Veri Silme
//var getById = await context.Technicians.FindAsync(1);
//context.Technicians.Remove(getById);
//await context.SaveChangesAsync();
#endregion

#region TPC'de Veri Güncelleme
//var getById = await context.Technicians.FindAsync(3);
//getById.Name = "Ahmet";
//await context.SaveChangesAsync();
#endregion


#region TPC'de Veri Sorgulama
//var techs=await context.Technicians.ToListAsync();
//Console.WriteLine();
#endregion

Console.WriteLine("Hello, World!");

 public abstract class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
public class Employee : Person
{
    public string? Department { get; set; }
}
public class Customer : Person
{
    public string? CompanyName { get; set; }
}

public class Technician : Employee
{
    public string? Branch { get; set; }
}

public class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Technician> Technicians { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=TPC;Trusted_Connection=True;");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().UseTpcMappingStrategy();
       
    }


}

