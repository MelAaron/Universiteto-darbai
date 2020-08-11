using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_12
{
    class Sentence
    {
        public string Sentencee { get; set; }
        public int Beginning { get; set; }
        public int WordAmount { get; set; }

        /// <summary>
        /// adds a new sentence
        /// </summary>
        /// <param name="sentence">sentence in a string</param>
        /// <param name="beginning">the beginning of a sentence</param>
        /// <param name="wordAmount">the end of the sentence</param>
        public Sentence (string sentence, int beginning, int wordAmount)
        {
            Sentencee = sentence;
            Beginning = beginning;
            WordAmount = wordAmount;
        }
    }
}
