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

namespace WindowsFormsApp1.MarketingDepartment
{
    public partial class SUpdateExpandPlan : Form
    {
        public SUpdateExpandPlan()
        {
            InitializeComponent();
        }
        DataTable dt;
        SqlDataAdapter da;
        public string Username { get; set; }
        public string Group { get; set; }
        public string id { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void SUpdateCBExpandPlan_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string sql = "select id,date as 时间 , region as 区域 ,province as 省份 ,market as 市 ,county as 区县 ,number as 人数 ,yuefen as 人员到位月份 ,target1 as 签单目标,target2 as 收货目标 ,remark as 备注 from SCBExpandPlan where id = '" + id + "'";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void SUpdateCBExpandPlan_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select id,date as 时间 , region as 区域 ,province as 省份 ,market as 市 ,county as 区县 ,number as 人数 ,yuefen as 人员到位月份 ,target1 as 签单目标,target2 as 收货目标 ,remark as 备注 from SCBExpandPlan where state = 1 ";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("保存失败");
                return;
            }
        }
    }
}
