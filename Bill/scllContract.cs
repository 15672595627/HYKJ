using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Bill
{
    // Token: 0x02000089 RID: 137
    public partial class scllContract : Form
    {
        // Token: 0x06000769 RID: 1897 RVA: 0x000FFCF4 File Offset: 0x000FDEF4
        public scllContract()
        {
            this.InitializeComponent();
        }
        private string a;

        private string b;

        private SqlDataAdapter da = null;

        private DataTable dt = null;
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void button4_Click(object sender, EventArgs e)
        {
            string text = this.textBox3.Text.Trim();
            string text2 = this.textBox1.Text.Trim();
            string text3 = this.textBox2.Text.Trim();
            string text4 = this.textBox4.Text.Trim();
            string text5 = this.textBox10.Text.Trim();
            string selectCommandText = string.Concat(new string[]
            {
                "select id, Date as 出库时间 , contactId as 合同编号, orderId as 订单编号 ,company as 客户名称,project as 项目名称,product as 产品,stockName as 仓库,materialsId as 物料代码,materialsName as 物料名称,specification as 物料规格,unitNumber as 数量,unit as 单位 ,purchasingPrice as 单价,stockAmount as 金额 from OutStockDetial where contactId like '%",
                text,
                "%' and orderId like '%",
                text5,
                "%' and materialsName like '%",
                text2,
                "%' and specification like '%",
                text3,
                "%' and materialsId like '%",
                text4,
                "%' and state = 'N' order by Date DESC "
            });
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, scllContract.SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.dataGridView1.DataSource = dataTable;
            this.dataGridView1.Columns["id"].Visible = false;
            this.dataGridView1.ClearSelection();
            SqlConnection sqlConnection = new SqlConnection(scllContract.SQL);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = "select company as 客户名称,project as 项目名称, product as 产品  from OutStockDetial where contactId like '%" + text + "%' "
            }.ExecuteReader();
            bool flag = sqlDataReader.Read();
            if (flag)
            {
                this.XMMC.Text = sqlDataReader.GetString(1);
                this.CP.Text = sqlDataReader.GetString(2);
                this.KHMC.Text = sqlDataReader.GetString(0);
            }
            sqlConnection.Close();
        }

        private void 下推ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(scllContract.SQL);
            string text = DateTime.Now.ToString("yyyy-MM-dd ");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            string text2 = this.dataGridView1.CurrentRow.Cells["id"].Value.ToString().Trim();
            string text3 = this.dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString().Trim();
            string text4 = this.dataGridView1.CurrentRow.Cells["订单编号"].Value.ToString().Trim();
            string text5 = this.dataGridView1.CurrentRow.Cells["客户名称"].Value.ToString().Trim();
            string text6 = this.dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString().Trim();
            string text7 = this.dataGridView1.CurrentRow.Cells["产品"].Value.ToString().Trim();
            string text8 = this.dataGridView1.CurrentRow.Cells["仓库"].Value.ToString().Trim();
            string text9 = this.dataGridView1.CurrentRow.Cells["物料代码"].Value.ToString().Trim();
            string text10 = this.dataGridView1.CurrentRow.Cells["物料名称"].Value.ToString().Trim();
            string text11 = this.dataGridView1.CurrentRow.Cells["物料规格"].Value.ToString().Trim();
            string text12 = this.dataGridView1.CurrentRow.Cells["数量"].Value.ToString().Trim();
            string text13 = this.dataGridView1.CurrentRow.Cells["单位"].Value.ToString().Trim();
            string text14 = this.dataGridView1.CurrentRow.Cells["单价"].Value.ToString().Trim();
            string text15 = this.dataGridView1.CurrentRow.Cells["金额"].Value.ToString().Trim();
            sqlCommand.CommandText = string.Concat(new string[]
            {
                "insert into linliaodan  (orderId,contactId,company,project,product,stockName,materialsId,materialsName,specification,unit,unitNumber,purchasingPrice,stockAmount,state,xtDate) VALUES ('",
                text4,
                "','",
                text3,
                "','",
                text5,
                "','",
                text6,
                "','",
                text7,
                "','",
                text8,
                "','",
                text9,
                "','",
                text10,
                "','",
                text11,
                "','",
                text13,
                "','",
                text12,
                "','",
                text14,
                "','",
                text15,
                "','N','",
                text,
                "')"
            });
            sqlCommand.ExecuteNonQuery();
            try
            {
                sqlCommand.CommandText = string.Concat(new string[]
                {
                    "update OutStockDetial set state = 'Y',xtDate =  '",
                    text,
                    "' where id = '",
                    text2,
                    "'"
                });
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.button4.PerformClick();
            sqlConnection.Close();
            this.button5.PerformClick();
        }

        private void 批量下推ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = this.dataGridView1.Rows.Count > 0;
            if (flag)
            {
                bool flag2 = MessageBox.Show("是否下推所选择的申请？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK;
                if (flag2)
                {
                    string text = DateTime.Now.ToString("yyyy-MM-dd ");
                    for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                    {
                        int index = this.dataGridView1.SelectedRows[i].Index;
                        string text2 = this.dataGridView1.Rows[index].Cells["id"].Value.ToString().Trim();
                        SqlConnection sqlConnection = new SqlConnection(scllContract.SQL);
                        sqlConnection.Open();
                        SqlCommand sqlCommand = sqlConnection.CreateCommand();
                        string text3 = this.dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString().Trim();
                        string text4 = this.dataGridView1.CurrentRow.Cells["订单编号"].Value.ToString().Trim();
                        string text5 = this.dataGridView1.CurrentRow.Cells["客户名称"].Value.ToString().Trim();
                        string text6 = this.dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString().Trim();
                        string text7 = this.dataGridView1.CurrentRow.Cells["产品"].Value.ToString().Trim();
                        string text8 = this.dataGridView1.CurrentRow.Cells["仓库"].Value.ToString().Trim();
                        string text9 = this.dataGridView1.CurrentRow.Cells["物料代码"].Value.ToString().Trim();
                        string text10 = this.dataGridView1.CurrentRow.Cells["物料名称"].Value.ToString().Trim();
                        string text11 = this.dataGridView1.CurrentRow.Cells["物料规格"].Value.ToString().Trim();
                        string text12 = this.dataGridView1.CurrentRow.Cells["数量"].Value.ToString().Trim();
                        string text13 = this.dataGridView1.CurrentRow.Cells["单位"].Value.ToString().Trim();
                        string text14 = this.dataGridView1.CurrentRow.Cells["单价"].Value.ToString().Trim();
                        string text15 = this.dataGridView1.CurrentRow.Cells["金额"].Value.ToString().Trim();
                        sqlCommand.CommandText = string.Concat(new string[]
                        {
                            "insert into linliaodan  (orderId,contactId,company,project,product,stockName,materialsId,materialsName,specification,unit,unitNumber,purchasingPrice,stockAmount,state,xtDate) VALUES ('",
                            text4,
                            "','",
                            text3,
                            "','",
                            text5,
                            "','",
                            text6,
                            "','",
                            text7,
                            "','",
                            text8,
                            "','",
                            text9,
                            "','",
                            text10,
                            "','",
                            text11,
                            "','",
                            text13,
                            "','",
                            text12,
                            "','",
                            text14,
                            "','",
                            text15,
                            "','N','",
                            text,
                            "')"
                        });
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.CommandText = string.Concat(new string[]
                        {
                            "update OutStockDetial set state = 'Y', xtDate = '",
                            text,
                            "' where id = '",
                            text2,
                            "'"
                        });
                        int num = sqlCommand.ExecuteNonQuery();
                        bool flag3 = num == 0;
                        if (flag3)
                        {
                            MessageBox.Show("下推失败");
                        }
                        sqlConnection.Close();
                    }
                    this.button4.PerformClick();
                }
            }
            this.button5.PerformClick();
        }

        // Token: 0x0600076D RID: 1901 RVA: 0x00100759 File Offset: 0x000FE959
        private void scllContract_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
        }

        // Token: 0x0600076E RID: 1902 RVA: 0x00100769 File Offset: 0x000FE969
        private void scllContract_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

        // Token: 0x0600076F RID: 1903 RVA: 0x0010077C File Offset: 0x000FE97C
        private void DY_Click(object sender, EventArgs e)
        {
            bool flag = this.printDialog1.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                this.printDocument1.Print();
            }
        }

        // Token: 0x06000770 RID: 1904 RVA: 0x001007AC File Offset: 0x000FE9AC
        private void button5_Click(object sender, EventArgs e)
        {
            string str = this.textBox6.Text.Trim();
            string selectCommandText = "select id, xtDate as 下推时间 , contactId as 合同编号, orderId as 订单编号 ,company as 客户名称,project as 项目名称,product as 产品,stockName as 仓库,kuwei as 库位 ,materialsId as 物料代码,materialsName as 物料名称,specification as 物料规格,unitNumber as 数量,unit as 单位 ,remark as 备注 from linliaodan where contactId like '%" + str + "%' and state = 'N' order by xtDate DESC ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, scllContract.SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            this.dataGridView2.DataSource = dataTable;
            this.dataGridView2.Columns["id"].Visible = false;
        }

        // Token: 0x06000771 RID: 1905 RVA: 0x0010081F File Offset: 0x000FEA1F
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        // Token: 0x06000772 RID: 1906 RVA: 0x00100824 File Offset: 0x000FEA24
        private void BC_Click(object sender, EventArgs e)
        {
            string text = DateTime.Now.ToString("yyyy-MM-dd");
            string str = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.a = (this.DJBH.Text = "LLD" + str);
            this.b = (this.DJRQ.Text = text);
            SqlConnection sqlConnection = new SqlConnection(scllContract.SQL);
            int num = 0;
            sqlConnection.Open();
            foreach (object obj in ((IEnumerable)this.dataGridView2.Rows))
            {
                DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
                string text2 = dataGridViewRow.Cells["id"].Value.ToString();
                string cmdText = string.Concat(new string[]
                {
                    "update linliaodan set materialRequisitionId = '",
                    this.a,
                    "' , date = '",
                    this.b,
                    "',state = 'Y' where id = '",
                    text2,
                    "'"
                });
                SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                num = sqlCommand.ExecuteNonQuery();
            }
            bool flag = num <= 0;
            if (flag)
            {
                MessageBox.Show("保存失败！");
            }
            else
            {
                MessageBox.Show("保存成功！");
            }
            try
            {
                string text3 = this.dataGridView2.CurrentRow.Cells["库位"].Value.ToString();
                string text4 = this.dataGridView2.CurrentRow.Cells["物料代码"].Value.ToString();
                string cmdText2 = string.Concat(new string[]
                {
                    "update MaterialStock set kuwei = '",
                    text3,
                    "' where materialsId = '",
                    text4,
                    "'"
                });
                string cmdText3 = string.Concat(new string[]
                {
                    "update linliaodan set kuwei = '",
                    text3,
                    "' where materialsId = '",
                    text4,
                    "'"
                });
                SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
                SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
                sqlCommand2.ExecuteNonQuery();
                sqlCommand3.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            sqlConnection.Close();
        }

        // Token: 0x06000773 RID: 1907 RVA: 0x00100A8C File Offset: 0x000FEC8C
        private void button1_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }

        // Token: 0x06000774 RID: 1908 RVA: 0x00100A9B File Offset: 0x000FEC9B
        private void button2_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.ShowDialog();
        }

        // Token: 0x06000775 RID: 1909 RVA: 0x00100AAC File Offset: 0x000FECAC
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            this.button5.PerformClick();
            try
            {
                bool flag = this.dataGridView2.Rows.Count > 0;
                if (flag)
                {
                    int num = 5;
                    int num2 = 200;
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    Pen pen = new Pen(Color.Black, 1f);
                    Font font = new Font("楷体", 24f, FontStyle.Bold);
                    Font font2 = new Font("楷体", 12f, FontStyle.Bold);
                    Brush black = Brushes.Black;
                    string text = this.dataGridView2.CurrentRow.Cells["客户名称"].Value.ToString();
                    string s = text;
                    e.Graphics.DrawString("生产领料单", font, black, 305f, 50f);
                    e.Graphics.DrawString("单据编号：", font2, black, 10f, 110f);
                    e.Graphics.DrawString(this.DJBH.Text, font2, black, 90f, 110f);
                    e.Graphics.DrawString("领料用途：", font2, black, 10f, 130f);
                    e.Graphics.DrawString(s, font2, black, 90f, 130f);
                    e.Graphics.DrawString("日期：", font2, black, 600f, 110f);
                    e.Graphics.DrawString(this.DJRQ.Text, font2, black, 650f, 110f);
                    foreach (object obj in this.dataGridView2.Columns)
                    {
                        DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
                        bool flag2 = !dataGridViewColumn.Visible;
                        if (!flag2)
                        {
                            bool flag3 = dataGridViewColumn.HeaderText != "下推时间";
                            if (flag3)
                            {
                                bool flag4 = dataGridViewColumn.HeaderText != "订单编号";
                                if (flag4)
                                {
                                    bool flag5 = dataGridViewColumn.HeaderText != "客户名称";
                                    if (flag5)
                                    {
                                        bool flag6 = dataGridViewColumn.HeaderText != "项目名称";
                                        if (flag6)
                                        {
                                            bool flag7 = dataGridViewColumn.HeaderText != "产品";
                                            if (flag7)
                                            {
                                                bool flag8 = dataGridViewColumn.HeaderText != "领料单号";
                                                if (flag8)
                                                {
                                                    bool flag9 = dataGridViewColumn.HeaderText != "单位";
                                                    if (flag9)
                                                    {
                                                        bool flag10 = dataGridViewColumn.HeaderText != "日期";
                                                        if (flag10)
                                                        {
                                                            e.Graphics.DrawRectangle(pen, num, 150, 100, 550);
                                                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF((float)num, 150f, 80f, 50f), stringFormat);
                                                            num += 100;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    num = 5;
                    for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < this.dataGridView2.Columns.Count; j++)
                        {
                            bool flag11 = j == 2 || j == 7 || j == 8 || j == 9 || j == 10 || j == 11 || j == 12 || j == 14;
                            if (flag11)
                            {
                                e.Graphics.DrawRectangle(pen, num, num2, 100, 50);
                                e.Graphics.DrawString(this.dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF((float)num, (float)num2, 100f, 50f), stringFormat);
                                num += 100;
                            }
                        }
                        num = 5;
                        num2 += 50;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Token: 0x06000776 RID: 1910 RVA: 0x00100F40 File Offset: 0x000FF140
        private void button3_Click(object sender, EventArgs e)
        {
            this.button5.PerformClick();
        }

        // Token: 0x040012C3 RID: 4803
        
    }
}
