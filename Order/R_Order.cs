using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1.Order
{
    public partial class R_Order : Form
    {
        public R_Order()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string strsql = "select contractid as 合同编号,company as 公司名,project as 项目名称 from [dbo].[Contract_h] where contractid like '%" + HTBH.Text.Trim() + "%' and company like '%" + GSM.Text.Trim() + "%'";
            SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string aa = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Receipt receipt = (Receipt)this.Owner;
            receipt.Controls["HTBH"].Text = aa;
            this.Close();
        }
    }
}
