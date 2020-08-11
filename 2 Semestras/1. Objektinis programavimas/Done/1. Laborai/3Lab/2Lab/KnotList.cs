using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace _2Lab
{
    public class KnotList<type> : IEnumerable<type> 
        where type : IComparable<type>, IEquatable<type>
    {
        private Knot<type> first;
        private Knot<type> last;
        private Knot<type> current;

        private sealed class Knot<type>
        {
            public type data { get; set; }
            public Knot<type> next { get; set; }
            public Knot<type> previous { get; set; }
            /// <summary>
            /// creates a new knot
            /// </summary>
            /// <param name="input">input data</param>
            /// <param name="adrN">previous knot</param>
            /// <param name="adrP">next knot</param>
            public Knot(type input, Knot<type> adrN, Knot<type> adrP)
            {
                data = input;
                previous = adrN;
                next = adrP;
            }
        }
        /// <summary>
        /// sets the first and last knots to null
        /// </summary>
        public KnotList()
        {
            this.first = this.last = current = null;
        }
        /// <summary>
        /// gets the current pointer's object's data
        /// </summary>
        /// <returns></returns>
        public type GetData()
        {
            return current.data;
        }
        /// <summary>
        /// Adds a object to the end of the list
        /// </summary>
        /// <param name="sub">subscriber data</param>
        public void AddToEnd(type newObject)
        {
            Knot<type> temp = new Knot<type>(newObject, last, null);
            if (first != null)
                last.next = temp;
            else
                first = temp;
            last = temp;
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
        /// sets the current pointer to the previous one
        /// </summary>
        public void Previous()
        {
            current = current.previous;
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
        /// checks if the list is empty
        /// </summary>
        /// <returns>true or false</returns>
        public bool Empty()
        {
            return first == null;
        }
        public void Last()
        {
            current = last;
        }
        /// <summary>
        /// sors the list
        /// </summary>
        public void Sorting()
        {
            for (Knot<type> n = first; n != null; n = n.next)
            {
                Knot<type> maxv = n;
                for (Knot<type> n2 = n; n2 != null; n2 = n2.next)
                    if (n2.data.CompareTo(maxv.data) < 0)
                        maxv = n2;
                type St = n.data;
                n.data = maxv.data;
                maxv.data = St;
            }
        }
        /// <summary>
        /// goes through list, saves last exit
        /// </summary>
        /// <returns>current one's data</returns>
        public IEnumerator<type> GetEnumerator()
        {
            for (Knot<type> dd = first; dd != null; dd = dd.next)
            {
                yield return dd.data;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}