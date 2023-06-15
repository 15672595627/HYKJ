using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace WindowsFormsApp1.PO
{
    public partial class NewPO : Form
    {
        public NewPO()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void NewPO_Load(object sender, EventArgs e)
        {
            RQ.Text = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "CGDD" + time;
        }

        private void CGSQ_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NewPOApply newPOApply = new NewPOApply();
            newPOApply.Show(this);
        }
        private void CGSQ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CGSQ.Text == "")
                {
                    MessageBox.Show("请输入订单编号");
                }
                else
                {

                    dataGridView1.Columns.Clear();
                    string aa = CGSQ.Text.Trim();
                    string strsql = "select orderid as 采购申请单号,wlid as 物料编码,wlmc as 物料名称,wlgg as 物料规格,wldw as 单位,cgsl as 采购数量 from [dbo].[POApply] where orderid = '" + aa + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns.Add("采购重量", "采购重量");
                    for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                        this.dataGridView1.Rows[i].Cells[6].Value = 0;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (CGSQ.Text == "")
            {
                MessageBox.Show("请输入订单编号");
            }
            else
            {
                string djbh = DJBH.Text.Trim();
                string rq = RQ.Text.Trim();
                string gys = GYS.Text.Trim();
                string jq = JQ.Text.Trim();
                string cgsq = CGSQ.Text.Trim();
                string bz = BZ.Text.Trim();
                string htbh = HTBH.Text.Trim();
                string gsm = GSM.Text.Trim();
                string xmmc = XMMC.Text.Trim();


                SqlConnection con = new SqlConnection(SQL);
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    //cmd.CommandText = "INSERT INTO [dbo].[NewPO_h] ([orderid],[applyid],[date],[supplier],[delivery],[remakes],[examine]) VALUES ('" + djbh + "','" + sqdh + "','" + rq + "','" + gys + "','" + jq + "','" + bz + "','未审核')";
                    int cot = cmd.ExecuteNonQuery();
                    if (cot > 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
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
                if (dataGridView1 != null)
                {

                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            string a1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            string a2 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            string a3 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            string a4 = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            string a5 = dataGridView1.Rows[i].Cells[5].Value.ToString();
                            string a6 = dataGridView1.Rows[i].Cells[6].Value.ToString();

                            //cmd.CommandText = "INSERT INTO [dbo].[NewPO_b] ([orderid],[applyid],[supplier],[date],[wlid],[wlmc],[wlgg],[dw],[cgsl],[weight],[within],[state]) VALUES ('" + djbh + "','" + sqdh + "','" + gys + "','" + rq + "','" + a1 + "','" + a2 + "','" + a3 + "','" + a4 + "','" + a5 + "','" + a6 + "','0','未审核')";
                            cmd.ExecuteNonQuery();
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

        private void CGGYS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SupplierPO supplierPO = new SupplierPO();
            supplierPO.Show(this);
        }
    }
}
