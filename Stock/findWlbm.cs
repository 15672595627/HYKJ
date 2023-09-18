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
using System.Xml.Linq;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Scheduling;

namespace WindowsFormsApp1.Stock
{
    public partial class findWlbm : Form
    {
        public findWlbm()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da;
        private DataTable dt;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        public string con_user { get; set; }
        public string con_group { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            string text = txtId.Text.Trim();
            string text2 = txtName.Text.Trim();
            string text3 = txtGg.Text.Trim();
            string text4 = comboBox1.Text.Trim();
            string str = "select id, materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,auxiliarysign as 助记号,stockId as 仓库代码,stockName as 仓库名称 ,unitNumber as 数量,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注,purchasingPrice as 最新进价 ,stockAmount as 库存金额 from MaterialStock where materialsId like '%" + text + "%' and materialsName like '%" + text2 + "%' and specification like '%" + text3 + "%' and stockName like '%" + text4 + "%' and state = 'N'";
            da = new SqlDataAdapter(str, kucunyanzheng.SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void 下推ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int m = dataGridView1.SelectedRows[i].Index;
                string id = dataGridView1.Rows[m].Cells["id"].Value.ToString();
                SqlConnection sqlConnection = new SqlConnection(kucunyanzheng.SQL);
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "update MaterialStock set state1 = 'Y'where id = '" + id + "'";
                int num = sqlCommand.ExecuteNonQuery();
                bool flag = num == 0;
                if (flag)
                {
                    MessageBox.Show("下推失败");
                }
                sqlConnection.Close();
            }
        }
    }
}
