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

        protected void Page_Load(object sender, EventArgs e)
        {
            SubList Subscribers = new SubList();
            PubList Publications = new PubList();

            Publications = PublicationInfo(Publications);
            Subscribers = SubscriberInfo(Subscribers);
            PrintSPublicationToPubTable(Publications);
            PrintSubsToSubTable(Subscribers);

            Checking(Publications, Subscribers);

            
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

            SubList Subscribers = new SubList();
            PubList Publications = new PubList();

            Publications = PublicationInfo(Publications);
            Subscribers = SubscriberInfo(Subscribers);

            MostIncomeByMonth(Publications, Subscribers);

            PublicationIncome(Subscribers, Publications);
            double AllPubIncome = AllIncome(Publications);
            PrintData(answerFile, AllPubIncome);

            PubList LowIncomePubs = LowIncomePublications(Publications);
            LowIncomePubs.Sorting();
            PrintDataToFile(answerFile, "Below average income publications:", LowIncomePubs);

            PrintInputData(Subscribers, Publications, answerFile);
        }

        #region ReadData
        /// <summary>
        /// Reads subscriber information from file
        /// and adds to the end of the list
        /// </summary>
        /// <param name="list">the list starting list</param>
        /// <returns>a list of subscribers with their information</returns>
        private SubList SubscriberInfo(SubList list)
        {
            using (StreamReader sr = new StreamReader(Server.MapPath("App_Data/U3b.txt")))
            {
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
            }
            return list;
        }
        /// <summary>
        /// Reads publication informations from file
        /// and adds to the end of the given list
        /// </summary>
        /// <param name="list">a list that needs to be filled</param>
        /// <returns>updated list</returns>
        private PubList PublicationInfo(PubList list)
        {
            using (StreamReader sr = new StreamReader(Server.MapPath("App_Data/U3a.txt")))
            {
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
            }
            return list;
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
        private void MostIncomeByMonth(PubList P, SubList S)
        {
            for (int month = 1; month <= 12; month++)
            {
                PubList monthly = new PubList();
                P.SetIncomeToZero();
                for (P.First(); !P.End(); P.Next()) //eina per leidinius
                {

                    for (S.First(); !S.End(); S.Next()) //eina per prenumeratorius
                        if (P.PublicationData().Code == S.SubscriberData().SubscribtionCode)
                            if ((month >= S.SubscriberData().SubscribtionStart) && (month <= S.SubscriberData().SubscribtionStart + S.SubscriberData().SubscribtionDuration - 1))
                                P.PublicationData().Income += S.SubscriberData().SubscribtionAmount * P.PublicationData().Price;
                    monthly.AddToEnd(P.PublicationData());
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
        private Publication HighestIncome(PubList list)
        {
            double max = 0;
            Publication maxPub = null;
            for (list.First(); !list.End(); list.Next())
                if (list.PublicationData().Income > max)
                {
                    max = list.PublicationData().Income;
                    maxPub = list.PublicationData();
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
        private void PublicationIncome(SubList Subs, PubList Publications)
        {
            Publications.SetIncomeToZero();
            for (Publications.First(); !Publications.End(); Publications.Next())
                for (Subs.First(); !Subs.End(); Subs.Next())
                    if (Subs.SubscriberData().SubscribtionCode == Publications.PublicationData().Code)
                        Publications.PublicationData().Income += Publications.PublicationData().Price * Subs.SubscriberData().SubscribtionAmount * Subs.SubscriberData().SubscribtionDuration;
        }
        /// <summary>
        /// sums up all of the publication's income
        /// </summary>
        /// <param name="Publications">list of publications</param>
        /// <returns>the sum of all publication's income</returns>
        private double AllIncome(PubList Publications)
        {
            double sum = 0;
            for (Publications.First(); !Publications.End(); Publications.Next())
                sum += Publications.PublicationData().Income;
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
        private PubList LowIncomePublications(PubList All)
        {
            double average = Average(All);
            PubList LowIncomePubs = new PubList();
            for (All.First(); !All.End(); All.Next())
                if (All.PublicationData().Income < average)
                    LowIncomePubs.AddToEnd(All.PublicationData());
            return LowIncomePubs;
        }

        /// <summary>
        /// finds the average income of all publications
        /// </summary>
        /// <param name="All">list of publications</param>
        /// <returns>the average income</returns>
        private double Average(PubList All)
        {
            double sum = 0;
            int k = 0;
            for (All.First(); !All.End(); All.Next())
            {
                sum += All.PublicationData().Income;
                k++;
            }
            return sum / k;
        }
        #endregion

        #region Selected Publication and month
        /// <summary>
        /// the button used to find the subscribers of a selected
        /// publication the selected month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            PubList Pubs = new PubList();
            Pubs = PublicationInfo(Pubs);

            SubList Subs = new SubList();
            Subs = SubscriberInfo(Subs);

            string SelectedCode = TextBox1.Text;
            int SelectedMonth = int.Parse(TextBox2.Text);

            Publication foundPubl = FindPublicationWithCode(Pubs, SelectedCode);
            SubList PubSubs = FindSubscribers(Subs, SelectedCode, SelectedMonth);
            PrintSubscribersToTable(PubSubs, foundPubl);
        }
        /// <summary>
        /// using the selected code, finds the publication
        /// </summary>
        /// <param name="list">list of publications</param>
        /// <param name="code">the selected code</param>
        /// <returns>the publication that was found using the code</returns>
        private Publication FindPublicationWithCode(PubList list, string code)
        {
            for (list.First(); !list.End(); list.Next())
                if (code == list.PublicationData().Code)
                    return list.PublicationData();
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
        private SubList FindSubscribers(SubList Subs, string Code, int month)
        {
            SubList PubSubs = new SubList();
            for (Subs.First(); !Subs.End(); Subs.Next())
                if (Subs.SubscriberData().SubscribtionCode == Code)
                    if (month >= Subs.SubscriberData().SubscribtionStart && month <= Subs.SubscriberData().SubscribtionStart + Subs.SubscriberData().SubscribtionDuration - 1)
                        PubSubs.AddToEnd(Subs.SubscriberData());
            return PubSubs;
        }
        /// <summary>
        /// prints the found subscribers to a table
        /// </summary>
        /// <param name="list">list of subscribers</param>
        /// <param name="pubName">the name of the publication</param>
        private void PrintSubscribersToTable(SubList list, Publication pub)
        {
            if (!list.Empty() && pub != null)
                for (list.First(); !list.End(); list.Next())
                {
                    Label3.Visible = true;
                    Label3.Text = pub.Name + " Subscriber's last names:";
                    TableCell cell = new TableCell();
                    string tempstring = String.Format("{0}", list.SubscriberData().LastName);
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
        /// prints subscribers to a file
        /// </summary>
        /// <param name="file">file name</param>
        /// <param name="list">list of subscribers</param>
        private void PrintDataToFile(string file, SubList list)
        {
            using (StreamWriter sw = new StreamWriter(Server.MapPath(@file), true))
            {
                if(list.Empty())
                {
                    sw.WriteLine("No subscribers found");
                    sw.WriteLine();
                }
                else
                {
                    list.First();
                    string line = new string('-', list.SubscriberData().ToString().Length);
                    sw.WriteLine(list.SubscriberData().Header());
                    sw.WriteLine(line);
                    while (!list.End())
                    {
                        sw.WriteLine(list.SubscriberData().ToString());
                        sw.WriteLine(line);
                        list.Next();
                    }
                    sw.WriteLine();
                }
            }
        }
        /// <summary>
        /// prints the given list to file
        /// </summary>
        /// <param name="file">file path</param>
        /// <param name="header">header of the table</param>
        /// <param name="list">list of publiactions</param>
        private void PrintDataToFile(string file, string header, PubList list)
        {
            using (StreamWriter sw = new StreamWriter(Server.MapPath(@file), true))
            {
                if (list.Empty())
                {
                    sw.WriteLine("No publications found");
                    sw.WriteLine();
                }
                else
                {
                    list.First();
                    string line = new string('-', list.PublicationData().ToString().Length);

                    sw.WriteLine(header);
                    sw.WriteLine(line);
                    for (list.First(); !list.End(); list.Next())
                    {
                        sw.WriteLine(list.PublicationData().ToString());
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
        private void PrintSubsToSubTable(SubList subs)
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
                    cell[0].Text = subs.SubscriberData().LastName;
                    cell[1].Text = subs.SubscriberData().Adress;
                    cell[2].Text = subs.SubscriberData().SubscribtionStart.ToString();
                    cell[3].Text = subs.SubscriberData().SubscribtionDuration.ToString();
                    cell[4].Text = subs.SubscriberData().SubscribtionCode;
                    cell[5].Text = subs.SubscriberData().SubscribtionAmount.ToString();
                    row.Cells.AddRange(cell);
                    TableSubs.Rows.Add(row);
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
        private void PrintSPublicationToPubTable(PubList pubs)
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
                    cell[0].Text = pubs.PublicationData().Code;
                    cell[1].Text = pubs.PublicationData().Name;
                    cell[2].Text = pubs.PublicationData().Price.ToString();
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
        private void PrintInputData(SubList subs, PubList pubs, string answerFile)
        {
            PrintDataToFile(answerFile, subs);
            pubs.First();
            PrintDataToFile(answerFile, pubs.PublicationData().Header(), pubs);
        }
        #endregion

        #region Show Input Data
        /// <summary>
        /// 3rd button. Used to make the input tables visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            TableSubs.Visible = TablePubs.Visible = true;
            SubTLabel.Visible = PubTLabel.Visible = true;
            if (Button1.Enabled == false)
            {
                File.Delete(Server.MapPath("Answer.txt"));

                SubList Subscribers = new SubList();
                PubList Publications = new PubList();

                Publications = PublicationInfo(Publications);
                Subscribers = SubscriberInfo(Subscribers);

                PrintDataToFile("Answer.txt", Subscribers);
                PrintDataToFile("Answer.txt", "No publications found" ,Publications);
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
        private void Checking(PubList Publications, SubList Subscribers)
        {
            if (Publications.Empty() || Subscribers.Empty())
            {
                Button1.Enabled = Button2.Enabled = false;
                Label4.Text = "No Publications or Subscribers found!";
            }
        }
        #endregion
    }
}