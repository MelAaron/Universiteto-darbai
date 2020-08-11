using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2Lab
{
    public class PubList
    {
        Knot first { get; set; }
        Knot last { get; set; }
        Knot current { get; set; }
        private sealed class Knot
        {
            public Publication publication { get; set; }
            public Knot next { get; set; }

            public Knot(Publication input, Knot adr)
            {
                publication = input;
                next = adr;
            }
        }
        /// <summary>
        /// sets the first and last pointers to null
        /// </summary>
        public PubList()
        {
            first = last = null;
        }
        /// <summary>
        /// adds publication to the end of the list
        /// </summary>
        /// <param name="pub">Publication</param>
        public void AddToEnd(Publication pub)
        {
            Knot temp = new Knot(pub, null);
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
        /// sets the current pointer to the next publication
        /// </summary>
        public void Next()
        {
            current = current.next;
        }
        /// <summary>
        /// checks if the current pointer is the last one
        /// </summary>
        /// <returns>true or false</returns>
        public bool End()
        {
            return current == null;
        }
        /// <summary>
        /// gets the current publication's data
        /// </summary>
        /// <returns>pblication's data</returns>
        public Publication PublicationData()
        {
            return current.publication;
        }
        /// <summary>
        /// checks if the list is empty
        /// </summary>
        /// <returns>true or false</returns>
        public bool Empty()
        {
            return first == null;
        }
        /// <summary>
        /// sets all publication's incomes to zero
        /// </summary>
        public void SetIncomeToZero()
        {
            for (Knot i = first; i != null; i = i.next)
            {
                i.publication.Income = 0;
            }
        }
        public void Pasalinti(Publication pasalinamasis)
        {
            Knot nuoroda = first;
            for (Knot laikinas = first; laikinas != null; laikinas = laikinas.next)
            {
                if (laikinas.publication.Equals(pasalinamasis))
                {
                    nuoroda.next = laikinas.next;
                    laikinas.publication = default(Publication);
                }
                else nuoroda = laikinas;
            }
        }
        /// <summary>
        /// sors the list
        /// </summary>
        public void Sorting()
        {
            bool bc = true;
            Knot d0, d1, r1;
            while (bc)
            {
                bc = false;
                d0 = d1 = r1 = first;
                while (d1 != null)
                {
                    if(d0.publication > d1.publication)
                    {
                        bc = true;
                        if(d0 == first)
                        {
                            first = first.next;
                            d0.next = d1.next;
                            d1.next = d0;
                        }
                        else
                        {
                            d0.next = d1.next;
                            d1.next = d0;
                            r1.next = d1;
                        }
                    }
                    r1 = d0;
                    d0 = d1;
                    d1 = d1.next;
                }
            }
        }
    }
}