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
    public partial class updateOutList : Form
    {
        public updateOutList()
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
        private void updateOutList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string str = "select id, materialRequisitionId as 领料单号 , contactId as 合同编号,company as 客户名称,project as 项目名称,wsje as 无税金额,stockName as 仓库,sl as 领料数量,kuwei as 库位 ,materialsId as 物料代码,materialsName as 物料名称,specification as 物料规格,unitNumber as 库存数量,unit as 单位 ,purchasingPrice as 库存单价,stockAmount as 库存金额,date as 领料时间,remark as 备注,ll as 领料,zd as 制单,je as 金额 from linliaodan where id = '" + UId + "'";
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
                int llsl = Convert.ToInt32(dataGridView1.Rows[m].Cells["领料数量"].Value);
                if (dataGridView1.Rows[m].Cells["库存单价"].Value == DBNull.Value)
                {
                    dataGridView1.Rows[m].Cells["库存单价"].Value = 0;
                }
                decimal ckdj = Convert.ToDecimal(dataGridView1.Rows[m].Cells["库存单价"].Value);
                int kcsl = Convert.ToInt32(dataGridView1.Rows[m].Cells["库存数量"].Value);
                decimal kcje = Convert.ToDecimal(dataGridView1.Rows[m].Cells["库存金额"].Value);
                int sl = llsl;
                decimal dj = ckdj;
                int ssl = kcsl;
                int newKcsl = ssl - llsl;
                decimal je = sl * dj;//金额
                decimal newAmount = kcje - je;

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update MaterialStock set  unitNumber = '" + newKcsl + "',stockAmount = '" + newAmount + "'where materialsId = '" + wldm + "'";
                cot = cmd.ExecuteNonQuery();

                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "update linliaodan set  sl = '" + sl + "',je = '" + je + "',unitNumber = '" + newKcsl + "',stockAmount = '" + newAmount + "',state = '已审核' where id = '" + id + "'";
                cot1 = cmd1.ExecuteNonQuery();
            }
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cot > 0 || cot1 > 0)
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
            string str = "select id, materialRequisitionId as 领料单号 , contactId as 合同编号,company as 客户名称,project as 项目名称,wsje as 无税金额,stockName as 仓库,sl as 领料数量,kuwei as 库位 ,materialsId as 物料代码,materialsName as 物料名称,specification as 物料规格,unitNumber as 库存数量,unit as 单位 ,purchasingPrice as 库存单价,date as 领料时间,remark as 备注,ll as 领料,zd as 制单,je as 金额 from linliaodan where id = '" + UId + "'";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void updateOutList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
