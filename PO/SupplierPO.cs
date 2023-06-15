using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1.PO
{
    public partial class SupplierPO : Form
    {
        public SupplierPO()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void button1_Click(object sender, EventArgs e)
        {
            string strsql = "select company as 供应商,type as 类别 from [dbo].[Supplier] where company like '%" + GYS.Text.Trim() + "%'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string aa = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            NewPO newPO = (NewPO)this.Owner;
            newPO.Controls["GYS"].Text = aa;
            this.Close();
        }
    }
}
