
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;


#region Generated Value Nedir?
//EF Core' da üretilen değerlerle ilgili çeşitli modellerin ayrıntılarını yapılandırmamızı sağlayan bir konfigurasyondur.

#endregion

#region Default Values

//EF Core herhangi bir tablonun herhangi bir kolonuna yazılım tarafından bir değer gönderilmediği taktirde bu kolona hangi değerin(default value) üretilip yazdırılacağını belirleyen yapılanmalardır.
#region HasDefaultValue
// Stat ic veri veriyor.
#endregion

#region HasDefaultValueSql
//Sql cümleciği
#endregion
#endregion

#region Computed Columns
#region HasComputedColumnSql
// Tablo içerisindeki kolonlar üzerinde yapılan aritmatik işlemler neticesinde üretilen kolondur.
#endregion
#endregion

#region Value Generation

#region Primary Keys
//Herhangi bir tablodaki satırları kimlik vari şekilde tanımlayan, tekil(unique) olan sütun veya sütunlardır.
#endregion
#region Identity
// Identity, yalnızca otomatik olarak artan bir sütundur. Bir sütun, PK olmaksızın identity olarak tanımlanabilir. Bir tablo içerisinde identity kolonu sadece tek bir tane olarak tanımlanabilir.
#endregion
//Bu iki özellik genellikle birlikte kullanılmaktadırlar. 0 yüzden EF Core PK olan bir kolonu otomatik olarak Identity olacak şekilde yapılandırmaktadır. Ancak böyle olması için bir gereklilik yoktur!
#endregion

#region DatabaseGenerated

#region DatabaseGeneratedQption.None — ValueGeneratedNever
//Bir kolonda değer üretilmeyecekse eğer None ile işaretliyoruz. 
//EF Core 'un default olarak PK kolonlarda getirdiği Identity özelliğini kaldırmak istiyorsak eğer Nonelı kullanabiliriz.
#endregion

#region DatabaseGenerated0ption.Identity — ValueGeneratedOnAdd
//Herhangi bir kolona Identity özelliğini vermemizi sağlayan bir konfigürasyondur .

#region Sayısal Türlerde
//Eğer ki Identity özelliği bir tabloda sayısal olan bir kolonda kullanılacaks o durumda ilgili tablodaki pk olan kolondan özellikle/ iradeli bir şekilde identity özelliğinin kaldırılması gerekmektedir. (None)l
#endregion

#region Sayısal Olmayan Türlerde
//Eğer ki Identity özelliği bir tabloda sayısal olmayan bir kolonda kullaınacaksa o durumda ilgili talbodaki pk olan kolondan iradeli bir şekilde identity özelliğinin kaldırılmasına gerek yoktur.
#endregion
#endregion

#region DatabaseGeneratedOption.Computed — ValueGenerated0nAdd0rUpdate
//EF Core üzerinde bir kolon Computed coLumn ise ister Computed olarak belirleyebilirsiniz isterseniz de belirmeden kullanmaya devam edebilirsiniz.
#endregion

#endregion

ApplicationDbContext context = new();

Person person = new()
{
    PersonId=300,
    Name="Oğuzhan",
    Surname="Dilek",
    Premium=10,
    TotalGain=110,
    

};
await context.AddAsync(person);
await context.SaveChangesAsync();
Console.WriteLine("Hello, World!");
public class Person
{
    //[DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PersonId { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }

    public int Salary { get; set; }
    public int Premium { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int TotalGain { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PersonCode { get; set; }
}

public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ApplicationDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasKey(p => p.PersonId);

        modelBuilder.Entity<Person>()
                        .Property(p => p.PersonId)
                        .HasColumnOrder(7)
                        .ValueGeneratedNever();

        modelBuilder.Entity<Person>()
          .Property(p => p.Name)
          .HasColumnOrder(1);
        modelBuilder.Entity<Person>()
          .Property(p => p.Surname)
          .HasColumnOrder(2);
      
        modelBuilder.Entity<Person>()
          .Property(p => p.Premium)
          .HasColumnOrder(4);
        modelBuilder.Entity<Person>()
          .Property(p => p.TotalGain);
        modelBuilder.Entity<Person>()
          .Property(p => p.PersonCode)
          .HasColumnOrder(6)
          .HasDefaultValueSql("NEWID()");
          //.ValueGeneratedOnAdd(); //Yukarıdaki Annatation oldğu için bunu kapattık
      


        modelBuilder.Entity<Person>()
            .Property(p => p.Salary)
            //.HasDefaultValue(100);
            .HasColumnOrder(3)
            .HasDefaultValueSql("FLOOR(RAND()*1000)");

        modelBuilder.Entity<Person>()
            .Property(p => p.TotalGain)
            .HasColumnOrder(5)
            .HasComputedColumnSql("([Salary] + [Premium])")
            .ValueGeneratedOnAddOrUpdate();
        

        

}
}

