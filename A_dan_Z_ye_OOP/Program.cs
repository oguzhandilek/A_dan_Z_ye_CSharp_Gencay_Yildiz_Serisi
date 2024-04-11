
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

OOPDersNotlari.ClassİcindeClass classİcindeClass=new OOPDersNotlari.ClassİcindeClass(); //Class içinde tanımlanan Class için nesne oluşturma

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

Console.ReadLine();