using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Scheduling
{
    public partial class ContractH : Form
    {
        public ContractH()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da;
        private DataTable dt;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();
            string text2 = textBox2.Text.Trim();
            string str ="select id, orderid as 单据编号,contractid as 合同编号,date as 日期,company as 公司,project as 项目名称,sub as 分公司 ,con_cate as 合同类别,kh_type as 客户类别,kh_cate as 客户类型,seller as 业务员,cost as 钢材,area as 地区,place as 产地,tax as 税率,amount as 金额,examine as 审核状态,qj as 期间 from[dbo].[Contract_h] where contractid like '%"+text+ "%' and company like '%"+text2+"%'";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string text2 = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string text3 = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string text4 = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            kucunyanzheng kucunyanzheng = (kucunyanzheng)this.Owner;
            kucunyanzheng.Controls["panel1"].Controls["txtDdbh"].Text = text;
            kucunyanzheng.Controls["panel1"].Controls["txtHtbh"].Text = text2;
            kucunyanzheng.Controls["panel1"].Controls["txtGsm"].Text = text3;
            kucunyanzheng.Controls["panel1"].Controls["txtXm"].Text = text4;
            this.Close();
        }

        private void ContractH_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }
        private void ContractH_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
       
    }
}
