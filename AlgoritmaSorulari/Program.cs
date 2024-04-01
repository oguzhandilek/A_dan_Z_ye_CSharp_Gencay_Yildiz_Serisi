using AlgoritmaSorulari;
using System;

Sorular sorular = new Sorular();
int ilkSayi = 0;
int ikinciSayi = 0;
double topla = default;
string sonuc = default;
#region Soru1-Cevap1


//Console.WriteLine("İlk Sayıyı Giriniz");

//tryAgain1:

//if (!int.TryParse(Console.ReadLine(), out ilkSayi))
//{
//    Console.WriteLine("Lütfen değeri sayısal giriniz");
//    goto tryAgain1;
//}

//tryAgain2:

//Console.WriteLine("İkinci Sayıyı Giriniz");
//if (!int.TryParse(Console.ReadLine(), out ikinciSayi))
//{
//    Console.WriteLine("Lütfen sayısal değer giriniz");
//    goto tryAgain2;
//}


//Console.WriteLine($@"Girilen iki  sayının toplamı: {sorular.Soru(ilkSayi, ikinciSayi)} </>");



#endregion

#region Soru2-Cevap2
//tryAgain1:
//Console.WriteLine("İlk Sayıyı Gİirniz");

//if (!int.TryParse(Console.ReadLine(), out ilkSayi))
//{
//    Console.WriteLine("Lütfen sayısal değer giriniz");
//    goto tryAgain1;
//}
//double _ilksSayi = Math.Pow(ilkSayi, 2);

//tryAgain2:
//Console.WriteLine("İkinci Sayıyı Giriniz");
//if (!int.TryParse(Console.ReadLine(), out ikinciSayi))
//{
//    Console.WriteLine("Lütfen sayısal değer giriniz");
//    goto tryAgain2;
//}
//double _İkinciSayi = Math.Pow(ikinciSayi, 2);

//Console.WriteLine($"{ilkSayi} ile {ikinciSayi} sayılarının kareleri toplamı {sorular.Soru(_ilksSayi, _İkinciSayi)}");

#endregion

#region Soru3-Cevap3
//For Dögüsü ile
//for (int i = 1; i <= 10; i++)
//{
//    topla += Math.Pow(i, 3);

//}
//Console.WriteLine(topla);

//While Dögüsü ile
//string sonuc = default;
//int sayac = 1;
//while (true)
//{
//    topla += Math.Pow(sayac, 3);
//    sonuc += $"{sayac}³ + ";
//    sayac++;
//    if (sayac == 11)
//    {
//        sonuc += $"= {topla}";
//        break;
//    }

//}
//Console.WriteLine(sonuc);

//Do While Döngüsü ile

//do
//{
//    topla += Math.Pow(sayac, 3);
//sayac++;
//} while (sayac < 11) ;
//Console.WriteLine($"Toplam: {topla}");
#endregion

#region Soru4-Cevap4

//Sadece tarih ile
//int dogumTarihi = 0;

//tryAgain:
//Console.WriteLine("Doğum tarihinizi yıl olarak giriniz");
//if (!int.TryParse(Console.ReadLine(),out dogumTarihi))
//{
//    Console.WriteLine("Doğum tarihini yıl olarak giriniz örnek:1992");
//    goto tryAgain;
//}
//int yas = DateTime.Now.Year - dogumTarihi;
//Console.WriteLine($"{yas} yaşındasınız");

//Gün/Ay/Yıl ile
//tryAgain:
//Console.WriteLine("Doğum tarihinizi Gün.Ay.Yıl olarak giriniz");
//DateTime dogumTarihi = new();
//if (!DateTime.TryParse(Console.ReadLine(), out dogumTarihi))
//{
//    Console.WriteLine("Doğum tarhinizi Gün, Ay, Yıl olarak ve aralara nokta koyarak giriniz");
//    goto tryAgain;
//}
//TimeSpan yas = DateTime.Now - dogumTarihi;
//Console.WriteLine($@"{yas.Days/365} yaşındasınız");


#endregion

#region Soru5-Cevap5
// for döngüsü ile
//double carp = 1;
//tryAgain:
//Console.WriteLine("Bir sayı giriniz");
//if (!double.TryParse(Console.ReadLine(), out double sayi))
//{
//    Console.WriteLine("Lütfen sayısal değer giriniz");
//    goto tryAgain;
//}
//for (int i = 1; i <= sayi; i++)
//{
//    carp *= i;
//    sonuc += $"{i.ToString()}.";
//    if (i >= sayi)
//    {
//        sonuc = sonuc.Remove(sonuc.Length-1);
//        sonuc += $"= {carp}";
//    }


//}
//Console.WriteLine(sonuc);

//while döngüsü ile


#endregion