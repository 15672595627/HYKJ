using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class ContractAlert : Form
    {
        public ContractAlert()
        {
            InitializeComponent();
        }


        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        

        /*[DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private static int AW_HIDE = 0x00010000;//该变量表示动画隐藏窗体
        private static int AW_SLIDE = 0x00040000;//该变量表示出现滑行效果的窗体
        private static int AW_VER_NEGATIVE = 0x00000008;//该变量表示从下向上开屏
        private static int AW_VER_POSITIVE = 0x00000004;//该变量表示从上向下开屏
        private const int AW_ACTIVE = 0x20000;//激活窗口
        private const int AW_BLEND = 0x80000;//应用淡入淡出结果
        
        */
        private void ContractAlert_Load(object sender, EventArgs e)
        {
            /*int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            AnimateWindow(this.Handle, 1000, AW_ACTIVE | AW_BLEND);
            */

            /*DateTime sqltime = DateTime.Now.AddMonths(-1);
            string sqldate = (sqltime).ToString("d").Trim();
            DateTime detime = DateTime.Now.AddDays(3);
            string dedate = (detime).ToString("d").Trim();
            string strsql = "select contractid as 合同编号,date as 日期,company as 公司,contact as 联系人,customercategory as 客户类型,Delivery as 交期,seller as 业务员,amount as 金额 from (select * from [dbo].[Contract_h] where date > '" + sqldate + "') a  where delivery < '" + dedate + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            dataGridView1.DataSource = ds.Tables[0];
            */
            /*string a = ds.Tables[0].Rows[0][2].ToString();
            string b = ds.Tables[0].Rows[0][4].ToString();
            DateTime c = Convert.ToDateTime(ds.Tables[0].Rows[0][10]);
            DateTime d = DateTime.Now;
            TimeSpan timeSpan = c - d;
            int aa = timeSpan.Days + 1;
            richTextBox1.Text = "合同编号：" + a + "  " + "客户公司：" + b;
            label2.BackColor = Color.Red;
            label2.Text = "交期还剩：" + aa + "天";
            */




        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
            this.Close();
           
        }
    }
}
