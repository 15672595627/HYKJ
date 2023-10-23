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

namespace WindowsFormsApp1.PurchasingDepartment
{
    public partial class PUpdateAddEmployee : Form
    {
        public PUpdateAddEmployee()
        {
            InitializeComponent();
        }
        int Iid;
        int zt;
        string rq;
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public string Username { get; set; }
        public string Group { get; set; }
        public string id { get; set; }
        private void PUpdateAddEmployee_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string sql = "select id,[position] as 岗位名称, [reason] as 原因, [numberPeople] as 计划入职人数, [date] as 月份 from [dbo].[CGBPersonnelDetails] where id = '" + id + "'";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void PUpdateAddEmployee_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select id,[position] as 岗位名称, [reason] as 原因, [numberPeople] as 计划入职人数, [date] as 月份 from [dbo].[CGBPersonnelDetails] where state2 = 1 and state = 1";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
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
