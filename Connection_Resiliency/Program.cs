// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

ApplicationDbContext context = new();

#region Connection Resiliency Nedir?
//EF Core üzerinde yapılan veritabanı çalışmaları sürecinde ister istemez veritabanı bağlantısında kopuşlar/ kesintiler vs. meydana gelebilmektedir.

//Connection Resiliency ile kopan bağlantıyı tekrar kurmak için gerekli tekrar bağlantı taleplerinde bulunabilir ve biryandan da execution strategy dediğimiz davranış modellerini belirleyerek bağlantıların kopması durumunda tekrar edecek olan sorguları baştan sona yeniden tetikleyebiliriz.
#endregion

#region EnableRetryOnFailure
//Uygu1ama sürecinde veritabanı bağlantısı koptuğu taktirde bu yapılandırma sayesinde bağlantıyı tekrardan kurmaya çalışabiliyirouz .

while (true)
{
    await Task.Delay(2000);
   var persons= await context.Persons.ToListAsync();
    persons.ForEach(p=> Console.WriteLine(p.Name));
    Console.WriteLine("*****************");

}


#region MaxRetryCount
// Yeniden bağlantı sağlanması durumunun kaç kere gerçekleştirlecğeini bildirmektedir.
#endregion
#region MaxRetryDelay

#endregion
#endregion

#region Execution Strategies

#endregion


public class Person
{
    public int PersonId { get; set; }
    public string? Name { get; set; }
}
public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ConnectionResiliencyDb;Trusted_Connection=True;",
            builder=>
            builder.EnableRetryOnFailure())
            .LogTo(filter:(eventId,level)=> eventId.Id==CoreEventId.ExecutionStrategyRetrying,
            logger:eventData=>
            {
                Console.WriteLine($"Bağlantı kurulmaktadır");
            }
            );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Person>()
            .HasData(
           new Person() {PersonId=1, Name="Ahmet"},
           new Person() {PersonId=2, Name="Hikmet"},
           new Person() {PersonId=3, Name="Zehmet"},
           new Person() {PersonId=4, Name="Melehat"}
            );
    }
}