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
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.OrderReport
{
    public partial class Amount : Form
    {
        public Amount()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void Amount_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            string htbh = HTBH.Text.Trim();
            string strsql = "select contractid as 合同编号,date as 日期,company as 公司名,project as 项目名称,amount as 合同金额 from Contract_h where contractid = '" + htbh + "'";
            string strsql1 = "select contractid as 合同编号,date as 日期,company as 公司名,project as 项目名称,amount as 合同金额 from Order_b where contractid like '%" + htbh + "%'";

            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);

            decimal ht1 = 1;
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                ht1 = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["合同金额"].Value);
            }
                

            SqlDataAdapter da1 = new SqlDataAdapter(strsql1, SQL);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            dataGridView2.DataSource = dt1;

            decimal sum = 0;

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                sum += Convert.ToDecimal(dataGridView2.Rows[i].Cells["合同金额"].Value);
            }
            string ssum = sum.ToString();

            string[] row = { "合计", "", "", "", ssum };
            ((DataTable)dataGridView2.DataSource).Rows.Add(row);

            decimal ht2 = Convert.ToDecimal(dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["合同金额"].Value);

            WCL.Text = ((ht2 / ht1)*100).ToString("0.00");

        }

        private void Amount_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
