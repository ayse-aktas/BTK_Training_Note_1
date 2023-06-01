using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;

#region
/*Kısayollar
 * Crtl + Tab:açık dosyalar arasında gezilebilir.
 * Tab :başını yazdığın ifadeyi tamamlamak için kullanılır.
 * cw +Tab : Console.WriteLine(); ifadesini yazdırır.
 * Crtl + . : Bir kod parçasını iyileştirmemize ve method haline getirmemizi sağlar.
 * Bir methodun hemen üstünde "///" bu şekilde üç kez üstüste basarsak otomatik açıklama satırları oluşur.
 * Tanımladığımız struct içerisinde "prop" yazıp iki kez tab yaparsak özellik otomatik oluşur.
 * Ctrl + Shift + V :Geçmişte kopyaladıklarımızın listesi.
 */

//*get :okuma* set :yazma
//Console.WriteLine(new string('-',25)); : 25 adet - çizgi oluşturur.
//Generic'ler tasarlandığımız interface, class, metod yada parametrelerin (argümanların) belirli bir tip için değil bir şablon yapısına uyan her tip için çalışmasını sağlayan bir yapıdır.
// Console.Write(...); : Yazıları yan yana yazmayı sağlar.
// Console.WriteLine(...); : Yazıları alt alta yazmayı sağlar.
// IsDigit(n) :rakam mı kontrol eder. 
// Convert.ToInt16(Console.ReadLine()); //Convert.ToInt16 ile girilen string deger int e donusturuluyor  
// Console.WriteLine(isim.KeyChar); //Örneğin, kullanıcı SHIFT + K tuşlarına basarsa, bu özellik büyük bir K döndürür.
// Console.ReadKey();//Kullanıcı bir tuşa basana ve uygulama sonlandırana veya ek bir bilgi penceresi görüntüleyene kadar program yürütmeyi durdurmaktır. 
// Console.WriteLine(isim.Key); //
// var: tipi kendisi belirler.Örtülü değişken
// GetType:Veri tipini belirler. 
// * \n: alt satıra geçer. * \t: bir tab boşluk bırakır. * \a: bir uyarı sesi verir. 
// Console.Write("{0,5},{1,-2}", d1, d2); // 1. değişkeni için 5 lik yer ayırır ve sağa yapışık yazar, 2.değişkeni için 2 lik yer ayırır ve sola yapışık yazar. 

/* SortedList 
 *  System.Collections sınıfı altında yer alır.
 *  Non-generic(Object) ->boxing||unboxing kullanılır.
 * Key-Value pairs
 * Key'e  göre sıralama yapılır.Ekleme sırasında yapılır.
 * Sıralı şekilde organize edilir
 * Hem Key(anahtar) hem de indisle elemanlara erişebilir.
 * IndexofKey - IndexofValue - GetKey - GetByIndex
 * IComparer
 */

/*Hashtable
 *  System.Collections sınıfı altında yer alır.
 *  Non-generic ->boxing||unboxing kullanılır.
 *  indisleme yok
 *  key - value pairs -> anahtar - değer
 *  key - value-> ICollection Ara yüzünü kullanırlar. (Interface|Arayüz)
 *  Anahtar -> Contain Key
 *  Değer -> Contain Value
 *  Anahtarlar tekil olmalıdır.
 */

/*List<T> 
 * System.Collections sınıfı altında yer alır.
 * Array -> ArrayList(Object)||boxing|unboxing -> List<T>|Type 
 * Tip güvenliği generic liste ile sağlanır.
 * Add() - AddRange() - Remove() - RemoveRange() - Count() -Capacity()
 * ***Interface(Arayüz)
 * ->Kontratları devr alır  (Kalıtım-Inheritance)
 * C# ->class(inheritance)
 */

/*Stack<T>
 * System.Collections sınıfı altında yer alır.
 * Generic yapıdadır.
 * T-> Type(tip)->Stack(int),Stack(string)
 * Last-ın Firs-out,LIFO - Son gelen ilk çıkar.
 *------------------------------------------------
 * KULLANILABİLECEK FONKSİYONLAR
 * push()-Ekleme
 * pop()-Çıkarma
 * peek()-Top(en üsteki elemanı alma)
 * clear()- Temizleme
 * count()-Eleman sayısını alma
 * ToArray()-Diziye çevirme
 * -----------------------------------------------
 * KULLANILDIĞI YERLER
 * Fonksiyon çağrıları ve özyinelemeli(recursive)
 * En son kullanılan uygulamaları listesi
 * Sözdizilimi hatalarını yakalamak üzere
 * Geri izleme işleme
 * Ayrıştırma
 * Ters çevirme işlemlerinde
 * Hafıza yönetimi
 * Tarayıcı sekmelerinde
 */

/*Queue<T>  (kuyruk yapısı)
 * System.Collections.Generic sınıfı altında yer alır.
 * Generic 
 * T-> Type(tip)
 * First() - In First-Out (İlk gelen ilk çıkar.)
 *---------------------------------------------------------
 * KULLANILABİLECEK FONKSİYONLAR
 * Enque() - Eleman Ekleme
 * Deque() - Eleman Çıkartma
 * Peek()  - işlem görecek yapı (top)
 * Count   - Eleman sayısı
 * clear() -temizleme 
 * --------------------------------------------------------
 * KULLANILDIĞI YERLER
 * İşletim sitemlerinde çalışma önceliği belirlenmesinde
 * Ağ yazıcılarında
 * Mesaj kuyruklarında
 * Buffer(tampon)
 */

