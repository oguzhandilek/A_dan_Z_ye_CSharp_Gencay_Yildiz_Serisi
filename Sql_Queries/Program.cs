using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();


//Eğer ki, sorgunuzu LINQ ile ifade edemiyorsanız yahut LINQ'in ürettiği sorguya nazaran daha optimize bir sorguyu manuel geliştirmek ve EF Core üzerinden execute etmek istiyorsanız EF Core 'un bu davrnaışı desteklediğini bilmelisiniz .

//Manuel bir şekilde/ tarafımızca oluşturulmuş olan sorguları EF Core tarafından execute edebilmek için o sorgunun sonucunu karşılayacak bir entity model'in tasarlanmış ve bunun DbSet olarak context nesnesine tanımlanmış olması gerekiyor.


#region FromSqlInterpolated
// EF Core 7.0 sürümünden önce ham sorguları execute edebildiğimiz fonksiyondur.
//var persons = await context.Persons.FromSqlInterpolated($"Select * From Persons").ToListAsync();
#endregion

#region FromSql - EF Core 7.0
//EF Core 7.0 ile gelen metottur.

#region Query Execute
//var persons= await context.Persons.FromSql($"select * from persons").ToListAsync();
#endregion

#region Stored Procedure Execute

//var persons = await context.Persons.FromSql($"Execute dbo.usp_GetAllPersons null").ToListAsync();
//var person = await context.Persons.FromSql($"Execute dbo.usp_GetAllPersons 4").ToListAsync();
#endregion

#region Parametreli Sorgu Oluşturma
#region Ornek 1
//var personId = 3;
//var person= await context.Persons.FromSql($"select * from persons where Id={personId}").ToListAsync();
#endregion
#region Ornek 2
//int personId = 2;
//var persons= await context.Persons.FromSql($"execute usp_GetAllPersons {personId}").ToListAsync();

// Burada sorguya geçirilen personld değişkeni arkaplanda bir DbParameter türüne dönüştürülerek o şekilde sorguya dahil edilmektedir.
#endregion
#region Ornek 3
//SqlParameter personId = new("Id", "4");
//personId.DbType=System.Data.DbType.Int32;
//personId.Direction=System.Data.ParameterDirection.Input;

//var persons= await context.Persons.FromSql($"execute usp_GetAllPersons {personId}").ToListAsync();

#endregion
#region Ornek 4
//SqlParameter sqlParameter = new("Name", "Cucume");
//sqlParameter.DbType=System.Data.DbType.String;

//var personNames = await context.Persons.FromSql($"Select * from persons where Name={sqlParameter}").ToListAsync();
#endregion
#region Ornek 5
//SqlParameter personId = new("Id", "1");
//personId.DbType=System.Data.DbType.Int32;
//var persons= await context.Persons.FromSql($"Execute usp_GetAllPersons @Id={personId}").ToListAsync();
//@ ile parametre isimlerini vererek birden fazla parametreye sahip olan procedurceler için  ilgili parametreye doğru veriyi göndermemizi sağlamış oluruz.
#endregion
#endregion
#endregion

#region Dynamic SQL Oluşturma ve Parametre Girme - FromSqlRaw
//string columnName = "Id", value = "3";
//var persons= await context.Persons.FromSql($"Select * from Persons Where {columnName}={value}").ToListAsync();

// EF Core dinamik olarak oluşturulan sorgularda özellikle kolon isimleri parametreleştirilmişse o sorguyu ÇALIŞTIRMAYACAKTIR!
//string columName = "Id";
//SqlParameter value = new("Id", "3");
//var persons= await context.Persons.FromSqlRaw($"Select * from Persons Where {columName}=@Id",value).ToListAsync();

//string columnName = "Name";
//string nameValue = "Cucume";
//SqlParameter value= new("Name",nameValue);
//var persons=await context.Persons.FromSqlRaw($"Select * from Persons Where {columnName}=@Name",value).ToListAsync();

//FromSqL ve FromSq11nterpoLated metotlarında SQL Injection vs. gibi güvenlik önlemleri alınmış vaziyettedir. Lakin dinamik olarak sorguları oluşturuyorsanız eğer burada güvenlik geliştirici sorumludur. Yani gelen sorguda/veri yorumlar, noktalı virgüller yahut SQL'e özel karakterlerin algılanması ve bunların temizlenmesi geliştirici tarafından gerekmektedir.

#endregion

#region SqlQuery - Entity Olmayan Scalar Sorguların Çalıştırılması - Non Entity - Ef Core 7.0
//Entity'si olmayan scaLar sorguların çalıştırılıp sonucunu elde etmemizi sağlayan yeni bir fonksiyondur.
//var data = await context.Database.SqlQuery<int>($"Select Id From Persons").ToListAsync();
//var names = await context.Database.SqlQuery<string>($"Select Name From Persons").ToListAsync();

//var datas = await context.Database.SqlQuery<int>($"Select Id Value From Persons").Where(p => p > 3).ToListAsync();

//Sq1Query'de LINQ operatörleriyle sorguya ekstradan katkıda bulunmak istiyorsanız eğer bu sorgu neticesinde gelecek olan kolonun adını Value olarak bildirmeniz gerekmektedir. Çünkü, SqLQuery metodu sorguyu bir subquery olarak generate etmektedir. Haliyle bu durumdan dolayı LINQ ile verilen şart ifadeleri statik olarka Value kolonuna göre tasarlanmıştır. O yüzden bu şekilde bir çalışma zorunlu gerekmektedir.
#endregion

#region ExecuteSql - ExecuteSqlAsync
//Insert, update, delete
//await context.Database.ExecuteSqlAsync($"Update Orders Set Description='ExecuteSqlAsync' Where Id=1");
#endregion

#region Sınırlılıklar
//QueryLer entity türünün tüm Propertyler için kolonlarda değer döndürmelidir.
var query = await context.Persons.FromSql($"Select Name,Id from Persons").ToListAsync();
// Sütun isimleri proıperty isimleriyle aynı olmalıdır.

// SQL Sorgusu Join yapısı İÇEREMEZ! !! Haliyle bu tarz ihtiyaç noktalarında Include Fonksiyonu KULLANILMALIDIR!
var queries= await context.Persons.FromSql($"Select * from Persons")
    .Include(p=> p.Orders)
    .ToListAsync();
#endregion

Console.WriteLine("Hello, World!");

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Order> Orders { get; set; }


}

public class Order
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string? Description { get; set; }

    public Person Person { get; set; }

}

public class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=SqlQueries;Trusted_Connection=True;");
    }
}