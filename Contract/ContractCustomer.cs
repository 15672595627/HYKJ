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
using WindowsFormsApp1.Order;
using WindowsFormsApp1.Contract;
using System.Configuration;

namespace WindowsFormsApp1.Contract
{
    public partial class ContractCustomer : Form
    {
        public ContractCustomer()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click_1(object sender, EventArgs e)
        {
            string aa = GSMC.Text.Trim();
            string bb = XMMC.Text.Trim();
            string cc = YWY.Text.Trim();
            string strsql = "select company as 公司名,project as 项目名称,type as 客户类型,seller as 业务员 from [dbo].[Customer] where company like '%" + aa + "%' and project like '%" + bb + "%' and seller like '%" + cc + "%'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string b = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string c = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string d = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            NewContract newContract = (NewContract)this.Owner;
            newContract.Controls["GSM"].Text = a;
            newContract.Controls["XMMC"].Text = b;
            newContract.Controls["KHLX"].Text = c;
            newContract.Controls["YWY"].Text = d;
            this.Close();
        }


    }
}