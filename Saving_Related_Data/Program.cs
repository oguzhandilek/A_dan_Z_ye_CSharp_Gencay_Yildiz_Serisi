// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

Console.WriteLine("Hello, World!");
ApplicationDbContext context = new();
#region One to One İlişkisel Senaryolarda Veri Ekleme
#region 1. Yöntem —> Principal Entity Üzerinden Dependent Entity Verisi Ekleme

//Person person = new Person();
//person.PersonName = "Sütlaç";
//person.Address = new() { PersonAddress = "Keçören/ANKARA" };

//await context.AddAsync(person);
//await context.SaveChangesAsync();
#endregion
// Eğer ki principal entity üzerinden ekleme gerçekleştiriliyorsa dependent entity nesnesi verilmek zorunda değildir! Amma velakin, dependent entity üzerinden ekleme işlemi gerçekleştiriliyorsa eğer burada principaL entitynin nesnesine ihtiyacımız zaruridir.

#region 2. Yöntem -> Dependent Entity Uzerinden Principal Entity Verisi Ekleme
//Address address = new()
//{
//    PersonAddress = "Tortum/ERZURUM",
//    Person = new() { PersonName = "Rumeysa" }
//};
//await context.AddAsync(address);
//await context.SaveChangesAsync();
#endregion

//public class Person
//{
//    public int Id { get; set; }
//    public string PersonName { get; set; }

//    public Address Address { get; set; }

//}

//public class Address
//{
//    public int Id { get; set; }
//    public string PersonAddress { get; set; }

//    public Person Person { get; set; }
//}

//public class ApplicationDbContext:DbContext
//{
//    public DbSet<Person> Persons { get; set; }
//    public DbSet<Address> Addresses { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ApplicationDb;Trusted_Connection=True;");

//    }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Person>()
//            .HasKey(p=> p.Id);
//        //modelBuilder.Entity<Person>()
//        //    .HasOne(p => p.Address)
//        //    .WithOne(p => p.Person)
//        //    .HasForeignKey<Address>(a => a.Id);

//        modelBuilder.Entity<Address>()
//            .HasOne(a => a.Person)
//            .WithOne(p => p.Address)
//            .HasForeignKey<Address>(a => a.Id);
//    }
//}
#endregion

#region One to Many İlişkisel Senaryolarda Veri Ekleme
#region 1. Yöntem —> Principal Entity Üzerinden Dependent Entity Verisi Ekleme
#region Nesne Referansı Üzerinden Ekleme

//Blog blog = new();
//blog.Name = "Blog A";
//blog.Posts.Add(new() { Title="Post 1"});
//blog.Posts.Add(new() { Title = "Post 2" });
//blog.Posts.Add(new() { Title="Post 3"});

//await context.AddAsync(blog);
//await context.SaveChangesAsync();
#endregion
#region Object Initializer Uzerinden Ekleme
//Blog blog = new() {
//    Name="Blog B",
//    Posts=new HashSet<Post>() {new() { Title="Post 4"}, new() { Title="Post 5"} }
//};

//await context.AddAsync(blog);
//await context.SaveChangesAsync();
#endregion
#endregion
#region 2. Yöntem -> Dependent Entity Uzerinden Principal Entity Verisi Ekleme
//2. Yöntem kısıtlıdır ve yapılmaması tavsiye edilir.
//Post post = new() { Title = "Post 6", Blog = new() { Name = "Blog C" } };
//await context.AddAsync(post);
//await context.SaveChangesAsync();
#endregion
#region 3. Yöntem-> Foreign Key Kolonu Uzerin en Veri Ekleme
// 1. ve 2. yöntemler hiç olmayan verilerin ilişkisel olarak eklenmesini sağlarken, bu 3. yöntem önceden eklenmiş olan bir principal entity verisiyle yeni dependent entityLerin ilişkiseL olarak eklettirilmesini sağlamaktadır.
//Post post = new()
//{
//    BlogId = 1,
//    Title = "Post 7"
//};
//await context.AddAsync(post);
//await context.SaveChangesAsync();
#endregion

