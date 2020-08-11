using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DuomWeb
{
    public partial class Forma1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TableRow row = new TableRow();

            TableCell pavadinimas = new TableCell();
            pavadinimas.Text = "<b>Pavadinimas</b>";
            row.Cells.Add(pavadinimas);

            TableCell kaina = new TableCell();
            kaina.Text = "<b>Kaina, Eur<b>";
            row.Cells.Add(kaina);

            Table1.Rows.Add(row);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] visosEilutes = File.ReadAllLines(Server.MapPath("App_Data/Prekes.txt"));

            foreach (string eilute in visosEilutes)
            {
                string[] dalys = eilute.Split(' ');

                TableRow row = new TableRow();

                TableCell pavadinimas = new TableCell();
                pavadinimas.Text = dalys[0];

                TableCell kaina = new TableCell();

                kaina.Text = dalys[1];

                row.Cells.Add(pavadinimas);
                row.Cells.Add(kaina);

                Table1.Rows.Add(row);
            }
        }
    }
}