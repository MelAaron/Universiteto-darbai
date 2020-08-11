using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_12
{
    class SentenceContainer
    {
        private Sentence[] Sentences;
        public int Count { get; private set; }

        /// <summary>
        /// creates  new sentence container
        /// </summary>
        /// <param name="size">size of container</param>
        public SentenceContainer(int size)
        {
            Sentences = new Sentence[size];
            Count = 0;
        }
        /// <summary>
        /// adds a sentence to the container
        /// </summary>
        /// <param name="sentence">given sentence</param>
        public void AddSentence (Sentence sentence)
        {
            Sentences[Count++] = sentence;
        }
        /// <summary>
        /// adds a sentence to the given place 
        /// </summary>
        /// <param name="sentence">the sentehce</param>
        /// <param name="index">the place in the container</param>
        public void AddSentence (Sentence sentence, int index)
        {
            Sentences[index] = sentence;
        }
        /// <summary>
        /// gets a sentence from the container
        /// </summary>
        /// <param name="index">index of sentence</param>
        /// <returns>the sentence</returns>
        public Sentence GetSentence (int index)
        {
            return Sentences[index];
        }
    }
}
