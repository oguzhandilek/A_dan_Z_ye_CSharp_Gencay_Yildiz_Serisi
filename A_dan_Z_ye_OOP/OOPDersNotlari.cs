using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

        #endregion
        #region 3. Bir Constructer'dan Başka Bir Constructer'l Çağırmak İçin Kullanılır

        #endregion
        #endregion
    }
}
