
using System.Reflection;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();

#region View Nedir?
//----View Yapısı
//--Kullanım
//--Genellikle karmaşık sorguların tek bir sorgu üzerinden çalıştırılabilmesidir.
//---- Bu amaçla raporlama işlemlerinde kullanılabilirler.
//--- Aynı zamanda güvenlik ihtiyacı olduğu durumlarda herhangi bir sorgunun 2. - 3. şahıslardan gizlenmesi amacıyla da kullanılırlar.
//--- Genel Özellikleri
//--Herhangi bir sorgunun sonucunu tablo olarak ele alıp, ondan sorgu çekilebilmesini sağlarlar.
//---- ***Önemli***insert, Update ve Delete yapabilirler. Bu işlemleri fiziksel tabloya yansıtırlar. 
//---- View yapıları fiziksel olarak oluşturulan yapılardır.
//---- View yapıları normal sorgulardan daha yavaş çalışırlar.
//--Dikkat !
//---- Database elemanlarını Create komutuyla oluşturuyorduk. View yapısıda bir database yapısı olduğu İçin Create komutu İle oluşturacağız.
#endregion

#region EF Core İle View Kullanımı

#region View Oluşturma
//1: Adım:boş bir migration oluşturulmalıdır.
// 2. adım: migration içerisindeki Up fonksiyonunda view'in create komutları, down fonksiyonunda ise drop komutları yazılmalıdır. 
// 3. adım: migrate ediniz.
#endregion

#region View'i Dbset Oalrak Ayarlama
//View'i EF Core üzerinden sorgulayabilmek için view neticesini karşılayabilecek bir entity olşturulması ve bu entity türünden DbSet property' sinin eklenmesi gerekmektedir.
#endregion
#region Dbset'in Bir View Olduunu Bildirmek

#endregion

var peronOrders = await context.PersonOrders
    .Where(po=> po.Count>2)
    .ToListAsync();

#region EF Core'da View'lerin Özelliklleri
//ViewLerde primary key olmaz! Bu yüzden ilgili DbSet'lerin HasNoKey ile işaretlenmesi gerekemktedir.
// View neticesinde gelen veriler Change Tracker ile takip edilmezler. Haliyle üzerlerinde yapılan değişiklikleri EF Core veritabanına yansıtmaz
var personOrder= await context.PersonOrders.FirstAsync();
personOrder.Name = "Cumali";
await context.SaveChangesAsync();
#endregion
#endregion
Console.WriteLine("Hello, World!");

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Order> Orders { get; set; }= new List<Order>();


}

public class Order
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string? Description { get; set; }

    public Person Person { get; set; } = default!;

}

public class PersonOrder   
{
    public string Name { get; set; }
    public int Count { get; set; }
}
public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Perssons { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<PersonOrder> PersonOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ViewsDb;Trusted_Connection=True;");
    }
}