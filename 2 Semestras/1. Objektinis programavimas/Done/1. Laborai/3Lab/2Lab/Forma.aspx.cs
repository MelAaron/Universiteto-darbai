using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace _2Lab
{
    public partial class Forma : System.Web.UI.Page
    {
        KnotList<Subscriber> Subscribers;
        KnotList<Publication> Publications;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Compiles the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            const string answerFile = "Answer.txt";
            File.Delete(Server.MapPath(answerFile));
            
            Subscribers = Session["l2"] as KnotList<Subscriber>;
            Publications = Session["l1"] as KnotList<Publication>;
            if (Subscribers == null || Publications == null)
            {
                Label4.Visible = true;
                return;
            }
              
            PrintInputData(Subscribers, Publications, answerFile);
            if (!Publications.Empty() && !Subscribers.Empty())
            {
                MostIncomeByMonth(Publications, Subscribers);

                PublicationIncome(Subscribers, Publications);
                double AllPubIncome = AllIncome(Publications);
                PrintData(answerFile, AllPubIncome);

                KnotList<Publication> LowIncomePubs = LowIncomePublications(Publications);
                LowIncomePubs.Sorting();
                LowIncomePubs.First();
                Print(answerFile, "Below average income publications", LowIncomePubs.GetData().Header(), LowIncomePubs);

                FindSelectedPubSubs(Publications, Subscribers);
                
                Label4.Visible = false;
            }
            else if (Publications.Empty() || Subscribers.Empty())
                Label4.Visible = true;
            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile != false && FileUpload2.HasFile != false)
            {
                PublicationInfo(Publications, FileUpload2.FileContent);
                SubscriberInfo(Subscribers, FileUpload1.FileContent);
                Label4.Visible = false;
            }
        }

        #region ReadData
        /// <summary>
        /// Reads subscriber information from file
        /// and adds to the end of the list
        /// </summary>
        /// <param name="list">the list starting list</param>
        /// <returns>a list of subscribers with their information</returns>
        private void SubscriberInfo(KnotList<Subscriber> list, Stream File)
        {
            using (StreamReader sr = new StreamReader(File))
            {
                list = new KnotList<Subscriber>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string lastName = values[0];
                    string city = values[1];
                    int beginning = int.Parse(values[2]);
                    int duration = int.Parse(values[3]);
                    string code = values[4];
                    int amount = int.Parse(values[5]);
                    Subscriber sub = new Subscriber(lastName, city, beginning, duration, code, amount);
                    list.AddToEnd(sub);
                }
                Session.Add("l2", list);
            }
        }
        /// <summary>
        /// Reads publication informations from file
        /// and adds to the end of the given list
        /// </summary>
        /// <param name="list">a list that needs to be filled</param>
        /// <returns>updated list</returns>
        private void PublicationInfo(KnotList<Publication> list, Stream File)
        {
            using (StreamReader sr = new StreamReader(File))
            {
                list = new KnotList<Publication>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string code = values[0];
                    string name = values[1];
                    double price = double.Parse(values[2]);
                    Publication publication = new Publication(code, name, price);
                    list.AddToEnd(publication);
                }
                
                Session.Add("l1", list);
            }
        }

        #endregion

        #region Income by month
        /// <summary>
        /// Goes month by month, publication by publication
        /// and searches for it's subscribers and calculates 
        /// the month's income. makes a list of all publications
        /// and their incomes each month
        /// </summary>
        /// <param name="P">list of publications</param>
        /// <param name="S">list of subscribers</param>
        private void MostIncomeByMonth(KnotList<Publication> P, KnotList<Subscriber> S)
        {
            for (int month = 1; month <= 12; month++)
            {
                KnotList<Publication> monthly = new KnotList<Publication>();
                SetIncomeToZero(P);
                for (P.First(); !P.End(); P.Next()) //eina per leidinius
                {

                    for (S.First(); !S.End(); S.Next()) //eina per prenumeratorius
                        if (P.GetData().Code == S.GetData().SubscribtionCode)
                            if ((month >= S.GetData().SubscribtionStart) && (month <= S.GetData().SubscribtionStart + S.GetData().SubscribtionDuration - 1))
                                P.GetData().Income += S.GetData().SubscribtionAmount * P.GetData().Price;
                    monthly.AddToEnd(P.GetData());
                }
                Publication maxPub = HighestIncome(monthly);
                PrintBestMonthly(maxPub, month);
            }
        }
        /// <summary>
        /// Compares the publications
        /// finds the publication with the most income
        /// that month
        /// </summary>
        /// <param name="list">list of publications</param>
        /// <returns>the publication with the highest income</returns>
        private Publication HighestIncome(KnotList<Publication> list)
        {
            double max = 0;
            Publication maxPub = null;
            for (list.First(); !list.End(); list.Next())
                if (list.GetData().Income > max)
                {
                    max = list.GetData().Income;
                    maxPub = list.GetData();
                }
            return maxPub;
        }
        /// <summary>
        /// Adds the publication with the highest income each month
        /// to file
        /// </summary>
        /// <param name="pub"></param>
        /// <param name="month"></param>
        private void PrintBestMonthly(Publication pub, int month)
        {
            using (StreamWriter sw = new StreamWriter(Server.MapPath("Answer.txt"), true))
            {
                if (month == 1)
                    sw.WriteLine("Highest income every month:");
                if (pub == null)
                    sw.WriteLine("{0, -2}. |{1, 20}|", month, "Nera");
                else
                    sw.WriteLine("{0, -2}. |{1, 20}|", month, pub.Name);
            }
        }



        #endregion

        #region All Publication Income
        /// <summary>
        /// goes through all publications, finds their subscribers
        ///  and calculates the publication's info
        /// </summary>
        /// <param name="Subs">list of subscribers</param>
        /// <param name="Publications">list of publications</param>
        private void PublicationIncome(KnotList<Subscriber> Subs, KnotList<Publication> Publications)
        {
            SetIncomeToZero(Publications);
            for (Publications.First(); !Publications.End(); Publications.Next())
                for (Subs.First(); !Subs.End(); Subs.Next())
                    if (Subs.GetData().SubscribtionCode == Publications.GetData().Code)
                        Publications.GetData().Income += Publications.GetData().Price * Subs.GetData().SubscribtionAmount * Subs.GetData().SubscribtionDuration;
        }
        /// <summary>
        /// sums up all of the publication's income
        /// </summary>
        /// <param name="Publications">list of publications</param>
        /// <returns>the sum of all publication's income</returns>
        private double AllIncome(KnotList<Publication> Publications)
        {
            double sum = 0;
            for (Publications.First(); !Publications.End(); Publications.Next())
                sum += Publications.GetData().Income;
            return sum;
        }
        #endregion

        #region Low Income Publications
        /// <summary>
        /// goes through all publications and adds
        /// the publications with below average income to a new list
        /// </summary>
        /// <param name="All">list of publications</param>
        /// <returns>a list of publications with below average income</returns>
        private KnotList<Publication> LowIncomePublications(KnotList<Publication> All)
        {
            double average = Average(All);
            KnotList<Publication> LowIncomePubs = new KnotList<Publication>();
            for (All.First(); !All.End(); All.Next())
                if (All.GetData().Income < average)
                    LowIncomePubs.AddToEnd(All.GetData());
            return LowIncomePubs;
        }

        /// <summary>
        /// finds the average income of all publications
        /// </summary>
        /// <param name="All">list of publications</param>
        /// <returns>the average income</returns>
        private double Average(KnotList<Publication> All)
        {
            double sum = 0;
            int k = 0;
            for (All.First(); !All.End(); All.Next())
            {
                sum += All.GetData().Income;
                k++;
            }
            return sum / k;
        }
        private void SetIncomeToZero(KnotList<Publication> list)
        {
            for (list.First(); !list.End(); list.Next())
                list.GetData().Income = 0;
        }
        #endregion

        #region Selected Publication and month
        /// <summary>
        /// Finds the selected code's publications subscribers
        /// </summary>
        /// <param name="Pubs">list of publications</param>
        /// <param name="Subs">list of subscribers</param>
        private void FindSelectedPubSubs(KnotList<Publication> Pubs, KnotList<Subscriber> Subs)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                KnotList<Subscriber> a = new KnotList<Subscriber>();
                PrintSubscribersToTable(a, null);
            }
            else if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                string SelectedCode = TextBox1.Text;
                int SelectedMonth = int.Parse(TextBox2.Text);
                Publication foundPubl = FindPublicationWithCode(Pubs, SelectedCode);
                KnotList<Subscriber> PubSubs = FindSubscribers(Subs, SelectedCode, SelectedMonth);
                PrintSubscribersToTable(PubSubs, foundPubl);
            }
        }
        /// <summary>
        /// using the selected code, finds the publication
        /// </summary>
        /// <param name="list">list of publications</param>
        /// <param name="code">the selected code</param>
        /// <returns>the publication that was found using the code</returns>
        private Publication FindPublicationWithCode(KnotList<Publication> list, string code)
        {
            for (list.First(); !list.End(); list.Next())
                if (code == list.GetData().Code)
                    return list.GetData();
            return null;
        }
        /// <summary>
        /// finds the subscribers for the selected publication the selected month
        /// </summary>
        /// <param name="Subs">list o subscribers</param>
        /// <param name="Code">the selected code</param>
        /// <param name="month">the selected month</param>
        /// <returns>a list of subscribers of the selected publication
        /// the selected month</returns>
        private KnotList<Subscriber> FindSubscribers(KnotList<Subscriber> Subs, string Code, int month)
        {
            KnotList<Subscriber> PubSubs = new KnotList<Subscriber>();
            for (Subs.First(); !Subs.End(); Subs.Next())
                if (Subs.GetData().SubscribtionCode == Code)
                    if (month >= Subs.GetData().SubscribtionStart && month <= Subs.GetData().SubscribtionStart + Subs.GetData().SubscribtionDuration - 1)
                        PubSubs.AddToEnd(Subs.GetData());
            return PubSubs;
        }
        /// <summary>
        /// prints the found subscribers to a table
        /// </summary>
        /// <param name="list">list of subscribers</param>
        /// <param name="pubName">the name of the publication</param>
        private void PrintSubscribersToTable(KnotList<Subscriber> list, Publication pub)
        {
            if (!list.Empty() && pub != null)
                for (list.First(); !list.End(); list.Next())
                {
                    Label3.Visible = true;
                    Label3.Text = pub.Name + " Subscriber's last names:";
                    TableCell cell = new TableCell();
                    string tempstring = String.Format("{0}", list.GetData().LastName);
                    cell.Text = tempstring;

                    TableRow row = new TableRow();
                    row.Cells.Add(cell);

                    Table1.Rows.Add(row);
                }
            else
            {
                Label3.Visible = true;
                Label3.Text = "The publication does not have any subscribers the selected month.";
            }
        }

        #endregion

        #region PrintResults
        /// <summary>
        /// Prints the list to selected file
        /// </summary>
        /// <typeparam name="type">type of list</typeparam>
        /// <param name="file">path of wanted answer file</param>
        /// <param name="tableName">Header of the table</param>
        /// <param name="tableHeader">header of the table</param>
        /// <param name="list">list that is being printed</param>
        private void Print<type>(string file, string tableName, string tableHeader, IEnumerable<type> list)
        {
            using (StreamWriter sw = new StreamWriter(Server.MapPath(@file), true))
            {
                if (list == null)
                {
                    sw.WriteLine("No list found");
                    sw.WriteLine();
                }
                else
                {
                    string line = new string('-', tableHeader.Length);
                    sw.WriteLine(tableName);

                    sw.WriteLine(tableHeader);
                    sw.WriteLine(line);
                    foreach (type a in list)
                    {
                        sw.WriteLine(a.ToString());
                        sw.WriteLine(line);
                    }
                    sw.WriteLine();
                }
            }
        }

        /// <summary>
        /// prints all income to file
        /// </summary>
        /// <param name="file">file path</param>
        /// <param name="AllIncome">number</param>
        private void PrintData(string file, double AllIncome)
        {
            using (StreamWriter sw = new StreamWriter(Server.MapPath(@file), true))
            {
                sw.WriteLine();
                sw.WriteLine("All Publication income: {0:F2}", AllIncome);
                sw.WriteLine();
            }
        }
        /// <summary>
        /// prints subscriber data to table in web
        /// </summary>
        /// <param name="list">list of subscribers</param>
        private void PrintSubsToSubTable(KnotList<Subscriber> subs)
        {
            if (!subs.Empty())
            {
                SubTLabel.Text = "Input subscriber data:";
                TableRow row = new TableRow();
                TableCell[] cell = new TableCell[6];
                for (int i = 0; i < 6; i++)
                    cell[i] = new TableCell();
                cell[0].Text = "Last Name";
                cell[1].Text = "Adress";
                cell[2].Text = "Subscribtion start";
                cell[3].Text = "Subscribtion duration";
                cell[4].Text = "Subscribtion code";
                cell[5].Text = "Subscribtion amount";
                row.Cells.AddRange(cell);
                TableSubs.Rows.Add(row);
                for (subs.First(); !subs.End(); subs.Next())
                {
                    row = new TableRow();
                    for (int i = 0; i < 6; i++)
                        cell[i] = new TableCell();
                    cell[0].Text = subs.GetData().LastName;
                    cell[1].Text = subs.GetData().Adress;
                    cell[2].Text = subs.GetData().SubscribtionStart.ToString();
                    cell[3].Text = subs.GetData().SubscribtionDuration.ToString();
                    cell[4].Text = subs.GetData().SubscribtionCode;
                    cell[5].Text = subs.GetData().SubscribtionAmount.ToString();
                    row.Cells.AddRange(cell);
                    TableSubs.Rows.Add(row);
                }
            }
            else
            {
                SubTLabel.Text = "No Subscribers Found";
            }

        }
        private void PrintSubsToSubTable2(KnotList<Subscriber> subs)
        {
            if (!subs.Empty())
            {
                SubTLabel.Text = "Input subscriber data:";
                TableRow row = new TableRow();
                TableCell[] cell = new TableCell[6];
                for (int i = 0; i < 6; i++)
                    cell[i] = new TableCell();
                cell[0].Text = "Last Name";
                cell[1].Text = "Adress";
                cell[2].Text = "Subscribtion start";
                cell[3].Text = "Subscribtion duration";
                cell[4].Text = "Subscribtion code";
                cell[5].Text = "Subscribtion amount";
                row.Cells.AddRange(cell);
                Table2.Rows.Add(row);
                for (subs.Last(); !subs.End(); subs.Previous())
                {
                    row = new TableRow();
                    for (int i = 0; i < 6; i++)
                        cell[i] = new TableCell();
                    cell[0].Text = subs.GetData().LastName;
                    cell[1].Text = subs.GetData().Adress;
                    cell[2].Text = subs.GetData().SubscribtionStart.ToString();
                    cell[3].Text = subs.GetData().SubscribtionDuration.ToString();
                    cell[4].Text = subs.GetData().SubscribtionCode;
                    cell[5].Text = subs.GetData().SubscribtionAmount.ToString();
                    row.Cells.AddRange(cell);
                    Table2.Rows.Add(row);
                }
            }
            else
            {
                SubTLabel.Text = "No Subscribers Found";
            }

        }
        /// <summary>
        /// prints publication data to web
        /// </summary>
        /// <param name="list">list of publiactions</param>
        private void PrintSPublicationToPubTable(KnotList<Publication> pubs)
        {
            if (!pubs.Empty())
            {
                PubTLabel.Text = "Input publication data:";
                TableRow row = new TableRow();
                TableCell[] cell = new TableCell[3];
                for (int i = 0; i < 3; i++)
                    cell[i] = new TableCell();
                cell[0].Text = "Code";
                cell[1].Text = "Name";
                cell[2].Text = "Price";
                row.Cells.AddRange(cell);
                TablePubs.Rows.Add(row);
                for (pubs.First(); !pubs.End(); pubs.Next())
                {
                    row = new TableRow();
                    for (int i = 0; i < 3; i++)
                        cell[i] = new TableCell();
                    cell[0].Text = pubs.GetData().Code;
                    cell[1].Text = pubs.GetData().Name;
                    cell[2].Text = pubs.GetData().Price.ToString();
                    row.Cells.AddRange(cell);
                    TablePubs.Rows.Add(row);
                }
            }
            else
            {
                PubTLabel.Text = "No Publications Found.";
            }

        }
        /// <summary>
        /// calls the prmethods
        /// </summary>
        /// <param name="subs">subscriber list</param>
        /// <param name="pubs">publication list</param>
        /// <param name="answerFile">asnwer file path</param>
        private void PrintInputData(KnotList<Subscriber> subs, KnotList<Publication> pubs, string answerFile)
        {
            PrintSubsToSubTable(subs);
            PrintSubsToSubTable2(subs);
            PrintSPublicationToPubTable(pubs);
            subs.First();
            pubs.First();
            if(!subs.Empty())
            Print(answerFile, "", subs.GetData().Header(), subs);
            else
                Print(answerFile, "", "", subs);
            if (!pubs.Empty())
            Print(answerFile, "", pubs.GetData().Header(), pubs);
            else
                Print(answerFile, "", "", pubs);
            if (CheckBox1.Checked == true)
            {
                TableSubs.Visible = TablePubs.Visible = true;
                SubTLabel.Visible = PubTLabel.Visible = true;
            }
        }
        #endregion

        #region Checking
        /// <summary>
        /// checks if the starting lists are empty
        /// and if so, disables the buttons, alerts the user
        /// </summary>
        /// <param name="Publications">list of publications</param>
        /// <param name="Subscribers">list of subscribers</param>
        private bool Checking(KnotList<Publication> Publications, KnotList<Subscriber> Subscribers)
        {
            if (Publications.Empty() || Subscribers.Empty())
            {
                Label4.Text = "No Publications or Subscribers found!";
                return false;
            }
            if (FileUpload1.HasFile == false || FileUpload2.HasFile == false)
            {
                Label4.Text = "No Publications or Subscribers found!";
                return false;
            }
            return true;
        }
        #endregion

    }
}