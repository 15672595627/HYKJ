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

namespace WindowsFormsApp1.Order
{
    public partial class OrderService : Form
    {
        public OrderService()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string OrderProduct1 { get; set; }


        public static string CPMC = "";

        public string ord_user { get; set; }
        public string ord_group { get; set; }


        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void Orderservice_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            XDRQ.Text = DateTime.Now.ToString("d");
            DDBH.Text = "XSDD" + time;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 9);
            dataGridView1.DefaultCellStyle.Font = new Font("宋体", 9);
            toolStripStatusLabel2.Text = ord_user;
            toolStripStatusLabel5.Text = ord_group;
            GDY.Text = ord_user;
        }

        #region 合同编号相关

        private void HTBH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FindContract findcontract = new FindContract();
            findcontract.Show(this);
        }

        private void HTBH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(HTBH.Text == "")
                {
                    MessageBox.Show("合同编号不可为空");
                }
                else
                {
                    string a = HTBH.Text.Trim();

                    string sql = String.Format("select contractid as 合同编号,date as 日期, company as 公司名,project as 项目名称,seller as 业务员,area as 区域,amount as 金额 from [dbo].[Contract_h] where contractid like '%" + a + "%'");

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, SQL);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    QDRQ.Text = ds.Tables[0].Rows[0][1].ToString();
                    GSM.Text = ds.Tables[0].Rows[0][2].ToString();
                    XMMC.Text = ds.Tables[0].Rows[0][3].ToString();
                    YWY.Text = ds.Tables[0].Rows[0][4].ToString();
                    QY.Text = ds.Tables[0].Rows[0][5].ToString();
                    HTJE.Text = ds.Tables[0].Rows[0][6].ToString();

                    string strsql = "select contractid as 合同编号,desgin as 下单员 from [dbo].[DesginBom] where contractid like '%" + a + "%'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count > 0)
                    XDY.Text = dt.Rows[0][1].ToString();
                }
            }
        }

        #endregion 合同编号相关

        #region 红色groupbox边框

        private void GroupBox1_Paint_1(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;

            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Red, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }

        private void GroupBox4_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;

            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Red, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }

        private void GroupBox2_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;

            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Red, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }

        private void GroupBox3_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;

            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Red, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }

        private void GroupBox5_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;

            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Red, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }

        #endregion 红色groupbox边框


        private void Button2_Click(object sender, EventArgs e)
        {
            if (HTBH.Text == "" || JESL.Text == ""|| QJ.Text == "")
            {
                MessageBox.Show("请输入合同编号/税率/期间");
            }
            if (YS.Text == "")
            {
                MessageBox.Show("请输入颜色");
            }
            if (ZCM.Text == "")
            {
                MessageBox.Show("请输最长米");
            }
            if (ZMS.Text == "")
            {
                MessageBox.Show("请输入总米数");
            }
            if (HTBH.Text == "")
            {
                MessageBox.Show("请输入合同编号");
            }
            if (LXR.Text == "")
            {
                MessageBox.Show("请输入联系人");
            }
            if (LXFS.Text == "")
            {
                MessageBox.Show("请输入联系方式");
            }
            else
            {
                string qj = QJ.Text;
                string ddbh = DDBH.Text;
                string htbh = HTBH.Text;
                string xdrq = XDRQ.Text;
                string gdy = GDY.Text;
                string xmmc = XMMC.Text;
                string gsm = GSM.Text;
                string qdrq = QDRQ.Text;
                string ywy = YWY.Text;
                string lxr = LXR.Text;
                string lxfs = LXFS.Text;
                string qy = QY.Text;
                string jq = JQ.Text;
                string xdy = XDY.Text;
                string ys = YS.Text;
                string zcm = ZCM.Text;
                string zms = ZMS.Text;
                string jesl = JESL.Text;
                string htje = HTJE.Text;
                string sjje = SJJE.Text;
                string wsje = WSJE.Text;
                string azf = AZF.Text;
                string ywf = YWF.Text;
                string huok = HUOK.Text;
                string dj = DJ.Text;
                string hk = HK.Text;
                string bz = richTextBox1.Text;
                SqlConnection con = new SqlConnection(SQL);
                bool go = true;
                bool flag7 = this.YS.Text != "" && this.ZCM.Text != "" && this.ZMS.Text != "" && this.LXR.Text != "" && this.LXFS.Text != "";
                if(flag7)
                {
                    try
                    {
                        con.Open();
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            SqlCommand comm = new SqlCommand();
                            string nr = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                            string sl1 = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                            string dw = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                            string dj1 = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                            string ms = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                            string je = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                            string cpmc = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                            comm.CommandText = "INSERT INTO [dbo].[Order_b]([orderid],[contractid],[date],[service],[company],[project],[sub],[quantity],[unit],[price],[meters],[amount],[productname],[ident],[pmc],[dusting]) VALUES('" + ddbh + "', '" + htbh + "', '" + xdrq + "', '" + gdy + "', '" + gsm + "', '" + xmmc + "', '" + nr + "','" + sl1 + "','" + dw + "','" + dj1 + "','" + ms + "','" + je + "','" + cpmc + "','N','N','" + PF.Text + "')";
                            comm.Connection = con;
                            int count = comm.ExecuteNonQuery();
                            if (count < 1)
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
                        con.Close();
                    }

                    try
                    {
                        if (go == true)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "INSERT INTO [dbo].[Order_h] ([orderid],[contractid],[date],[service],[company],[project],[con_date],[seller],[person],[phone],[area],[delivery],[desgin],[color],[longmetre],[quantity],[tax],[htje],[sjje],[wsje],[azf],[ywf],[huokuan],[dj],[hk],[remarks],[examine],[qj]) VALUES ('" + ddbh + "','" + htbh + "','" + xdrq + "','" + gdy + "','" + gsm + "','" + xmmc + "','" + qdrq + "','" + ywy + "','" + lxr + "','" + lxfs + "','" + qy + "','" + jq + "','" + xdy + "','" + ys + "','" + zcm + "','" + zms + "','" + jesl + "','" + htje + "','" + sjje + "','" + wsje + "','" + azf + "','" + ywf + "','" + huok + "','" + dj + "','" + hk + "','" + bz + "','已审核','" + qj + "')";
                            cmd.Connection = con;
                            int count = cmd.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("保存成功");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("保存失败");
                            }
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
                else
                {
                    MessageBox.Show("联系人，联系方式，颜色，最长米或总米数没有输入，无法保存");
                }        
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            if(dataGridView1.CurrentCell.OwningColumn.Name == "单价")
            {
                if (dataGridView1.CurrentRow.Cells[1].Value == null)
                {
                    MessageBox.Show("数量先输一下");
                }
                else
                {
                    decimal aa = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value);
                    decimal bb = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value);
                    string cc = (aa * bb).ToString();
                    dataGridView1.CurrentRow.Cells[5].Value = cc;

                }

            }
            if (dataGridView1.CurrentCell.OwningColumn.Name == "金额")
            {
                if (dataGridView1.CurrentRow.Cells[1].Value == null)
                {
                    MessageBox.Show("数量先输一下");
                }
                else
                {
                    if(dataGridView1.CurrentRow.Cells[1].Value.ToString() == "0")
                    {
                        return;
                    }
                    else
                    {
                        decimal aa = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value);
                        decimal bb = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[5].Value);
                        string cc = (bb / aa).ToString("0.00");

                        dataGridView1.CurrentRow.Cells[3].Value = cc;
                    }
                }
            }
            if (dataGridView1.CurrentCell.OwningColumn.Name == "单位")
            {
                if (dataGridView1.CurrentRow.Cells[1].Value == null)
                {
                    MessageBox.Show("数量先输一下");
                }
                else
                {
                    if (dataGridView1.CurrentCell.Value.ToString() == "米")
                    {
                        dataGridView1.CurrentRow.Cells[4].Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    }
                    if (dataGridView1.CurrentCell.Value.ToString() == "平米")
                    {
                        dataGridView1.CurrentRow.Cells[4].Value = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    }
                    if (dataGridView1.CurrentCell.Value.ToString() == "个" || dataGridView1.CurrentCell.Value.ToString() == "批")
                    {
                        dataGridView1.CurrentRow.Cells[4].Value = "0";
                    }
                }
            }

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.F7)
            {
                if(dataGridView1.CurrentCell.OwningColumn.Name == "合同产品名称")
                {
                    FindProduct findProduct = new FindProduct();
                    findProduct.FPD_HTBH = HTBH.Text.Trim();
                    findProduct.ShowDialog();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.CurrentCell.OwningColumn.Name == "合同产品名称")
                {
                    dataGridView1.CurrentCell.Value = CPMC;
                }


            }

        }


        private void DJ_TextChanged(object sender, EventArgs e)
        {
            if(DJ.Text == "")
            {
                return;
            }
            else
            {
                decimal aa = Convert.ToDecimal(SJJE.Text.Trim());
                decimal bb = Convert.ToDecimal(DJ.Text.Trim());
                HUOK.Text = (aa - bb).ToString();
            }
        }

        private void JESL_TextChanged(object sender, EventArgs e)
        {
            if (HTJE.Text == "")
            {
                MessageBox.Show("请注意：合同金额是否为空");
            }
            else
            {
                if (SJJE.Text == "" || AZF.Text == "" || YWF.Text == "" || HK.Text == "")
                {
                    MessageBox.Show("请输入：安装费！业务费！回扣");
                    return;
                }
                else
                {

                    decimal ab = Convert.ToDecimal(JESL.Text.Trim());//税率
                    decimal aa = Convert.ToDecimal(SJJE.Text.Trim());//实际金额
                    decimal bb = Convert.ToDecimal(AZF.Text.Trim());//安装费
                    decimal cc = Convert.ToDecimal(YWF.Text.Trim());//业务费
                    decimal dd = Convert.ToDecimal(HK.Text.Trim());//回扣
                    if((1 + ab / 100) > 0) 
                    { 
                    WSJE.Text = ((aa - bb - cc - dd) / (1 + ab / 100)).ToString("0.00");
                    }
                    else
                    {
                        WSJE.Text = Convert.ToString(0.00);
                    }
                }
            }
        }

        private void dataGridView1_Validated(object sender, EventArgs e)
        {
            decimal sum = 0;
            decimal sum1 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["金额"].Value);
                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["米数"].Value);
            }

            SJJE.Text = sum.ToString("0.00");
            ZMS.Text = sum1.ToString("0.00");
        }

        private void OrderService_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}