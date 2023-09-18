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

namespace WindowsFormsApp1.Scheduling
{
    public partial class ddl : Form
    {
        public ddl()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da;
        private DataTable dt;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void button1_Click(object sender, EventArgs e)
        {
            string selectCommandText = "select id, materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,stockId as 仓库代码,stockName as 仓库名称  ,sl as 数量,unitNumber as 库存数量,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注,purchasingPrice as 最新进价 ,stockAmount as 库存金额 from OutStockDetial where state = 'Y'";
            da = new SqlDataAdapter(selectCommandText, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int m = dataGridView1.SelectedRows[i].Index;
                SqlConnection sqlConnection = new SqlConnection(SQL);
                sqlConnection.Open();
                string id = dataGridView1.Rows[m].Cells["id"].Value.ToString();
                string text11 = dataGridView1.Rows[m].Cells["仓库名称"].Value.ToString();
                string text12 = dataGridView1.Rows[m].Cells["单位"].Value.ToString();
                string wldl = dataGridView1.Rows[m].Cells["物料代码"].Value.ToString();
                string text9 = dataGridView1.Rows[m].Cells["物料名称"].Value.ToString();
                string text10 = dataGridView1.Rows[m].Cells["规格型号"].Value.ToString();
                int sl = Convert.ToInt32(dataGridView1.Rows[m].Cells["数量"].Value);
                int d = Convert.ToInt32(dataGridView1.Rows[m].Cells["库存数量"].Value);
                decimal text13 = Convert.ToDecimal(dataGridView1.Rows[m].Cells["最新进价"].Value);
                string text14 = dataGridView1.Rows[m].Cells["库存金额"].Value.ToString();
                int sl1 = sl;
                int kcsl = d - sl;
                decimal newje = kcsl * text13;

                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "update MaterialStock set  unitNumber = '" + kcsl + "',stockAmount = '" + newje + "'where materialsId = '" + wldl + "'";
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = sqlConnection.CreateCommand();
                cmd1.CommandText = "update OutStockDetial set  sl = '" + sl1 + "',stockAmount = '" + newje + "'where materialsId = '" + wldl + "'";
                cmd1.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
