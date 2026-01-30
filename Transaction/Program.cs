// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Transactions;

ApplicationDbContext context = new();

#region Transaction Nedir?
// Transaction, veritabanındaki kümülatif işlemleri atomik bir şekilde gerçekleştirmemizi sağlayan bir özelliktir.
//Bir transaction içerisindkei tüm işlemler commit edildiği taktirde veritabanına fiziksel olarak yansıtılacaktır. Ya da rollback edilirse tüm işlemler geri alınacak ve fiziksel olarak veritabanında herhangi bir verişel değişiklik durumu söz konusu olmayacaktır. 
// Transaction'ın genel amacı veritabanındaki tutarlılık durumunu korumaktadır. Ya da bir başka deyişle verityabanındaki tutarsızlık durumlarına karşı önlem almaktır.
#endregion

#region Default Transaction Davranışı
//EF Core'da varsayılan olarak, yapılan tüm işlemler SaveChanges fonksiyuyla veritabanına fiziksel olarak uygulanır.
//Çünkü SaveChanges default olarak bir trasncationa sahiptir. 
//Eğer ki bu süreçte bir problem/hata/başarısızLık durumu söz konusu olursa tüm işlemler geri alınır(rollback) ve işlemlerin hiçbiri veritabanına uygulanmaz . 
//BöyIece SaveChanges tüm işlemlerin ya tamamen başarılı olacağını ya da bir hata oluşursa veritabanını değiştirmeden işlemleri sonlandıracağını ifade etmektedir .
#endregion

#region Transaction Kontrolünü Manuel Sağlama
//IDbContextTransaction transaction= await context.Database.BeginTransactionAsync();
////EF Core'da transaction kontrolü iradeli bir şekilde manuel sağlamak yani elde etmek istiyorsak eğer BeginTransactionAsync fonksiyonu çağrılmalıdır.
//try
//{
//    Person person = new() { Name = "Ahmet" };
//    await context.Perssons.AddAsync(person);
//    await context.SaveChangesAsync();
//    Order order = new() { PersonId = person.Id, Description = "Kalem", Price = 20 };
//    await context.Orders.AddAsync(order);
//    await context.SaveChangesAsync();
//    //Eğer ki tüm işlemler başarılı bir şekilde tamamlanırsa transaction commit edilmelidir.
//    await transaction.CommitAsync();
//}
//catch (Exception)
//{
//    //Eğer ki işlemlerden herhangi birinde hata/proble durum söz konusu olursa tüm işlemler geri alınmalıdır.
//    await transaction.RollbackAsync();
//    throw;
//}

#endregion

#region Savepoints
//EF Core 5.0 sürümüyle gelmiştir.
//Savepoints, veritabanıu işlemleri sürecinde bir hata oluşursa veya başka bir nedenle yapılan işlemlerin geri alınması gerekiyorsa transaciton içerisinde dönüş yapılabilecek noktaları ifade eden bir özelliktir.
#region CreateSavePoint
// Transaction içerisinde geri dönüş noktası oluşturmamızı sağlayan bir fonksiyondur.
#endregion
#region RollbackToSavepoint
// Transacction içerisinde herhangi bir geri dönüş noktasına(Savepoint 'e) roLIback yapmamızı sağlayan fonksiyondur.
#endregion

//IDbContextTransaction transaction1 = await context.Database.BeginTransactionAsync();
// Person? person1=await context.Perssons.FindAsync(1);
//Person? person2 = await context.Perssons.FindAsync(2);
// context.Perssons.RemoveRange(person1, person2);
//    await context.SaveChangesAsync();
//    await transaction1.CreateSavepointAsync("Silmeİslemi");
//    Order? order1 = await context.Orders.FindAsync(11);
//    context.Orders.Remove(order1);
//    await context.SaveChangesAsync();

////Eğer ki silme işlemi sırasında bir hata/problemi söz konusu olursa silme işlemine geri dönebiliriz.
//await transaction1.RollbackToSavepointAsync("Silmeİslemi");
//await transaction1.CommitAsync();

#endregion

#region TransactionScope
//veritabanı işlemlerini bir grup olarak yapmamızı sağlayan bir sınıfıtr. 
//ADO. NET ile de kullanılabilir.

using TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled); //TransactionScopeAsyncFlowOption.Enabled// async/await sırasında thread değişse bile transaction bilgisinin kaybolmamasını sağlar
// TransactionScope’un async akışta (ExecutionContext) geçerli kalmasını sağlar
try
{
    Person person = new() { Name = "Mehmet" };
    await context.Perssons.AddAsync(person);
    await context.SaveChangesAsync();
    Order order = new() { PersonId = person.Id, Description = "Defter", Price = 50 };
    await context.Orders.AddAsync(order);
    await context.SaveChangesAsync();
    transactionScope.Complete(); //Compote fonksiyonu yapılan veritabanı işlemlerinin commit edilmesini sağlar.
    //Eğer ki rolLback yapacaksanız compLete fonksiyonunun tetiklenmemesi yeterlidir!
}
catch (Exception)
{
    //Eğer ki işlemlerden herhangi birinde hata/proble durum söz konusu olursa tüm işlemler geri alınmalıdır.
    throw;
}
#region Complete

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
    public int Price { get; set; }

    public Person Person { get; set; } = default!;

}
public class ApplicationDbContext : DbContext
{
    public DbSet<Person> Perssons { get; set; }
    public DbSet<Order> Orders { get; set; }

  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Transaction;Trusted_Connection=True;");
    }
}