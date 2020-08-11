using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Linq.Expressions;

namespace _4lab
{
    public partial class Form : System.Web.UI.Page
    {
        private List<Player> BestPlayers;
        private Dictionary<DateTime, List<Player>> MatchList;
        protected void Page_Load(object sender, EventArgs e)
        {
            BestPlayers = (List<Player>)Session["Best"];
            MatchList = (Dictionary<DateTime, List<Player>>)Session["Input"];
            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Add("-");
                DropDownList1.Items.Add("Striker");
                DropDownList1.Items.Add("Defender");
                DropDownList1.Items.Add("Center");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserInterfaceExceptions(TextBox1.Text, TextBox2.Text, TextBox3.Text, DropDownList1.SelectedValue);
            string WantedPosition = DropDownList1.SelectedValue;
            DateTime StartD = DateTime.Parse(TextBox1.Text);
            DateTime EndD = DateTime.Parse(TextBox2.Text);
            int PAmount = int.Parse(TextBox3.Text);

            Dictionary<DateTime, List<Player>> MatchList = new Dictionary<DateTime, List<Player>>();
            ReadData(MatchList);
            PrintInputDataToFile("Answer.txt", MatchList);
            PrintInputDataToTable(MatchList);
            InputDataShow();

            List<Player> BestPlayers = FindBestPlayers(WantedPosition, StartD, EndD, MatchList, PAmount);
            PrintAnswersToFile("Answer.txt", BestPlayers, WantedPosition);
            PrintAnswersToTable(BestPlayers);

            Session["Best"] = BestPlayers;
            Session["Input"] = MatchList;
            Button2.Visible = true;
        }
        /// <summary>
        /// Second button for sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            BestPlayers = BestPlayers.OrderBy(x => x.Team).ThenBy(x => x.LastName).ToList();
            PrintAnswersToTable(BestPlayers);
            if (CheckBox1.Checked == true)
                PrintInputDataToTable(MatchList);
        }
        #region Read Data
        /// <summary>
        /// Reads all files in given location that start with the string Match
        /// </summary>
        /// <param name="dictionary">the list that needs to be filled</param>
        public void ReadData(Dictionary<DateTime, List<Player>> dictionary)
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath(@"App_Data"), "Match*.txt");
            string PlayerInfo = Server.MapPath(@"App_Data/PlayerInfo.txt");
            FileExceptionControl(filePaths, PlayerInfo);
            foreach (string path in filePaths)
            {
                List<Player> list = new List<Player>();
                DateTime date;
                ReadMatchData(path, list, out date);
                ReadPosition(PlayerInfo, list);
                dictionary.Add(date, list);
            }

        }
        /// <summary>
        /// Reads individual match file
        /// </summary>
        /// <param name="file">given match file</param>
        /// <param name="list">given list</param>
        /// <param name="date">date from the first line of the file</param>
        public void ReadMatchData(string file, List<Player> list, out DateTime date)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                int counter = 1;
                EmptyFileException(file);
                date = DateTime.Parse(sr.ReadLine());
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] val = line.Split(';');
                    if (MatchFileControl(val, counter, file))
                        continue;
                    string TName = val[0];
                    string LName = val[1];
                    string Name = val[2];
                    int MPlayed = int.Parse(val[3]);
                    int PScored = int.Parse(val[4]);
                    int MMade = int.Parse(val[5]);
                    Player pl = new Player(TName, LName, Name, MPlayed, PScored, MMade);
                    if (!list.Contains(pl))
                        list.Add(pl);
                    counter++;
                }
            }
        }
        /// <summary>
        /// Reads the position file
        /// </summary>
        /// <param name="file">file location</param>
        /// <param name="list">player list</param>
        public void ReadPosition(string file, List<Player> list)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                int counter = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] val = line.Split(';');
                    if (PlayerInfoControl(val, counter, file)) //----------------------------------------------------------------------------------------------------
                        continue;
                    
                    var a = list.Find(x => x.Team == val[0] && x.LastName == val[1] && x.Name == val[2]);
                    if (a != null) a.SetPosition(val[3]);
                    counter++;
                }
            }
        }
        #endregion

        #region Get Best Players
        /// <summary>
        /// finds the best player from the list and deletes him after adding to new list
        /// </summary>
        /// <param name="WishedPosition">user chosen position</param>
        /// <param name="StartD">user chosen starting date</param>
        /// <param name="EndD">user chosen ending date</param>
        /// <param name="list">the list of players </param>
        /// <param name="MaxPlayers">The amount of players to be selected</param>
        /// <returns>list of best players</returns>
        public List<Player> FindBestPlayers(string WishedPosition, DateTime StartD, DateTime EndD, Dictionary<DateTime, List<Player>> list, int MaxPlayers)
        {
            return list.Where(nn => nn.Key >= StartD && nn.Key <= EndD).SelectMany(nn => nn.Value)
                .Where(nn => nn.Position == WishedPosition).ToList().OrderByDescending(nn => nn.PointsGained)
                .ThenBy(nn => nn.MinutesPlayed).ThenBy(nn => nn.MistakesMade).Take(MaxPlayers).ToList();
        }
        #endregion

        #region Print Data
        /// <summary>
        /// Prints input data to answer file
        /// </summary>
        /// <param name="file">answer file location</param>
        /// <param name="list">list to be printed</param>
        public void PrintInputDataToFile(string file, Dictionary<DateTime, List<Player>> list)
        {
            using (StreamWriter sw = new StreamWriter(Server.MapPath(file)))
            {
                foreach (var entry in list)
                {
                    if (entry.Value.Count != 0)
                    {
                        sw.WriteLine(entry.Key);
                        sw.WriteLine(entry.Value[0].Header());
                        sw.WriteLine(new string('-', entry.Value[0].Header().Length));
                        entry.Value.ForEach(aa => { sw.WriteLine(aa.ToString()); });
                        sw.WriteLine();
                    }
                    else
                    {
                        sw.WriteLine(entry.Key);
                        sw.WriteLine("List is empty");
                        sw.WriteLine();
                    }
                }
            }
        }
        /// <summary>
        /// Prints the answers to file
        /// </summary>
        /// <param name="file">file path</param>
        /// <param name="list">given list</param>
        /// <param name="position">user wished position</param>
        public void PrintAnswersToFile(string file, List<Player> list, string position)
        {
            using (StreamWriter sw = new StreamWriter(Server.MapPath(file), true))
            {
                if (list.Count != 0)
                {
                    sw.WriteLine("Chosen position by the user: {0}", position);
                    sw.WriteLine(list[0].Header());
                    sw.WriteLine(new string('-', list[0].Header().Length));
                    for (int i = 0; i < list.Count; i++)
                        sw.WriteLine(list[i].ToString());
                    sw.WriteLine();
                }
                else
                    sw.WriteLine("The list is empty");
            }
        }
        /// <summary>
        /// Prints input data to user interface 
        /// </summary>
        /// <param name="list">given list</param>
        public void PrintInputDataToTable(Dictionary<DateTime, List<Player>> list)
        {
            foreach (var entry in list)
            {
                TableRow row = new TableRow();
                TableCell cella = new TableCell();
                cella.Text = entry.Key.ToString();
                row.Cells.Add(cella);
                Table1.Rows.Add(row);
                row = new TableRow();
                TableCell[] cell = new TableCell[7];
                for (int i = 0; i < 7; i++)
                    cell[i] = new TableCell();
                cell[0].Text = "Team";
                cell[1].Text = "Last Name";
                cell[2].Text = "Name";
                cell[3].Text = "Position";
                cell[4].Text = "Points Scored";
                cell[5].Text = "Minutes Played";
                cell[6].Text = "Mistakes Made";
                row.Cells.AddRange(cell);
                Table1.Rows.Add(row);
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    row = new TableRow();
                    for (int j = 0; j < 7; j++)
                        cell[j] = new TableCell();
                    cell[0].Text = entry.Value[i].Team;
                    cell[1].Text = entry.Value[i].LastName;
                    cell[2].Text = entry.Value[i].Name;
                    cell[3].Text = entry.Value[i].Position;
                    cell[4].Text = entry.Value[i].PointsGained.ToString();
                    cell[5].Text = entry.Value[i].MinutesPlayed.ToString();
                    cell[6].Text = entry.Value[i].MistakesMade.ToString();
                    row.Cells.AddRange(cell);
                    Table1.Rows.Add(row);
                }
            }
        }
        /// <summary>
        /// Prints answers to user interface
        /// </summary>
        /// <param name="list">given list </param>
        public void PrintAnswersToTable(List<Player> list)
        {
            TableRow row = new TableRow();
            TableCell[] cell = new TableCell[7];
            for (int i = 0; i < 7; i++)
                cell[i] = new TableCell();
            cell[0].Text = "Team";
            cell[1].Text = "Last Name";
            cell[2].Text = "Name";
            cell[3].Text = "Position";
            cell[4].Text = "Points Scored";
            cell[5].Text = "Minutes Played";
            cell[6].Text = "Mistakes Made";
            row.Cells.AddRange(cell);
            Table2.Rows.Add(row);
            for (int i = 0; i < list.Count; i++)
            {
                row = new TableRow();
                for (int j = 0; j < 7; j++)
                    cell[j] = new TableCell();
                cell[0].Text = list[i].Team;
                cell[1].Text = list[i].LastName;
                cell[2].Text = list[i].Name;
                cell[3].Text = list[i].Position;
                cell[4].Text = list[i].PointsGained.ToString();
                cell[5].Text = list[i].MinutesPlayed.ToString();
                cell[6].Text = list[i].MistakesMade.ToString();
                row.Cells.AddRange(cell);
                Table2.Rows.Add(row);
            }
        }
        #endregion

        #region Exception Control
        /// <summary>
        /// Looks through file array, throws an exception if none are found
        /// </summary>
        /// <param name="filePaths">string array of files</param>
        /// <param name="PlayerInfo">player info file path</param>
        public void FileExceptionControl(string[] filePaths, string PlayerInfo)
        {
            try
            {
                if (filePaths.Length == 0) throw new Exception("Cannot find any Match*.txt files in given location");
                else if (!File.Exists(PlayerInfo)) throw new Exception("Cannot find PlayerInfo.txt file in given location");
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// Looks for an error in the match files.
        /// </summary>
        /// <param name="val">player information</param>
        /// <param name="counter">line counter</param>
        /// <param name="file">file location</param>
        public bool MatchFileControl(string[] val, int counter, string file)
        {
            try
            {
                if (val.Length != 6) throw new Exception(String.Format("There is a mistake in line {0} in the file {1}.", counter, file));
                for (int i = 3; i < 6; i++)
                    if (int.TryParse(val[i], out int rez) == false)
                        throw new Exception(string.Format("There is mistake in the line {0} in the file {1}. There should be a number instead of a char.", counter, file));
            }
            catch (Exception)
            {
                Label5.Text += String.Format("There is a mistake in line {0} in the file {1}.{2}", counter, file, Environment.NewLine);
                return true;
            }
            return false;
        }
        /// <summary>
        /// looks for mistakes in playerinfo file
        /// </summary>
        /// <param name="val">player information</param>
        /// <param name="counter">line counter</param>
        /// <param name="file">file path</param>
        public bool PlayerInfoControl(string[] val, int counter, string file)
        {
            try
            {
                if (val.Length != 4) throw new Exception(String.Format("There is a mistake in line {0} in the file {1}.", counter, file));
            }
            catch (Exception)
            {
                if (!Label5.Text.Contains(String.Format("There is a mistake in line {0} in the file {1}.", counter, file)))
                    Label5.Text += String.Format("There is a mistake in line {0} in the file {1}.{2}", counter, file, Environment.NewLine);
                return true;
            }
            return false;
        }
        /// <summary>
        /// User interface exception control
        /// </summary>
        /// <param name="S">user selected starting date</param>
        /// <param name="E">user selected ending date</param>
        /// <param name="Amount">user selected amount of players</param>
        /// <param name="WPos">user selected wanted position</param>
        public void UserInterfaceExceptions(string S, string E, string Amount, string WPos)
        {
            try
            {
                if (DateTime.TryParse(S, out DateTime rez) == false)
                    throw new Exception(string.Format("Starting date is in the incorrect format."));
                if (DateTime.TryParse(E, out DateTime rezz) == false)
                    throw new Exception(string.Format("Ending date is in the incorrect format."));
                if (DateTime.Parse(E) < DateTime.Parse(S))
                    throw new Exception(string.Format("The starting date has to be before the ending date."));
                if (WPos != "Striker" && WPos != "Defender" && WPos != "Center")
                    throw new Exception(string.Format("The chosen position does not exist."));
                if (int.TryParse(Amount, out int rezzz) == false)
                    throw new Exception(string.Format("The chosen amount is not a number."));
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// checkbox for input data
        /// </summary>
        public void InputDataShow()
        {
            if (CheckBox1.Checked)
                Table1.Visible = true;
            if (!CheckBox1.Checked)
                Table1.Visible = false;
        }
        /// <summary>
        /// empty file exception control
        /// </summary>
        /// <param name="file">file path</param>
        public void EmptyFileException(string file)
        {
            try
            {
                string[] a = File.ReadAllLines(file);
                if (a.Length == 0)
                    throw new Exception(string.Format("The File {0} is empty", file));
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

    }
}