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
using WindowsFormsApp1.Scheduling;

namespace WindowsFormsApp1.Stock
{
    public partial class updateStock : Form
    {
        public updateStock()
        {
            InitializeComponent();
        }
        string aaa ;
        private SqlDataAdapter da;
        private DataTable dt;

        private SqlDataAdapter da1;
        private DataTable dt1;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        public string con_user { get; set; }
        public string con_group { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            string ss = "SELECT  TOP 1 id,bh as 编号 FROM PutStockDetial ORDER BY bh DESC ";
            da1 = new SqlDataAdapter(ss, SQL);
            dt1 = new DataTable();
            da1.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string a = dt1.Rows[i]["编号"].ToString();
                string[] strArray = a.Split('K');
                string a1 = strArray[1];
                int a2 = Convert.ToInt32(a1);
                int a3 = a2 + 1;
                aaa = "WGRK" + a3.ToString();
            }
            bh.Text = aaa;
            string text = txtId.Text.Trim();
            string text2 = txtName.Text.Trim();
            string text3 = txtGg.Text.Trim();
            string text4 = comboBox1.Text.Trim();
            string str = "select id, materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,auxiliarysign as 助记号,stockId as 仓库代码,stockName as 仓库名称 ,sl as 数量,dj as 单价,je as 金额,unitNumber as 库存数量,purchasingPrice as 最新进价 ,stockAmount as 库存金额,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注 from MaterialStock where materialsId like '%" + text + "%' and materialsName like '%" + text2 + "%' and specification like '%" + text3 + "%' and stockName like '%" + text4 + "%' and state1 = 'Y'";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            decimal sum0 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum0 += Convert.ToInt32(dataGridView1.Rows[i].Cells["金额"].Value);
            }
            string suum0 = sum0.ToString();
            string[] row = { "1", "合计", "", "", "", "", "", "0", "0", suum0, "0", "0", "0", "", "", "", "", "" };
            ((DataTable)dataGridView1.DataSource).Rows.Add(row);
            
        }

        private void updateStock_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void updateStock_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
        int cot;
        int cot1;
        int cot2;
        

        private void txtId_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            findWlbm find = new findWlbm();
            find.Show(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
       
            string sj = DateTime.Now.ToString("yyyy-MM-dd");
            if(dataGridView1.Rows.Count>0)
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string id = dataGridView1.Rows[i].Cells["id"].Value.ToString().Trim();
                string wldm = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                string wlmc = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                string wlgg = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                string ckdm = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                string ckmc = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                int sl = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                decimal dj = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                decimal jine = Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                int kcsl = Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value);
                decimal zxjj = Convert.ToDecimal(dataGridView1.Rows[i].Cells[11].Value);
                decimal kcje = Convert.ToDecimal(dataGridView1.Rows[i].Cells[12].Value);
                string dw = dataGridView1.Rows[i].Cells[13].Value.ToString().Trim();
                string kw = dataGridView1.Rows[i].Cells[14].Value.ToString().Trim();
                string zl = dataGridView1.Rows[i].Cells[15].Value.ToString().Trim();
                string zldw = dataGridView1.Rows[i].Cells[16].Value.ToString().Trim();
                string bz = dataGridView1.Rows[i].Cells[17].Value.ToString().Trim();

                //金额
                decimal je = dj * sl;
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update MaterialStock set sl = '0',dj = '0', state1 = 'N' where id = '"+id+"'";
                cot2 = cmd.ExecuteNonQuery();

                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "INSERT INTO [dbo].[PutStockDetial] ([materialsId],[materialsName],[specification],[stockId],[stockName],[unitNumber],[unit],[weight],[weightUnit],[remark],[purchasingPrice],[stockAmount],[kuwei],date,[bh],sl,dj,je) VALUES ('" + wldm + "','" + wlmc + "','" + wlgg + "','" + ckdm + "','" + ckmc + "','" + kcsl + "','" + dw + "','" + zl + "','" + zldw + "','','" + zxjj + "','" + kcje + "','" + kw + "','" + sj + "','"+aaa+"','"+sl+"','"+dj+"','"+je+"')";
                cot1 = cmd1.ExecuteNonQuery();
                conn.Close();
            }
            if (cot2 < 0|| cot1<0)
            {
                MessageBox.Show("保存失败");
            }
            else
            {
                MessageBox.Show("保存成功");
            }
           
            button1.PerformClick();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int m = dataGridView1.SelectedRows[i].Index;
                string id = dataGridView1.Rows[m].Cells["id"].Value.ToString().Trim();
                string wldm = dataGridView1.Rows[m].Cells[1].Value.ToString().Trim();
                string wlmc = dataGridView1.Rows[m].Cells[2].Value.ToString().Trim();
                string wlgg = dataGridView1.Rows[m].Cells[3].Value.ToString().Trim();
                string ckdm = dataGridView1.Rows[m].Cells[5].Value.ToString().Trim();
                string ckmc = dataGridView1.Rows[m].Cells[6].Value.ToString().Trim();
                int sl = Convert.ToInt32(dataGridView1.Rows[m].Cells[7].Value);
                decimal dj = Convert.ToDecimal(dataGridView1.Rows[m].Cells[8].Value);
                decimal jine = Convert.ToDecimal(dataGridView1.Rows[m].Cells[9].Value);
                int kcsl = Convert.ToInt32(dataGridView1.Rows[m].Cells[10].Value);
                decimal zxjj = Convert.ToDecimal(dataGridView1.Rows[m].Cells[11].Value);
                decimal kcje = Convert.ToDecimal(dataGridView1.Rows[m].Cells[12].Value);
                string dw = dataGridView1.Rows[m].Cells[13].Value.ToString().Trim();
                string kw = dataGridView1.Rows[m].Cells[14].Value.ToString().Trim();
                string zl = dataGridView1.Rows[m].Cells[15].Value.ToString().Trim();
                string zldw = dataGridView1.Rows[m].Cells[16].Value.ToString().Trim();
                string bz = dataGridView1.Rows[m].Cells[17].Value.ToString().Trim();


                //拿到的库存表的金额
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                decimal amount = sl * dj;
                int TolSl = sl + kcsl;//更新后库存数量
                decimal JE = dj * sl + kcje;//更新后库存金额
                decimal jg = JE / TolSl;
                SqlCommand cmd = conn.CreateCommand();
                //库存金额为库存表当前剩余的金额+入库的金额。。。库存数量=当前库存剩余数量+入库数量。。。单价=库存金额/库存数量
                cmd.CommandText = "update MaterialStock set sl = '" + sl + "',dj = '" + dj + "',je = '" + amount + "',unitNumber = '" + TolSl + "',stockAmount = '" + JE + "',purchasingPrice = '" + jg + "' where id = '" + id + "'";
                cot = cmd.ExecuteNonQuery();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            button1.PerformClick();
            bh.Text = aaa;
            try
            {
                bool flag = dataGridView1.Rows.Count > 0;
                if (flag)
                {
                    string rq = DateTime.Now.ToString("yyyy-MM-dd");
                    int num = 50;
                    int num2 = 200;
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    Pen pen = new Pen(Color.Black, 1f);
                    Font font = new Font("楷体", 24f, FontStyle.Bold);
                    Font font2 = new Font("楷体", 12f, FontStyle.Bold);
                    Brush black = Brushes.Black;
                    e.Graphics.DrawString("华禹科技采购入库单", font, black, 245f, 50f);
                    e.Graphics.DrawString("供应商：", font2, black, 50f, 110f);
                    e.Graphics.DrawString(textBox1.Text, font2, black, 140f, 110f);
                    e.Graphics.DrawString("备注：", font2, black, 50f, 130f);
                    e.Graphics.DrawString(bz.Text, font2, black, 110f, 130f);
                    e.Graphics.DrawString("日期：", font2, black, 330f, 110f);
                    e.Graphics.DrawString(rq, font2, black, 380f, 110f);
                    e.Graphics.DrawString("编号：", font2, black, 650f, 110f);
                    e.Graphics.DrawString(bh.Text, font2, black, 700f, 110f);
                    e.Graphics.DrawString("仓库：", font2, black, 650f, 130f);
                    e.Graphics.DrawString(ckmc.Text, font2, black, 700f, 130f);
                    foreach (object obj in dataGridView1.Columns)
                    {
                        DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
                        bool flag2 = !dataGridViewColumn.Visible;
                        if (!flag2)
                        {
                            bool flag3 = dataGridViewColumn.HeaderText != "物料代码";
                            if (flag3)
                            {
                                bool flag4 = dataGridViewColumn.HeaderText != "助记号";
                                if (flag4)
                                {
                                    bool flag5 = dataGridViewColumn.HeaderText != "仓库代码";
                                    if (flag5)
                                    {
                                        bool flag6 = dataGridViewColumn.HeaderText != "仓库名称";
                                        if (flag6)
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
                                                                    bool flag13 = dataGridViewColumn.HeaderText != "备注";
                                                                    if (flag13)
                                                                    {
                                                                        e.Graphics.DrawRectangle(pen, num, 150, 120, 550);
                                                                        e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF((float)num, 150f, 80f, 50f), stringFormat);
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
                    num = 50;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (j == 2 || j == 3 ||  j == 7||j==8|| j == 9 || j==13)
                            {
                                e.Graphics.DrawRectangle(pen, num, num2, 120, 50);
                                e.Graphics.DrawString(dataGridView1.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF((float)num, (float)num2, 100f, 50f), stringFormat);
                                num += 120;
                            }
                        }
                        num = 50;
                        num2 += 50;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
            bool flag = printDialog1.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                printDocument1.Print();
            }
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            findSupply find = new findSupply();
            find.Show(this);
        }
    }
}
