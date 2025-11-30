using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

ApplicationDbContext context = new();


#region Loading ReLated Data

#region Eager Loading
//Eager Loading, generate edilen bir sorguya ilişkisel verilerin parça parça eklenmesini sağlayan ve bunu yaparken iradeli/ istekli bir şekilde yapmamızı sağlayan bir yöntemdir.

#region Include
//Eager Loading operasyonunu yapmamızı sağlayan bir fonksiyondur. 
// Yani üretilen bir sorguya diğer ilişkisel tabloların dahil edilmesini sağlayan bir işleve sahiptir..

//var employees= await context.Employees
//    .Where(e=> e.Orders.Count > 2)
//    .Include(e=> e.Orders)
//    //.Include("Orders") // Bu atnımlama genellikle Shadow Prop.larda kullanılır
//    .Include(e=> e.Region)
//    .ToListAsync();
#endregion

#region ThenInclude
// ThenInclude, üretilen sorguda Include edilen tabloların ilişkili olduğu diğer tablolarıda sorguya ekleyebilmek için kullanılan bir fonksiyondur.
//Eğer ki, üretilen sorguya include edilen navigation property koleksiyonel bir propertyse işte o zaman bu property üzerinden diğer ilişkisel tabloya erişim gösterilememektedir. Böyle bir durumda koleksiyonel propertylerin türlerine erişip, o tür ile ilişkili diğer tablolarıda sorguya eklememizi sağlayan fonksiyondur .

//var orders= await context.Orders
//    .Include(o=> o.Employee)
//    .Include(o=> o.Employee.Region)
//    .ToListAsync();

//var regions = await context.Regions
//    .Include(r => r.Employees)
//    .ThenInclude(r => r.Orders)
//    .ToListAsync();
#endregion

#region Filtered Include
// Sorgulama süreçlerinde IncLude yaparken sonuçlar üzerinde filtreleme ve sıralama gerçekleştirebilmemizi sağlayan bir özleliktir.

//var regions = await context.Regions
//    .Include(r => r.Employees
//                   .Where(e => e.Name
//                   .Contains("a"))
//                   .OrderByDescending(e=> e.Surname))
//    .ToListAsync();

// Desktelenen fonksiyon: Where, OrderBy , OrderByDescending, ThenBy, ThenByDescending, Skip,Take

//Change Tracker'ın aktif olduğu durumlarda Include edilmiş sorgular üzerindeki filtreleme sonuçları beklenmeyen olabilir. Bu durum, daha önce sorgulanmş ve Change Tracker tarafından takip edilmiş veriler arasında filtrenin gereksinimi dışında kalan veriler için söz konusu olacaktır. Bundan dolayı sağlıklı bir filtred incLude operasyonu için change tracker' ın kullanılmadığı sorguları tercih etmeyi düşünebilirsiniz.
#endregion

#region Eager Loading İçin Kritik Bir Bilgi
//EF Core, önceden üretilmiş ve execute edilerek verileri belleğe alınmış olan sorguların verileri, sonraki sorgularda KULLANIR!
//var orders = await context.Orders.ToListAsync();
//var employees=await context.Employees.ToListAsync();
#endregion

#region Birbirlerinden Türetilmiş Entityler Arasında Include
//Örneğimizi Person entity'sini Table Per Hirerarcy davranışı ile gerçekleştirdik.

#region Cast Operatörü ile Include
//var person1= await context.Persons
//    .Include(p=> ((Employee)p).Orders)
//    .FirstOrDefaultAsync(p=> p.Id==1);

#endregion

#region as Operatörü ile Include.
//var person2= await context.Persons
//    .Include(p=> (p as Employee).Orders)
//    .FirstOrDefaultAsync(p=> p.Id == 2);
#endregion

#region 2. Overload ile Include
//var person3= await context.Persons
//    .Include("Orders")
//    .FirstOrDefaultAsync(p=> p.Id == 3);
#endregion

#endregion

#region AutoInclude - EF Core 6
//Uygulama seviyesinde bir entitye karşılık yapılan tüm sorgulamalarda "kesinlikle” bir tabloya IncLude işlemi gerçekleştirlecekse eğer bunu her bir sorgu için tek tek yapmaktansa merkezi bir hale getirmemizi sağlayan özelliktir.

