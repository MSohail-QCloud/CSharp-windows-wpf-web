using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VesterShoes.classes;

namespace VesterShoes
{
    public partial class CompleteItmes : Form
    {
         public int GlobalVar { get; set; }
        public CompleteItmes()
        {
            InitializeComponent();
        }
         VestureClass  vc = new VestureClass();
        private void CompleteItmes_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = vc.Select("select JobID,orderID,SortID,tp.ItemsID,ItemsQty,ItemsRate,ItemsTotal,tf.PCompanyName,ti.ItemsDescription from tblOrders tp join tblProfile tf on tp.ProfileId=tf.ProfileId join tblItems ti on tp.ItemsID=ti.ItemsID where jobStates='5'");
                GridCompleteItems.AutoGenerateColumns = false;
                GridCompleteItems.DataSource = ds.Tables[0].DefaultView;
                GridCompleteItems.ClearSelection();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void GridCompleteItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                GlobalVar =int.Parse(GridCompleteItems.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.DialogResult = DialogResult.OK;
                Hide();
            }
        }

        private void GridCompleteItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
