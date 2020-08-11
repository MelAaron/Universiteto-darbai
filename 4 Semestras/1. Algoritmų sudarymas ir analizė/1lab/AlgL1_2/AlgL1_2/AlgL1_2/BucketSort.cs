using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1_2
{
    class BucketSort
    {
        class Bubble_Sort
        {
            private static void Main(string[] args)
            {
                int[] numOfData = { 100, 200, 300, 2000, 6000 };
                int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
                //Benchmark(seed, numOfData);
                Test_File_Array_List(seed);
            }
            private static void Benchmark(int seed, int[] dataCount)
            {
                Console.WriteLine("Array");
                for (int i = 0; i < dataCount.Length; i++)
                {
                    int n = dataCount[i];
                    string filename = @"mydataarray.dat";
                    MyFileArray myfilearray = new MyFileArray(filename, n, seed);
                    var benchmark = Stopwatch.StartNew();
                    using (myfilearray.fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
                        BucketSortArray(myfilearray);
                    benchmark.Stop();
                    Console.WriteLine("{0} - {1}", dataCount[i], benchmark.Elapsed);
                }
                Console.WriteLine("LinkedList");
                for (int i = 0; i < dataCount.Length; i++)
                {
                    int n = dataCount[i];
                    string filename = @"mydatalist.dat";
                    MyFileList myfilelist = new MyFileList(filename, n, seed);

                    var benchmark = Stopwatch.StartNew();
                    using (myfilelist.fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
                        BucketSortList(myfilelist);
                    benchmark.Stop();
                    Console.WriteLine("{0} - {1}", dataCount[i], benchmark.Elapsed);
                }
            }
            public static void Test_File_Array_List(int seed)
            {
                int n = 12;
                string filename = @"mydataarray.dat";
                MyFileArray myfilearray = new MyFileArray(filename, n, seed);
                using (myfilearray.fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
                {
                    Console.WriteLine("\n FILE ARRAY \n");
                    myfilearray.Print(n);

                    Console.WriteLine("\n SORTED FILE ARRAY \n");
                    MyFileArray ats = BucketSortArray(myfilearray);
                    using (ats.fs = new FileStream(@"ats.dat", FileMode.Open, FileAccess.ReadWrite))
                        ats.Print(n);
                }
                filename = @"mydatalist.dat";
                MyFileList myfilelist = new MyFileList(filename, n, seed);
                using (myfilelist.fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
                {
                    Console.WriteLine("\n FILE LIST \n");
                    myfilelist.Print(n);
                    BucketSortList(myfilelist);
                    Console.WriteLine("\n SORTED FILE LIST \n");
                    MyFileList atss = BucketSortList(myfilelist);
                    using (atss.fs = new FileStream(@"Lats.dat", FileMode.Open, FileAccess.ReadWrite))
                        atss.Print(n);
                }
            }

            private static MyFileList BucketSortList(DataList x)
            {
                DirectoryInfo di = new DirectoryInfo(@"..\..\data2\");
                foreach (FileInfo file in di.GetFiles())
                    if (file.Name.Contains("LBucket"))
                        file.Delete();

                int[] lengths = new int[10];
                for (int i = 0; i < 10; i++)
                    lengths[i] = 0;

                for (int i = 0; i < x.Length; i++)
                {
                    Objektas temp;
                    int bucket;
                    if (i == 0)
                    {
                        temp = x.Head();
                        bucket = (int)(temp.flo * 10);
                    }
                    else
                    {
                        temp = x.Next();
                        bucket = (int)(temp.flo * 10);
                    }

                    string fileName = "LBucket" + bucket + ".dat";
                    string path = @"..\..\data2\" + fileName;

                    if (!File.Exists(path))
                        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                        {
                            writer.Write(4);
                            Byte[] str = Encoding.ASCII.GetBytes(temp.str);
                            writer.Write(str);
                            writer.Write(temp.flo);
                            writer.Write((lengths[bucket] + 1) * 12 + 4);
                            lengths[bucket] += 1;
                        }
                    else
                        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                        {
                            Byte[] str = Encoding.ASCII.GetBytes(temp.str);
                            writer.Write(str);
                            writer.Write(temp.flo);
                            writer.Write((lengths[bucket] + 1) * 12 + 4);
                            lengths[bucket] += 1;
                        }
                }
                MyFileList ats = new MyFileList(@"Lats.dat", x.Length);
                using (BinaryWriter writer = new BinaryWriter(File.Open(@"Lats.dat", FileMode.Create)))
                {
                    writer.Write(4);
                    int ind = 0;
                    foreach (FileInfo file in di.GetFiles())
                    {
                        int length = lengths[int.Parse(file.Name.Substring(7, 1))];
                        MyFileList buck = new MyFileList(@"..\..\data2\" + file.Name, length);

                        using (buck.fs = new FileStream(@"..\..\data2\" + file.Name, FileMode.Open, FileAccess.ReadWrite))
                        {
                            //buck.Print(buck.Length);
                            InsertionSort(buck);

                            for (int j = 0; j < length; j++)
                            {
                                Objektas t;
                                if (j == 0)
                                    t = buck.Head();
                                else
                                    t = buck.Next();
                                Byte[] str = Encoding.ASCII.GetBytes(t.str);
                                writer.Write(str);
                                writer.Write(t.flo);
                                writer.Write((ind + 1) * 12 + 4);
                                ind++;
                            }
                        }
                    }
                }
                return ats;
            }

            private static MyFileArray BucketSortArray(DataArray x)
            {
                DirectoryInfo di = new DirectoryInfo(@"..\..\data\");
                foreach (FileInfo file in di.GetFiles())
                    if (file.Name.Contains("ABucket"))
                        file.Delete();

                int[] lengths = new int[10];

                for (int i = 0; i < x.Length; i++)
                {
                    Objektas key = x[i];
                    int bucket = (int)(key.flo * 10);
                    string fileName = "ABucket" + bucket + ".dat";
                    string path = @"..\..\data\" + fileName;

                    if (!File.Exists(@"..\..\data\" + fileName))
                        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                        {
                            Byte[] str = Encoding.ASCII.GetBytes(key.str);
                            writer.Write(str);
                            writer.Write(key.flo);
                            lengths[bucket] = 1;
                        }
                    else
                        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                        {
                            Byte[] str = Encoding.ASCII.GetBytes(key.str);
                            writer.Write(str);
                            writer.Write(key.flo);
                            lengths[bucket] += 1;
                        }
                }
                MyFileArray ats = new MyFileArray(@"ats.dat", x.Length);
                using (BinaryWriter writer = new BinaryWriter(File.Open(@"ats.dat", FileMode.Create)))
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        int length = lengths[int.Parse(file.Name.Substring(7, 1))];
                        MyFileArray buck = new MyFileArray(@"..\..\data\" + file.Name, length);

                        using (buck.fs = new FileStream(@"..\..\data\" + file.Name, FileMode.Open, FileAccess.ReadWrite))
                        {
                            InsertionSort(buck);

                            for (int j = 0; j < length; j++)
                            {
                                Byte[] str = Encoding.ASCII.GetBytes(buck[j].str);
                                writer.Write(str);
                                writer.Write(buck[j].flo);
                            }
                        }
                    }
                }
                return ats;
            }
            public static void InsertionSort(DataArray myArray)
            {
                int n = myArray.Length;
                for (int i = 1; i < n; ++i)
                {
                    Objektas key = myArray[i];
                    int j = i - 1;

                    while (j >= 0 && CompareV1(myArray[j], key) > 0)
                    {
                        myArray.SetValue(j + 1, myArray[j]);
                        j = j - 1;
                    }
                    myArray.SetValue(j + 1, key);
                }
            }
            public static void InsertionSort(DataList myList)
            {
                int n = myList.Length;
                for (int i = 1; i < n; ++i)
                {
                    Objektas key = myList.ElementAt(i);
                    int j = i - 1;

                    while (j >= 0 && CompareV1(myList.ElementAt(j), key) > 0)
                    {
                        myList.SetValue(j + 1, myList.ElementAt(j));
                        j = j - 1;
                    }
                    myList.SetValue(j + 1, key);
                }
            }

            public static int CompareV1(Objektas a, Objektas b)
            {
                if (a.flo == b.flo)
                    return a.str.CompareTo(b.str);
                else
                    return a.flo.CompareTo(b.flo);
            }
        }
    }
}