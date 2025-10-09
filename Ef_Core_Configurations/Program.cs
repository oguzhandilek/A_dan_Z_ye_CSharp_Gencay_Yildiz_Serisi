// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.SqlServer.Server;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");

#region EF Core'da Neden Yapılandırmalara İhtiyacımız Olur?
//Defau1t davranışları yeri geldiğinde geçersiz kılmak ve özelleştirmek isteyebiliriz. Bundan dolayı yapılandırmalara ihtiyacımız olacaktır.
#endregion

#region OnModelCreating Metodu
// EF Core 'da yapılandırma deyince akla İLk gelen metot OnModeICreating metodudur. 
// Bu metot, DbContext sınıfı içerisinde virtual olarak ayarlanmış bir metottur. 
//Biz1er bu metodu kullanarak model 'lapımızla ilgili temel konfigürasyonel davranışları(Fluent API) sergileyeibliriz.
// Bir model' ın oluşturlmasıyla ilgili tüm konfigürasyonları burada gerçekleştirebilmekteyiz .

#region GetEntityTypes
//EF Core 'da kulla ıntitylleri elde etmekl programatik olarak öğrenmek istiyorsak eğer GetEntityTypes fonksiyonunu kullanabiliriz.
#endregion
#endregion

#region Configurations -  Data Annotations & Fluent API

#region Table - ToTable
//Generate edilecek tablonun ismini belirlememizi sağlayan yapılandırmadır.
// Ef Core normal şartlarda generate edeceği tablonun adını DbSet property'sinden almaktadır. Bizler eğer ki bunu özelleştirmek istiyorsak Table attribute 'unu yahut ToTab1e api' ını kullanabilriiz
#endregion

#region Column — HasCoLumnName, HasColumnType, HasColumnOrder
// EF Core 'da tabloların kolonları entity sınıfları içerisindeki property 'lere karşılık gelmektedir. 
//Defau1t olarak property 'lerin adı kolon adıyken, türleri/ tipleri kolon türleridir. 
// Eğer ki generate edilecek kolon isimlerine ve türlerine müdahale etmek istiyorsak bu konfigürasyon kullanılır.
#endregion

#region ForeignKey-HasForeignKey
//İ1işkiseL tablo tasarımlarında, bağımlı tabloda esas tabloya karşılık gelecek verilerin tutulduğu kolonu foreign key olarak temsil etmekteyiz. 
//EF Core 'da foreign key kolonu genellikle Entity Tnaımlama kuralları gereği default yapılanmalarla oluşturulur. 
//ForeignKey Data Annotations Attribute' unu direkt kullanabilirsiniz. Lakin Fluent api ile bu konfigürasyonu yapacaksanız iki entity arasındaki ilişkiyide modellemeniz gerekmektedir. Aksi taktirde fluent api üzerinde HasForeignKey fonksiyonunu kullanamnazsınız !
#endregion

#region NotMapped - Ignore
//EF Core, entity sınıfları içerisindeki tüm proeprtyleri default olarak modellenen tabloya kolon şeklinde migrate eder.
// Bazn bizler entity sınıfları içerisinde tabloda bir kolona karşılık gelmeyen propertyler tanımlamak mecburiyetinde kalabiliriz. 
// Bu property'lerin ef core tarafından kolon olarak map edilmesini istemediğimizi bildirebilmek için NotMapped ya da Ignore kullanabiliriz.
#endregion

#region Key — HasKey
// EF Core 'da, defauLt convention olarak bir entity' nin içerisinde Id,ID, Entityld, EntityID vs. şeklinde tanımlanan tüm proeprtylere varsayılan olarak primary key constraint uygulanır.
//Key ya da HasKey yapılanmalarıyla istediğinmiz her hangi bir proeprty'e default convention dışında pk uygulayabiliriz. 
// EF Core'da bir entity içerisinde kesinlikle PK' i temsil edecek olan property bulunmalıdır. Aksi taktirde EF Core migration olutşurken hata verecektir.Eğer ki tablonun PK' i yoksa bunun bildirilmesi gerekir.
#endregion

