
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
ApplicationDbContext context = new();
#region CompLext Query Operators

#region Join
#region Query Syntax
//var query = from photo in context.Photos
//            join person in context.Persons
//            on photo.PersonId equals person.Id
//            select new
//            {
//                person.Name,
//                photo.Url,
//            };
//var datas=await query.ToListAsync();

//var ordersQeury = from order in context.Orders
//                  join person in context.Persons
//                  on order.PersonId equals person.Id
//                  where person.Name.Contains("uh")
//                  select new
//                  {
//                      person.Name,
//                      order.Description,
//                  };
//var orders= await ordersQeury.ToListAsync();
#endregion
#region Method Syntax
//var query = context.Photos
//    .Join(context.Persons,
//    photo=> photo.PersonId,
//    person=> person.Id,
//    (photo,person)=> new {
//    person.Name,
//    photo.Url,
//    });
//var datas= await query.ToListAsync();

//var orders = await context.Orders
//    .Join(context.Persons, order =>
//    order.PersonId,
//    person => person.Id,
//    (order, person) => new
//    {
//        person.Name,
//        order.Description,
//    })
//    .Where(person => person.Name.Contains("u"))
//    .ToListAsync();

//var getByNameContainsPhotoUrl= await context.Persons
//    .Join(context.Photos,
//    person=> person.Id,
//    photo=> photo.PersonId,
//    (person,photo)=>new
//    {
//        person.Name,
//        photo.Url,
//    })
//    .FirstOrDefaultAsync(p=> p.Name.Contains("muh"));

#endregion

#region Multiple Columns Join
#region Query Syntax
//Not: birden fazla kolon ile join işlemi yapılcaksa o zaman ananonim türk oluşturmak icap eder.
//var query = from photo in context.Photos
//            join person in context.Persons
//            on new { Id = photo.PersonId, photo.Url } equals new { person.Id, Url = person.Name }
//            select new
//            {
//                person.Name,
//                photo.Url,
//            };
//var datas= await query.ToListAsync();
//Örneğimiz her ne kadar mantıksal açıdan saçma olsada burda alınması gerekn ders anaonim yapılandırmada kullanılan alias'tır. Görülüdüğü üzere kolon adları aynı olmadığı için hata vereceğinde bir nevi alias tanımlayarak hata vermesini önlemiş ve sorgunun çalışmasını sağlamış olduk.
#endregion
#region Method Syntax
//var query = context.Photos
//    .Join(context.Persons,
//    photo=> new
//    {
//        Id=photo.PersonId,
//        photo.Url,
//    },
//    person=> new
//    {
//        Id=person.Id,
//        Url=person.Name,
//    },
//    (photo,person) =>new
//    {
//      person.Name,
//      photo.Url,
//    }
//    );
//var datas=await query.ToListAsync();
#endregion
#endregion

#region 2' den Fazla Tabloyla Join
#region Query Syntax
//var query = from photo in context.Photos
//            join person in context.Persons
//            on photo.PersonId equals person.Id
//            join order in context.Orders
//            on person.Id equals order.PersonId
//            select new
//            {
//                person.Name,
//                photo.Url,
//                order.Description,
//            };
//var datas= await query.ToListAsync();
#endregion
#region Method Syntax
//var query = context.Photos
//    .Join(context.Persons,
//    photo => photo.PersonId,
//    person => person.Id,
//    (photo, person) => new
//    {
//        photo.Url,
//        person.Id,
//        person.Name
//    })
//    .Join(context.Orders,
//    oncekiSorgu => oncekiSorgu.Id,
//    order => order.PersonId,
//    (oncekiSorgu, order) => new
//    {

//        oncekiSorgu.Name,
//        oncekiSorgu.Url,
//        order.Description
//    });
//var datas= await query.ToListAsync();
#endregion
#endregion

