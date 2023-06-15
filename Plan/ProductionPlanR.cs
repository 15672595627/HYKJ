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
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Plan
{
    public partial class ProductionPlanR : Form
    {
        public ProductionPlanR()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        public string PPR_DJBH { get; set; }

        public string PPR_User { get; set; }
        public string PPR_Group { get; set; }

        private void ProductionPlanR_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

            toolStripStatusLabel3.Text = PPR_User;
            toolStripStatusLabel5.Text = PPR_Group;
            DJBH.Text = PPR_DJBH;
            string strsql = "select * from [dbo].[Plan] where orderid = '" + PPR_DJBH + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DJRQ.Text = dt.Rows[0][2].ToString();
            PQR.Text = dt.Rows[0][3].ToString();
            HTBH.Text = dt.Rows[0][4].ToString();
            GDY.Text = dt.Rows[0][5].ToString();
            GSM.Text = dt.Rows[0][6].ToString();
            CPMC.Text = dt.Rows[0][7].ToString();
            NR.Text = dt.Rows[0][8].ToString();

            WLZT.Text = dt.Rows[0][9].ToString();
            WLZTBZ.Text = dt.Rows[0][10].ToString();

            KSSJ.Value = Convert.ToDateTime(dt.Rows[0][11]);
            JSSJ.Value = Convert.ToDateTime(dt.Rows[0][12]);

            JGZT.Text = dt.Rows[0][13].ToString();
            JJGZTYY.Text = dt.Rows[0][14].ToString();
            PTZT.Text = dt.Rows[0][15].ToString();
            PTZTYY.Text = dt.Rows[0][16].ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string nettime = Winmain.GetNetDateTime();
            if (nettime != "")
            {
                toolStripStatusLabel1.Text = Convert.ToDateTime(nettime).ToString("G");
            }
            else
            {
                toolStripStatusLabel1.Text = DateTime.Now.ToString("G");
            }
        }


        private void ProductionPlanR_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void JJGGX_Click(object sender, EventArgs e)
        {
            string djbh = DJBH.Text.Trim();
            JJGZTYY.ReadOnly= true;
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[Plan] SET jjgzt='" + JGZT.Text + "',jjgztzt = '" + JJGZTYY.Text + "' WHERE orderid = '" + djbh + "'";
            int cot = cmd.ExecuteNonQuery();
            if (cot > 0)
            {
                con.Close();
                MessageBox.Show("更新成功");
                this.Close();
            }
            else
            {
                con.Close();
                MessageBox.Show("更新失败");
            }
        }

        private void PTGX_Click(object sender, EventArgs e)
        {
            string djbh = DJBH.Text.Trim();
            PTZTYY.ReadOnly= true;
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[Plan] SET ptzt='" + PTZT.Text + "',ptztzt = '" + PTZTYY.Text + "' WHERE orderid = '" + djbh + "'";
            int cot = cmd.ExecuteNonQuery();
            if (cot > 0)
            {
                con.Close();
                MessageBox.Show("更新成功");
                this.Close();
            }
            else
            {
                con.Close();
                MessageBox.Show("更新失败");
            }
        }

        private void PQSJGX_Click(object sender, EventArgs e)
        {
            string djbh = DJBH.Text.Trim();
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[Plan] SET planstart='" + KSSJ.Text + "',planend = '" + JSSJ.Text + "' WHERE orderid = '" + djbh + "'";
            int cot = cmd.ExecuteNonQuery();
            if (cot > 0)
            {
                con.Close();
                MessageBox.Show("更新成功");
                this.Close();
            }
            else
            {
                con.Close();
                MessageBox.Show("更新失败");
            }
        }

        private void WLZTGX_Click(object sender, EventArgs e)
        {
            string djbh = DJBH.Text.Trim();
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [dbo].[Plan] SET wlzt='" + WLZT.Text + "',wlztbz = '" + WLZTBZ.Text + "' WHERE orderid = '" + djbh + "'";
            int cot = cmd.ExecuteNonQuery();
            if (cot > 0)
            {
                con.Close();
                MessageBox.Show("更新成功");
                this.Close();
            }
            else
            {
                con.Close();
                MessageBox.Show("更新失败");
            }
        }

        private void JJGJD_Click(object sender, EventArgs e)
        {
            JGZT.Text = "已接单" + "+" + DateTime.Now.ToString();
            JGZT.BackColor = Color.Yellow;
        }

        private void JJGJG_Click(object sender, EventArgs e)
        {
            JGZT.Text = "加工中" + "+" + DateTime.Now.ToString(); ;
            JGZT.BackColor = Color.Green;
        }

        private void JJGWC_Click(object sender, EventArgs e)
        {
            JGZT.Text = "已完成" + "+" + DateTime.Now.ToString(); ;
            JGZT.BackColor = Color.Lime;
        }

        private void JJGZTZT_Click(object sender, EventArgs e)
        {
            JGZT.Text = "因故暂停" + "+" + DateTime.Now.ToString(); ;
            JGZT.BackColor = Color.Red;
            JJGZTYY.ReadOnly = false;
        }

        private void PTJD_Click(object sender, EventArgs e)
        {
            PTZT.Text = "已接单" + "+" + DateTime.Now.ToString(); ;
            PTZT.BackColor = Color.Yellow;
        }

        private void PTJG_Click(object sender, EventArgs e)
        {
            PTZT.Text = "加工中" + "+" + DateTime.Now.ToString(); ;
            PTZT.BackColor = Color.Green;
        }

        private void PTWC_Click(object sender, EventArgs e)
        {
            PTZT.Text = "已完成" + "+" + DateTime.Now.ToString(); ;
            PTZT.BackColor = Color.Lime;
        }

        private void PTZTZT_Click(object sender, EventArgs e)
        {
            PTZT.Text = "因故暂停" + "+" + DateTime.Now.ToString(); ;
            PTZT.BackColor = Color.Red;
            PTZTYY.ReadOnly = false;
        }
    }
}
