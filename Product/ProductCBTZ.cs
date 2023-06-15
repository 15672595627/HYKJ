using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Product
{
    public partial class ProductCBTZ : Form
    {
        public ProductCBTZ()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string PCB_User { get; set; }
        public string PCB_Group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void ProductCBTZ_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "CBTZ" + time;
            DJRQ.Text = DateTime.Now.ToString("d");
            toolStripStatusLabel2.Text = PCB_User;
            toolStripStatusLabel5.Text = PCB_Group;
            LDY.Text = PCB_User;
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CBTZ_ST cBTZ = new CBTZ_ST();
            cBTZ.Show(this);
        }

        private void CPMC_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string strsql = "select product as 产品名称,norm as 规格,unit as 单位,num as 数量,amount as 金额,warehouse as 收货仓库 from Stock where product like '%" + CPMC.Text.Trim() + "%'";
                SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns.Add("成本单价", "成本单价");
                dataGridView1.Columns.Add("成本金额", "成本金额");
                dataGridView1.Columns.Add("发货数量", "发货数量");
                dataGridView1.Columns.Add("发货金额", "发货金额");
                dataGridView1.Columns.Add("发货成本金额", "发货成本金额");

                dataGridView1.Rows[0].Cells["成本单价"].Value = "1";
                dataGridView1.Rows[0].Cells["成本金额"].Value = "1";
                dataGridView1.Rows[0].Cells["发货数量"].Value = dataGridView1.Rows[0].Cells["数量"].Value;
                dataGridView1.Rows[0].Cells["发货金额"].Value = "1";
                dataGridView1.Rows[0].Cells["发货成本金额"].Value = "1";

            }
        }

        private void BC_Click(object sender, EventArgs e)
        {

            string djbh = DJBH.Text.Trim();
            string djrq = DJRQ.Text.Trim();
            string cpmc = CPMC.Text.Trim();
            string htbh = HTBH.Text.Trim();
            SqlConnection con = new SqlConnection(SQL);
            try
            {
                con.Open();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string cpgg = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string dw = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string kcsl = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string kcje = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string shck = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string cbdj = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    string cbje = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    string fhsl = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    string fhje = dataGridView1.Rows[i].Cells[9].Value.ToString();
                    string fhcbje = dataGridView1.Rows[i].Cells[10].Value.ToString();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "insert into ProductCbtz ([orderid],[contractid],[date],[staff],[product],[norms],[shck],[cbdj],[cbamount],[num],[amount],[dw],[fhsl],[fhamount],[fhcbamount],[examine]) values ('" + djbh + "','" + htbh + "','" + djrq + "','" + PCB_User + "','" + cpmc + "','" + cpgg + "','" + shck + "','" + cbdj + "','" + cbje + "','" + kcsl + "','" + kcje + "','" + dw + "','" + fhsl + "','" + fhje + "','" + fhcbje + "','未审核')";
                    int cot = cmd.ExecuteNonQuery();
                    if (cot == 0)
                    {
                        MessageBox.Show("保存失败");
                    }
                }
            }
            catch 
            {
                MessageBox.Show("有空白，没填完！");
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("保存成功");
            con.Close();
            this.Close();
        }

        private void ProductCBTZ_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
