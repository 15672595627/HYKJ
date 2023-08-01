using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Scheduling
{
    // Token: 0x02000010 RID: 16
    public partial class kucunyanzheng : Form
    {
        // Token: 0x060000CA RID: 202 RVA: 0x0000F1A9 File Offset: 0x0000D3A9
        public kucunyanzheng()
        {
            this.InitializeComponent();
        }


        private SqlDataAdapter da;
        private DataTable dt;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        public string User { get; set; }

        public string Group { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.txtId.Text.Trim();
            string text2 = this.txtName.Text.Trim();
            string text3 = this.txtGg.Text.Trim();
            string selectCommandText = string.Concat(new string[]
            {
                "select id, materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,auxiliarysign as 助记号,stockId as 仓库代码,stockName as 仓库名称 ,unitNumber as 数量,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注,purchasingPrice as 最新进价 ,stockAmount as 库存金额 from MaterialStock where materialsId like '%",
                text,
                "%' and materialsName like '%",
                text2,
                "%' and specification like '%",
                text3,
                "%' and state = 'N'"
            });
            this.da = new SqlDataAdapter(selectCommandText, kucunyanzheng.SQL);
            this.dt = new DataTable();
            this.da.Fill(this.dt);
            this.dataGridView1.DataSource = this.dt;
            this.dataGridView1.Columns["id"].Visible = false;
        }

        // Token: 0x060000D0 RID: 208 RVA: 0x0000F2C8 File Offset: 0x0000D4C8
        private void txtHtbh_TextChanged(object sender, EventArgs e)
        {
            /*ContractH contractH = new ContractH();
            contractH.Show();*/
        }

        // Token: 0x060000D1 RID: 209 RVA: 0x0000F2E3 File Offset: 0x0000D4E3

        // Token: 0x060000D2 RID: 210 RVA: 0x0000F2E8 File Offset: 0x0000D4E8
        private void txtHtbh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ContractH contractH = new ContractH();
            contractH.Show(this);
        }

        // Token: 0x060000D3 RID: 211 RVA: 0x0000F304 File Offset: 0x0000D504
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = this.dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            string selectCommandText = "select id, materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,auxiliarysign as 助记号,stockId as 仓库代码,stockName as 仓库名称 ,unitNumber as 数量,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注,purchasingPrice as 最新进价 ,stockAmount as 库存金额 from MaterialStock where id = '" + str + "'";
            this.da = new SqlDataAdapter(selectCommandText, kucunyanzheng.SQL);
            this.dt = new DataTable();
            this.da.Fill(this.dt);
            this.dataGridView2.DataSource = this.dt;
            this.dataGridView2.Columns["id"].Visible = false;
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Rows[0].Selected = true;
        }

        // Token: 0x060000D4 RID: 212 RVA: 0x0000F3D4 File Offset: 0x0000D5D4
        private void kucunyanzheng_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selectCommandText = "select id, materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,auxiliarysign as 助记号,stockId as 仓库代码,stockName as 仓库名称 ,unitNumber as 数量,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注,purchasingPrice as 最新进价 ,stockAmount as 库存金额 from MaterialStock where state = 'Y'";
            this.da = new SqlDataAdapter(selectCommandText, kucunyanzheng.SQL);
            this.dt = new DataTable();
            this.da.Fill(this.dt);
            this.dataGridView2.DataSource = this.dt;
            this.dataGridView2.Columns["id"].Visible = false;
        }

        // Token: 0x060000D7 RID: 215 RVA: 0x0000F458 File Offset: 0x0000D658
        private void btnBc_Click(object sender, EventArgs e)
        {
            string text = DateTime.Now.ToString("yyyy-MM-dd");
            string text2 = this.txtDdbh.Text.Trim();
            string text3 = this.txtHtbh.Text.Trim();
            string text4 = this.txtGsm.Text.Trim();
            string text5 = this.txtXm.Text.Trim();
            string text6 = this.textBox5.Text.Trim();
            string text7 = this.dataGridView2.CurrentRow.Cells["id"].Value.ToString();
            string text8 = this.dataGridView2.CurrentRow.Cells["物料代码"].Value.ToString();
            string text9 = this.dataGridView2.CurrentRow.Cells["物料名称"].Value.ToString();
            string text10 = this.dataGridView2.CurrentRow.Cells["规格型号"].Value.ToString();
            string text11 = this.dataGridView2.CurrentRow.Cells["仓库名称"].Value.ToString();
            string text12 = this.dataGridView2.CurrentRow.Cells["单位"].Value.ToString();
            decimal d = Convert.ToInt32(this.dataGridView2.CurrentRow.Cells["数量"].Value.ToString());
            decimal d2 = Convert.ToInt32(this.textBox6.Text.Trim());
            string text13 = this.dataGridView2.CurrentRow.Cells["最新进价"].Value.ToString();
            string text14 = this.dataGridView2.CurrentRow.Cells["库存金额"].Value.ToString();
            try
            {
                bool flag = d > d2;
                if (flag)
                {
                    decimal num = d - d2;
                    SqlConnection sqlConnection = new SqlConnection(kucunyanzheng.SQL);
                    sqlConnection.Open();
                    string cmdText = string.Concat(new string[]
                    {
                        "update MaterialStock set unitNumber = '",
                        num.ToString(),
                        "'where id = '",
                        text7,
                        "'"
                    });
                    SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    string cmdText2 = string.Concat(new string[]
                    {
                        "INSERT INTO OutStockDetial (Date,orderId,contactId,company,project,product,stockName,materialsId,materialsName,specification,unit,unitNumber,purchasingPrice,stockAmount,state) VALUES ('",
                        text,
                        "','",
                        text2,
                        "','",
                        text3,
                        "','",
                        text4,
                        "','",
                        text5,
                        "','",
                        text6,
                        "','",
                        text11,
                        "','",
                        text8,
                        "','",
                        text9,
                        "','",
                        text10,
                        "','",
                        text12,
                        "','",
                        d2.ToString(),
                        "','",
                        text13,
                        "','",
                        text14,
                        "','N')"
                    });
                    SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
                    int num2 = sqlCommand2.ExecuteNonQuery();
                    bool flag2 = num2 > 0;
                    if (flag2)
                    {
                        MessageBox.Show("保存成功");
                    }
                    sqlConnection.Close();
                }
                else
                {
                    bool flag3 = d < d2;
                    if (flag3)
                    {
                        MessageBox.Show(string.Concat(new string[]
                        {
                            "库存数量：",
                            d.ToString(),
                            "  小于需要的数量：",
                            d2.ToString(),
                            "  ,请申请采购"
                        }));
                        SqlConnection sqlConnection2 = new SqlConnection(kucunyanzheng.SQL);
                        sqlConnection2.Open();
                        string cmdText3 = string.Concat(new string[]
                        {
                            "INSERT INTO purchaseRequest (orderId,contactId,company,project,product,stockName,materialsId,materialsName,specification,unit,unitNumber,purchasingPrice,stockAmount,state) VALUES ('",
                            text2,
                            "','",
                            text3,
                            "','",
                            text4,
                            "','",
                            text5,
                            "','",
                            text6,
                            "','",
                            text11,
                            "','",
                            text8,
                            "','",
                            text9,
                            "','",
                            text10,
                            "','",
                            text12,
                            "','",
                            d.ToString(),
                            "','",
                            text13,
                            "','",
                            text14,
                            "','N')"
                        });
                        SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection2);
                        int num3 = sqlCommand3.ExecuteNonQuery();
                        bool flag4 = num3 < 0;
                        if (flag4)
                        {
                            MessageBox.Show("保存失败！");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失败，失败原因" + ex.Message);
            }
        }

        // Token: 0x060000D8 RID: 216 RVA: 0x0000F984 File Offset: 0x0000DB84
        private void kucunyanzheng_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

        // Token: 0x060000D9 RID: 217 RVA: 0x0000F994 File Offset: 0x0000DB94
        private void 下推ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                string str = this.dataGridView1.Rows[i].Cells["id"].Value.ToString();
                SqlConnection sqlConnection = new SqlConnection(kucunyanzheng.SQL);
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "update MaterialStock set state = 'Y'where id = '" + str + "'";
                int num = sqlCommand.ExecuteNonQuery();
                bool flag = num == 0;
                if (flag)
                {
                    MessageBox.Show("下推失败");
                }
                sqlConnection.Close();
            }
            this.button1.PerformClick();
            this.button3.PerformClick();
        }
    }
}
