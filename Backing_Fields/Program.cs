// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
BackingFieldsDbContext context = new();
#region Backing Fields
// Tablo içerisindeki kolonları, entity class 'ları içerisinde property 'ler ile değil field'larla temsil etmemizi sağlayan bir özelliktir.

//Person? person = await context.Persons.FindAsync(1);

//Person person1 = new()
//{
//        Name="Name 201",
//        Department="Department 501"
//};
//await context.AddAsync(person1);
//await context.SaveChangesAsync();
//Console.WriteLine();
//public class Person
//{
//    public int Id { get; set; }
//    public string name;
//    public string Name { get=> name.Substring(0,3); set=> name=value.Substring(0,3); }
//    public string Department { get; set; }

//}
#endregion

#region BackingField Attributes
//public class Person
//{
//    public int Id { get; set; }
//    public string name;
//    [BackingField(nameof(name))]
//    public string Name { get; set; }
//    public string Department { get; set; }

//}
#endregion

#region HasField Fluent API
//Fleunt API 'da HasFie1d metodu BackingField özelliğine karşılık gelmektedir.
//public class Person
//{
//    public int Id { get; set; }
//    public string name;
//    public string Name { get; set; }
//    public string Department { get; set; }

//}
#endregion

#region Field And Property Access
//EF Core sorgulama sürecinde entity içerisindeki propertyleri ya da Çield 'Ları kullanıp kullanmayacağının davranışını bizlere belirtmektedir.

//EF Core, hiçbir ayarlana yoksa varsayılan olarak propertyler üzerinden verileri işler, eğer ki backing Çield bildiriliyorsa field üzerinden işler yok eğer backing field bildirildiği halde davranış belirtiliyorsa ne belirtilmişse ona göre işlemeyi devam ettirir.
//UsePropertyAccessMode üzerinden davranış modellemesi gerçekleştirilebilir.

//Person? person = await context.Persons.FindAsync(1);
//Console.WriteLine();
#endregion

#region Fie1d—0nly Properties
//Entity1erde değerleri almak için property'ler yerine metotların kullanıldığı veya belirli alanların hiç gösterilmemesi gerektiği durumlarda(örneğin primary key kolonu) kullanabilir.
Person? person = await context.Persons.FindAsync(3);
var isim=person.GetName();
Console.WriteLine(isim.ToUpper());
public class Person
{
    public int Id { get; set; }
    public string name;
 
    public string Department { get; set; }

    public string GetName()
        => name;
    public string SetName(string value)
        => this.name = value;
}
#endregion
//public class Person
//{
//    public int Id { get; set; }
//    public string name;
//    public string Name { get; set; }
//    public string Department { get; set; }

//}

public class BackingFieldsDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=BackingFieldsDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Person>()
        //    .Property(x => x.Name)
        //    .HasField(nameof(Person.name))
        //    .UsePropertyAccessMode(PropertyAccessMode.Property);

        //Fie1d : Veri erişim süreçlerinde sadece field 'ların kullanılmasını söyler. Eğer field' ın kullanılamayacağı durum söz konusu olursa bir exception fırlatır. 
        //Fie1dDuringConstruction : Veri erişim süreçlerinde ilgili entityden bir nesne oluşturulma sürecinde FieLd 'ların kullanılmasını söyler. , 
        //Property : Veri erişim sürecinde sadece propertynin kullanılmasını söyler. Eğer propertylnin kullanılamayacağı durum söz konusuysa (read—only, write—only) bir exception fırLatır.
        //PreferField ,
        //PreferFieldDuringConstruction
        //PreferProperty

        //-----
        //Field-Only Properties
        modelBuilder.Entity<Person>()
            .Property(nameof(Person.name));
    }
}