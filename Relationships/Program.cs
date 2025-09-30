// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Relationships(ilişkiler) Terimleri
#region Principal Entity(AsıL Entity)
//Kendi başına var olabilen tabloyu modelleyen entity'e denir.
// Depertmanlar ve Çalışanlar ilişkili tablosunda ;Departmanlar tablosunu modelleyen 'Departman ' entity ' sidir.
#endregion
#region Dependent Entity(Bağım11 Entity)
// Kendi başına var olamayan, bir başka tabloya bağımlı (ilişkisel olarak bğaımll) olan tabloyu modelleyen entity'e denir.
//Ca1isan1ar tablosunu modelleyen 'Calisan' entity' sidir.
#endregion

#region Foreign Key
// PrincipaL Entity ile Dependent Entity arasındaki ilişkiyi sağlayan key'dir.
//Dependent Entity'de tanımlanır.
//PrincipaL Entity'de ki Principal Key'i tutar.
#endregion

#region Principal Key
// Principal Entity'deki id'nin kendisidir. Principal Entity nin kimliği olan kolonu ifade eden propertydir.
#endregion
#endregion

public class Calisan
{
    public int Id { get; set; }
    public string CalisanAdi { get; set; }
    public int DepertmanId { get; set; }

    public Depertman Depertman { get; set; }
}

public class Depertman
{
    public int Id { get; set; }
    public string DepertmanAdi { get; set; }

    public ICollection<Calisan> Calisanlar { get; set; }

}

#region Navigation Property Nedir?
// İlişkisel tablolar arasındaki fiziksel erişimi entity class 'ları üzerinden sağlayan property ' lerdir.
//Bir property'nin navigation property olabilmesi için kesinlikle entity türünden olması gerekiyor.
// Navigation property er entity' terdeki tanımlarına göre n 'e n yahut 1'e n şeklinde ilişki türlerini ifade etmektedirler. Sonraki derslerinizde ilişkisel yapıları tam teferruatlı pratikte incelerken navigation proeprty' terin bu özelliklerinden istifade ettiğimizi göreceksiniz.
#endregion

#region İlişki Türleri
#region One To One
//Birebir ilişki
#endregion
#region One To Many
//Bire çok İlişki
#endregion
#region Many To Many
//Çoka çok ilişki
#endregion
#endregion