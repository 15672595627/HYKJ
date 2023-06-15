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
    public partial class FindProduct : Form
    {
        public FindProduct()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string OrderProduct { get; set; }
        public string FPD_HTBH { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            string strsql = "select contractid as 合同编号,company as 公司名称,product as 产品名称,amount as 金额 from [dbo].[Contract_b] where  contractid like '%" + FPD_HTBH + "%'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string aa = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            OrderService.CPMC = aa;
            this.Close();
            
        }
    }
}
