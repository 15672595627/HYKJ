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

namespace WindowsFormsApp1.Contract
{
    public partial class Con_date : Form
    {
        public Con_date()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string aa = HTBH.Text.Trim();
            string bb = GSMC.Text.Trim();
            string strsql = "select contractid as 合同编号,company as 公司名称,project as 项目名称 from [dbo].[Contract_h] where contractid like '%" + aa + "%' and company like '%" + bb + "%'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            string aa = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            NewContract newContract = (NewContract)this.Owner;
            newContract.Controls["HTBH"].Text = aa;
            this.Close();
        }
    }
}
