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
    public partial class ProductionPlan : Form
    {
        public ProductionPlan()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string PDP_User { get; set; }
        public string PDP_Group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void ProductionPlan_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "SCPQD" + time;
            DJRQ.Text = DateTime.Now.ToString("yyyy-MM-dd");
            PQR.Text = PDP_User;
            toolStripStatusLabel3.Text = PDP_User;
            toolStripStatusLabel5.Text = PDP_Group;

        }

        private void HTBH_DoubleClick(object sender, EventArgs e)
        {
            PlanOrder planorder = new PlanOrder();
            planorder.Show(this);
            
        }


        private void PQSJBC_Click(object sender, EventArgs e)
        {
            if (WLZT.Text == "" || HTBH.Text == "" || CPMC.Text == "" || NR.Text == "")
            {
                MessageBox.Show("请选择物料状态！+ 合同编号不可为空");
            }
            else
            {
                string djbh = DJBH.Text.Trim();
                string djrq = DJRQ.Text.Trim();
                string pqr = PQR.Text.Trim();
                string htbh = HTBH.Text.Trim();
                string gdy = GDY.Text.Trim();
                string gsm = GSM.Text.Trim();
                string cpmc = CPMC.Text.Trim();
                string nr = NR.Text.Trim();
                string wlzt = WLZT.Text.Trim();
                string wlztbz = WLZTBZ.Text.Trim();
                string kssj = KSSJ.Text.Trim();
                string jssj = JSSJ.Text.Trim();

                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmmd = conn.CreateCommand();
                cmmd.CommandText = "select * from [dbo].[Plan] where contractid = '" + htbh + "' and  product = '" + cpmc + "' and nr = '" + nr + "'";
                SqlDataReader sdr = cmmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("产品已排", "警告");
                }
                else
                {
                    sdr.Close();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO [dbo].[Plan] ([orderid],[date],[planner],[contractid],[service],[company],[product],[nr],[wlzt],[wlztbz],[planstart],[planend]) VALUES ('" + djbh + "','" + djrq + "','" + pqr + "','" + htbh + "','" + gdy + "','" + gsm + "','" + cpmc + "','" + nr + "','" + wlzt + "','" + wlztbz + "','" + kssj + "','" + jssj + "')";
                    int cot = cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "UPDATE [dbo].[Order_b] SET pmc = 'Y' WHERE contractid = '" + htbh + "' and productname = '" + cpmc + "' and sub = '" + nr + "'";
                    int cot1 =cmd1.ExecuteNonQuery();

                    if (cot > 0 || cot1 > 0) 
                    {
                        conn.Close();
                        MessageBox.Show("保存成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
                    }
                }
                
            }

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


        private void ProductionPlan_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void HTBH_TextChanged(object sender, EventArgs e)
        {
            if(HTBH.Text.Trim() == "")
            {
                return;
            }
            else
            {
                string strsql = "select contractid,service from [dbo].[Order_h] where contractid = '" + HTBH.Text.Trim() + "'";
                SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GDY.Text = dt.Rows[0][1].ToString();

            }
        }

        private void WLZT_TextChanged(object sender, EventArgs e)
        {
            if(WLZT.Text == "物料正常")
            {
                WLZTBZ.ReadOnly = true;
                WLZTBC.Enabled = false;
            }
            if(WLZT.Text == "物料不全")
            {
                WLZTBZ.ReadOnly= false;
                WLZTBC.Enabled = true;
            }
        }

        private void WLZTBC_Click(object sender, EventArgs e)
        {
            if (WLZT.Text == "" || HTBH.Text == "" || CPMC.Text == "" || NR.Text == "") 
            {
                MessageBox.Show("请选择物料状态！+ 合同编号不可为空");
            }
            else
            {
                string djbh = DJBH.Text.Trim();
                string djrq = DJRQ.Text.Trim();
                string pqr = PQR.Text.Trim();
                string htbh = HTBH.Text.Trim();
                string gdy = GDY.Text.Trim();
                string gsm = GSM.Text.Trim();
                string cpmc = CPMC.Text.Trim();
                string nr = NR.Text.Trim();
                string wlzt = WLZT.Text.Trim();
                string wlztbz = WLZTBZ.Text.Trim();

                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmmd = conn.CreateCommand();
                cmmd.CommandText = "select * from [dbo].[Plan] where contractid = '" + htbh + "' and product = '" + cpmc + "' and nr = '" + nr + "'";
                SqlDataReader sdr = cmmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("产品已排", "警告");
                }
                else
                {
                    sdr.Close();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO [dbo].[Plan] ([orderid],[date],[planner],[contractid],[service],[company],[product],[nr],[wlzt],[wlztbz]) VALUES ('" + djbh + "','" + djrq + "','" + pqr + "','" + htbh + "','" + gdy + "','" + gsm + "','" + cpmc + "','" + nr + "','" + wlzt + "','" + wlztbz + "')";
                    int cot = cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "UPDATE [dbo].[Order_b] SET pmc = 'Y' WHERE productname = '" + cpmc + "' and sub = '" + nr + "'";
                    int cot1 = cmd1.ExecuteNonQuery();

                    if (cot > 0 || cot1 > 0) 
                    {
                        conn.Close();
                        MessageBox.Show("保存成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
                    }
                }
                
            }
        }
    }
}
