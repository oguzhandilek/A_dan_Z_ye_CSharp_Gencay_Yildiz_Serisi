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

#region Dynamic SQL Oluşturma ve Parametre Girme

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

public class ApplicationDbContext:DbContext
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