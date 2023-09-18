using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1.OrderReport
{
    public partial class Daily : Form
    {
        public Daily()
        {
            this.InitializeComponent();
        }
        public string DY_User { get; set; }

        public string DY_Group { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
            this.toolStripStatusLabel2.Text = this.DY_User;
            this.toolStripStatusLabel5.Text = this.DY_Group;
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

        // Token: 0x0600035E RID: 862 RVA: 0x0004745C File Offset: 0x0004565C
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            string str = DateTime.Now.ToString("yyyy-MM-dd");
            string selectCommandText = "select * from Contract_h where date = '" + str + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, Daily.SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string selectCommandText2 = "select date,sum(amount) from Contract_h where date = '" + str + "' GROUP BY date";
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, Daily.SQL);
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.SubItems[0].Text = "内勤";
            listViewItem.SubItems.Add(dataTable.Rows.Count.ToString());

            bool flag = dataTable2.Rows.Count > 0;
            if (flag)
            {
                listViewItem.SubItems.Add(dataTable2.Rows[0][1].ToString() + "元");
            }
            bool flag2 = dataTable2.Rows.Count == 0;
            if (flag2)
            {
                listViewItem.SubItems.Add("0元");
            }
            listView1.Items.Add(listViewItem);
            string selectCommandText3 = "select * from Order_h where date = '" + str + "'";
            SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText3, Daily.SQL);
            DataTable dataTable3 = new DataTable();
            sqlDataAdapter3.Fill(dataTable3);
            string selectCommandText4 = "select date,sum(meters) from Order_b where date = '" + str + "' GROUP BY date";
            SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommandText4, Daily.SQL);
            DataTable dataTable4 = new DataTable();
            sqlDataAdapter4.Fill(dataTable4);
            ListViewItem listViewItem2 = new ListViewItem();
            listViewItem2.SubItems[0].Text = "客服";
            listViewItem2.SubItems.Add(dataTable3.Rows.Count.ToString());

            bool flag3 = dataTable4.Rows.Count > 0;
            if (flag3)
            {
                listViewItem2.SubItems.Add(dataTable4.Rows[0][1].ToString() + "米");
            }
            bool flag4 = dataTable4.Rows.Count == 0;
            if (flag4)
            {
                listViewItem2.SubItems.Add("0米");
            }
            this.listView1.Items.Add(listViewItem2);
            string selectCommandText5 = "select * from DesginBom where date = '" + str + "'";
            SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommandText5, Daily.SQL);
            DataTable dataTable5 = new DataTable();
            sqlDataAdapter5.Fill(dataTable5);
            string selectCommandText6 = "SELECT sum(meters) from ( select DISTINCT orderid,date,meters from DesginBom where date like '%" + str + "%' ) a";
            SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommandText6, Daily.SQL);
            DataTable dataTable6 = new DataTable();
            sqlDataAdapter6.Fill(dataTable6);
            ListViewItem listViewItem3 = new ListViewItem();
            listViewItem3.SubItems[0].Text = "设计";
            listViewItem3.SubItems.Add(dataTable5.Rows.Count.ToString());
            listViewItem3.SubItems.Add(dataTable6.Rows[0][0].ToString() + "米");
            listView1.Items.Add(listViewItem3);

            string aa = DateTime.Now.ToString("yyyy-MM-dd");
            string selectCommandText7 = "select * from [dbo].[Plan] where date = '" + aa + "'";
            SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommandText7, Daily.SQL);
            DataTable dataTable7 = new DataTable();
            sqlDataAdapter7.Fill(dataTable7);
            decimal d = 0m;
            bool flag5 = dataTable7.Rows.Count > 0;
            if (flag5)
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
                    SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommandText8, Daily.SQL);
                    DataTable dataTable8 = new DataTable();
                    sqlDataAdapter8.Fill(dataTable8);
                    bool flag7 = dataTable8.Rows.Count > 0;
                    if (flag7)
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


            string selectCommandText9 = "select * from ProductIn where date = '" + str + "'";
            SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommandText9, Daily.SQL);
            DataTable dataTable9 = new DataTable();
            sqlDataAdapter9.Fill(dataTable9);
            string selectCommandText10 = "select sum(meters) from ProductIn where date = '" + str + "'";
            SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommandText10, Daily.SQL);
            DataTable dataTable10 = new DataTable();
            sqlDataAdapter10.Fill(dataTable10);
            ListViewItem listViewItem5 = new ListViewItem();
            listViewItem5.SubItems[0].Text = "发货员（产成品入库）";
            listViewItem5.SubItems.Add(dataTable9.Rows.Count.ToString());
            bool flag9 = dataTable10.Rows.Count > 0;
            if (flag9)
            {
                listViewItem5.SubItems.Add(dataTable10.Rows[0][0].ToString() + "米");
            }
            else
            {
                listViewItem5.SubItems.Add("0米");
            }
            this.listView1.Items.Add(listViewItem5);
            string selectCommandText11 = "select * from ProductOut where date = '" + str + "'";
            SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommandText11, Daily.SQL);
            DataTable dataTable11 = new DataTable();
            sqlDataAdapter11.Fill(dataTable11);
            string selectCommandText12 = "select sum(meters) from ProductOut where date = '" + str + "'";
            SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommandText12, Daily.SQL);
            DataTable dataTable12 = new DataTable();
            sqlDataAdapter12.Fill(dataTable12);
            ListViewItem listViewItem6 = new ListViewItem();
            listViewItem6.SubItems[0].Text = "发货员（产成品出库）";
            listViewItem6.SubItems.Add(dataTable11.Rows.Count.ToString());
            bool flag10 = dataTable12.Rows.Count > 0;
            if (flag10)
            {
                listViewItem6.SubItems.Add(dataTable12.Rows[0][0].ToString() + "米");
            }
            else
            {
                listViewItem6.SubItems.Add("0米");
            }
            this.listView1.Items.Add(listViewItem6);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private AutoSizeFormClass asc = new AutoSizeFormClass();
    }
}
