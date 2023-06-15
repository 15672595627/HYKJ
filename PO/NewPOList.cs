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


namespace WindowsFormsApp1.PO
{
    public partial class NewPOList : Form
    {
        public NewPOList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string aa = DDBH.Text.Trim();
            string bb = GYS.Text.Trim();
            string cc = RQ.Text.Trim();
            string dd = RQ1.Text.Trim();

            string strsql = "select orderid as 订单编号,date as 日期,supplier as 供应商,delivery as 交期, examine as 审核标记 from [dbo].[NewPO_h] where orderid like '%" + aa + "%' and  supplier like '%" + bb + "%'  and date between '" + cc + "' and '" + dd + "' ";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[NewPO_h] SET examine = '已审核' where orderid like '%" + a + "%'";
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

        private void button3_Click(object sender, EventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[NewPO_h] SET examine = '未审核' where orderid like '%" + a + "%'";
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
    }
}
