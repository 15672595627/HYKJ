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
    public partial class FindContract : Form
    {
        public FindContract()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void button1_Click_1(object sender, EventArgs e)
        {
            string aa = RQ1.Text.Trim();
            string bb = RQ2.Text.Trim();
            string cc = HTBH.Text.Trim();
            string dd = KH.Text.Trim();
            string sql = String.Format("select contractid as 合同编号,company as 客户,seller as 业务员,sub as 区域,date as 日期,project as 项目名称,amount as 金额 from [dbo].[Contract_h] where contractid like '%" + cc + "%' and company like '%" + dd + "%' and date between '" + aa + "' and '" + bb + "'");
            SqlDataAdapter adapter = new SqlDataAdapter(sql, SQL);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            string b = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            string c = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            string d = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
            string f= dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            string g = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
            string h = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
            string i = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
            OrderService orderservice = (OrderService)this.Owner;
            orderservice.Controls["groupBox1"].Controls["HTBH"].Text = b;
            orderservice.Controls["groupBox1"].Controls["YWY"].Text = c;
            orderservice.Controls["groupBox1"].Controls["QY"].Text = d;
            orderservice.Controls["groupBox1"].Controls["GSM"].Text = f;
            orderservice.Controls["groupBox1"].Controls["textBox1"].Text = g;
            orderservice.Controls["groupBox1"].Controls["XMMC"].Text = h;
            orderservice.Controls["groupBox3"].Controls["HTJE"].Text = i;
            this.Close();
        }

        private void FindContract_Load(object sender, EventArgs e)
        {
            RQ1.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(-3);
            RQ2.Value = DateTime.Now;
        }
    }
}