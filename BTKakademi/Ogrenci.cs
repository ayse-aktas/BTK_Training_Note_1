namespace BTKakademi
{
    partial class Program
    {
        //Struct tanımlama 
        public struct Ogrenci
        {
            //Yapılandırıcı method-Constructor
            public Ogrenci(int numara, string adi, string soyadi, bool cinsiyet = true)
            {
                Numara = numara;
                Adi = adi;
                Soyadi = soyadi;
                Cinsiyet = cinsiyet;
            }
            public int Numara { get; set; }//Property - Özellik
            public string Adi { get; set; }
            public string Soyadi { get; set; }
            public bool Cinsiyet { get; set; }

            //Bir methodu geçersiz kılmak/ezmek/override
            public override string ToString()
            {
                return $"{Numara,-5}  {Adi,-10}  {Soyadi,-10}" +
                        string.Format("{0,-5}", Cinsiyet == true ? "Bay" : "Bayan");
            }
            public static void Calistir()
            {

                var ogrenciListesi = new List<Ogrenci>()
                {
                    new Ogrenci(10,"Berat","Yılmaz",true),
                    new Ogrenci(20, "Ayse", "Aktas", false),
                    new Ogrenci(30, "Begüm", "Koç", false),
                    new Ogrenci(40, "Selahattin", "Aktaş")
                };
                Console.ReadKey();
                ogrenciListesi.ForEach(o => Console.WriteLine(o));
            }
        }
    }
}