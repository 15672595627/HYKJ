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

namespace WindowsFormsApp1.PO
{
    public partial class NewShortApply : Form
    {
        public NewShortApply()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string strsql = "select orderid as 单据编号,contractid as 合同编号,date as 日期,company as 客户,project as 项目,examine as 审核状态 from [dbo].[ShortAge_h] where examine = '已审核' and  date between '" + RQ.Text.Trim() + "' and '" + RQ1.Text.Trim() + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string aa = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            NewPO newPO = (NewPO)this.Owner;
            newPO.Controls["SQDH"].Text = aa;
            this.Close();
        }
    }
}
