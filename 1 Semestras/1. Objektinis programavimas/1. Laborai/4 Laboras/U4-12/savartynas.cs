using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_12
{
    class savartynas
    {
        //string Sentence(string[] lines)
        //{
        //    //var Sentencess = new Dictionary<string, int>();
        //    string text = Text(lines); //visas tekstas vienoj linijoj
        //    int sA = SentenceAmount(text); //sakiniu kiekis (kiek tasku tiek sakiniu)
        //    var Sentences = new string[sA];
        //    var periodP = PeriodP(text, sA);
        //    int pastP = 0;
        //    int k = 0;

        //    for (int i = 0; i < sA; i++)
        //    {
        //        Sentences[i] = text.Substring(pastP + 2, periodP[k] - pastP); //Sudaro string nuo praeito tasko iki sekancio
        //        pastP = periodP[k]; //sekantis taskas tampa buvusiu
        //        k++;
        //        //Console.WriteLine(SEN[i]);
        //    }
        //    string longestSen = LongestS(Sentences); //randa ir grazina ilgiausia sakini
        //    return longestSen;
        //}

        //string LongestS(string[] sentences)
        //{
        //    int maxL = 0;
        //    string longestS = sentences[0];
        //    for (int i = 0; i < sentences.Length; i++)
        //    {
        //        if (sentences[i].Length > maxL)
        //        {
        //            maxL = sentences[i].Length;
        //            longestS = sentences[i];
        //        }
        //    }
        //    return longestS;
        //}

        //string[] SentencesE(int sA)
        //{
        //    var sentences = new string[sA];
        //    for (int i = 0; i < sA; i++)
        //    {
        //        sentences[i] = "";
        //    }
        //    return sentences;
        //}

        //string Text(string[] lines)
        //{
        //    string text = "";
        //    for (int i = 0; i < lines.Length; i++)
        //    {
        //        text += " " + lines[i];
        //    }
        //    return text;
        //}

        //int SentenceAmount(string text)
        //{
        //    int periodA = 0;
        //    for (int i = 0; i < text.Length; i++)
        //    {
        //        if (text[i] == '.')
        //            periodA++;
        //    }
        //    return periodA;
        //}

        //int[] PeriodP(string text, int sA)
        //{
        //    var pP = new int[sA];
        //    int k = 0;
        //    for (int i = 0; i < text.Length; i++)
        //    {
        //        if (text[i] == '.')
        //        {
        //            pP[k] = i;
        //            k++;
        //        }
        //    }
        //    return pP;
        //}



        //public Dictionary<string, int> Zodziai(string[] lines, char[] skyrikliai)
        //{
        //    var DazZodziai = new Dictionary<string, int>();
        //    for (int i = 0; i < lines.Length; i++)
        //    {
        //        var line = lines[i];
        //        string[] zodziai = line.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
        //        for (int j = 0; j < zodziai.Length; j++)
        //        {
        //            var zodis = zodziai[j];
        //            if (!DazZodziai.ContainsKey(zodis))
        //            {
        //                DazZodziai.Add(zodis, 1);
        //            }
        //            else
        //            {
        //                DazZodziai.TryGetValue(zodis, out int value);
        //                value++;
        //                DazZodziai[zodis] = value++;
        //            }
        //        }
        //    }
        //    return DazZodziai;
        //}

        //public void PrintSentences(string fv, List<string> sentences)
        //{
        //    using (StreamWriter writer = new StreamWriter(@fv, true, Encoding.GetEncoding(1257)))
        //    {
        //        for (int i = 0; i < sentences.Count; i++)
        //        {
        //            writer.WriteLine(sentences[i]);
        //        }
        //    }
        //}

        //public void FindSentences(string fn, ref List<string> sentences)
        //{
        //    using (StreamReader sr = new StreamReader(@fn, Encoding.GetEncoding(1257)))
        //    {
        //        char[] sentenceEnd = { '.', '?', '!' };
        //        char[] seperators = { ' ', '-', ',', ':', ';', '(', ')', '\t' };
        //        string sentence = null;
        //        while (!sr.EndOfStream)
        //        {
        //            char ch = (char)sr.Read();
        //            sentence += ch;
        //            if (sentenceEnd.Contains(ch))
        //            {
        //                //Eliminuojam naujos eilutes simboli
        //                sentence = sentence.Replace(System.Environment.NewLine, "").Trim(seperators);
        //                sentences.Add(sentence);
        //                sentence = null;
        //            }
        //        }
        //    }
        //}

        //void Apdoroti (string FN)
        //{
        //    var Sentences = new SentenceContainer(100000);
        //    using (StreamReader sr = new StreamReader(FN))
        //    {
        //        string sentence = "";
        //        char cha;
        //        int pra=0, i=0;
        //        while((cha = (char)sr.Read()) != null)
        //        {
        //            i++;
        //            if((cha == '.')||(cha == '!')&&(cha == '?'))
        //            {
        //                Sentence newsentence = new Sentence(sentence, pra);
        //                Sentences.AddSentence(newsentence);
        //                pra = i;
        //            }
        //            else
        //            {
        //                sentence += cha;
        //            }
        //        }
        //    }
        //}

        //string[] Reading(string DFile)
        //{
        //    string[] lines = File.ReadAllLines(DFile, Encoding.GetEncoding(1257));
        //    return lines;
        //}
    }
}
