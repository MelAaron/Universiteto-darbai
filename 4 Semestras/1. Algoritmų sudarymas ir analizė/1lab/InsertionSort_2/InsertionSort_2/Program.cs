using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Test_File_Array_List(seed);

            Console.ReadKey();
        }

        public static void InsertionSort(DataArray myArray)
        {
            int n = myArray.Length;
            for (int i = 1; i < n; ++i)
            {
                DataToSort key = myArray[i];
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
                DataToSort key = myList.ElementAt(i);
                int j = i - 1;

                while (j >= 0 && CompareV1(myList.ElementAt(j), key) > 0)
                {
                    myList.SetValue(j + 1, myList.ElementAt(j));
                    j = j - 1;
                }
                myList.SetValue(j + 1, key);
            }
        }
        public static int CompareV1(DataToSort a, DataToSort b)
        {
            if (a.dataString == b.dataString)
            {
                return a.dataFloat.CompareTo(b.dataFloat);
            }
            else
            {
                return a.dataString.CompareTo(b.dataString);
            }
        }
        public static void Test_File_Array_List(int seed)
        {
            int n = 12;
            string filename;
            filename = @"mydataarray.dat";
            MyFileArray myfilearray = new MyFileArray(filename, n, seed);
            using (myfilearray.fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                Console.WriteLine("\n FILE ARRAY \n");
                myfilearray.Print(n);
                InsertionSort(myfilearray);
                Console.WriteLine();
                Console.WriteLine("Sorted:");
                myfilearray.Print(n);
                Console.WriteLine();
            }
            filename = @"mydatalist.dat";
            MyFileList myfilelist = new MyFileList(filename, n, seed);
            using (myfilelist.fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                Console.WriteLine("\n FILE LIST \n");
                myfilelist.Print(n);
                InsertionSort(myfilelist);
                Console.WriteLine("Sorted:");
                myfilelist.Print(n);
                Console.WriteLine();
            }
        }
    }
}
