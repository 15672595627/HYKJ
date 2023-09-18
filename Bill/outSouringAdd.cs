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
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.PO;

namespace WindowsFormsApp1.Bill
{
    public partial class outSouringAdd : Form
    {
        public outSouringAdd()
        {
            InitializeComponent();


        }
        public string User { get; set; }

        public string Group { get; set; }
        private SqlDataAdapter da = null;
        private DataTable dt = null;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FindSupply findSupply = new FindSupply();
            findSupply.Show(this);
        }
        string sj1 = DateTime.Now.ToString("yyyy-MM-dd");
        private void outSouringAdd_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string sj = DateTime.Now.ToString("yyMMddhhmmss");
            textBox5.Text = "CGRK" + sj;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select id, materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,stockName as 仓库名称 , sl as 入库数量,dj as 入库单价,unitNumber as 库存数量,je as 金额,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注,purchasingPrice as 最新进价 ,stockAmount as 库存金额 from MaterialStock where materialsId like '%"+textBox2.Text
                + "%' and materialsName like '%"+textBox3.Text+ "%' and specification like '%"+textBox4.Text+ "%' and stockName like '%"+comboBox1.Text+"%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["id"].Visible = false;
        }
        int cot = 0;
        private void 下推ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                
                int m = dataGridView1.SelectedRows[i].Index;
                string id = dataGridView1.Rows[m].Cells["id"].Value.ToString();
                string wldm = dataGridView1.Rows[m].Cells["物料代码"].Value.ToString();
                string wlmc = dataGridView1.Rows[m].Cells["物料名称"].Value.ToString();
                string ggxh = dataGridView1.Rows[m].Cells["规格型号"].Value.ToString();
                string ckmc = dataGridView1.Rows[m].Cells["仓库名称"].Value.ToString();
                int rksl = Convert.ToInt32(dataGridView1.Rows[m].Cells["入库数量"].Value);
                decimal rkdj = Convert.ToDecimal(dataGridView1.Rows[m].Cells["入库单价"].Value);
                decimal je = Convert.ToDecimal(dataGridView1.Rows[m].Cells["金额"].Value);
                int kcsl = Convert.ToInt32(dataGridView1.Rows[m].Cells["库存数量"].Value);
                string dw = dataGridView1.Rows[m].Cells["单位"].Value.ToString();
                string kw = dataGridView1.Rows[m].Cells["库位"].Value.ToString();
                string zlsl = dataGridView1.Rows[m].Cells["重量数量"].Value.ToString();
                string zldw = dataGridView1.Rows[m].Cells["重量单位"].Value.ToString();
                string bz = dataGridView1.Rows[m].Cells["备注"].Value.ToString();
                decimal zxjj = Convert.ToDecimal(dataGridView1.Rows[m].Cells["最新进价"].Value);
                decimal kcje = Convert.ToDecimal(dataGridView1.Rows[m].Cells["库存金额"].Value);

                string add = "insert into PutStockDetial (rky,bh,materialsId,materialsName,specification,stockName,sl,dj,je,unitNumber,unit,kuwei,weight,weightUnit,remark,purchasingPrice,stockAmount,gys,date,state)values" +
                    "('"+User+"','" + textBox5.Text + "','"+wldm+"','"+wlmc+"','"+ggxh+"','"+ckmc+"','"+rksl+"','"+rkdj+"','"+je+"','"+kcsl+"','"+dw+"','"+kw+"','"+zlsl+"','"+zldw+"','"+bz+"','"+zxjj+"','"+kcje+"','"+textBox1.Text+"','"+sj1+"','Y')";
                SqlCommand cmd1 = new SqlCommand(add,conn);
                cot = cmd1.ExecuteNonQuery();
            }
            if (cot < 1)
            {
                MessageBox.Show("下推失败");
            }
            else
            {
                MessageBox.Show("下推成功");
            }
            conn.Close();
            button2.PerformClick();
        }

        

        private void outSouringAdd_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "select id,bh as 编号, materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,stockName as 仓库名称 , sl as 入库数量,dj as 入库单价,unitNumber as 库存数量,je as 金额,unit as 单位,gys as 供应商,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注,purchasingPrice as 最新进价 ,stockAmount as 库存金额 from PutStockDetial where state = 'Y'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
            dataGridView2.Columns["id"].Visible = false;
            decimal sum0 = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                sum0 += Convert.ToInt32(dataGridView2.Rows[i].Cells["金额"].Value);
            }
            string suum0 = sum0.ToString();
            string[] row = { "1", "合计", "合计", "合计", "", "", "0", "0", "0", suum0, "", "", "", "", "", "", "0", "0"};
            ((DataTable)dataGridView2.DataSource).Rows.Add(row);
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
            {
                int m = dataGridView2.SelectedRows[i].Index;
                string id = dataGridView2.Rows[m].Cells["id"].Value.ToString();
                string wldm = dataGridView2.Rows[m].Cells["物料代码"].Value.ToString();
                int rksl = Convert.ToInt32(dataGridView2.Rows[m].Cells["入库数量"].Value);
                decimal rkdj = Convert.ToDecimal(dataGridView2.Rows[m].Cells["入库单价"].Value);
                int kcsl = Convert.ToInt32(dataGridView2.Rows[m].Cells["库存数量"].Value);
                decimal kcje = Convert.ToDecimal(dataGridView2.Rows[m].Cells["库存金额"].Value);
                //string id = dataGridView2.Rows[m].Cells["id"].Value.ToString();
                int sl = rksl;
                decimal dj = rkdj;
                decimal je = sl * dj;//金额
                decimal totalAmount = je + kcje;//总金额
                int totalNumber = kcsl + sl;//总数量
                decimal newdj = totalAmount / totalNumber;//最新进价

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update MaterialStock set  unitNumber = '" + totalNumber + "',stockAmount = '" + totalAmount + "',purchasingPrice = '"+ newdj + "'where materialsId = '" + wldm + "'";
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "update PutStockDetial set  sl = '" + sl + "',dj = '" + dj + "',je = '" + je + "',unitNumber = '"+ totalNumber + "',stockAmount = '"+ totalAmount + "',purchasingPrice = '"+ newdj + "'where materialsId = '" + wldm + "'";
                cmd1.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                SqlConnection sqlConnection = new SqlConnection(SQL);
                sqlConnection.Open();
                string str = "update PutStockDetial set state = 'N' ,examine = '已审核'";
                SqlCommand sqlCommand = new SqlCommand(str, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            button2.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button2.PerformClick();

            printPreviewDialog1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
            bool flag = this.printDialog1.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            button2.PerformClick();
            try
            {
                bool flag = dataGridView2.Rows.Count > 0;
                if (flag)
                {

                    string rq = DateTime.Now.ToString("yyyy-MM-dd");
                    int num1 = 200;
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    Pen pen = new Pen(Color.Black, 1f);
                    Font font = new Font("楷体", 24f, FontStyle.Bold);
                    Font font2 = new Font("楷体", 12f, FontStyle.Bold);
                    Brush black = Brushes.Black;
                    e.Graphics.DrawString("华禹科技采购入库单", font, black, 245f, 50f);
                    e.Graphics.DrawString("供应商：", font2, black, 100f, 110f);
                    e.Graphics.DrawString(textBox1.Text, font2, black, 160f, 110f);
                    e.Graphics.DrawString("备注：", font2, black, 100f, 130f);
                    e.Graphics.DrawString(textBox6.Text, font2, black, 150f, 130f);
                    e.Graphics.DrawString("日期：", font2, black, 300f, 110f);
                    e.Graphics.DrawString(sj1, font2, black, 350f, 110f);
                    e.Graphics.DrawString("编号：", font2, black, 500f, 110f);
                    e.Graphics.DrawString(textBox5.Text, font2, black, 550f, 110f);
                    e.Graphics.DrawString("仓库：", font2, black, 500f, 130f);
                    e.Graphics.DrawString(comboBox1.Text, font2, black, 550f, 130f);
                    foreach (var item in dataGridView2.Columns)
                    {
                        DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)item;
                        if (dataGridViewColumn.HeaderText == "物料名称")
                        {
                            e.Graphics.DrawRectangle(pen, 100, 170, 220, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(170, 160f, 80f, 50f), stringFormat);
                        }
                        if (dataGridViewColumn.HeaderText == "规格型号")
                        {
                            e.Graphics.DrawRectangle(pen, 320, 170, 120, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(340, 160f, 80f, 50f), stringFormat);
                        }
                        if (dataGridViewColumn.HeaderText == "入库数量")
                        {
                            e.Graphics.DrawRectangle(pen, 440, 170, 80, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(440, 160f, 80f, 50f), stringFormat);
                        }
                        if (dataGridViewColumn.HeaderText == "入库单价")
                        {
                            e.Graphics.DrawRectangle(pen, 520, 170, 80, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(520, 160f, 80f, 50f), stringFormat);
                        }
                        if (dataGridViewColumn.HeaderText == "金额")
                        {
                            e.Graphics.DrawRectangle(pen, 600, 170, 60, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(590, 160f, 80f, 50f), stringFormat);
                        }
                        if (dataGridViewColumn.HeaderText == "单位")
                        {
                            e.Graphics.DrawRectangle(pen, 660, 170, 60, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(650, 160f, 80f, 50f), stringFormat);
                        }
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            if (j == 3)
                            {
                                e.Graphics.DrawRectangle(pen, 100, num1, 220, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(100f, (float)num1, 200f, 50f), stringFormat);
                            }
                            if (j == 4)
                            {
                                e.Graphics.DrawRectangle(pen, 320, num1, 120, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(320f, (float)num1, 100f, 50f), stringFormat);
                            }
                            if (j == 6)
                            {
                                e.Graphics.DrawRectangle(pen, 440, num1, 80, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(420f, (float)num1, 100f, 50f), stringFormat);
                            }
                            if (j == 7)
                            {
                                e.Graphics.DrawRectangle(pen, 520, num1, 80, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(500f, (float)num1, 100f, 50f), stringFormat);
                            }
                            if (j == 9)
                            {
                                e.Graphics.DrawRectangle(pen, 600, num1, 60, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(580f, (float)num1, 100f, 50f), stringFormat);
                            }
                            if (j == 10)
                            {
                                e.Graphics.DrawRectangle(pen, 660, num1, 60, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(640f, (float)num1, 100f, 50f), stringFormat);
                            }
                        }
                        num1 += 40;
                       
                    }
                    e.Graphics.DrawString("制单：", font2, black, 100f, num1+10);
                    e.Graphics.DrawString(User, font2, black, 150f, num1+10);
                    /*foreach (object obj in dataGridView2.Columns)
                           {
                               DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
                               bool flag2 = !dataGridViewColumn.Visible;
                               if (!flag2)
                               {
                                   bool flag3 = dataGridViewColumn.HeaderText != "编号";
                                   if (flag3)
                                   {
                                       bool flag4 = dataGridViewColumn.HeaderText != "物料代码";
                                       if (flag4)
                                       {
                                           bool flag5 = dataGridViewColumn.HeaderText != "仓库代码";
                                           if (flag5)
                                           {

                                               bool flag7 = dataGridViewColumn.HeaderText != "库存数量";
                                               if (flag7)
                                               {
                                                   bool flag8 = dataGridViewColumn.HeaderText != "最新进价";
                                                   if (flag8)
                                                   {
                                                       bool flag9 = dataGridViewColumn.HeaderText != "库存金额";
                                                       if (flag9)
                                                       {
                                                           bool flag10 = dataGridViewColumn.HeaderText != "库位";
                                                           if (flag10)
                                                           {
                                                               bool flag11 = dataGridViewColumn.HeaderText != "重量数量";
                                                               if (flag11)
                                                               {
                                                                   bool flag12 = dataGridViewColumn.HeaderText != "重量单位";
                                                                   if (flag12)
                                                                   {
                                                                       bool flag13 = dataGridViewColumn.HeaderText != "仓库名称";
                                                                       if (flag13)
                                                                       {
                                                                           bool flag14 = dataGridViewColumn.HeaderText != "供应商";
                                                                           if (flag14)
                                                                           {
                                                                               bool flag15 = dataGridViewColumn.HeaderText != "备注";
                                                                               if (flag15)
                                                                               {
                                                                                   e.Graphics.DrawRectangle(pen, num, 170, 120, 550);
                                                                                   e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF((float)num, 160f, 80f, 50f), stringFormat);
                                                                                   num += 120;
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
                                       }
                                   }
                               }
                           }
                           num = 50;
                           for (int i = 0; i < dataGridView2.Rows.Count; i++)
                           {
                               for (int j = 0; j < dataGridView2.Columns.Count; j++)
                               {
                                   if (j == 3 || j == 4 || j == 10 || j == 6 || j == 7 || j == 9)
                                   {
                                       e.Graphics.DrawRectangle(pen, num, num2, 120, 50);
                                       e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF((float)num, (float)num2, 100f, 50f), stringFormat);
                                       num += 120;
                                   }
                               }
                               num = 50;
                               num2 += 50;
                           }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
