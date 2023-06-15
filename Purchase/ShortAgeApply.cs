using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Desgin;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;

namespace WindowsFormsApp1.Purchase
{
    public partial class ShortAgeApply : Form
    {
        public ShortAgeApply()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void ShortAgeApply_Load(object sender, EventArgs e)
        {
            RQ.Text = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "BLCGD" + time;

        }
        private void HTBH_DoubleClick(object sender, EventArgs e)
        {
            ShortAgeApplyContract shortGoods = new ShortAgeApplyContract();
            shortGoods.Show(this);
        }

        private void HTBH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(HTBH.Text == "")
                {
                    MessageBox.Show("请输入合同编号");
                }
                else
                {
                    try
                    {
                        string strsql = "select contractid as 合同编号,company as 公司名,project as 项目名称 from [dbo].[Contract_h] where contractid = '" + HTBH.Text.Trim() + "'";
                        SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        GSMC.Text = ds.Tables[0].Rows[0][1].ToString();
                        XMMC.Text = ds.Tables[0].Rows[0][2].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    try
                    {
                        dataGridView1.Columns.Clear();
                        string strsql1 = "select contractid as 合同编号,zcid as 主材编号,zcmc as 主材名称,zcgg as 主材规格,zczs as 主材支数 from [dbo].[Desgin_zc] where contractid = '" + HTBH.Text.Trim() + "'";
                        SqlDataAdapter da1 = new SqlDataAdapter(strsql1, SQL);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        if (ds1.Tables[0].Rows.Count > 0)
                        dataGridView1.DataSource = ds1.Tables[0];
                        string col = "DW";
                        string text = "单位";
                        dataGridView1.Columns.Add(col, text);
                        string col1 = "SL";
                        string text1 = "采购数量";
                        dataGridView1.Columns.Add(col1, text1);
                        string col2 = "BZ";
                        string text2 = "备注";
                        dataGridView1.Columns.Add(col2, text2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    try
                    {
                        dataGridView2.Columns.Clear();
                        string strsql2 = "select contractid as 合同编号,pjid as 配件编号,pjmc as 配件名称,pjgg as 配件规格,pjsf as 配件实发 from [dbo].[Desgin_pj] where contractid = '" + HTBH.Text.Trim() + "'";
                        SqlDataAdapter da2 = new SqlDataAdapter(strsql2, SQL);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        if (ds2.Tables[0].Rows.Count > 0)
                        dataGridView2.DataSource = ds2.Tables[0];

                        string col = "DW1";
                        string text = "单位";
                        dataGridView2.Columns.Add(col, text);
                        string col1 = "SL1";
                        string text1 = "采购数量";
                        dataGridView2.Columns.Add(col1, text1);
                        string col2 = "BZ1";
                        string text2 = "备注";
                        dataGridView2.Columns.Add(col2, text2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HTBH.Text == "")
            {
                MessageBox.Show("请输入合同编号");
            }
            else
            {
                string djbh = DJBH.Text.Trim();
                string rq = RQ.Text.Trim();
                string htbh = HTBH.Text.Trim();
                string gsmc = GSMC.Text.Trim();
                string xmmc = XMMC.Text.Trim();
                string bz = BZ.Text.Trim();
                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [dbo].[POApply] where contractid ='" + htbh + "'";
                cmd.Connection = con;
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("订单已录", "警告");
                }
                else
                {
                    sdr.Close();
                    con.Close();
                    button1.Enabled = false;
                    try
                    {
                        con.Open();
                        if (dataGridView1.Rows.Count > 0)
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[5].Value == null)
                                    dataGridView1.Rows[i].Cells[5].Value = 0;
                                if (dataGridView1.Rows[i].Cells[6].Value == null)
                                    dataGridView1.Rows[i].Cells[6].Value = 0;
                                if (dataGridView1.Rows[i].Cells[7].Value == null)
                                    dataGridView1.Rows[i].Cells[7].Value = 0;
                                string wlbh = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                                string wlmc = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                                string wlgg = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                                
                                string wldw = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                                string cgsl = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                                string cgbz = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();

                                cmd.CommandText = "INSERT INTO [dbo].[POApply] ([orderid],[contractid],[date],[company],[project],[wlid],[wlmc],[wlgg],[wldw],[cgsl],[remakes],[remakes1],[examine]) VALUES ('" + djbh + "','" + htbh + "','" + rq + "','" + gsmc + "','" + xmmc + "','" + wlbh + "','" + wlmc + "','" + wlgg + "','" + wldw + "','" + cgsl + "','" + cgbz + "','" + bz + "','未审核')";
                                int cot = cmd.ExecuteNonQuery();
                            }
                      
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    finally
                    {
                        con.Close();
                    }
                    try
                    {
                        con.Open();
                        if (dataGridView2.Rows.Count > 0)
                            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                            {
                                if (dataGridView2.Rows[i].Cells[5].Value == null)
                                    dataGridView2.Rows[i].Cells[5].Value = 0;
                                if (dataGridView2.Rows[i].Cells[6].Value == null)
                                    dataGridView2.Rows[i].Cells[6].Value = 0;
                                if (dataGridView2.Rows[i].Cells[7].Value == null)
                                    dataGridView2.Rows[i].Cells[7].Value = 0;
                                string wlbh = dataGridView2.Rows[i].Cells[1].Value.ToString().Trim();
                                string wlmc = dataGridView2.Rows[i].Cells[2].Value.ToString().Trim();
                                string wlgg = dataGridView2.Rows[i].Cells[3].Value.ToString().Trim();
                                
                                string wldw = dataGridView2.Rows[i].Cells[5].Value.ToString().Trim();
                                string cgsl = dataGridView2.Rows[i].Cells[6].Value.ToString().Trim();
                                string cgbz = dataGridView2.Rows[i].Cells[7].Value.ToString().Trim();

                                cmd.CommandText = "INSERT INTO [dbo].[POApply] ([orderid],[contractid],[date],[company],[project],[wlid],[wlmc],[wlgg],[wldw],[cgsl],[remakes],[remakes1],[examine]) VALUES ('" + djbh + "','" + htbh + "','" + rq + "','" + gsmc + "','" + xmmc + "','" + wlbh + "','" + wlmc + "','" + wlgg + "','" + wldw + "','" + cgsl + "','" + cgbz + "','" + bz + "','未审核')";
                                int cot = cmd.ExecuteNonQuery();
                            }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

    }
}
