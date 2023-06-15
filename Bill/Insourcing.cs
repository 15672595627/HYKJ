using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1.Bill
{
    public partial class Insourcing : Form
    {
        public Insourcing()
        {
            InitializeComponent();
        }

        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void Insourcing_Load(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("d");
            string time1 = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "RKD" + time1;
            DJRQ.Text = time;
        }

        private void TextBox1_DoubleClick(object sender, EventArgs e)
        {
            InPurchase inPurchase = new InPurchase(); 
            inPurchase.Show(this);
        }

        private void CGDD_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(CGDD.Text == "")
                {
                    MessageBox.Show("请输入订单号");
                }
                else
                {
                    dataGridView1.DataSource = null;
                    string aa = CGDD.Text.Trim();
                    string strsql = "select orderid as 订单编号,applyid as 申请单号,wlid as 物料编号,wlmc as 物料名称,wlgg as 物料规格,dw as 单位,cgsl as 采购数量  from [dbo].[NewPO_b] where  orderid = '" + aa + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns.Add("no", "入库重量");
                    dataGridView1.Columns.Add("no1", "入库数量");
                    for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                        this.dataGridView1.Rows[i].Cells[7].Value = 0;
                    for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                        this.dataGridView1.Rows[i].Cells[8].Value = 0;


                    string strsql1 = "select * from [dbo].[NewPO_h] where orderid = '" + aa + "'";
                    SqlDataAdapter da1 = new SqlDataAdapter(strsql1, SQL);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    GYS.Text = ds1.Tables[0].Rows[0][4].ToString();
                }
            }
        }

        private void BC_Click(object sender, EventArgs e)
        {
            BC.Enabled = false;
            
            string aa = GYS.Text.Trim();
            string bb = DJRQ.Text.Trim();
            string cc = DJBH.Text.Trim();
            string dd = CGDD.Text.Trim();
            if (CGDD.Text == "")
            {
                MessageBox.Show("请输入订单号");
            }
            else
            {
                SqlConnection con = new SqlConnection(SQL);
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string a1 = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                        string a2 = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                        string a3 = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                        string a4 = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                        string a5 = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                        string a6 = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                        string a7 = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                        cmd.CommandText = "INSERT INTO [dbo].[Insourcing] ([billid],[orderid],[supplier],[date],[goodsid],[goodsname],[goodsgg],[goodsdw],[cgsl],[weight],[rksl],[examine]) VALUES('" + cc + "', '" + dd + "', '" + aa + "', '" + bb + "', '" + a1 + "', '" + a2 + "', '" + a3 + "', '" + a4 + "', '" + a5 + "', '" + a6 + "', '" + a7 + "','未审核')";
                        int cot = cmd.ExecuteNonQuery();
                        if(cot == 0)
                        {
                            MessageBox.Show("保存失败");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    con.Close();
                }
              
            }
        }

    }
}