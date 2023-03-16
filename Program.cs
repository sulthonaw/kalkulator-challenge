namespace Kalkulator
{
    class Program
    {

        public static string[] _dataAng = { "nol", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas" };

        static void Main(string[] args)
        {
            Console.Clear();

            string input = "satu";

            string[] arrInput = input.Split(' ');

            readInput(arrInput);
        }

        // NOTE : Method membaca array terbilang dan mengubahnya menjadi array angka
        static void readInput(string[] arr)
        {
            int[] tampungan = new int[arr.Length];

            tampilArrayStr(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 1)
                {
                    if (arr[i] == "ribu")
                    {
                        int before = i - 1;
                        tampungan[before] *= 1000;
                    }
                    else if (arr[i] == "ratus")
                    {
                        int before = i - 1;
                        tampungan[before] *= 100;
                    }
                    else if (arr[i] == "puluh")
                    {
                        int before = i - 1;
                        tampungan[before] *= 10;
                    }
                    else if (arr[i] == "belas")
                    {
                        int before = i - 1;
                        tampungan[before] += 10;
                    }
                    else
                    {
                        Console.WriteLine("Format salah.");
                    }
                }
                else
                {
                    for (int j = 0; j < _dataAng.Length; j++)
                    {
                        if (arr[i] == _dataAng[j]) tampungan[i] = j;
                    }
                }
            }

            int hasil = 0;
            foreach (int t in tampungan) hasil += t;

            Console.WriteLine(hasil);
        }

        // NOTE : Method mengubah terbilang istimewa menjadi biasa
        // Cth  : [seratus] -> [satu][ratus]
        static void ubahTerbilangIstimewa(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                string[] tampungan = new string[2];
                if (arr[i] == "seribu")
                {
                    tampungan[0] = "satu";
                    tampungan[1] = "ribu";
                    arr.Concat(tampungan);
                }
                else if (arr[i] == "seratus")
                {
                    tampungan[0] = "satu";
                    tampungan[1] = "ratus";
                }
            }

            tampilArrayStr(arr);
        }

        // NOTE : Method menampilkan array tipe data int
        static void tampilArrayInt(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write($"[{i}] ");
            }
            Console.WriteLine();
        }

        // NOTE : Method menampilkan array tipe data string
        static void tampilArrayStr(string[] arr)
        {
            foreach (string i in arr)
            {
                Console.Write($"[{i}] ");
            }
            Console.WriteLine();
        }
    }
}