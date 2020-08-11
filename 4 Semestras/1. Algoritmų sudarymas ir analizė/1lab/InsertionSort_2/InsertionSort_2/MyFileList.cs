using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InsertionSort_2
{
    class MyFileList : DataList
    {
        int prevNode;
        int currentNode;
        int nextNode;
        public MyFileList(string filename, int n, int seed)
        {
            length = n;
            Random rand = new Random(seed);
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    writer.Write(4);
                    for (int j = 0; j < length; j++)
                    {
                        Byte[] str = Encoding.ASCII.GetBytes(CreateString(4, rand));
                        writer.Write(str);
                        writer.Write((float)rand.NextDouble());
                        writer.Write((j + 1) * 12 + 4);
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

        public override DataToSort Head()
        {
            Byte[] data = new Byte[12];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            currentNode = BitConverter.ToInt32(data, 0);
            prevNode = -1;
            fs.Seek(currentNode, SeekOrigin.Begin);
            fs.Read(data, 0, 12);

            string s = Encoding.ASCII.GetString(data.Take(4).ToArray());
            float dataFloat = BitConverter.ToSingle(data, 4);
            
            nextNode = BitConverter.ToInt32(data, 8);

            return new DataToSort(s, dataFloat);
        }
        public override DataToSort Next()
        {
            Byte[] data = new Byte[12];
            fs.Seek(nextNode, SeekOrigin.Begin);
            fs.Read(data, 0, 12);
            prevNode = currentNode;
            currentNode = nextNode;

            string s = Encoding.ASCII.GetString(data.Take(4).ToArray());
            float dataFloat = BitConverter.ToSingle(data, 4);

            nextNode = BitConverter.ToInt32(data, 8);
            return new DataToSort(s, dataFloat);
        }
        public override DataToSort ElementAt(int n)
        {
            DataToSort temp = Head();

            for (int i = 0; i < Length; i++)
            {
                if (i == n)
                {
                    return temp;
                }

                temp = Next();
            }

            return temp;
        }
        public override void SetValue(int i, DataToSort v)
        {
            DataToSort temp = Head();
            for (int x = 0; x < Length; x++)
            {
                if (x == i)
                {
                    Byte[] dataStr = Encoding.ASCII.GetBytes(v.dataString);
                    Byte[] dataFloat = new Byte[8];
                    BitConverter.GetBytes(v.dataFloat).CopyTo(dataFloat, 4);

                    fs.Seek(currentNode, SeekOrigin.Begin);

                    fs.Write(dataStr, 0, 4);
                    fs.Write(dataFloat, 4, 4);

                    break;
                }
                temp = Next();
            }
        }
    }
}
