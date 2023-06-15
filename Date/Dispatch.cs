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

namespace WindowsFormsApp1.Date
{
    public partial class Dispatch : Form
    {
        public Dispatch()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void Dispatch_Load(object sender, EventArgs e)
        {
            JDRQ.Text = DateTime.Now.ToString("yyyy-MM-dd");
            string aa = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "LCPD" + aa;
            WCZT.BackColor = Color.Red;
            WCZT.Text = "未完成";
            WCZT.Font = new Font("楷体", 12);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WCZT.BackColor = Color.Lime;
            WCZT.Text = "已完成";
            WCZT.Font = new Font("楷体", 12);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WCZT.BackColor = Color.Red;
            WCZT.Text = "未完成";
            WCZT.Font = new Font("楷体", 12);
        }

        private void HTBH_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LCDD.Text == "" || LCRY.Text == "")
            {
                MessageBox.Show("请输入拉尺的地点和人员");
            }
            else
            {
                SqlConnection con = new SqlConnection(SQL);

                    string aa = DJBH.Text;
                    string bb = HTBH.Text;
                    string cc = JDRQ.Text;
                    string dd = KHM.Text;
                    string ee = LXFS.Text;
                    string ff = LCDD.Text;
                    string gg = LCRY.Text;
                    string hh = LCXM.Text;
                    string ii = APRQ.Text;
                    string jj = SJRQ.Text;
                    string kk = XDRQ.Text;
                    string ll = WCZT.Text;
                    string mm = BZ.Text;
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO [dbo].[Distribution] ([orderid],[contractid],[date],[customer],[phone],[place],[personnel],[project],[arrangedate],[actualdate],[orderdate],[state],[remarks],[examine]) VALUES ('" + aa + "','" + bb + "','" + cc + "','" + dd + "','" + ee + "','" + ff + "','" + gg + "','" + hh + "','" + ii + "','" + jj + "','" + kk + "','" + ll + "','" + mm + "','未审核')";
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
                    }
                try
                {
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
    }
}