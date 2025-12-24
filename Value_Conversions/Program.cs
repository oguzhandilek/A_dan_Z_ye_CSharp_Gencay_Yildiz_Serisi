
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

ApplicationDbContext context = new();

#region Valeu Conversions Nedir?
//EF Core üzerinden veritabanı ile yapılan sorgulama süreçlerinde veriler üzerinde dönüşümler yapmamızı sağlayan bir özelliktir. 
//SELECT sorguları sürecinde gelecek olan veriler üzerinde dönüşüm yapabiliriz. 
// Ya da /
// UPDATE yahut İNSERT sorgularında da yazılım üzerinden veritabanına gönderdiğimiz veriler üzerinde de dönüşümler yapabilir ve böylece fiziksel olarak da verileri manipüle edebiliriz.l
#endregion
#region Value Converter Kullanımı Nasıldır?
//VaLue conversions özelliğini EF Core 'da ki Value Converter yapıları tarafından uygulayabilmekteyiz.

#region HasConversion
//HasConversion fonksiyonu, en sade haliyle EF Core üzerinden value converter özelliği gören bir fonksiyondur.

var persons= await context.Persons.ToListAsync();
Console.WriteLine();
#endregion
#endregion
#region Enum Değerler İle Value Converter Kullanımı
//Normal durumlarda Enum türünde tutulan propertylerin veritabanındaki karşılıkları int olacak şekilde aktarımı gerçekleştirlimektedir.Value converter sayesinde enum türünden olan propertylerinde dönüşümlerini istediğimiz türlere sağlayarak hem ilgili kolonun türünü o türde ayarlayaiblir hem de enum üzerinden çalış sürecinde verişel dönüşümleri ilgili türde sağlayabiliriz .

//var person = new Person() { Name = "Ezaxil", Gender = "M", Gender2 = Gender.Male };
//await context.AddAsync(person);
//await context.SaveChangesAsync();
//var _person = await context.Persons.FindAsync(7);

#endregion

Console.WriteLine("Hello, World!");

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public Gender Gender2 { get; set; }
}
public enum Gender
{
    Male,
    Female
}
public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=Value_Conversions;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasKey(p=> p.Id);
        modelBuilder.Entity<Person>().HasData(new Person[]
        {
            new(){Id = 1,Name="Abdulhamit",Gender="M",Gender2=Gender.Male},
            new(){Id = 2,Name="Eşref",Gender="M",Gender2=Gender.Male},
            new(){Id = 3,Name="Bartu",Gender="M",Gender2=Gender.Male},
            new(){Id = 4,Name="Cucume",Gender="F",Gender2=Gender.Female},
            new(){Id = 5,Name="Halime",Gender="F",Gender2=Gender.Female},
            new(){Id = 6,Name="Keriye",Gender="F",Gender2=Gender.Female},
        });
        #region Value Converter Kullanımı Nasıldır?

        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Gender)
        //    .HasConversion(
        //    //INSERT-UPDATE
        //    g => g.ToUpper()
        //    ,
        //    //SELECT
        //    g => g == "M" ? "Male" : "Female"
        //    );
        #endregion

        #region Enum Değerler İle Value Converter Kullanımı
        modelBuilder.Entity<Person>().Property(p => p.Gender2)
            .HasConversion(
            //UPDATE-INSERT
            g => g.ToString()
            //g=> (int)g
            ,
            //SELECT
            g=> (Gender)Enum.Parse(typeof(Gender),g)
            );
        #endregion

    }
}