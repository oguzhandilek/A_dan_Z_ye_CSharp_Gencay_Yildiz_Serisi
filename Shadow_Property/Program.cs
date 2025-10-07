// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

Console.WriteLine("Hello, World!");
ShadowPropertyDbContext context = new();
#region Shadow Properties — Gölge Özellikler
//Entity sınıflarında fiziksel olarak tanımlanmayan/modellenmeyen ancak EF Core tarafından ilgili entity 'için var olan/ var olduğu kabul edilen property'lerdir.
//Tab10da gösterilmesini istemediğimiz/ lüzumlu görmediğimiz/entity instance'ı üzerinde işlem yapmayacağımız kolonlar için shadow propertyLer kullanılabilir.
// Shadow property 'lerin değerleri ve stateleri Change Tracker tarafından kontrol edilir.
#endregion

#region Foreign Key -Shadow Properties
// İlişkisel senaryolarda foreign key property' sini tanımlamadığımız halde EF Core tarafından dependent entity'e eklenmektedir. İşte bu shadow property'dir.
//List<Blog> blogs= await context.Blogs
//    .Include(b=> b.Posts)
//    .ToListAsync();
//Console.WriteLine();
#endregion

#region Shadow Property Oluşturma
//Bir entity üzerinde shadow property oluşturmak istiyorsanız eğer FLuent API'I kullanmanız gerekmektedir.
//modelBuilder.Entity<Blog>()
//           .Property<DateTime>("CreatedDate");
#endregion

#region Shadow Property'e Erişim Sağlama
#region ChangeTracker İle Erişim
// Shadow property'e erişim sağlayabilmek için Change Tracker'dan istifade edilebilir.

//Blog? blog = await context.Blogs.FirstOrDefaultAsync(b=> b.Id==1);
//var createdDate=context.Entry(blog).Property("CreatedDate");
//Console.WriteLine(createdDate.CurrentValue);
//Console.WriteLine(createdDate.OriginalValue);
//createdDate.CurrentValue= DateTime.Now;
//await context.SaveChangesAsync();
//Console.WriteLine(createdDate.OriginalValue);
#endregion
#region EF .Property İle Erişim
//Özellikle LINQ sorgularında Shadow Property 'lerine erişim için EF. Property static yapılanmasını kullanabiliriz .
//var blogs = await context.Blogs.OrderBy(b => EF.Property<DateTime>(b, "CreatedDate")).ToListAsync();

//var blogs2= await context.Blogs.Where(b=> EF.Property<DateTime>(b,("CreatedDate")).Year>2020).ToListAsync();
Console.WriteLine();
#endregion
#endregion
#region Saving
//Blog blog = new()
//{
//    Name = "AlbeyazimSoft",
//    Posts = new HashSet<Post>() { 
//        new() { Title = "Post 1",lastUpdated=true }, 
//        new() { Title="Post 2",lastUpdated=false },
//        new() { Title="Post 3",lastUpdated=true }
//    }
//};

//Blog blog = new() { Name = "KarbeyazimSoft" };

//await context.AddAsync(blog);
//await context.SaveChangesAsync();
//var result=await context.Blogs.FirstOrDefaultAsync(b => b.Name.Contains("Kar"));
//var createdDate=context.Entry(result).Property("CreatedDate");
//createdDate.CurrentValue=DateTime.Now;
//await context.SaveChangesAsync();
#endregion
class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }

}

class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool lastUpdated  { get; set; }

    public Blog Blog { get; set; }

}

class ShadowPropertyDbContext:DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ShadowPropertyDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .Property<DateTime>("CreatedDate");
    }
}