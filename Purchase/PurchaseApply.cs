using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Desgin;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Purchase
{
    public partial class PurchaseApply : Form
    {
        public PurchaseApply()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public static string PAGoods = "";
        private void PurchaseApply_Load(object sender, EventArgs e)
        {
            RQ.Text = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "CGSQD" + time;
            

        }

        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(dataGridView1.CurrentCell.OwningColumn.Name == "物料编码")
            dataGridView1.CurrentCell.Value = PAGoods;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F7)
            {
                if(dataGridView1.CurrentCell.OwningColumn.Name == "物料编码")
                {
                    PurchaseApplyGoods purchaseApplyGoods = new PurchaseApplyGoods();
                    purchaseApplyGoods.Show();
                }


            }
            if(e.KeyCode == Keys.Enter)
            {
                string strsql = "select * from [dbo].[Goods] where goodsid = '" + PAGoods + "'";
                SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.CurrentRow.Cells[1].Value = ds.Tables[0].Rows[0][2].ToString();
                dataGridView1.CurrentRow.Cells[2].Value = ds.Tables[0].Rows[0][3].ToString();
                dataGridView1.CurrentRow.Cells[3].Value = ds.Tables[0].Rows[0][4].ToString();
                


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string djbh = DJBH.Text.Trim();
            string rq = RQ.Text.Trim();
            string bz = BZ.Text.Trim();
            SqlConnection con = new SqlConnection(SQL);
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    string wlid = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string wlmc = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string wlgg = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string wldw = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string cgsl = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string cgbz = dataGridView1.Rows[i].Cells[5].Value.ToString();

                    cmd.CommandText = "INSERT INTO [dbo].[POApply] ([orderid],[date],[wlid],[wlmc],[wlgg],[wldw],[cgsl],[remakes],[remakes1],[examine]) VALUES ('" + djbh+ "','" + rq + "','" + wlid + "','" + wlmc + "','" + wlgg + "','" + wldw + "','" + cgsl + "','" + cgbz + "','" + bz + "','未审核')";
                    int cot = cmd.ExecuteNonQuery();
                    if (cot == 0)
                    {
                        MessageBox.Show("保存失败");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失败，失败原因" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
