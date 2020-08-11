using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BucketSort
    {
        public static List<int> Sort(params int[] x)
        {
            List<int> sortedArray = new List<int>();

            int numOfBuckets = 10;

            //Create buckets
            List<int>[] buckets = new List<int>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            //Iterate through the passed array and add each integer to the appropriate bucket
            for (int i = 0; i < x.Length; i++)
            {
                int bucket = (x[i] / numOfBuckets);
                buckets[bucket].Add(x[i]);
            }

            //Sort each bucket and add it to the result List
            for (int i = 0; i < numOfBuckets; i++)
            {
                List<int> temp = InsertionSort(buckets[i]);
                sortedArray.AddRange(temp);
            }
            return sortedArray;
        }

        //Insertion Sort
        public static List<int> InsertionSort(List<int> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                //2. Store the current value in a variable
                int currentValue = input[i];
                int pointer = i - 1;

                //3. As long as we are pointing to a valid value in the array...
                while (pointer >= 0)
                {
                    //4. If the current value is less than the value we are pointing at...
                    if (currentValue < input[pointer])
                    {
                        //5. Move the pointed-at value up one space, and insert the current value at the pointed-at position.
                        input[pointer + 1] = input[pointer];
                        input[pointer] = currentValue;
                    }
                    else break;
                }
            }

            return input;
        }
        //private static void Main(string[] args)
        //{
        //    int[] array = new int[] { 43, 17, 87, 92, 31, 6, 96, 13, 66, 62, 4 };

        //    Console.WriteLine("Bucket Sort");

        //    foreach (int num in array)
        //        Console.WriteLine(num);

        //    List<int> sorted = Sort(array);

        //    foreach (int num in sorted)
        //        Console.WriteLine(num);
        //    Console.ReadLine();
        //}
    }
}


