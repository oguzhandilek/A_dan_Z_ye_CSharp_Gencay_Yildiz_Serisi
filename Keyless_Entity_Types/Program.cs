// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
ApplicationDbContext context = new ApplicationDbContext();

#region Keyless Entity Types
//NormaL entity type'lara ek olarak primary key içermeyen querylere karşı veritabanı sorguları yürütmek için kullanılan bir özelliktir KET.

//GeneLLik1e aggreate operasyonların yapıldığı group by yahut pivot table gibi işlemler neticesinde elde edilen istatistiksel sonuçlar primary key kolonu barındırmazlar. Bizler bu tarz sorguları KeyLess Entity Types özelliği ile sanki bir entity'e karşılı geliyormuş gibi çalıştırabiliriz .
#endregion

#region Keyless Entity Tanımlama
// 1. Hangi sorgu olursa olsun EF Core üzerinden bu sorgunun bir entity'e karşılık geliyormuş gibi işleme/execute 'a/çaLıştırmaya tabi tutulabilmesi için o sorgunun sonucunda bir entity 'nin yine de tasarlanması gerekmektedir.
// 2. Bu entity' nin DbSet property 'si olarak DbContext nesnesine eklenmesi gerekmektedir.
// 3. Tanımlamış olduğumuz entity'e OnModeLCreating fonksiyonu içerisinde girip bunun bir key'i olmadığını bildirmeli (HasNoKey) ve hangi sorgunun çalıştırılacağı da ToView vs. gibi işlemlerle ifade edilmelidir.

var datas = await context.PersonOrderCounts.ToListAsync();
var data = await context.Set<PersonOrderCount>().ToListAsync();
#region Keyless Attribute'u
//[Keyless]
#endregion
#region HasNoKey Fluent API'ı

#endregion
#endregion

#region Keyless Entity Types Özellikleri
//Primary Key kolonu OLMAZ!
//Change Tracker mekanizması aktif olmayacaktır.
//TPH olarak entity hiyerarşisinde kullanılabilir Lakin diğer kalıtımsal ilişkilerde kullanılamaz!
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

//[Keyless]
public class PersonOrderCount
{
    public string? Name { get; set; }
    public int Count { get; set; }
}

public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PersonOrderCount> PersonOrderCounts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=KeylessDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<PersonOrderCount>().
            ToView("vw_PersonOrderCount")
            .HasNoKey();
    }
}