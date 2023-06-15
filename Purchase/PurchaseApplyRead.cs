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
    public partial class PurchaseApplyRead : Form
    {
        public PurchaseApplyRead()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public static string SAR { get; set; }

        private void PurchaseApplyRead_Load(object sender, EventArgs e)
        {
            HTBH.Text = SAR.ToString().Trim();
            SqlConnection con = new SqlConnection(SQL);
            try
            {
                con.Open();
                string strsql = "select * from [dbo].[ShortAge_h] where contractid = '" + HTBH.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                DDBH.Text = dataSet.Tables[0].Rows[0][1].ToString();
                RQ.Text = dataSet.Tables[0].Rows[0][3].ToString();
                KHM.Text = dataSet.Tables[0].Rows[0][4].ToString();
                GYS.Text = dataSet.Tables[0].Rows[0][5].ToString();
                CP.Text = dataSet.Tables[0].Rows[0][6].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"操作有误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            try
            {
                con.Open();
                string strsql1 = "select orderid as 订单编号,contractid as 合同编号,date as 日期,zcid as 物料编码,zcmc as 物料名称,zcgg as 物料规格,wlzt as 物料状态,cgsl as 采购数量 from [dbo].[ShortAge_zc] where contractid = '" + HTBH.Text + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(strsql1, SQL);
                DataSet dataSet1 = new DataSet();
                da1.Fill(dataSet1);
                dataGridView1.DataSource = dataSet1.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            try
            {
                con.Open();
                string strsql2 = "select orderid as 订单编号,contractid as 合同编号,date as 日期,pjid as 物料编码,pjmc as 物料名称,pjgg as 物料规格,wlzt as 物料状态,cgsl as 采购数量 from [dbo].[ShortAge_pj] where contractid = '" + HTBH.Text + "'";
                SqlDataAdapter da2 = new SqlDataAdapter(strsql2, SQL);
                DataSet dataSet2 = new DataSet();
                da2.Fill(dataSet2);
                dataGridView2.DataSource = dataSet2.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }


        }
    }
}
