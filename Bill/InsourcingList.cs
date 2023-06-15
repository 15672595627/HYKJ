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
    public partial class InsourcingList : Form
    {
        public InsourcingList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void Button1_Click(object sender, EventArgs e)
        {

            string aa = RQ1.Text.Trim();
            string bb = RQ2.Text.Trim();
            string cc = SHZT.Text.Trim();
            dataGridView1.DataSource = null;
            string strsql = "select billid as 订单编号,orderid as 采购订单编号,date as 日期,goodsid as 物料编码,goodsname as 物料名称,goodsgg as 物料规格,goodsdw as 单位,cgsl as 采购数量,rksl as 入库数量,examine as 审核标识  from [dbo].[Insourcing] where examine like '" + cc + "' and  date between '" + aa + "' and '" + bb + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            string aa = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string stsql = "select * from [dbo].[Insourcing] where billid = '" + aa + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stsql, SQL);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            string shzt = dataSet.Tables[0].Rows[0][9].ToString();
            if (shzt == "已审核")
            {
                MessageBox.Show("单据已审核");
            }
            else
            {
                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE [dbo].[Insourcing] SET examine = '已审核' where billid = '" + aa + "'";
                int cot = cmd.ExecuteNonQuery();
                if (cot > 0)
                {
                    MessageBox.Show("审核成功");
                }
                else
                {
                    MessageBox.Show("审核失败");

                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string wlid = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string strsql = "select goodsid,goodsnum from [dbo].[Goods] where goodsid = '" + wlid + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    decimal go = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                    decimal to = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    string togo = (go + to).ToString();

                    cmd.CommandText = "UPDATE [dbo].[Goods] SET goodsnum = '" + togo + "' where goodsid = '" + wlid + "'";
                    int cot1 = cmd.ExecuteNonQuery();
                    if (cot1 == 0)
                    {
                        MessageBox.Show("保存失败");
                    }
                }
                con.Close();
            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {

            string aa = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string stsql = "select * from [dbo].[Insourcing] where billid = '" + aa + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stsql, SQL);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            string shzt = dataSet.Tables[0].Rows[0][9].ToString();

            if (shzt == "未审核")
            {
                MessageBox.Show("单据未审核");
            }
            else
            {
                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE [dbo].[Insourcing] SET examine = '未审核' where billid = '" + aa + "'";
                int cot = cmd.ExecuteNonQuery();
                if (cot > 0)
                {
                    MessageBox.Show("反审核成功");
                }
                else
                {
                    MessageBox.Show("反审核失败");

                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string wlid = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string wlmc = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string strsql = "select goodsid,goodsnum from [dbo].[Goods] where goodsid = '" + wlid + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    decimal go = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                    decimal to = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[7].Value);
                    decimal togo = go - to;
                    if(togo < 0)
                    {
                        MessageBox.Show("'" + wlmc + "'缺料");
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE [dbo].[Goods] SET goodsnum = '" + togo + "' where goodsid = '" + wlid + "'";
                        int cot1 = cmd.ExecuteNonQuery();
                        if (cot1 == 0)
                        {
                            MessageBox.Show("保存失败");
                        }
                    }
                }
                con.Close();
            }
        }
    }
}