//var employees= await context.Employees.ToListAsync();
#endregion

#region IgnoreAutoIncludes
// AutoIncLude konfigürasyonunu sorgu seviyesinde pasifize edebilmek için kullandığımız fonksiyondur.

//var employe=await context.Employees.IgnoreAutoIncludes().FirstOrDefaultAsync(e=> e.Name.Contains("e"));
#endregion
#endregion

#region Explicit Loading
//OLuşturuLan sorguya eklenecek verilerin şartlara bağlı bir şekilde/ ihtiyaçlara istinaden yüklenmesini sağlayan bir yaklaşımdır.

#region Reference
//Exp1icit Loading sürecinde ilişkisel olarak sorguya eklenmek istenen tablonun navigation propertysi eğer ki tekil bir türse bu tabloyu reference ile sorguya ekleyebilemkteyiz.

//var employee = await context.Employees.FirstOrDefaultAsync(e=> e.Id == 1);
//
//
//
//await context.Entry(employee).Reference(e=> e.Region).LoadAsync();
#endregion
#region Collection
//ExpLicit Loading sürecinde ilişkisel olarak sorguya eklenmek istenen tablonun navigation propertysi eğer ki çoğul/koleksiyoneL bir türse bu tabloyu Collection ile sorguya ekleyebilemkteyiz. 

//var employe = await context.Employees.FirstOrDefaultAsync(e => e.Id == 2);  
////
////
////
////
//await context.Entry(employe).Collection(w=> w.Orders).LoadAsync();
#endregion

#region Collection'Iar da Aggregate Operatör Uygulamak
//var employee= await context.Employees.FirstOrDefaultAsync(e=> e.Id == 1);
//var count = await context.Entry(employee).Collection(e=> e.Orders).Query().CountAsync();
//Console.WriteLine();
#endregion
#region Collection'larda Filtreleme Gerçekleştirmek
//var employe= await context.Employees.FirstOrDefaultAsync(e=> e.Id == 2);
//var orders= await context.Entry(employe).Collection(e=> e.Orders).Query().Where(o=> o.OrderDate.Month==DateTime.Now.Month).ToListAsync();
#endregion
#endregion




#region Lazy Loading
//var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == 3);

//Console.WriteLine(employee.Region.Name);

#region Lazy Loading Nedir?
//Navigation propertylLer üzerinde bir işlem yapılmaya çalışıldığı taktirde ilgili propertynin/ ye/ temsil ettiği/ karşılık gelen tabloya özel bir sorgu oluşturulup execute edilmesini ve verilerin yüklenmesini sağlayan bir yaklaşımdır.
#endregion

#region Proxy'lerle Lazy Loading 
//Microsoft.EntityFrameworkCore.Proxies
#region Propertylerin virtual Olması
//Eğer ki proxler üzerinden lazy Ioading operasyonu gerçekleştiriyorsanız Navigtation Propertylerin virtual ile işaretlenmiş olması gerekmektedir. Aksi taktirde patlama meydana gelecektir . 
#endregion
#endregion

#region Proxy Olmaksızın Lazy Loading
// Prox'ler tüm platformlarda desteklenmeyebilir. Böyle bir durumda manuel bir şekilde lazy loading'i uygulamak mecburiyetinde kalabiliriz .
//ManueL yapılan Lazy Loading operasyonlarında Navigation Proeprtylerin virtual ile işaretlenmesine gerek yoktur!
var employee = await context.Employees.FindAsync(1);
Console.WriteLine(employee.Region.Name);
Console.WriteLine(employee.Orders[1].OrderDate.Month);
#region ILazyLoader Interface'i İle Lazy Loading
//Microsoft.EntityFrameworkCore.Abstractions
#endregion
#region Delegate İle Lazy Loading

#endregion

#region N+1 Problemi
//Lazy Loading, kullanım açısından oldukça maliyetli ve performans düşürücü bir etkiye sahip yöntemdir. O yüzden kullanırken mümkün mertebe dikkatli olmalı ve özellikle navigation propertylerin döngüsel tetiklenme durumlarında Lazy Loading'i tercih etmemeye odaklanmalıyız. Aksi taktirde her bir tetiklemeye karşılık aynı sorguları üretip execute edecektir. Bu durumu N+1 Problemi olarak nitelendirmekteyiz .
//Mümkün mertebe, ilişkisel verileri eklerken Lazy Loading kullanmamaya özen göstermeliyiz.
#endregion
#endregion

