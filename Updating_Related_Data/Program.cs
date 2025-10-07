// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
ApplicationDbContext context = new ApplicationDbContext();

#region One to One İlişkisel Senaryolarda Veri Güncelleme
#region Saving
//Person person = new() { PersonName = "Zehra", Address = new() { AddressName = "Keçiören/Ankara" } };
//Person person1 = new() { PersonName = "Oğuzhan" };
//await context.AddRangeAsync(person, person1);
//await context.SaveChangesAsync();
#endregion

#region 1.Durum - Esas tablodaki veriye bağımlı veriyi değiştirme
//Person? person = await context.Persons
//    .Include(p => p.Address)
//    .FirstOrDefaultAsync(p => p.Id == 1);
//context.Addresses.Remove(person.Address);

//person.Address = new() { AddressName = "Narman/ERZURUM" };
//await context.SaveChangesAsync();

#endregion
#region 2.Durum - Bağımlı verinin ilişkisel olduğu ana veriyi güncelleme
//Address? address = await context.Addresses.FindAsync(2);
//context.Addresses.Remove(address);
//await context.SaveChangesAsync();

////Person? person = await context.Persons.FindAsync(2);
////address.Person = person;

//address.Person = new()
//{
//    PersonName = "Sütlaç"
//};

//await context.Addresses.AddAsync(address);
//await context.SaveChangesAsync();


#endregion
#endregion

#region One to Many İlişkisel Senaryolarda Veri Güncelleme
#region Saving
//Blog blog = new()
//{
//    Name="AlbeyazimSoft",
//    Posts= new HashSet<Post>()
//    {
//        new(){Title="Post 1"},
//        new(){Title="Post 2"},
//        new(){Title="Post 3"},
//    }
//};
//await context.Blogs.AddAsync(blog);
//await context.SaveChangesAsync();
#endregion

#region 1.Durum - Esas tablodaki veriye bağımlı veriyi değiştirme
//Blog? blog= await context.Blogs
//    .Include(p=> p.Posts)
//    .FirstOrDefaultAsync(b=> b.Id == 1);
//Post? silinecekPost=blog.Posts.FirstOrDefault(b=> b.Id == 2);
//context.Posts.Remove(silinecekPost);

//blog.Posts.Add(new() { Title = "Post 5" });
//blog.Posts.Add(new() { Title = "Post 6" });
//await context.SaveChangesAsync();


#endregion
#region 2.Durum - Bağımlı verinin ilişkisel olduğu ana veriyi güncelleme
//Post? post= await context.Posts.FindAsync(4);
//post.Blog = new() { Name = "KarbeyazımSoft" };
//await context.SaveChangesAsync();

//Post? post= await context.Posts.FindAsync(5);
//Blog? blog=await context.Blogs.FindAsync(2);

//post.Blog = blog;
//await context.SaveChangesAsync();
#endregion
#endregion

#region Many to Many İlişkisel Senaryolarda Veri Güncelleme
#region Saving
//Book book1 = new() { BookName = "Kitap 1" };
//Book book2 = new() { BookName = "Kitap 2" };
//Book book3 = new() { BookName = "Kitap 3" };
//Author author1 = new() { AuthorName = "Yazar 1" };
//Author author2 = new() { AuthorName = "Yazar 2" };
//Author author3 = new() { AuthorName = "Yazar 3" };

//book1.Authors.Add(new BookAuthor { Author=author1});
//book1.Authors.Add(new BookAuthor { Author=author2});

//book2.Authors.Add(new BookAuthor{ Author=author1});
//book2.Authors.Add(new BookAuthor{ Author=author2});
//book2.Authors.Add(new BookAuthor{ Author=author3});

//book3.Authors.Add(new BookAuthor { Author =author3});
//await context.AddRangeAsync(book1,book2,book3);
//await context.SaveChangesAsync();

#endregion
#region 1. örnek
//Book? book = await context.Books.FindAsync(10);
//Author? author = await context.Authors.FindAsync(12);
//book.Authors.Add(new BookAuthor { Author=author});
//await context.SaveChangesAsync();

#endregion
#region 2. Örnek
//Author? author=await context.Authors
//    .Include(a=> a.Books)
//    .FirstOrDefaultAsync(a=> a.Id==12);
//foreach (var book in author.Books)
//{
//    if (book.BookId!=10)
//    {
//        author.Books.Remove(book);
//    }
//}
//await context.SaveChangesAsync();
//;
#endregion

#endregion

public class Person
{
    public int Id { get; set; }
    public string PersonName { get; set; }

    public Address Address { get; set; }

}
public class Address
{
    public int Id { get; set; }
    public string AddressName { get; set; }

    public Person Person { get; set; }
}
public class Blog
{
    public Blog()
    {
        Posts = new HashSet<Post>();
    }
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }
}
public class Post
{

    public int Id { get; set; }
    public int BlogId { get; set; }
    public string Title { get; set; }

    public Blog Blog { get; set; }
}
public class Book
{
    public Book()
    {
        Authors=new HashSet<BookAuthor>();
    }
    public int Id { get; set; }
    public string BookName { get; set; }
    public ICollection<BookAuthor> Authors { get; set; } 

}
public class Author
{
    public Author()
    {
        Books = new HashSet<BookAuthor>();
    }
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public ICollection<BookAuthor> Books { get; set; } 
}

public class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }

    public Author Author { get; set; }
    public Book Book { get; set; }
}

public class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=ApplicationDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Blog>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });

        modelBuilder.Entity<Address>()
            .HasOne(p => p.Person)
            .WithOne(p => p.Address)
            .HasForeignKey<Address>(p => p.Id);

        modelBuilder.Entity<Blog>()
            .HasMany(b => b.Posts)
            .WithOne(b => b.Blog)
            .HasForeignKey(p => p.BlogId);

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