using System;

class Program
{
    static void Main()
    {
        bool devamEt = true;

        while (devamEt)
        {
            //  Kullanıcıdan gitmek istediği lokasyonu alma
            string lokasyon = GetLokasyon();

            // Kullanıcıdan kişi sayısını alma
            int kisiSayisi = GetKisiSayisi();

            //  Lokasyon hakkında bilgi verme
            ShowLokasyonInfo(lokasyon);

            //  Kullanıcıya ulaşım tercihini sorma
            int ulasimSecimi = GetUlasimSecimi();

            //  Toplam fiyatı hesaplama
            decimal toplamFiyat = HesaplaToplamFiyat(lokasyon, kisiSayisi, ulasimSecimi);

            //  Kullanıcıya toplam fiyatı gösterme
            Console.WriteLine($"Toplam Fiyat: {toplamFiyat} TL");

            //  Başka bir tatil planlamak isteyip istemediğini sorma
            devamEt = SorDevamEtmekIsterMisiniz();
        }

        Console.WriteLine("İyi günler dileriz!");
    }

    // Lokasyon seçimi
    static string GetLokasyon()
    {
        string lokasyon;

        Console.WriteLine("Lütfen gitmek istediğiniz lokasyonu giriniz (Bodrum, Marmaris, Çeşme):");
        lokasyon = Console.ReadLine().ToLower(); // Kullanıcı girdisini küçük harf

        // Lokasyon doğrulaması
        while (lokasyon != "bodrum" && lokasyon != "marmaris" && lokasyon != "çeşme")
        {
            Console.WriteLine("Geçersiz lokasyon! Lütfen Bodrum, Marmaris veya Çeşme'den birini seçin.");
            lokasyon = Console.ReadLine().ToLower();
        }

        return lokasyon;
    }

    // Kişi sayısı
    static int GetKisiSayisi()
    {
        int kisiSayisi;

        Console.WriteLine("Kaç kişi için tatil planlamak istiyorsunuz?");
        while (!int.TryParse(Console.ReadLine(), out kisiSayisi) || kisiSayisi <= 0)
        {
            Console.WriteLine("Geçersiz kişi sayısı! Lütfen geçerli bir sayı girin.");
        }

        return kisiSayisi;
    }

    // Lokasyon hakkında bilgi verme
    static void ShowLokasyonInfo(string lokasyon)
    {
        if (lokasyon == "bodrum")
        {
            Console.WriteLine("Bodrum - Yunan adalarına yakınlığı ve eşsiz plajları ile ünlüdür.");
        }
        else if (lokasyon == "marmaris")
        {
            Console.WriteLine("Marmaris - Mavi yolculuklar ve doğa yürüyüşleri ile ünlüdür.");
        }
        else if (lokasyon == "çeşme")
        {
            Console.WriteLine("Çeşme - Rüzgar sörfü ve deniz sporları ile ünlüdür.");
        }
    }

    // Ulaşım seçenek
    static int GetUlasimSecimi()
    {
        int secim;

        Console.WriteLine("Lütfen ulaşım tercihinizi seçiniz:");
        Console.WriteLine("1 - Kara yolu (Kişi başı 1500 TL)");
        Console.WriteLine("2 - Hava yolu (Kişi başı 4000 TL)");

        while (!int.TryParse(Console.ReadLine(), out secim) || (secim != 1 && secim != 2))
        {
            Console.WriteLine("Geçersiz seçenek! Lütfen 1 veya 2 giriniz.");
        }

        return secim;
    }

    // Toplam fiyat
    static decimal HesaplaToplamFiyat(string lokasyon, int kisiSayisi, int ulasimSecimi)
    {
        decimal lokasyonFiyati = 0;
        decimal ulasimFiyati = (ulasimSecimi == 1) ? 1500m : 4000m; 

        if (lokasyon == "bodrum")
        {
            lokasyonFiyati = 4000m;
        }
        else if (lokasyon == "marmaris")
        {
            lokasyonFiyati = 3000m;
        }
        else if (lokasyon == "çeşme")
        {
            lokasyonFiyati = 5000m;
        }

        // Toplam fiyat
        return (lokasyonFiyati + ulasimFiyati) * kisiSayisi;
    }

    // baska tatil
    static bool SorDevamEtmekIsterMisiniz()
    {
        Console.WriteLine("Başka bir tatil planlamak ister misiniz? (Evet için 'E', Hayır için 'H' tuşlayın)");
        string cevap = Console.ReadLine().ToLower();

        if (cevap == "e")
        {
            return true;
        }
        else if (cevap == "h")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Geçersiz cevap! Program sonlandırılıyor.");
            return false;
        }
    }
}