#endregion
#endregion

Console.WriteLine("Hello, World!");

#region ILazyLoader Interface'i ile LazyLaoding 
//public class Person
//{
//    public int Id { get; set; }
//}
//public class Employee
//{
//    private readonly ILazyLoader _lazyLoader;
//    private Region _region;
//    private List<Order> _orders;
//    public Employee()
//    {
//    }
//    public Employee(ILazyLoader lazyLoader)
//        => _lazyLoader = lazyLoader;

//    public int Id { get; set; }
//    public int RegionId { get; set; }
//    public string? Name { get; set; }
//    public string? Surname { get; set; }
//    public int Salary { get; set; }

//    //LazyLoadig operasyonunu aşağıdaki gibi manuel olarak kullanacaksak virtual ile işaretlemeye gerek yok
//    public virtual Region Region
//    {
//        get => _lazyLoader?.Load(this, ref _region);
//        set => _region = value;
//    }
//    public virtual List<Order> Orders
//    {
//        get => _lazyLoader.Load(this, ref _orders);
//        set => value = _orders;
//    }


//}

//public class Region
//{
//    private readonly ILazyLoader _lazyLoader;
//    private ICollection<Employee> _employees;

//    public Region()
//    {
//    }
//    public Region(ILazyLoader lazyLoader)
//    {
//        _lazyLoader = lazyLoader;
//    }

//    public int Id { get; set; }
//    public string Name { get; set; }

//    public virtual ICollection<Employee> Employees
//    {
//        get => _lazyLoader.Load(this, ref _employees);
//        set => _employees = value;
//    }
//}

//public class Order
//{
//    private readonly ILazyLoader _lazyLoader;
//    private Employee _employee;

//    public Order()
//    {
//    }
//    public Order(ILazyLoader lazyLoader)
//    {
//        _lazyLoader = lazyLoader;
//    }

//    public int Id { get; set; }
//    public int EmployeeId { get; set; }
//    public DateTime OrderDate { get; set; }

//    public virtual Employee Employee
//    {
//        get => _lazyLoader.Load(this, ref _employee);
//        set => value = _employee;
//    }

//}
#endregion

#region Delegate İle LazyLaoding
public class Person
{
    public int Id { get; set; }
}
public class Employee
{
    private readonly ILazyLoader _lazyLoader;
    private Region _region;
    private List<Order> _orders;
    public Employee()
    {
    }
    public Employee(ILazyLoader lazyLoader)
        => _lazyLoader = lazyLoader;

    public int Id { get; set; }
    public int RegionId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Salary { get; set; }

    //LazyLoadig operasyonunu aşağıdaki gibi manuel olarak kullanacaksak virtual ile işaretlemeye gerek yok
    public virtual Region Region
    {
        get => _lazyLoader?.Load(this, ref _region);
        set => _region = value;
    }
    public virtual List<Order> Orders
    {
        get => _lazyLoader.Load(this, ref _orders);
        set => value = _orders;
    }


}

public class Region
{
    private readonly ILazyLoader _lazyLoader;
    private ICollection<Employee> _employees;

    public Region()
    {
    }
    public Region(ILazyLoader lazyLoader)
    {
        _lazyLoader = lazyLoader;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Employee> Employees
    {
        get => _lazyLoader.Load(this, ref _employees);
        set => _employees = value;
    }
}

public class Order
{
    private readonly ILazyLoader _lazyLoader;
    private Employee _employee;

    public Order()
    {
    }
    public Order(ILazyLoader lazyLoader)
    {
        _lazyLoader = lazyLoader;
    }

    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }

    public virtual Employee Employee
    {
        get => _lazyLoader.Load(this, ref _employee);
        set => value = _employee;
    }

}
#endregion


public class ApplicationDbContext:DbContext
{
    //public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Region> Regions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies(false) //manuel lazy loading iin false çektik
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LRDDb;Trusted_Connection=True;");

        //optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}