#region Timestamp — IsRowVersion
// İleride/ sonraki derlerde veri tutarlılığı ile ilgili bir ders yapacağız.
// Bu derste bir satırdaki verinin bütünsel olarak değişikliğini takip etmemizi sağlayacak olan verisyon mantığını konuşuyor olacağız.
// İşte bir verinin verisyonunu oluşturmamızı sağlayan yapılanma bu konfigürasyonlardır.
#endregion

#region Required - IsRequired
//Bir kolonun nullable ya da not nuLL olup olmamasını bu konfigürasyonla belirleyebiliriz.
// EF Core 'da bir property default olarak not nu1L şeklinde tanımlanır. Eğer ki property'isi nullable yapmak istyorsak türü üzerinde operatörü ile bbildirimde bulunmamız gerekmektedir.
#endregion

#region MaxLenght,StringLength — HasMaxLength
//Bir kolonun max karakter sayısını belirlememizi sağlar.
#endregion

#region Precision - HasPrecision
//KüsüratLı sayılarda' bir kesinlik belirtmemizi ve noktanın hanesini bildirmemizi sağlayan bir yapılandırmadır.
#endregion

#region Unicode — IsUnicode 
//Kolon içerisinde unicode karakterler kullanılacaksa bu yapılandırmadan istifade edilebilir.
#endregion

#region Comment — HasComment
//EF Core üzerinden oluşturulmuş olan veritabanı nesneleri üzerinde bir açıkalama/yorum yapmak istiyorsanız Comment'i kullanblirsiniz
#endregion

#region ConcurrencyCheck — IsConcurrencyToken
// İleride/ sonraki derlerde veri tutarlılığı ile ilgili bir ders yapacağız.
// Bu derste bir satırdaki verinin bütünsel olarak tutarlığını sağlayacak olan bir concurrency token yapılanmasından bahsececeğiz.
// İşte bir verinin verisyonunu oluşturmamızı sağlayan yapılanma bu konfigürasyonlardır.
#endregion

#region InverseProperty
// İki entity arasında birden fazla ilişki varsa eğer bu ilişkilerin hangi navigation property üzerinden olacağını ayarlamamızı sağlayan bir konfigrasyondur.
#endregion

#endregion

#region Configurations - Fluent API

#region Composite Key
// Tablblarda birden fazla kolonu kümülatif olarak primary key yapmak istiyorsak buna composite key denir.
#endregion

#region HasDefaultSchema
//EF Core üzerinden inşa edilen herhangi bir veritabanı nesnesi default olarak dbo şemasına sahiptir. Bunu özelleştirebilmek için kullanılan bir yapılandırmadır.
#endregion

#region Property

#region HasDefaultValue
// Tablodaki herhangi bir kolonun değer gönderilmediği durumlarda default olarak hangi değeri alacağını belirler.
#endregion

#region HasDefaultValueSql
// Tablodaki herhangi bir kolonun değer gönderilmediği durumlarda deçault olarak hangi sqL cümleciğinden değeri alacağını belirler.
#endregion
#endregion

#region HasComputedColumnSql
// Tablolarda birden fazla kolondaki veirleri işleyerek değerini oluşturan kolonlara Computed Column denmektedir. EF Core üzerinden bu tarz computed column oluşturabilmek için kullanıolan bir yapılandırmadır.
#endregion

#region HasConstraintName
//EF Core üzerinden oluşturulkan constraint ilere default isim yerine özelleştirilmiş bir isim verebilmek için kullanılan yapılandırmadır.
#endregion

#region HasData
//Sonraki 'derslerimizde Seed Data isimli bir konuyu incleyeceğiz. Bu konuda migrate sürecinde veritabanını inşa ederken bir yandan da yazılım üzerinden hazır veriler oluşturmak istiyorsak eğer buunun yöntemini usulünü inceliyor olacağız.
// İşte HasData konfigürasyonu bu operasyonun yapılandırma ayağıdır.
//HasData ile migrate sürecinde oluşturulacak olan verilerin pk olan id kolonlarına iradeli bir şekilde değerlerin girilmesi zorunludur!
#endregion

