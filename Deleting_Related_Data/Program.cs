// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

Console.WriteLine("Hello, World!");
ApplicationDbContext context = new ApplicationDbContext();
#region One to One İlişkisel Senaryolarda Veri Silme
//Person? person= await context.Persons
//    .Include(p=> p.Address)
//    .FirstOrDefaultAsync(p=> p.Id == 1);
//if (person!=null)
//{
//context.Addresses.Remove(person.Address);
//}
//await context.SaveChangesAsync();
#endregion

#region One to Many İlişkisel Senaryolarda Veri Silme
//Blog? blog = await context.Blogs
//    .Include(b => b.Posts)
//    .FirstOrDefaultAsync(b => b.Id == 1);
//if (blog != null)
//{

//    Post? post1 = blog.Posts.FirstOrDefault(p => p.Id == 2);
//    if (post1 != null)
//        context.Posts.Remove(post1);
//}
//await context.SaveChangesAsync();


#endregion

#region Many to Many İlişkisel Senaryolarda Veri Silme
//Book? book= await context.Books
//    .Include(b=> b.Authors)
//    .ThenInclude(ba=> ba.Author)
//    .FirstOrDefaultAsync(b=> b.Id==10);
//BookAuthor? bookAuthor= book.Authors
//    .FirstOrDefault(ba=> ba.AuthorId==11);
//if (bookAuthor is not null)
//{
//    book.Authors.Remove(bookAuthor);
//    await context.SaveChangesAsync();
//}

//Console.WriteLine();
#endregion

#region Cascade Delete
//Bu davranış modelleri Fluent API ile konfigüre edilebilmektedir.
// 
#region Cascade
//Esas tablodan silinen veriyle karşı/bağımlı tabloda bulunan ilişkili verilerin silinmesini sağlar. First Kod yaklaşımında EF COre default bunu ayarlayacaktır.Çoka çok ilişkiler Cascade dışında diğer davRANIŞLARI DESTEKLEMZ.
#endregion
#region SetNull
//Esas tablodan silinen veriyle karşı/bağımlı tabloda bulunan ilişkiLi verilere NULL değerin atanmasını sağlar.
//0ne to One senaryolarda eğer ki Foreign key ve Primary key kolonları aynı ise o zaman SetNull davranışını KULLANAMAYIZ!
// İlgili Entity de foreignkey olan propertyy'i Nullable (?) ile işaretletmek gerekiyor.Yapılan Bu değişikler migrate edilmelidir.
//modelBuilder.Entity<Address>()
//           .HasOne(p => p.Person)
//           .WithOne(p => p.Address)
//           .HasForeignKey<Address>(p => p.Id);
////.OnDelete(DeleteBehavior.SetNull) SetNull birebir ilişkilerde kullanılmaz çünkü PK ve FK ler aynı kolona tanımlıdır

//modelBuilder.Entity<Blog>()
//    .HasMany(b => b.Posts)
//    .WithOne(b => b.Blog)
//    .HasForeignKey(p => p.BlogId)
//    .IsRequired(false)
//    .OnDelete(DeleteBehavior.SetNull);
#endregion
#region Restrict
//Esas tablodan herhangi bir veri silinmeye çalışıldığında o veriye karşılık dependent table 'da ilişkisel veri(ler) varsa eğer bu sefer bu silme işlemini engellemesini sağlar .
//modelBuilder.Entity<Blog>()
//       .HasMany(b => b.Posts)
//       .WithOne(b => b.Blog)
//       .HasForeignKey(p => p.BlogId)
//       .IsRequired(false)
//       .OnDelete(DeleteBehavior.Restrict);
#endregion
#endregion

#region Saving
//Person person = new()
//{
//    PersonName = "Zehra",
//    Address = new() { AddressName = "Yakutiye/Erzurum" }
//};
//Person person1 = new() { PersonName = "Oğuzhan", Address = new() { AddressName = "Keçiören/Ankara" } };
//await context.AddRangeAsync(person, person1);
//await context.SaveChangesAsync();

#endregion