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
            string str = "select id,orderid as 单据编号,contractid as 合同编号,date as 日期,service as 跟单员,desgin as 设计员,company as 公司名,project as 项目名称,con_date as 合同日期,seller as 业务员,person as 联系人,phone as 电话,delivery as 交期,color as 颜色,longmetre as 最长米,quantity as 总米数,tax as 税率,htje as 合同金额,sjje as 实际金额,amount as 总金额,wsje as 无税金额,azf as 安装费,ywf as 业务费,huokuan as 货款,dj as 定金,hk as 回扣,remarks as 备注,examine as 审核状态,qj as 期间 from [dbo].[Order_h] where contractid like '%" + text+ "%' and company like '%"+text2+ "%' order by [date] DESC ";
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
            string text3 = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            string text4 = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            string wsje = dataGridView1.CurrentRow.Cells["无税金额"].Value.ToString();
            kucunyanzheng kucunyanzheng = (kucunyanzheng)this.Owner;
            kucunyanzheng.Controls["panel1"].Controls["txtDdbh"].Text = text;
            kucunyanzheng.Controls["panel1"].Controls["txtHtbh"].Text = text2;
            kucunyanzheng.Controls["panel1"].Controls["txtGsm"].Text = text3;
            kucunyanzheng.Controls["panel1"].Controls["txtXm"].Text = text4;
            kucunyanzheng.Controls["panel1"].Controls["txtWsje"].Text = wsje;
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
