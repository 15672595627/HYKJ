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

namespace WindowsFormsApp1.Bill
{
    public partial class InPurchase : Form
    {
        public InPurchase()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string strsql = "select orderid as 订单编号,applyid as 申请单号,date as 日期,supplier as 供应商,delivery as 交期,examine as 审核状态,state as 单据状态  from [dbo].[NewPO_h]   where  date between '" + RQ1.Text.Trim() + "' and '" + RQ2.Text.Trim() + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            string aa = dataGridView1.Rows[row].Cells[0].Value.ToString().Trim();
            //Insourcing insourcing = (Insourcing)this.Owner;
            //insourcing.Controls["CGDD"].Text = aa;
            this.Close();
        }
    }
}
