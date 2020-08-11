using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2Lab
{
    public class Subscriber
    {
        public string LastName { get; set; }
        public string Adress { get; set; }
        public int SubscribtionStart { get; set; }
        public int SubscribtionDuration { get; set; }
        public string SubscribtionCode { get; set; }
        public int SubscribtionAmount { get; set; }
        /// <summary>
        /// creats a new subscriber object
        /// </summary>
        /// <param name="lastname">subscriber's last name</param>
        /// <param name="adress">subscriber's adress</param>
        /// <param name="subscribtionstart">subscriber's subscribtion start</param>
        /// <param name="subscribtionduration">subscriber's subscribtion duration</param>
        /// <param name="subscribtioncode">subscriber's subscribtion code</param>
        /// <param name="subscribtionamount">subscriber's subscribtion amount</param>
        public Subscriber (string lastname, string adress, int subscribtionstart, int subscribtionduration, string subscribtioncode, int subscribtionamount)
        {
            LastName = lastname;
            Adress = adress;
            SubscribtionStart = subscribtionstart;
            SubscribtionDuration = subscribtionduration;
            SubscribtionCode = subscribtioncode;
            SubscribtionAmount = subscribtionamount;
        }
        /// <summary>
        /// prints subscriber's information to one formated string
        /// </summary>
        /// <returns>formated information</returns>
        public override string ToString()
        {
            return String.Format("{0, -20} | {1, -20} | {2, -20} | {3, -25} | {4, -25} | {5, -20} |", LastName, Adress, SubscribtionStart, SubscribtionDuration, SubscribtionCode, SubscribtionAmount);
        }
        /// <summary>
        /// prints the header of a table for a table of subscribers
        /// </summary>
        /// <returns>formated header</returns>
        public string Header()
        {
            return String.Format("{0, -20} | {1, -20} | {2, 20} | {3, 25} | {4, 25} | {5, 20} |", "LastName", "Adress", "Subscribtion Start", "Subscribtion Duration", "Subscribtion Code", "Subscribtion Amount");
        }
    }
}