using Microsoft.VisualBasic;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace A_dan_Z_ye_OOP
{
    public class OOPDersNotlari
    {

        #region Nested Class
        //Class içinde Class tanımlama
        //Class İçerisinde Tanımlanan Class Sınıf Elemanı mıdır? DEĞİLDİRRR

        /// <summary>
        /// Bu Class içi içe bir Class^tır
        /// </summary>
        public class ClassİcindeClass
        {
        }
        //kodun devamı progma.cs 15. satırında
        #endregion

        #region Class Elemanlarına Açıklama Satırı Nasıl Eklenır?
        //  /// <summary>
        //   /// Bu açıkalama iligli member a ekelenecek açıklamadır
        //    /// </summary>

        /// <summary>
        /// BU X'in birinic overload'dır
        /// </summary>
        public void X()
        {
        }
        /// <summary>
        /// Bu X'in ikinci overloadıdır.
        /// </summary>
        /// <param name="a"></param>
        public void X(int a) { }
        #endregion

        #region Field nedir?
        //Nesne içerisinde veri depoladığımız/tuttuğumuz alanlardır.
        //Class içerisindeki değişkenlerdir.
        //Herhangi bir türden olabilir.
        // Değerlerin Default'ları otomatik atanır
        //int a;
        //string b;

        #endregion

        #region Property nedir?

        //Nesne içerisinde özellik/property sağlar.
        //Property esasında özünde bir metottur. Yani programatik/algoritmik kodlanmızı
        //inşa ettiğimiz bir metot.
        //Lakin fiziksel olarak nptottan farkı parametre almamakta ve içerisinde get ve set
        //olmak üzere iki adet blok almaktadır.
        // Keza bu bloklar compile neticesinde get ve set isimü metotlar olarak karşımıza
        //çıkmaktadır.

        // Biz yazılımcılar nesnelerimiz içerisindeki field'lara direkt eriŞImesini istemeyiz
        //Dolayısıyla field'lar da ki verileri kontrollü bir şekilde dışarıya açmak isteriz.
        //i te böyle bir durumda metotları kullanabiliriz.
        //Böyle bir durumda C# programlama dilinde metot yerine property yapıları geliştirilmiştir.

        //işte...Biz property'lerin bu işlevine Encapsulation(Kapsülleme/Sarmalama) diyeceğiz...

        #region Encapsulation (Kapsülleme/Sarmalama) Nedir
        // Encapsulation, bir nesne içerisindeki dataların(fieldllardaki verilerin) dışarıya kontrollü
        //bir şekilde açılması ve kontrollü bir şekilde veri almasıdır.
        #endregion

        #region Full Property
        //Property hangi türden bir field'l temsil ediyorsa o türden olmalıdır...

        int yasi;
        //Property1er temsil ettikleri field' lapın isimlerinin başharfi büyük olacak şekilde isimlendirilir. .l
        //public int Yasi { get; set; }
        public int Yasi
        {
            get
            {
                // Property üzerinden değer talep edildiğinde bu blok tetiklernir.
                // Yani değer buradan gödneirlir.
                return yasi;
            }
            set
            {
                //  Propertype veri gönderildiğinde tetiklenir.

                yasi = value;//Gönderilen veriyi vaiue keywordüyle yakalar.

            }
        }

        #endregion
        #region Prop Property
        // • Bir property her ne kadar encapsulation yapsada temsil ettiği fieldlda ki dataya hiç
        //müdahale etmeden erişilmesini ve veri atanmasını sağlıyorsa böyle bir durumda
        //kullanılan property imzasıdır.
        public int MyProperty { get; set; }
        // Prop property'ler compile edildiklerinde arkaplanda kendi field'larını oluştururlar.
        //Dolayısıyla bir field tanımlamaya gerek yoktur!
        //Prop imzalarda ilgili property read only olabilir lakin write only olamaz!
        public int MyProperty1 { get; }
        #endregion

        #region Auto Property Initializers (C# 60)
        //• Bir propertylnin ilk değerini nesne ayağa kaldırılır kaldırılmaz aşağıdaki gibi verebiliriz.
        public int MyProperty2 { get; set; } = 15;
        public int MyProperty3 { get; } = 15;
        #endregion
        #region Ref Readonly Returns
        // • ref readonly returns, bir sınıf(class) içerisindeki fieldlı referansıyla döndürmemizi
        //sağlayan ve biryandan da bu değişkenin değerini read only yapan özelliktir.
        // Makaleyi Oku : https://www.gencayyildiz.com/blog/c-7-2-ref-readonly-returns/
        string adi = "Oğuzhan Dilek";
        public ref readonly string Adi => ref adi;

        #endregion
        #region Computed(Hesaplanmış) Properties
        //İçerisinde türetilmiş bir bağıntı taşıyan propertyllerdir.
        int s1 = 10;
        int s2 = 20;
        public int Topla
        {
            get
            {
                return s1 + s2;
            }
        }
        #endregion
        #region Expression-Bodied Property
        //anımlanan propertylde Lambda Expression kullanmamızı sağlayan söz dizimidir.
        //Sadece readonly olarak kullanılır
        public string Cinsiyet => "Erkek";
        #endregion
        #region Init-OnIy Properties - Init Accessor (C# 9,0)
        //Init-OnIy Properties, nesnenin sadece ilk yaratılış anında propertylerine değer atamaktadır.
        //Böylece iş kuralı gereği run time'da değeri değişmemesi gereken nesneler için bir önlem alınmaktadır.
        //Init-Only properties,developer açısından süreç esnasında değiştirilmemesi gereken property
        //değerlerinin "yanlışlıkla"değiştirilmesinin önüne geçmekte ve böylece olası hata ve bug'lardan yazılımı arındırmaktadır.
        //İlgili Makale https://www.gencayyildiz.com/blog/c-9-0-init-only-properties-ve-init-accessor/
        #endregion
        #region Indexer
        //• Nesneye indexer özelliği kazandıran, fıtrat olarak property ile birebir aynı olan elemandır.
        public int this[int a]
        {
            get { return a; }
            set
            {
            }
        }
        #endregion
        #endregion

        #region this Keywordü
        #region 1.Sınıfın Nesnesini Temsil Eder

        #endregion
        #region 2. Aynı isimde Field le Metot Parametrelerini Ayırmak çin Kullanılır
        //this keywordü ilgili class yapılanmasının o anki nesnesine karşılık gelir.
        //this kullanmak zorunda değiliz.
        class MyClass
        {
            int a;
            void X(int a)
            {
                this.a = 1; // MyClass memeber'ında ki a fieldına erisip değere atadık.
            }
        }
        #endregion
        #region 3. Bir Constructer'dan Başka Bir Constructer'l Çağırmak İçin Kullanılır

        #endregion
        #endregion

        #region Nesne kavramı (Object Concept)
        //todo Nesne nedir?
        // Kompleks verilerdir Nesneleri modellemeİzİ saglayan classlar İse Complex Type'lardir.
        // Bir veri bütünüdür
        MyClass nesne1 = new MyClass(); // MyClass nesne modeli olup new MyClass ile bir nesne oluşturduk.

        #region Target-Typed New Expressions (C# 9.0)
        // Nesne oluşum sürecinde, oluşturulacak olan nesne eğer ki direkt bir referansa atılıyorsa eğer
        //burada hangi nesnenin oluşturulduğu referans sayesinde bilinebilmektedir.Dolayısıyla ilgili
        //nesnenin oluşturulması için
        MyClass nesne2 = new();
        //ilgili makale https://www.gencayyildiz.com/blog/c-9-0-target-typed-new-expressions/
        #endregion

        #endregion

        #region Referans Nedir?
        //RAMIin Stack bölgesinde tanımlanan ve Heap bölgesindeki nesneleri işaretleyen/referanseden değişkenlerdir/noktalardır.
        //Eger ki bir nesne referanssizsa bunu oluşturabilmetkeyiz...Lakin bu nesne
        //sistemde/memoryde lüzumsuz yer kaplayacagindan dolayi belli bir sure sonra
        //Garbage Collector dedgimiz cop toplayİcisİ tarafindan temizlenecektir.
        //GC; heap'de referanssiz olan nesneleri imha etmekten/temzelemekten sorumlu bir yapilanmadir.l
        //MemberwiseCIone bir sinfiin icerisinde o siniftan uretilmis olan o anki nesneyi clonelamamizi saglayan bir fonksiyondur....l

        #endregion

        #region ENCAPSULATION NEDİR? BİR VERİYİ NEDEN KAPSÜLLERİZ?
        // Encapsulation, nesnelerimizde ki field'ların kontrollü bir şekilde dışarıya açılmasıdır.
        //Bir başka deyişle, nesnelerimizi başkalarının yanlış kullanımlarından korumak için kontrolsüz değişime kapatmaktır-
        #region Eskiden Encapsulation Nasıl Yapılıyordu
        class OldEncapsulation
        {
            int a;
            public int AGet() { return this.a; }
            public void AGet(int a)
            {
                this.a = a;
            }
        }
        #endregion
        #region Şimdiki Kullanım yani Full Property
        //propfull yazarak tab tab yap
        class NewEncapsulation
        {
            private int myVar;

            public int MyProperty
            {
                get { return myVar; }
                set { myVar = value; }
            }
        }

        #endregion
        #endregion

        #region Records Nedir
        //todo Records Nedir?
        //Eğer ki bir objeyi bütünsel olarak değişmez yapmak istiyorsak o zaman daha fazlasına ihtiyacımız olacaktır.
        //İşte bu ihtiyaca istinaden Records türü geliştirilmiştir.
        //Recordı bir objenin topyekün 6Üâre sabit/değişmez olarak kalmasını sağlamakta ve bu durumu güvence altına almaktadır.
        //Böylece bu obje, artık değeri değişmeyeceğinden dolayı esasında objeden ziyade bir değer gözüyle bakılan bir yapıya dönüşmektedir.
        // Buradan yola çıkarak record'ları, içerisinde data barındıran lightweight(hafif) class'lar olarakdeğerIendirebiliriz.
        //Record'lar bir class'tır. Sadece nesnelerinden ziyade, değerleri ön plana çıkmış bir Class.

        //Class ile Record farkı
        // + Class'lar da verisel olarak nesne ön plandadır ve bir farklı referansa sahip olan nesne farklı değer olarak algılanmaktadır.
        //+ Dolayısıyla Equals(xı y) karşılaştırması yanlıştır.

        //Recprdllar ise verişel olarak değeri ön planda tâaktadır.Sadece nesnel olarak bu veriler bir objede tutulmakta lakin
        //değiştirilmemektedir. Haliyle farklı objelerde de olsa, veriler(property değerleri) aynı olduğu sürece Equals(x, y) önermesi doğru olacaktır.
        //record MyRecord
        //{
        //    public int MyProperty5 { get; init; }
        //}

        //todo With Expressions 
        //+ Immutable türlerde çalışırken nesne üzeirnde değişiklik yapabilmek için ilgili nesneyi ya çoğaltmamız/klonlamamız(deep copy) ve
        //üzerinde değişiklik yapmamız gerekmekte ya da manuel yeni bir nesne üretip mevcut nesnedeki değerleri, değişikliği yansıtılacak şekilde
        //aktarmamız gerekmektedir.
        //+ Misal, alt tarafta bu tarz durumlara istinaden yazılımcıların yılların deneyiminden getirdiği With function çözümü ele alınmaktadır.
        //Kodlar Program.cs 18. satırda

        // Ya da aşağıdaki gibi record oluşturabilir ve With Function yazmadan direkt olarak with expressionslları kullanabilirsiniz.


        #region (Init-OnIy Properties) Nedir?
        //(Init-OnIy Properties) Nedir? ->> C# 9.01daı herhangi bir nesnenin propertylerine ilk değerlerinin verilmesi ve sonraki süreçte bu
        //değerlerin değiştirilmemesini garanti altına almamızı seğlayan Init - Only Properties Ozelliğigelmiştir.
        //Bu özellik sayesinde nesnenin sadece ilk oluşturulma anında propertylerine değer atanmakta 
        //ve böylece iş kuralları gereği untimelda değeri değişmemesi gereken nesneler için ideaLbjr önlem alınmaktadır
        //Init-OQly pçopefties, d&veloper açısından süreç esnasında değiştirilmemesi gereken property değerlerinin
        //-yanlışlıkla- değiştirilmesinin önüne geçmekte ve böylece olası hata ve bugl/ardan yazılımı arındırmaktadır.

        public int MyProperty4 { get; init; } = 1;

        //Aytıca getter-only-properties ile çalışmaktansa readonly bir field üzerinde işlem yapmamız gerekiyorsa
        //eğer aşağıdaki gibi init bizlere eşlik edebilmektedir.
        private readonly int c;
        public int InitOnly
        {
            get { return c; }
            init { c = value; }
        }
        #endregion


        #endregion

        #region Constructor Nedir
        //Constructor bir nesne üretimi sÜrecİnde tetiklenen metottur.
        //Constructor, özel bir sınıf elemanıdır.
        //Constructor, new ile nesne yaratma talebi geldikten ve ilgili nesneye hafızada yer ayrıl diktan sonra tetiklenir.
        //Constructor'ların;
        //Metot adı sınıf adıyla aynı olmalıdır! (Özel sınıf elemanlarının dışında hiçbir member sınıf adıyla aynı olamaz!)
        // Geri dönüş değeri olmaz/belirtilmez!
        //Erişim belirleyicisi public olmalıdır! (private olduğu durum incelenecektir)

        #region this Keywordüyle Construtor arası geçişler

        #endregion

        #endregion

        #region Destructor/FinaIizer Metot Nedir? Yıkıcı Metot
        //Bir classltan üretilmiş olan nesne İmha edilirken otomatik çağrılan metottur.
        //Parametre alamaz
        // Class içinde tanımlanır ve sadece bir tane tanımalanabilir

        //Peki Bir Nesne Hangi Şartlarda Kim Tarafından İmha Edilir?
        //Bir nesnenin imha edilmesi için;
        //ilgili nesne herhangi bir referans tarafından işaretlenmemelidir,
        //Yahut nesnenin oluşturulduğu ve kullanıldığı scope sona ermiş olmalıdır.
        //Yani anlaşılan ilgili nesneye bir daha erişilemez hale gelinmelidir.
        //işte o zaman nesne imha edilir.

        #region Garbage Collector
        // Uygulamada lüzumsuz olan nesneleri toplamak için Garbage Collector isimli bir mekanizma
        //devreye girer.
        //Esasında Garbage Collector C#'da bellek optimizasyonunu üstlenen bir yapılanmadır.
        //Dolayısıyla biz geliştiricilerin bu mekanizmaya müdahale etmesi pek öneırlmez
        #endregion

        #region Destructor Tanımlama Kuralları
        //Destructor tanımlayabilmek için ~(tilde) işareti kullanılır.
        //Örnekler Program.cs içinde 35-50 satırlarında
        #endregion
        #endregion

        #region Deconstruct Metodu Nedir?
        //  Bir sınıf içerisinde "Deconstructll ismiyle tanımlanan metot compiler tarafından özel olarak algılanmakta ve sınıfın
        //nesnesi üzerinden geriye hızlıca Tuple bir değer döndürmemizi sağlamaktadır.
        //Sınıf isimle aynı isimi barındırmaz!!!
        #region Deconstruct Prototipı
        //Örn 403. satır ve Program.cs 52-57 arasında

        #endregion
        #endregion

        #region Static Constructor
        //SORU: Bir sınıftan nesne oluşturulurken ilk tetiklenen fonksiyon nedir?
        //EL-CEVAP:) : Bir sınıftan nesne üretilirken "constructor"a nazaran ilk tetiklenen
        //metot "staticconstructor"dır. Amma velakin belirli bir duruma istinaden!!!
        // ctor İlgili siniftan hernesne üretilirken tetiklenen fonksiyondur....
        // static ctor ise ilgili siniftan ilkkkkk nesne  üretilirken tetiklnen fonksiyondur..."
        // static constructor'da geri donus degeri ve erişim belirleyicisi bildirilmez!
        //overloading yapilmaz! Bir sinifin icerisinde sade ve sadece bir tane tanimlanabilir.
        //Yani parametre
        //Isrni sinif ismiyle ayni olacaktir..

        #endregion

        #region Singleton Design Pattern
        // Bir sınıftan uygulama bazında sade ve sadece tek bir nesne oluşturulmasınıistiyorsan kullanabileceğin bir design pattern.
        #endregion

        #region Positional Record Nedir?
        //Norminal Recordllar Object Initializerjlar ile ilk degerleri verilerek üretilebilen readonly datalardi
        //Positional Recordlar ise esasinda Recordllar içerisinde tanimlama yapabildigimiz consfrudor ve deconslrudor kullanimlarini daha da özelleştirerek kullanilmasini saglamaktadirlar
        #endregion

        #region Inheritance (Kalıtım) Nedir?
        //Kalıtım OOP'nin ennnn önemli özelliğidir.
        //Üretilen nesneler farklı nesnelere özelliklerini aktarabilmekte ve böylece hiyerarşik bir düzenleme yapılabilmektedir.
        //Bir programcı açısından bu özellik;
        //Aynı aile grubundan gelen nesnelerin ya da yatayda eşit seviyede olan tüm olguların benzer özelliklerini tekrar tekrar herbirinde tanımlamaktansa bir üst sınıfta tanımlanmasını ve her bir sınıfın bu özellikleri üst sınıftan kalıtımsal olarak almasını sağlamaktadır.
        //Böylece hem kod maliyeti düşmekte, hem de mimarisel tasarım açısından avantaj sağlanmaktadır.

        #region C# Programlama Dilinde Hangi Yapılar Kalıtım Alabilirler?
        //C# programlama dilinde kalıtım sınıflara özel bir niteliktir.
        //Yani bir sınıf sade ve sadece bir sınıftan kalıtım alabilir.
        //Recordlar kalıtım alabiri mi?
        //Evet, recordlar da kalıtım alabilmekte.Lakin sadece kendi aralarında.Kalıtım alabildikleri tek istisnai sınıf ise ileride göreceğimiz Object sınıfıdır.
        //Ayrıca sonraki derslerimizde göreceğimiz abstract Class, interface ve struct gibi yapılarında kendilerine göre kalıtımsal operasyonları mevcuttur.Bu yapılardaki kalıtımsal detaylar ilgili derslerde ele alınacaktır.

        //C#lta iki sınıf arasında kalıtımsal ilişki kurabilmek için : operatörü kullanılmaktadır.
        //Hatta bilsekte bilmesekte kalıtımsal tüm ilişkiler : operatörü tarafından yapılmaktadır.
        // class KalıtımAlan : KalıtımVeren
        //class Torun : Dede
        //Bu operatör, bu sınıftakitüm erişilebilir memberları, bu sınıfa kalıtımsal olarak aktarmaktadır.
        #endregion
        #region Kaltımda Nesne Üretim Sıras Nasıldır?
        // Örnek A,B,C,D sınıfları oluşturulup sonuç Console yazılmıştır
        //   Yani buradan anlaşılıyor ki,bir sınıftan nesne üretilirken siz 1 adet nesne ürettiğinizi düşünsenizde kalıtımsal açıdan birden fazla nesne üretimig erçekleştirilebilmektedir.
        #endregion

        #region Nesnelerdeki Default Fonksiyonları İnceleyelim
        //Nesnelerdeki ToString,Equals, GetHashCode ve GetType Metotları Nereden Gelmektedir?
        #region Nesnelerin Atası/Ademi Object Türü
        //C# programlama dilinde tüm sınıflar Object sınıfından türetilir.

        #endregion


        #endregion

        #region İsim Saklama(Name Hiding) Sorunsalı
        //Kalıtım durumlarında atalardaki herhangi bir member ile aynı isimde memberla sahip olan nesneler olabilmektedir.
        //Neden mi Name Hiding?
        //Atalar ile aynnı isimde member var ise compoiler atalardaki member ı gizler
        #endregion

        #region Recordllar da Kalıtım?
        //        Record'lar sade ve sadece Record'lar dan kalıtım alabilmektedirler.
        //        Class'lar dan kalıtım alamazlar yahut veremezler!
        //Kalıtımın tüm temel kuralları record'laş için geçerlidir;
        //        Bir record aynı anda birden fazla recordldan kalıtım alamaz!
        //Record'lar da temelde Class oldukları için üretilir üretilmez otomatik olarak
        //Object'ten türerler.
        //base ve this keywordleri aynı amaçla kullanılabilmektedir.
        //Name Hiding söz konusu olabilmektedir.
        #endregion

        #region Base Keywordü
        #region Bir Sınıftan Base Class Constructorlına Ulaşım

        //Madem ki/ herhangi bir sınıftan nesne üretimi gerçekleştirilirken öncelikle base classlından nesne üretiliyor, bu demektir ki önce base classlın constructorlı tetikleniyor.
        //Haliyle bizler nesne üretimi esnasında base classlta üretilecek olan nesnenin istediğimiz constructorllarını tetikleyebilmeli yahut varsa parametre bu değerleri verebilmeliyiz.
        //• İşte bunun için base Keywordlü nü kullanmaktayız.
        #endregion
        //base Keyword vs this Keyword
        //• this, bir sınıftaki constructorllar arasında geçiş yapmamızı sağlar.
        //• baseı bir sınıfın base class'ının constructor'larından hangisinin tetikleneceğini belirlememizi ve varsa         parametrelerinin değerlerinin derived class'tan verilmesini sağlar.
        //Base Class'da erişilebilir olmayan member'lar base keywordüyle erişilemez!
        #endregion
        #endregion

        #region Sanal Yapılar (Virtual  Override)
        //Bir nesne üzerinde var olan tüm membe larımta mı derleme zamanında belirgindir.
        //Yani, derleme aşamasında hangi nesne üzerinden hangi metotların çağrılabileceği bilinmektedir.
        //Sanal yapılar ile derleme zamanında kesin bilinen bu bilgi run time(çalışma zamanın)da belirlenebilmektedir.Yani ilgili nesnenin hangi metodu kullanacağı bilgini kararlaştırılır.
        #region Sanal Yapılar Nedir
        //Sanal yapıları bir sınıf içerisinde bildirilmiş olan ve o sınıftan türeyen alt sınıflarda da tekrar bildirilebilen yapılardır.
        //Bu yapılar metot ya da property olabilir.
        //.Bir sınıfta bildirilen sanal yapı(metot ya da property) bu sınıftan türeyen torunlarında ezilebilmekte yani devre dışı bırakılıp yeniden oluşturulabilmektedir. Yani yeniden yapılandırmadır.
        //Yani sanal yapılanmalarda Name Hiding'de olduğu gibi bir isimsel çakışmadan ziyade üstten gelen bir yapının işlevini iptal edip yeniden yapılandırmak vardır
        //İşte burada bir sınıfta tasarlanmış sanal yapının işlevinin iptal edilip edilmeme durumuna göre tanımlandığı sınıftan mı yoksa bu sınıfın torunlarından mı çağrılacağının belirlenmesi run time'da gerçekleşecektir.
        //Sanal yapılarda çağrılan memberlın hangi türe ait olduğu Run Time'da belirlenir...
        //Vee unutma! Metot ya da property fark etmez! Bir sanal memberlın hangi türe ait olduğunun bu şekilde run timeldabelirlenmesine Geç Bağlama(Late Binding) denir!
        #endregion
        #region Sanal Ne için Kullanılr
        //Bir sınıfta tanımlanmış olan herhangi bir memberlın kendisinden türeyen alt sınıflarda Name Hiding durumuna düşmemeksizin ezilip/yeniden yazılıp yapılandırılması için kullanılır.
        //Peki bu zorunlu mudur?
        //Yani bir sanal yapı illa ki kendisinden türeyen torunlarda ezilmek/yeniden yazılmak zorunda mıdır?
        //Tabi ki de h9Y!Y! Yani bir member sanal illa ki kendisinden !türeyen!) alt sınıflarda ezilmez zoru da değildir!
        //Ama ezilmek istenirse de Name Hiding direkt ilgili sınıfın bir memberlı olacak şekilde sağlamış olur.
        #endregion
        #region Bir Sınıfta Sanal Yapı nasıl Oluşturulur
        //todo virtual keywordü 
        // public virtual ya da virtual public ilgili memberı (metod veya property) imzasını virtual keywordü ile işaretlemek yeterliir
        #endregion
        #region Sanal Yapılar Nasıl Ezilir 
        //Bir classlta virtual ile işaretlenerek sanal hale getirilmiş bir member(metot ya da property)ı bu classltan miras alan torunlarında ezilmek/yeniden yazılmak isteniyorsa eğer ilgili classlta imzası
        //todo override keywordü
        //işaretlenmiş bir vaziyette tekrardan aynı member oluşturulur. 
        //public override void MyMethod()
        //Base class'ta ya da atalarda virtual ile işaretlenerek sanallaştırılmış herhangi bir member torunlarda illa ki override ile ezilmek zorunda değildir!
        //Base class'taki bir member override edilecekse o member virtua ile işaretlenmesi gerekir
        #endregion
        #region İkiden Çok Hiyerarş, Kalıtım Durumlarda Override Durumu
        //Bir Clas virtual InheritanceLevel  işaretlenmiş herhangi bir member illa ki direkt o class'tan türeyen 1. dereceden classllar da override edilmek mecburiyetinde değildir!
        //İhtiyaca binaen alt seviyede ki torunlardan herhangi birinde override edilebilir.

        #endregion
        #region Özet
        //    • Sanal yapılar OOP'de Polimorfızm(Çok Biçimlilik)'i uygulayan
        //yapılardır. (İleride göreceğiz)
        //• Sanal yapıların en önemli özelliği Geç Bağlam(Late Binding)'dir.
        //Eğer bir member sanal olarak bildirilmemişse, derleyici nesnelerin tü
        //bilgisinden faydalanarak derleme zamanında hangi nesneden ilgili
        //member'ın çağrılacağını bilir.
        //Eğer bir member sanal olarak bildirilmişse, ilgili member'ın hangi
        //nesne üzerinden çağrılacağı run time'da belirlenir.
        //Hangi member'ın run timelda belirlenmesine Geç Bağlama(Late
        //Binding) denir.
        //• Sanal yapı oluşturabilmek için ilgili member'ı virtual keywordü ile
        //işaretlemeliyiz.
        //        Türeyen sınıflarda sanal yapıyı ezebilmek için override
        //kullanılır.
        //Türeyen sınıflar sanal yapıları override etmek zorunlu değildir
        //Static yapılanmalar sanal olarak bildirilemezler! (
        #endregion
        #endregion

        #region Çok Biçimlilik (Polimorfizim)
        //İki ya da daha fazla nesnenin aynı tür sınıf tarafından karşılabilmesidir/referans edilebilmesidir.
        //Bir başka deyişle;Bir nesnenin birden fazla farklı türdeki referans tarafından işaretlenebilmesi polimorfizm'dir.
        //Polimorfizm, OOP tasarımlarında geliştirilen koda daha manevrasal bir şekilde nitelik kazandıran ve yaklaşım sergilememizi sağlayan bir özelliktir.
        #region Static Polimorfizm
        //Static polimorfizm; derleme zamanında sergilenen polimorfizm'dir. Hangi fonksiyonun çağrılacağına derleme zamanında karar verilir.
        //C#'da static polimorfızm deyince aklımıza Metot Overloading terimi gelmelidir.
        //Metot Overloading; aynı isimde birbirinden farklı imzalara sahip olan metotların tanımlanmasıdır.Ya da başka deyişle bir isme birden fazla farklı türde metot yüklemektir.Haliyle burada bir metodun birden fazla formunun olması polimorfizm'ken, bunlardan kullanılacak olanın derleme zamanında bilinmesi statik polimorfizm olarak  nitelendirilmektedir.
        #endregion
        #region Dinamik Polimorfizm
        //Dinamik polimorfizm; çalışma zamanında sergilenen polimorfizm'dir. Yani hangi fonksiyonun çalışacağına run timeida karar verilir.
        //C#'da dinamik polimorfizm deyince akla Metot Override gelmektedir.
        //Metot Override; base class'ta virtual olarak işaretlenmiş metotların derived class'ta override edilerek ezilmesi/ yeniden yazılması işlemidir.Haliyle burada aynı isimde birden fazla forma sahip fonksiyonun olması polimorfizm'ken, bunlardan hangisinin kullanılacağının çalışma zamanında bilinmesi dinamik polimorfizm olarak nitelendirilmektedir.
        #endregion
        #region Polimorfizm Durumlarında Tür Dönüşümleri
        //Polimorfizmı OOPlde bir nesnenin kalıtımsal açıdan ataları olan referanslar tarafından işaretlenebilmesidir.Haliyle ilgili nesne, bu ataları olan referans türlerine göre dönüştürülebilmektedir.
        //A a = new C();
        //C c=(C)a; /*Misal olarak, burada görüldüğü üzere A türünden olan a referansındaki özünde C türünden nesne kendi türünden bir referansla işaretlenmiştir.*/
        //Dikkat ederseniz bu işlem için Cast operatörü kullanılmaktadır.
        //Bu durumun terside geçerlidir.Yani ilgili nesne kendi türünden kalıtımsal olarak ataları olan diğer türlere Cast edilebilir. C =new C(); --> A a=(A)c;

        #region Cast Operatörü ile
        //A a = new C();
        //C c=(C)a; 
        //Eğer ki, kalıtımsal ilişki olmayan herhangi bir türe dönüştürülmeye çalışılırsa derleyici hatası verecektir.

        //Yok eğer kalıtımsal ilişkide olup fiziksel nesnenin hiyerarşik altında olan bir türe dönüştürülmeye çalışılırsa run time hatası verecektir.
        //--> D d= (D)a;
        // kalıtımsal olarak Cnin altında Alnın torunu ise fiziksel C nesnesinin kendisinden küçük olan D referansıyla işaretlenmesi Polimorfizm mantığı gereği mümkün olamayacağı için run time hatası verecektir.

        // --> C C=new C();
        // A a= c; bilinçsiz tür dönüşümü ilede yapabiliriz ama alttaki açıklama kaydıyla
        //Tersine olarak, kalıtımsal ilişkide alt türden üst türe cast operatörü ile de bir dönüşüm sağlamaktadır.
        #endregion
        #region As Operatörü ile
        //A a = new C();
        //C c = a as C;
        // kalıtımsal ilişkide olup fiziksel nesnenin türünden daha alt hiyerarşide olan nesnelere dönüştürülmeye çalışıldığında Polimorfizm mantığı gereği ilgili referans o nesneyi karşılayamayacağından run time hatası VERMEYECEK! geriye null dönecektir.
        //A a = new C();
        // D d= a as D --> run time da null değeri verir. Cast kullanırken Try Catch , as kullanırken null değer kontroledilir
        #endregion
        #region is Operatörü 
        //is operatörü kalıtımsal ilişkiye sahip nesnelerin Polimorfizm özelliğine nazaran fiziksel olarak hangi türde olduğunu veren bir operatördür.
        //Haliyle çok biçimlilik uygulanmış bir nesnenin ihtiyaç doğrultusunda(uygun olan) farklı bir türe dönüştürülebilmesi için işi garantiye alabilmek adına önce is kontrolü ardından Cast ya da as operasyonu sağlanması kafiidir.
        #endregion
        #endregion
        #endregion

        #region Association, Aggregation, Composition (Nesneler Arası İlişki Türleri)
        //Nesneler arasında terminolojik olarak nitelendirilebilir ilişki türleri mevcuttur.Bu ilişkiler; kalıtım, referans yahut soyutlama gibi durumların getirisi olan mantıksal izahatlerdir.
        //Nesneler arası ilişki türleri :
        //is —a ilişkisi
        // has —a ilişkisi
        // can — do ilişkisi
        #region Nesneler arası ilişki türleri 
        #region is - a İlişkisi Nedir?
        //is — a ilişkisi tamamıyle kalıtımla alakalıdır.C# programlama dilinde, iki sınıf arasında : operatörü ile gerçekleştirilen kalıtım neticesinde ortaya bir is — a ilişkisi çıkmaktadır.
        #endregion
        #region has-a İlişkisi Nedir?
        //Bir sınıfın başka bir sınıfın nesnesine dair sahiplik ifadesinde bulunan ilişkidir.Bir yandan kompozisyon/composition ilişkisi de denmektedir.
        //class Araba
        //{

        //}
        //class Opel:Araba Opel bir arabadır yani is -a ilişkisi
        //{
        //    Motor motor=new Motor(); // Opelin Motor'u vardır has-a
        //}
        //class Motor
        //{

        //}
        #endregion
        #region can-do ilişkis Nedir?
        //Kısaca interface; bir sınıfın imzasıdır.Yani bir sınıfın içerisinde olacak olan tüm member'ların şablonunu/arayüzünü oluşturduğumuz bir kontrattır.Herhangi bir interface'i uygulayan Class o interface içerisinde tanımlanmış member imzalarını kendisinde oluşturmak zorundadır.Aksi taktirde compiler hata verecektir.Velhasıl tüm bunları a'dan z'ye ilgili konuya ait dersimizde tam teferruatlı incelemiş olacağız.
        //Interface'ler içlerindeki member'ların imzalarını classlara uygulattırdığından dolayı o interface'ler ilgili nesnelerin yapabilecekleri kabiliyetleri göstermektedir.
        //Yani can-do ilişkisi bir nesnenin davranışlarını/kabiliyetlerini belirtmektedir.
        //Bu davranış/kabiliyetlerin interface içerisinde tanımlanmaktadır.
        #endregion
        #endregion

        #region Association Nedir?
        //  •Association, sınıflar arasındaki bağlantının zayıf biçimine verilen addır.
        //'Bu bağlantı oldukça gevşektir. Yani, sınıflar kendi aralarında ilişkilidir lakin
        //birbirlerinden de bağımsızdırlar!
        //'Parça - bütün ilişkisi yoktur!
        //'Örneğin; bir otobüsteki yolcular ile otobüs arasındaki ilişki Association'dır. Nihayetinde hepsi aynı yöne gitmektedir.Lakin bir yolcu indiğinde bu durum otobüsün ve diğer yolcuların durumunu değiştirmez!

        #endregion
        #region Aggregation ve Composition Nedir?
        //-Nesneleri birleştirip daha büyük bir nesne yapmaya verilen isimlerdir.
        // -Yani her ikisi de birleştirilmiş nesnelerden bütünsel nesneler yapma durumlarını ifade eden
        //-Her ikisinde de Association'da olmayan parça - bütün ilişkisi söz konusudur.
        //-Her ikisinde de sahiplik ilişkisi(has a) vardır.

        //Fark Nedir
        //Usta , Duvar Çimento ilişkisi üzerinden örnek

        // 1- Duvarla Tuğla arasındaki ilişki
        //        Duvar, tuğlalardan örülmektedir.Yani
        //tuğlaların bir araya gelmesiyle oluşur.
        //Haliyle tuğla olmadan duvar olmaz!
        //Amma velakin, tuğla tek başına bir anlam
        //ifade edebilmektedir.Nihayetinde bir
        //tuğlayı duvar örmenin dışında farklı
        //noktalarda da kullanabiliriz.
        //O yüzden duvarla tuğla arasındaki ilişki
        //Aggregation'dır.

        // 2 - Duvarla Çimento arasındaki İlişki
        //  Duvar, çimento olmadan örülemez.Lakin
        //çimento da duvar örmenin dışında tek başına
        //bir anlam ifade etmez!(öyle kabul edelim)
        //Bu sebepten dolayı duvarla çimento
        //arasındaki ilişki Composition'dır.

        // 3- Duvarla Usta Arasındaki İlişki
        // Duvar ile usta arasında parça - bütün ilişkisi
        //yoktur.Duvarı herhangi bir usta örebilir.
        //Haliyle duvar ile usta arasındaki ilişki de sıkı
        //bağlılık olmadığından dolayı Association'dır.
        #endregion

        #endregion

        #region sealed Keyword
        //Bir sınıfın miras vermesini yahut bir başka deyişle başka bir sınıf tarafından miras alınmasını engelleyen bir keyword'dür.
        //Sadece sınıflarda ve sadece 'override' edilmiş metotlarda kullanılabilir.

        #region Method Üzerinde sealed işlevi
        //Kalıtımsal durumlarda, atalardan gelen ve birinci dereceden alt sınıf tarafından 'override' edilmiş olan 'virtual' member'ların hiyerarşideki sonraki sınıflar tarafından 'override' edilmesini ilgili member'ı sealed ile işaretleyerek engelleyebiliriz.
        //Pratikte bu yöntem sayesinde üst sınıfın davranışını güvenli bir şekilde korumuş ve ilgili metodun değiştirilmesini önlemiş oluyoruz.
        #endregion
        #region Hangi durumlarda kullanılmalıdır
        //        Sınıfların Davranışlarını Korumak İstediğimizde
        //Kalıtımsal Hiyerarşide üst sınıfların özel metotları/davranışları varsa ve bu
        //metotlardaki davranışların alt sınıflar tarafından değiştirilebilir olmasını istemediğimiz
        //durumlarda, o metodu sealed olarak işaretleyebiliriz.

        //         Performans İyileştirmesi İstendiğinde
        //Mikro seviyede yapılan bir optimizasyon neticesinde C#'ta bir sınıf sealed ile
        //işaretlendiğinde sealed olmayan bir sınıfa göre ufak çapta bir performans artışı
        //gösterdiği anlaşılmıştır.Bunun nedeni, derleyicinin sealed ile işaretlenmiş sınıfın
        //miras alınamayacağını bilerek daha hızlı derleme yapmasıdır.

        //            Singleton Design Pattern
        //Singleton Design Pattern'da bir sınıfın uygulama çapında tekil bir instance'ının
        //olması amaçlanmaktadır.Haliyle ilgili sınıf sealed ile işaretlenerek, bu sınıftan
        //herhangi bir kalıtımsal ilişkinin yaratılmasını engelleyebilir ve tek instance üretimini
        //daha da garanti hale getirmiş oluruz.
        #endregion
        #endregion

        #region PARTIAL YAPILANMALAR
        //Bir classlını structlın yahut interfacelin aynı yahut farklı dosyalarda birden fazla parçasının tasarlanmasını lakin bu parçaların ÖzÜnde bir bÜtÜn olarak kullanılmasını sağlayanı kodun daha organize ve kolay okunabilirliğini arttıran özelliklerdir.

        //Normal şartlarda aynı namespace altında birden fazla aynı isimde yapı bulundurulamaz!
        //Amma velâkin bu yapılar partial olarak tasarlanıyorsa bu mümkündür.
        //Bu tanımlamalar fiziksel olarak farklı olsalar da compiler açısından bir bütünün parçalarıdır.
        //Yani yandaki gibi bu sınıftan bir nesne retilmeye çalışıldığı zaman özünde tek bir nesne üretilecektir.
        //Bu tanımlar ister aynı ister farklı dosya içerisinde tanımlanabilir.
        //Tabi unutmamak lazımdır ki, fiziksel olarak farklı olan bu tanımların birbirlerinin parçaları olabilmesi için aynı namespace içerisinde, aynı isimde ve aynı yapıda olmaları gerekmektedir.

        #region Kullanım Amaçaları
        //        Kod Bölümleme
        //Büyük ve karmaşık yapıdaki sınıfları daha okunabilir ve düzenlenebilir parçalara bölmek için kullanılabilir.

        //        İş Bölümü
        //Ekiplerin, aynı sınıfın farklı kısımlarını aynı anda geliştirebilmeleri için kullanılabilir.

        //        Code Generator
        //Code Generator sistemleri tarafından yazdığınız kodun ezilmemesi için kullanılabilir.
        #endregion

        #region Sınırlar Nelerdir?
        // Parça olması amaçlanan tüm yapılar partial keyword'ü ile işaretlenmelidir.
        //İç içe partial türler kullanılabilir.
        //Tüm partal yapılar aynı namespace altında bulunmalıdır. Farklı projeler yahut
        //modüllere yayılamaz!
        //parlial olan bir yapının tüm parçalarının türleri ve isimleri aynı olmak zorundadır.

        #endregion

        #region PARTIAL OLABİLEN YAPILAR
        //Class
        //Struct
        //Record
        //İnterface
        //Abstract Class
        #endregion
        #region Partial Metotlar Nelerdir?
        //Partial metotlar, sınıfın bir parçasında geliştiricinin metot bildiriminde bulunmasını sağlar.Başka bir parçasında ise diğer geliştirici tarafından bu metot tanımlanabilir.Bunun yararlı olduğu iki senaryo vardır;

        //1. Template Code
        //Geliştirilen kodda metotlara dair bir şablon oluşturmak için kullanılabilir.
        //Bu şablonların uygulanıp uygulanmayacağına dair geliştiricinin karar vermesine olanak tanınır. 
        //Eğer şablonu tanımlanan metot uygulanmazsa derleyici tarafından metodun imzası ve o metoda dair yapılan tum çağrılar/tetiklemeler kaldırılır.
        //Yani anlayacağınız, partial bir metot tanımlandığı taktirde ister uygulansın ister uygulanmasın herhangi bir farklı noktadan çağrılabilir/tetiklenebilir.Ancak uygulanmadığı taktirde herhangi bir derleme yahut çalışma zamanı hatası alınmayacaktır.

        //2 Source Generator
        //• Source generator sistemleri ile sınıflarda tanımlanmış olan par-tial metot imzalarına karşılık govdeler oluşturulabilir.
        //Geliştirici, uygulanacak  metodun partial bir şekilde şablonunu ekledikten sonra source generator derleme sırasında bu metodun uygulamasını sağlar.
        //Tabi geliştirici isterse, bu metotların govdeleri source generator tarafından üretilmeden önce ya da bir başka deyişle bu metotlar uygulanmadan once başka bir noktada çğrırabilir/ tetiklenebilir.

        #region Kuralları
        //partial metotların runtime'da var olacağı kesin değildir. Eğer implementation edilmedilerse partial metotlar derleme sırasında yok sayılırlar.
        //Yukarıdaki durumdan dolayı partial metotlar delegate'ler ile temsil edilemezler.
        //partial metotlar;
        //ancak partal yapılar içerisinde tanımlanabilirler.
        //geri dönüş tipleri her daim void olmak zorundadır.
        ////static veya generic olabilirler.
        //out parametresi alamazlar lakin ref parametresi alabilirler.
        //extern ve virtual olamazlar.
        //Aynı classllar da olduğu gibi paftial metodun hem tanımı hem de gövdesi partial ile işaretlenmelidir.
        //Bir metot imzasına karşılık tanım ve gövde olabilir.
        //Eğer ki partial metotlar başka bir metot tarafından çağrılırlarsa compiler tarafından var oldukları bilinecektir yok eğer çağrılmazlarsa compiler derleme aşamasında ilgili metodu hiç görmeyecektir.
        //Gövdeleri tanımlı olduğu halde public olarak işaretlenebilir aksi halde gövde tanımlı değilse izin vermez erişim default olarak  private olarak kalır

        #endregion
        #endregion
        #region partial Keywordü

        #endregion
        #endregion
    }
    public class Employee
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public int? Position { get; init; }
        public Employee With(int position)
        {
            return new Employee
            {
                Name = this.Name,
                Surname = this.Surname,
                Position = position
            };
        }
    }
    public record MyRecord
    {
        public MyRecord()
        {

        }
        public string Name { get; init; }
        public string Surname { get; init; }
        public int? Position { get; init; }
    }
    public class ConstructorClass
    {
        public ConstructorClass()
        {
            Console.WriteLine("Birinci  Constructor nesnesi oluşturmuştur ");
        }

        public ConstructorClass(int a) : this()
        {
            Console.WriteLine("İkinci Constructor nesnesi oluşturmuştur " + a);
        }

        public ConstructorClass(int a, int b) : this(a)
        {
            Console.WriteLine("Üçüncü Constructor nesnesi oluşturmuştur " + a + b);
        }
        ~ConstructorClass() { Console.WriteLine("Selametle ben imha oldum"); }
    }
    public class MyClass2
    {
        int no;
        public MyClass2(int no)
        {
            this.no = no;
            Console.WriteLine($"{no}. nesne oluşturulmuştur");
        }
        ~MyClass2() { Console.WriteLine($"{no}. nesne imha edilmiştir"); }
    }
    public class Person //Deconstruct Prototip Örneği
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Deconstruct(out string name, out int age)
        {
            name = Name;
            age = Age;
        }
    }

    public class MyClass3 //Static Constructor Örneği
    {
        public MyClass3()
        {
            //Bu sınıftan nesne üretilirken ilk tetiklenecek olan metottur.
            Console.WriteLine("MyClass3 ctor tetiklenmiştir");
        }

        static MyClass3() // static constructor'da geri donus degeri ve erişim belirleyicisi bildirilmez!
        {
            // Bu sınıftan ilk nesne üretilirken ilk tetiklenecek olan metottur.
            //Üreti1en ilk nesnenin dışında birdaha tetiklenmez!
            Console.WriteLine("MyClass3 static ctor tetiklenmiştir");
            // Stat ic construct'ın tetiklenebilmesi için illa ilk nesne üretimi
            //yapılmasına gerek yoktur.ilgili sınıf içerisinde herhangi bir static
            //yapılanmanında tetiklenmesi static cosnt.tetiklenmesini sağlayacaktır.
        }
    }

    public class Database // Singleton Design Pattern Örneği//Video 14
    {
        Database()
        {

        }
        public string ConnectionString { get; set; }
        static Database database;
        public static Database GetInstance
        {
            get
            {
                return database;
            }
        }

        static Database()
        {
            database = new Database();
        }
    }

    public record MyRecord2(string name, string surname) //Positional Record
    {
        //Bir record üzerinde constructor ve deconstruct yapilanmasini hizlİ bir şekildeoluşturmamizi saglayan bir semantik saglamaktadir.

        //Bu parametrelerin karsiligi olarak compiler seviyesinde propertyler otomatik oluşturulacaktir.
        //BU PROPERTYLER OLUŞTURULRUKEN inil OLACAK ŞEKİLDE OLUŞTURULUR....
        // P.R.kullanirken parametrelerin karsiliklari olan propertyleri manuel oluşturmakzorunda DEGILIZ....



        //Positional Record tanımlanmışsa eğer nesne üretiminde tetiklenmesi/ kullanılması ZORUNLUDUR!
        public MyRecord2() : this("Positional", "Record")
        {

        }
        public MyRecord2(string name) : this()
        {

        }

        public string Name => name;
        public string Surname => surname; // isteğe bağlı kendi proplarımızı yazıp Positional da ki dataları eşitleyebiliriz
    }
    public class A
    {
        int a;
        public int b;
        public int MyProperty { get; set; }//Name Hiding örneği
        public A()
        {
            Console.WriteLine($"{nameof(A)} nesnesi ouşturulmuştur");
        }


    }
    public class B : A
    {
        int c;
        public int MyProperty { get; set; } //Name Hiding örneği
        public B()
        {
            Console.WriteLine($"{nameof(B)} nesnesi ouşturulmuştur");
            this.b = 1;
            base.MyProperty = 2;
            MyProperty = 3; //compailer başına default base koyacaktır.

        }
    }
    public class C : B
    {
        public C()
        {
            Console.WriteLine($"{nameof(C)} nesnesi ouşturulmuştur");
        }
    }
    public class D : C
    {
        public D()
        {
            Console.WriteLine($"{nameof(D)} nesnesi ouşturulmuştur");
        }
    }
    class BaseClass
    {
        public BaseClass(int a)
        {

        }
        public BaseClass(string a)
        {

        }
        public BaseClass(int a, string b)
        {
            //Bir classin constructorinin yaninda : base(... ) kepvordunu kullanirsak eger o class'in base classinin tum constructorlarini bize getirecektir.Haliyle ilgili siniftan bir nesne uretililrken base classtan nesne üretimi esnasinda hangi constructorin tetiklenegini bu şekilde belirleyebiliriz....
        }
        public BaseClass()
        {
            //  Eger ki base class'ta bos parametreli bir constructor varsa derived classta base ile bir bildirilmde bulunmak zorunda degiliz...Nicin? Cunku varsayilan olarak kalitimsal durumda base classtaki bos paarametreleri constructor tetiklenir....
        }
    }
    class ChieldClass : BaseClass //DerivedClass
    {

        public ChieldClass() : base(5, "Asdşsi")
        {
            //Eger ki base class'in costructor'i sadece parametre alan constructor ise derived class'larda o constructor'a bir deger GONDERMEK ZORUNDAYIZ....
            //Bunuda base keyvmrduyle saglayabiliriz...l
        }
        public ChieldClass(int a) : base(a)
        {

        }
    }


    #region Virtual Override için Örnekler
    #region örnek 1
    public class Obje
    {
        public virtual void Bilgi()
        {
            Console.WriteLine("Ben bir objeyim");
        }
    }
    public class Terlik : Obje
    {
        public override void Bilgi()
        {
            Console.WriteLine("Ben bir terliğim");
        }
    }
    public class Kalem : Obje
    {
        public override void Bilgi()
        {
            Console.WriteLine("Ben bir kalemim");
        }
    }
    #endregion
    #region Örnek 2
    public class Memeli
    {
        virtual public void Konus()
        {
            Console.WriteLine("Ben konuşmuyorum");
        }
    }
    public class Maymun : Memeli
    {
        public override void Konus()
        {
            Console.WriteLine("Ben maymunum");
        }
    }
    public class Inek : Memeli
    {
        public override void Konus()
        {
            Console.WriteLine("Ben ineğim..");
        }
    }
    #endregion
    #region Örnek 3
    public class Sekil
    {
        protected int _boy; //todo Protected ile işaretlenmiş herhangi bir member sade ve sadece ilgili sınıfta yahut o sınıftan kalıtım almış olan sınıfların içerisinde erişilebilir. Amma velakin nesne üzerinden erişilemez!
        protected int _en;
        public Sekil(int boy, int en)
        {
            _boy = boy;
            _en = en;
        }
        public virtual int AlanHesapla()
        {
            return 0;
        }

    }
    public class Ucgen : Sekil
    {
        public Ucgen(int boy, int en) : base(boy, en)
        {

        }
        public override int AlanHesapla()
        {
            return _boy * _en / 2;
        }
    }
    public class Dortgen : Sekil
    {
        public Dortgen(int boy, int en) : base(boy, en)
        {

        }
        public override int AlanHesapla()
        {
            return _boy * _en;
        }
    }
    public class Dikdörtgen : Sekil
    {
        public Dikdörtgen(int boy, int en) : base(boy, en)
        {

        }
        public override int AlanHesapla()
        {
            return _boy * _en;
        }
    }
    #endregion
    #endregion

    #region Seald Keyword Örneği
    //sealed class SealdClass
    // {
    //     public virtual void SealedMethod() 
    //     {

    //     }
    // }
    class SealdClass
    {
        public virtual void SealedMethod()
        {

        }
    }
    class CaseClass : SealdClass
    {
        sealed public override void SealedMethod()
        {
            Console.WriteLine("Ben bir sealed örneği methodum");
        }
    }
    class ExampClass : CaseClass
    {
        //  override // burdan itibaren varsa alttaki miras alan sınıflarda method override edileemz
    }
    sealed record SealedRecord
    {

    }
    #endregion

    #region partial Örneği
    #region partial class
    public partial class PartialClass
    {
        public void A()
        {

        }
        partial void X();
        partial void Y();
        partial void Z();

        partial void Y()
        {
            throw new NotImplementedException();
        }
    }

    public partial class PartialClass
    {
        public void B()
        {

        }
    }
    #endregion
    #region partial record
    partial record PartialRecord
    {

    }
    partial record PartialRecord
    {

    }
    #endregion
    #region partial abstract class
    abstract partial class AbstractPartialClass
    {

    }
    abstract partial class AbstractPartialClass
    {

    }
    #endregion
    #region partial struct
    partial struct PartialStruct { }
    partial struct PartialStruct { }
    #endregion
    #region partial interface
    partial interface IPartialInterFace { }
    partial interface IPartialInterFace { }
    #endregion
    #endregion
}
