using System;

namespace AgirlikHesaplama
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Uzunluk (mm): ");
            double uzunluk = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Genişlik (mm): ");
            double genislik = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Kalınlık (mm): ");
            double kalinlik = Convert.ToDouble(Console.ReadLine());

            AliminyumLevha levha = new AliminyumLevha
            {
                Uzunluk = uzunluk,
                Genislik = genislik,
                Kalinlik = kalinlik,
                Yogunluk = 2.7 // g/cm^3
            };

            double agirlik = HesaplamaServisi.AgirlikHesapla(levha);
            double fiyat = HesaplamaServisi.FiyatHesapla(agirlik, 217.5);

            Console.WriteLine($"Levhanın ağırlığı: {agirlik:F2} kg");
            Console.WriteLine($"Levhanın fiyatı: {fiyat:F2} TL");
            Console.ReadLine();
        }
    }

    public class AliminyumLevha
    {
        public double Uzunluk { get; set; }
        public double Genislik { get; set; }
        public double Kalinlik { get; set; }
        public double Yogunluk { get; set; }
    }

    public static class HesaplamaServisi
    {
        public static double AgirlikHesapla(AliminyumLevha levha)
        {
            // Hacim hesaplama (cm^3 cinsinden)
            double hacim = (levha.Uzunluk / 10) * (levha.Genislik / 10) * (levha.Kalinlik / 10); // cm^3
            return hacim * levha.Yogunluk / 1000; // kg cinsinden ağırlık
        }

        public static double FiyatHesapla(double agirlik, double birimFiyat)
        {
            return agirlik * birimFiyat;
        }
    }
}
