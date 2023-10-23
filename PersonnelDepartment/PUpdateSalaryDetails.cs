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

namespace WindowsFormsApp1.PersonnelDepartment
{
    public partial class PUpdateSalaryDetails : Form
    {
        public PUpdateSalaryDetails()
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

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select [id], [DepartMent] as 部门, [Number] as 总人数, [Amount] as 总金额, [January] as 一月, [February] as 二月, [March] as 三月, [April] as 四月, [May] as 五月, [June] as 六月, [July] as 七月, [August] as 八月, [September] as 九月, [October] as 十月, [November] as 十一月, [December] as 十二月,[date] as 日期,[state] as 状态 from RSBSalaryDetails where state= 1";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["状态"].Visible = false;
        }

        private void PUpdateSalaryDetails_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string sql = "select [id], [DepartMent] as 部门, [Number] as 总人数, [Amount] as 总金额, [January] as 一月, [February] as 二月, [March] as 三月, [April] as 四月, [May] as 五月, [June] as 六月, [July] as 七月, [August] as 八月, [September] as 九月, [October] as 十月, [November] as 十一月, [December] as 十二月,[date] as 日期,[state] as 状态 from RSBSalaryDetails where id = '" + id + "'";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["状态"].Visible = false;
        }

        private void PUpdateSalaryDetails_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
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
