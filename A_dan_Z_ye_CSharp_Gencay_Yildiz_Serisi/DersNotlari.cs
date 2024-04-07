using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace A_dan_Z_ye_CSharp_Gencay_Yildiz_Serisi
{
    public class DersNotlari
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

        //todo todo yorum satırlarını kolay bir şekilde bulmamızı sağlar. yorum slaşlarından (//) sonra todo yazılır ve yorum yazılır
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
        //todo@ verbatim operatörünü kaçış karakteri olarak kullanabiiriz
        //  string metin = @"hava çok""güzel""";
        //  Escape karakterlerinin kullanilmasi icap eden durumlarda @ operatorunu kullanarak eylemsel karakterleri kendileriyle
        //ezebilecek ozellik kazandirabiliyoruz...l

        //bir diğer kullanım alanı da string ifadeeri satır satır yazmak istenilince aray + oepratörü koymadan yazmaya ayara
        //        string ifade = @"XXXXXXX xxxxx
        //xxxxxxxxxxxxxxx xxxxxxxxxxxxxx xxxxxxxx";

        //todoverbaetim @ ve string interpolation $ aynı anda kullanımında önce verabtim @ sonra interpolation $ yazılır
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
        //for (int i = 0; i < 17; i++)
        //{
        //    yaslar[i] = i+10;
        //    _yaslar.Add(i+10);
        //}
        //Console.WriteLine(yaslar[5]);
        //Console.WriteLine(_yaslar[5]);
        #endregion
        #region ArrayList Kullanılırken Boxing -UnBoxing Durumları
        //ArrayLİst, verilen datayı boxing işlemine tabi tutuar.
        //ArrayList içerisindeki herhangi bir veriyi talep ettiğimizde o veri object olarak gelecektir. Dolayısıyla kendi
        // türünde işlem yapabilmek için unboxing işlemine tabi tutuannz gerekir.
        //    int toplam = 0;
        //        for (int i = 0; i<_yaslar.Count; i++)
        //        {
        // if (_yaslar[i] is int) eğer değer int ise 
        //            toplam += (int) _yaslar[i]; // () cast operatörü ile unboxing yaptık

        //}

        #endregion

        #region ArrayList Collection InitiaIizers(Koleksiyon İlklendirici) İle Değer Ekleme
        //todo ArrayList Collection InitiaIizers örneği aşağıdaki gibidir
        //ArrayList array = new ArrayList()
        //{
        //    "Zehre",
        //    123,
        //    'a',
        //    true
        //};
        #endregion
        #endregion
        #endregion

        #region İterasyon
        //todo İterasyon Nedir?
        // Mantiksal acidan her tahminin mantigi yatar.
        // Örn: 1 3 5 7 9 .. tek sayıların yazıldığı tahmini
        #region İterasyon ve Döngü
        //Foreach(1terasyon) BİR DOUGÜ DEĞİLDİR!
        #endregion
        #region ForEach İterasyonu
        // foreach (değişken in collection veya dizi)
        //{  }
        //örn;
        //ArrayList array = new ArrayList()
        //{
        //    "Zehra",
        //    123,
        //    'a',
        //    true
        //};

        //foreach(object item in array)
        //{
        //    Console.WriteLine(item);
        //}
        #endregion
        #endregion

        #region C#'da Hazır Sınıf ve Metotlar
        #region Math Sınıfı
        #region Abs Fonksiyonu
        //todo Abs fonk.
        //Mutlak Değer işlemini yapar
        //Absolute Value
        //int i = Math.Abs(-59);
        #endregion
        #region Ceiling Fonksiyonu
        //todo Ceiling Fonk.
        //Ondalıklı değeri tamsayıya yuvarlar. Yukarı doğru yuvaralr 3.14 ->> 4
        //int i = Math.Ceiling(3.14);
        #endregion
        #region Floor 
        //todo Floor Fonk
        ////Ondalıklı değeri tamsayıya yuvarlar. Aşağı doğru yuvaralr 3.14 ->> 3
        //int i = Math.Floor(3.14);
        #endregion
        #region Round Fonksiyonu
        //todo Round Fonk
        ////Ondalıklı değeri en yakın tamsayıya yuvarlar. 3.4 ->> 3 , 3.5 --> 4 , 3.6--> 4
        //int i = Math.Round(3.5);
        #endregion
        #region Pow Fonksiyonu
        //todo Pow Fonk
        ////Üstlü sayılar için kullanılırı . x taban y üst
        //int i = Math.pow(3,5); 3'ün 5. kuvveti
        #endregion
        #region Sqrt Fonksiyonu
        //todo Sqrt Fonk.
        //Karekök için kullanılr
        //Console.WriteLine(Math.Sqrt(4));
        #endregion
        #region Truncate
        //todo Truncate
        // Elindeki ondlık değerin sadece tam sayı değerini elde etmek için kullanılır
        ////Console.WriteLine(Math.Truncate(3.14)); --> 3
        #endregion
        #endregion

        #region DateTime Struct'ı
        #region Now
        // Şimdiki zamamnı milisaniyey kadar döndüren bir property'dir.
        //Console.WriteLine(DateTime.Now);
        #endregion
        #region Today
        //Şimdidki zamanın sadece gün ay yılını getirir
        //Console.WriteLine(DateTime.Today);
        #endregion
        #region Compaire
        //iki tarih aarsında kıayslama yapıp sonucu int döndürür
        //Örn;
        //DateTime tarih1 = new DateTime(2024, 01, 01);
        //DateTime tarih2 = new DateTime(2024, 01, 01);
        //int result = DateTime.Compare(tarih1, tarih2);
        //Console.WriteLine(result>0?$"{tarih1} Büyük":(result==0? $"{tarih1} Eşittir":(result<0? $"{tarih1} Küçüktür":"Hata")));
        #endregion
        #region DateTime - Tarihsel Zamana Saat, Gün, Ay, Yıl Ekleyerek Sonucu Hesaplamak
        //Console.WriteLine(DateTime.Now.AddYears (999 ) ) ;
        #endregion
        #endregion

        #region TimeSpanStruct'ı
        //iki tarih arasında zaman farkını hesaplayan struct'tır
        //DateTime t1=DateTime.Now;
        //DateTime t2= new DateTime(2000,1,1);
        //TimeSpan span =t1-t2;
        //Console.WriteLine(  span.Days);
        //Console.WriteLine(span.Minutes);

        #endregion

        #region Random Sınıfı
        #region Next Fonksiyonu
        //Random rnd = new Random();
        //Console.WriteLine(rnd.Next()); 00 ile integer son sınırına kadar son sınır dahil değil
        //Console.WriteLine(rnd.Next(10)); 0 ile 10'a kadar ama 10 dahil değil
        //Console.WriteLine(rnd.Next(1,10)); 1 ile 10 kadar. 1 dahil ama 10 değil
        #endregion
        #region NextDouble Fonksiyonu
        // 0 ile 1 arasında random sayı üretir
        //Random rnd = new Random();
        //Console.WriteLine(  rnd.NextDouble());
        #endregion
        #endregion


        #endregion

        #region Metotlar
        //Yapılacak işelem göre 4 farklı türde metot oluşturulabilir.
        // Geriye değer döndürmeyen ve parametre almayan 
        // Geriye değer döndürmeyen ve parametre alan
        // Geriye değer döndüren ve parametre almayan 
        // Geriye değer döndüren ve parametre alan

        //Her türlü koşulda metot imzası aşağıdaki gibidir.
        // [Erişim Belirleyicisi(Access Modifier] [geri dönüş değeri] [Metot Adı] ( parametler)
        //{
        //}

        // SOLID Prensipleri gereği bir metot bir iş yapacaktır.
        // Bir yanan toplama yapıp diğer yandan veritabanına ekleme yapan metot doğru değildir
        #region Geriye değer döndürmeyen ve parametre almayan metot
        //Bir metot geriye değer döndürmüyorsa void kullanılır
        public void Metot()
        {
            Console.WriteLine("Geriye değer döndürmeyen paraetre almayan metot oluşturuludu.");
        }
        #endregion
        #region Geriye değer döndürmeyen ve parametre alan metot
        public void Metot(int a)
        {
            Console.WriteLine("");
        }
        #endregion
        #region Geriye değer döndüren ve parametre almayan metot
        //Bir etot herhangi bir türde değer döndüreceğini ifade ediyorsa kesinlikle o türde bir dğer döndürmelidir. Yoksa hata verir.
        //return nerede işlenirse orada ilgili fonksiyondan /mettodan çıkılır. Yazıldığı satır bu anlamda önemlidir.
        public char Metot3()
        {
            return 'A';
            Console.WriteLine("Returnden sonara yazıldığı için console boş kalacak");
        }
        int Metot4() // Erişim belirleyicisi default olarak private'dır
        {
            if (DateTime.Now.Second > 10) // Şart sadece true değeri değil false değerlerinide yazmanız geryor. Aksi halde derleyici hatası alırsınız
            {
                return 5;
            }
            return 1;
        }
        #endregion
        #region Geriye değer döndüren ve parametre alan metot
        public bool Metot5(int x)
        {
            return x == 3 ? true : false; // return brda işlem yapmamıza olanak sağlıyor. Örnektede olduğu gibi ternary opt. ile bir kıyaslama yapıp değer döndürdük

        }
        #endregion
        #region Metodun Geriye Değer Döndürmesi Ne Demektir?
        public int Topla(int sayi1, int sayi2)
        {
            int sonuc = sayi1 + sayi2;
            Console.WriteLine(sonuc); // Geriye değer döndürmek ekrana çıktı vermesi demek değidir!!!
            return sonuc; // Metodun geriye döndürdüğü değer programatik olarak yakalanıp algoritmanın akışında farklı yönlendirme sebebiyet verebilen değerdir.
            //Metodoun döndürdüğü değer algoritmanın akışında farklı amaçlar ile kullanılabilir

        }
        // örnk
        public bool PersonelEkle(string ad, string soyadi, int yas)
        {
            if (yas >= 20)
            {
                //.veritabına eklendi
                return true;
            }
            else
            {

                return false;
            }
        }
        //örneğin devam eden kodou Progam Classs'nın 216. satırında

        #endregion
        #region Optional Parameters (İsteğe Bağlı Parametreler)
        //todo Optional Parameters (İsteğe Bağlı Parametreler)
        //Bir metot eğer parametreli ise o metodun parametrelerine uygun değeri göndermek zorundasın.
        // Eğer bir metodun parametlerine zorunlu bir şekide değer göndermek istmeiyorsak, parametreye
        // değeri isteüimze göre/opsiyonel olarak o parametrenin bu durumu karsilayabilecek
        // bir ozellikte olmasi gerekmektedir.İste bu ozellgide opsiyonel parametreler denmektedir.
        // Bir parametrenin opsiyonel olmasi demek 0 parametrenin varsayilan/default degeri olmasi demektir...

        static public void X(int a, int x, int y, int b = 0, int c = 5)
        // Metot parametrelerine (assign) ile bir deger atanirsa eger 0 parametreye varsayilan
        //degerİ atanmİs olur.Haliyle opsiyonel parametre haline getirilmiş olunur...
        {

        }
        static void Y()
        {
            X(5, 6, 7, 8);
            X(5, 6, 7);
        }
        #region Kritik
        // Tüm parametreler opsiyonel olabilir.
        // Birden fazla parametre içerisinde bir kısmı opsiyonel olabilir mi?
        // Birden fazla parametre durumunda opsiyonel olanlar sağ tarafta TANIMLANMALIDIR!
        #endregion
        #region Non-Trailing Named Arguments
        //todo Non-Trailing Named Arguments
        //Hangi parametreye hangi değerlerin gönderildiğini direkt görebilmek için bu özelliği kullanıırız.
        //Görece1i bir şekilde çok parametreli fonksiyonlarda hedef parametrelere değer göndermemizi sağlayan bir, özelliktir.
        public void X(int a, int b, string c)
        { }
        public void NonTrailingNamedArg()
        {
            X(c: "abc", a: 5, b: 5);
            X(1, c: "abc", b: 2);
        }
        #endregion
        #endregion
        #region Tanımlanmış Metodun Kullanımı
        //Tetikleme=Çağırma=Kullanım
        #region Tanımlandığı Sınıf İçinde Çağrılması
        // Bir metot tanımlandıuğl sınıf içerisindeki farklı bir metot içerisinden çağrılacaksa eğer
        // tek yapılması gereken sadece isminin çağrılmasıdır/ tetiklenmesidir/ çalıştırılmasıdır.
        public void A()
        {
            B();
        }
        public void B()
        {
            C();
        }
        public void C(int a = 0)
        {
            A();
        }
        #endregion
        #region Başka Sınıflarda Kullanımı
        #region Referans ve Nesne İlişkisine Hafiften Temas Edelim
        // Bir sınıfın içnde bulunan metotlara erişebilmek için bir nesne üretmen gerekecek bunu new ile yaparsın
        //   sonra bu nesneyi aynı sınıf tipi ile işaretlemen gerekecek
        // Random sınıfının metotlarına erişmek için;
        Random rnd = new Random(); //new Random ile nesne oluşturduk bunu Random türünde rnd değişkeni ile referans ettik
                                   // Sınıf (Class) Yeryüzündeki herhangi bir olguyu modellememizi sağlayan yapılanma!
                                   // İçerisinde ilgil iolguya dair verileri tutacak alanları(field) barındıran ve
                                   // bu alanlar üzerinde işlem yapmamızı sağlayacak olan metotları barındıran bir yapı!
                                   //Nesne Class 'tan üretilen değer/ veri.
                                   // Referans Class•tan üretilen değeri kullanmamızı sağlayan yapı!


        #endregion
        #endregion
        #endregion
        #region In Parameters
        //// 1. parametrenin değerini metodun içerisinde herhangi bir yerde çağırıp kullanabiliriz.
        // 2. metot içerisinde üretilen herhangi bir değeri tutacak değişken oluşturmaktansa parametre üzerinde bu değeri
        //tutabiliriz.Yani parametrenin değerini değiştirebililriz. (Çünkü parametreler özünde bir değişkendir)
        //todo metodlarda in keywordü
        // in komutu sayesinde parametreye verilen değeri sabit tutabilmekteyiz.
        // İn komutu, metodun parametresini readon1y(Sadece okunabilir) hale getirir.
        // in komutunun kullanılıdğı parametrelerde eğer ki metot içerisinde farklı bir assign durumu soz konusu olursa
        // derleyici hatası verecektir.
        void X(in int x, int b, in char c)
        {
            b = 5;

        }
        #endregion
        #region Local Functions
        //todo Local Functions
        // Bir metot içerisinde tanımlanmış olan metotlardır!
        //C#'ta metotlar sade ve sadece class içerisinde tanımlanırlar diye söylemiştik! Halbuki OOP'de göreceğimiz struct,
        // abstract class, interface, record yapılanmalarında da metotlar tanımlanmaktadır.Metotlar bu saydıklarıomızın
        // dışında KESİNLİKLE başka bir yerde tanımlanamaz! !! !
        //Metot1ar kesinlikle metotların içerisinde tanımlanamaz demiştirk! !! Halbuki C# 7.0'Da gelen local function
        //özelliği sayesinde metot içerisinde metot tanımlana ilmektedir.
        //Local func.larda Eriim belirleyicisi yoktur. yani direkt geri dönüş değerinden başlanır

        //Tanımlama Kuarlları
        // 1. Erişim belirleyici (Access Modifier) yazılmaz!
        // 2. Local function olarak tanımlanan fonksiyon adı tanımlandığı fonksiyonun adından farklı olmalıdır! Aksi
        //taktirde derleyici hatası VERMEZ! ! !
        //Kullanım Kuralları
        //- Bir local function sade ve sadece tanımlandığı metodun içerisinde kullanılabilir.
        //- Local function tanımlandığı metodun içerisinde her yârden erişilebilir.
        //Amacı
        // Local function, sadece tek bir metotta tekrarlı bir şekilde kullanılacak bir algoritmayı/ kod parçacığını/ işlemi o
        //metoda özel bir şekilde tek seferlik tanımlamamızı ve kullanmamızı sağlamaktadır.
        //Muadilleri;
        ////Anonim, Delegate, Func
        public void Function()
        {
            LocalFunction();

            void LocalFunction()
            {
                Console.WriteLine("Local Functions");
            }

            LocalFunction();
        }
        #endregion
        #region Static Local Functions
        //todo Static Local Functions

        //public void Funct(int a)
        //{
        //    int b= 5;
        //    static void StaticLocalFunction(int a, int b)
        //    {
        //        Console.WriteLine(a);
        //        Console.WriteLine(b);
        //    }
        //}
        #endregion
        #region Overloading Kuralları
        // Bir sınıf içerisinde birden fazla aynı isimde metot tanımlayabilmek için şu kuırallara dikkat edilmesi gerekmektedir.
        //Metot Overloading işlemini yapabilmek için metotların isimleri aynı olmalıdır!
        //Bu metotlar içerisinde fark yaratmamız gerekmektedir.
        // Bu fark bizzat metot imzalarında OLMALIDIR!
        //MetotIar arasında farkı yaratırken erişim belirleyicileri ve geri dönüş değerleri aktif rol oynamamaktadır.
        // *Parametre sayıları ya da parametre türleri fakrı 1 olmalıdır! *
        //OverIoading işlemine tabi tutulmuş metotlardan istediğimizi kullanabilmek için o metodun imzasına uygun parametreleri
        //tetiklememiz(ya da bir başka deyişle o imzadaki metodu kullanmamız) yeterli olacaktır.
        #endregion
        #region Recursive Yaklaşım (Tekrarlamalı/Öz Yinelemeli) Metotlar
        //todo Recursive Yaklaşım (Tekrarlamalı/Öz Yinelemeli) Metotlar
        //Recursive Fonk kendi içerisinde kendisini çağıran/ tetikleyen fonksiyonlardır.
        //Recursive fonk. bir yaklaşımdır!
        //Anlaşılması, kullanması ve anlatılması zordur!
        //Revursive fonk. ne amaçla kullanılmaktadır?
        //Öngörü1emeyen, derinlıgı tahmin edileme en sonu bılınme en durumlarda tercih edilebilir.

        //Örnkler;
        //public  void RecursiveFunc()
        //  {
        //      Console.WriteLine("Merhaba");
        //      RecursiveFunc(); //Sonsuz döngüye girer dikkat
        //      Console.WriteLine( "Dünya");// bu koda gelmeden kendisini tekrarlayacak
        //  }
        //public void RecursiveFunc(int a=1)
        //{
        //    Console.WriteLine("Merhaba");
        //    if (a<3)
        //    {
        //       RecursiveFunc(++a);  
        //    }

        //}
        //public void RecursiveFunc(int a = 1)
        //{
        //    Console.WriteLine("Merhaba");
        //    if (a < 3)
        //    {
        //        RecursiveFunc(++a);
        //    }
        //    Console.WriteLine("Dünya");
        //}

        #endregion
        #endregion

        #region Ref Keywordü
        //todo Ref Keywordü
        //ref keywordü referanstan gelmektedir.
        //Referans OOP kavramıdır.
        // OOP'de nesnler(object) RAM'de Heap bölgesinde tutulmaktedır.
        // OOP'de referanslar = operatörü ile iletişime geçebilmektedir. Bir referans, işaretlediği herhangi bir nesneyi
        // = operatörü sayesinde farklı bir referansa işaretlenebiir
        // Yani, referanslar da = operatörü neticesinde herhangi bir veriseL/nesneseL türeme söz konusu. olmamakta,
        // işaretlenmiş nesne diğer referans tarafından işaretlenmektedir.

        // ref keyword'ü değer türlü değişknlerin referanslarını çağırmamızı/kullanmamızı sağlamış olur.
        // Değer türlü değişkenlerde referans çalışması yapmak istiyorsak eğer ref keywordü kullanılır!
        //ref keywordü, değer türlü değişkenlerin referans türlü değişkenler gibi çalışmasını sağlayan bir komuttur.
        //Değer türü değişkenlerde sha110N copy»apmamızı sağlayna bir keywordüdür
        //Örnek 1
        //int a = 5;
        //ref int b = ref a;
        //a *= 5;
        //Console.WriteLine(b);

        //b -= 10;
        //Console.WriteLine(a);

        //Örenk 2
        // Kodun öncesi Program.cd 239. satırda
        public void RefKey(ref int x)
        { x = 25; }


        #endregion
        #region Ref Returns 
        // ref returns özelliği sadece metotlarda geçerlidir.
        //Metotlar  geriye değer döndürebilen yapılardır. Ayrıca metbtlarda geriye nesnelerde döndürebilmekteyiz .
        //Ayrqca ref returns özelliği sayesinde değer türlü değişkenlerin referanslarımda geriye döndürebilmekteyiz

        //Örnk

        // Algoritmanın önceki kodları Program.c243. satırda
        public ref int RefReturn(ref int y)
        {
            y = 25;
            return ref y;
        }
        #endregion
        #region Out Keywordü
        //todo out keywordü
        //Metodun parametreleri üzerinden dışarıya veri göndermemizi sağlayan keyword'tür
        //Bir metod out parametre barındırıyorsa o parametlerere kendi içersinde değer aanamsı gerekmekedir. Aksi takdirde derleyici hatası alıncakatır
        //Output parametre abrındıran bir metodu kullanırken, out parametrelerden gelecek oaln değerleri karşılayacak değişkenler tanımlanmalıdır


        // Algoritmanın önceki kodları Program.cs 248. satırdan itibaren yazıldı
        public int OutKey(out int b, int c, out string d)
        {
            b = 25;
            d = "Rumeysa";
            return 0;
        }
        #endregion
        #region TryParse
        //todo TryParse
        //string a = "123";
        //if (int.TryParse(a, out int result))  parse edilecek değerin türün uygunluğunu şansa bırakmamak ve runtime da hata almamak için TryParse keywordünü kullanırız. Sonuç bool döner bu doğrultuda işlem yapılır ve ya hata mesajı fırlatılr.

        //{
        //}
        //else
        //{

        //}
        #endregion
    }
    public class Matematik
    {


        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        public int Cikar(int sayi1, int sayi2)
        {
            return sayi1 - sayi2;
        }
        public int Carp(int sayi1, int sayi2) { return sayi1 * sayi2; }
        public double Böl(int sayi1, int sayi2)
        {
            return sayi1 / sayi2;
        }
    }
}
