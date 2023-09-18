using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.OrderReport
{
    // Token: 0x02000044 RID: 68
    public partial class Month : Form
    {
        // Token: 0x0600034B RID: 843 RVA: 0x00046423 File Offset: 0x00044623
        public Month()
        {
            this.InitializeComponent();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private AutoSizeFormClass asc = new AutoSizeFormClass();
       
        public string MH_User { get; set; }

        public string MH_Group { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
            this.toolStripStatusLabel2.Text = this.MH_User;
            this.toolStripStatusLabel5.Text = this.MH_Group;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string netDateTime = Winmain.GetNetDateTime();
            bool flag = netDateTime != "";
            if (flag)
            {
                this.DQSJ.Text = Convert.ToDateTime(netDateTime).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                this.DQSJ.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            string str = DateTime.Now.ToString("yyyy-MM");
            string selectCommandText = "select * from Contract_h where date like '%" + str + "%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, Month.SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string selectCommandText2 = "SELECT sum(amount) from ( select amount from Contract_h where date like '%" + str + "%' ) a";
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, Month.SQL);
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.SubItems[0].Text = "内勤";
            listViewItem.SubItems.Add(dataTable.Rows.Count.ToString());
            listViewItem.SubItems.Add(dataTable2.Rows[0][0].ToString() + "元");
            this.listView1.Items.Add(listViewItem);
            string selectCommandText3 = "select * from Order_h where date like '%" + str + "%'";
            SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText3, Month.SQL);
            DataTable dataTable3 = new DataTable();
            sqlDataAdapter3.Fill(dataTable3);
            string selectCommandText4 = "SELECT sum(meters) from ( select DISTINCT date,meters from Order_b where date like '%" + str + "%' ) a";
            SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommandText4, Month.SQL);
            DataTable dataTable4 = new DataTable();
            sqlDataAdapter4.Fill(dataTable4);
            ListViewItem listViewItem2 = new ListViewItem();
            listViewItem2.SubItems[0].Text = "客服";
            listViewItem2.SubItems.Add(dataTable3.Rows.Count.ToString());
            bool flag = dataTable4.Rows.Count > 0;
            if (flag)
            {
                listViewItem2.SubItems.Add(dataTable4.Rows[0][0].ToString() + "米");
            }
            bool flag2 = dataTable4.Rows.Count == 0;
            if (flag2)
            {
                listViewItem2.SubItems.Add("0米");
            }
            this.listView1.Items.Add(listViewItem2);
            string selectCommandText5 = "select * from DesginBom where date like '%" + str + "%'";
            SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommandText5, Month.SQL);
            DataTable dataTable5 = new DataTable();
            sqlDataAdapter5.Fill(dataTable5);
            string selectCommandText6 = "SELECT sum(meters) from ( select DISTINCT orderid,date,meters from DesginBom where date like '%" + str + "%' ) a";
            SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommandText6, Month.SQL);
            DataTable dataTable6 = new DataTable();
            sqlDataAdapter6.Fill(dataTable6);
            ListViewItem listViewItem3 = new ListViewItem();
            listViewItem3.SubItems[0].Text = "设计";
            listViewItem3.SubItems.Add(dataTable5.Rows.Count.ToString());
            listViewItem3.SubItems.Add(dataTable6.Rows[0][0].ToString() + "米");
            this.listView1.Items.Add(listViewItem3);

            string selectCommandText7 = "select * from [dbo].[Plan] where date like '%" + str + "%'";
            SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommandText7, Month.SQL);
            DataTable dataTable7 = new DataTable();
            sqlDataAdapter7.Fill(dataTable7);
            decimal d = 0m;
            bool flag3 = dataTable7.Rows.Count > 0;
            if (flag3)
            {
                for (int i = 0; i < dataTable7.Rows.Count; i++)
                {
                    string text = dataTable7.Rows[i][4].ToString();
                    string text2 = dataTable7.Rows[i][7].ToString();
                    string text3 = dataTable7.Rows[i][8].ToString();
                    string selectCommandText8 = string.Concat(new string[]
                    {
                        "select * from Order_b where contractid = '",
                        text,
                        "' and  productname = '",
                        text2,
                        "' and sub = '",
                        text3,
                        "'"
                    });
                    SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommandText8, Month.SQL);
                    DataTable dataTable8 = new DataTable();
                    sqlDataAdapter8.Fill(dataTable8);
                    bool flag4 = dataTable8.Rows.Count > 0;
                    if (flag4)
                    {
                        sqlDataAdapter8.Fill(dataTable8);
                        d += Convert.ToDecimal(dataTable8.Rows[0][11]);
                    }
                }
            }
            ListViewItem listViewItem4 = new ListViewItem();
            listViewItem4.SubItems[0].Text = "PMC";
            listViewItem4.SubItems.Add(dataTable7.Rows.Count.ToString());
            listViewItem4.SubItems.Add(d.ToString() + "米");
            this.listView1.Items.Add(listViewItem4);

            string selectCommandText9 = "select * from ProductIn where date like '%" + str + "%'";
            SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommandText9, Month.SQL);
            DataTable dataTable9 = new DataTable();
            sqlDataAdapter9.Fill(dataTable9);
            string selectCommandText10 = "select sum(meters) from ProductIn where date like '%" + str + "%'";
            SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommandText10, Month.SQL);
            DataTable dataTable10 = new DataTable();
            sqlDataAdapter10.Fill(dataTable10);
            ListViewItem listViewItem5 = new ListViewItem();
            listViewItem5.SubItems[0].Text = "发货员（产成品入库）";
            listViewItem5.SubItems.Add(dataTable9.Rows.Count.ToString());
            bool flag5 = dataTable10.Rows.Count > 0;
            if (flag5)
            {
                listViewItem5.SubItems.Add(dataTable10.Rows[0][0].ToString() + "米");
            }
            bool flag6 = dataTable10.Rows.Count == 0;
            if (flag6)
            {
                listViewItem5.SubItems.Add("0米");
            }
            this.listView1.Items.Add(listViewItem5);
            string selectCommandText11 = "select * from ProductOut where date like '%" + str + "%'";
            SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommandText11, Month.SQL);
            DataTable dataTable11 = new DataTable();
            sqlDataAdapter11.Fill(dataTable11);
            string selectCommandText12 = "select sum(meters) from ProductOut where date like '%" + str + "%'";
            SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommandText12, Month.SQL);
            DataTable dataTable12 = new DataTable();
            sqlDataAdapter12.Fill(dataTable12);
            ListViewItem listViewItem6 = new ListViewItem();
            listViewItem6.SubItems[0].Text = "发货员（产成品出库）";
            listViewItem6.SubItems.Add(dataTable11.Rows.Count.ToString());
            bool flag7 = dataTable12.Rows.Count > 0;
            if (flag7)
            {
                listViewItem6.SubItems.Add(dataTable12.Rows[0][0].ToString() + "米");
            }
            bool flag8 = dataTable12.Rows.Count == 0;
            if (flag8)
            {
                listViewItem6.SubItems.Add("0米");
            }
            this.listView1.Items.Add(listViewItem6);
        }
    }
}
