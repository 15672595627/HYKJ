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
    public partial class Month : Form
    {
        public Month()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string MH_User { get; set; }
        public string MH_Group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            toolStripStatusLabel2.Text = MH_User;
            toolStripStatusLabel5.Text = MH_Group;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string nettime = Winmain.GetNetDateTime();
            if (nettime != "")
            {
                DQSJ.Text = Convert.ToDateTime(nettime).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                DQSJ.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string sj = DateTime.Now.ToString("yyyy-MM");
            string nqts = "select * from Contract_h where date like '%" + sj + "%'";
            SqlDataAdapter danqts = new SqlDataAdapter(nqts, SQL);
            DataTable dtnqts = new DataTable();
            danqts.Fill(dtnqts);


            string nqje = "SELECT sum(amount) from ( select amount from Contract_h where date like '%" + sj + "%' ) a";
            SqlDataAdapter danqje = new SqlDataAdapter(nqje, SQL);
            DataTable dtnqje = new DataTable();
            danqje.Fill(dtnqje);



            ListViewItem item = new ListViewItem();
            item.SubItems[0].Text = "内勤";
            item.SubItems.Add(dtnqts.Rows.Count.ToString());
            item.SubItems.Add(dtnqje.Rows[0][0].ToString() + "元");


            listView1.Items.Add(item);


            string kfts = "select * from Order_h where date like '%" + sj + "%'";
            SqlDataAdapter dakfts = new SqlDataAdapter(kfts, SQL);
            DataTable dtkfts = new DataTable();
            dakfts.Fill(dtkfts);

            string kfms = "SELECT sum(meters) from ( select DISTINCT date,meters from Order_b where date like '%" + sj + "%' ) a";
            SqlDataAdapter dakfms = new SqlDataAdapter(kfms, SQL);
            DataTable dtkfms = new DataTable();
            dakfms.Fill(dtkfms);

            ListViewItem item1 = new ListViewItem();
            item1.SubItems[0].Text = "客服";
            item1.SubItems.Add(dtkfts.Rows.Count.ToString());
            if(dtkfms.Rows.Count > 0)
                item1.SubItems.Add(dtkfms.Rows[0][0].ToString() + "米");
            if (dtkfms.Rows.Count == 0)
                item1.SubItems.Add("0" + "米");
            listView1.Items.Add(item1);

            string sjts = "select * from DesginBom where date like '%" + sj + "%'";
            SqlDataAdapter dasjts = new SqlDataAdapter(sjts, SQL);
            DataTable dtsjts = new DataTable();
            dasjts.Fill(dtsjts);

            string sjms = "SELECT sum(meters) from ( select DISTINCT orderid,date,meters from DesginBom where date like '%" + sj + "%' ) a";
            SqlDataAdapter dasjms = new SqlDataAdapter(sjms, SQL);
            DataTable dtsjms = new DataTable();
            dasjms.Fill(dtsjms);

            ListViewItem item2 = new ListViewItem();
            item2.SubItems[0].Text = "设计";
            item2.SubItems.Add(dtsjts.Rows.Count.ToString());
            item2.SubItems.Add(dtsjms.Rows[0][0].ToString() + "米");
            listView1.Items.Add(item2);

            string pmcts = "select * from [dbo].[Plan] where date like '%" + sj + "%'";
            SqlDataAdapter dapmcts = new SqlDataAdapter(pmcts, SQL);
            DataTable dtpmcts = new DataTable();
            dapmcts.Fill(dtpmcts);

            decimal pmcms = 0;
            if (dtpmcts.Rows.Count > 0)
            {
                for (int i = 0; i < dtpmcts.Rows.Count; i++)
                {
                    string htbh = dtpmcts.Rows[i][4].ToString();
                    string cpmc = dtpmcts.Rows[i][7].ToString();
                    string nr = dtpmcts.Rows[i][8].ToString();
                    string strsql = "select * from Order_b where contractid = '" + htbh + "' and  productname = '" + cpmc + "' and sub = '" + nr + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        da.Fill(dt);

                        pmcms += Convert.ToDecimal(dt.Rows[0][11]);
                    }
                }
            }
        

            ListViewItem item3 = new ListViewItem();
            item3.SubItems[0].Text = "PMC";
            item3.SubItems.Add(dtpmcts.Rows.Count.ToString());
            item3.SubItems.Add(pmcms + "米");
            listView1.Items.Add(item3);


            string cprkts = "select * from ProductIn where date like '%" + sj + "%'";
            SqlDataAdapter dacprkts = new SqlDataAdapter(cprkts, SQL);
            DataTable dtcprkts = new DataTable();
            dacprkts.Fill(dtcprkts);

            string cprkms = "select sum(meters) from ProductIn where date like '%" + sj + "%'";
            SqlDataAdapter dacprkms = new SqlDataAdapter(cprkms, SQL);
            DataTable dtcprkms = new DataTable();
            dacprkms.Fill(dtcprkms);

            ListViewItem item4 = new ListViewItem();
            item4.SubItems[0].Text = "发货员（产成品入库）";
            item4.SubItems.Add(dtcprkts.Rows.Count.ToString());
            if(dtcprkms.Rows.Count > 0)
                item4.SubItems.Add(dtcprkms.Rows[0][0].ToString() + "米");
            if(dtcprkms.Rows.Count == 0)
                item4.SubItems.Add("0" + "米");
            listView1.Items.Add(item4);


            string cpckts = "select * from ProductOut where date like '%" + sj + "%'";
            SqlDataAdapter dacpckts = new SqlDataAdapter(cpckts, SQL);
            DataTable dtcpckts = new DataTable();
            dacpckts.Fill(dtcpckts);

            string cpckms = "select sum(meters) from ProductOut where date like '%" + sj + "%'";
            SqlDataAdapter dacpckms = new SqlDataAdapter(cpckms, SQL);
            DataTable dtcpckms = new DataTable();
            dacpckms.Fill(dtcpckms);

            ListViewItem item5 = new ListViewItem();
            item5.SubItems[0].Text = "发货员（产成品出库）";
            item5.SubItems.Add(dtcpckts.Rows.Count.ToString());
            if(dtcpckms.Rows.Count > 0)
                item5.SubItems.Add(dtcpckms.Rows[0][0].ToString() + "米");
            if (dtcpckms.Rows.Count == 0)
                item5.SubItems.Add("0" + "米");
            listView1.Items.Add(item5);

           
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

    }
}
