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
using WindowsFormsApp1.Goods;
using System.Collections;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1.Bill
{
    public partial class Outsourcing : Form
    {
        public Outsourcing()
        {
            InitializeComponent();
        }

        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public static string OTWL { get; set; }
        
        private void Outsourcing_Load(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("d");
            string time1 = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "LLD" + time1;
            DJRQ.Text = time;
        }

        private void BC_Click(object sender, EventArgs e)
        {
            if (XLD.Text == "")
            {
                MessageBox.Show("请输入单据");
            }
            else
            {
                string aa = XLD.Text.Trim();
                string bb = DJRQ.Text.Trim();
                string cc = DJBH.Text.Trim();
                string dd = CP.Text.Trim();
                string ee = XMMC.Text.Trim();

                SqlConnection con = new SqlConnection(SQL);
                try
                {
                    con.Open();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand();
                        string a1 = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                        string a2 = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                        string a3 = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                        string a4 = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                        string a5 = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();


                        cmd.CommandText = "INSERT INTO [dbo].[Outsourcing] ([billid],[contractid],[company],[product],[date],[goodsid],[goodsname],[goodsnorms],[goodsunit],[goodsnum],[remarks],[examine]) VALUES ('" + cc + "','" + aa + "','" + ee + "','" + dd + "','" + bb + "','" + a1 + "','" + a2 + "','" + a3 + "','" + a4 + "','" + a5 + "','" + BZ.Text.Trim() + "','未审核')";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败，失败原因" + ex.Message);
                }
                finally
                {
                    con.Close();
                }
                try
                {
                    con.Open();
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand();
                        string a1 = dataGridView2.Rows[i].Cells[1].Value.ToString().Trim();
                        string a2 = dataGridView2.Rows[i].Cells[2].Value.ToString().Trim();
                        string a3 = dataGridView2.Rows[i].Cells[3].Value.ToString().Trim();
                        string a4 = dataGridView2.Rows[i].Cells[4].Value.ToString().Trim();
                        string a5 = dataGridView2.Rows[i].Cells[5].Value.ToString().Trim();



                        cmd.CommandText = "INSERT INTO [dbo].[Outsourcing] ([billid],[contractid],[company],[product],[date],[goodsid],[goodsname],[goodsnorms],[goodsunit],[goodsnum],[remarks],[examine]) VALUES ('" + cc + "','" + aa + "','" + ee + "','" + dd + "','" + bb + "','" + a1 + "','" + a2 + "','" + a3 + "','" + a4 + "','" + a5 + "','" + BZ.Text.Trim() + "','未审核')";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败，失败原因" + ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }

        private void XLD_KeyDown(object sender, KeyEventArgs e)
        {
            string aa = XLD.Text.Trim();
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            string strsql = "select contractid as 合同编号,project as 项目名称, product as 产品 from [dbo].[Desgin_h] where contractid = '" + aa + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            XMMC.Text = ds.Tables[0].Rows[0][1].ToString();
            CP.Text = ds.Tables[0].Rows[0][2].ToString();

            string strsql1 = "select contractid as 合同编号,zcid as 主材编码, zcmc as 主材名称,zcgg as 主材规格,zclb as 主材类别,zczs as 主材支数 from [dbo].[Desgin_zc] where contractid = '" + aa + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(strsql1, SQL);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Columns.Add("bz", "备注");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Cells[6].Value = 0;
            dataGridView1.Columns.Add("kw", "库位");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Cells[7].Value = 0;

            string strsql2 = "select contractid as 合同编号,pjid as 配件编码,pjmc as 配件名称,pjgg as 配件规格,pjcz as 配件材质,pjsf as 配件实发 from [dbo].[Desgin_pj] where contractid = '" + aa + "'";
            SqlDataAdapter da2 = new SqlDataAdapter(strsql2, SQL);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            dataGridView2.Columns.Add("bz", "备注");
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                dataGridView2.Rows[i].Cells[6].Value = 0;
            dataGridView2.Columns.Add("kw", "库位");
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                dataGridView2.Rows[i].Cells[7].Value = 0;

        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            OutsourcingPlan outsourcingPlan = new OutsourcingPlan();
            outsourcingPlan.Show(this);
        }

        private void DY_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            string yt = XLD.Text.Trim()+XMMC.Text.Trim();


            int r = 50; // 设置横坐标的位置

            int c = 200; // 设置纵坐标的间隔

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Pen mypen= new Pen(Color.Black, 1);
            Font bt = new Font("楷体", 24, FontStyle.Bold);
            Font zw = new Font("楷体", 12, FontStyle.Bold);



            Brush bru = Brushes.Black;


            e.Graphics.DrawString("生产领料单", bt, bru, 305, 50);
            e.Graphics.DrawString("单据编号：", zw, bru, 100, 110);
            e.Graphics.DrawString(DJBH.Text, zw, bru, 180, 110);
            e.Graphics.DrawString("领料用途：", zw, bru, 100, 130);
            e.Graphics.DrawString(yt, zw, bru, 180, 130);
            e.Graphics.DrawString("日期：", zw, bru, 600, 110);
            e.Graphics.DrawString(DJRQ.Text, zw, bru, 650, 110);


            foreach (DataGridViewColumn dgvcol in dataGridView1.Columns)
            {
                if (!dgvcol.Visible) continue;
                if(dgvcol.HeaderText != "合同编号")
                {
                    if(dgvcol.HeaderText != "主材编码")
                    {
                        if (dgvcol.HeaderText == "主材名称")
                        {
                            e.Graphics.DrawRectangle(mypen, r, 150, 200, 50);

                            e.Graphics.DrawString(dgvcol.HeaderText, new Font("楷体", 12, FontStyle.Regular), Brushes.Black, new RectangleF(r, 150, 200, 50), sf);
                            r = r + 200;
                        }
                        else
                        {
                            e.Graphics.DrawRectangle(mypen, r, 150, 100, 50);

                            e.Graphics.DrawString(dgvcol.HeaderText, new Font("楷体", 12, FontStyle.Regular), Brushes.Black, new RectangleF(r, 150, 100, 50), sf);
                            r = r + 100;
                        }
                    }
                    
                }
            }

            r = 50;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 2; j < dataGridView1.Columns.Count; j++)
                {
                    if (j == 2)
                    {
                        e.Graphics.DrawRectangle(mypen, r, c, 200, 50);
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12, FontStyle.Regular), Brushes.Black, new RectangleF(r, c, 200, 50), sf);
                        r = r + 200;
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(mypen, r, c, 100, 50);
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12, FontStyle.Regular), Brushes.Black, new RectangleF(r, c, 100, 50), sf);
                        r = r + 100;
                    }


                }
                r = 50;
                c += 50;
            }

            int zc = dataGridView1.Rows.Count;
            int pj = zc * 100;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 2; j < dataGridView2.Columns.Count; j++)
                {
                    if (j == 2)
                    {
                        e.Graphics.DrawRectangle(mypen, r, pj, 200, 50);
                        e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12, FontStyle.Regular), Brushes.Black, new RectangleF(r, pj, 200, 50), sf);
                        r = r + 200;
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(mypen, r, pj, 100, 50);
                        e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12, FontStyle.Regular), Brushes.Black, new RectangleF(r, pj, 100, 50), sf);
                        r = r + 100;
                    }
                }
                r = 50;
                pj += 50;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0||dataGridView2.Rows.Count > 0)
            {
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string bh1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string bh2 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    string strsql1 = "select goodsid,location from [dbo].[Goods] where goodsid = '" + bh1 + "'";
                    string strsql2 = "select goodsid,location from [dbo].[Goods] where goodsid = '" + bh2 + "'";
                    SqlDataAdapter da1 = new SqlDataAdapter(strsql1, SQL);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    dataGridView1.Rows[i].Cells[7].Value = dt1.Rows[0][1].ToString();
                    SqlDataAdapter da2 = new SqlDataAdapter(strsql2, SQL);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    dataGridView2.Rows[i].Cells[7].Value = dt2.Rows[0][1].ToString();
                }
            }
        }
    }
}