using System;
using System.Web.UI.WebControls;

namespace ValidWeb
{
    public partial class Forma1 : System.Web.UI.Page
    {
        private string issaugotasTekstas;
        private Table issaugotaInfo;
        private int count;

        protected void Page_Load(object sender, EventArgs e)
        {

            if(DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Add("-");
                for (int i = 14; i <= 25; i++)
                {
                    DropDownList1.Items.Add(i.ToString());
                }
            }
            issaugotaInfo = (Table)Session["lentele"];
            if(issaugotaInfo != null)
            IterptiIrasa(issaugotaInfo);
        }

        protected void Button1_Click(object sender, EventArgs e) //"Registruotis"
        {
            count = Table1.Rows.Count + 1;
            issaugotasTekstas = count + ". " + TextBox1.Text + " " + TextBox2.Text + " " + TextBox3.Text + " " + DropDownList1.SelectedValue;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                if(CheckBoxList1.Items[i].Selected)
                issaugotasTekstas += " " + CheckBoxList1.Items[i].Text;

            IterptiIrasa(issaugotasTekstas);

            // issaugome reiksme sesijos kintamajame
            Session["lentele"] = Table1;
        }

        private void IterptiIrasa(string tekstas)
        {
            TableCell cell = new TableCell();
            cell.Text = tekstas;

            TableRow row = new TableRow();
            row.Cells.Add(cell);

            Table1.Rows.Add(row);
        }

        private void IterptiIrasa(Table lentele)
        {
            for (int i = 0; i < lentele.Rows.Count; i++)
            {
                TableCell cell = new TableCell();
                cell.Text = lentele.Rows[i].Cells[0].Text;

                TableRow row = new TableRow();
                row.Cells.Add(cell);

                Table1.Rows.Add(row);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Table1.Rows.Clear();
            Session["lentele"] = null;
        }
    }
}