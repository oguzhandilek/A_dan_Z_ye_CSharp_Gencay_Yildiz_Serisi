
using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new ApplicationDbContext();
#region Table Per Type(TPT) Nedir?
//Entitylerin aralarında kalıtımsal ilişkiye sahip olduğu durumlarda her bir türe/entitye/tip/referans karşılık bir tablo generate eden davranıştır.
//Her generate edilen bu tablolar hiyerarşik düzlemde kendi aralarında birebir ilişkiye sahiptir.
#endregion

#region TPT Nasıl Uygulanır?
// TP Tiyi uygulayabilmek için öncelikle entitylerin kendi aralarında olması gereken mantıkta inşa edilmesi gerekmektedir.
// Entityler DbSet olarak bildirilmelidir.
// Hiyerarşik olarak aralarında kalıtımsal ilişki olan tüm entityler OnMode1Creating fonksiyonunda ToTab1e metodu ile konfigüre edilmelidir. Böyldce EF Core kalıtımsal ilişki olan bu tablolar arasında TPT davranışının olduğunu anlayacaktır. 

#endregion

#region TPT'de Veri Ekleme
//Technician technician = new() { Name = "Sülhettin", Surname = "Damar", Department = "İnşaat", Branch = "Sivaci" };
//await context.Technicians.AddAsync(technician);
//Customer customer = new() { Name = "Abdurrezak", Surname = "Gelggezah", CompanyName = "Yerebatan a.ş." };
//await context.AddAsync(customer);
// await context.SaveChangesAsync();
#endregion

#region TPT'de Veri Silme
//var getById=await context.Employees.FindAsync(2);
//context.Employees.Remove(getById);
//await context.SaveChangesAsync();
#endregion

#region TPT'de Veri Güncelleme
//var getById = await context.Technicians.FindAsync(2);
//getById.Branch = "Sıvacı";
//await context.SaveChangesAsync();
#endregion


#region TPT'de Veri Sorgulama
//var datas = await context.Technicians.ToListAsync();
//var persons = await context.Persons.ToListAsync();
//Console.WriteLine();
#endregion



Console.WriteLine("Hello, World!");

public class Person
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
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=TPT;Trusted_Connection=True;");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable("Persons");
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Technician>().ToTable("Technicians");

    }

    
}
