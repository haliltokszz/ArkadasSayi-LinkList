using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadasSayi_LinkList
{
    class Program
    {
        static LinkedList dizi = new LinkedList();

        public static bool KontrolEtveEkle(int deger)
        {
            bool eklenebilirMi = true;
            if (dizi.Size != 0)
            {
                Node veri = dizi.Head;
                while (veri != null)
                {
                    if (veri.Data == deger)
                    {
                        Console.WriteLine("Lütfen farklı bir sayı giriniz. Eklemek istediğiniz sayı LinkedList'te bulunmaktadır.");
                        eklenebilirMi = false;
                        return false;
                    }
                    veri = veri.Next;
                }
                if (eklenebilirMi)
                    dizi.InsertFirst(deger);
            }
            else
                dizi.InsertFirst(deger);
            return true;
        }
        public static void ArkadasSayi(LinkedList dizi) { 
        //worst-case Big(O) karmaşıklığı = O(n^3) fakat en kötü durumda 4*n+5*n denemede buluyoruz (n= sayı değeri)
        //fonksiyon öncelikle döngüden sayıların bölenlerinin toplamını buluyor. Ardından dizinin içinde bu toplama eşit bir sayı olup olmadığını kontrol ediyoruz
        //eğer varsa direk o sayının da bölenlerinin toplamını bulup arkdaş sayı olup olmadıklarını kontrol ediyoruz böylece daha hızlı sonuç almak mümkün oluyor...
            for (int i=1; i<=dizi.Size; i++)
            {
                
                int headPos = 1;
                int toplam=0, bolen=1;
                Node node = dizi.GetElement(i);
                Node temp = dizi.Head;
                while (bolen < node.Data) //kendisi hariç bölenleri
                {
                    if (node.Data % bolen == 0) //tam bölünüyorsa bölen toplama eklenir
                        toplam += bolen;
                    bolen++;
                }
                while (temp!=null)//dizi sınırları içinde geziyoruz
                {
                    if (temp.Data == toplam)//eğer dizinin içindeki bir sayı bölenlerin toplamına eşitse
                    {
                        int toplam2 = 0, bolen2 = 1;
                        while (bolen2 < temp.Data) //kendisi hariç bölenleri
                        {
                            if (temp.Data % bolen2 == 0) //tam bölünüyorsa bölen toplama eklenir
                                toplam2 += bolen2;
                            bolen2++;
                        }
                        if(toplam2== node.Data)//eğer ikinci sayının bölenler toplamı da birinci sayıya eşitse arkadaş sayılardır 
                        {
                            dizi.DeletePos(i);
                            dizi.DeletePos(headPos-1);
                            dizi.InsertPos(headPos-1, node.Data);
                            dizi.InsertPos(i, temp.Data);
                            return;
                        }
                    }
                    temp = temp.Next; //eger değilse ilerliyoruz ve headPos' u arttırıyoruz...
                    headPos++;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("5 farklı tam sayı içerisindeki 2 arkadaş sayıyı bulur ve yerlerini değiştirir.");
            Console.WriteLine("Lütfen ekrana 5 farklı tam sayı giriniz...");
            for(int i=0; i<5; i++)
            {
                if (KontrolEtveEkle(Convert.ToInt32(Console.ReadLine())) == false)
                {
                    i--;
                }
            }
            Console.WriteLine(dizi.DisplayElements());
            ArkadasSayi(dizi);
            Console.WriteLine(dizi.DisplayElements());
            Console.Read();
        }
    }
}
