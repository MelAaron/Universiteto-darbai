using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insertion_sort_1
{
    class Lines
    {
         node head;
         node selected;
         node sorted;

        public class node
        {
            public Line val;
            public node next;

            public node(Line val)
            {
                this.val = val;
            }
        }
        public void First()
        {
            selected = head;
        }
        public void Next()
        {
            if(selected.next!=null)
            selected = selected.next;

        }
        public Line Take()
        {
            return selected.val;
        }

        public void push(Line val)
        {
            node newnode = new node(val);
            newnode.next = head;
            head = newnode;
        }
       public void insertionSort()
        {
            sorted = null;
            node current = head;
            while (current != null)
            {
                node next = current.next;
                sortedInsert(current);
                current = next;
            }
            head = sorted;
        }

        /* 
        * function to insert a new_node in a list. Note that  
        * this function expects a pointer to head_ref as this 
        * can modify the head of the input linked list  
        * (similar to push()) 
        */
       public void sortedInsert(node newnode)
        {
            /* Special case for the head end */
            if (sorted == null || sorted.val.ComapareTo(newnode.val)>=0)
            {
                newnode.next = sorted;
                sorted = newnode;
            }
            else
            {
                node current = sorted;
                while (current.next != null && current.next.val.ComapareTo(newnode.val)<0)
                {
                    current = current.next;
                }
                newnode.next = current.next;
                current.next = newnode;
            }
        }

        /* Function to print linked list */
       public void printlist()
        {
            selected = head;
            while (selected != null)
            {
                Console.WriteLine(selected.val.toString());
                selected = selected.next;
            }
        }
    }
}
