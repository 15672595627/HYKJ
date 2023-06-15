using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1.Platform
{
    public partial class OrderReceiving : Form
    {
        public OrderReceiving()
        {
            InitializeComponent();
        }

        public string ORI_User { get; set; }
        public string ORI_Group { get; set; }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void OrderReceiving_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = ORI_User;
            toolStripStatusLabel7.Text = ORI_Group;
            SSBM.Text = ORI_Group;
            YH.Text = ORI_User;
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

        private void HTBH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string htbh = HTBH.Text.Trim();
                string strsql = "select contractid,company,project from [dbo].[Contract_h] where contractid = '" + htbh + "'";
                SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GSM.Text = dt.Rows[0][1].ToString();
                    XMMC.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("查询不到该合同！");
                }
            }
         
        }
    }
}
