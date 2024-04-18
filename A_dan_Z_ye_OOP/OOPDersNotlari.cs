using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
        #region 2. Aynı simde Field le Metot Parametrelerini Ayırmak çin Kullanılır
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
        //Rçcordı bir objenin topyekü 6Üâre sabit/değişmez olarak kalmasını sağlamakta ve bu durumu güvence altına almaktadır.
        //Böylece bu obje, artık değeri değişmeyeceğinden dolayı esasında objeden ziyade bir değer gözüyle bakılan bir yapıya dönüşmektedir.
        // Buradan yola çıkarak record'ları, içerisinde data barındıran lightweight(hafif) class'lar olarakdeğerIendirebiliriz.
        //Record'lar bir class'tır. Sadece nesnelerinden ziyade, değerleri ön plana çıkmış bir Class.

        //Class ile Record farkı
        // + Class'lar ğa verişel olarak nesne ön piahdâdır ve bir farklı referansa sahip olan hesne farklı değer olarak algılanmaktadır.
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
        //Metot adı sınıf adıyla aynı olmalıdır! (Özel sınıf elemanla ın
        //dışında hiçbir member sınıf adıyla aynı olamaz!)
        // Geri dönüş değeri olmaz/belirtilmez!
        //Erişim belirleyicisi public olmalıdır! (private olduğu durum
        //ayriyetten incelenecektir)
        
     
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
        public string Name { get; init; }
        public string Surname { get; init; }
        public int? Position { get; init; }
    }
    public class ConstructorClass
    {
        public ConstructorClass()
        {
            Console.WriteLine("Bir adet Constructor nesnesi oluşturmuştur");
        }
    }
}
