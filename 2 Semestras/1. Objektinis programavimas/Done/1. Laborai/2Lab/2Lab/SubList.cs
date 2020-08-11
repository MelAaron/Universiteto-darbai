using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace _2Lab
{
    public class SubList
    {
        Knot first { get; set; }
        Knot last { get; set; }
        Knot current { get; set; }
        private sealed class Knot
        {
            public Subscriber subscriber { get; set; }
            public Knot next { get; set; }

            public Knot(Subscriber input, Knot adr)
            {
                subscriber = input;
                next = adr;
            }
        }
        /// <summary>
        /// sets the first and last knots to null
        /// </summary>
        public SubList()
        {
            first = last = null;
        }
        /// <summary>
        /// Adds a subscriber to the end of the list
        /// </summary>
        /// <param name="sub">subscriber data</param>
        public void AddToEnd(Subscriber sub)
        {
            Knot temp = new Knot(sub, null);
            if (first == null)
            {
                first = last = temp;
            }
            else
            {
                last.next = temp;
                last = temp;
            }
        }
        /// <summary>
        /// sets the current pointer to the first
        /// </summary>
        public void First()
        {
            current = first;
        }
        /// <summary>
        /// sets the current pointer to the next one
        /// </summary>
        public void Next()
        {
            current = current.next;
        }
        /// <summary>
        /// checks of the current pointer is the last one
        /// </summary>
        /// <returns>true or false</returns>
        public bool End()
        {
            return current == null;
        }
        /// <summary>
        /// gets the current pointer's subscriber's data
        /// </summary>
        /// <returns></returns>
        public Subscriber SubscriberData()
        {
            return current.subscriber;
        }
        /// <summary>
        /// checks if the list is empty
        /// </summary>
        /// <returns>true or false</returns>
        public bool Empty()
        {
            return first == null;
        }
    }
}