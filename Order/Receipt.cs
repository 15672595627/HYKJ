using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Policy;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Order
{
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string Rec_user { get; set; }
        public string Rec_group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void Receipt_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "SKD" + time;
            DJRQ.Text = DateTime.Now.ToString("d");
            toolStripStatusLabel2.Text = Rec_user;
            toolStripStatusLabel5.Text = Rec_group;
        }

        private void HTBH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            R_Order r_Order = new R_Order();
            r_Order.Show(this);
        }

        private void HTBH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(HTBH.Text == "")
                {
                    MessageBox.Show("请输入单号");

                }
                else
                {
                    string strsql = "select contractid,company,project,sub,seller from [dbo].[Contract_h] where contractid = '" + HTBH.Text.Trim() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GSM.Text = dt.Rows[0][1].ToString();
                    XMMC.Text = dt.Rows[0][2].ToString();
                    QY.Text = dt.Rows[0][3].ToString();
                    YWY.Text = dt.Rows[0][4].ToString();
                }
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                return;
            }
            else
            {
                if (comboBox1.Text == "私户")
                {
                    comboBox2.Items.Clear();
                    comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox2.Items.AddRange(new object[] {
                        "建行",
                        "农行",
                        "工行",
                        "储蓄银行",
                        "湖北银行",
                        "微信",
                        "支付宝"});
                }
                if (comboBox1.Text == "公户")
                {
                    comboBox2.Items.Clear();
                    comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox2.Items.AddRange(new object[] {
                        "荆州华禹建行龙山寺支行",
                        "荆州华禹工行四机支行",
                        "武汉华禹鑫盛工行东西湖支行",
                        "武汉华禹鑫盛建行",
                        "华禹机电经营部建行龙山寺支行",
                        "佳兴机电设备经营部建行龙山寺支行",
                        "创鑫机电设备建行龙山寺支行",
                        "荆州华禹湖北银行荆城支行",
                        "芜湖华禹恒建行公户",
                        "佛山市华禹劳务服务有限公司",
                        "武汉鑫盛上海银行",
                        "武汉鑫盛招商银行深圳分行",
                        "荆州华禹邮储银行",
                                            });
                }
                if (comboBox1.Text == "其他")
                {
                    comboBox2.Items.Clear();
                    comboBox2.DropDownStyle = ComboBoxStyle.DropDown;

                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(GSM.Text == ""||XMMC.Text == ""||YWY.Text == ""||QY.Text == ""||SKJE.Text == ""||comboBox1.Text == ""|| comboBox2.Text == "")
            {
                MessageBox.Show("请输入完整信息！");
            }
            else
            {
                string djbh = DJBH.Text.Trim();
                string djrq = DJRQ.Text.Trim();
                string htbh = HTBH.Text.Trim();
                string gsm = GSM.Text.Trim();
                string xmmc = XMMC.Text.Trim();
                string yh = comboBox1.Text.Trim() + comboBox2.Text.Trim();
                string skje = SKJE.Text.Trim();
                string ywy = YWY.Text.Trim();
                string qy = QY.Text.Trim();
                string gdw = Rec_user;
                string bz = BZ.Text.Trim();
                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Insert INTO [dbo].[Receipt] ([orderid],[contractid],[date],[company],[project],[bank],[skje],[seller],[area],[service],[remake],[examine]) VALUES ('" + djbh + "','" + htbh + "','" + djrq + "','" + gsm + "','" + xmmc + "','" + yh + "','" + skje + "','" + ywy + "','" + qy + "','" + gdw + "','" + bz + "','未审核')";
                int cot = cmd.ExecuteNonQuery();
                if (cot > 0)
                {
                    MessageBox.Show("保存成功,请联系相关人员进行审核！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
        }

        private void GSM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Findkh findkh = new Findkh();
            findkh.Show(this);
        }

        private void YWY_TextChanged(object sender, EventArgs e)
        {
            if (YWY.Text == "")
            {
                return;
            }
            else
            {
                string ywy = YWY.Text.Trim();
                string strsql = "select seller,company from [dbo].[Seller] where seller = '" + ywy + "'";
                SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                DataTable dt = new DataTable();
                da.Fill(dt);
                QY.Text = dt.Rows[0][1].ToString();
            }
        }

        private void Receipt_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