#region HasDiscriminator
// İleride entityler arasında kalıtımsal ilişkilerin olduğu TPT ve TPH isminde konuları inceliyor olacağız. İşte bu konularla ilgili yapılandırmalarımız HasDiscriminator ve HasVa1ue fonksiyonlarıdır .l
#region HasValue

#endregion
#endregion

#region HasField
//Backing Field özelliğini kullanmamızı sağlayan bir yapılandırmadır.
#endregion

#region HasNoKey
//NormaL şartlarda EF Core 'da tüm entitylerin bir PK kolonu olmak zorundadır. Eğer ki entity'de pk kolonu olmayacaksa bunun bildirilmesi gerekmektedir! İşte bunun için kullanuılan fonksiyondur.
#endregion

#region HasIndex
// Sonraki derslerimizde EF Core üzerinden Index yapılanmasını detaylıca inceliyor olacağız. 
//Bu ypılanmaya dair konfigürasyonlarımız Haslndex ve Index attribute'dur.
#endregion

#region HasQueryFilter
// İleride göreceğimiz Global QUery Filter başlıklı dersimizin yapılandırmasıdır. 
// Temeldeki görevi bir entitye karşılık uygulama bazında global bir filtre koymaktır.
#endregion

#endregion

#region Data Annotations 
////[Table("Kisiler")]
//public class Person
//{
//    //[Key]
//    //public int KisiSiraNo { get; set; }
//    public int Id { get; set; }
//    //[ForeignKey(nameof(Department))]
//    public int DId { get; set; }
//    //public int DepartmentId { get; set; }
//    //[Column("Adi", TypeName = "Metin",Order =4)]

//    public string Name { get; set; }
//    //[Required] Bu not null yapar ama nullable yapmak iiçn ? eklemek gerekir
//    //[MaxLength(100)]
//    //[StringLength(100)]
//    //[Unicode]
//    public string? Surname { get; set; }
//    //[Precision(5,3)]
//    public decimal Salary { get; set; }
//    //[NotMapped]
//    //public string TablodaOlmasın { get; set; } // Yazılımsal amaçla oluşturduğum bir property

//    //[Timestamp]
//    //[Comment("Bu veri versiyonlamaya yaramaktadır")]
//    //public byte[] RowVersion { get; set; }
//    //[ConcurrencyCheck]
//    //public string ConcurrencyCheck { get; set; }
//    public DateTime CreatedDate { get; set; }
//    public Department Department { get; set; }

//}
#endregion
#region Fluent API Person
public class Person
{
    public int Id { get; set; }
    public int Id2 { get; set; }
    public int DepartmentId { get; set; }
    public string Name { get=>_name; set=> _name=value; }
    public string _name;
    public string? Surname { get; set; }
    public decimal Salary { get; set; }
    public DateTime CreatedDate { get; set; }
    public Department Department { get; set; }
}
#endregion

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Person> Persons { get; set; }
}

public class Example
{
    //public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Computed { get; set; }
}

public abstract class Entity
{
    public int Id { get; set; }
    public string X { get; set; }
}
public class A:Entity
{
    public int Y { get; set; }
}
public class B:Entity
{
    public int Z { get; set; }
}

public class Flight
{
    public int FlightId { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAiportId { get; set; }
    public string Name { get; set; }
    public Airport DepartureAirport { get; set; }
    public Airport ArrivalAirport { get; set; }

}

public class Airport
{
    public int AirportId { get; set; }
    public string Name { get; set; }

    [InverseProperty(nameof(Flight.DepartureAirport))]
    public ICollection<Flight> DepartingFlights { get; set; }
    [InverseProperty(nameof(Flight.ArrivalAirport))]
    public ICollection<Flight> ArrivingFlights { get; set; }
}

public class EFCoreConfigurationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Example> Examples { get; set; }
    public DbSet<Entity> Entities { get; set; }
    public DbSet<A> As { get; set; }
    public DbSet<B> Bs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=EFCoreConfigurationDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region GetEntityTypes

