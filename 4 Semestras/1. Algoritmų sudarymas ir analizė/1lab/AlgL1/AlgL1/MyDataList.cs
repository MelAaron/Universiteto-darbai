using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgL1
{
    class MyDataList : DataList
    {
        class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }
            public Objektas data { get; set; }
            public MyLinkedListNode(Objektas data)
            {
                this.data = data;
            }
        }
        MyLinkedListNode headNode;
        MyLinkedListNode prevNode;
        MyLinkedListNode currentNode;
        public MyDataList(int n, int seed)
        {
            length = n;
            Random rand = new Random(seed);
            headNode = new MyLinkedListNode(new Objektas((float)rand.NextDouble(), CreateString(4, rand)));
            currentNode = headNode;
            for (int i = 1; i < length; i++)
            {
                prevNode = currentNode;
                currentNode.nextNode = new MyLinkedListNode(new Objektas((float)rand.NextDouble(), CreateString(4, rand)));
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = null;
        }
        public override void clear()
        {
            headNode = null;
            prevNode = null;
            currentNode = null;
        }
        public override void addAll(List<Objektas> items)
        {
            foreach (Objektas item in items)
            {
                if (headNode == null)
                {
                    headNode = new MyLinkedListNode(item);
                    currentNode = headNode;
                    continue;
                }
                prevNode = currentNode;
                currentNode.nextNode = new MyLinkedListNode(item);
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = null;
        }
        public override Objektas Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }
        public override Objektas Next()
        {
            prevNode = currentNode;
            currentNode = currentNode.nextNode;
            if (currentNode == null) return null;
            return currentNode.data;
        }
        public override void Swap(Objektas a, Objektas b)
        {
            prevNode.data = a;
            currentNode.data = b;
        }

        internal static string CreateString(int stringLength, Random rd)
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            char[] chars = new char[stringLength];
            for (int i = 0; i < stringLength; i++)
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            return new string(chars);
        }
    }
}
