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

namespace WindowsFormsApp1.Purchase
{
    public partial class POApplyList : Form
    {
        public POApplyList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            string aa = RQ.Text.Trim();
            string bb = RQ1.Text.Trim();
            string strsql = "select orderid as 单据编号,contractid as 合同编号,date as 日期,company as 公司名,project as 项目名称,wlid as 物料编码,wlmc as 物料名称,wlgg as 物料规格,wldw as 单位,cgsl as 采购数量,remakes as 物料备注,remakes1 as 单据备注,examine as 审核状态 from [dbo].[POApply] where date between '" + aa + "'and '" + bb + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[POApply] SET examine = '已审核' where orderid like '%" + a + "%'";
            int count = cmd.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("审核成功");
            }
            else
            {
                MessageBox.Show("审核失败");
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[POApply] SET examine = '未审核' where orderid like '%" + a + "%'";
            int count = cmd.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("反审核成功");
            }
            else
            {
                MessageBox.Show("反审核失败");
            }
            conn.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString().Trim();
            ShortAgeApplyRead shortAgeRead = new ShortAgeApplyRead();
            ShortAgeApplyRead.SAR = a;
            shortAgeRead.Show();
        }
    }
}
