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
    public partial class updatePutList : Form
    {
        public updatePutList()
        {
            InitializeComponent();
        }
        public string OSL_User { get; set; }
        public string OSL_Group { get; set; }
        public string UId { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private SqlDataAdapter da;
        private DataTable dt;

        private void updatePutList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string str = "select id, date as 时间,bh as 入库编号 ,materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,stockId as 仓库代码,stockName as 仓库名称 ,sl as 入库数量,dj as 入库单价,je as 金额,unitNumber as 库存数量,purchasingPrice as 最新进价 ,stockAmount as 库存金额,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注 ,gys as 供应商,examine as 审核状态 from PutStockDetial where id = '" + UId + "'";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        int cot;
        int cot1;
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int m = dataGridView1.SelectedRows[i].Index;
                string id = dataGridView1.Rows[m].Cells["id"].Value.ToString();
                string wldm = dataGridView1.Rows[m].Cells["物料代码"].Value.ToString();
                int rksl = Convert.ToInt32(dataGridView1.Rows[m].Cells["入库数量"].Value);
                decimal rkdj = Convert.ToDecimal(dataGridView1.Rows[m].Cells["入库单价"].Value);
                int kcsl = Convert.ToInt32(dataGridView1.Rows[m].Cells["库存数量"].Value);
                decimal kcje = Convert.ToDecimal(dataGridView1.Rows[m].Cells["库存金额"].Value);
                int sl = rksl;
                decimal dj = rkdj;
                decimal je = sl * dj;//金额
                decimal totalAmount = je + kcje;//总金额
                int totalNumber = kcsl + sl;//总数量
                decimal newdj = totalAmount / totalNumber;//最新进价

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update MaterialStock set  unitNumber = '" + totalNumber + "',stockAmount = '" + totalAmount + "',purchasingPrice = '" + newdj + "'where materialsId = '" + wldm + "'";
                cot = cmd.ExecuteNonQuery();

                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "update PutStockDetial set  sl = '" + sl + "',dj = '" + dj + "',je = '" + je + "',unitNumber = '" + totalNumber + "',stockAmount = '" + totalAmount + "',purchasingPrice = '" + newdj + "',examine = '已审核' where id = '" + id + "'";
                cot1 = cmd1.ExecuteNonQuery();
            }
            conn.Close();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int m = dataGridView1.SelectedRows[i].Index;
                string id = dataGridView1.Rows[m].Cells["id"].Value.ToString();
                string shzt = dataGridView1.Rows[m].Cells["审核状态"].Value.ToString();
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                string str = "update PutStockDetial set examine = '已审核' where id = '"+id+"'";
                cmd.CommandText = str;
                cot = cmd.ExecuteNonQuery();
            }
            if(cot > 0)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }

            string str1 = "select id, date as 时间,bh as 入库编号 ,materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,stockId as 仓库代码,stockName as 仓库名称 ,sl as 入库数量,dj as 入库单价,je as 金额,unitNumber as 库存数量,purchasingPrice as 最新进价 ,stockAmount as 库存金额,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注 ,gys as 供应商,examine as 审核状态 from PutStockDetial where id = '" + UId + "'";
            da = new SqlDataAdapter(str1, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }*/
           
            if(cot>0 || cot1 > 0)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
            button2.PerformClick();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "select id, date as 时间,bh as 入库编号 ,materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,stockId as 仓库代码,stockName as 仓库名称 ,sl as 入库数量,dj as 入库单价,je as 金额,unitNumber as 库存数量,purchasingPrice as 最新进价 ,stockAmount as 库存金额,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注 ,gys as 供应商,examine as 审核状态 from PutStockDetial where id = '" + UId + "'";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void updatePutList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
