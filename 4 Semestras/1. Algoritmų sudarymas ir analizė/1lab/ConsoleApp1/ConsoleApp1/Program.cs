using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] data = new int[] { -1, 25, -58964, 8547, -119, 0, 78596, -58964 };
            //int[] data = new int[] { 3, 7, 11, 15, 18, 23, 41, 45 };
            //BucketSort(ref data);
            //List<int> sorkted = new List<int>();
            //sorted = BucketSort(data);
            //foreach (int num in data)
            //Console.WriteLine(num);

            //BucketSort bucketsort = new BucketSort();

            //Objektas obj = new Objektas("aaaa", 1234);
            //Objektas obj2 = new Objektas("aaca", 1234);
            //Objektas obj3 = new Objektas("aaba", 1234);
            //Objektas obj4 = new Objektas(RandomString(4), 6432);
            //Objektas obj5 = new Objektas(RandomString(4), 1252);
            //Objektas obj6= new Objektas(RandomString(4), 6431);
            //Objektas obj7 = new Objektas(RandomString(4), 7632);
            //Objektas obj8 = new Objektas(RandomString(4), 5125);
            //Objektas obj9 = new Objektas(RandomString(4), 2351);
            //Objektas obj10 = new Objektas(RandomString(4), 3261);
            //Objektas[] data2 = new Objektas[10];
            //data2[0] = obj;
            //data2[1] = obj2;
            //data2[2] = obj3;
            //data2[3] = obj4;
            //data2[4] = obj5;
            //data2[5] = obj6;
            //data2[6] = obj7;
            //data2[7] = obj8;
            //data2[8] = obj9;
            //data2[9] = obj10;

            //ReadAndSort();

            //List<Objektas> naujas = ReadFile(@"..\..\data\TextFile1.txt");

            //BucketSortOutside(@"..\..\data\TextFile1.txt", @"..\..\data\buckets\TextFile2.txt");

            Objektas[] data2 = RandomObjectgArray(15);
            Console.WriteLine("Pradiniai duomenys");
            Print(data2);
            Console.WriteLine();

            Objektas[] haha = BucketSortArray(data2);
            Console.WriteLine("Isrykiuotas array");
            Print(haha);
            Console.WriteLine();

            List<Objektas> haha2 = BucketSortList(data2.ToList());
            Console.WriteLine("Isrykiuotas list");
            Print(haha2);
        }

        #region List

        private static List<Objektas> BucketSortList(List<Objektas> x)
        {
            List<Objektas> sortedArray = new List<Objektas>();

            Objektas didz = x[0];
            for (int i = 0; i < x.Count; i++)
                if (x[i] >= didz)
                    didz = x[i];

            int numOfBuckets = (int)(didz.flo / 10) + 1;

            //Create buckets
            List<Objektas>[] buckets = new List<Objektas>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<Objektas>();
            }

            //Iterate through the passed array and add each integer to the appropriate bucket
            for (int i = 0; i < x.Count; i++)
            {
                int bucket = (int)(x[i].flo / 10);
                buckets[bucket].Add(x[i]);
            }

            //Sort each bucket and add it to the result List
            for (int i = 0; i < numOfBuckets; i++)
            {
                List<Objektas> temp = InsertionSort(buckets[i]);
                sortedArray.AddRange(temp);
            }
            return sortedArray;
        }
        #endregion
        #region Array
        private static Objektas[] BucketSortArray(Objektas[] x)
        {
            Objektas[] sortedArray = new Objektas[x.Length];

            Objektas didz = x[0];
            for (int i = 0; i < x.Length; i++)
                if (x[i] >= didz)
                    didz = x[i];

            int numOfBuckets = (int)(didz.flo / 10) + 1;

            //Create buckets
            List<Objektas>[] buckets = new List<Objektas>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<Objektas>();
            }

            //Iterate through the passed array and add each integer to the appropriate bucket
            for (int i = 0; i < x.Length; i++)
            {
                int bucket = (int)(x[i].flo / 10);
                buckets[bucket].Add(x[i]);
            }
            int a = 0;
            //Sort each bucket and add it to the result List
            for (int i = 0; i < numOfBuckets; i++)
            {
                List<Objektas> temp = InsertionSort(buckets[i]);
                for (int j = 0; j < temp.Count; j++)
                {
                    sortedArray[a] = temp[j];
                    a++;
                }
                //sortedArray.AddRange(temp);
            }
            return sortedArray;
        }
        #endregion
        #region Insertion sort
        private static List<Objektas> InsertionSort(List<Objektas> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                //2. Store the current value in a variable
                Objektas currentValue = input[i];
                int pointer = i - 1;

                //3. As long as we are pointing to a valid value in the array...
                while (pointer >= 0)
                {
                    if (currentValue <= input[pointer])
                    {
                        input[pointer + 1] = input[pointer];
                        input[pointer] = currentValue;
                    }
                    else break;
                }
            }

            return input;
        }
        #endregion
        #region Random
        public static Objektas[] RandomObjectgArray(int length)
        {
            Objektas[] temp = new Objektas[length];
            for (int i = 0; i < length; i++)
            {
                temp[i] = new Objektas(RandomFloat(4), RandomString(4));
            }
            return temp;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static float RandomFloat(int length)
        {
            string chars = "0123456789";
            string str = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            while (str[0] == '0')
                str = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return float.Parse(str);
        }
        #endregion
        #region Print and Read
        private static void Print(List<Objektas> Lines)
        {
            //Console.WriteLine("Sarasas");
            foreach (Objektas e in Lines)
            {
                Console.WriteLine(e.flo + " " + e.str);
            }
        }
        private static void Print(Objektas[] Lines)
        {
            //Console.WriteLine("masyvas");
            foreach (Objektas e in Lines)
            {
                Console.WriteLine(e.flo + " " + e.str);
            }
        }
        private static List<Objektas> ReadFile(string fil)
        {

            List<Objektas> Lines = new List<Objektas>();

            //string fil = @"..\..\data\TextFile1.txt";
            using (StreamReader sr = new StreamReader(fil))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    Objektas eil = new Objektas(float.Parse(parts[0]), parts[1]);
                    Lines.Add(eil);
                }
            }
            //foreach (Eilute e in Lines)
            //{
            //    //Console.WriteLine(e.toString()); 
            //}
            return Lines;
        }
        #endregion
        #region Outside memory
        public static void BucketSortOutside(string readPath, string writePath)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(@"..\..\data\buckets\");
            foreach (FileInfo file in di.GetFiles())
                file.Delete();

            using (StreamReader sr = new StreamReader(readPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    Objektas eil = new Objektas(float.Parse(parts[0]), parts[1]);

                    int bucket = (int)(eil.flo / 100);
                    string fileName = "Bucket" + bucket + ".txt";
                    if (!File.Exists(@"..\..\data\buckets\" + fileName))
                        using (StreamWriter sw = File.CreateText(@"..\..\data\buckets\" + fileName))
                            sw.WriteLine(line);
                    else
                        using (StreamWriter sw = new StreamWriter(@"..\..\data\buckets\" + fileName, true))
                            sw.WriteLine(line);
                }
            }

            //foreach (FileInfo file in di.GetFiles())
            //sortas(file.Name);

            File.Delete(@"..\..\data\TextFile2.txt");
            string[] filePaths = Directory.GetFiles(@"..\..\data\buckets\", "Bucket*.txt");
            foreach(string file in filePaths)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    using (StreamWriter sw = new StreamWriter(@"..\..\data\TextFile2.txt", true))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
        }

        private static void SortFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                //using (StreamWriter sw = new StreamWriter())
            }
        }

        private static void ReadAndSort()
        {
            using (FileStream fileStream = new FileStream(@"../../data/TextFile1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                //fileStream.se;
                //byte[] array = new byte[4];
                //fileStream.Read(array, 0, 4);
                // byte[] data = new byte[9];
                //int i = 0;
                //fileStream.Seek(8, SeekOrigin.Begin);
                // array.ToString();
                //     for(int j = 0; j < 4; j++)
                //  string a = a + fileStream.ReadByte().ToString();
                // a = 
                int number = 0;
                byte[] bytes = new byte[12];
                string line = null;
                fileStream.Seek(0, SeekOrigin.Current);
                while ((line = (fileStream.Read(bytes, 0, 12)).ToString()) != null && fileStream.Position <= fileStream.Length)
                {
                    //Console.WriteLine(System.Text.Encoding.UTF8.GetString(bytes));
                    string Line = System.Text.Encoding.UTF8.GetString(bytes);
                    string[] parts = Line.Split(' ');
                    float h = float.Parse(parts[0]);
                    Objektas e = new Objektas(h, parts[1]);
                    Console.WriteLine(e.flo + " " + e.str);
                    //fileStream.Seek()
                    if (fileStream.Position >= fileStream.Length) break;
                    //   fileStream.
                    // number = number + 12;
                    // fileStream.
                    //if (fileStream.CanRead)
                    //    Console.WriteLine("true");
                    //  else Console.WriteLine("false");
                }

            }
        }

        //public static void BucketSortOutside(string readPath, string writePath)
        //{
        //    int lineCount = 1;
        //    using (StreamReader sr = new StreamReader(readPath))
        //    {
        //        Stream fs = new MemoryStream();

        //        string[] temp = sr.ReadLine().Split(' ');
        //        string line;
        //        Objektas max = new Objektas(float.Parse(temp[0]), temp[1]);
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            lineCount++;
        //            string[] parts = line.Split(' ');
        //            Objektas eil = new Objektas(float.Parse(parts[0]), parts[1]);
        //            if (eil >= max)
        //                max = eil;
        //        }
        //        fs.Position = 0;
        //        sr.DiscardBufferedData();
        //        int numOfBuckets2 = (int)(max.flo / 10) + 1;

        //        using (StreamWriter sw = new StreamWriter(writePath))
        //        {
        //            for (int i = 0; i < numOfBuckets2; i++)
        //            {
        //                sw.WriteLine();
        //            }
        //        }
        //    }

        //    int linenum = 1;
        //    using (StreamReader sr = new StreamReader(readPath))
        //    {
        //        string line;
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            string[] parts = line.Split(' ');
        //            Objektas eil = new Objektas(float.Parse(parts[0]), parts[1]);

        //            int bucket = (int)(eil.flo / 10);
        //            using (StreamWriter sw = new StreamWriter(writePath))
        //            {
        //                for (int i = 0; i < bucket; i++)
        //                {
        //                    sw.WriteLine(line);
        //                }
        //                sw.WriteLine(eil.flo + " " + eil.str);
        //            }
        //        }
        //    }






        //    //List<Objektas> sortedArray = new List<Objektas>();

        //    //Objektas didz = x[0];
        //    //for (int i = 0; i < x.Length; i++)
        //    //    if (x[i] >= didz)
        //    //        didz = x[i];

        //    //int numOfBuckets = (int)(didz.flo / 10) + 1;

        //    ////Create buckets
        //    //List<Objektas>[] buckets = new List<Objektas>[numOfBuckets];
        //    //for (int i = 0; i < numOfBuckets; i++)
        //    //{
        //    //    buckets[i] = new List<Objektas>();
        //    //}

        //    ////Iterate through the passed array and add each integer to the appropriate bucket
        //    //for (int i = 0; i < x.Length; i++)
        //    //{
        //    //    int bucket = (int)(x[i].flo / 10);
        //    //    buckets[bucket].Add(x[i]);
        //    //}

        //    ////Sort each bucket and add it to the result List
        //    //for (int i = 0; i < numOfBuckets; i++)
        //    //{
        //    //    List<Objektas> temp = InsertionSort(buckets[i]);
        //    //    sortedArray.AddRange(temp);
        //    //}
        //    //return sortedArray;
        //}
        #endregion



        public static List<Objektas> BucketSort(Objektas[] x)
        {
            List<Objektas> sortedArray = new List<Objektas>();

            Objektas didz = x[0];
            for (int i = 0; i < x.Length; i++)
                if (x[i] >= didz)
                    didz = x[i];

            int numOfBuckets = (int)(didz.flo / 10) + 1;

            //Create buckets
            List<Objektas>[] buckets = new List<Objektas>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<Objektas>();
            }

            //Iterate through the passed array and add each integer to the appropriate bucket
            for (int i = 0; i < x.Length; i++)
            {
                int bucket = (int)(x[i].flo / 10);
                buckets[bucket].Add(x[i]);
            }

            //Sort each bucket and add it to the result List
            for (int i = 0; i < numOfBuckets; i++)
            {
                List<Objektas> temp = InsertionSort(buckets[i]);
                sortedArray.AddRange(temp);
            }
            return sortedArray;
        }

        //Insertion Sort




        //public static List<int> Sort(int[] x)
        //{
        //    List<int> sortedArray = new List<int>();

        //    int numOfBuckets = 10;

        //    //Create buckets
        //    List<int>[] buckets = new List<int>[numOfBuckets];
        //    for (int i = 0; i < numOfBuckets; i++)
        //    {
        //        buckets[i] = new List<int>();
        //    }

        //    //Iterate through the passed array and add each integer to the appropriate bucket
        //    for (int i = 0; i < x.Length; i++)
        //    {
        //        int bucket = (x[i] / numOfBuckets);
        //        buckets[bucket].Add(x[i]);
        //    }

        //    //Sort each bucket and add it to the result List
        //    for (int i = 0; i < numOfBuckets; i++)
        //    {
        //        List<int> temp = InsertionSort(buckets[i]);
        //        sortedArray.AddRange(temp);
        //    }
        //    return sortedArray;
        //}

        ////Insertion Sort
        //public static List<int> InsertionSort(List<int> input)
        //{
        //    for (int i = 1; i < input.Count; i++)
        //    {
        //        //2. Store the current value in a variable
        //        int currentValue = input[i];
        //        int pointer = i - 1;

        //        //3. As long as we are pointing to a valid value in the array...
        //        while (pointer >= 0)
        //        {
        //            //4. If the current value is less than the value we are pointing at...
        //            if (currentValue < input[pointer])
        //            {
        //                //5. Move the pointed-at value up one space, and insert the current value at the pointed-at position.
        //                input[pointer + 1] = input[pointer];
        //                input[pointer] = currentValue;
        //            }
        //            else break;
        //        }
        //    }

        //    return input;
        //}

        //void bucketSort(float arr[], int n)
        //{
        //    // 1) Create n empty buckets 
        //    vector<float> b[n];

        //    // 2) Put array elements in different buckets 
        //    for (int i = 0; i < n; i++)
        //    {
        //        int bi = n * arr[i]; // Index in bucket 
        //        b[bi].push_back(arr[i]);
        //    }

        //    // 3) Sort individual buckets 
        //    for (int i = 0; i < n; i++)
        //        sort(b[i].begin(), b[i].end());

        //    // 4) Concatenate all buckets into arr[] 
        //    int index = 0;
        //    for (int i = 0; i < n; i++)
        //        for (int j = 0; j < b[i].size(); j++)
        //            arr[index++] = b[i][j];
        //}




        public static void BucketSort(ref int[] data)
        {
            int minValue = data[0];
            int maxValue = data[0];

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxValue)
                    maxValue = data[i];
                if (data[i] < minValue)
                    minValue = data[i];
            }
            //Creates array of lists(buckets)
            List<int>[] bucket = new List<int>[maxValue - minValue + 1];
            //Initiates the lists
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < data.Length; i++)
            {
                bucket[data[i] - minValue].Add(data[i]);
            }

            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        data[k] = bucket[i][j];
                        k++;
                    }
                }
            }
        }
    }
}
