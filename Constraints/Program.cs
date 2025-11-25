

using Microsoft.EntityFrameworkCore;

#region Primary Key Constraint
// Bir kolonu PK constraint ile birincil anahtar yapmak istiyorsak eğer bunun için name convention 'dan istifade edebiliriz. idi İDİ EntityNameId, EntityNameID şeklinde tanımlanan tüm propertyLer default olarak EF Core tarafından pk constraint olacak şekilde generate edilirler. 
//Eğer ki, farklı bir propertyle PK özelliğini atamak istiyorsan burada HasKey Fluent API'I yahut Key attributelu ile bu bildirimi iradeli bir şekilde yapmak zorundasın.
#region Alternate Keys
//Bir entity içerisinde PK' e ek olarak her entity instance'ı için alternatif bir benzersiz tanımlayıcı işlevine sahip olan bir key'dir.
#endregion
#region Composite Alternate Key
//Örenği aşağıda
#endregion
#region HasName Fonksiyonu İle Primary Key Constraint'e İsim Verme

#endregion
#endregion

#region Foreign Key Constraint
#region Shadow Property Uzerinden Foreign Key
//Eğer entity'de foreignkey  property'sini yazmak istemiyor veya yazmamamk gibi bir senaryonuz var anck yiende veritabaında foreign key kolonuna ihtiyaç duyorsanız kullanabilirsiniz.
#endregion
#region HasConstraintName Fonksiyonu İle Primary Key Constraint'e isim Verme

#endregion
#endregion

#region Unique Constraint
#region HasIndex-IsUnique Fonksiyonları

#endregion

#region Index-IsUnique Attribute'leri

#endregion

#region Alternate Key

#endregion
#endregion

#region Check Constraint
#region HasCheckConstraint

#endregion
#endregion

Console.WriteLine("Hello, World!");

//[Index(nameof(Blog.Url),IsUnique =true)]
public class Blog
{
    public int Id { get; set; }
    public string? BlogName { get; set; }
    public string? Url { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
}
public class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public string? Title { get; set; }
    public string? BlogUrl { get; set; }

    public int A { get; set; }
    public int B { get; set; }

    public virtual Blog Blog { get; set; }

}

public class ApplicationDbContext:DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=Constarints;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Blog>()
        //    .HasKey(b => b.Id);

        //modelBuilder.Entity<Post>()
        //    .HasKey(p => p.Id)
        //    .HasName("OrnekPrimaryKey");

        //modelBuilder.Entity<Blog>().HasAlternateKey(b => b.Url);
        //modelBuilder.Entity<Blog>()
        //    .HasAlternateKey(compositeKey => new { compositeKey.Url, compositeKey.BlogName });

        //modelBuilder.Entity<Blog>()
        //    .HasMany(b => b.Posts)
        //    .WithOne(p => p.Blog)
        //    .HasForeignKey(p => p.BlogId);
        //modelBuilder.Entity<Blog>()
        //    .HasMany(b => b.Posts)
        //    .WithOne(p => p.Blog)
        //    .HasForeignKey(compositeKey => new { compositeKey.BlogId, compositeKey.BlogUrl });



        //modelBuilder.Entity<Post>()
        //    .Property<int>("PostForeignKeyId");
        //modelBuilder.Entity<Post>()
        //    .HasOne(p => p.Blog)
        //    .WithMany(p => p.Posts)
        //    .HasForeignKey("PostForeignKeyId")
        //    .HasConstraintName("ornekForeignKey");

        //modelBuilder.Entity<Blog>()
        //    .HasIndex(b => b.Url)
        //    .IsUnique();

        //modelBuilder.Entity<Blog>()
        //    .HasAlternateKey(b => b.Url);

        modelBuilder.Entity<Post>()
            .ToTable(tb =>
            tb.HasCheckConstraint("a_b_Check_const", "[A] > [B]"));

    }
}

