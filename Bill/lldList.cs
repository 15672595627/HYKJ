using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Stock;

namespace WindowsFormsApp1.Bill
{
    // Token: 0x02000084 RID: 132
    public partial class lldList : Form
    {
        // Token: 0x06000747 RID: 1863 RVA: 0x000FC26A File Offset: 0x000FA46A
        public lldList()
        {
            this.InitializeComponent();
        }
        public string OSL_User { get; set; }
        public string OSL_Group { get; set; }
        private SqlDataAdapter da = null;
        private DataTable dt = null;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.txtHtbh.Text.Trim();
            string text2 = this.txtlld.Text.Trim();
            string text3 = this.dt1.Text.Trim();
            string text4 = this.dt2.Text.Trim();
            string selectCommandText = string.Concat(new string[]
            {
                "select id, materialRequisitionId as 领料单号 , contactId as 合同编号,company as 客户名称,project as 项目名称,wsje as 无税金额,stockName as 仓库,sl as 领料数量,kuwei as 库位 ,materialsId as 物料代码,materialsName as 物料名称,specification as 物料规格,unitNumber as 库存数量,unit as 单位 ,stockAmount as 库存金额,date as 领料时间,remark as 备注,ll as 领料,zd as 制单,je as 金额,state as 审核状态 from linliaodan where contactId like '%"+text+"%' and state like '%"+comboBox1.Text+"%' and materialRequisitionId like '%",
                text2,
                "%' and date between '",
                text3,
                "' and '",
                text4,
                "' order by date DESC "
            });
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, lldList.SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.dataGridView1.DataSource = dataTable;
            this.dataGridView1.Columns["id"].Visible = false;
        }

        private void lldList_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
        }

        private void lldList_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

        private void 反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OSL_Group == "资材部" || OSL_Group == "Administrators") 
            {
                int cot1 = 0;
                int cot2 = 0;
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    int kcsl = Convert.ToInt32(dataGridView1.CurrentRow.Cells["库存数量"].Value);
                    int llsl = Convert.ToInt32(dataGridView1.CurrentRow.Cells["领料数量"].Value);
                    decimal je = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["金额"].Value);
                    decimal kcje = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["库存金额"].Value);

                    int m = dataGridView1.SelectedRows[i].Index;
                    string id = dataGridView1.Rows[m].Cells["id"].Value.ToString().Trim();
                    string wldm = dataGridView1.Rows[m].Cells["物料代码"].Value.ToString().Trim();

                    SqlConnection conn = new SqlConnection(SQL);
                    conn.Open();
                    int oldsl = kcsl + llsl;//原始库存量
                    decimal odlje = kcje + je;//原始库存金额

                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "UPDATE [dbo].[linliaodan] SET sl = '0',je = '0',unitNumber = '" + oldsl + "',stockAmount = '" + odlje + "',state = '未审核' where id = '" + id + "'";
                    cot1 = cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = conn.CreateCommand();
                    cmd2.CommandText = "UPDATE [dbo].[MaterialStock] SET unitNumber = '" + oldsl + "',stockAmount = '" + odlje + "' where materialsId = '" + wldm + "'";
                    cot2 = cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                if (cot1 < 0 || cot2 < 0)
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
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["审核状态"].Value.ToString() == "未审核")
            {
                string b = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                updateOutList updateOutList = new updateOutList();
                updateOutList.UId = b;
                updateOutList.OSL_Group = OSL_Group;
                updateOutList.OSL_User = OSL_User;
                updateOutList.Show();
            }
            else
            {
                MessageBox.Show("该记录已被审核，请反审核后才能修改");
            }
        }
    }
}
