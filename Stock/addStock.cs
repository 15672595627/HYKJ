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

namespace WindowsFormsApp1.Stock
{
    public partial class addStock : Form
    {
        public addStock()
        {
            InitializeComponent();
        }
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        int cot;
        int cot1;
        public string con_user { get; set; }
        public string con_group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string wldm = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                string wlmc = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                string wlgg = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                string zjh = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                string ckdm = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                string ckmc = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                string sl = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                string dw = dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                string zl = dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                string zldw = dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                string bz = dataGridView1.Rows[i].Cells[10].Value.ToString().Trim();
                string zxjj = dataGridView1.Rows[i].Cells[11].Value.ToString().Trim();
                string kcje = dataGridView1.Rows[i].Cells[12].Value.ToString().Trim();
                string kw = dataGridView1.Rows[i].Cells[13].Value.ToString().Trim();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO [dbo].[MaterialStock] ([materialsId],[materialsName],[specification],[auxiliarysign],[stockId],[stockName],[unitNumber],[unit],[weight],[weightUnit],[remark],[purchasingPrice],[stockAmount],[kuwei],[state]) VALUES ('" + wldm + "','" + wlmc + "','" + wlgg + "','" + zjh + "','" + ckdm + "','" + ckmc + "','" + sl + "','" + dw + "','" + zl + "','" + zldw + "','" + bz + "','" + zxjj + "','" + kcje + "','"+kw+"','N')";
                cot = cmd.ExecuteNonQuery();

                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "INSERT INTO [dbo].[PutStockDetial] ([materialsId],[materialsName],[specification],[stockId],[stockName],[unitNumber],[unit],[weight],[weightUnit],[remark],[purchasingPrice],[stockAmount],[kuwei]) VALUES ('" + wldm + "','" + wlmc + "','" + wlgg + "','" + ckdm + "','" + ckmc + "','" + sl + "','" + dw + "','" + zl + "','" + zldw + "','" + bz + "','" + zxjj + "','" + kcje + "','" + kw + "')";
                cot1 = cmd1.ExecuteNonQuery();
            }
            if (cot < 1 && cot1 <0 )
            {
                MessageBox.Show("添加失败！");
            }else
            {
                MessageBox.Show("添加成功！");
            }
            conn.Close();
        }

        private void addStock_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void addStock_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