#region Group Join- GroupBy Değil!
//var query = from person in context.Persons
//            join order in context.Orders
//                on person.Id equals order.PersonId into personOrders
//            select new
//            {
//                person.Name,
//                Count = personOrders.Count(),
//                personOrders
//            };
//var datas=await query.ToListAsync();
#endregion


#endregion

//Left ya da right join işlemleri query syntax üzerinden gerçekleşir dolayısıyla method syntaxda left ya da right join işlemini arama!
//DefauLtIfEmpty : Sorgulama sürecinde iLişkiseL olarak karşılığı olmayan verilere deşault değerini yazdıran yani LEFT JOIN sorgusunu oluşturtan bir fonksiyondur.
#region Left Join
//Person addPerson = new() { Name = "Gıyasettin", Gender = Gender.Man };
//await context.AddAsync(addPerson);
//await context.SaveChangesAsync();
//var query = from person in context.Persons
//            join order in context.Orders
//             on person.Id equals order.PersonId into personOrders
//            from order in personOrders.DefaultIfEmpty()
//            select new
//            {
//                person.Name,
//                order.Description
//            };
//var datas= await query.ToListAsync();
#endregion

#region Right Join
//SOrgu neticesinde yine sql de left join yapmış oluyoruz. ama mantık olarak tabloların yerini değiştirmiş olduk.
//var query = from order in context.Orders
//            join person in context.Persons
//             on order.PersonId equals person.Id into orderPersons
//            from person in orderPersons.DefaultIfEmpty()
//            select new
//            {
//                person.Name,
//                order.Description,  
//            };
//var datas= await query.ToListAsync();
#endregion

#region Full Join
//var leftQuery = from person in context.Persons
//                join order in context.Orders
//                on person.Id equals order.PersonId into personOrders
//                from order in personOrders.DefaultIfEmpty()
//                select new
//                {
//                    person.Name,
//                    order.Description,
//                };
//var rightQuery = from order in context.Orders
//                 join person in context.Persons
//                 on order.PersonId equals person.Id into orderPersons
//                 from person in orderPersons.DefaultIfEmpty()
//                 select new { person.Name, order.Description, };

////var fullJoin = leftQuery.Union(rightQuery); 
//var fullJoin = leftQuery.Concat(rightQuery);

//var fullDatas=await fullJoin.ToListAsync();

#endregion

#region Cross Join
//var crossQuery = from person in context.Persons
//                 from order in context.Orders
//                 select new
//                 {
//                     person.Name,
//                     order.Description
//                 };
//var datas= await crossQuery.ToListAsync();
#endregion

#region Collection Selector' da Where Kullanma Durumu
//var query = from order in context.Orders
//            from person in context.Persons.Where(p => p.Id == order.PersonId) //Bu şekilde bir sorgulama ef core tarafında inner join davranışına sebep olacaktır.
//            select new
//            {
//                person,
//                order
//            };
//var datas= await query.ToListAsync();
#endregion

#region Cross Apply

#endregion

#region Cross Apply
//Inner Join
var query = from person in context.Persons
            from order in context.Orders.Select(o => person.Name)
            select new
            {
                person.Name,
                order
            };
var datas= await query.ToListAsync();
#endregion

#region Outer Apply
//left join
var query2 = from person in context.Persons
            from order in context.Orders.Select(o => person.Name).DefaultIfEmpty()
            select new
            {
                person.Name,
                order
            };
var datas2 = await query2.ToListAsync();
#endregion

#endregion
Console.WriteLine("Hello, World!");

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public Gender Gender { get; set; }
    public Photo Photo { get; set; }

    public ICollection<Order> Orders { get; set; }


}
public class Photo
{
    public int PersonId { get; set; }
    public string? Url { get; set; }


    public Person Person { get; set; }

}
public enum Gender
{
    Man = 1,
    Woman = 2
}
public class Order
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string? Description { get; set; }

    public Person Person { get; set; }

}

public class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ComplexQueries;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}