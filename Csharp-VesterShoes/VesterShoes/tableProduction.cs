using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Table = CrystalDecisions.CrystalReports.Engine.Table;
using TextBox = System.Windows.Forms.TextBox;

namespace VesterShoes
{
    public partial class tableProduction : Form
    {
        private int numOfRows = 5;
        private int numOfColumns = 5;

        public tableProduction()
        {
            InitializeComponent();
        }

        private void tableProduction_Load(object sender, EventArgs e)
        {
            //GenerateTable(numOfColumns, numOfRows);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (int.TryParse(TextBox1.Text.Trim(), out numOfColumns) && int.TryParse(TextBox2.Text.Trim(), out numOfRows))
            //{
            //    //Generate the Table based from the inputs
            //    GenerateTable(numOfColumns, numOfRows);

            //    //Store the current Rows and Columns In ViewState as a reference value when it post backs
            //    ViewState["cols"] = numOfColumns;
            //    ViewState["rows"] = numOfRows;
            //}
            //else
            //{
            //    Response.Write("Values are not numeric!");
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////Check if ViewState values are null
            //if (ViewState["cols"] != null && ViewState["rows"] != null)
            //{
            //    //Find the Table in the page
            //    Table table = (Table)Page.FindControl("Table1");
            //    if (table != null)
            //    {
            //        //Re create the Table with the current rows and columns
            //        GenerateTable(int.Parse(ViewState["cols"].ToString()), int.Parse(ViewState["rows"].ToString()));

            //        // Now we can loop through the rows and columns of the Table and get the values from the TextBoxes
            //        for (int i = 0; i < int.Parse(ViewState["rows"].ToString()); i++)
            //        {
            //            for (int j = 0; j < int.Parse(ViewState["cols"].ToString()); j++)
            //            {
            //                //Print the values entered
            //                if (Request.Form["TextBoxRow_" + i + "Col_" + j] != string.Empty)
            //                {
            //                    Response.Write(Request.Form["TextBoxRow_" + i + "Col_" + j] + "<BR/>");
            //                }
            //            }
            //        }
            //    }
            //}
        }
        //private void GenerateTable(int colsCount, int rowsCount)
        //{

        //    //Creat the Table and Add it to the Page
        //    Table table = new Table();
        //    table.ID = "Table1";
        //    Page.Form.Controls.Add(table);

        //    // Now iterate through the table and add your controls
        //    for (int i = 0; i < rowsCount; i++)
        //    {
        //        TableRow row = new TableRow();
        //        for (int j = 0; j < colsCount; j++)
        //        {
        //            TableCell cell = new TableCell();
        //            TextBox tb = new TextBox();

        //            // Set a unique ID for each TextBox added
        //            tb.ID = "TextBoxRow_" + i + "Col_" + j;
        //            // Add the control to the TableCell
        //            cell.Controls.Add(tb);
        //            // Add the TableCell to the TableRow
        //            row.Cells.Add(cell);
        //        }

        //        // Add the TableRow to the Table
        //        table.Rows.Add(row);
        //    }
        //}
    }
}
