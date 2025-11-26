using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

#endregion

#region Lazy Loading

#endregion

#endregion

Console.WriteLine("Hello, World!");

public class Person
{
    public int Id { get; set; }
}
public class Employee:Person
{
    //public int Id { get; set; }
    public int RegionId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Salary { get; set; }

    public Region Region { get; set; }
    public virtual List<Order> Orders { get; set; }
}

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }

    public Employee Employee { get; set; }

}

public class ApplicationDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Region> Regions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=LRDDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}