//public class Blog
//{
//    public Blog()
//    {
//        Posts=new HashSet<Post>(); //1 .Yöntem kullanılacakasa bu şart veya yukarıda new'lemek şart
//    }

//    public int Id { get; set; }
//    public string Name { get; set; }

//    public ICollection<Post> Posts { get; set; }
//}

//public class Post
//{
//    public int Id { get; set; }
//    public int BlogId { get; set; }
//    public string Title { get; set; }

//    public Blog Blog { get; set; }

//}
//public class ApplicationDbContext : DbContext
//{

//    public DbSet<Blog> Blogs { get; set; }
//    public DbSet<Post> Posts { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ApplicationDb;Trusted_Connection=True;");

//    }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//      modelBuilder.Entity<Blog>()
//            .HasKey(b => b.Id);
//        //modelBuilder.Entity<Post>()
//        //      .HasOne(p => p.Blog)
//        //      .WithMany(b => b.Posts)
//        //      .HasForeignKey(p => p.BlogId);

//        modelBuilder.Entity<Blog>()
//               .HasMany(b => b.Posts)
//               .WithOne(p => p.Blog)
//               .HasForeignKey(p => p.BlogId);

//    }
//}
#endregion

#region Many to Many İlişkisel Senaryolarda Veri Ekleme

#region 1.Yöntem
// n to n ilişkisi eğer ki default convention üzerinden tasarlanmışsa kullanılan bir yöntemdir.
//Book book = new Book() { 
//    BookName = "Kitap 1", Authors = new HashSet<Author>()
//{   new () { AuthorName = "Yazar 1" }, 
//    new() { AuthorName = "Yazar 2" },
//    new() { AuthorName = "Yazar 3" } 
//} 
//};

//await context.Books.AddAsync(book);
//await context.SaveChangesAsync();
//public class Book
//{
//    public int Id { get; set; }
//    public string BookName { get; set; }

//    public ICollection<Author> Authors { get; set; }

//}

//public class Author
//{
//    public int Id { get; set; }
//    public string AuthorName { get; set; }

//    public ICollection<Book> Books { get; set; }
//}
//public class ApplicationDbContext : DbContext
//{
//    public DbSet<Book> Books { get; set; }
//    public DbSet<Author> Authors { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ApplicationDb;Trusted_Connection=True;");

//    }

//}
#endregion

#region 2. Yöntem
// n to n ilişkisi eğer ki fLuent api ile tasarlanmışsa kullanılan bir yöntemdir.

//Author author = new()
//{
//    AuthorName="Yazar 1",
//    Books= new HashSet<BookAuthor>() { new(){Book=new Book() { BookName="Kitap B"} } }
//};
//await context.AddAsync(author);

Book book = new()
{
    BookName = "Kitap 2",
    Authors=new HashSet<BookAuthor>()
    {
        new()
        {
            AuthorId=1

        },
        new()
        {
            Author=new(){AuthorName="Yazar 2"}
        }
    }
};
await context.AddAsync(book);
await context.SaveChangesAsync();
public class Book
{
    public Book()
    {
        Authors = new HashSet<BookAuthor>();
    }
    public int Id { get; set; }
    public string BookName { get; set; }

    public ICollection<BookAuthor> Authors { get; set; }

}

public class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }

    public Book Book { get; set; }
    public Author Author { get; set; }
}
public class Author
{
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public ICollection<BookAuthor> Books { get; set; }
}
public class ApplicationDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ApplicationDb;Trusted_Connection=True;");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.AuthorId, ba.BookId });
        modelBuilder.Entity<BookAuthor>()
            .HasOne(b => b.Author)
            .WithMany(b => b.Books)
            .HasForeignKey(b => b.AuthorId);
        modelBuilder.Entity<BookAuthor>()
            .HasOne(a => a.Book)
            .WithMany(a => a.Authors)
            .HasForeignKey(a => a.BookId);

    }
}
#endregion


#endregion