using System;
using System.IO;
using System.Linq;
using System.Text;

namespace InsertionSort_2
{
    class MyFileArray : DataArray
    {
        public MyFileArray(string filename, int n, int seed)
        {
            DataToSort[] data = new DataToSort[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                DataToSort d = new DataToSort(CreateString(4, rand), (float)rand.NextDouble());
                data[i] = d;
            }
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                    {
                        Byte[] str = Encoding.ASCII.GetBytes(data[j].dataString);
                        writer.Write(str);
                        writer.Write(data[j].dataFloat);
                    }
                        
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        internal static string CreateString(int stringLength, Random rd)
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            //const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
            //const string allowedChars = "A";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
        public FileStream fs { get; set; }

        public override DataToSort this[int index]
        {
            get
            {
                Byte[] data = new Byte[8];
                fs.Seek(8 * index, SeekOrigin.Begin);
                fs.Read(data, 0, 8);
                string s = Encoding.ASCII.GetString(data.Take(4).ToArray());
                float dataFloat = BitConverter.ToSingle(data, 4);

                return new DataToSort(s, dataFloat);
            }
        }

        public override void Print(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Byte[] data = new Byte[8];
                fs.Seek(8 * i, SeekOrigin.Begin);
                fs.Read(data, 0, 8);
    
                string s = Encoding.ASCII.GetString(data.Take(4).ToArray());
                float dataFloat = BitConverter.ToSingle(data, 4);
                Console.WriteLine("{0}, {1:F5}", s, dataFloat);
            }
        }
        public override void SetValue(int i, DataToSort v)
        {
            Byte[] dataStr = Encoding.ASCII.GetBytes(v.dataString);
            Byte[] dataFloat = new Byte[8];
            BitConverter.GetBytes(v.dataFloat).CopyTo(dataFloat, 4);

            fs.Seek(8 * i, SeekOrigin.Begin);
            fs.Write(dataStr, 0, 4);
            fs.Write(dataFloat, 4, 4);          
        }
    }
}