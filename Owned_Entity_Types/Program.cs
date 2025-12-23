// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Reflection;

ApplicationDbContext context = new();

#region Owned Entity Types Nedir?
//EF Core entity sınıflarını parçalayarak, propertyLerini kümesel olarak farklı sınıflarda barındırmamıza ve tüm bu sınıfları ilgili entity 'de birileştirip bütünsel olarak çalışmamıza izin vermektedir.
//Böy1ece bir entity, sahip olunan(owned) birden fazla alt sınıfın birleşmesiyle meydana gelebilmektedir.
#endregion

#region Owned Entity Types'ı Neden Kullanırız?
//https: //www.gencayyiLdiz .com/bIog/wp—content/upLoads/2@20/12/Entity—Framework—Core—0wned—Entities—and—TabLe—SpIitting.png
//Domain Driven Design(DDD) yaklaşımında Value Object 'lere karşılık olarak Owned Entity Types 'lar kullanılır!
#endregion

#region Owned Entity Types Nasıl Uygulanır?
//Normal bir entity'de farklı sınıfların referans edilmesi primary key vs. gibi hatalara sebebiyet verecektir. Çünkü direkt bir sınfın referans olarak alınması ef core tarafından ilişkisel bir tasarım olarak algılanır. Bizlerin entity ieçrisindeki propertyleri kümesel olarak barındıran sınıfları o entity' nin bir parçası olduğunu bildirmemiz özellikle gerekmektedir.
#region OwnsOne Metodu

#endregion
#region Owned Attribtue'u

#endregion
#region IEntityTypeConfiguration<T> Arayüzü

#endregion

#region OwnsMany Metodu
//0wnsMany metodu, entity'nin farklı özelliklerine başka bir sınıftan ICoLLection türünde Navigation Property aracılığıyla ilişkise olarak erişebilmemizi sağlayan bir işleve sahiptir.
//NormaLde Has ilişki olarak kurulabilecek bu ilişkinin temel Çarkı, Has ilişkisi DbSet property'si gerektirirken, 0wnsMany metodu ise DbSet'e ihtiyaç duymaksızın gerçekleştirmemizi sağlamaktadır.
#endregion
#endregion


#region Sınırlılıklar
 //Herhangi bir Owned Entity Type için DbSet property' sine ihtiyaç yoktur. 
 //0nMode1Creating fonksiyonunda Entity«T» metodu ile Owned Entity Type türünden bir sınıf üzerinde herhangi bir konfigürasyon gerçekleştirilemez ! 
 //0wned Entity Type 'ların kalıtımsal hiyerarşi deesteği yoktur!
#endregion
Console.WriteLine("Hello, World!");
public class Employee
{
    public int Id { get; set; }
    //public string? Name { get; set; }
    //public string? MiddleName { get; set; }
    //public string? LastName { get; set; }
    //public string? StreetAdress { get; set; }
    //public string? Loaction { get; set; }
    public bool IsActive { get; set; }
    public EmployeeName EmployeeName { get; set; }
    public Adress Adress { get; set; }
    public ICollection<Order> Orders { get; set; }
}
public class Order
{
    public DateTime OrderDate { get; set; }
    public int Price { get; set; }
}

//[Owned]
public class EmployeeName
{
    public string? Name { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
}
//[Owned]
public class Adress
{
    public string? StreetAdress { get; set; }
    public string? Loaction { get; set; }
}
public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region OwnsOne
        //modelBuilder.Entity<Employee>().OwnsOne(e => e.EmployeeName, builder =>
        //      {
        //          builder.Property(e => e.Name).HasColumnName("Name");
        //          builder.Property(e => e.LastName).HasColumnName("LastName");
        //      });
        //modelBuilder.Entity<Employee>().OwnsOne(e => e.Adress);
        #endregion

        #region OwnsMany 
        modelBuilder.Entity<Employee>().OwnsMany(e => e.Orders,builder=>
        {
            builder.WithOwner().HasForeignKey("OwnedEmployeeId");
            builder.Property<int>("Id");
            builder.HasKey("Id");
        });
        #endregion

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=Owned_Entity;Trusted_Connection=True;");
    }
}

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.OwnsOne(e => e.EmployeeName, builder => {
            builder.Property(e => e.Name).HasColumnName("Name");
    });
        builder.OwnsOne(e => e.Adress, builder =>
        {
            builder.Property(e => e.StreetAdress).HasColumnName("StreetAdress");
        });
    }
    
}