namespace Kalkulator
{
    class Program
    {
        public static string[] _dataAng = { "nol", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas" };

        static void Main(string[] args)
        {
            Console.Clear();

            string input = "lima ribu lima ratus satu";

            readInput(input);
        }

        // NOTE : Method membaca array terbilang dan mengubahnya menjadi array angka
        static void readInput(string input)
        {
            string[] arr = input.Split(' ');

            List<int> tampungan = new List<int>();

            tampilArrayStr(arr);

            int temporary = 0;

            for (int i = 0; i < arr.Length; i++)
            {

                if (i % 2 == 1)
                {
                    if (arr[i] == "ribu")
                    {
                        temporary *= 1000;
                        tampungan.Add(temporary);
                    }
                    else if (arr[i] == "ratus")
                    {
                        temporary *= 100;
                        tampungan.Add(temporary);
                    }
                    else if (arr[i] == "puluh")
                    {
                        temporary *= 10;
                        tampungan.Add(temporary);
                    }
                    else if (arr[i] == "belas")
                    {
                        temporary += 10;
                        tampungan.Add(temporary);
                    }
                    else
                    {
                        Console.WriteLine("Format salah.");
                        break;
                    }
                }

                for (int j = 0; j < _dataAng.Length; j++)
                {
                    if (arr[i] == _dataAng[j])
                    {
                        temporary = j;
                    }
                }

            }

            int hasil = 0;
            foreach (int t in tampungan) hasil += t;

            tampilArrayInt(tampungan.ToArray());
            Console.WriteLine(hasil);
        }

        // NOTE : Method untuk menangani terbilang istimewa (seratus, seribu) 
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