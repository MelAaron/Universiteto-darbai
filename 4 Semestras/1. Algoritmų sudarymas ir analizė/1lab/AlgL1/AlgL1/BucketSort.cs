using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1
{
    class BucketSort
    {
        private static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            int[] numOfData = { 1000, 2000, 3000, 20000, 60000 };


            //Test_Array_List(seed);//Rikiavimas
            Benchmark(seed, numOfData);
        }
        #region Array
        private static void BucketSortArray(DataArray x)
        {
            int numOfBuckets = 10;

            List<Objektas>[] buckets = new List<Objektas>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<Objektas>();
            }

            for (int i = 0; i < x.Length; i++)
            {
                int bucket = (int)(x[i].flo * numOfBuckets);
                buckets[bucket].Add(x[i]);
            }
            int a = 0;
            for (int i = 0; i < numOfBuckets; i++)
            {
                BubbleSort(buckets[i]);
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    x.Change(a, buckets[i][j]);
                    a++;
                }
            }
        }
        #endregion
        private static void BucketSortList(DataList x)
        {
            int numOfBuckets = 10;

            List<Objektas>[] buckets = new List<Objektas>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<Objektas>();
            }

            Objektas temp = x.Head();
            buckets[(int)(temp.flo * numOfBuckets)].Add(temp);
            for (int i = 1; i < x.Length; i++)
            {
                temp = x.Next();
                int bucket = (int)(temp.flo * 10);
                buckets[bucket].Add(temp);
            }
            int a = 0;
            x.clear();
            for (int i = 0; i < numOfBuckets; i++)
            {
                BubbleSort(buckets[i]);
                x.addAll(buckets[i]);
            }
        }
        public static void BubbleSort(List<Objektas> items)
        {
            Objektas prevdata, currentdata;
            for (int i = items.Count - 1; i >= 0; i--)
            {
                currentdata = items[0];
                for (int j = 1; j <= i; j++)
                {
                    prevdata = currentdata;
                    currentdata = items[j];
                    if (prevdata > currentdata)
                    {
                        items[j - 1] = currentdata;
                        items[j] = prevdata;
                        currentdata = prevdata;
                    }
                }
            }
        }
        public static void Test_Array_List(int seed)
        {
            int n = 12;
            MyDataArray myarray = new MyDataArray(n, seed);
            Console.WriteLine("\n ARRAY \n");
            myarray.Print(n);
            BucketSortArray(myarray);
            Console.WriteLine("\n SORTED \n");
            myarray.Print(n);

            MyDataList mylist = new MyDataList(n, seed);
            Console.WriteLine("\n LIST \n");
            mylist.Print(n);
            Console.WriteLine("\n SORTED \n");
            BucketSortList(mylist);
            mylist.Print(n);
        }
        public static void Benchmark(int seed, int[] dataCount)
        {
            Console.WriteLine("Array");
            for (int i = 0; i < dataCount.Length; i++)
            {
                int n = dataCount[i];
                MyDataArray myarray = new MyDataArray(n, seed);
                var benchmark = Stopwatch.StartNew();
                BucketSortArray(myarray);
                benchmark.Stop();
                Console.WriteLine("{0} - {1}", dataCount[i], benchmark.Elapsed);
            }
            Console.WriteLine("LinkedList");
            for (int i = 0; i < dataCount.Length; i++)
            {
                int n = dataCount[i];
                MyDataList mylist = new MyDataList(n, seed);
                var benchmark = Stopwatch.StartNew();
                BucketSortList(mylist);
                benchmark.Stop();
                Console.WriteLine("{0} - {1}", dataCount[i], benchmark.Elapsed);
            }
        }
    }

}