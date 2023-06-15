using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Order
{
    public partial class Findkh : Form
    {
        public Findkh()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string strsql = "select company as 公司名,project as 项目名称,seller as 业务员 from [dbo].[Customer] where company like '%" + KHM.Text.Trim() + "%'";
            SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string b = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string c = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Receipt receipt = (Receipt)this.Owner;
            receipt.Controls["GSM"].Text = a;
            receipt.Controls["XMMC"].Text = b;
            receipt.Controls["YWY"].Text = c;
            this.Close();
        }
    }
}
