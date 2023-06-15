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

namespace WindowsFormsApp1.Date
{
    public partial class Dis_Contract : Form
    {
        public Dis_Contract()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string aa = RQ1.Text.Trim();
            string bb = RQ2.Text.Trim();
            string cc = GSMC.Text.Trim();
            string strsql = "select contractid as 合同编号,date as 日期,company as 公司名称,contact as 联系人,subsidiary as 区域 from [dbo].[Contract_h] where company like '%" + cc + "%' and date between '" + aa + "' and '" + bb + "' ";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string aa = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Dis_Date dis_Date = (Dis_Date)this.Owner;
            dis_Date.Controls["groupBox2"].Controls["HTBH"].Text = aa;
            this.Close();
        }
    }
}
