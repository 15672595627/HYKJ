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
using WindowsFormsApp1.Purchase;

namespace WindowsFormsApp1.Desgin
{
    public partial class ShortAgeApplyContract : Form
    {
        public ShortAgeApplyContract()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string aa = dateTimePicker1.Text.ToString().Trim();
            string bb = dateTimePicker2.Text.ToString().Trim();
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            string strsql = "select contractid as 合同编号,date as 日期 , company as 客户名,product as 产品,lable as 缺料标识 from [dbo].[Desgin_h]  where  lable like '%缺料%' and date between '" + aa + "'and '" + bb + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            string aa = dataGridView1.Rows[row].Cells[0].Value.ToString().Trim();
            ShortAgeApply shortAge = (ShortAgeApply)this.Owner;
            shortAge.Controls["HTBH"].Text = aa;
            this.Close();
        }
    }
}
