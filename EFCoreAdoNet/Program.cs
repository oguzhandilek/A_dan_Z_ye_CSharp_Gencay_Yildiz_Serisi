

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

ApplicationDbContext context = new();

#region Database Property'si
//Database property'si veritabanını temsil eden ve EF Core'un bazı işlevlerinin detaylarına erişmemizi sağlayan bir propertydir.
#endregion
#region BeginTransaction
//EF Core, transaction yönetimini otomatik bir şekilde kendisi gerçekleştirmektedir. Eğer ki transaction yönetimini manuel- olarak anlık ele almak isti orsak BeginTransaction fonksionunu kullanabiliriz.

//IDbContextTransaction transaction = context.Database.BeginTransaction();

#endregion

#region CommitTransaction
//EF Core üzerinde yapılan çalışmaların commit edilebilmesi için kullanılan bir fonksiyondur.
//context.Database.CommitTransaction();
#endregion

#region RollbackTransaction
//EF Core üzerinde yapılan çalışmaların rollback edilebilmesi için kullanılan bir fonksiyondur.
//context.Database.RollbackTransaction();
#endregion

#region CanConnect
// Verilen connection string'e karşılık bağlantı kurulabilir bir veritabanı var mı yok mu bunun bilgisini bool türde veren bir fonksiyondur. 
bool connect = context.Database.CanConnect();
#endregion

#region EnsureCreated
//EF Core 'da tasarlanan veritabanını migration kullanmaksızın, runtime 'da yani kod üzerinde veritabanı sunucusuna inşa edebilmek için kullanılan bir fonksiyondur.
//bool isCreated =context.Database.EnsureCreated();
#endregion
#region EnsureDeleted
// İnşa edilmiş veritabanını runtime'da silmemizi sağlayan bir fonksiyondur.
//bool isDeleted =context.Database.EnsureDeleted();
#endregion

#region GenerateCreateScript
//Context nesnesinde yapılmış olan veritabanı tasarımı her ne ise ona uygun bir SQL Script' ini string olarak veren metottur.
//var script = context.Database.GenerateCreateScript();
//Console.WriteLine(script);
#endregion

#region ExecuteSql
//Veritabanına yapılacak insert, Update ve Delete sorgularını yazdığımız bir metottur. Bu metot işlevsel olarak alacağı parametreleri SQL Injection saldırılarına karşı korumaktadır.

//var name = "Sülhettin";
//var result = context.Database.ExecuteSql($"Insert Person Values({name})");
#endregion

#region ExcuteSqlRaw
//Veritabanına yapılacak insert, Update ve Delete sorgularını yazdığımız bir metottur. Bu metotta ise sorguyu SQL Injection saldırılarına karşı koruma görevi geliştirinin sorumluluğundadır.
//var name = "Şeref";
//var result=context.Database.ExecuteSqlRaw($"Insert Person values({name})");
#endregion

#region SqlQuery
//SqLQuery fonksiyonu her ne kadar erişilebilir olsada artık desteklenememktedir. Bunun yerine DbSet propertysi üzerinden erişilebilen FromSqL fonksiyonu gelmiştir/kullanılmaktadır.
#endregion

#region SqlQueryRaw
//SqLQueryRaw fonksiyonu her ne kadar erişilebilir olsada artık desteklenememktedir. Bunun yerine DbSet propertysi üzerinden erişilebilen FromSqLraw fonksiyonu gelmiştir/kullanılmaktadır.
#endregion

#region GetMigrations
//Uygu1amada üretilmiş olan tüm migration 'ları runtime'da programatik olarak elde etmemizi sağlayan metottur.l
//var migs =context.Database.GetMigrations();

#endregion

#region GetAppliedMigrations
//UyguLamada migrate edilmiş olan tüm migrationları elde etmemizi sağlayan bir fonksiyondur.
//var appliedMigs=context.Database.GetAppliedMigrations();
#endregion

#region GetPendingMigrations
//UyguLamada migrate edilmemiş olan tüm migrationları elde etmemizi sağlayan bir fonksiyondur.
//var migs = context.Database.GetPendingMigrations();
#endregion

#region Migrate
//Migration 'Ları programatik olarak runtime'da migrate etmek için kullanılan bir fonksiyondur.
//context.Database.Migrate();
//EnsureCreated fonksiyonu migration 'Ları kapsamamaktadır. O yüzden migraton'lar içerisinde yapılan çalışmalar ilgili fonksiyonda geçerli olmayacaktır.
#endregion

#region OpenConnection
// Veritabanı bağlantısını manuel açar.
//context.Database.OpenConnection();
#endregion

#region CloseConnection
// Veritabanı bav lantısını manuel kapatır.
//context.Database.CloseConnection();
#endregion

#region GetConnectionString
// İlgili context pesnesinin o anda kullandığı connectionstring değeri ne ise onu elde etmenizi sağlar.
//var connectionString=context.Database.GetConnectionString();
#endregion

#region GetDbConnection
//EF Core'un kullanmış olduğu Ado.NET altyapısının kullandığı DbConnection nesnesini elde etmemizi sağlayan bir fonksiyondur. Yaniiii bizleri Ado.NET kanadına götürür.
//SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();
#endregion

#region SetDbConnection
//OzeLLeştırıLmış connectıon nesnelerını EF Core mımarısıne dahli etmemızı sagLayan bır fonksıyondur.
//context.Database.SetDbConnection(connection);
#endregion

#region ProviderName Property'si
/// EF Core 'un kullanmış olduğu provider neyse onun bilgisini getiren bir proeprty ' dir.
Console.WriteLine(context.Database.ProviderName);
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

public class ApplicationDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=EfCoreAdonetDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}