using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using WindowsFormsApp1.Main;
using System.Data.OleDb;
using System.Security.Cryptography;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Desgin
{
    public partial class DesginRead : Form
    {
        public DesginRead()
        {
            InitializeComponent();
        }

        private static string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string DL { get; set; }

        DataTable dtzc = new DataTable();
        DataTable dtpj = new DataTable();
        SqlDataAdapter dazc ;
        SqlDataAdapter dapj ;

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void DesginRead_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 9);
            dataGridView1.DefaultCellStyle.Font = new Font("宋体", 9);
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 9);
            dataGridView2.DefaultCellStyle.Font = new Font("宋体", 9);

            string htbh = DL;

            string sql = String.Format("select * from [dbo].[Desgin_h]  where contractid like '%" + htbh + "%'");
            string sql1 = String.Format("select id,contractid as 合同编号,zcid as 主材编码,zcmc as 主材名称,zcgg as 主材规格,zclb as 主材类别,zccc as 主材尺寸,zczs as 主材支数   from [dbo].[Desgin_zc] where contractid like '%" + htbh + "%'");
            string sql2 = String.Format("select id,contractid as 合同编号,pjid as 配件编码,pjmc as 配件名称,pjgg as 配件规格,pjlb as 配件类别,dusting as 配件喷粉,pjsf as 配件实发   from [dbo].[Desgin_pj] where contractid like '%" + htbh + "%'");

            SqlDataAdapter da = new SqlDataAdapter(sql, SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);
            BH.Text = dt.Rows[0][1].ToString();
            HTBH.Text = dt.Rows[0][2].ToString();
            RQ.Text = dt.Rows[0][3].ToString();
            GSMC.Text = dt.Rows[0][4].ToString();
            XMMC.Text = dt.Rows[0][5].ToString();
            XDY.Text = dt.Rows[0][6].ToString();
            CP.Text = dt.Rows[0][7].ToString();
            CPYS.Text = dt.Rows[0][8].ToString();
            MS.Text = dt.Rows[0][9].ToString();
            SFYL.Text = dt.Rows[0][10].ToString();
            string bb = dt.Rows[0][11].ToString();

            if (bb == "已审核")
            {
                pictureBox1.Visible = true;
                XG.Enabled = false;
            }
            else
            {
                pictureBox1.Visible = false;
                XG.Enabled = true;

            }

            dazc = new SqlDataAdapter(sql1, SQL);
            dazc.Fill(dtzc);
            dataGridView1.DataSource = dtzc;
            dataGridView1.Columns["id"].Visible = false;


            dapj = new SqlDataAdapter(sql2, SQL);
            dapj.Fill(dtpj);
            dataGridView2.DataSource = dtpj;
            dataGridView2.Columns["id"].Visible = false;


        }

        private void XG_Click(object sender, EventArgs e)
        {
            string htbh = DL;
            string strsql = String.Format("select contractid,examine1 from [dbo].[Desgin_h]  where contractid like '%" + htbh + "%'");
            SqlDataAdapter sda = new SqlDataAdapter(strsql, SQL);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            if (dataTable.Rows[0][1].ToString() == "已审核")
            {
                MessageBox.Show("生产部已审核，无法更改");
            }
            else
            {
                dataGridView1.ReadOnly = false;
                dataGridView2.ReadOnly = false;
                XG.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder SCBzc = new SqlCommandBuilder(dazc);
                dazc.Update(dtzc);
                SqlCommandBuilder SCBpj = new SqlCommandBuilder(dapj);
                dapj.Update(dtpj);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            MessageBox.Show("更新成功!");
        }

        private void DesginRead_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}