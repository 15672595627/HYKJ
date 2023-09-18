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
using WindowsFormsApp1.Order;
using WindowsFormsApp1.Scheduling;

namespace WindowsFormsApp1.Stock
{
    public partial class PutStockDetialList : Form
    {
        public PutStockDetialList()
        {
            InitializeComponent();
        }
        public string User { get; set; }

        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private SqlDataAdapter da;
        private DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {

            string str = "select id, date as 时间,bh as 入库编号 ,materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,stockId as 仓库代码,stockName as 仓库名称 ,sl as 入库数量,dj as 入库单价,je as 金额,unitNumber as 库存数量,purchasingPrice as 最新进价 ,stockAmount as 库存金额,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注 ,gys as 供应商,examine as 审核状态 from PutStockDetial where examine like '%"+comboBox1.Text+ "%'and materialsId like '%"+textBox1.Text+ "%' and materialsName like '%"+textBox2.Text+ "%' and specification like '%"+textBox3.Text+"%'";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //dataGridView1.Columns["id"].Visible = false;
        }

        private void PutStockDetialList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void PutStockDetialList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void 反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Group == "资材部" || Group == "Administrators")
            {
                int cot1 = 0;
                int cot2 = 0;
                for (int i = 0; i <dataGridView1.SelectedRows.Count; i++)
                {
                    int kcsl = Convert.ToInt32(dataGridView1.CurrentRow.Cells["库存数量"].Value);
                    int rksl = Convert.ToInt32(dataGridView1.CurrentRow.Cells["入库数量"].Value);
                    decimal rkdj = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["入库单价"].Value);
                    decimal je = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["金额"].Value);
                    decimal zxjj = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["最新进价"].Value);
                    decimal kcje = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["库存金额"].Value);
                    int m = dataGridView1.SelectedRows[i].Index;
                    string id = dataGridView1.Rows[m].Cells["id"].Value.ToString().Trim();
                    string wldm = dataGridView1.Rows[m].Cells["物料代码"].Value.ToString().Trim();
                    
                    SqlConnection conn = new SqlConnection(SQL);
                    conn.Open();            
                    int oldsl = kcsl - rksl;//原始库存量
                    decimal odlje = kcje - je;//原始库存1金额

                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "UPDATE [dbo].[PutStockDetial] SET sl = '0',dj = '0',je = '0',unitNumber = '"+ oldsl + "',stockAmount = '" + odlje + "',examine = '未审核' where id = '" + id + "'";
                    cot1 = cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = conn.CreateCommand();
                    cmd2.CommandText = "UPDATE [dbo].[MaterialStock] SET unitNumber = '"+ oldsl + "',stockAmount = '" + odlje + "' where materialsId = '" + wldm + "'";
                    cot2 = cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                if(cot1 < 0||cot2 < 0)
                {
                    MessageBox.Show("反审核失败");
                }
                else
                {
                    MessageBox.Show("反审核成功");
                }
            }
            else
            {
                MessageBox.Show("你没有权限");
            }
            button1.PerformClick();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["审核状态"].Value.ToString() == "未审核")
            {
                string b = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                updatePutList putList = new updatePutList();
                putList.UId = b;
                putList.OSL_Group = Group;
                putList.OSL_User = User;
                putList.Show();
            }
            else
            {
                MessageBox.Show("该记录已被审核，请反审核后才能修改");
            }
        }
    }
}