/* LinkedList<T> (bağlı liste|bağlantılı liste)
 * System.Collections.Generic sınıfı altında yer alır.
 * Generic 
 * Doğrusal bir veri yapısıdır.Veriler sıralı değildir.
 * Düğümler içerir.(işaretçi||prevous)[veri][işaretçi(next)]...(işaretçi||prevous)[veri][işaretçi(next)]->düğüm örneği.Kendisinden önceki elemanı işaret eder.  
 *                                            |First|                                   |Last|
 * Dinamiktir.Boyutu kullanırken büyüyüp küçülebilir.
 * Array ile kıyaslandığında daha performanslı çalıştığı söylenebilir.
 *---------------------------------------------------------
 * KULLANILABİLECEK FONKSİYONLAR
 * AddFirst
 * AddLast
 * First
 * Last
 * Remove
 * RemoveFirst
 * RemoveLast
 * AddBefore
 * AddAfter 
 */

/*Dictionary<TKey,TValue>
 * System.Collections.Generic sınıfı altında yer alır.
 * Generic - > type-safe
 * TKey    - >   TValue      pains
 * |Anahtar|    |Değer|      |Çift|
 * TKey -> Benzersiz olmak zorunda.
 * TValue-> İstediğimiz değeri saklayabilir.
 * Hashtable ile kıyaslandığında daha performanslı çalıştığı söylenebilir.
 */

/*SortedDicitonary<TKey,TValue>  
 * System.Collections.Generic sınıfı altında yer alır.
 * Dictionary sınıfında kullanılan methodların tamamı bu koleksiyon için de kullanılabilir.
 * TKey(Anahtar) - TValue(Değer) pairs(çifti)  göre çalışır.
 * Ekleme adımında sıralama işlemi yapıldığından bir miktar performans kaybı gözlemlenebilir.
 * Sıralama işlemi TKey ifadesine göre yapılır.
 */

/*SortedSet<T>
 * System.Collections.Generic sınıfı altında yer alır.
 * Generic - > type-safe
 * Elemanları benzersiz olmalıdır.
 * Sıralı->Sıralama ekleme sırasında yapılır.
 * Dinamiktir.Boyutu kullanırken büyüyüp küçülebilir.
 * --------------------------------------------------
 * KULLANILABİLECEK FONKSİYONLAR
 * Add() - ekleme (bool değer döner.)
 * Remove() - silme 
 * RemoveWhere(preducate|Koşul(lambda)|) - koşula bağlı silme yapar.
 * A.UnionWith(B) -> A ve B kümelerinin birleşimindeki elemanlar.
 * A.IntersectWith(B) -> A ve B kümelerinin kesişimindeki elemanlar.
 * A.ExceptWhith(B) -> Yanlızca A kümesi elemanları.
 *  A.SymmetricExceptWith( B ) ->Yanlızca A kümesi ve yanlızca B kümesi elemanlarının birleşimi.
 * -----------------------------------------------------------------
 * KULLANILDIĞI ALANLAR
 * Kesişim,Birleşim,Ayırım,Altkümeler...(Kümelerde kullanabilir.) 
 */

/*HashSet<T>
 * System.Collections.Generic sınıfı altında yer alır.
 * Generic - > type-safe
 * Elemanlar benzersiz.
 * Sıralama yok!!!
 * Küme işlemlerine izin verir.
 * SortedSet'teki çoğu fonksiyon kullanılır.
 */
#endregion

namespace BTKakademi
{
    public class Sehir : IComparable<Sehir>
    {
        public int PlakaNo { get; set; }
        public string SehirAdi { get; set; }
        public Sehir(int plakaNo, string sehirAdi)
        {
            PlakaNo = plakaNo;
            SehirAdi = sehirAdi;
        }
        public override string? ToString()
        {
            return $"{PlakaNo,-5} {SehirAdi,-20}";
        }

