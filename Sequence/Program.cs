using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();

#region Sequence Nedir?
// Veritabanında benzersiz ve ardışık sayısal değerler üreten veritabanı nesnesidir.
//Sequence herhangi bir tablonun özelliği değildir. Veritabanı nesnesidir. Birden fazla tablo tarafından kullanılabilir.
#endregion

#region Sequence Tanımlama
//Sequence'ler üzerinden değer oluştururken veritabanına özgü çalışma yapılması zaruridir. SQL Serverla özel yazılan Sequence tanımı misal olarak Oracle için hata verebilir.

await context.Employees.AddAsync(new() { Name = "Enver", Surname = "Terakki", Salary = 1000 });
await context.Employees.AddAsync(new() { Name = "Talat", Surname = "İttahat", Salary = 1000 });
await context.Employees.AddAsync(new() { Name = "Cemal", Surname = "Perver", Salary = 1000 });
await context.Customers.AddAsync(new() { Name="Fahreddin"});
await context.Customers.AddAsync(new() { Name="Halil"});
await context.Customers.AddAsync(new() { Name="Arapgirli Cevat"});

await context.SaveChangesAsync();
#region HasSequence

#endregion
#region HasDefaultValueSql

#endregion
#endregion

#region Sequence Yapılandırması

#region StartAt

#endregion
#region IncrementsBy

#endregion
#endregion

#region Sequence İle Identity Farkı
//Sequence bir veritabanı nesnesiyken, Identity ise tabloların özellikleridir.
// Yani Sequence herhangi bir tabloya bağımlı değildir. 
// Identity bir sonraki değeri diskten alırken Sequence ise RAM 'den alır. Bu yüzden önemli ölçüde Identity'e nazaran daha hızlı, performanslı ve az maliyetlidir.
#endregion

Console.WriteLine("Hello, World!");

public class Employee   
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Salary { get; set; }
}
public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }

}

public class ApplicationDbContext:DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=SequenceDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence("EmployeeAndCustomer_Sequence")
            .StartsAt(100)
            .IncrementsBy(15);

        modelBuilder.Entity<Employee>()
            .Property(e => e.Id)
            .HasDefaultValueSql("NEXT VALUE FOR EmployeeAndCustomer_Sequence");
        modelBuilder.Entity<Customer>()
            .Property(c => c.Id)
            .HasDefaultValueSql("NEXT VALUE FOR EmployeeAndCustomer_Sequence");

    }
}
