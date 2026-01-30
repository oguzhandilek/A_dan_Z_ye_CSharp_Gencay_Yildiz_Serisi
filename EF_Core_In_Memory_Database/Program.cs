// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;

ApplicationDbContext context = new();
#region EF Core 'da In—Memory Database İle Çalışmanın Gereği Nedir?
//Ben deniz(Gençay) genellikle bu özelliği yeni çıkan EF Core özelliklerini test edebilmek için kullanıyorum. 
//EF Coreı fiziksel veritabanlarından ziyade in—memory'de Database oluşturup üzerinde birçok işlemi yapmamız sağlayabilmektedir. İşte bu özellik ile gerçek uygulamaların dışında test gibi operasyonları hızlıca yürütebileceğimiz imkanlar elde edebilmekteyiz.
#endregion

#region Avantajları Nelerdir?
// Test ve pre—prod uygulamalarda gerçek/fizikseL veritabanları oluşturmak ve yapı Landıormak yerine tüm veritanını bellekte modelleyebilir ve gerekli işlemleri sanki gerçek bir veritabanında çalışıyor gibi orada gerçekleştirebiliriz. 
//Bellekte çalışmak geçici bir deneyim olacağı için veritabanı serverlarında test amaçlı üretilmiş olan veritabanlarının Lüzumsuz yer işgal etmesini engellemiş olacaktır .
//BeLIekte veritabanını modellemek kodun hızlı bir şekilde test edilmesini sağlayacaktırl
#endregion
#region Dezavantajları Nelerdir?
//In-Memory'de yapılacak olan veritabanı işlevlerinde iLişkiseI modellemeler YAPILAMAMAKTADIR! Bu durumdan dolayı veri tutarlılığı sekteye uğrayabilir ve istatiksel açıdan yanlış sonuçlar elde edilebilir.

#endregion

#region Ornek Çalışma
//Microsoft.EntityFrameworkCore.InMemory kütüphanesi Nu-Get paketi projemize eklenmelidir.
//Mıgrations işlemleri in-memory database üzerinde gerçekleştirilememektedir. Bu nedenle veritabanı modeli kod tarafında oluşturulmalıdır.
//Uygulama her çalıştığında in-memory database sıfırlanacaktır.

await context.Persons.AddAsync(new() { Name="Deneme",Surname="Kullanıcı"});
await context.SaveChangesAsync();

var persons=await context.Persons.ToListAsync();
Console.WriteLine();
#endregion

Console.WriteLine("Hello, World!");



public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }

}

public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseInMemoryDatabase("InMemoryDb");
    }
}