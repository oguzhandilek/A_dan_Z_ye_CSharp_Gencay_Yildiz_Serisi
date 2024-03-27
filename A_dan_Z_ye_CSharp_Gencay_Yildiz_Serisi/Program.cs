using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace A_dan_Z_ye_CSharp_Gencay_Yildiz_Serisi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(typeof(decimal).IsPrimitive);

            //float x = 3.14f;
            //double y = 3.14d;
            //decimal z = 3.14m;
            //(int a, string b) c = (1, "Zehra");
            //Console.WriteLine(c.a+" "+c.b);
            //c.a = 1_000_000;
            //c.b = "Rumeysa";
            //Console.WriteLine(c.a + " " + c.b);
            //const double piDegeri= 3.14;
            //object adi = "Oğuzhan";
            //object _yas = 32;
            //var _var = 5;
            //dynamic _dynamic = 5;
            //string @parse = "123";
            //bool medeniHal = false;
            //string mesaj = medeniHal == true ? "Evlilere kampanya.." : "Bekaralara kampnaya..";
            //Console.WriteLine(mesaj);
            //Console.WriteLine(short.Parse(parse)*5);
            //Console.WriteLine(_dynamic.GetType());
            //Console.WriteLine((int)_yas*5);
            //Console.WriteLine(adi);
            //int yas = 25;
            //string sonuc= yas<25 ? "A": (yas==25 ? "B" : "C");

            // 110'uncu ders soru çözümü

            //int sayi=int.Parse(Console.ReadLine());
            //int sonuc = sayi < 3 ? sayi * 5 :
            //    (sayi > 3 && sayi < 9 ? sayi * 3 :
            //    (sayi >= 9 && sayi % 2 == 0) ? sayi * 10 :
            //    (sayi % 2 == 1 ? sayi : 1));
            //Console.WriteLine(sonuc);

            //111'inciders sorusunun çözümü
            //string havaDurumu = "Yağmurlu";
            //Console.WriteLine(havaDurumu=="Yağmurlu" ? "Şemsiye al": 
            //    (havaDurumu=="Güneşli" ? "Bol bol d vitamini al":
            //    "Yağmur yağabilir"));

            //object x = "Dilek";

            //if (x is "Oğuzhan")
            //{
            //    Console.WriteLine(x+"Constant Pattern");
            //}
            //if (x is string a)
            //{
            //    Console.WriteLine(a +"Type Pattern");
            //}

            //if (x is var _x)
            //{
            //    Console.WriteLine(_x +" var pattern");
            //}

            //bool result= x is var o;
            //bool result2 = x is string o2;

            //Console.WriteLine(o);
            //Console.WriteLine(o2);
            //Console.WriteLine(result);

            //try
            //{
            //    int s1 = 0, s2=10;
            //    int a = s2 / s1;
            //}
            //catch (Exception firlatilanHata) //Bu tanımlama yapılırsa hataya dair bilgi alınabilir
            //{

            //    Console.WriteLine("Mesaj :"+firlatilanHata.Message);
            //}
            //int top=1;
            //int x=int.Parse(Console.ReadLine());
            //for (int i = x; i >= 1; i--)
            //{
            //    top *=i;

            //}
            //Console.WriteLine(top);
            //while (true)
            //{
            //    if (DateTime.Now.Second % 5 == 0)
            //    {

            //        Console.WriteLine(  DateTime.Now);
            //    }
            //}

            //            string isim = "Zehra", soyisim="Dilek", tcNo = "21323484";
            //            int yas = 20;
            //            bool medenihal=false;
            //            Console.WriteLine(string.Format($"TC No: {tcNo}" +
            //                $" olan {isim} {soyisim} şahsın bilgileri" +
            //                $" | Yaş: {yas} | Medeni Hal : " +
            //                $"{(medenihal? "Evli": "Bekar")}"));
            //            string d = @"ksjfdsk 
            //sdfsdf 
            //dfdsf
            //sdfsdf";

            //string metin = "Zehra Dilek";
            //string result = metin.ToUpper();
            //Console.WriteLine(result);

            //string text= "Ölüme gidelim dedin de mazot mu yok dedik. ";
            //StringSegment segment = new StringSegment(text);
            //StringSegment segment1= new StringSegment(text, 2,5);
            //Console.WriteLine(segment1);

            //string isim = "Zehra", soyisim = "Diek";
            //StringBuilder builder = new StringBuilder();
            //builder.Append(isim);
            //builder.Append(" ");
            //builder.Append(soyisim);
            //Console.WriteLine(builder.ToString());

            // int[] sayilar = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            // Span<int> span = new Span<int>(sayilar);
            // Span<int> span2 = sayilar; //üsteki ile aynı referansı veriri
            // Span<int> span3 = new Span<int>(sayilar, 3, 5);

            // Span<int> span4=sayilar.AsSpan(); //San türünde br nesne döndürürür //Yukarıda ki yöntemle aynı işlevi gören farklı bir yordamdır
            //Span<int> span5= sayilar.AsSpan(3, 5); // döndürülen nesnnenin belirli aralığını refere eder


            // string text = "Sen kalbimde batan güneş, ben yollarda çilekeş...";
            // ReadOnlySpan<char> readOnlySpan = text.AsSpan(); //Kritik strig türelerde refere edilince ReadOnlySpan döndürür

            string text = "ahmet";
            Regex regex = new Regex(@"a|b|c");
            Match match = regex.Match(text);
            Console.WriteLine(match.Success);





            Console.ReadLine();
        }
    }
}
