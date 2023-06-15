using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Desgin;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Purchase
{
    public partial class ShortAgeApplyRead : Form
    {
        public ShortAgeApplyRead()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public static string SAR { get; set; }

        private void ShortAgeRead_Load(object sender, EventArgs e)
        {
            HTBH.Text = SAR.ToString().Trim();
            try
            {
                string strsql = "select * from [dbo].[ShortAge_h] where contractid = '" + HTBH.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DDBH.Text = ds.Tables[0].Rows[0][1].ToString();
                RQ.Text = ds.Tables[0].Rows[0][3].ToString();
                KHM.Text = ds.Tables[0].Rows[0][4].ToString();
                GYS.Text = ds.Tables[0].Rows[0][5].ToString();
                CP.Text = ds.Tables[0].Rows[0][6].ToString();
                string aa = ds.Tables[0].Rows[0][7].ToString().Trim();
                if(aa == "已审核")
                {
                    pictureBox1.Visible = true;
                    dataGridView1.ReadOnly = true;
                    dataGridView2.ReadOnly = true;
                }
                else
                {
                    pictureBox1.Visible = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"操作有误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            try
            {
                string strsql1 = "select orderid as 订单编号,contractid as 合同编号,date as 日期,zcid as 物料编码,zcmc as 物料名称,zcgg as 物料规格,dw as 单位,wlzt as 物料状态,cgsl as 采购数量 from [dbo].[ShortAge_zc] where contractid = '" + HTBH.Text + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(strsql1, SQL);
                DataSet dataSet1 = new DataSet();
                da1.Fill(dataSet1);
                dataGridView1.DataSource = dataSet1.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            { 
                string strsql2 = "select orderid as 订单编号,contractid as 合同编号,date as 日期,pjid as 物料编码,pjmc as 物料名称,pjgg as 物料规格,dw as 单位,wlzt as 物料状态,cgsl as 采购数量 from [dbo].[ShortAge_pj] where contractid = '" + HTBH.Text + "'";
                SqlDataAdapter da2 = new SqlDataAdapter(strsql2, SQL);
                DataSet dataSet2 = new DataSet();
                da2.Fill(dataSet2);
                dataGridView2.DataSource = dataSet2.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
