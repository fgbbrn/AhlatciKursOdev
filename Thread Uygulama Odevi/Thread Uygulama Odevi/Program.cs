using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace ThreadUygulamaOdev
{
    public class Program
    {
        static ConcurrentQueue<string> sira = new ConcurrentQueue<string>();

        public static void Main(string[] args)
        {
            Thread dosyaOkumaThread = new Thread(DosyaOkumaYap);
            dosyaOkumaThread.Start();

            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(YazdirmaYap);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            dosyaOkumaThread.Join();

            Console.WriteLine("İşlem tamamlandı. Çıktılar:");

            foreach (string item in sira)
            {
                Console.WriteLine(item);
            }
        }

        public static void YazdirmaYap()
        {
            while (sira.TryDequeue(out string oge))
            {
                Console.WriteLine("Çıkarılan öge: " + oge + ", İş parçacığı: " + Thread.CurrentThread.ManagedThreadId);
            }
        }

        public static void DosyaOkumaYap()
        {
            string dosyaSonuc = "dosya.txt";

            using (StreamReader sr = new StreamReader(dosyaSonuc))
            {
                string satir;
                while ((satir = sr.ReadLine()) != null)
                {
                    string[] ogeler = satir.Split(' ');

                    foreach (string oge in ogeler)
                    {
                        sira.Enqueue(oge);
                    }
                }
            }
        }
    }
}