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
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.OrderReport
{
    public partial class OrderTrack : Form
    {
        public OrderTrack()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string OTK_User { get; set; }
        public string OTK_Group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void OrderTrack_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            toolStripStatusLabel2.Text = OTK_User;
            toolStripStatusLabel5.Text = OTK_Group;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string nettime = Winmain.GetNetDateTime();
            if (nettime != "")
            {
                DQSJ.Text = Convert.ToDateTime(nettime).ToString("G");
            }
            else
            {
                DQSJ.Text = DateTime.Now.ToString("G");
            }
        }

        private void OrderTrack_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string dj = "select contractid,company,productname,sub from Order_b where ident = 'N'";
            SqlDataAdapter djda = new SqlDataAdapter(dj, SQL);
            DataTable djdt = new DataTable();
            djda.Fill(djdt);

            if(djdt.Rows.Count > 0) 
            {
                try
                {
                    for (int i = 0; i < djdt.Rows.Count; i++) 
                    {
                        string htbh = djdt.Rows[i][0].ToString();
                        string khm = djdt.Rows[i][1].ToString();
                        string cpmc = djdt.Rows[i][2].ToString();
                        string nr = djdt.Rows[i][3].ToString();
                        string sjy = "未查询到设计部数据";
                        string kfy = "未查询到客服部数据";
                        string pcgq = "未查询到PMC数据";
                        string jjgzt = "未查询到PMC数据";
                        string ptzt = "未查询到PMC数据";
                        string rkzt = "未入库";
                        string ckzt = "未出库";

                        string sjb = "SELECT * FROM DesginBom where contractid = '" + htbh + "' ";
                        SqlDataAdapter sjbda = new SqlDataAdapter(sjb, SQL);
                        DataTable sjbdt = new DataTable();
                        sjbda.Fill(sjbdt);

                        if (sjbdt.Rows.Count > 0)
                        {
                            sjy = sjbdt.Rows[0][4].ToString();
                        }

                        string kfb = "SELECT * FROM Order_h where contractid = '" + htbh + "' ";
                        SqlDataAdapter kfbda = new SqlDataAdapter(kfb, SQL);
                        DataTable kfbdt = new DataTable();
                        kfbda.Fill(kfbdt);

                        if (kfbdt.Rows.Count > 0)
                        {
                            kfy = kfbdt.Rows[0][4].ToString();
                        }

                        string pmc = "SELECT * FROM [dbo].[Plan] where contractid = '" + htbh + "' and product = '" + cpmc + "' and nr = '" + nr + "'";
                        SqlDataAdapter pmcda = new SqlDataAdapter(pmc, SQL);
                        DataTable pmcdt = new DataTable();
                        pmcda.Fill(pmcdt);

                        if (pmcdt.Rows.Count > 0)
                        {
                            string kssj = pmcdt.Rows[0][11].ToString();
                            string jssj = pmcdt.Rows[0][12].ToString();
                            jjgzt = pmcdt.Rows[0][13].ToString();
                            ptzt = pmcdt.Rows[0][15].ToString();
                            pcgq = kssj + "-" + jssj;
                        }

                        string cprk = "SELECT * FROM [dbo].[ProductIn] where contractid = '" + htbh + "' and product = '" + cpmc + "' and substance = '" + nr + "'";
                        SqlDataAdapter cprkda = new SqlDataAdapter(cprk, SQL);
                        DataTable cprkdt = new DataTable();
                        cprkda.Fill(cprkdt);

                        if (cprkdt.Rows.Count > 0)
                        {
                            if (cprkdt.Rows[0][24].ToString() == "已审核")
                            {
                                rkzt = "已入库";
                            }

                        }

                        string cpck = "SELECT * FROM [dbo].[ProductOut] where contractid = '" + htbh + "' and product = '" + cpmc + "' and substance = '" + nr + "'";
                        SqlDataAdapter cpckda = new SqlDataAdapter(cpck, SQL);
                        DataTable cpckdt = new DataTable();
                        cpckda.Fill(cpckdt);

                        if (cpckdt.Rows.Count > 0)
                        {
                            if (cpckdt.Rows[0][24].ToString() == "已审核")
                            {
                                ckzt = "已出库";
                            }

                        }


                        ListViewItem item = new ListViewItem();
                        item.SubItems[0].Text = khm;
                        item.SubItems.Add(cpmc);
                        item.SubItems.Add(nr);
                        item.SubItems.Add(sjy);
                        item.SubItems.Add(kfy);
                        item.SubItems.Add(pcgq);
                        item.SubItems.Add(jjgzt);
                        item.SubItems.Add(ptzt);
                        item.SubItems.Add(rkzt);
                        item.SubItems.Add(ckzt);

                        listView1.Items.Add(item);
                    }
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
