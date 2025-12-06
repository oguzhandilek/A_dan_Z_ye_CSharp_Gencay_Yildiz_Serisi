
using System.Reflection;
using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();

#region Stored Prodecure Nedir?
//---- Stored Procedures (Saklı Yordamlar)
//------ Genel Özelliklerı

//----Normal sorgulardan daha hızlı çalışırlar.
//----Çünkü normal sorgular Execute edilirken "Execute Plan” işlemi yapılır. Bu işlem sırasında hangi tablodan veri çekilecek, hangi kolonlardan gelecek, bunlar nerede v.s gibi işlemler yapılır. Bir sorgu her çalıştırıldığında bu işlemler aynen tekrar tekrar yapılır. Fakat sorgu Stored Procedure olarak çalıştırılırsa bu işlem sadece bir kere yapılır ve o da ilk çalıştırma esnasındadır. Diğer çalıştırmalarda bu işlemler yapılmaz. Bundan dolayı hız ve performansta artış sağlanır.
//----İçerisinde Select, insert, Update ve Delete işlemleri yapılabilir.
//----iç içe kullanılabilir.
//----İçlerinde fonksiyon olutşrulabilir.
//----- Sorgularımızın dışarıdan alacağı değerler parametre olarak Stored Procedure' lere geçirilebildiğinden dolayı, sorgularımızın "SQL Injection” yemelerinide önlemiş oluruz. Bu yönleriyle de daha güvenlidirler.
//----- Stored Procedure fiziksel bir veritabanı nesnesidir. Haliyle Create komutu ile oluşturulur.
//----- Fiziksel olarak ilgili veritabanının "Programmability” "Stored Procedures" kombinasyonundan erişilebilirler.

//--Prototip -
//--- Create Proc ya da Procedure [İsim]
//--(
//--varsa parametreler
//--)
//--as
//--yazılacak sorgular, kodlar, şartlar,fonksiyonlar,komutlar---- Stored Procedures (Saklı Yordamlar)
//------ Genel Özelliklerı

//----Normal sorgulardan daha hızlı çalışırlar.
//----Çünkü normal sorgular Execute edilirken "Execute Plan” işlemi yapılır. Bu işlem sırasında hangi tablodan veri çekilecek, hangi kolonlardan gelecek, bunlar nerede v.s gibi işlemler yapılır. Bir sorgu her çalıştırıldığında bu işlemler aynen tekrar tekrar yapılır. Fakat sorgu Stored Procedure olarak çalıştırılırsa bu işlem sadece bir kere yapılır ve o da ilk çalıştırma esnasındadır. Diğer çalıştırmalarda bu işlemler yapılmaz. Bundan dolayı hız ve performansta artış sağlanır.
//----İçerisinde Select, insert, Update ve Delete işlemleri yapılabilir.
//----iç içe kullanılabilir.
//----İçlerinde fonksiyon olutşrulabilir.
//----- Sorgularımızın dışarıdan alacağı değerler parametre olarak Stored Procedure' lere geçirilebildiğinden dolayı, sorgularımızın "SQL Injection” yemelerinide önlemiş oluruz. Bu yönleriyle de daha güvenlidirler.
//----- Stored Procedure fiziksel bir veritabanı nesnesidir. Haliyle Create komutu ile oluşturulur.
//----- Fiziksel olarak ilgili veritabanının "Programmability” "Stored Procedures" kombinasyonundan erişilebilirler.

//--Prototip -
//--- Create Proc ya da Procedure [İsim]
//--(
//--varsa parametreler
//--)
//--as
//--yazılacak sorgular, kodlar, şartlar,fonksiyonlar,komutlar
#endregion

#region EF Core İle Stored Procedure Kullanımı

#region Stored Procedure Oluşturma
// 1. adım . boş bir migration oluşturunuz .
// 2. adım . migration 'ın içerisindeki Up fonksiyonuna SPİ ın Create komutlarını yazınız, Down Fonk. ise Drop komutlarını yaznınz
//3 Adım : migarate ediniz
#endregion
#region Stored Procedure Kullanma
//SPII kullanabilmek için bir entityle ihtiyacımız vardır. Bu entity' nin DbSet propertysi ol larak context nesnesine de eklenmesi gerekmektedir. 
//Bu DbSet properytysi üzerinden FromSqI fonksiyonunu kullanarak 'Exec ....' yapılanmasını çalıştırıp sorgu neticesini elde edebilirsiniz . komutu eşliğinde SP
#region FromSql
//var datas= await context.PersonOrders.FromSql($"execute usp_PersonOrders").ToListAsync();
#endregion
#endregion

#region Geriye Değer Döndüren Stored Proc Kullanma

#endregion

#region Parametreli Stored Proc Kullanma

#endregion

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

    public Person Person { get; set; } = default!;

}

public class PersonOrder
{
    public string Name { get; set; }
    public int Count { get; set; }
}

public class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PersonOrder> PersonOrders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<PersonOrder>()
            .HasNoKey();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StoredProcDb;Trusted_Connection=True;");
    }
}