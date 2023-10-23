using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Main;
using System.Data.SqlClient;
using System.Configuration;
using WindowsFormsApp1.Class;
using System.Xml.Serialization;

namespace WindowsFormsApp1.Contract
{
    public partial class NewContract : Form
    {
        public NewContract()
        {
            InitializeComponent();
            this.dataGridView1.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e) { };
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string con_user { get; set; } 
        public string con_group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void NewContract_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            string a = "XSHT" + time;
            DJBH.Text = a;
            DJRQ.Text = DateTime.Now.ToString("yyyy-MM-dd");
            toolStripStatusLabel2.Text = con_user;
            toolStripStatusLabel5.Text = con_group;
        }

        private void GSM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ContractCustomer contractCustomer = new ContractCustomer();
            contractCustomer.Show(this);
        }

        private void YWY_TextChanged(object sender, EventArgs e)
        {
            
            string strsql = String.Format("select seller as 业务员,company as 分公司,m_target as 月目标,y_target as 年目标 from [dbo].[Seller] where seller like '%" + YWY.Text.Trim() + "%'");
            SqlDataAdapter adapter = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                FGS.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            if (AZ.CheckState == CheckState.Checked)
                AZ.Text = "安装";
            if (YS.CheckState == CheckState.Checked)
                YS.Text = "运输";
            if (WLKH.CheckState == CheckState.Checked)
                WLKH.Text = "网络客户";
            if (HS.CheckState == CheckState.Checked)
                HS.Text = "含税";

            string djbh = DJBH.Text.Trim();
            string djrq = DJRQ.Text.Trim();
            string sjd = SJDXH.Text.Trim();//数据单编号
            string htbh = HTBH.Text.Trim();//合同编号
            string gsm = GSM.Text.Trim();
            string xmmc = XMMC.Text.Trim();
            string fgs = FGS.Text.Trim();
            string khlx = KHLX.Text.Trim();
            string khlb = KHLB.Text.Trim();
            string htlb = HTLB.Text.Trim();
            string qy = QY.Text.Trim();
            string ywy = YWY.Text.Trim();
            string gcj = GCJ.Text.Trim();
            string az = AZ.Text.Trim();
            string ys = YS.Text.Trim();
            string wlkh = WLKH.Text.Trim();
            string hs = HS.Text.Trim();
            string zje = ZJE.Text.Trim();
            string bz = BZ.Text.Trim();
            string cd = CD.Text.Trim();
            string qj = QJ.Text.Trim();
            if (HTLX.Text == "")
            {
                MessageBox.Show("请选择合同类型", "警告");
            }
            else
            {
                if (HTLX.Text == "数据合同")
                {
                    if (SJDXH.Text == "")
                    {
                        MessageBox.Show("请输入数据单编号");
                    }
                    else
                    {
                        bool go = true;

                        string sjht = htbh + "-" + sjd;
                        SqlConnection conn = new SqlConnection(SQL);
                        conn.Open();
                        SqlCommand cmmd = conn.CreateCommand();
                        cmmd.CommandText = "select * from [dbo].[Contract_h] where contractid ='" + sjht + "'";
                        SqlDataReader sdr = cmmd.ExecuteReader();
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("编码已存在", "警告");
                        }
                        else
                        {
                            sdr.Close();
                            conn.Close();
                            try
                            {
                                conn.Open();
                                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                                {
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.Connection = conn;
                                    string cplx = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                                    string cplb = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                                    string cpmc = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                                    string cpgg = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                                    string cpgd = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                                    string cpdj = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                                    string cpjg = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                                    string cpje = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                                    cmd.CommandText = "INSERT INTO [dbo].[Contract_b] ([orderid],[contractid],[date],[company],[project],[pd_kind],[pd_cate],[product],[norms],[high],[price],[s_amount],[amount],[ry]) VALUES ('" + djbh + "','" + sjht + "','" + djrq + "','" + gsm + "','" + xmmc + "','" + cplx + "','" + cplb + "','" + cpmc + "','" + cpgg + "','" + cpgd + "','" + cpdj + "','" + cpjg + "','" + cpje + "','"+ con_user + "')";
                                    int cot = cmd.ExecuteNonQuery();

                                    cmd.CommandText = "INSERT INTO [dbo].[Product] ([contractid],[company],[product],[amount]) VALUES ('" + sjht + "','" + gsm + "','" + cpmc + "','" + cpje + "')";
                                    int cot1 = cmd.ExecuteNonQuery();

                                    //返回数据条数验证保存
                                    if (cot < 1 || cot1 < 1)
                                    {
                                        MessageBox.Show("保存失败");
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("更新失败，失败原因" + ex.Message);
                                go = false;
                            }
                            finally
                            {
                                conn.Close();
                            }
                            try
                            {
                                if(go == true)
                                {
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand();
                                    string sqlstr = "INSERT INTO [dbo].[Contract_h] ([orderid],[contractid],[date],[company],[project],[sub],[kh_type],[kh_cate],[con_cate],[area],[place],[seller],[cost],[installation],[transport],[net],[tax],[amount],[remake],[examine],[qj],[ry]) VALUES ('" + djbh + "','" + sjht + "','" + djrq + "','" + gsm + "','" + xmmc + "','" + fgs + "','" + khlx + "','" + khlb + "','" + htlb + "','" + qy + "','" + cd + "','" + ywy + "','" + gcj + "','" + az + "','" + ys + "','" + wlkh + "','" + hs + "','" + zje + "','" + bz + "','已审核','" + qj + "','"+ con_user + "')";
                                    cmd.CommandText = sqlstr;
                                    cmd.Connection = conn;
                                    int count = cmd.ExecuteNonQuery();
                                    if (count > 0)
                                    {
                                        MessageBox.Show("保存成功");

                                        this.Close();
                                        NewContract newContract = new NewContract();
                                        newContract.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("保存失败");
                                    }
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("更新失败，失败原因" + ex.Message);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            
                        }
                    }

                }
                else
                {
                    bool go = true;
                    SqlConnection conn = new SqlConnection(SQL);
                    conn.Open();
                    SqlCommand cmmd = conn.CreateCommand();
                    cmmd.CommandText = "select * from [dbo].[Contract_h] where contractid ='" + HTBH.Text.Trim() + "'";
                    SqlDataReader sdr = cmmd.ExecuteReader();
                    sdr.Read();
                    if (sdr.HasRows)
                    {
                        MessageBox.Show("编码已存在", "警告");
                    }
                    else
                    {
                        sdr.Close();
                        conn.Close();
                        try
                        {
                            conn.Open();
                            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                            {
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = conn;
                                string cplx = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                                string cplb = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                                string cpmc = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                                string cpgg = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                                string cpgd = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                                string cpdj = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                                string cpjg = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                                string cpje = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                                cmd.CommandText = "INSERT INTO [dbo].[Contract_b] ([orderid],[contractid],[date],[company],[project],[pd_kind],[pd_cate],[product],[norms],[high],[price],[s_amount],[amount]) VALUES ('" + djbh + "','" + htbh + "','" + djrq + "','" + gsm + "','" + xmmc + "','" + cplx + "','" + cplb + "','" + cpmc + "','" + cpgg + "','" + cpgd + "','" + cpdj + "','" + cpjg + "','" + cpje + "')";
                                int cot = cmd.ExecuteNonQuery();

                                cmd.CommandText = "INSERT INTO [dbo].[Product] ([contractid],[company],[product],[amount]) VALUES ('" + htbh + "','" + gsm + "','" + cpmc + "','" + cpje + "')";
                                int cot1 = cmd.ExecuteNonQuery();

                                if (cot < 1 || cot1 < 1)
                                {
                                    MessageBox.Show("保存失败");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("更新失败，失败原因" + ex.Message + "\n" + "检查一下详细数据是不是没录。");
                            go = false;
                        }
                        finally
                        {
                            conn.Close();
                        }
                        try
                        {
                            if(go == true)
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand();
                                string sqlstr = "INSERT INTO [dbo].[Contract_h] ([orderid],[contractid],[date],[company],[project],[sub],[kh_type],[kh_cate],[con_cate],[seller],[place],[area],[cost],[installation],[transport],[net],[amount],[remake],[examine],[qj]) VALUES ('" + djbh + "','" + htbh + "','" + djrq + "','" + gsm + "','" + xmmc + "','" + fgs + "','" + khlx + "','" + khlb + "','" + htlb + "','" + ywy + "','" + cd + "','" + qy + "','" + gcj + "','" + az + "','" + ys + "','" + wlkh + "','" + zje + "','" + bz + "','已审核','" + qj + "')";
                                cmd.CommandText = sqlstr;
                                cmd.Connection = conn;
                                int count = cmd.ExecuteNonQuery();
                                if (count > 0)
                                {
                                    MessageBox.Show("保存成功");
                                    this.Close();
                                    NewContract newContract = new NewContract();
                                    newContract.Show();
                                }
                                else
                                {
                                    MessageBox.Show("保存失败");
                                }
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("更新失败，失败原因" + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }  
                    }
                }
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            decimal sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["金额"].Value);
                dataGridView1.Rows[i].Cells["产品名称"].Value = HTBH.Text.Trim() + "+" + XMMC.Text.Trim() + "+" + dataGridView1.Rows[i].Cells["产品类型"].Value + dataGridView1.Rows[i].Cells["产品类别"].Value;
            }
            ZJE.Text = sum.ToString();
        }

        private void HTLX_TextChanged(object sender, EventArgs e)
        {
            if (HTLX.Text == "正常合同")
            {
                SJD.Visible = false;
                SJDXH.Visible = false;

                string strsql = "SELECT RANK() OVER (ORDER BY contractid DESC) AS [RANK],contractid FROM [dbo].[Contract_h] where contractid like '%W%'";
                SqlDataAdapter adapter = new SqlDataAdapter(strsql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                ZXDH.Text = ds.Tables[0].Rows[0][1].ToString();

            }
            if(HTLX.Text == "样品合同")
            {
                SJD.Visible = false;
                SJDXH.Visible = false;

                string strsql = "SELECT RANK() OVER (ORDER BY contractid DESC) AS [RANK],contractid FROM [dbo].[Contract_h] where contractid like '%Y%'";
                SqlDataAdapter adapter = new SqlDataAdapter(strsql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                ZXDH.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            if(HTLX.Text == "补单合同")
            {
                SJD.Visible = false;
                SJDXH.Visible = false;

                string strsql = "SELECT RANK() OVER (ORDER BY contractid DESC) AS [RANK],contractid FROM [dbo].[Contract_h] where contractid like '%B%' and contractid not like '%MJ%'";
                SqlDataAdapter adapter = new SqlDataAdapter(strsql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                ZXDH.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            if (HTLX.Text == "美居合同")
            {
                SJD.Visible = false;
                SJDXH.Visible = false;


                string strsql = "SELECT RANK() OVER (ORDER BY contractid DESC) AS [RANK],contractid FROM [dbo].[Contract_h] where contractid like '%MJ%'";
                SqlDataAdapter adapter = new SqlDataAdapter(strsql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                ZXDH.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            /*if (HTLX.Text == "样品合同")
            {
                SJD.Visible = false;
                SJDXH.Visible = false;
                HTBH.ReadOnly = true;
                string aa = DateTime.Now.ToString("yyyyMM");
                string strsql = "SELECT RANK() OVER (ORDER BY contractid DESC) AS [RANK],* FROM [dbo].[Contract_h] where contractid like '%" + aa + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(strsql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    HTBH.Text = aa + "Y" + "-" + "1";
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string bb = ds.Tables[0].Rows[0][3].ToString();
                    decimal htid = Convert.ToDecimal(bb.Split('-').Last());
                    string newid = (htid + 1).ToString();
                    HTBH.Text = aa + "Y" + "-" + newid;
                }
            }
            if (HTLX.Text == "补单合同")
            {
                SJD.Visible = false;
                SJDXH.Visible = false;
                HTBH.ReadOnly = true;
                string aa = DateTime.Now.ToString("yyyyMM");
                string strsql = "SELECT RANK() OVER (ORDER BY contractid DESC) AS [RANK],* FROM [dbo].[Contract_h] where contractid like '%" + aa + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(strsql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    HTBH.Text = aa + "B" + "-" + "1";
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string bb = ds.Tables[0].Rows[0][3].ToString();
                    decimal htid = Convert.ToDecimal(bb.Split('-').Last());
                    string newid = (htid + 1).ToString();
                    HTBH.Text = aa + "B" + "-" + newid;
                }
            }
            */
            if (HTLX.Text == "数据合同")
            {

                GSM.ReadOnly = true;
                SJD.Visible = true;
                SJDXH.Visible = true;


            }


        }

        private void HTBH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(HTBH.ReadOnly == false)
            {
                Con_date con_Date = new Con_date();
                con_Date.Show(this);
            }
            
        }

        private void HTBH_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (HTBH.Text == "")
                {
                    MessageBox.Show("请输入合同编号");
                }
                else
                {
                    if (HTLX.Text == "数据合同")
                    {
                        string strsql = "select * from [dbo].[Contract_h] where contractid = '" + HTBH.Text.Trim() + "'";
                        SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GSM.Text = ds.Tables[0].Rows[0][4].ToString();
                            XMMC.Text = ds.Tables[0].Rows[0][5].ToString();
                            FGS.Text = ds.Tables[0].Rows[0][6].ToString();
                            KHLX.Text = ds.Tables[0].Rows[0][7].ToString();
                            KHLB.Text = ds.Tables[0].Rows[0][8].ToString();
                            HTLB.Text = ds.Tables[0].Rows[0][9].ToString();
                            YWY.Text = ds.Tables[0].Rows[0][12].ToString();
                            QY.Text = ds.Tables[0].Rows[0][11].ToString();
                        }
                    }

                }
            }

        }

        private void DYFM_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings.Landscape = true;
                this.printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            //
            //封面打印，画方格
            //
            Pen mypen = new Pen(Color.Black, 4);
            Pen hx = new Pen(Color.Black, 2);
            Point pt1 = new Point(218, 500);
            Point pt2 = new Point(218, 770);
            Point pt3 = new Point(386, 500);
            Point pt4 = new Point(386, 770);
            Point pt5 = new Point(554, 500);
            Point pt6 = new Point(554, 770);
            Point pt7 = new Point(722, 500);
            Point pt8 = new Point(722, 770);
            Point pt9 = new Point(890, 500);
            Point pt10 = new Point(890, 770);
            Point htmc1 = new Point(510, 195);
            Point htmc2 = new Point(700, 195);
            Point htbh1 = new Point(510, 235);
            Point htbh2 = new Point(700, 235);
            Point cplx1 = new Point(510, 275);
            Point cplx2 = new Point(700, 275);
            Point nqsh1 = new Point(510, 315);
            Point nqsh2 = new Point(700, 315);
            Point az1 = new Point(510, 395);
            Point az2 = new Point(700, 395);
            Point ywy1 = new Point(200, 475);
            Point ywy2 = new Point(400, 475);
            Point scd1 = new Point(510, 475);
            Point scd2 = new Point(700, 475);
            Point chrq1 = new Point(850, 475);
            Point chrq2 = new Point(1050, 475);

            e.Graphics.DrawRectangle(mypen, 50, 50, 1060, 720);
            e.Graphics.DrawLine(mypen, pt1, pt2);
            e.Graphics.DrawLine(mypen, pt3, pt4);
            e.Graphics.DrawLine(mypen, pt5, pt6);
            e.Graphics.DrawLine(mypen, pt7, pt8);
            e.Graphics.DrawLine(mypen, pt9, pt10);

            e.Graphics.DrawLine(hx, htmc1, htmc2);
            e.Graphics.DrawLine(hx, htbh1, htbh2);
            e.Graphics.DrawLine(hx, cplx1, cplx2);
            e.Graphics.DrawLine(hx, nqsh1, nqsh2);
            e.Graphics.DrawLine(hx, az1, az2);
            e.Graphics.DrawLine(hx, ywy1, ywy2);
            e.Graphics.DrawLine(hx, scd1, scd2);
            e.Graphics.DrawLine(hx, chrq1, chrq2);

            e.Graphics.DrawRectangle(mypen, 50, 500, 1060, 270);
            e.Graphics.DrawRectangle(mypen, 50, 590, 1060, 180);
            e.Graphics.DrawRectangle(mypen, 50, 680, 1060, 90);
            Font bt = new Font("楷体", 24,FontStyle.Bold);
            Font zt = new Font("宋体", 16);
            Font jz = new Font("楷体", 16, FontStyle.Bold); 
            Font qm = new Font("宋体", 14);
            Font sm = new Font("宋体", 10);
            Brush bru = Brushes.Black;
            e.Graphics.DrawString("荆州华禹金属材料科技有限公司", bt, bru, 350, 90);
            e.Graphics.DrawString("业务流程跟踪卡", zt, bru, 500, 130);
            e.Graphics.DrawString("合同名称：", zt, bru, 400, 170);
            e.Graphics.DrawString("合同编号：", zt, bru, 400, 210);
            e.Graphics.DrawString("产品类型：", zt, bru, 400, 250);
            e.Graphics.DrawString("内勤审核：", zt, bru, 400, 290);
            e.Graphics.DrawString("定金到账：   是       否", zt, bru, 400, 330);
            e.Graphics.DrawString("是否安装：", zt, bru, 400, 370);
            e.Graphics.DrawString("对方证件：  身份证  公章  营业执照", zt, bru, 400, 410);
            e.Graphics.DrawString("生产地：", jz, bru, 423, 450);
            e.Graphics.DrawString("业务员：", jz, bru, 123, 450);
            e.Graphics.DrawString("出货日期：", jz, bru, 750, 450);
            e.Graphics.DrawString("合同审核/日期", qm, bru, 65, 525);
            e.Graphics.DrawString("（运营部主管签字）", sm, bru, 65, 550);
            e.Graphics.DrawString("下单接单/日期", qm, bru, 401, 525);
            e.Graphics.DrawString("（设计员签字）", sm, bru, 401, 550);
            e.Graphics.DrawString("下单定金审核/日期", qm, bru, 720, 525);
            e.Graphics.DrawString("（出纳签字）", sm, bru, 737, 550);
            e.Graphics.DrawString("合同登记/日期", qm, bru, 65, 615);
            e.Graphics.DrawString("（客服组长签字）", sm, bru, 65, 640);
            e.Graphics.DrawString("下单审核/日期", qm, bru, 401, 615);
            e.Graphics.DrawString("（设计组长签字）", sm, bru, 401, 640);
            e.Graphics.DrawString("生产接单/日期", qm, bru, 737, 615);
            e.Graphics.DrawString("（车间主任签字）", sm, bru, 737, 640);
            e.Graphics.DrawString("跟单接单/日期", qm, bru, 65, 705);
            e.Graphics.DrawString("（跟单员签字）", sm, bru, 65, 730);
            e.Graphics.DrawString("物料报备/日期", qm, bru, 401, 705);
            e.Graphics.DrawString("（设计组长签字）", sm, bru, 401, 730);
            e.Graphics.DrawString("出货尾款审核/日期", qm, bru, 720,705);
            e.Graphics.DrawString("（出纳签字）", sm, bru, 737, 730);

            if (AZ.CheckState == CheckState.Checked)
                AZ.Text = "是";
            if (AZ.CheckState == CheckState.Unchecked)
                AZ.Text = "否";
            string aa = GSM.Text.Trim();
            string bb = XMMC.Text.Trim();
            string htmc = aa + "(" + bb + ")";
            e.Graphics.DrawString(htmc, zt, bru, 510, 170);
            e.Graphics.DrawString(HTBH.Text.Trim(), zt, bru, 510, 210);
            e.Graphics.DrawString(con_user, zt, bru, 510, 290);
            e.Graphics.DrawString(AZ.Text.Trim(), zt, bru, 510, 370);
            e.Graphics.DrawString(CD.Text.Trim(), zt, bru, 510, 450);
            e.Graphics.DrawString(YWY.Text.Trim(), zt, bru, 223, 450);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            pageSetupDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewCustomer newCustomer = new NewCustomer();
            newCustomer.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewSeller newSeller = new NewSeller();
            newSeller.ShowDialog();
        }

        private void NewContract_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}