using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Product
{
    public partial class CBTZ_ST : Form
    {
        public CBTZ_ST()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void SX_Click(object sender, EventArgs e)
        {
            string strsql = "select product as 产品名称,contractid as 合同编号 from Stock where product like '%" + CPMC.Text.Trim() + "%'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string aa = dataGridView1.CurrentRow.Cells["产品名称"].Value.ToString();
            string bb = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
            ProductCBTZ cBTZ = (ProductCBTZ)this.Owner;
            cBTZ.Controls["CPMC"].Text = aa;
            cBTZ.Controls["HTBH"].Text = bb;
            this.Close();
        }
    }
}
