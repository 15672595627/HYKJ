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

namespace WindowsFormsApp1.Scheduling
{
    public partial class MaterialCheck : Form
    {
        public MaterialCheck()
        {
            InitializeComponent();
        }

        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                string a = dateTimePicker1.Text.ToString().Trim();
                string b = dateTimePicker2.Text.ToString().Trim();
                string strsql = String.Format("select contractid as 合同编号,date as 日期 ,company  as 客户,product as 产品,examine as 审核状态,examine1 as 生产审核状态,lable as 缺料状态   from [dbo].[Desgin_h] where examine = '已审核' and  date between '" + a + "' and '" + b + "'");
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(strsql, SQL);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失败，失败原因" + ex.Message);
            }
        }


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView2.Columns.Clear();
            dataGridView3.Columns.Clear();

            string aa = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string strsql = "select contractid as 合同编号,date as 日期,zcid as 主材编码,zcmc as 主材名称,zcgg as 主材规格,zclb as 主材类别,zccc as 主材尺寸,zczs as 支数 from [dbo].[Desgin_zc] where contractid = '" + aa + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns.Add("即时库存", "即时库存");

            string strsql1 = "select contractid as 合同编号,date as 日期,pjid as 配件编码,pjmc as 配件名称,pjgg as 配件规格,pjcz as 配件材质,dusting as 喷粉状态,pjsf as 配件实发 from [dbo].[Desgin_pj] where contractid = '" + aa + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(strsql1, SQL);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridView3.DataSource = ds1.Tables[0];
            dataGridView3.Columns.Add("即时库存", "即时库存");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShortAgeApply shortAge = new ShortAgeApply();
            shortAge.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[Desgin_h] SET examine1 = '已审核' where contractid like '%" + a + "%'";
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
            string a = dataGridView1.CurrentCell.Value.ToString();
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[Desgin_h] SET examine1 = '未审核' where contractid like '%" + a + "%'";
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

        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0 || dataGridView2.Rows.Count > 0 || dataGridView3.Rows.Count > 0)
            {

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    string id = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    
                    string strsql = "select goodsid,goodsnum from [dbo].[Goods] where goodsid = '" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.Rows[i].Cells[8].Value = dt.Rows[0][1];
                    decimal num1 = Convert.ToDecimal(dt.Rows[0][1]);
                    decimal num = Convert.ToDecimal(dataGridView2.Rows[i].Cells[7].Value);
                    decimal num2 = num1 - num;
                    if(num2 < 0)
                    {
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    if (num2 > 0)
                    {
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    string id = dataGridView3.Rows[i].Cells[2].Value.ToString();

                    string strsql = "select goodsid,goodsnum from [dbo].[Goods] where goodsid = '" + id + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView3.Rows[i].Cells[8].Value = dt.Rows[0][1];
                    decimal num1 = Convert.ToDecimal(dt.Rows[0][1]);
                    decimal num = Convert.ToDecimal(dataGridView3.Rows[i].Cells[7].Value);
                    decimal num2 = num1 - num;
                    if (num2 < 0)
                    {
                        dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    if (num2 > 0)
                    {
                        dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[Desgin_h] SET lable = '主材配件正常' where contractid like '%" + a + "%'";
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
    }
}
