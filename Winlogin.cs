using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Data;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1
{
    public partial class Winlogin : Form
    {

        public Winlogin()
        {
            InitializeComponent();
            
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        
        private void Winlogin_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            toolStripStatusLabel1.Text = "版本：" + System.Windows.Forms.Application.ProductVersion.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ZH.Text == "" || MM.Text == "")
            {
                MessageBox.Show("用户名密码不能为空！");
            }
            else
            {
                string name = ZH.Text.Trim();
                string pwd = MM.Text.Trim();
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                try
                {
                    SqlCommand cmmd = conn.CreateCommand();//执行命令对象
                    cmmd.CommandText = "select COUNT(*) from dbo.[User] where name='" + name + "' and password = '" + pwd + "'";
                    int i = Convert.ToInt32(cmmd.ExecuteScalar());//调用查询单个值的方法
                    if (i > 0)
                    {
                        //实例化窗口对象
                        Winmain winmain = new Winmain();
                        this.Visible = false;
                        winmain.Username = ZH.Text.Trim();
                        winmain.ShowDialog();
                        this.Dispose();
                        this.Close();
                        ;//传递当前用户名
                         //显示对象窗口
                    }
                    else
                    {
                        MessageBox.Show("登录失败！");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();//关闭连接
                }
            }
        }

        private void GXRZ_Click(object sender, EventArgs e)
        {
            Updatelog updatelog = new Updatelog();
            updatelog.ShowDialog();
        }

        private void WTFK_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback();
            feedback.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Winlogin_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}