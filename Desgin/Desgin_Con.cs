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
using WindowsFormsApp1.Desgin;

namespace WindowsFormsApp1.Desgin
{
    public partial class Desgin_Con : Form
    {
        public Desgin_Con()
        {
            InitializeComponent();
        }

        private static string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button2_Click(object sender, EventArgs e)
        {
            string aa = HTBH.Text.Trim();
            string sql = String.Format("select contractid as 合同编号,company as 客户,project as 项目 from [dbo].[Contract_h] where contractid like '%" + aa + "%'");
            SqlDataAdapter da = new SqlDataAdapter(sql, SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            string htbh = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string gsm = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string xmmc = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            NewDesgin newDesgin = (NewDesgin)this.Owner;
            newDesgin.Controls["groupBox1"].Controls["HTBH"].Text = htbh;
            newDesgin.Controls["groupBox1"].Controls["GSM"].Text = gsm;
            newDesgin.Controls["groupBox1"].Controls["XMMC"].Text = xmmc;

            this.Close();
        }
    }
}