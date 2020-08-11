using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2savarankiskas
{
    class Program
    {
        public const int MaxNumberOfFaculty = 50;

        static void Main(string[] args)
        {
            Branch[] branches = new Branch[MaxNumberOfFaculty];
            int Count = 0;
            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            
            foreach (string path in filePaths)
            {
                branches[Count++] = ReadMarkData(path);
            }

            for (int i = 0; i < Count; i++)
            {
                GroupsContainer groups = GetGroups(branches[i]);
                groups.SortGroups();
                Console.WriteLine(branches[i].Faculty);
                for (int j = 0; j < groups.Count; j++)
                {
                    Console.WriteLine("{0} {1:f}", groups.GetGroup(j).Name, groups.GetGroup(j).GetAverage());
                }
            }

            Console.ReadKey();

        }

        /// <summary>
        /// Read marks data from files
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Branch ReadMarkData(string file)
        {
            Branch branch = null;
            using (StreamReader reader = new StreamReader(@file))
            {
                string line = null;
                line = reader.ReadLine();
                if (line != null)
                {
                    branch = new Branch(line);
                }
                while (null != (line = reader.ReadLine()))
                {
                    int sum = 0;
                    string[] values = line.Split(';');
                    string surname = values[0];
                    string name = values[1];
                    string group = values[2];
                    int amount = int.Parse(values[3]);

                    for (int i = 4; i < amount + 4; i++)
                    {
                        int marks = int.Parse(values[i]);
                        sum += marks;
                    }

                    Student student = new Student(surname, name, group, amount, sum);
                    branch.AddStudent(student);
                }
            }
            return branch;
        }

        /// <summary>
        /// Find double placed groups
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static GroupsContainer GetGroups(Branch branch)
        {
            GroupsContainer groups = new GroupsContainer();
            for (int i = 0; i < branch.Count; i++)
            {
                bool found = false;
                for (int j = 0; j < groups.Count; j++)
                {
                    if (groups.GetGroup(j).Name.Equals(branch.Students[i].Group))
                    {
                        groups.GetGroup(j).Name.Equals(branch.Students[i]);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    groups.AddGroup(new Group(branch.Students[i].Group));
                    groups.GetGroup(groups.Count - 1).AddStudent(branch.Students[i]);
                }
             }
            return groups;
        }

    }
 }