        //var entites =modelBuilder.Model.GetEntityTypes();
        //foreach (var entity in entites)
        //{
        //    Console.WriteLine(entity);
        //}
        #endregion
        #region ToTable
        //modelBuilder.Entity<Person>().ToTable("Kisiler");
        #endregion
        #region Column
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Name)
        //    .HasColumnName("Adi")
        //    .HasColumnType("nvarchar(20)")
        //    .HasColumnOrder(3);

        #endregion
        #region ForeignKey
        //modelBuilder.Entity<Person>()
        //    .HasOne(p => p.Department)
        //    .WithMany(d => d.Persons)
        //    .HasForeignKey(p => p.DId);
        #endregion
        #region Ignore
        //modelBuilder.Entity<Person>()
        //    .Ignore(p => p.TablodaOlmasın);
        #endregion
        #region HasKey
        //modelBuilder.Entity<Person>()
        //    .HasKey(p => p.KisiSiraNo);
        #endregion
        #region IsRowVersion
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.RowVersion)
        //    .IsRowVersion();
        #endregion
        #region IsRqeuired
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Surname)
        //    .IsRequired();
        #endregion
        #region HasMaxLength
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Surname)
        //    .HasMaxLength(100);
        #endregion
        #region Precision
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Salary)
        //    .HasPrecision(5);
        #endregion
        #region Unicode
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Surname)
        //    .IsUnicode(true);
        #endregion
        #region Comment
        //modelBuilder.Entity<Person>()
        //    .HasComment("Bu tablo .. işe yaramaktadır")
        //    .Property(p => p.Surname)
        //    .HasComment("Bu kolon soyisim tutmak için verildi");
        #endregion
        #region ConcurrencyCheck
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.ConcurrencyCheck)
        //    .IsConcurrencyToken();
        #endregion
        #region CompositeKey
        //modelBuilder.Entity<Person>()
        //    .HasKey("Id", "Id2");
        //modelBuilder.Entity<Person>()
        //    .HasKey(p=> new {p.Id,p.Id2});
        #endregion
        #region HasDefaultSchema
        //modelBuilder.HasDefaultSchema("mySchema");
        #endregion
        #region Porperty

        #region HasDefaultValue
        //modelBuilder.Entity<Person>()
        //  .Property(p => p.Salary)
        //  .HasDefaultValue(100);
        #endregion
        #region HasDefaultValueSql
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.CreatedDate)
        //    .HasDefaultValueSql("GETDATE()");
        #endregion
        #endregion
        #region HasComputedColumnSql
        //modelBuilder.Entity<Example>()
        //    .Property(e => e.Computed)
        //    .HasComputedColumnSql("[X] + [Y]");
        #endregion
        #region HasConstraintName
        //modelBuilder.Entity<Person>()
        //    .HasOne(p => p.Department)
        //    .WithMany(p => p.Persons)
        //    .HasForeignKey(p => p.DepartmentId)
        //    .HasConstraintName("FK_Department_DepartmanID");
        #endregion
        #region HasData
        //modelBuilder.Entity<Department>().HasData(
        //     new Department() { Id = 1, Name = "Yazılım" },
        //     new Department() { Id = 2, Name = "Yazılım" });
        //modelBuilder.Entity<Person>()
        //    .HasData(new Person { Id = 1, Name = "Zehra", Surname = "Dilek", Salary = 5000, CreatedDate = DateTime.Now },
        //    new Person { Id = 2, Name = "Zehra", Surname = "Dilek", Salary = 5000, CreatedDate = DateTime.Now });
        #endregion
        #region HasDiscriminator
        //modelBuilder.Entity<Entity>()
        //    .HasDiscriminator<int>("Ayirici")
        //    .HasValue<A>(1)
        //    .HasValue<B>(2)
        //    .HasValue<Entity>(3);
        #endregion
        #region HasField
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Name)
        //    .HasField(nameof(Person._name));
        #endregion
        #region HasNoKey
        //modelBuilder.Entity<Example>()
        //    .HasNoKey();
        #endregion
        #region HasIndex
        //modelBuilder.Entity<Person>()
        //    .HasIndex(p => new { p.Name, p.Surname });
        #endregion
        #region HasQueryFilter
        //modelBuilder.Entity<Person>()
        //    .HasQueryFilter(p => p.CreatedDate.Year == DateTime.Now.Year);
        #endregion
    }
}