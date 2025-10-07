// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
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

#endregion

//[Table("Kisiler")]
public class Person
{
    //[Key]
    //public int KisiSiraNo { get; set; }
    public int Id { get; set; }
    //[ForeignKey(nameof(Department))]
    public int DId { get; set; }
    //public int DepartmentId { get; set; }
    //[Column("Adi", TypeName = "Metin",Order =4)]

    public string Name { get; set; }
    //[Required] Bu not null yapar ama nullable yapmak iiçn ? eklemek gerekir
    public string? Surname { get; set; }
    public decimal Salary { get; set; }
    //[NotMapped]
    //public string TablodaOlmasın { get; set; } // Yazılımsal amaçla oluşturduğum bir property

    //[Timestamp]
    public byte[] RowVersion { get; set; }
    public DateTime CreatedDate { get; set; }
    public Department Department { get; set; }

}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Person> Persons { get; set; }
}

public class EFCoreConfigurationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Department> Departments { get; set; }

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

    }
}