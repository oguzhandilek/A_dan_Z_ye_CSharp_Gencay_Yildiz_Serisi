
using A_dan_Z_ye_OOP;

OOPDersNotlari dersNotlari = new OOPDersNotlari();
//dersNotlari.a = 10;
//OOPDersNotlari dersNotlari2= new OOPDersNotlari();
//dersNotlari2.a = 20;
//Console.WriteLine(dersNotlari.a + " "+ dersNotlari2.a);

Console.WriteLine(dersNotlari.Yasi);
dersNotlari.Yasi = 65;
Console.WriteLine(dersNotlari.Yasi);
dersNotlari[5] = 10; //Indexer örnek kodunun devamı

OOPDersNotlari.ClassİcindeClass classİcindeClass = new OOPDersNotlari.ClassİcindeClass(); //Class içinde tanımlanan Class için nesne oluşturma

new OOPDersNotlari(); //Referanssız bir nesne
Employee empoloyee1 = new Employee
{
    Name = "Oğuzhan",
    Surname = "Dilek",
    Position = 1
};
Employee employee2 = empoloyee1.With(2);

MyRecord myRecord = new MyRecord
{
    Name = "Oğuzhan",
    Surname = "Dilek",
    Position = 1
};

MyRecord myRecord2 = myRecord with { Position = 2 };

void DestrocturExamp()
{
    ConstructorClass constructorClass = new ConstructorClass();
}
DestrocturExamp();
GC.Collect(); //GarbagaC011ector devreye sokulmuş oldu. Bu müdahale gerekli olmadığı halde tavsiye edilmez

new ConstructorClass(15, 20);

int sayi = 10;
while (sayi >= 1)
{
    new MyClass2(sayi--);
}
Console.WriteLine("+++++++++++++");
GC.Collect();

Person person = new Person
{
    Name = "Zehra",
    Age = 0
};
var (x, y) = person;

new MyClass3();
new MyClass3();

var database1 = Database.GetInstance;
var database2 = Database.GetInstance;
var database3 = Database.GetInstance;
database1.ConnectionString = "Singleton Desing Patern";

MyRecord2 m = new MyRecord2("Record", "Positional");
var (n, s) = m;

D d = new D();
Kalem k= new Kalem();
k.Bilgi();
Terlik t= new Terlik();
t.Bilgi();
Maymun maymun = new Maymun();
maymun.Konus();
Inek i= new Inek();
i.Konus();
Ucgen u = new Ucgen(3, 4);
Console.WriteLine(u.AlanHesapla());

Dortgen dortgen = new Dortgen(3,4);
Console.WriteLine(dortgen.AlanHesapla());

PartialClass partial = new PartialClass();
partial.A();
partial.B();

new MyManager();

Console.ReadLine(); 