        public int CompareTo(Sehir other) //Plaka no ya göre sıralama işlemi
        {
            if (this.PlakaNo < other.PlakaNo)
            {
                return -1;
            }
            else if (this.PlakaNo == other.PlakaNo)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
    partial class Program
    {
        public struct Nokta
        {
            public int X { get; set; }
            public int Y { get; set; }
            public override string ToString()
            {
                return $"{X},{Y}";
            }
            //Default ctor
            public Nokta(int x, int y)
            {
                X = x;
                Y = y;
            }
            //Yapımıza yeni üye -> Metot
            public void SetOrigin()
            {
                X = 0;
                Y = 0;
            }
            public void Degistir()
            {
                var gecici = X;
                X = Y;
                Y = gecici;
            }

        }
        enum Islemler //SwicthCaseYapisi için
        {
            Toplama = 1,
            Cikarma,
            Carpma,
            Bolme
        }
        static void Main(string[] args)
        {  
        }
        #region ÖRNEKLER
        private static void HashSet_1()
        {
            //HashSet
            var sesliHarf = new HashSet<char>()
            {
                'e','i','ı','u','ü','o','ö','b'
            };
            //Ekleme
            sesliHarf.Add('a');
            //Çıkarma
            sesliHarf.Remove('b');
            foreach (char ch in sesliHarf)
            {
                Console.Write($"{ch,-3}");
            }
            Console.WriteLine();
            Console.WriteLine("Eleman sayisi: {0}", sesliHarf.Count);

            var alfabe = new List<char>();
            for (int i = 97; i < 123; i++)
            {
                alfabe.Add((char)i);
            }
            foreach (char ch in alfabe)
            {
                Console.Write($"{ch,-3}");
            }
            Console.WriteLine();
            Console.WriteLine("Eleman sayisi: {0}", alfabe.Count);
            //Türkçe'de kullanılan sesli harfler
            sesliHarf.ExceptWith(alfabe);
            foreach (char ch in sesliHarf)
            {
                Console.Write($"{ch,-3}");
            }
            Console.WriteLine();
            Console.WriteLine("Eleman sayisi: {0}", sesliHarf.Count);

            sesliHarf.UnionWith(alfabe);
            foreach (char ch in sesliHarf)
            {
                Console.Write($"{ch,-3}");
            }
            Console.WriteLine();
            Console.WriteLine("Eleman sayisi: {0}", sesliHarf.Count);

            Console.ReadKey();
        }
        private static void SortedListKumeIslemleri()
        {
            //SortedList Küme işlemleri
            var A = new SortedSet<int>(RastgeleSayiUret(10));
            var B = new SortedSet<int>(RastgeleSayiUret(10));
            #region yazdirma
            Console.WriteLine();
            Console.WriteLine("    A kümesi ");
            foreach (int s in A)
            {
                Console.Write($"{s,-5}");
            }
            Console.WriteLine();
            Console.WriteLine("    B kümesi ");
            foreach (int s in B)
            {
                Console.Write($"{s,-5}");
            }
            Console.WriteLine();
            #endregion

            //Union

            // A.UnionWith(B); //   A ve B Kümesinin Birleşimi 
            //A.Intersect( B );//  A ve B Kümesinin Kesişimi
            //A.Except( B );   //Sadece A  
            A.SymmetricExceptWith(B);//Kesişim Dışındaki Elemanlar

            Console.WriteLine("    Kesişim Dışındaki Elemanlar  ");
            foreach (int s in A)
            {
                Console.Write($"{s,-5}");
            }
            Console.WriteLine();
            Console.WriteLine("\nToplam sayisi: {0}", A.Count);


            Console.WriteLine();
            Console.ReadKey();
        }
        static List<int> RastgeleSayiUret(int n)
        {
            var list = new List<int>();
            var r = new Random();
            for (int i = 0; i < n; i++)
                list.Add(r.Next(0, 10));
            return list;
        }
        private static void SortedSetUygulamasi_2()
        {
            //SortedSet
            var sayilar = new List<int>();
            var r = new Random();

            for (int i = 0; i < 100; i++)
            {
                sayilar.Add(r.Next(0, 10));//0 dahil 10 dahil değil 0-10 arasındaki sayıları ekliyor.
                Console.WriteLine($"{sayilar[i],-3} eklendi.");
            }
            Console.WriteLine();

            //Listedeki benzersiz elemanları bulmak
            var benzersizSayiListesi = new SortedSet<int>(sayilar);
            Console.WriteLine("Benzersiz Sayı Listesi");

            foreach (int b in benzersizSayiListesi)
            {
                Console.Write($"{b,-3}");
            }
            Console.WriteLine();
            Console.WriteLine("Benzersiz {0} adet sayi var", benzersizSayiListesi.Count);

            Console.ReadKey();
        }
        private static void SortedSetUygulamasi()
        {
            //SortedSet
            //Tanımlama
            var list = new SortedSet<string>();

            //Ekleme
            if (list.Add("Ayşe"))
            {
                Console.WriteLine("Ayşe eklendi.");
            }
            else
            {
                Console.WriteLine("Ayşe eklenemedi.");
            }
            Console.WriteLine("{0}", list.Add("Ahmet") == true ? "Ahmet eklendi." : "Ahmet eklenemedi.");
            if (list.Add("Ayşe"))
            {
                Console.WriteLine("Ayşe eklendi.");
            }
            else
            {
                Console.WriteLine("Ayşe eklenemedi.");
            }
            list.Add("Sule");
            list.Add("Neslihan");
            list.Add("Fahrettin");
            list.Add("Fatih");
            list.Add("Semih");

            //Çıkarma
            list.Remove("Sule");

            //Koşullu toplu çıkarma
            list.RemoveWhere(deger => deger.Contains("A"));
            list.RemoveWhere(deger => deger.StartsWith("F"));

            //Dolaşma
            Console.WriteLine("---------------------------");
            Console.WriteLine("\nİsimler Listesi\n");
            foreach (string i in list)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Eleman sayısı  :  {0}", list.Count);
            Console.ReadKey();
        }
        private static void SortedDicitonaryUygulaması()
        {
            //SortedDicitonary<TKey,TValue>  
            var kitapIndex = new SortedDictionary<string, List<int>>()
            {
                {"HTML",new List<int> {3,5,7} },
                {"CSS",new List<int> {70,80,90} },
                {"jQuery",new List<int> {3,5,15} },
                {"SQL",new List<int> {70,80} }
            };
            //Ekleme
            kitapIndex.Add("FTP", new List<int>() { 3, 5, 7 });
            kitapIndex.Add("ASP.NET", new List<int>() { 50, 60 });

            //dolaşma
            foreach (var kavram in kitapIndex)
            {
                Console.WriteLine(kavram.Key);
                foreach (int s in kavram.Value)
                {
                    Console.WriteLine($"\t > {s,-4} pp");
                }
            }
            Console.ReadKey();
        }
        private static void DictionaryUygulama()
        {
            //Dictionary
            var PersonelListesi = new Dictionary<int, Personel>()
            {
                {110,new Personel("Ayse","Aktas",999999999)},
                {120,new Personel("Fatma","Mertep",7054)},
                {130,new Personel("Beren","Kaplan",10000)},
            };

            PersonelListesi.Add(100, new Personel("Zeynep", "Coşkun", 5000));
            //Dolasma
            Console.WriteLine(" No    Adi       Soyadi          Maas      ");
            foreach (var p in PersonelListesi)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();
        }
        private static void DictionaryTemelleri()
        {
            //Dictionary
            var telefonKodlari = new Dictionary<int, string>()
            {
                {332,"Konya"},
                {424,"Elazığ"},
                {466,"Art"},
                {447,"Malatya"}
            };

            //Ekleme
            telefonKodlari.Add(322, "Adana");
            telefonKodlari.Add(212, "İstanbul");
            telefonKodlari.Add(216, "İstanbul");

            //Erişme
            telefonKodlari[466] = "Artvin";
            //telefonKodlari[46] = "Muş";

            //ContainKey
            if (!telefonKodlari.ContainsKey(312))
            {
                Console.WriteLine("\aAnkara'nın kod bilgisi tanimli degil!");
                telefonKodlari.Add(312, "Ankara");
                Console.WriteLine("Yeni kod eklendi.");
            }

            //ContainsValue
            if (!telefonKodlari.ContainsValue("Malatya"))
            {
                Console.WriteLine("\aMalatya'nın kod bilgisi tanimli degil!");
                telefonKodlari.Add(447, "Malatya");
                Console.WriteLine("Yeni kod eklendi.");
            }

            //Çıkarma
            telefonKodlari.Remove(322);

            //Dolaşma
            foreach (var s in telefonKodlari)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
        private static void LinkedListTemelleri()
        {
            //LinkedList<T> Temelleri
            //Tanımlama
            var sehirler = new LinkedList<string>();
            sehirler.AddFirst("Ordu");
            sehirler.AddFirst("Trabzon");
            sehirler.AddLast("İstanbul");

            sehirler.AddAfter(sehirler.Find("Ordu"), "Samsun");
            sehirler.AddBefore(sehirler.First.Next.Next, "Giresun");
            sehirler.AddAfter(sehirler.Last.Previous, "Sinop");
            sehirler.AddAfter(sehirler.Find("Sinop"), "Zonguldak");

            Console.WriteLine("Gidiş Güzergahı");
            Console.WriteLine("-----------------------");
            var eleman = sehirler.First;
            while (eleman != null)
            {
                Console.WriteLine(eleman.Value);
                eleman = eleman.Next;
            }

            Console.WriteLine();
            Console.WriteLine("Dönüş Güzergahı");
            Console.WriteLine("-----------------------");
            var gecici = sehirler.Last;
            while (gecici != null)
            {
                Console.WriteLine(gecici.Value);
                gecici = gecici.Previous;
            }
            Console.ReadKey();
        }
        private static void QueueUygulamasi()
        {
            var sesliHarfler = new List<char>()
            {
                'a','e','ı','i','u','ü','o','ö'
            };
            var kuyruk = new Queue<char>();
            ConsoleKeyInfo secim;
            foreach (char k in sesliHarfler)
            {
                Console.WriteLine($"{k} elemanını kuyruk'a eklensin mi?(e/h) ");
                secim = Console.ReadKey();
                if (secim.Key == ConsoleKey.E)
                {
                    kuyruk.Enqueue(k);
                    Console.WriteLine($"\n{k,5} kuyruğa eklendi.");
                    Console.WriteLine($"Kuyruktaki eleman sayisi : {kuyruk.Count}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Kuyruktan elemanlarin kaldırılması işlemi için ESC tuşuna basınız.");
            Console.WriteLine();
            secim = Console.ReadKey();
            if (secim.Key == ConsoleKey.Escape)
            {
                while (kuyruk.Count > 0)
                {
                    Console.WriteLine($"{kuyruk.Peek(),5} kuyruktan çıkartılıyor.");
                    Console.WriteLine($"{kuyruk.Dequeue(),5} kuyruktan çıkartıldı.");
                    Console.WriteLine($"Kuyruktaki eleman sayisi : {kuyruk.Count}");
                }
                Console.WriteLine("\nKuyruktan çıkarma işlemi tamamlandı.");
            }
            Console.WriteLine("Program bitti.");
            Console.ReadKey();
        }
        private static void KuyrukTemelleriOrnegi()
        {
            //Queue 
            //Tanımlama
            var karakterKuyrugu = new Queue<char>();
            //Ekleme
            karakterKuyrugu.Enqueue('a');
            karakterKuyrugu.Enqueue('e');
            Console.WriteLine($"Eleman sayısı : {karakterKuyrugu.Count}");
            var dizi = karakterKuyrugu.ToArray();

            Console.WriteLine($"Kuyrugun başındaki eleman: {karakterKuyrugu.Peek()}");
            //Çıkarma
            Console.WriteLine($"{karakterKuyrugu.Dequeue()} karakteri çıkartıldı.");
            Console.WriteLine($"{karakterKuyrugu.Dequeue()} karakteri çıkartıldı.");
            Console.WriteLine($"Eleman sayısı : {karakterKuyrugu.Count}");

            Console.ReadKey();
        }
        private static void StackUygulamasi()
        {
            var sayiYigini = new Stack<int>();
            Console.Write("Sayı Giriniz: ");
            int sayi = Convert.ToInt32(Console.ReadLine());

            while (sayi > 0)
            {
                int k = sayi % 10;
                sayiYigini.Push(k);
                sayi = sayi / 10;
            }
            int i = 0;
            int n = sayiYigini.Count - 1;
            foreach (var s in sayiYigini)
            {
                Console.WriteLine($"{s,7} x {Math.Pow(10, n - i),-7} = {s * Math.Pow(10, n - i),-7}");
                i++;
            }
            Console.ReadKey();
        }
        private static void KarakterYiginiOrnegi()
        {
            var karakterYigini = new Stack<char>();
            for (int i = 65; i <= 90; i++)
            {
                karakterYigini.Push((char)i);
                Console.WriteLine($"{karakterYigini.Peek()} yığına eklendi.");
                Console.WriteLine($"Yığındaki eleman sayısı: {karakterYigini.Count}");
            }
            //Ek bilgi
            var dizi = karakterYigini.ToArray();

            Console.WriteLine("Yığından çıkartma işlemi için bir tuşa basınız");
            Console.ReadKey();
            Console.WriteLine();
            while (karakterYigini.Count > 0)
            {
                Console.WriteLine($"{karakterYigini.Pop()} yığından çıkartıldı.");
                Console.WriteLine($"Yığındaki eleman sayısı: {karakterYigini.Count}");
            }
            Console.ReadKey();
        }
        private static void YiginOrnegi()
        {
            //Stack tanımlama
            var karakterYigini = new Stack<char>();
            //Ekleme
            karakterYigini.Push('A');
            Console.WriteLine(karakterYigini.Peek());
            karakterYigini.Push('B');
            Console.WriteLine(karakterYigini.Peek());
            karakterYigini.Push('C');
            Console.WriteLine(karakterYigini.Peek());
            //Çıkarma
            Console.WriteLine(karakterYigini.Pop() + " yığından çıkartıldı.");
            Console.WriteLine(karakterYigini.Pop() + " yığından çıkartıldı.");
            Console.WriteLine(karakterYigini.Pop() + " yığından çıkartıldı.");
            Console.ReadKey();
        }
        private static void IComparableImplementas()
        {
            //List
            var sayilar = new List<int>() { 53, 40, 14, 2, 3, 12, 15 };
            sayilar.Sort();
            sayilar.ForEach(s => Console.WriteLine(s));
            Console.WriteLine("********************************");

            //Şehir Listesi
            var sehirler = new List<Sehir>()
            {
                new Sehir(6,"Ankara"),
                new Sehir(34,"İstanbul"),
                new Sehir(55,"Samsun"),
                new Sehir(23,"Elazığ"),
                new Sehir(42,"Konya")
            };
            sehirler.Add(new Sehir(1, "Adana"));
            sehirler.Sort();
            sehirler.ForEach(s => Console.WriteLine(s));
            Console.ReadKey();
        }
        private static void SortedList_1()
        {
            //SortedList - Temeller
            var list = new SortedList()
            {
                {1, "Bir" },
                {2, "İki" },
                {3, "Üç" },
                {8, "Sekiz" },
                {5, "Beş" },
                {6, "Altı" },
            };

            list.Add(4, "Dört");
            list.Add(7, "Yedi");

            //Dolaşma
            foreach (DictionaryEntry i in list)
            {
                Console.WriteLine($"{i.Key,-5} - {i.Value,-20}");
            }

            Console.WriteLine("Lisredeki eleman sayısı : {0}", list.Count);
            Console.WriteLine("Listenin Kapatisesi     : {0}", list.Capacity);
            list.TrimToSize();
            Console.WriteLine("Listenin Kapatisesi     : {0}", list.Capacity);

            //Erişme - Key
            Console.WriteLine(list[4]);
            //Erişme - İndex
            Console.WriteLine(list.GetByIndex(0));
            //Get -> Key
            Console.WriteLine(list.GetKey(7));
            //Liste sonundaki elemanın değeri
            Console.WriteLine(list.GetByIndex(list.Count - 1));

            var anahtarlar = list.Keys;
            Console.WriteLine("\nANAHTARLAR");
            foreach (var item in anahtarlar)
            {
                Console.WriteLine(item);
            }

            var degerler = list.Values;
            Console.WriteLine("\nDEĞERLER");
            foreach (var item in degerler)
            {
                Console.WriteLine(item);
            }

            if (list.ContainsKey(1))
            {
                list[1] = "One";
            }
            //Dolaşma
            foreach (DictionaryEntry i in list)
            {
                Console.WriteLine($"{i.Key,-5} - {i.Value,-20}");
            }

            //listenden kaldırma
            list.Remove(2);
            Console.WriteLine("2.Eleman kaldırıldı.");
            //Dolaşma
            foreach (DictionaryEntry i in list)
            {
                Console.WriteLine($"{i.Key,-5} - {i.Value,-20}");
            }
            Console.ReadKey();
        }
        private static void SortedList_2()
        {
            //SortedList
            var kitapIcerigi = new SortedList()
            {
                {1,"Önsöz"},
                {50,"Değişkenler"},
                {40,"Oparatörler"},
                {60,"Döngüler"},
                {45,"İlişkisel Oparatörler"}
            };
            Console.WriteLine("İçindekiler");
            Console.WriteLine(new string('-', 45));
            Console.WriteLine($"{"Konular",-30} {"Sayfalar",-5}");
            foreach (DictionaryEntry i in kitapIcerigi)
            {
                Console.WriteLine($"{i.Value,-30} {i.Key,-5}");
            }
        }
        private static void Hashtable_2()
        {
            //Hashtable uygulaması(url yapımı)

            //başlığı okuma
            Console.WriteLine("Başlık giriniz: ");
            string baslik = Console.ReadLine();

            //Küçültme
            baslik = baslik.ToLower();

            //hastable 
            var karakterSeti = new Hashtable()
            {
                {'c','ç'},
                {'ı','i'},
                {'ö','o'},
                {'ü','u'},
                {'ğ','g'},
                {' ','-'},
                {'\'','-'},
                {'.','-'},
                {'?','-'},
            };

            foreach (DictionaryEntry item in karakterSeti)
            {
                baslik = baslik.Replace(Convert.ToChar(item.Key), (char)item.Value);
            }
            //New Baslik
            Console.WriteLine(baslik);
        }
        private static void Hashtable_1()
        {
            //Hashtable Uygulama
            var sehirler = new Hashtable();
            //Ekleme
            sehirler.Add(6, "Ankara");
            sehirler.Add(34, "İstanbul");
            sehirler.Add(55, "Samsun");
            sehirler.Add(23, "Elazığ");

            //Dolasma 
            foreach (DictionaryEntry i in sehirler)
            {
                Console.WriteLine($"{i.Key,-5} - {i.Value,-20}");
            }

            //Anahtarları alma
            Console.WriteLine("\nAnahtarlar (Keys)");
            var anahtarlar = sehirler.Keys;
            foreach (var i in anahtarlar)
            {
                Console.WriteLine(i);
            }

            //Değerler
            Console.WriteLine("\nDeğerler (Values)");
            ICollection değerler = sehirler.Values;
            foreach (var item in değerler)
            {
                Console.WriteLine(item);
            }

            //Elemana Erişme
            Console.WriteLine("\nElemana erişme");
            Console.WriteLine(sehirler[55]);

            //Eleman Silme 
            Console.WriteLine("\nEleman Silme");
            sehirler.Remove(23);
            //Dolasma 
            foreach (DictionaryEntry i in sehirler)
            {
                Console.WriteLine($"{i.Key,-5} - {i.Value,-20}");
            }

            Console.ReadKey();
        }
        private static void Array_1()
        {
            //Array | dizi| tanımlama                            
            int[] sayilar = new int[] { 5, 3, 8, 10, 2, 18, 23, 44, 55, 6, 34, 19 };
            var sayilar2 = new ArrayList(sayilar);
            var numbers = Array.CreateInstance(typeof(int), sayilar.Length);

            sayilar.CopyTo(numbers, 0);

            Array.Sort(numbers);//sayıları sıralar
            Array.Sort(sayilar);//sayıları sıralar
            sayilar2.Sort(); //sayıları sıralar
            Array.Clear(sayilar, 2, 2);

            Console.WriteLine(Array.IndexOf(sayilar, 55));

            //Dolasma
            for (int i = 0; i < numbers.Length; i++)
            {
                // Console.WriteLine("sayilar[{0}] = {1} -numbers[{0}]={2}," ,i, sayilar[i],numbers.GetValue(i));
                Console.WriteLine($"sayilar[{i}] = {sayilar[i],4} -numbers[{i}]={numbers.GetValue(i),4} -sayilar2[{i}] = {sayilar2[i],4}");
            }
        }
        private static void Method()
        {
            //Tanımlama
            var List1 = new List<OgretimElemani>()
            {
                new OgretimElemani(100,"Ahmet","Yankı",true),
                new OgretimElemani(101,"Aylin","Aktaş",false),
                new OgretimElemani(102,"Mehmet","Yıldız",true),
                new OgretimElemani(103,"Burcu","Koç",false),
                new OgretimElemani(104,"Hüseyin","Kaplan",true)
            };

            Console.WriteLine("Liste 1");
            List1.ForEach(ogr => Console.WriteLine(ogr));

            var List2 = List1;
            Console.WriteLine("Liste 2");
            List2.ForEach(ogr => Console.WriteLine(ogr));


            List2.Add(new OgretimElemani(105, "Fadime", "Aktaş Koç", false));
            Console.WriteLine("Liste 2'ye bir eleman eklendi.");

            Console.WriteLine("Liste 1");
            List1.ForEach(ogr => Console.WriteLine(ogr));

            Console.WriteLine("Liste 2");
            List2.ForEach(ogr => Console.WriteLine(ogr));


        }
        private static void Struct_1()
        {
            //Struct -> değer tipli
            var n1 = new Nokta(5, 3);
            Console.WriteLine($"n1 : {n1}");
            n1.Degistir();
            Console.WriteLine($"n1 : {n1}");
            var n2 = n1;
            Console.WriteLine($"n2 : {n2}");
            n2.X = 5;
            Console.WriteLine($"n1 : {n1}");

            Console.WriteLine($"n2 : {n2}");
            Console.ReadKey();
        }
        private static void StructNesneOlusturma()
        {
            //Struct-kullanma
            Ogrenci ogr = new Ogrenci();
            ogr.Numara = 10;
            ogr.Adi = "Berat";
            ogr.Soyadi = "Yılmaz";
            ogr.Cinsiyet = true;
            //Alternatif kullanma
            var ogr2 = new Ogrenci()
            {
                Numara = 20,
                Adi = "Ayse",
                Soyadi = "Aktas",
                Cinsiyet = false,
            };

            //Alternatif kullanma
            var ogr3 = new Ogrenci(30, "Begüm", "Koç", false);
            var ogr4 = new Ogrenci(40, "Selahattin", "Aktaş");
        }
        private static void VeriAltUstLimit()
        {
            //8-bit integer
            Console.WriteLine(nameof(SByte));
            Console.WriteLine($"Alt limit       :{SByte.MinValue,20}");
            Console.WriteLine($"Üst limit       :{SByte.MaxValue,20}");
            Console.WriteLine($"Boyut           :{sizeof(SByte),20}");
            Console.WriteLine();
            Console.ReadKey();

            //Signed 8-bit integer
            Console.WriteLine(nameof(Byte));
            Console.WriteLine($"Üst limit       :{Byte.MaxValue,20}");
            Console.WriteLine($"Alt limit       :{Byte.MinValue,20}");
            Console.WriteLine($"Boyut           :{sizeof(Byte),20}");
            Console.WriteLine();
            Console.ReadKey();

            //Signed 16-bit integer
            Console.WriteLine(nameof(Int16));
            Console.WriteLine($"Üst limit       :{Int16.MaxValue,20}");
            Console.WriteLine($"Alt limit       :{Int16.MinValue,20}");
            Console.WriteLine($"Boyut           :{sizeof(Int16),20}");
            Console.WriteLine();
            Console.ReadKey();

            //Unsigned 16-bit integer
            Console.WriteLine(nameof(UInt16));
            Console.WriteLine($"Üst limit       :{UInt16.MaxValue,20}");
            Console.WriteLine($"Alt limit       :{UInt16.MinValue,20}");
            Console.WriteLine($"Boyut           :{sizeof(UInt16),20}");
            Console.WriteLine();
            Console.ReadKey();

            //Signed 32-bit integer
            Console.WriteLine(nameof(Int32));
            Console.WriteLine($"Üst limit       :{Int32.MaxValue,20}");
            Console.WriteLine($"Alt limit       :{Int32.MinValue,20}");
            Console.WriteLine($"Boyut           :{sizeof(Int32),20}");
            Console.WriteLine();
            Console.ReadKey();

            //Unsigned 32-bit integer
            Console.WriteLine(nameof(UInt32));
            Console.WriteLine($"Üst limit       :{UInt32.MaxValue,20}");
            Console.WriteLine($"Alt limit       :{UInt32.MinValue,20}");
            Console.WriteLine($"Boyut           :{sizeof(UInt32),20}");
            Console.WriteLine();
            Console.ReadKey();

            //Double
            Console.WriteLine(nameof(Double));
            Console.WriteLine($"Üst limit       :{Double.MaxValue,20}");
            Console.WriteLine($"Alt limit       :{Double.MinValue,20}");
            Console.WriteLine($"Boyut           :{sizeof(Double),20}");
            Console.WriteLine();
            Console.ReadKey();
        }
        private static void ListeOrnegi()
        {
            var sehirler = new List<string>()
            {
                "Ankara","Sakarya","Konya","Muğla","Sivas"
            };
            // Lambda expression => Araştır....
            sehirler.ForEach(s => Console.WriteLine(s));
            Console.WriteLine();

            var iller = sehirler;
            iller.ForEach(i => Console.WriteLine(i));
            Console.WriteLine(new string('-', 50));

            sehirler.Add("Sinop");
            sehirler.ForEach(s => Console.WriteLine(s));

            Console.WriteLine();
            iller.ForEach(i => Console.WriteLine(i));
            Console.WriteLine(new string('-', 50));

            iller.Remove("Ankara");
            sehirler.ForEach(s => Console.WriteLine(s));
            Console.WriteLine();
            iller.ForEach(i => Console.WriteLine(i));
            Console.WriteLine(new string('-', 50));
        }
        private static void ReferansCalismasi()
        {
            int x = 10;
            int y = 20;
            Console.WriteLine("{0} {1}", x, y);
            Degistir(ref x, ref y);
            Console.WriteLine("{0} {1}", x, y);
        }
        /// <summary>
        /// Sayıların yerini değiştirme
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void Degistir(ref int x, ref int y)
        {
            int gecici = x;
            x = y;
            y = gecici;
            Console.WriteLine("{0} {1}", x, y);
        }
        private static void MethodTasarimi2()
        {
            //method aşırı yükleme
            var OdenecekMiktar = SatisYap(100);
            var OdenecekMiktar2 = SatisYap(100, 10);
            Console.WriteLine(OdenecekMiktar);
            Console.WriteLine(OdenecekMiktar2);
        }
        /// <summary>
        /// Satış yapan fonksiyon örneği
        /// </summary>
        /// <param name="miktar">Alışveriş tutarı</param>
        /// <returns>Kdv eklenmiş toplam ödenecek</returns>
        private static double SatisYap(double miktar)
        {
            return miktar * 1.18;
        }
        /// <summary>
        /// İndirimli satış yapan fonksiyon
        /// </summary>
        /// <param name="miktar">Alışveriş tutarı</param>
        /// <param name="indirim">İndirim oranı</param>
        /// <returns>KDV eklenmiş ve indirimli toplam ödenecek</returns>
        private static double SatisYap(double miktar, double indirim)
        {
            return miktar * 1.18 - (miktar * indirim / 100);
        }
        private static void MethodTasarimi1()
        {
            Console.WriteLine(karsilastir(5, 3));
            Console.WriteLine(KareAl(3));
            Console.WriteLine(SeriToplami(5.5, 15.3, 2.5));
        }
        private static double SeriToplami(params double[] seri)
        {
            double toplam = 0.0;
            foreach (var item in seri)
            {
                toplam += item;
            }
            return toplam;
        }
        private static double SeriToplami(int v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }
        public static int karsilastir(int x, int y)
        {
            return x > y ? x : y;
        }
        static int KareAl(int x)
        {
            return (x * x);
        }
        private static void Listeler()
        {
            //List<tip>
            /*Çalışma sırasında tip bilgisi bellidir.
             *Tip güvenliği sağlanır.
            */

            //Tanımla
            /*List<int>*/
            var sayilar = new List<int>();

            int x = 55;
            int[] Seri = new int[] { 70, 80, 90 };

            //Ekleme
            sayilar.Add(10);
            sayilar.Add(15);
            sayilar.Add(20);
            sayilar.Add(x);

            //for (int i = 0; i < Seri.Length; i++)
            //{
            //    sayilar.Add(Seri[i]);
            //}
            //Ya da :
            //foreach (var item in Seri)
            //{
            //    sayilar.Add(item);
            //}Ya da :
            sayilar.AddRange(Seri);

            sayilar.AddRange(new int[] { 40, 50, 60 });

            //Araya ekleme
            sayilar.Insert(1, 7);
            sayilar.InsertRange(4, new int[] { 80, 91 });

            //Dolaşma
            foreach (var s in sayilar)
            {
                Console.Write($"{s,-5}");
            }
            Console.WriteLine();
            //Silme
            sayilar.RemoveAt(1);
            sayilar.RemoveAt(sayilar.IndexOf(55));
            //Dolaşma
            foreach (var s in sayilar)
            {
                Console.Write($"{s,-5}");
            }
        }
        private static void ArrayListMethod()
        {
            /*ArrayList farklı veri türlerini tutabilir.Hepsinin türünü object olarak düşünür.
                         *İçine yazdığımız int obje olarak düşünülür.Onu int olarak kullanmak istediğimizde çevirme işlemi yaparız.
                         *
                         */
            //ArrrayList Tanımlama & Ekleme
            var arrayList = new ArrayList()
            {
                10,"BTK Akademi",true, 'e'
            };

            /*Ekleme1
            arrayList.Add(10);//boxing
            arrayList.Add("BTK Akademi");
            arrayList.Add(true);
            arrayList.Add('e');
            */
            //Dolaşma 
            foreach (var e in arrayList)
            {
                Console.Write($"{e} ");
            }

            //arraylist'e bu diziyi ekleyelim.
            int[] sayilar = new int[] { 23, 44, 55 };
            arrayList.AddRange(sayilar);

            //Dolaşma
            Console.WriteLine();
            foreach (var e in arrayList)
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();
            //Elemana Erişme
            Console.WriteLine(arrayList[4]);

            //Elemana erişme - Atama
            int x = Convert.ToInt16(arrayList[0]);//(int)arrayList[0]; //Kutudan çıkartma
            Console.WriteLine(x + 10);

            //Eleman silme
            //arrayList.Remove(10);
            //arrayList.RemoveAt(1);
            arrayList.RemoveRange(3, 3);
            //Dolaşma
            Console.WriteLine();
            foreach (var e in arrayList)
            {
                Console.Write($"{e} ");
            }
        }
        private static void DiziBilgi3()
        {
            double[,] matris = new double[,] { { 1, 2, 3 },
                                               { 4, 5, 6 },
                                               { 7, 8, 9} };
            double btoplam = 0;
            double stoplam = 0;
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    btoplam += matris[i, j];
                    if (i == j)
                    {
                        matris[i, j] = -1;
                    }
                    if (matris[i, j] % 2 == 0)
                    {
                        matris[i, j] = 0;
                    }
                    Console.Write($"{matris[i, j],5}");
                    stoplam += matris[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine(stoplam);
            Console.WriteLine(btoplam);
        }
        private static void DiziBilgisi2()
        {
            Console.WriteLine("Dizi boyutunu giriniz :");
            int boyut = Convert.ToInt32(Console.ReadLine());
            int[] sayilar = new int[boyut];

            var r = new Random();//random classından r nesnesini oluşturduk.

            for (int i = 0; i < sayilar.Length; i++)
            {
                sayilar[i] = r.Next(1, 10);
            }
            foreach (int sayi in sayilar)
            {
                Console.WriteLine("{0,5} {1,5}", sayi, sayi * sayi);
            }
        }
        private static void DiziBilgi1()
        {
            //Dizi Tanımlama & başlatma & atama
            int[] numaralar = new int[/*buraya boyut girilebilir*/] { 3, 5, 7 };

            for (int i = 0; i < numaralar.Length; i++)
            {
                Console.WriteLine($"Numaralar[{i}] = " + $"{numaralar[i]}");
            }
        }
        private static void DonguOrnegi3()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(" * ");
                }
                Console.WriteLine();
            }
        }
        private static void DonguOrnegi2()
        {
            Console.WriteLine("Bir sayi giriniz :");
            int n = Convert.ToInt32(Console.ReadLine());
            int i = 2;
            do
            {
                Console.Write("{0,-3}", i);
                i += 2;
            } while (i <= n);
        }
        private static void DonguOrnegi()
        {
            int sayac = 10;
            while (sayac > 0)
            {
                Console.WriteLine("{0,-3} {1,-2}", sayac, sayac * sayac);
                sayac--;
            }
        }
        private static void SwicthCaseYapisi()
        {
            int A = 10, B = 20;
            Islemler secim = (Islemler)(new Random().Next(1, 4));//1 ile 4 arasında rasgele işlem yapar.
            switch (secim)
            {
                case Islemler.Toplama:
                    Console.WriteLine($"{A} + {B}= {A + B}");
                    break;
                case Islemler.Cikarma:
                    Console.WriteLine($"{A} - {B}= {A - B}");
                    break;
                case Islemler.Carpma:
                    Console.WriteLine($"{A} * {B}= {A * B}");
                    break;
                case Islemler.Bolme:
                    Console.WriteLine($"{A} / {B}= {A / B}");
                    break;
                default:
                    Console.WriteLine("\a Geçerli işlem girilmedi.");
                    break;
            }
        }
        private static void KarakterOzellikleri()
        {
            var k = (char)Console.Read();
            if (char.IsDigit(k))
            {
                Console.WriteLine("Rakamdır!");
            }
            else if (char.IsLower(k))
            {
                Console.WriteLine("Kucuk karakter.");
            }
            else if (char.IsUpper(k))
            {
                Console.WriteLine("Buyuk karakter.");
            }
            else
            {
                Console.WriteLine("Bilinmeyen karakter.");
            }
        }
        private static void TekCift()
        {
            //Tek mi,çift mi?
            Console.WriteLine("Lütfen bir tam sayı giriniz :");
            int s1 = Convert.ToInt16(Console.ReadLine());
            if (s1 % 2 == 0)
            {
                Console.WriteLine(s1 + " sayısı çifttir.");
            }
            else
            {
                Console.WriteLine($"{s1} sayısı tektir.");
            }
        }
        private static void MutlakDeger()
        {
            //Mutlak Değer
            Console.WriteLine("Lütfen bir tam sayı giriniz :");
            //Convert.ToInt16 ile girilen string deger int e donusturuluyor  
            int s1 = Convert.ToInt16(Console.ReadLine());
            if (s1 < 0)
            {
                Console.WriteLine($"|{s1}| = " + (-s1));
            }
            else
            {
                Console.WriteLine($"|{s1}| = " + (s1));
            }
        }
        private static void Operatorler()
        {
            int A = 20, B = 10;
            // Aritmetik oparetorler
            Console.WriteLine(A + B);
            Console.WriteLine(A - B);
            Console.WriteLine(A * B);
            Console.WriteLine(A / B);
            Console.WriteLine(A % B);

            //İlişkisel oparetorler
            Console.WriteLine(A > B);
            Console.WriteLine(A < B);
            Console.WriteLine(A >= B);
            Console.WriteLine(A <= B);
            Console.WriteLine(A == B);
            Console.WriteLine(A != B);

            //Koşul ifadeleri
            Console.WriteLine(A > B && A < 5);
            Console.WriteLine(A < B || B > 5);
        }
        private static void StringMethodu()
        {
            var ifade = "Merhaba programlama dünyası.";
            Console.WriteLine(ifade);
            Console.WriteLine(ifade.Length);
            Console.WriteLine(ifade.TrimStart());//Geçerli dizeden baştaki tüm boşluk karakterlerini kaldırır.
            Console.WriteLine(ifade.TrimEnd());//Geçerli dizgenin sonundaki tüm boşluk karakterlerini kaldırır.
            Console.WriteLine(ifade[0]);
            Console.WriteLine(ifade[1]);
            Console.WriteLine(ifade[ifade.Length - 1]);
        }
        private static void OrtuluDegiskenTanimi()
        {
            //örtülü değişken
            var isim = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine(isim.Key);
            Console.WriteLine(isim.KeyChar);
        }
        #endregion
    }
}