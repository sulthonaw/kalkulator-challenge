namespace Kalkulator
{
    class Program
    {
        public static string[] _dataAng = { "nol", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas" };

        static void Main(string[] args)
        {
            Console.Clear();
            int? kalkulator = KalkulatorTerbilang("lima dikali lima");
            Console.WriteLine($"Hasil : {kalkulator}");
        }

        static int? KalkulatorTerbilang(string input)
        {
            if (input.Contains("dikali") || input.Contains("kali"))
            {
                string[] operan = { " dikali ", " kali " };
                string[] inputInArray = input.Split(operan, System.StringSplitOptions.RemoveEmptyEntries);
                return ConvertTerbilangKeNum(inputInArray[0]) * ConvertTerbilangKeNum(inputInArray[1]);
            }
            else if (input.Contains("ditambah") || input.Contains("tambah"))
            {
                string[] operan = { " ditambah ", " tambah " };
                string[] inputInArray = input.Split(operan, System.StringSplitOptions.RemoveEmptyEntries);
                return ConvertTerbilangKeNum(inputInArray[0]) + ConvertTerbilangKeNum(inputInArray[1]);
            }
            else if (input.Contains("dikurang") || input.Contains("kurang"))
            {
                string[] operan = { " dikurang ", " kurang " };
                string[] inputInArray = input.Split(operan, System.StringSplitOptions.RemoveEmptyEntries);
                return ConvertTerbilangKeNum(inputInArray[0]) - ConvertTerbilangKeNum(inputInArray[1]);
            }
            else if (input.Contains("dibagi") || input.Contains("bagi"))
            {
                string[] operan = { " dibagi ", " bagi " };
                string[] inputInArray = input.Split(operan, System.StringSplitOptions.RemoveEmptyEntries);
                return ConvertTerbilangKeNum(inputInArray[0]) / ConvertTerbilangKeNum(inputInArray[1]);
            }
            return 0;
        }

        // NOTE : Method membaca array terbilang dan mengubahnya menjadi array angka
        static int? ConvertTerbilangKeNum(string input)
        {
            input.ToLower();

            if (input.Length == 0) return null;

            input = ubahTerbilangIstimewa(input);

            List<string> arr = input.Split(' ').ToList();

            List<int> tampungan = new List<int>();

            int temporary = 0;

            for (int i = 0; i < arr.Count; i++)
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
                        return null;
                    }
                }

                if (i % 2 == 0)
                {
                    int? checkValue = null;
                    for (int j = 0; j < _dataAng.Length; j++)
                    {
                        if (arr[i] == _dataAng[j])
                        {
                            checkValue = j;
                        }
                    }
                    if (checkValue != null) temporary = (int)checkValue;
                    else return null;
                }
            }

            if (arr.Count % 2 == 1) tampungan.Add(temporary);

            int hasil = 0;
            foreach (int t in tampungan) hasil += t;

            return hasil;
        }

        // NOTE : Method untuk menangani terbilang istimewa (seratus, seribu) 
        // Cth  : [seratus] -> [satu][ratus]
        static string ubahTerbilangIstimewa(string input)
        {
            if (input.Contains("seribu"))
                return input.Replace("seribu", "satu ribu");
            else if (input == "seratus")
                return input.Replace("seratus", "satu ratus");
            return input;
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