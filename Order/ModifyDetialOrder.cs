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

namespace WindowsFormsApp1.Order
{
    public partial class ModifyDetialOrder : Form
    {
        public ModifyDetialOrder()
        {
            InitializeComponent();
        }
        public string OSL_User { get; set; }
        public string OSL_Group { get; set; }
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        DataTable dt;
        SqlDataAdapter da;
        public string OId { get; set; }
        public string UId { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void ModifyDetialOrder_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string sql = String.Format("select id,orderid as 单据编号,contractid as 合同编号,date as 日期,service as 跟单员,company as 公司名,project as 项目名称,sub as 内容,quantity as 数量,unit as 单位,price as 单价,meters as 米数,amount as 总金额,azf as 安装费,hk as 回扣,yf as 运费 ,sjje as 实际金额,wsje as 无税金额,ywy as 业务员,qy as 区域,productname as 产品名称,ident as 发货状态,ckzt as 出库状态,examine as 审核状态 from [dbo].[Order_b] where orderid = '" + OId+"'");
            
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
        decimal sumSl;
        decimal sumDj;
        decimal sumMs;
        decimal sumZje;
        decimal sumAzf;
        decimal sumHk;
        decimal sumYf;
        decimal sumSjje;
        decimal sumWsje;

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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //string oId = dataGridView1.Rows[i].Cells["单据编号"].Value.ToString();
                decimal sl = Convert.ToDecimal(dataGridView1.Rows[i].Cells["数量"].Value);
                decimal dj = Convert.ToDecimal(dataGridView1.Rows[i].Cells["单价"].Value);
                decimal ms = Convert.ToDecimal(dataGridView1.Rows[i].Cells["米数"].Value);
                decimal zje = Convert.ToDecimal(dataGridView1.Rows[i].Cells["总金额"].Value);
                decimal azf = Convert.ToDecimal(dataGridView1.Rows[i].Cells["安装费"].Value);
                decimal hk = Convert.ToDecimal(dataGridView1.Rows[i].Cells["回扣"].Value);
                decimal yf = Convert.ToDecimal(dataGridView1.Rows[i].Cells["运费"].Value);
                decimal sjje = Convert.ToDecimal(dataGridView1.Rows[i].Cells["实际金额"].Value);
                decimal wsje = Convert.ToDecimal(dataGridView1.Rows[i].Cells["无税金额"].Value);
                sumSl += sl;
                sumDj += dj;
                sumMs += ms;
                sumZje += zje;
                sumAzf += azf;
                sumHk += hk;
                sumYf += yf;
                sumSjje += sjje;
                sumWsje += wsje;
                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update Order_h set amount = '"+ sumSjje + "',wsje = '"+ sumWsje + "',sjje = '"+sumZje+ "',azf = '"+sumAzf+ "',hk = '" + sumHk+ "'where orderid = '"+ OId + "'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*try
            {
                SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("保存失败");
                return;
            }*/
        }
    }
}
