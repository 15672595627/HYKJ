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
    public partial class OutsourcingList : Form
    {
        public OutsourcingList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void Button1_Click(object sender, EventArgs e)
        {
            string bb = XMMC.Text.Trim();
            string aa = SHZT.Text.Trim();
            dataGridView1.DataSource = null;
            string strsql = "select billid as 订单编号,contractid as 合同编号,company as 项目名称,product as 产品,date as 日期,goodsid as 物料编码,goodsname as 物料名称,goodsnorms as 物料规格,goodsunit as 物料材质类型,goodsnum as 物料数量,remarks as 备注,examine as 审核状态  from [dbo].[Outsourcing] where examine like '" + aa + "' and  company like '%" + bb + "%' and date between '" + RQ1.Text.Trim() + "' and '" + RQ2.Text.Trim() + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            else
            {
                string aa = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string stsql = "select * from [dbo].[Outsourcing] where contractid = '" + aa + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stsql, SQL);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string shzt = dataSet.Tables[0].Rows[0][11].ToString();
                if (shzt == "已审核")
                {
                    MessageBox.Show("单据已审核");
                }
                else
                {
                    SqlConnection con = new SqlConnection(SQL);
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE [dbo].[Outsourcing] SET examine = '已审核' where contractid = '" + aa + "'";
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
                        string bm = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        string wl = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        string strsql = "select goodsid,goodsnum from [dbo].[Goods] where goodsid = '" + bm + "'";
                        SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        decimal go = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                        decimal to = Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                        decimal togo = go - to;
                        if(togo < 0)
                        {
                            MessageBox.Show("'" + wl + "'缺料");
                        }
                        else
                        {
                            cmd.CommandText = "UPDATE [dbo].[Goods] SET goodsnum = '" + togo + "' where goodsid = '" + bm + "'";
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

        private void Button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            else
            {

                string aa = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                string stsql = "select * from [dbo].[Outsourcing] where contractid = '" + aa + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stsql, SQL);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string shzt = dataSet.Tables[0].Rows[0][11].ToString();

                if (shzt == "未审核")
                {
                    MessageBox.Show("单据未审核");
                }
                else
                {
                    SqlConnection con = new SqlConnection(SQL);
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE [dbo].[Outsourcing] SET examine = '未审核' where contractid = '" + aa + "'";
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
                        string bm = dataGridView1.Rows[i].Cells[5].Value.ToString();

                        string strsql = "select goodsid,goodsnum from [dbo].[Goods] where goodsid = '" + bm + "'";
                        SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        decimal go = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                        decimal to = Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                        string togo = (go + to).ToString();
                        cmd.CommandText = "UPDATE [dbo].[Goods] SET goodsnum = '" + togo + "' where goodsid = '" + bm + "'";
                        int cot1 = cmd.ExecuteNonQuery();
                        if (cot1 == 0)
                        {
                            MessageBox.Show("保存失败");
                        }
                    }
                    con.Close();
                }
            }
        }
    }
}
