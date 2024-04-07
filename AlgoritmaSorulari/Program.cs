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
//double carp = 1;
//int sayac=1;
//tryAgain:
//Console.WriteLine("Bir sayı giriniz");
//if (!double.TryParse(Console.ReadLine(), out double sayi ))
//{
//    Console.WriteLine("Lütfen sayısal değer giriniz");
//    goto tryAgain;
//}

//while (true)
//{
//    carp *= sayac;
//    sonuc += $"{sayac}.";
//    sayac++;
//    if (sayac>sayi)
//    {
//        sonuc=sonuc.Remove(sonuc.Length-1);
//        sonuc += $" = {carp}";
//        break;

//    }
//}
//Console.WriteLine(sonuc);

//Do While döngüsü
//double carp = 1;
//int sayac = 1;
//Console.WriteLine("Bir sayı giriniz");
//if (double.TryParse(Console.ReadLine(), out double sayi))
//{
//    do
//    {
//        carp *= sayac;
//        sonuc += $"{sayac}.";
//        sayac++;
//        if (sayac>sayi)
//        {
//            sonuc = sonuc.Remove(sonuc.Length - 1);
//            sonuc += $" = {carp}";
//            break;
//        }
//    } while (true);
//    Console.WriteLine(sonuc);
//}

//Recersive Yaklaşım ile çözüm

//Console.WriteLine("Bir sayı giriniz");
//int sayi = int.Parse(Console.ReadLine());
//Console.WriteLine(Faktoriyel(sayi));
//int Faktoriyel(int sayi)
//{
//    if (sayi>1)
//    {
//        return sayi * Faktoriyel(--sayi);

//    }
//    return sayi;
//}

#endregion

#region Soru6_Cevap6
//Console.WriteLine("İlk sayıyı giriniz");
//ilkSayi = int.Parse(Console.ReadLine());
//Console.WriteLine("İkinci Sayıyı Giriniz");
//ikinciSayi = int.Parse(Console.ReadLine());

//for döngüsü ile
//if (ilkSayi>ikinciSayi)
//{
//   for (int i = 1; i < ikinciSayi; i++)
//{
//    ilkSayi += ilkSayi;
//}
//Console.WriteLine($"Sonuç= {ilkSayi}"); 
//}
//else
//{
//    for (int i = 1; i < ilkSayi; i++)
//    {
//        ikinciSayi += ikinciSayi;
//    }
//    Console.WriteLine($"Sonuç= {ikinciSayi}");
//}


//While döngüsü ile
//int sayac = 1;
//if (ikinciSayi<ilkSayi)
//{
//   while (sayac < ikinciSayi)
//{
//    ilkSayi += ilkSayi;
//    sayac++;
//}
//Console.WriteLine($"Sonuç= {ilkSayi}"); 
//}
//else
//{
//    while (sayac < ilkSayi)
//    {
//        ikinciSayi += ikinciSayi;
//        sayac++;
//    }
//    Console.WriteLine($"Sonuç= {ikinciSayi}");
//}


//Do While ile
//if (ilkSayi>ikinciSayi)
//{
//  do
//{
//    if (ikinciSayi == 1)
//    {
//        break;
//    }
//    ilkSayi += ilkSayi;
//    sayac++;

//} while (sayac < ikinciSayi);
//Console.WriteLine($"Sonuç= {ilkSayi}");  
//}
//else
//{
//    do
//    {
//        if (ilkSayi == 1)
//        {
//            break;
//        }
//        ikinciSayi += ikinciSayi;
//        sayac++;

//    } while (sayac < ilkSayi);
//    Console.WriteLine($"Sonuç= {ikinciSayi}");
//}

//Recursive Fonksiyonu
//Console.WriteLine(Topla(ilkSayi, ikinciSayi));
//int t = 0;
//int a= 0;
//int Topla(int _ilkSayi, int _ikinciSayi)
//{
//    if (_ikinciSayi > 1)
//    {
//        t = Topla(_ilkSayi, --_ikinciSayi);
//        a=_ilkSayi+t;
//        return a;
//    }
//    return _ilkSayi;
//}
//Console.ReadLine();
#endregion

#region Soru7-Cevap7

//Console.WriteLine("Bölmek istediğiniz sayıyı giriniz");
//ilkSayi = int.Parse(Console.ReadLine());
//Console.WriteLine("Bölüm Değerini Giriniz");
//ikinciSayi = int.Parse(Console.ReadLine());

//for döngüsü ile
//int sayac = 0;

//for (int i = 0; i < ilkSayi; i++)
//{
//    ilkSayi -= ikinciSayi;
//    sayac++;
//    if (ilkSayi < ikinciSayi)
//        break;
//}
//Console.WriteLine(sayac);

//Recursive Yaklaşımı ile çözüm;
//Console.WriteLine(Bol(ilkSayi,ikinciSayi));
//int Bol(int _ilkSayi, int _ikinciSayi)
//{
//    _ilkSayi -= _ikinciSayi;
//    if (_ilkSayi>=_ikinciSayi)
//    {
//        return 1+Bol(_ilkSayi, _ikinciSayi);

//    }
//    return 1;
//}

#endregion

#region Soru8-Cevap8
//Console.WriteLine("Lütfen basamak sayısını Öğrenmek İstediğiniz sayıyı giriniz.");
//float sayi=float.Parse(Console.ReadLine());
//int basamak = 1;
//For Döngüsü ile
//for (int i = 1; sayi >=10; i++)
//{
//    sayi /= 10;
//    basamak = i;
//}
//Console.WriteLine(basamak+1);

//While ile
//while(sayi>=10)
//{
//    sayi /= 10;
//    basamak++;

//}
//Console.WriteLine(basamak+1);

//Do While ile
//do
//{
//    if (sayi<10)
//    {
//        break;
//    }
//    sayi /= 10;
//    basamak++;

//} while (true);
//Console.WriteLine(basamak);

//Recursive Yaklaşım İle Çözümü
//Console.WriteLine(Basamak(sayi));
//float Basamak(float sayi)
//{
//    sayi /= 10;
//    if (sayi >= 10)
//    {
//        return 1 + Basamak(sayi);
//    }
//    return 2;
//}

//String Uzunluk değeri ile Çözüm
//string _basamak =sayi.ToString();
//Console.WriteLine(_basamak.Length);

//Console.WriteLine(sayi.ToString().Length); // Senior Çözüm :))

#endregion

#region Soru9-Cevap9
Console.WriteLine("3 basamaklı bir sayı giriniz");
int sayi = int.Parse(Console.ReadLine());

if (Basamak(sayi))
{
    int _sayi = sayi;
    while (true)
    {
        int basamak = _sayi % 10;
        _sayi /= 10;
        topla += Math.Pow(basamak, 3);
        if (_sayi < 10)
        {
            basamak = _sayi % 10;
            topla += Math.Pow(basamak, 3);
            break;
        }

    }
    if (topla == sayi)
    {
        Console.WriteLine("Eşittir");
    }
    else
    { Console.WriteLine("Eşit değildir"); }
}
bool Basamak(int sayi)
{
    int basamak = 1;
    while (sayi >= 10)
    {
        sayi /= 10;
        basamak++;
    }
    return basamak == 3 ? true : false;
}


#endregion