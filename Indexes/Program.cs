using Microsoft.EntityFrameworkCore;

#region Index Nedir?
// Index, bir sütuna dayalı sorgulamaları daha verimli ve performanslı hale getirmek için kullanılan yapıdır.
#endregion

#region Index'leme Nasıl Yapılır? 
// PK, FK ve ARI olan kolonlar otomatik olarak indexlenir.
#region Index Attribute'u

#endregion
#region HasIndex Metodu

#endregion
#endregion

#region Composite Index
//Composite ile birden fazla index tanımlama aynı şey değildir. Composite'te örenğin iki kolon varsa iki kolonun filtre şartına göre araam yapılır. eğer aynı anda iki kolon üzerinde bir filtrleme yapılamayacaksa composite gerek yoktur.
#endregion

#region Birden Fazla Index Tanımlama

#endregion

#region Index Uniqueness
//Bir  index defalut hali mükerredir. bunu Unique hale getşrmek opsiyoneldir.
#endregion

#region Index Sort Order - Sıralama Düzeni
//default olarak ascending olup küçükten büyüğe doğru sıralma yapar. 
#region AllDescending - Attribute
// Tüm indexLemeIerde descending davranışının bütünsel olarak konfigürasyonunu sağlar.
#endregion
#region IsDescending - Attribute 
// Indexleme sürecindeki her bir kolona göre sıralama davranışını hususi ayarlamak istiyorsak kullanılır.
#endregion
#region IsDescending -  Metodu

#endregion
#endregion

#region Index Name
//Name attiribute - HasDatabaseName metodu
#endregion

#region Index Filter
#region HasFilter Metodu

#endregion
#endregion

#region Included Columns
#region IncludeProperties Metodu

#endregion
#endregion


Console.WriteLine("Hello, World!");

//[Index(nameof(Name))]
//[Index(nameof(Name),nameof(Surname))]
//[Index(nameof(Surname))]    
//[Index(nameof(Name),IsUnique =true)]
//[Index(nameof(Name),AllDescending =true)]
//[Index(nameof(Name),nameof(Surname),IsDescending = new[] {true,false})]
//[Index(nameof(Name),Name ="name_index")]

public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Salary { get; set; }
}

public class ApplicationDbContext:DbContext
{
    public DbSet<Employee> Employees { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\local;Database=IndexesDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Employee>()
        //     //.HasIndex(e => e.Name);
        //     //.HasIndex(e => new { e.Name, e.Surname });
        //     //.HasIndex(nameof(Employee.Name), nameof(Employee.Surname)); //Üst satırla aynı kapıya çıkar
        //     .HasIndex(e => e.Name)
        //     .IsUnique();

        //modelBuilder.Entity<Employee>()
        //    .HasIndex(e => e.Name)
        //    .IsDescending();
        //modelBuilder.Entity<Employee>()
        //    .HasIndex(e => e.Name)
        //    .IsDescending(false);
        //modelBuilder.Entity<Employee>()
        //    .HasIndex(e => new {e.Name,e.Surname})
        //    .IsDescending(true,false);

        //modelBuilder.Entity<Employee>()
        //    .HasIndex(e => e.Name)
        //    .HasDatabaseName("name_index");

        //modelBuilder.Entity<Employee>()
        //    .HasIndex(e => e.Name)
        //    .HasFilter("[NAME] IS NOT NULL");

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Name)
            .IncludeProperties(e => e.Surname);
    }
}