using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanlisCarpma_toplama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //467 ve 21 için sonuç = 391
            //263 ve 18 için sonuç = 2367
            //415 ve 25 için sonuç = 2805
            do
            {
                Hosgeldin();
                int sayi1 = SayiAl();
                int sayi2 = SayiAl();
                if (sayi1 >= sayi2)
                    YanlisCarpveTopla(sayi1, sayi2);
                Console.WriteLine("\n");

            } while (TekrarYap());
            Hoscakal();
            Console.ReadLine();


        }

        static void Hosgeldin()
        {
            Console.WriteLine("yanlış çarpma ve toplama yapan uygulamaya hoşgeldin! ");
        }

        static int SayiAl()
        {

            int sayi;
            do
            {
                Console.WriteLine("sayı gir:");

            } while (!int.TryParse(Console.ReadLine(), out sayi));
            return sayi;


        }

        static int BasamakDegeriBul(int sayi, int basamak)
        {

            int basamakDegeri;
            basamakDegeri = ((sayi % (basamak * 10)) - (sayi % basamak)) / basamak;
            return basamakDegeri;
        }

        static int DiziToplamıBul(int[] dizi)
        {
            int toplam = 0;
            foreach (var item in dizi)
            {
                toplam = +item;
            }
            return toplam;
        }

        static int BasamakSayisiBul(int sayi)
        {

            int j = 0;

            //sayi2'nin basamak sayısı kadar alt alta yazılmış toplama satırı olacağı için sayı2'nin basamak sayısı:
            while (sayi > 0)
            {
                sayi /= 10;
                j++;
            }
            return j;
        }



        static int Max(int[] sayilar)
        {
            int buyuk = sayilar[0];

            for (int i = 0; i < sayilar.Length; i++)
            {
                if (buyuk < sayilar[i])
                { buyuk = sayilar[i]; }
            }
            return buyuk;
        }


        static void TersCevirYaz(int[] dizi)
        {

            int n = dizi.Length;
            int[] yenidizi = new int[n];

            for (int i = 0; i < n; i++)
            {
                yenidizi[n - 1 - i] = dizi[i];
            }
            for (int j = 0; j < n; j++)
            {

                Console.Write(yenidizi[j]);
            }
        }



        public static void YanlisCarpveTopla(int sayi1, int sayi2)
        {
            int[] toplamaSatirlariDizisi = new int[BasamakSayisiBul(sayi2)];

            Console.WriteLine("x___________________");
            for (int i = 0; i < toplamaSatirlariDizisi.Length; i++)
            {
                toplamaSatirlariDizisi[i] = sayi1 * BasamakDegeriBul(sayi2, (int)Math.Pow(10, i));
                Console.WriteLine(toplamaSatirlariDizisi[i]);

            }


            int[] sonucDizisi = new int[BasamakSayisiBul(Max(toplamaSatirlariDizisi))];
            Console.WriteLine("+___________________");


            for (int j = 0; j < sonucDizisi.Length; j++)
            {
                int toplam = 0;
                for (int i = 0; i < toplamaSatirlariDizisi.Length; i++)
                {

                    toplam += BasamakDegeriBul(toplamaSatirlariDizisi[i], (int)Math.Pow(10, j));

                }
                sonucDizisi[j] = toplam % 10;

            }

            TersCevirYaz(sonucDizisi);

        }



        private static bool TekrarYap()
        {
            Console.WriteLine("başka bir işlem yapmak istersen e'ye bas. çıkmak için h'ye bas.");

            string cevap = Console.ReadLine().ToLower();
            switch (cevap)
            {

                case "e":

                    return true;

                case "h":

                    return false;
                default:
                    return TekrarYap();
            }

        }

        private static void Hoscakal()
        {
            Console.WriteLine("güle güle :) ");
        }
    }
}