using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Bill;
using WindowsFormsApp1.Plan;

namespace WindowsFormsApp1.Scheduling
{
    public partial class ContactH : Form
    {
        public ContactH()
        {
            InitializeComponent();
        }
        public string User { get; set; }
        public string Group { get; set; }

        DataTable dt;
        DataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string kh = textBox2.Text.Trim();
            string htbh = textBox1.Text.Trim();
            string str = "select id,orderid as 单据编号,contractid as 合同编号,date as 日期,company as 客户,project as 项目名称,sub as 分公司 ,con_cate as 合同类别,kh_type as 客户类别,kh_cate as 客户类型,seller as 业务员,cost as 钢材,area as 地区,place as 产地,tax as 税率,amount as 金额,examine as 审核状态,qj as 期间 from [dbo].[Contract_h] where contractid like '%"+htbh+ "%' and company like '%" + kh+"%'";
            da = new SqlDataAdapter(str, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["id"].Visible = false;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
            string b = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString();
            string c = dataGridView1.CurrentRow.Cells["客户"].Value.ToString();
            string d = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
            CheckStock checkStock = (CheckStock)this.Owner;
            checkStock.Controls["groupBox1"].Controls["txtHtbh"].Text = a;
            checkStock.Controls["groupBox1"].Controls["txtDdbh"].Text = b;
            checkStock.Controls["groupBox1"].Controls["txtKh"].Text = c;
            checkStock.Controls["groupBox1"].Controls["txtXm"].Text = d;
            this.Close();
        }
    } 
}
