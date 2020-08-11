using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1_2
{
    class MyFileArray : DataArray
    {
        public MyFileArray(string filename, int n, int seed)
        {
            Objektas[] data = new Objektas[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                data[i] = new Objektas(CreateString(4,rand),(float)rand.NextDouble());
            }
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                    {
                        Byte[] str = Encoding.ASCII.GetBytes(data[j].str);
                        writer.Write(str);
                        writer.Write(data[j].flo);
                    }
                        //writer.Write(data[j]);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public MyFileArray(string filename, int n)
        {
            length = n;
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
        public override Objektas this[int index]
        {
            get
            {
                Byte[] data = new Byte[8];
                fs.Seek(8 * index, SeekOrigin.Begin);
                fs.Read(data, 0, 8);
                string s = Encoding.ASCII.GetString(data.Take(4).ToArray());
                float dataFloat = BitConverter.ToSingle(data, 4);
                return new Objektas(s, dataFloat);
            }
        }
        public override void Swap(int j, Objektas a, Objektas b)
        {
            Byte[] data = new Byte[16];
            BitConverter.GetBytes(a.flo).CopyTo(data, 0);
            BitConverter.GetBytes(b.flo).CopyTo(data, 8);
            fs.Seek(8 * (j - 1), SeekOrigin.Begin);
            fs.Write(data, 0, 16);
        }
        //public  void SetValue1(int i, Objektas v)
        //{
        //    Byte[] dataStr = Encoding.ASCII.GetBytes(v.str);
        //    Byte[] dataFloat = new Byte[8];
        //    BitConverter.GetBytes(v.flo).CopyTo(dataFloat, 4);

        //    fs.Seek(8 * i, SeekOrigin.Begin);
        //    fs.Write(dataStr, 0, 4);
        //    fs.Write(dataFloat, 4, 4);
        //}
        public override void SetValue(int i, Objektas v)
        {
            Byte[] data = new Byte[8];
            Encoding.ASCII.GetBytes(v.str).CopyTo(data, 0);
            BitConverter.GetBytes(v.flo).CopyTo(data, 4);
            fs.Seek(8 * i, SeekOrigin.Begin);
            fs.Write(data, 0, 8);
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
    }
}
