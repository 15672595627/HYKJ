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

namespace WindowsFormsApp1.SalesDepartment
{
    public partial class WHQYUpdateReduceEmployee : Form
    {
        public WHQYUpdateReduceEmployee()
        {
            InitializeComponent();
        }
        public string id { get; set; }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        string rq;
        int Iid;
        int zt;
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void WHQYUpdateReduceEmployee_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void WHQYUpdateReduceEmployee_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select id,[position] as 岗位名称, [reason] as 原因, [numberPeople] as 计划入职人数, [date] as 月份 from [dbo].[SalesPersonnelDetails] where state = -1 and state2 = 1 and company = '武汉区域'";
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
