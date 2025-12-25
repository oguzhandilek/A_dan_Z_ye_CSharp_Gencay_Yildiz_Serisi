
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Runtime.InteropServices;
using System.Text.Json;

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

#region ValueConverter Sınıfı
//ValueConverter sınıfı, verişel dönüşümlerideki çalışmaları/sorumlulukları üstlenebilecek bir sınıftır. 
// Yani bu sınıfın instance'ı ile HasConvention fonksiyonun yapılan çalışmaları üstlenebilir ve direkt bu instance'ıd ilgili fonksiyona vererek dönüşümsel çalışmalarımızı -gerçekleştirebiliiriz.

//var _person = await context.Persons.FindAsync(7);

#endregion

#region Custom ValueConverter Sınıfı
//EF Core Ida verişel- dönüşümler için custom olarak converter sınıfları üretebilmekteyiz. Bunun için tek yapılması gereken custom sınıfının ValueConverter sınıfından miras almasını sağlamaktadır.
//var _person = await context.Persons.FindAsync(7);
#endregion

#region Built-in Converters Yapıları
//EF Core basit dönüşümler için kendi bünyesinde yerleşik convert sınıfları barındırmaktadır.

#region BoolToZeroOneConverter
//bool olan verinin int olarak tutulmasını sağlar.
#endregion
#region BoolToStringConverter
//bool olan verinin string olarak tutulmasını sağlar.
#endregion
#region BoolToTwoValuesConverter
//bool olan verinin char olarak tutulmasını sağlar.
#endregion

//Diğer buiLt—in converters yapılarını aşağıdaki Linkten gözlemleyebilirsiniz.
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions
#endregion

#region İlkel Koleksiyonların Serilizasyonu
// İçerisinde ilkel türlerden oluşturuLmuş koleksiyonları barındıran modelleri migrate etmeye çalıştığımızda hata ile karşılaşmaktayız. Bu hatadan kurtuLmak ve ilgili veriye koleksiyondaki verileri serilize ederek işleyebilmek için bu koleksiyonu normal metinsel değerlere dönüştürmemize fırsat veren bir conversion operasyonu gerçekleştireibliriz.

//var person=new Person {Name ="Filanca",Gender="M",Gender2=Gender.Male, Maried=true,Titles=new() { "A", "B", "C" } };
//await context.AddAsync(person);
//await context.SaveChangesAsync();
//var _person = await context.Persons.FindAsync(person.Id);
#endregion

#region .Net 6 - Value Converter For Nullable Fields
// . NET 6 dan önce value converterllar nu1L değerlerin dönüşüşmünü desteklememekteydi. . NET 6 i Le artık nuL Ideğerler de dönüştürülebilmektedir.
#endregion

Console.WriteLine("Hello, World!");

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public Gender Gender2 { get; set; }
    public bool Maried { get; set; }
    public List<string>? Titles { get; set; }
}
public enum Gender
{
    Male,
    Female
}

public class GenderConverter:ValueConverter<Gender,string>
{
    public GenderConverter():base(
        //INSERT-UPDATE
        g=> g.ToString()
        ,
        //SELECT
        g=> (Gender)Enum.Parse(typeof(Gender),g))
    {
        
    }
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
            new(){Id = 1,Name="Abdulhamit",Gender="M",Gender2=Gender.Male,Maried=true},
            new(){Id = 2,Name="Eşref",Gender="M",Gender2=Gender.Male,Maried=true},
            new(){Id = 3,Name="Bartu",Gender="M",Gender2=Gender.Male,Maried=true},
            new(){Id = 4,Name="Cucume",Gender="F",Gender2=Gender.Female,Maried=true},
            new(){Id = 5,Name="Halime",Gender="F",Gender2=Gender.Female,Maried=false},
            new(){Id = 6,Name="Keriye",Gender="F",Gender2=Gender.Female,Maried=true},
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
        //modelBuilder.Entity<Person>().Property(p => p.Gender2)
        //    .HasConversion(
        //    //UPDATE-INSERT
        //    g => g.ToString()
        //    //g=> (int)g
        //    ,
        //    //SELECT
        //    g=> (Gender)Enum.Parse(typeof(Gender),g)
        //    );
        #endregion

        #region ValueConverter Sınıfı
        ValueConverter<Gender, string> valueConverter = new(
            //INSERT-UPDATE
            g => g.ToString()
            ,
            //SELECT
            g => (Gender)Enum.Parse(typeof(Gender), g)
            );

        modelBuilder.Entity<Person>().Property(p => p.Gender2).HasConversion(valueConverter);
        #endregion

        #region Custom ValueConverter Sınıfı
        //modelBuilder.Entity<Person>().Property(p => p.Gender2).HasConversion<GenderConverter>();
        #endregion

        #region BoolToZeroOneConverter
        //modelBuilder.Entity<Person>().Property(P => P.Maried).HasConversion<BoolToZeroOneConverter<int>>(); //1. seçenek
        ////ya da direkt aşağıdaki gibi int türünü bildirirsek de aynı davranış söz konusu olacaktır.
        //modelBuilder.Entity<Person>().Property(P => P.Maried).HasConversion<int>();//2.seçenek
        #endregion

        #region BoolToStringConverter
        //BoolToStringConverter converter = new("Bekar", "Evli");
        //modelBuilder.Entity<Person>().Property(P => P.Maried).HasConversion(converter);

        #endregion

        #region BoolToTwoValuesConverter
        //BoolToTwoValuesConverter<char> converter = new('B', 'E');
        //modelBuilder.Entity<Person>().Property(P => P.Maried).HasConversion(converter);
        #endregion

        #region İlkel Koleksiyonların Serilizasyonu
        modelBuilder.Entity<Person>()
            .Property(p => p.Titles)
            .HasConversion(
            //INSERT-UPDATE
            t=> JsonSerializer.Serialize(t,new JsonSerializerOptions { PropertyNameCaseInsensitive=true})
            ,
            //SELECT 
            t=> JsonSerializer.Deserialize<List<string>>(t,new JsonSerializerOptions { PropertyNameCaseInsensitive = true})
            );
        #endregion

    }
}