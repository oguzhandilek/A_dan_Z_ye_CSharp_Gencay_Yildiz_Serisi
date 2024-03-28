using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace A_dan_Z_ye_CSharp_Gencay_Yildiz_Serisi
{
    internal class DersNotlari
    {
        #region .Net'e giriş
        //.NET Framework ve .NET Core arasındaki Fark nedir?
        // .NET Framework sadece windows uygulamalarında çalışır 
        // Core ise daha evrensel Linux vs. tabanları desteker
        #endregion

        #region CLI Nedir?
        //Dotnet CLI Nedir?
        // Command Line Interface, .Net Komut satır arayüzüdür.
        //.Net Uygulamalarını geliştirmeyi, oluşturmayı, çalıştırmayı, yayınlamayı sağlar
        // Temel Komutlar
        // help, new , restore, build, publish, run
        #endregion

        #region todo özelliği

        //todo todo yorum satırlarını kolay bir şekildebulmamızı sağlar. yorum slaşlarından sonra todo yazılır ve yorum yazılrır
        //todo View menüsünden Task List penceresinden görütülenir


        #endregion

        #region Debugging
        //Hata ayıklama işlemini sağlar
        // breakpoint'i devam ettirmek için f10'u kullanırız.
        //hata ayıklamada değişikenleri daha rahat takip etmek için debug esnasında ilgili değişkeninin üstüne sağ tıkayıp
        // Add Watch dememiz yeterli

        #endregion

        #region Değişkenler
        //Value Type (Değer tipler)
        //Primitive Type (İlkel Tipler) -- byte Örnek byte'lardan meydana gelen decimal primitive değiildir. 
        //bir şeyden türetilmemiş olacak
        //Console.WriteLine(typeof(decimal).IsPrimitive); değişken,n primitive lu olmadığını anlamak için

        //Değer türü değişkenler ve Metotlar  RAM'in Stack'inde tutulur
        //Refrans tip veya nesneler değişkenler Heap'te tutulur

        //todo İsimlendirme Kuralları
        // PascalCase
        //camelCase
        //snake_case

        // değişken isimlerini neden @ operatörü ile tanımlamarız?
        // Keywordeleri değişken olarak yazmak için başına @ getirilir. Örn. @static ve string @namespace

        // float, double ve decimal ile ondalıklı değer atamalrında sonlarına aşaığdaki gbi harflaer gelmeli
        //float x = 3.14f;
        //double y = 3.14d;
        //double yy = 3.14; //ondalık değerlerde default double'dir dolayısıyla d ya da D kullanmayabilirsin. Tür dönüşümleri istisna
        //decimal z = 3.14m;

        //todo Tuple türünde değişken tanımlama ?
        // tek bir syntax üzerinde birden fazla deeğişk. tanm. imkan verir
        // örnek (int a, int b, type c, type d)z;
        // (int a, string b)c=(5,"Zehra");
        // c.a -> a değişkenini çağırır
        // c.b -> b değişkenini çağırır

        //todo c# 7.0 ile gelen Literal özellik 
        //Kompleks sayısal ifadeleri _(alt tire ) ile düzenlemmizi sağlayabiliriz
        // int = 1_000_000;
        // bool x= default; değişkenin default değerini atar

        //todo const 
        //tanımlandığı ana değerini almak zorundadır
        // değişitirlmeyen ve değiştirildiği takdirde compailer tarafından uyarılan sabitlerdir.
        // özünde static'tir. Static değerler uygulama bazlıdır yani evrensel olup her yeden erişime açıktır.
        // const double piSayisi=3.14;

        //dEĞİŞKENLERDE ATAMA
        //todo Shallow Copy
        //Değişkenler arası değer atamalrında değeri üretmek/çoğaltmak//klonlamak yerine var olanı birden fazla
        // referansla işaretleemye dayalı kopyalama yöntemidir.
        //Bellekte birden fazla referansın tek bir veriyi işaret etmesidir
        // Neticede ilgili değer bir değişikiğe uğradığında tüm işaretleyen referanslara bu değişiklik yansıyacaktır

        #endregion

        #region Object
        //Object tüm türelri karşılayan bir türdür. Referans türlü bir değişkendir.
        //Değer türlü değişkenleride karşılayabilir
        //Tüm türeler (değer/referans) objectten türerler.
        //object(string, int, bool, char)

        //todo Boxing nedir?
        //objecte türdeki bir değişkene herhangi bir türdeki değeri göndermektir
        //Veriyi object içinde öz türünde tutmaya denir

        //todo UnBoxing nedir?
        //object içerisindeki veriyi  kendi türünde tekrar elde edebiliriz

        //object türüne atanan değer direk çağrılırsa ötnek bir int türünde sayısal değer atandı geri çağrılduğında 
        //bu object türünde geri gelir. yani matematksel işlem yapamaz.

        //ancak bunu öz tipide almak istediğimizde  Unboxing olarak alabiliriz. Bunu da Cast Operatörür ile yaparız.
        //todo Cast Operatörü -->> oparatör parantezdir() object;
        //Cast operatörü, object olan değişkenni solunda o object'i hangi türe Unboxing etmek istiyorsak parantez hedef türü 
        //bildirilerek kullanlır
        //örenk ;
        //int=5;
        // object b=a,
        //(int)b; Cast operatörü b değişkeni/objesi içerisindeki değeri bana int olarak ve demektir
        #endregion

        #region var Keyword'ü
        //var bir değişken değildir. Bir keywor'tür
        //Tutulacak değerin türüne uygun bir değişken tanımlayabilmek içi kullanılan keyword'tür
        //var keyword'ü kendisine atanan değerin türüne bürünür. Bir tür değildir.
        // Kullanımsebebi farklı diller arasında desteklenmeyen türlerdeki veriler karşılayabilmek için kulamılan ortak bir keyword'tür.
        //var ile compailerre yaptırmak performansı ufakta olsa etkileyebilir.

        //kuraları
        // değişken tanımlandığı anda değeri verilir
        //İlk tanımlamadaki verilen değer sonrasında tür değiştirelemez

        // var-object arasındaki fark?
        //var da atanan değer RAM'in Stack'te tutar
        // object ise boxing yapar
        //var bir keyword iken object bir türdür.


        #endregion

        #region dynamic Keyword'ü
        // Uygulama derlenip çalıştığında ilgili değerin türüne bürünür
        // var derlemde bürünür iken dynamic runtimeda bürünür
        //dynamic keywordü runtime da türü belirler ama kararlı davranmayacaktır.
        //yani türler arası değişkenlikler olabilir. İlk değer int ikinci atadığın değer string olabilir
        //esnek çalşmanı sağlar
        // Kullanım alanları
        // türünü bilmediğiniz uzaktan gelen verileri atamak için kullanılır
        //Uzaktan gelen veriler var ile karşılanamaz. Çünkü tanılandığı anda bürünür. ama dynamic bekler

        #endregion

        #region Parse Metodu
        //todo parse fonksiyonu
        // parse sadece string dataları hedef türe dönüştürürken kullanılır
        // type.Parse(string="123");
        #endregion

        #region Convert Fonksiyonları
        // Herhangi bir türü uygun olan her türe dönüştürebilir.
        //string xx = "3,14";
        //double d=Convert.ToDouble(xx);
        #endregion

        #region Bilinçli Tür Dönüşümü
        // Bu işlemi cast operatörü ile yapabiiriz
        //int x=3000;
        //short y=(short)x;
        //Burada dikkat edilmesi gerekn hsusus alt bir türe dönüşte desteklenen aralığa dikkat edilmesi gerekir yoksa veri akybına neden olı

        //todo checked tür dönüşümünde veri kaybı var mı kontrol eder.
        //kullanımı
        //checked
        // {
        //  int a = 500;
        // byte b = (byte)a;
        // Console.WriteLine(b);
        // }

        //todo unchecked ise veri akybını göz ardı eder. defaulttur
        //unchecked  
        // {
        //  int a = 500;
        // byte b = (byte)a;
        // Console.WriteLine(b);
        // }
        #endregion

        #region Bool türünün sayısal değere dönüşmesi
        //Bool sayısala dönüşürken True 1 olarak Flase 0 olarak dönüşür
        #endregion

        #region Mantıksal Operatörler
        // && ve 
        // || veya
        // ^ ya da operatörü en az bir ve en fazla bir seçenek true olacak şekilde sorgular
        #endregion

        #region Üzerine Ekleme Yığma Operatörleri
        // += --> diğer operatörlerin haricinde string değerleride ekler. i=i+3 ile i+=3 aynıdır
        // -=
        // *=
        // /=
        // %=
        #endregion

        #region ! operatörü
        // !=
        // Console.WriteLine(!(i==j))
        // Console.WriteLine(!true)
        //
        #endregion

        #region Ternary Operatörü
        // Bir değişkene/metoda/property'e değer atarken eğer ki bu değer şarta göre fark edecekse tek satırda
        //yada satır bazlı bu şart kontrolünü yaparak duruma göre

        // değişken=....şart/durum ....?....true.....:......false...
        // geriye dönecek true veya false deki değereler aynı TÜR'de olmalıdır

        // birden fazla condition için semantik yapı
        //  int yas = 25;
        //string sonuc = yas < 25 ? "A" : (yas == 25 ? "B" : "C");

        #endregion

        #region . (Member Access-üye erişim) Operatörü
        //elimizdeki değerin türüne uygun member'larına erişmeyi sağlar
        #endregion

        #region typeof Operatörü
        // türün/değerin type'nı döndürür
        //ileri düzey programlamada reflection da elimizde ki bir türün reflectionına girmek için kullanılır
        //Type t= typeof(int);

        #endregion

        #region default operatörü
        // belitilen türün deafult değerini dödürür
        // sayisal=0
        // bool= false
        // string = null
        //char= \0
        // referans =null

        // Console.Writeline(default(decimal));
        //int a=default;
        //int a2 = default(int); bu ikis aynı şeydir üstteki yeni kullanımdır
        #endregion

        #region is Operatörü
        // Boxing'e tabi tutlmuş bir değerin öz türnü öğrenebilmek/check edebilmek için kullanılır
        // is operatörü denetleme neticesinde durumu bool yani true ya da false olar döndürür
        //object x=true;
        // cw(z is bool);
        //İleri düzeyde if yapılanmasında vd. çok tercih ettiğimiz bir opertör olacak
        // OOP yapılanmasında polimorfizim is operatörü ile kalıtımsal durumardaki nesleri öğreneceğiz
        #endregion

        #region is null ve is not null Operatörü
        //bir değişkenn null olup olmamasını true veya false olarak döndürür
        // sadece null olabilen türlerde kullanılır
        //bunlar Referans türlü değişkenlerde kullanılır Value Type de kullanılamaz
        // string a=null;
        // cw(a is null) --> True döndürür
        // cw(a is not null) --> False döndürür

        #endregion

        #region as Operatörü
        // Cast opr. UnBxing işlemine alternatif üretilmiş bir opr.türdür
        //Türüne uygun dönüşüm zaruri değildir.
        // Uygun tür dönüşümü yoksa null değeri döndürür
        // object x = 123;
        // Type y = x as Type -->kullanım şekli
        // as operatörü değer türlü değişkelnlerle kullanılamaz
        // Referans türlerle çalışır

        #endregion

        #region Type Pattern
        //Boxing işlemine tabi tutulmuş bir değeri ottomatik cast eden bir paterndir veya desendir
        //object x = "Dilek";
        //    if (x is string a) // a değişkeni fi blokonun içinde kullanılır. Dış scopda çağırılsada kullanılamaz
        //    {
        //        Console.WriteLine(a);
        //    }

        #endregion

        #region Constant Pattern
        //Elimizdeki veriyi sabit bir değer ile karşılaştırabilmemizi sağlar
        // Değer türlü değişkenler ve primitive de kullanılabilir
        // Console.WriteLine(a is 5); // Eğer ki is operatörüyle bir değişkenin değerini operatörünün sorumluluğuıyla check
        // edişyorsa işte buna constant pattern denmektedir
        //object x = "Dilek";
        //    if (x is "Oğuzhan")  burada ki si ; == kkomutu ile aynı işelvi görür.
        //    {
        //        Console.WriteLine(x+"Constant Pattern");
        //    }
        //    if (x is string a)
        //    {
        //        Console.WriteLine(a +"Type Pattern");
        //    }

        #endregion

        #region Var Pattern
        //Eldeki veriyi var değişkeni ile elde etmemizi sağlamaktadır.
        //        object x = "Dilek";
        //         

        //if (x is var _x) //burdaki var'ın runtime sürecinde belirlenecektir. Normalde var derleyici de değeri belirlenirken burda runtimeda belirlenir
        //{
        //    Console.WriteLine(_x + " var pattern");
        //}

        //Kritik not 

        //bool result = x is var o;  değer runtimeda bürüneceği için derleyicide hata vermez
        //bool result2 = x is string o2; değerin string olamama ihtimalinden dolayı bu kullanım hata verir

        //Console.WriteLine(o);
        //    Console.WriteLine(o2);
        #endregion

        #region Recursive Pattern
        //switch bloğunda referans türlü değişkenlerde kontrol edilebilmektedir
        //Tür kontrolü yaptığı içn  Type Pattern'i kapsamaktadır
        // case null komutu ile referans'ın null olu olmadığını konrtol edebilmesinde dolayı Constant Pattern'ıda kapsar

        #endregion

        #region Simple Type Pattern
        //Bir değişken içerisindeki değerin belirli bir  türde olup olmadığını hızlı bir şekilde
        // kontrol etmemizi sağlayan desendir. Type Patternden farkı değişken isimlerinin zorunluluğunu kaldırmştır
        #endregion

        #region Relational Patterns
        // Switch Desenlerde ve operatörleri kullanılabilmekte ve belirli karşılaştırmalar hızlıca
        //gerçekleştirilebilmektedir.
        //        int number= 111;
        //        string result= number switch
        //< 50 => "50 'den küçük",
        //>50 => "50 'den büyük",
        // 50 => "50'ye eşit"
        //_ => "Hiçbiri"
        #endregion

        #region Logical Pattern
        // and or ve not gibi mantıksal operatörler kullanılabilmektedir
        // Relational Pattern ile oldukça  uyumludur.
        //        int number= 111;
        //        string result= number switch
        //< 50 or > 50  => "50 'den küçük",
        //>50 and < 50 => "50 'den büyük",
        // 50 => "50'ye eşit"
        //_ => "Hiçbiri"
        #endregion

        #region Not Patterns
        // switch deseninde not operatörünün kullanılabildiği bir desendir.

        //        string GetProduct(IProduct p) p switch
        //Technologic "Teknolojik",
        //Computer "Bilgisayar",
        //not Goggles "Gözlük"
        #endregion

        #region Hata Kontrol Mekanizmaları
        // try-catch yapılanmasında Hata Parametreleri
        //          try
        //        {
        //            int s1 = 0, s2 = 10;
        //    int a = s2 / s1;
        //}
        //        catch (Exception firlatilanHata) when (3==3) //Bu tanımlama yapılırsa hataya dair bilgi alınabilir // when ile de kullanılabilir
        //        {

        //            Console.WriteLine("Mesaj :"+firlatilanHata.Message);
        //        }
        //      finally //zoronlu değil
        //     {
        //          Her iki durumda da çalışmasını istediğimiz dolar buraya
        //     }

        #endregion

        #region Yardımcı manevratik Komutlar
        // goto komutu
        // örn :
        //while (true)
        //   {
        // a:
        //       if (DateTime.Now.Second % 5 == 0)
        //       {
        // goto a; // a: akış koyduğum yere gider
        //           Console.WriteLine(DateTime.Now);
        //       }
        //}
        #endregion
        #region Sonsuz döngüler
        // for (; ;); 
        // while (ture);  bu haliyle yani scopsuzz olarak bu halde yazıp sonuna nokatılı virgül yapınca sonsuz döngüye girer
        //asenkron programlamada kullanıldığı noktalar olabilir
        #endregion

        #region String Değişkeninde Null - Empty Durumları, Farkları
        #region Null
        //Bir değişken/nullable/referans eğer ki null alıyorsa bu durum ilgili değişkenin herhangi bir alanı tahsis etmediği anlamına gelir.
        //Arsa yok!
        #endregion
        #region Empty
        //Bir değişken/nullable/referans eğer ki empty ise bu değişkenin değeri yok anlamına gelir.Lakin alan tahsisinde bulunulmuştur.

        //ARsa var lakin ev yok!]
        #endregion
        #endregion
        #region IsNullOrEmpty Fonksiyonu
        //todo IsNullOrEmpty fonksiyonu;
        //elimizdeki string ifadenin null yahut empty Olup olmama durumları hakkında bir check yapar ve geriye bool türde sonuç döner.
        //Eğer ki değer null ya da empty ise geriye true değilse false dönecektir.
        //string x = "";
        //    if (!string.IsNullOrEmpty(x))
        //    {

        //    }
        #endregion

        #region IsNullWhiteSpace
        //todo IsnNullOrWhiteSapce fonksiyonu;
        // elimizdeki string ifadenin null, empty veya boşluk olam durumumdunda geriye true değerini döndüren
        //bir fonksiyondur
        //string x = "  ";
        //    if (!string.IsNullWhiteSpace(x))
        //    {

        //    }
        #endregion

        #region String Formatlandırma
        //todo string.Format fonksiyonu;
        // metinsel kalibİn İcerİsİndekİ İndexsel bleirlenen noktalara sirasİyIa deger gondermemİzİ saglayan
        // bir fonksiyondur
        //string isim = "Zehra", soyisim = "Dilek", tcNo = "21323484";
        //int yas = 20;
        //bool medenihal = false;
        //Console.WriteLine(string.Format("TC No: {0} olan {1} {2} şahsın bilgileri | Yaş: {3} | Medeni Hal : {4}"

        //    , tcNo, isim, soyisim, yas, medenihal? "Evli" : "Bekar"));

        //todo string interpolation operatörü 
        // string ifadenin içerisinde süslü parantez ile araya girerek değişkeni eklemeizi sağlar
        // $ operatörünü bir string değerin başına koyulursa strin içindeki {}süslü parantezler bir interpolation özelliği sergiler
        //string isim = "Zehra", soyisim = "Dilek", tcNo = "21323484";
        //int yas = 20;
        //bool medenihal = false;
        //Console.WriteLine(string.Format($"TC No: {tcNo}" +
        //        $" olan {isim} {soyisim} şahsın bilgileri" +
        //        $" | Yaş: {yas} | Medeni Hal : " +
        //        $"{(medenihal? "Evli": "Bekar")}"));


        #endregion

        #region verbatim @ operatörü
        //todo @ verbatim operatörünü kaçış karakteri olarak kullanabiiriz
        //  string metin = @"hava çok""güzel""";
        //  Escape karakterlerinin kullanilmasi icap eden durumlarda @ operatorunu kullanarak eylemsel karakterleri kendileriyle
        //ezebilecek ozellik kazandirabiliyoruz...l

        //bir diğer kullanım alanı da string ifadeeri satır satır yazmak istenilince aray + oepratörü koymadan yazmaya ayara
        //        string ifade = @"XXXXXXX xxxxx
        //xxxxxxxxxxxxxxx xxxxxxxxxxxxxx xxxxxxxx";

        //todo verbaetim @ ve string interpolation $ aynı anda kullanımında önce verabtim @ sonra interpolation $ yazılır
        // string ifade = @$" Merhaba {isim} ....." gibi
        #endregion

        #region String Fonksiyonalrı
        #region Contains Fonk
        //string metin = " Deneme şansını bende deneme";
        //bool result = metin.Contains("deneme");
        //Console.WriteLine(result); //büyük küçük harf duyarlıdır. küçük harfle başalayan deneme yi abz alarak true değeri döndürür
        #endregion
        #region StarsWith
        //string metin = " Deneme şansını bende deneme";
        //bool result = metin.StartsWith("Deneme");
        //Console.WriteLine(result); Metnin iligili değer ile başalyıp başlamadığını döndürür
        #endregion
        #region EntsWith
        //string metin = " Deneme şansını bende deneme";
        //bool result = metin.EndsWith("deneme"); meti verilen son değer ie bitiyor muyu kontrol eder
        //Console.WriteLine(result);
        #endregion
        #region Equals 
        //Elimİzdkewİ metinsel İfade İle herehangİ bir İfaedenİn değersel olarka eşit Olup olamasınl check eden ve geriye bool sonuç dönen bir fonk.
        //   string metin = "Deneme şansını bende deneme";
        //bool result = metin.Equals("Deneme şansını bende deneme"); Büyük küçük harf duyarlılığı var
        //Console.WriteLine(result);
        #endregion
        #region Compare 
        //Metinsel ifadeleri karşılaştırmamızı ve sonuç olarak int türde değer elde etmemiz isağlayari.
        //0 : Her iki değer birbirine eşittir.
        // 1 : Soldaki sağdakinden alfanumerik olarak büyük
        //-1 : soldaki sağdakinden alfanumerik olarak küçük

        //string metin = "Deneme şansını bende deneme";
        //Console.WriteLine(string.Compare(metin,"Z"));
        #endregion
        #region CompareTo
        //string metin = "Deneme şansını bende deneme";

        //Console.WriteLine(string.Compare(metin,"Z"));
        //    Console.WriteLine(metin.CompareTo("Z")); aynı mantık ama kullanımı burda olduğu gibi farklı
        #endregion

        #region IndexOf
        //verilen değerin string ifade içerisinde Olup olmamasını geriye İnt döndüren bir fonksiyondur.
        //geriye int olarak indexNoyu döndürür.
        //eğer der yoksa  -1 değerini döndürür.
        // Indexof İlk eşleşen değerin İndexinİ döndürür.
        //string metin = "Deneme şansını bende deneme";
        //Console.WriteLine(metin.IndexOf("bende"));
        #endregion

        #region Insert
        //EIimizdeki metinsel ifadeye bir değer dahil etmemizi/eklememizi sağlayan bir fonksiyondur.
        //string metin = "Deneme şansını bende deneme";
        // Console.WriteLine(metin.Insert(5, "ata")); string olarak return olur orjinali aynı kalır.
        #endregion

        #region Remove
        //Metinsel ifadede indexel olarak verilen değer aralığını silen bir fonksiyondur.
        //  Console.WriteLine( metin.Remove(5)); 5. indexten sonraki tüm değerleri sil.
        // Console.WriteLine(metin.Remove(5,10)); 5. indexten başla 10 adet sil.
        #endregion
        #region Replace
        // Elimizdeki metinsel ifadede belirtilen değerleri yahut karakterleri, belirtilen diğer değerler ya da karakterler ile değiştirmemizi sağlayan bir
        //fonksiyondur.
        //string metin = "Deneme şansını bende deneme";
        //Console.WriteLine(metin.Replace('a','b'));
        //    Console.WriteLine(metin.Replace("şansısnı","kendini"));
        #endregion
        #region Split
        //Metinsel ifadeyi verilen değeri ayraç olarak kullanıp, parçalayan ve sonucu string dizisi olarak döndüren bir fonsiyondur.
        //string metin = "Deneme şansını bende deneme";
        //string[] result = metin.Split(' ');
        //string[] sonuc = metin.Split(' ', 'a');
        #endregion
        #region Substring //Çok Önemli Bir Fonk
        //Metinsel ifadenin belirli bir aralığını elde etmemizi sağlar.
        //string metin = "Deneme şansını bende deneme";
        //Console.WriteLine(metin.Substring(5)); // 5. indexten sonuna kadar tüm' egerleri getir.

        //Console.WriteLine(metin.Substring(5,5)); //5. indexten başlayacak 10 karakter getirecektir.

        #endregion
        #region ToLower
        //Eldeki metinsel ifadenin tüm karaktelrerini küçük karakter olarak düzenler.
        //string metin = "Deneme şansını bende deneme";
        //Console.WriteLine(metin.ToLower());
        #endregion
        #region ToUpper
        //Eldeki metinsel ifadenin tüm karaktelrerini büyük karakter olarak düzenler.
        //string metin = "Deneme şansını bende deneme";
        //Console.WriteLine(metin.ToUpper());
        #endregion
        #region Trim
        //Metinsel ifadelerin varsa solundaki ve sağındaki boşluk karkatelrini temizleyen bir fonksiyondur.
        //string metin = "  Zehra  ";
        //string result = metin.Trim();
        //Console.WriteLine(result);
        #endregion
        #region TrimEnd
        //sağdaki yani sonda ki boşluğu siler
        //string metin = "  Zehra  ";
        //string result = metin.TrimEnd();
        //Console.WriteLine(result);
        #endregion
        #region TrimStart
        //soldaki yani baştaki ki boşluğu siler
        //string metin = "  Zehra  ";
        //string result = metin.TrimStart();
        //Console.WriteLine(result);
        #endregion
        #endregion

        #region ArraySegment
        //ArraySegment ile Dızının Bel1i Bır Alanını Referans Etme

        //int[] sayilar = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        //ArraySegment<int> segment1 = new ArraySegment<int>(sayilar);
        //ArraySegment<int> segment2 = new ArraySegment<int>(sayilar, 2, 5);
        //Console.WriteLine($"ilk değer: {segment1.Array[segment1.Offset]}");
        //    segment1.Array[segment1.Offset] *= 10;
        //    Console.WriteLine($"değiştirlen değer: {segment1.Array[segment1.Offset]}");
        //    segment2.Array[segment2.Offset + 1] *= 10;
        //    Console.WriteLine($"segment2 değişen değer: {segment2.Array[segment2.Offset+1]}");

        #region ArraySegment Slicing (Dilimleme)
        //Bir dizi üzerinde birden fazla parçada çalışacaksan eğer herbir parçayı ayrı bir ArraySegment
        //olarak tanımlayabiliriz.Bu tanımlamaların dışında diziyi tek bir arraysegment ile referans edip
        //ilgili parçaları o segment üzerinden talep edebiliriz. Yani ilgili diziyi tek bir segment
        //üzerinden daha rahat bir şekilde parçalayasbiliriz. Bu durumda bize yazılımsal açıdan efektiflik
        //kazandırmış olacaktır.

        #endregion
        #endregion

        #region StringSegment
        //StringSegment, ArraySegment'in string değerler nezdindeki bir muadilidir.
        //Esasında metinsel değerlerideki birçok analitik operasyonlardan bizleri kurtarmakta ve Substring
        //vs.gibi fonksiyonlar yerine string değerde hedef kesit üzerinde İşlem yapmamızı sağlayan bir
        //türdür.

        //StringSegment türünü kullanabilmek için uygulamaya Microsoft. Extensions.primitives paketinin
        //yüklenmnesi gerekmektedir.


        //string text = "Ölüme gidelim dedin de mazot mu yok dedik. ";
        //StringSegment segment = new StringSegment(text);
        //StringSegment segment1 = new StringSegment(text, 2, 5);
        //Console.WriteLine(segment1);
        #endregion

        #region StringBuilder Sınıfı
        //// StringBui1der, string birleştirme operasyonlarında + operatörüne nazaran yüksek maliyeti absorbe
        //edebilmek için arkaplanda StringSegment algoritmasını kullanan ve bu algoritma ile bizlere
        //ilgili değerleri olabilecek ennn az maliyetle birleştirip döndüren bir sınıftır.

        //string isim = "Zehra", soyisim = "Diek";
        //StringBuilder builder = new StringBuilder();
        //builder.Append(isim);
        //    builder.Append(" ");
        //    builder.Append(soyisim);
        //    Console.WriteLine(builder.ToString());
        #endregion

        #region Span Türü
        // Bellek üzerinde belirli bir alan temsil ederek işlemler gerçekleştirmemizi sağlayan bir struct'tır.
        //Bu belirli alanlardan kasıt tabi ki de ardışıl alan kaplayan Array  değerleridir.
        // Normal şartlarda  Arraflerin belleğin HEAP kısmında tutulduğunu biliyoruz. Lakin stackalloc keyword'ü
        //sayesinde STACKlte de Array tanımlayabilmekteyiz.

        //Span, stack yahut heap   farketmeksizin tanımlanmış olan Array'lerin tümünü yahut bir bölümünü bizler
        //için refere edebilen ve üzerinde işlem gerçekleştirebimemizi sağlayan kullanışlı bir türdür,

        //todo ReadOnlySpan<T> nedir?
        // Span niteliklerinin tümünü sağlamakta lakin adı üzerinde sadece okunabilir kılmaktadır.

        //todo Span ile ArraySegment & StringSegment Farkı Nedir?
        //ArraySegment sadece string ve dizilerde temsiliyet yapabiliyorken, Span bellek  üzerinde olan herhangi bir yeri temsil edebilir.
        //ArraySegmentlte referans edilen alana hertürlü müdahale edilebilirken, ReadOnIySpanlda bu verişel operasyonlar engellenebilir ve sadece okunabilir bir
        //davranış sergilenebilir.
        //Sadece string yahut array türler ile çalışılacaksa eğer ArraySegment ve StringSegment tavsiye edilir.

        //Örnek
        // int[] sayilar = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        // Span<int> span = new Span<int>(sayilar);
        // Span<int> span2 = sayilar; //üsteki ile aynı referansı veriri
        // Span<int> span3 = new Span<int>(sayilar, 3, 5);

        // Span<int> span4=sayilar.AsSpan(); //San türünde br nesne döndürürür //Yukarıda ki yöntemle aynı işlevi gören farklı bir yordamdır
        //Span<int> span5= sayilar.AsSpan(3, 5); // döndürülen nesnnenin belirli aralığını refere eder


        // string text = "Sen kalbimde batan güneş, ben yollarda çilekeş...";
        // ReadOnlySpan<char> readOnlySpan = text.AsSpan(); //Kritik strig türelerde refere edilince ReadOnlySpan döndürür


        #endregion

        #region Memory Türü
        //todo Memory Türü Nedir
        //Span ref struct olarak tasarlanmış bir structltır.
        //Dolayısıyla Heaplte allocation(tahsis) edilememe, object, dynamic yahut interface
        //türleri aracılığıyla referans edilememe yahut bir class içerisinde field veya property
        //olarak tanımlanamama gibi kısıtlamaları vardır.
        //Memory türü Spanlın bu kısıtlamalarından münezzeh versiyonudur.
        // ReadOnlyMemory memory'nini sadece okunabilen bir türüdür.

        #endregion

        #region Regular Expressions (Düzenli İfadelerde)
        ////Metinsel yapılanmalarda belirli koşulları sağlayabilen ifadelerdir.
        ////Metinsel ifade içerisinde ihtiyaca istinaden düzenlenirler.
        //Örenk;
        //Bir metinsel ifade içerisinde @ karakteri geçen bütün aralıkları elde etmek istediğimizi varsayalım.
        //baasdseda@asm 1 23 1232'dkasd@dIqvgödq213'asdasdwd
        //Dikkat ederseniz bu değerlerdeki karakterlerin uzunluğu ve ne olduğu önemli değil. Yeter ki @
        //karakteri olsun.
        //Her email adresi mutlaka @ ve ardından .(nokta) karakteri barındırır. Eğer birden fazla nokta varsa,
        //noktalardan biri mutlaka @ karakterinden sonra olmalıdır.
        //gencay.yildiz @sebepsizbosyereayrilacaksan com
        //Haliyle bir karakter dizisinin email adresi olup olmadığını test etmek oldukça zor olacaktır.

        //todo Regex
        //Bu yüzden C#'ta bu tür düzenli ifadeleri temsil edebilmek için Regular Expressions operatörleri
        //geliştirilmiştir.
        // Bu operatörler eşliğinde elde edilen verinin tasarlanan metinsel düzene uyup uymadığı
        //değerlendirilebilmektedir.
        // Regular ifadeler System.Text.RegularExpressions namespace'i altındaki Regex sınıfı tarafından
        //temsil edilmektedir.
        //Regular Expressions'lar ufak tefek farklılık olsa dahi hemen hemen tüm programlama
        //dillerinde olan evrensel yapılanmalardır.



        #endregion

        #region Regular Expression Operatörleri
        #region ^ Operatörü
        //todo Regex ^ Operatörü: Satır başının istenilen ifadeyle başlamasını sağlar.
        //string text = "92111kasdbkafkbvbbsdl";
        //Regex regex = new Regex("^9");
        //Match match = regex.Match(text);
        //Console.WriteLine(match.Success);
        #endregion
        #region \ Operatörü
        // todo Regex \ Operatörü
        // \ : Belirli karakter gruplarını içermesini istiyorsak kullanırız.
        // \D : Metinsel değerin ilgili yerinde rakam olmayan tek bir karakterin bulunması gerektiği belirtilir.
        // \d : Metinsel değerin ilgili yerinde 0 - 9 arasında tek bir sayı olacağı ifade edilir.
        // \W : Metinsel değerin ilgili yerinde alfanümerik olmayan karakterin olması gerektiği belirtilir. Alfanümerik
        //karakterler  :  a-z A-Z 0-9
        // \w : Metinsel değerin ilgili yerinde alfanümerik olan karakterin olacağı ifade edilir.
        // \S : Metinsel değerin ilgili yerinde boşluk karakterleri(tab/space) Işında herhangi bir karakterin olamayacağı belirtilir
        // \s : Metinsel değerin ilgili yerinde sadece boşluk karakterinin olacağı ifade edilir.

        //Orn;
        //9 ile başlayan, ikinci karakteri herhangi bir sayı olan ve son karakteri de boşluk olmayan bir düzenli ifade
        //oluşturalım.
        // ^9\d\S
        //string text = "92111kasdbkafkbvbbsdl";
        //Regex regex = new Regex(@"^9\d\S"); ilk 3 karakteri denetler yani 92 1.. olsa idid false ocaktı
        //Match match = regex.Match(text);
        //Console.WriteLine(match.Success);

        #endregion

        #region + Operatörü
        //todo Regex + Operatörü
        ////Be1irti1en gruptaki karakterlerden bir ya da daha fazlasının olmasını istiyorsak kullanılır
        /////Örn;
        /////9 ile başlayan, arada herhangi bir sayısal değerleril olan ve son karakteri de boşluklolmayan bir düzenli ifade
        //oluşturalım.
        // ^9\d+\S
        #endregion

        #region | Operatörü
        //todo RegEx | Operatörü
        //Birden fazla karakter grubundan bir ya da birkaçının ilgili yerde olabileceğini belirtmek istiyorsak mantıksal
        //veya operatörü kullanılır.
        //Örn;
        //Baş harfi a ya da b ya da c olan metinsel ifadeyi girelim.
        //alblc
        //string text = "ahmet";
        //Regex regex = new Regex(@"a|b|c");
        //Match match = regex.Match(text);
        //Console.WriteLine(match.Success);

        #endregion

        #region {n} Operatörü
        // Sabit sayıda karakterin olması isteniyorsa (adet) şeklinde belirtilmeli.
        //507-7514592 cce tel formatını doğrulayalım
        // \d\d\d-\d\d\d\d\d\d bu da bir yöntem ama daha efektif alttaki
        // \d{3}-\d{6}
        #endregion

        #region ? Operatörü
        ////Bu karakterin önüne gelen karakter en fazla bir en az sıfır defa olabilmektedir.
        ///\d{3}B?A --> 234BA, 543BA, 543A bu değerler true döner ama 123BBA false döner
        #endregion

        #region . Operatörü
        // Kullanıldığı yerde \n karakteri dışında herhangi bir karakter bulunabilir.
        //\d{3}.A 
        #endregion

        #region \b \B Operatörü
        // \B: Bu ifade ile kelimenin başında ya da sonunda olmaması gereken karakterler bildirilir.
        // \b: Bu ifade ilgili kelimenin belirtilen karakter dizisi ile sonlanmasını sağlar.
        // Örn;
        // \d{3}dır\B --> 123dır, dır123 false ama 123dır2 true


        #endregion

        #region [n] Operatörü
        // [n] : Karakter aralığı belirtilebilir.
        //Ayrıca özel karakterlerin yerinde yazılmasınıda ifade eder.
        //Örn;
        // \d{3}[A-E]  123A,123D,123E true ama 123P false döner
        //Örn2;
        //(507) 751 45 92
        // [(]\d{3}[)]\s\d{2}\s\d{2} paarntezleri ve boşlukarı doğru yerde yazdırdık

        #endregion
        #region Regex Match Sınıfı Özellikleri
        //Console.WriteLine(match.Success); doğrulamamını true yada false değerini döndürür
        //    Console.WriteLine(match.Value); doğrulamının yapıldığı değeri verir
        //    Console.WriteLine(match.Index); doğrulamanın başlangıç değerini döner
        //    Console.WriteLine(match.Length); doğrulama yaılacak karakterlerin adetini döner

        #endregion
        #endregion

        #region Koleksiyonlar
        //todo Koleksiyonlar
        #region ArrayList Koleksiyonu
        //todo ArrayList Koleksiyonu
        //Koleksiyonların ilkidir. 
        #region ArrayList Tanımlama
        //  int[] yaslar=new int[4]; //Dizi
        //ArrayList _yaslar = new ArrayList(); //Koleksiyon
        #endregion
        #region Tanımlanmış Koleksiyona Değer Atama
        //yaslar[0] = 1; // diziye değer atama

        //    _yaslar.Add(1);
        //    _yaslar.Add("Ahmet"); //object türünde değer alıp Boxing yapar
        #endregion
        #region Tanımlanmış Koleksiyondan Değer Okuma

        #endregion

        #endregion
        #endregion
    }
}
