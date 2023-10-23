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

namespace WindowsFormsApp1.DesignDepartment
{
    public partial class DUpdateFixedAssetBudget : Form
    {
        public DUpdateFixedAssetBudget()
        {
            InitializeComponent();
        }
        DataTable dt;
        SqlDataAdapter da;
        public string id { get; set; }
        public string Username { get; set; }
        public string Group { get; set; }
        public string Iid { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void DUpdateFixedAssetBudget_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string sql = "select [id],[apartment] as 部门,[name] as 名称,[purpose] as 用途,[price] as 单价,[number] as 数量,[date] as 月份 from SJBFixedAssetBudget where id = '" + id + "'";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void DUpdateFixedAssetBudget_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select [id],[apartment] as 部门,[name] as 名称,[purpose] as 用途,[price] as 单价,[number] as 数量,[date] as 月份 from SJBFixedAssetBudget where state = 1";
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
