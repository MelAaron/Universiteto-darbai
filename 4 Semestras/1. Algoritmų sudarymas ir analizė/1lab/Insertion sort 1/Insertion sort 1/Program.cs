using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insertion_sort_1
{
    class Program
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            Program p = new Program();
            int[] NumberOfLines = { 100, 200, 300, 2000, 6000};
            p.test1();
            //p.test2(NumberOfLines);
            Console.WriteLine("Darbas sekmingai baigtas");
            Console.ReadKey();
            
        }
        #region Test1
        void test1()
        {
            int n, from, to;
            Console.WriteLine("Iveskite eiluciu skaiсiu");
            n = int.Parse(Console.ReadLine());
            createNewFile(n);
            List<Line> LinesList = Read();

            Console.WriteLine("Pradiniai duomenys");
            foreach (Line e in LinesList)
            {
                Console.WriteLine(e.toString());
            }
            Console.WriteLine();
            Console.WriteLine("Nuo kelintos eilutes rusiuoti?");
            from = int.Parse(Console.ReadLine());
            Console.WriteLine("Iki kelintos eilutes rusiuoti?");
            to = int.Parse(Console.ReadLine());
            LinesList = CropsList(LinesList, from, to);
            Line[] LinesArray = LinesList.ToArray();
            Lines LinesLinkedList = CreatesLinkedList(LinesList);
            Console.WriteLine();
            var watch = Stopwatch.StartNew();
            sort(LinesArray);
            watch.Stop();
            Console.WriteLine("Surusiuotas masyvas");
            print(LinesArray);
            Console.WriteLine(watch.Elapsed);

            watch = Stopwatch.StartNew();
            LinesLinkedList.insertionSort();
            watch.Stop();

            Console.WriteLine("Linked list surusiuotas");
            LinesLinkedList.printlist();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(watch.Elapsed);
        }
        List<Line> CropsList(List<Line> LinesList, int from, int to)
        {
            List<Line> NewList = new List<Line>();
            from--;
            to--;
            int i = 0;
            foreach (Line line in LinesList)
            {
                if (i >= from && i <= to)
                {
                    NewList.Add(line);
                }
                i++;
            }
            return NewList;
        }
        #endregion
        #region Test2
        void test2(int[] NumberOfLines)
        {

            Console.WriteLine("Masyvas");
            for (int i = 0; i < NumberOfLines.Length; i++)
            {
                createNewFile(NumberOfLines[i]);
                List<Line> LinesList = Read();
                Line[] LinesArray = LinesList.ToArray();
                var watch = Stopwatch.StartNew();
                sort(LinesArray);
                watch.Stop();
                Console.WriteLine("{0} - {1}", NumberOfLines[i], watch.Elapsed);
            }

            Console.WriteLine("Sarasas");
            for (int i = 0; i < NumberOfLines.Length; i++)
            {
                createNewFile(NumberOfLines[i]);
                List<Line> LinesList = Read();
                Lines LinesLinkedList = CreatesLinkedList(LinesList);
                var watch = Stopwatch.StartNew();
                LinesLinkedList.insertionSort();
                watch.Stop();
                Console.WriteLine("{0} - {1}", NumberOfLines[i], watch.Elapsed);
            }
        }
        #endregion
        #region Failo kurimas ir skaitymas
        List<Line> Read()
        {
            //  LinkedList<Eilute> 
            List<Line> Lines = new List<Line>();

            string fil = @"test.txt";
            using (StreamReader sr = new StreamReader(fil))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    string[] parts = line.Split(' ');
                    Line eil = new Line(parts[0], float.Parse(parts[1]));
                    Lines.Add(eil);
                }
            }
            return Lines;
        }
        void createNewFile(int n)
        {
            string[] stringarray = StringArrayGen(n);
            File.WriteAllLines(@"test.txt", stringarray);
        }
        public string[] StringArrayGen(int length)
        {
            string[] StringArray = new string[length];
            for (int i = 0; i < length; i++)
            {
                StringArray[i] = RandomString(4) + " " + RandomFloat(4);
            }
            return StringArray;
        }

        public string RandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string RandomFloat(int length)
        {
            string chars = "123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion
        #region rasymas
        void print(Line[] Lines)
        {
            Console.WriteLine("masyvas");
            foreach (Line e in Lines)
            {
                Console.WriteLine(e.toString());
            }
        }
        #endregion
        #region saraso kurimas
        Lines CreatesLinkedList(List<Line> LinesList)
        {
            Lines LinesLinkedList = new Lines();
            foreach (Line e in LinesList)
            {
                LinesLinkedList.push(e);
            }
            return LinesLinkedList;
        }
        #endregion
        #region masyvo rikiavimas
        void sort(Line[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                Line key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j].ComapareTo(key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        #endregion

    }

}
