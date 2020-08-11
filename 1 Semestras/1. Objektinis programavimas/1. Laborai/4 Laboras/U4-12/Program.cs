using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace U4_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            const string Duom = "..\\..\\Knyga.txt";
            const string Rez = "..\\..\\Rodikliai.txt";
            const string Rez2 = "..\\..\\ManoKnyga.txt";
            var Sentences = new SentenceContainer(100);
            var lines = new List<string>();
            var words = new List<string>();
            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };

            p.FindSentences(Duom, ref Sentences);
            //p.PrintSentences(Rez, Sentences);
            p.Checking(Sentences, Rez);

            var UniqueW = p.Words(Sentences, skyrikliai);
            p.PrintDictionary(Rez, UniqueW);
            
            p.Processing(Duom, ref lines);
            //int LongestL = p.LongestLine(lines);
            var LongestW = p.AllWords(lines, skyrikliai, ref words);
            var NewLines = p.Task(lines, LongestW, skyrikliai);
            p.PrintList(NewLines, Rez2);
            Console.WriteLine();
        }

        /// <summary>
        /// Prints a given list
        /// </summary>
        /// <param name="lines">a list of lines</param>
        /// <param name="fn">file name</param>
        void PrintList (List<string> lines, string fn)
        {
            using (StreamWriter sw = new StreamWriter(@fn, false, Encoding.GetEncoding(1257)))
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    sw.WriteLine(lines[i]);
                }
            }
        }
        
        /// <summary>
        /// Goes through every line and word
        /// adds the amount of spaces needed to every word
        /// </summary>
        /// <param name="lines">a list of lines</param>
        /// <param name="LongestW">the longest word</param>
        /// <param name="seperators">word seperators</param>
        /// <returns>a modified list with spaces</returns>
        List <string> Task (List<string> lines, string LongestW,
            char[] seperators)
        {
            var NewLines = new List<string>();
            int SymbolAmount = LongestW.Length;
            for (int i = 0; i < lines.Count; i++)
            {
                string newline = "";
                var line = lines[i];
                string[] zodziai = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                // eilutes zodziu masyvas
                for (int j = 0; j < zodziai.Length; j++)
                {
                    var zodis = zodziai[j];
                    newline +=zodis + new string(' ', SymbolAmount - zodziai[j].Length);
                    
                }
                NewLines.Add(newline);
            }
            return NewLines;
        }

        /// <summary>
        /// Finds the longest word and returns it
        /// </summary>
        /// <param name="words">a list of words</param>
        /// <returns>longest word</returns>
        string LongestWo (List<string> words)
        {
            string LongWord = words[0];
            int LongWordsInd = 0;
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i] == null)
                    continue;
                if(words[i].Length >= LongWord.Length)
                {
                    LongWord = words[i];
                    LongWordsInd = i;
                }
            }
            return words[LongWordsInd];
        }

        /// <summary>
        /// finds all of the words and gets the longes one
        /// </summary>
        /// <param name="lines">a list of lines</param>
        /// <param name="seperators">word seperators</param>
        /// <param name="words">a list of words</param>
        /// <returns>the longest word</returns>
        string AllWords(List <string> lines, char[] seperators,
            ref List<string> words)
        {
            char ch;
            string word = null;
            for (int i = 0; i < lines.Count; i++) // eina per kiekviena eilute
            {
                var line = lines[i];
                for (int j = 0; j < line.Length; j++) //eina per vienos eilutes simbolius
                {
                    ch = line[j];
                    if (seperators.Contains(ch))
                    {
                        words.Add(word);
                        word = null;
                    }
                    else
                    word += ch;
                }
            }
            var LongestWord = LongestWo(words);
            return LongestWord;
        }

        /// <summary>
        /// finds the longest line
        /// </summary>
        /// <param name="lines">a list of lines</param>
        /// <returns>the longest line's index</returns>
        int LongestLine (List<string> lines)
        {
            string LongestL = lines[0];
            int LongestLIndex = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                if(lines[i].Length > LongestL.Length)
                {
                    LongestL = lines[i];
                    LongestLIndex = i;
                }
            }
            return LongestLIndex;
        }

        /// <summary>
        /// makes a list of lines in the text
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="lines">a list of lines</param>
        void Processing (string fn, ref List<string> lines)
        {
            using (StreamReader sr = new StreamReader(@fn, Encoding.GetEncoding(1257)))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    lines.Add(line);
                }
            }
        }

        /// <summary>
        /// Prints unique words and the amount of them in the text
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="words">dictionary of the unique words</param>
        void PrintDictionary (string fn, Dictionary <string, int> words)
        {
            var wordsS = from entry in words orderby entry.Value descending select entry;
            using (StreamWriter sw = new StreamWriter(@fn, true, Encoding.GetEncoding(1257)))
            {
                int j = 0;
                sw.WriteLine("Word          | Amount |");
                foreach (var entry in wordsS)
                {
                    if (j == 10)
                        break;

                    sw.WriteLine("{0,-14}|{1,-8}|", entry.Key, entry.Value);
                    //sw.WriteLine( entry.Key + " | " + entry.Value + "|");
                    sw.WriteLine("----------");
                    j++;
                }
            }
        }
        
        /// <summary>
        /// Prints the longest sentence, it's amount of words,
        /// symbols and whitch line it starts in
        /// </summary>
        /// <param name="sentences">sentence container</param>
        /// <param name="longestSIndex">longest sentence index</param>
        /// <param name="fn">file name</param>
        void PrintLongestS (SentenceContainer sentences, int longestSIndex, string fn)
        {
            using (StreamWriter sr = new StreamWriter(@fn, false, Encoding.GetEncoding(1257)))
            {
                var lSentence = sentences.GetSentence(longestSIndex);
                sr.WriteLine("Longest sentence: ");
                sr.WriteLine(lSentence.Sentencee);
                sr.WriteLine("Amount of symbols: {0} ",
                    lSentence.Sentencee.Length);
                sr.WriteLine("Amount of words: {0} ",
                    lSentence.WordAmount);
                sr.WriteLine("The sentence begins in line {0}",
                    lSentence.Beginning);
                sr.WriteLine();
            }
        }

        /// <summary>
        /// finds the longest sentence in the sentence container
        /// </summary>
        /// <param name="sentences">sentence container</param>
        /// <returns>the index of the longest sentence</returns>
        int LongestS (SentenceContainer sentences)
        {
            int LongestSen = sentences.GetSentence(0).WordAmount;
            int LongestSenIndex = 0;
            for (int i = 0; i < sentences.Count; i++)
            {
                if(sentences.GetSentence(i).WordAmount> LongestSen)
                {
                    LongestSen = sentences.GetSentence(i).WordAmount;
                    LongestSenIndex = i;
                }
            }
            return LongestSenIndex;
        }

        /// <summary>
        /// Reads file char by char. Builds sentences
        /// and puts them into a sentence container
        /// </summary>
        /// <param name="fn">file name</param>
        /// <param name="sentences">sentence container</param>
        public void FindSentences (string fn, ref SentenceContainer sentences)
        {
            using (StreamReader sr = new StreamReader(@fn, Encoding.GetEncoding(1257)))
            {
                char[] sentenceEnd = { '.', '?', '!' };
                char[] seperators = { ' ', '-', ',', ':', ';', '(', ')', '\t' };
                string sentence = null;
                int eilute = 0;
                int eil = 0;
                while (!sr.EndOfStream)
                {
                    char ch = (char)sr.Read();
                    sentence += ch;
                    if(sentenceEnd.Contains(ch))
                    {
                        if (sentences.Count == 0)
                        {
                            eilute = EnterAmount(eilute, sentence);
                            eil = eilute;
                            var wordA = WordAmount(sentence, seperators); 
                            //Eliminuojam naujos eilutes simboli
                            sentence = sentence.Replace(System.Environment.NewLine, "").Trim(seperators);
                            var SE = new Sentence(sentence, 0, wordA);
                            sentences.AddSentence(SE);
                            sentence = null;
                        }
                        else
                        {
                            eilute = EnterAmount(eilute, sentence);
                            var wordA = WordAmount(sentence, seperators);
                            //Eliminuojam naujos eilutes simboli
                            sentence = sentence.Replace(System.Environment.NewLine, "").Trim(seperators);
                            var SE = new Sentence(sentence, eil + 1, wordA);
                            sentences.AddSentence(SE);
                            eil = eilute;
                            sentence = null;
                        }
                    }
                }
                //Checking(sentences);
            }
            
        }

        /// <summary>
        /// checks if there are any sentences in the file
        /// </summary>
        /// <param name="Sentences">sentence container</param>
        /// <param name="fn">file name</param>
        void Checking (SentenceContainer Sentences, string fn)
        {
            int LongestSenIndex = 0;
            if (Sentences.Count != 0)
            {
                LongestSenIndex = LongestS(Sentences);
                PrintLongestS(Sentences, LongestSenIndex, fn);
            }
            else
                Console.WriteLine("There are no sentences");
        }

        //public void PrintSentences(string fv, SentenceContainer sentences)
        //{
        //    using (StreamWriter writer = new StreamWriter(@fv, true, Encoding.GetEncoding(1257)))
        //    {
        //        for (int i = 0; i < sentences.Count; i++)
        //        {
        //            writer.WriteLine(sentences.GetSentence(i).Sentencee);
        //        }
        //    }
        //}

        /// <summary>
        /// Calculates the amount of \n used in the given string
        /// </summary>
        /// <param name="eilute">a line</param>
        /// <param name="sentence">sentence</param>
        /// <returns>amount of \n</returns>
        public int EnterAmount (int eilute, string sentence)
        {
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == '\n')
                    eilute++;
            }
            return eilute;
        }

        /// <summary>
        /// Calculates and returns the amount of words that are in
        /// the given sentence
        /// </summary>
        /// <param name="sentence">sentehce in a string</param>
        /// <param name="seperators">word sepetators</param>
        /// <returns>amount of words in a sentence</returns>
        public int WordAmount (string sentence, char[] seperators)
        {
            int zodziuK = 0;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (seperators.Contains(sentence[i]))
                    zodziuK++;
            }
            return zodziuK;
        }

        /// <summary>
        /// Searches for words. If the word is unique, adds it to the dictionary
        /// otherwise, ads 1 to it's value
        /// </summary>
        /// <param name="sentences">gives a sentence</param>
        /// <param name="seperators">word seperators</param>
        /// <returns>dictionary of words</returns>
        public Dictionary<string, int> Words(SentenceContainer sentences, char[] seperators)
        {
            var ComWords = new Dictionary<string, int>();
            for (int i = 0; i < sentences.Count; i++)
            {
                var sentence = sentences.GetSentence(i).Sentencee;
                string[] words = sentence.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < words.Length; j++)
                {
                    var word = words[j];
                    if (!ComWords.ContainsKey(word))
                    {
                        ComWords.Add(word, 1);
                    }
                    else
                    {
                        ComWords.TryGetValue(word, out int value);
                        value++;
                        ComWords[word] = value++;
                    }
                }
            }
            return ComWords;
        }
        
    }
}
