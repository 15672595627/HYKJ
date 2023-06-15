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
using System.Security.Policy;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Contract
{
    public partial class ContractRead : Form
    {
        public ContractRead()
        {
            InitializeComponent();
        }

        private static string SQL = ConfigurationManager.AppSettings["connectionstring"];
        public string ConR_ORD { get; set; }

        public string conr_user { get; set; }
        public string conr_group { get; set; }

        SqlDataAdapter da1;
        DataTable dt1;

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void ContractRead_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“hyerpDataSet1.Contract_h”中。您可以根据需要移动或移除它。
            asc.controllInitializeSize(this);
            
            toolStripStatusLabel2.Text = conr_user;
            toolStripStatusLabel5.Text = conr_group;
            string aa = ConR_ORD;
            string sql = String.Format("select * from [dbo].[Contract_h] where orderid = '" + aa + "'");
            string sql1 = String.Format("select id,orderid,contractid,pd_kind as 产品类别,pd_cate as 产品类型,product as 产品,norms as 规格,high as 高度,price as 单价,s_amount as 核算单价,amount as 金额 from[dbo].[Contract_b] where orderid = '" + aa + "'");
            SqlDataAdapter da = new SqlDataAdapter(sql, SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DJBH.Text = dt.Rows[0][1].ToString();
            HTBH.Text = dt.Rows[0][2].ToString();
            DJRQ.Text = dt.Rows[0][3].ToString();
            GSM.Text = dt.Rows[0][4].ToString();
            XMMC.Text = dt.Rows[0][5].ToString();
            FGS.Text = dt.Rows[0][6].ToString();//分公司
            KHLX.Text = dt.Rows[0][7].ToString();//客户类型
            KHLB.Text = dt.Rows[0][8].ToString();//客户类别
            HTLB.Text = dt.Rows[0][9].ToString();//合同类别
            QY.Text = dt.Rows[0][10].ToString();//地区
            CD.Text = dt.Rows[0][11].ToString();//产地
            YWY.Text = dt.Rows[0][12].ToString();//
            GCJ.Text = dt.Rows[0][13].ToString();//钢材
            ZJE.Text = dt.Rows[0][18].ToString();//金额
            BZ.Text = dt.Rows[0][19].ToString();//备注
            string b = dt.Rows[0][20].ToString();//审核状态
            QJ.Text = dt.Rows[0][21].ToString();//期间

            if (b == "已审核")
            {
                pictureBox1.Visible = true;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                XG.Enabled = false;
                BC.Enabled = false;

            }
            else
            {
                pictureBox1.Visible = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                XG.Enabled = true;
            }

            da1 = new SqlDataAdapter(sql1, SQL);
            dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["orderid"].Visible = false;
            dataGridView1.Columns["contractid"].Visible = false;


        }
        //打印
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
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
            Font bt = new Font("楷体", 24, FontStyle.Bold);
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
            e.Graphics.DrawString("下单定金审核/日期", qm, bru, 737, 525);
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
            e.Graphics.DrawString("出货尾款审核/日期", qm, bru, 737, 705);
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
            e.Graphics.DrawString(conr_user, zt, bru, 510, 290);
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

        private void DYFM_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings.Landscape = true;
                this.printDocument1.Print();
            }
        }

        private void XG_Click(object sender, EventArgs e)
        {
            BC.Enabled = true;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            QJ.Enabled = true;
            GCJ.ReadOnly = false;
            BZ.ReadOnly = false;

            
        }

        private void BC_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(da1);
                da1.Update(dt1);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Contract_h SET cost = '" + GCJ.Text.Trim() + "',qj = '" + QJ.Text.Trim() + "',remake = '" + BZ.Text.Trim() + "',amount = '" + ZJE.Text.Trim() + "',examine = '已审核' WHERE orderid = '" + ConR_ORD + "'";
                int cot = cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE Contract_b SET date = '" + DJRQ.Text.Trim() + "',company = '" + GSM.Text.Trim() + "',project = '" + XMMC.Text.Trim() + "' WHERE orderid = '" + ConR_ORD + "'";
                int cot1 = cmd.ExecuteNonQuery();

                if (cot > 0 && cot1 > 0)
                {
                    MessageBox.Show("保存成功");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Contract_b WHERE product is NULL";
                int cot = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            BC.Enabled = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            QJ.Enabled = false;
            GCJ.ReadOnly = true;
            BZ.ReadOnly = true;

        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int r = dataGridView1.CurrentRow.Index;
                if (r > 0)
                {

                    dataGridView1.Rows[r].Cells[1].Value = dataGridView1.Rows[r - 1].Cells[1].Value;
                    dataGridView1.Rows[r].Cells[2].Value = dataGridView1.Rows[r - 1].Cells[2].Value;

                }

                decimal sum = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    if (dataGridView1.Rows[i].Cells["金额"].Value == DBNull.Value)
                    {
                        dataGridView1.Rows[i].Cells["金额"].Value = "0";
                    }
                    else
                    {
                        sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["金额"].Value);
                    }
                }
                ZJE.Text = sum.ToString("0.00");
            } 
        }

        private void ContractRead_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}