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

namespace WindowsFormsApp1.Bill
{
    public partial class OutsourcingPlan : Form
    {
        public OutsourcingPlan()
        {
            InitializeComponent();
        }


        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string aa = RQ.Text.Trim();
            string bb = RQ1.Text.Trim();
            string cc = XMMC.Text.Trim();
            string strsql = "select contractid as 合同编号,company as 项目名称,product as 产品,date as 日期 from [dbo].[Plan] where company like '%"+cc+"%' and date between '" + aa + "' and '" + bb + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rw = e.RowIndex;
            string a = dataGridView1.Rows[rw].Cells[0].Value.ToString();
            Outsourcing outsourcing = (Outsourcing)this.Owner;
            outsourcing.Controls["XLD"].Text = a;
            this.Close();
        }
    }
}
