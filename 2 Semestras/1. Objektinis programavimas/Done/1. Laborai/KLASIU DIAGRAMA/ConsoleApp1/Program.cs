using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Console = Colorful.Console;
using Colorful;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth=140;
            bool exit = false;
            Console.WriteAscii("KLASIU DIAGRAMA", Color.FromArgb(255, 0, 120));
            Console.WriteAscii("SELECT YOUR FIGHTER", Color.FromArgb(200, 40, 80));

            
            int mode = ModeSelect();

            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            while (!exit)
            {
                if (mode == 1)
                {
                    while (!filepath.EndsWith(".cs"))
                    {
                        string[] files = AddUp(Directory.GetFiles(filepath, "*.cs"), Directory.GetDirectories(filepath));
                        DisplayPath(files);
                        filepath = NewPath(files, filepath);

                    }
                    GenerateTable(filepath);
                    filepath = filepath.Remove(filepath.LastIndexOf('\\'));

                }
                else if (mode == 2)
                {
                    while (true)
                    {
                        bool selected = false;
                        string[] files = AddUp(Directory.GetFiles(filepath, "*.cs"), Directory.GetDirectories(filepath));
                        DisplayPath(files);
                        filepath = NewPath(files, filepath, out selected);
                        Console.WriteLine(Console.WindowWidth);
                        if (selected) break;
                    }
                    string[] csFiles = Directory.GetFiles(filepath, "*.cs");
                    foreach (string file in csFiles)
                        GenerateTable(file);
                }
                else return;
                Console.WriteLineFormatted("Jei norite {0} sugeneruotu failu vieta, spauskite {1}, kitu atveju paspauskite betkoki mygtuka", Color.LawnGreen, Color.RoyalBlue, "atidaryti","A");
                if(Console.ReadLine().ToLower() == "a")
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = filepath,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                Console.WriteLineFormatted("Jei norite {0} nauja - spauskite {1}, jei norite iseiti - spauskite {2} ", Color.LawnGreen, Color.RoyalBlue, "pasirinkti", "N", "Y");
                if (Console.ReadLine() == "Y")exit = true;
            }
        }
        static int ModeSelect()
        {
            Console.WriteLineFormatted("1: {0} diagramos generatorius", Color.LawnGreen, Color.RoyalBlue, "Vieno failo");
            Console.WriteLineFormatted("2: {0} diagramu generatorius", Color.Orange, Color.RoyalBlue, "Keliu failu viename folderije");
            Console.WriteLineFormatted("3: {0}", Color.Red, Color.RoyalBlue, "Exit");
            return int.Parse(Console.ReadLine());
        }
        static void DisplayPath(string[] files)
        {
            //ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
           // ColorAlternator alternator = alternatorFactory.GetAlternator(1, Color.Orange, Color.Fuchsia);
            Console.Clear();
            string h = new string('#', 45);
            Console.WriteLine(h + "Files" + h, Color.IndianRed);
            int n = 1;
            foreach (string file in files)
            {
                //Console.WriteLineAlternating(n++ + ": " + file, alternator);
                Console.WriteLine(n++ + ": " + file, (file.EndsWith(".cs") ? Color.Fuchsia : Color.Orange));
            }
            Console.WriteLine(h + h + "#####", Color.IndianRed);
        }
        static string NewPath(string[] paths, string filepath)
        {
            Console.WriteLineFormatted("{2} nauja path arba .cs faila irasydami atitinkanti {1}, jei norite paeiti atgal pasirinkite {0}", "-1", "skaiciu", "Pasirinkite", Color.LawnGreen, Color.RoyalBlue);
            Console.ForegroundColor = Color.LimeGreen;
            int index = int.Parse(Console.ReadLine());
            if (index < 0) return filepath.Remove(filepath.LastIndexOf('\\'));
            return paths[index - 1];
        }
        static string NewPath(string[] paths, string filepath, out bool selected)
        {
            selected = false;
            Console.WriteLineFormatted("{2} nauja path spaudziant atitinkanti {1}, jei norite paeiti atgal pasirinkite {0} arba spauskite {3} norint sugeneruot visu .cs failu diagramas", "-1", "skaiciu", "Pasirinkite", "E", Color.LawnGreen, Color.RoyalBlue);
            Console.ForegroundColor = Color.LimeGreen;
            string s = Console.ReadLine();
            if(s.ToLower() == "e")
            {
                selected = true;
                return filepath;
            }
            else if (int.Parse(s) < 0) return filepath.Remove(filepath.LastIndexOf('\\'));
            return paths[int.Parse(s) - 1];
        }
        static string[] AddUp(string[] cs, string[] folders)
        {
            int n = 0;
            string[] temp = new string[cs.Count() + folders.Count()];
            foreach (string path in folders)
                temp[n++] = path;
            foreach (string path in cs)
                temp[n++] = path;
            return temp;
        }
        static void GenerateTable(string path)
        {
            bool insideClass = false;
            using (StreamReader sr = new StreamReader(path))
            {
                using (StreamWriter sw = new StreamWriter(path.TrimEnd(".cs".ToCharArray())+"Diagrama.txt"))
                {
                    string line = sr.ReadLine();
                    int inclass = 0;
                    while (!sr.EndOfStream && !insideClass)
                    {
                        line = sr.ReadLine();
                        if (line.Contains("class")) insideClass = true;
                    }
                    WriteLine(sw,"---------" + noSpace(line.Split(' '))[ClassIndex(noSpace(line.Split(' ')))] + "---------", Color.Orange);


                    insideClass = false;

                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        if (line.Contains("class"))
                        {
                            insideClass = true;
                            inclass = 0;
                            WriteLine(sw,"---------" + noSpace(line.Split(' '))[ClassIndex(noSpace(line.Split(' ')))] + "---------", Color.Orange);
                            continue;
                        }
                        if (insideClass)
                        {
                            if (line.Contains('{')) inclass++;
                            if (line.Contains('}')) inclass--;
                        }
                        if (insideClass && inclass <= 0)
                        {
                            insideClass = false;
                            WriteLine(sw,new string('-', 30), Color.Orange);
                        }


                        if (line.Contains('{') && line.Contains('}') && (line.Contains("get;") || line.Contains("set;")))
                        {
                            
                            string[] values = noSpace(line.Remove(line.IndexOf('{')).Split(' '));
                            WriteLine(sw,Visablity(values[0]) + values[2] + " : " + er(values[1]));
                        }
                        else if (line.Contains("private ") || line.Contains("public ") || line.Contains("static ") || line.Contains("protected "))
                        {
                            if (!line.Contains('('))
                            {
                                
                                string[] values = noSpace(line.Remove(line.IndexOf(";")).Split(' '));
                                WriteLine(sw,Visablity(values[0]) + values[2] + " : " + er(values[1]));
                            }
                            else
                            {
                                string[] values = noSpace(line.Substring(0, line.IndexOf('(')).Split(' '));
                                if (values.Count() == 2)//tik konstruktoriia, 3 tai normalus
                                {
                                    Write(sw,Visablity(values[0]) + values[1]);
                                    WriteLine(sw,inBetweenBrackets(line));
                                }
                                else if (values.Count() == 3)
                                {
                                    Write(sw,Visablity(values[0]) + values[2]);
                                    Write(sw,inBetweenBrackets(line));
                                    WriteLine(sw,(values[1].Contains("void") ? "" : " : " + er(values[1])));
                                }
                                else if (values.Count() > 3)
                                {
                                    Write(sw,Visablity(values[0]) + values[values.Count() - 1]);
                                    Write(sw,inBetweenBrackets(line));
                                    WriteLine(sw,(values[2].Contains("void") ? "" : " : " + er(values[2])));
                                }

                            }
                        }
                        else  if( (line.Contains('(') && line.Contains(')')) && noSpace(line.Substring(0, line.IndexOf('(')).Split(' ')).Count()==2)
                        {
                            if (line.IndexOf('(') - line.IndexOf(')') < -1 &&
                                noSpace(line.Substring(line.IndexOf('(') + 1, line.IndexOf(')') - line.IndexOf('(') - 1).Split(','))[0].Split(' ').Count() !=2) continue;

                                string[] values = noSpace(line.Substring(0, line.IndexOf('(')).Split(' '));
                            Write(sw, "-"+values[1]);
                            Write(sw, inBetweenBrackets(line));
                            WriteLine(sw, (values[0].Contains("void") ? "" : " : " + er(values[0])));
                        }
                        
                    }
                    WriteLine(sw,new string('-', 30), Color.Orange);
                }
            }
        }
        static string er(string a)
        {
            if (a.Contains("int")) return a.Replace("int", "integer");
            if (a.Contains("bool")) return a.Replace("bool", "boolean");
            if (a.Contains("double")) return a.Replace("double", "float");
            else return a;
        }
        static string Visablity(string a)
        {
            if (a.Contains("private")) return "-";
            else if (a.Contains("public")) return "+";
            else return "#";
        }
        static string[] noSpace(string[] a)
        {
            int count = 0;
            foreach (string var in a)
                if (var != "") count++;
            string[] temp = new string[count];
            count = 0;
            foreach (string var in a)
                if (var != "") temp[count++] = var;
            return temp;
        }
        static string inBetweenBrackets(string line)
        {
            string ret = "(";
            if (line.IndexOf('(') - line.IndexOf(')') < -1)
            {
                string[] values = noSpace(line.Substring(line.IndexOf('(') + 1, line.IndexOf(')') - line.IndexOf('(') - 1).Split(','));
                foreach (string sub in values)
                {
                    string[] subval = noSpace(sub.Split(' '));
                    if (subval.Count() == 2) ret += string.Format("in {0} :{1}", subval[1], er(subval[0]));
                    if (!(sub == values[values.Count() - 1])) ret += ", ";
                }
            }
            ret += ")";
            return ret;
        }
        static int ClassIndex(string[] values)
        {
            int a = 0;
            foreach(string temp in values)
            {
                if (temp.Contains("class")) return a+1;
                else a++;
            }
            return 2;
        }
        static void Write(StreamWriter sw, string text, Color c)
        {
            sw.Write(text);
            Console.Write(text, c);
        }
        static void WriteLine(StreamWriter sw, string text, Color c)
        {
            sw.WriteLine(text);
            Console.WriteLine(text, c);
        }
        static void Write(StreamWriter sw, string text)
        {
            sw.Write(text);
            Console.Write(text);
        }
        static void WriteLine(StreamWriter sw, string text)
        {
            sw.WriteLine(text);
            Console.WriteLine(text);
        }
    }
}
