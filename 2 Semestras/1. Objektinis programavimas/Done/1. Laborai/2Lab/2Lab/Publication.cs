using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2Lab
{
    public class Publication
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public double Income { get; set; }
        /// <summary>
        /// creates a new publication object
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Publication(string code, string name ,double price)
        {
            Code = code;
            Name = name;
            Price = price;

            Income = 0;
        }
        /// <summary>
        /// Operator. Compares by purice and name
        /// </summary>
        /// <param name="l">one pubication</param>
        /// <param name="r">other publication</param>
        /// <returns>true or false</returns>
        static public bool operator < (Publication l, Publication r)
        {
            if (l.Price.CompareTo(r.Price) == 0)
            {
                return (l.Name.CompareTo(r.Name) < 0);
            }
            else return (l.Price.CompareTo(r.Price) < 0);
        }
        /// <summary>
        /// > operator. Compares by price and name
        /// </summary>
        /// <param name="l">one publication</param>
        /// <param name="r">other publication</param>
        /// <returns>true or false</returns>
        static public bool operator > (Publication l, Publication r)
        {
            if (l.Price.CompareTo(r.Price) == 0)
            {
                return (l.Name.CompareTo(r.Name) > 0);
            }
            else return (l.Price.CompareTo(r.Price) > 0);
        }
        /// <summary>
        /// prinst all publication's data to one formated string
        /// </summary>
        /// <returns>formated publication's information</returns>
        public override string ToString()
        {
            return String.Format("{0, 10} | {1, -20} | {2, 5} |", Code, Name, Price);
        }
        /// <summary>
        /// prints formated header
        /// </summary>
        /// <returns>formated header string</returns>
        public string Header()
        {
            return String.Format("{0, -10} | {1, -20} | {2, -5} |","Code", "Name", "Price");
        }
    }
}