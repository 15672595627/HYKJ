using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1.Bill;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.PO;

using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1.Scheduling
{
    public partial class kucunyanzheng : Form
    {
        public kucunyanzheng()
        {
            this.InitializeComponent();
        }


        private SqlDataAdapter da;
        private DataTable dt;

        private SqlDataAdapter da1;
        private DataTable dt1;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        public string User { get; set; }

        public string Group { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.txtId.Text.Trim();
            string text2 = this.txtName.Text.Trim();
            string text3 = this.txtGg.Text.Trim();
            string ckmc = comCkmc.Text.Trim();
            string selectCommandText = string.Concat(new string[]
            {
                "select id, materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,auxiliarysign as 助记号,stockId as 仓库代码,stockName as 仓库名称 , sl as 数量,unitNumber as 库存数量,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注,purchasingPrice as 最新进价 ,stockAmount as 库存金额,state as 下推状态 from MaterialStock where materialsId like '%",
                text,
                "%' and materialsName like '%",
                text2,
                "%' and specification like '%",
                text3,
                "%' and state = 'N' and stockName like '%"+ckmc+"%'"
            });
            da = new SqlDataAdapter(selectCommandText, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            //this.dataGridView1.Columns["下推状态"].Visible = false;
        }

        private void txtHtbh_TextChanged(object sender, EventArgs e)
        {
            /*ContractH contractH = new ContractH();
            contractH.Show();*/
        }
        private void txtHtbh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ContractH contractH = new ContractH();
            contractH.Show(this);
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*string str = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            string selectCommandText = "select id, materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,auxiliarysign as 助记号,stockId as 仓库代码,stockName as 仓库名称 ,sl as 数量 ,unitNumber as 库存数量,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注,purchasingPrice as 最新进价 ,stockAmount as 库存金额 from MaterialStock where id = '" + str + "'";
            da = new SqlDataAdapter(selectCommandText,SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = this.dt;
            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.Rows[0].Selected = true;*/
        }

        private void kucunyanzheng_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string asa = DateTime.Now.ToString("yyMMddhhmmss");
            textBox1.Text = "LLD" + asa;
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void 下推ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = DateTime.Now.ToString("yyyy-MM-dd");
            string text2 = txtDdbh.Text.Trim();
            string text3 = txtHtbh.Text.Trim();
            string text4 = txtGsm.Text.Trim();
            string text5 = txtXm.Text.Trim();
            decimal wsje = Convert.ToDecimal(txtWsje.Text.Trim());
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int m = dataGridView1.SelectedRows[i].Index;
                string id = dataGridView1.Rows[m].Cells["id"].Value.ToString();
                string text8 = dataGridView1.Rows[m].Cells["物料代码"].Value.ToString();
                string text9 = dataGridView1.Rows[m].Cells["物料名称"].Value.ToString();
                string text10 = dataGridView1.Rows[m].Cells["规格型号"].Value.ToString();
                string text11 = dataGridView1.Rows[m].Cells["仓库名称"].Value.ToString();
                string text12 = dataGridView1.Rows[m].Cells["单位"].Value.ToString();
                int sl = Convert.ToInt32(dataGridView1.Rows[m].Cells["数量"].Value.ToString());
                int d = Convert.ToInt32(dataGridView1.Rows[m].Cells["库存数量"].Value.ToString());
                //decimal d2 = Convert.ToInt32(textBox6.Text.Trim());
                decimal text13 = Convert.ToDecimal(dataGridView1.Rows[m].Cells["最新进价"].Value.ToString());
                string text14 = dataGridView1.Rows[m].Cells["库存金额"].Value.ToString();
                SqlConnection sqlConnection = new SqlConnection(kucunyanzheng.SQL);
                sqlConnection.Open();
                /*SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "update MaterialStock set state = 'Y'where id = '" + id + "'";
                int num = sqlCommand.ExecuteNonQuery();
                bool flag = num == 0;
                if (flag)
                {
                    MessageBox.Show("下推失败");
                }*/
                SqlCommand sqlCommand1 = sqlConnection.CreateCommand();
                sqlCommand1.CommandText = "INSERT INTO OutStockDetial (Date,orderId,contactId,company,project,wsje,stockName,materialsId,materialsName,specification,unit,sl,unitNumber,purchasingPrice,stockAmount,state,zdy) VALUES ('" + text + "','" + text2 + "','" + text3 + "','" + text4 + "','" + text5 + "','" + wsje + "','" + text11 + "','" + text8 + "','" + text9 + "','" + text10 + "','" + text12 + "','" + sl + "','" + d + "','" + text13 + "','" + text14 + "','Y','"+User+"')";
                int num1 = sqlCommand1.ExecuteNonQuery();
                if (num1 == 0)
                {
                    MessageBox.Show("下推失败");
                }
                sqlConnection.Close();
            }
            this.button1.PerformClick();
            this.button3.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string selectCommandText = "select id, contactId as 合同编号,materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,stockId as 仓库代码,stockName as 仓库名称  ,sl as 出库数量,unitNumber as 库存数量,unit as 单位,kuwei as 库位,weight as 重量数量,weightUnit as 重量单位,remark as 备注,purchasingPrice as 最新进价 ,stockAmount as 库存金额 from OutStockDetial where state = 'Y'";
            da1 = new SqlDataAdapter(selectCommandText, SQL);
            dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            dataGridView2.Columns["id"].Visible = false;
            
        }
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string text = DateTime.Now.ToString("yyyy-MM-dd");
            string text2 = txtDdbh.Text.Trim();
            string text3 = txtHtbh.Text.Trim();
            string text4 = txtGsm.Text.Trim();
            string text5 = txtXm.Text.Trim();
            string text6 = txtWsje.Text.Trim();
            SqlConnection sqlConnection = new SqlConnection(SQL);
            sqlConnection.Open();
            try
            {
                for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
                {

                    int m = dataGridView2.SelectedRows[i].Index;
                    string id = dataGridView2.Rows[m].Cells["id"].Value.ToString();
                    string text11 = dataGridView2.Rows[m].Cells["仓库名称"].Value.ToString();
                    string text12 = dataGridView2.Rows[m].Cells["单位"].Value.ToString();
                    string wldl = dataGridView2.Rows[m].Cells["物料代码"].Value.ToString();
                    string text9 = dataGridView2.Rows[m].Cells["物料名称"].Value.ToString();
                    string text10 = dataGridView2.Rows[m].Cells["规格型号"].Value.ToString();
                    int sl = Convert.ToInt32(dataGridView2.Rows[m].Cells["出库数量"].Value);
                    int d = Convert.ToInt32(dataGridView2.Rows[m].Cells["库存数量"].Value);
                    decimal text13 = Convert.ToDecimal(dataGridView2.Rows[m].Cells["最新进价"].Value);
                    string text14 = dataGridView2.Rows[m].Cells["库存金额"].Value.ToString();
                    
                    int sl1 = sl;
                    int kcsl = d - sl;
                    decimal newje = kcsl * text13;
                    if(sl < d)
                    {
                        SqlCommand cmd = sqlConnection.CreateCommand();
                        cmd.CommandText = "update MaterialStock set  unitNumber = '" + kcsl + "',stockAmount = '" + newje + "'where materialsId = '" + wldl + "'";
                        cmd.ExecuteNonQuery();

                        SqlCommand cmd1 = sqlConnection.CreateCommand();
                        cmd1.CommandText = "update OutStockDetial set sl = '" + sl1 + "',unitNumber = '" + kcsl + "',stockAmount = '" + newje + "'where materialsId = '" + wldl + "'";
                        cmd1.ExecuteNonQuery();
                    }
                    if (sl > d)
                    {
                        MessageBox.Show("该 '"+wldl+"' 仓库库存不够，无法领料，系统已经自动生成采购申请单");
                        //string str = "insert into ";
                    }
                    /*SqlCommand sqlCommand1 = sqlConnection.CreateCommand();
                    sqlCommand1.CommandText = "INSERT INTO OutStockDetial (Date,orderId,contactId,company,project,product,stockName,materialsId,materialsName,specification,unit,sl,unitNumber,purchasingPrice,stockAmount) VALUES ('" + text + "','" + text2 + "','" + text3 + "','" + text4 + "','" + text5 + "','" + text6 + "','" + text11 + "','" + wldl + "','" + text9 + "','" + text10 + "','" + text12 + "','" + sl1 + "','" + kcsl + "','" + text13 + "','" + newje + "')";
                    sqlCommand1.ExecuteNonQuery();*/
                }
            }
            catch (Exception)
            {

                throw;
            }finally
            { sqlConnection.Close(); }
            
        }
        private void btnBc_Click(object sender, EventArgs e)
        {
            
            button3.PerformClick();
            string text = DateTime.Now.ToString("yyyy-MM-dd");
            string text2 = txtDdbh.Text.Trim();
            string text3 = txtHtbh.Text.Trim();
            string gsmc = txtGsm.Text.Trim();
            string xmmc = txtXm.Text.Trim();
            string text6 = txtWsje.Text.Trim();
            string kw = txtkw.Text.Trim();
            string ss = DateTime.Now.ToString("yyyy-MM-dd");
            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
                {
                    
                    string id = dataGridView2.Rows[i].Cells["id"].Value.ToString();
                    string htbh = dataGridView2.Rows[i].Cells["合同编号"].Value.ToString();
                    string wldm = dataGridView2.Rows[i].Cells["物料代码"].Value.ToString();
                    string wlmc = dataGridView2.Rows[i].Cells["物料名称"].Value.ToString();
                    string ggxh = dataGridView2.Rows[i].Cells["规格型号"].Value.ToString();
                    string ckmc = dataGridView2.Rows[i].Cells["仓库名称"].Value.ToString();
                    string dw = dataGridView2.Rows[i].Cells["单位"].Value.ToString();
                    int sl = Convert.ToInt32(dataGridView2.Rows[i].Cells["出库数量"].Value.ToString());
                    int d = Convert.ToInt32(dataGridView2.Rows[i].Cells["库存数量"].Value.ToString());
                    //decimal d2 = Convert.ToInt32(textBox6.Text.Trim());
                    decimal zxjj = Convert.ToDecimal(dataGridView2.Rows[i].Cells["最新进价"].Value.ToString());
                    string kcje = dataGridView2.Rows[i].Cells["库存金额"].Value.ToString();
                    decimal je = sl * zxjj;
                    /*int kcsl = d - sl;
                    decimal newje = kcsl * text13;*/
                    SqlConnection sqlConnection = new SqlConnection(SQL);
                    sqlConnection.Open();
                    string cmdText = string.Concat(new string[]
                    {
                            "update OutStockDetial set state = 'N' "
                    });
                    SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                    sqlCommand.ExecuteNonQuery();

                    if (sl < d)
                    {
                        string addLld = "insert into linliaodan (materialRequisitionId,contactId,company,project,wsje,materialsId,materialsName,specification,unit,sl,unitNumber,ll,zd,je,stockAmount,date,kuwei,stockName,state)Values('" + textBox1.Text + "','" + htbh + "','" + txtGsm.Text + "','" + txtXm.Text + "','" + txtWsje.Text + "','" + wldm + "','" + wlmc + "','" + ggxh + "','" + dw + "','" + sl + "','" + d + "','" + txtLl.Text + "','" + User + "','" + je + "','" + kcje + "','" + ss + "','" + kw + "','" + ckmc + "','已审核')";
                        SqlCommand cmd = new SqlCommand(addLld, sqlConnection);
                        cmd.ExecuteNonQuery();
                        //更新到出库明细表
                        /* SqlCommand sqlCommand1 = sqlConnection.CreateCommand();
                         sqlCommand1.CommandText = "INSERT INTO OutStockDetial (Date,orderId,contactId,company,project,product,stockName,materialsId,materialsName,specification,unit,sl,unitNumber,purchasingPrice,stockAmount) VALUES ('" + text + "','" + text2 + "','" + text3 + "','" + text4 + "','" + text5 + "','" + text6 + "','" + text11 + "','" + text8 + "','" + text9 + "','" + text10 + "','" + text12 + "','" + sl + "','" + d + "','" + text13 + "','" + text14 + "')";
                         sqlCommand1.ExecuteNonQuery();*/

                        sqlConnection.Close();
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                    //更新库存和更新金额
                   
                    /* try
                     {
                         bool flag = d > d2;
                         if (flag)
                         {
                             decimal num = d - d2;
                             SqlConnection sqlConnection = new SqlConnection(kucunyanzheng.SQL);
                             sqlConnection.Open();
                             string cmdText = string.Concat(new string[]
                             {
                             "update MaterialStock set unitNumber = '"+d+"',state = 'N' where id ='"+text7+"'"
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
                     }*/
                }
            }
            
            
            button3.PerformClick();
        }

        private void kucunyanzheng_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            button3.PerformClick();
            try
            {
                bool flag = dataGridView2.Rows.Count > 0;
                if (flag)
                {
                    string htbh = dataGridView2.CurrentRow.Cells["合同编号"].Value.ToString();
                    string rq = DateTime.Now.ToString("yyyy-MM-dd");
                    int num = 50;
                    int num1 = 200;
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    Pen pen = new Pen(Color.Black, 1f);
                    Font font = new Font("楷体", 24f, FontStyle.Bold);
                    Font font2 = new Font("楷体", 12f, FontStyle.Bold);
                    Brush black = Brushes.Black;
                    e.Graphics.DrawString("生产领料单", font, black, 330f, 50f);
                    e.Graphics.DrawString("单号：", font2, black, 30f, 80f);
                    e.Graphics.DrawString(textBox1.Text, font2, black, 80f, 80f);
                    e.Graphics.DrawString("日期：", font2, black, 50f, 110f);
                    e.Graphics.DrawString(rq, font2, black, 100f, 110f);
                    e.Graphics.DrawString("领料用途：", font2, black, 50f, 130f);
                    e.Graphics.DrawString(htbh+txtLlyt.Text, font2, black, 130f, 130f);
                    e.Graphics.DrawString("领料部门：", font2, black, 650f, 110f);
                    e.Graphics.DrawString(txtLlbm.Text, font2, black, 730f, 110f);
                    /*e.Graphics.DrawString("审核：", font2, black, 50f, 760f);
                    e.Graphics.DrawString(txtJz.Text, font2, black, 110f, 760f);*/
                    
                    foreach (var item in dataGridView2.Columns)
                    {
                        DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)item;
                        if (dataGridViewColumn.HeaderText == "物料名称")
                        {
                            e.Graphics.DrawRectangle(pen, 50, 170, 220, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(120, 160f, 80f, 50f), stringFormat);
                        }
                        if (dataGridViewColumn.HeaderText == "规格型号")
                        {
                            e.Graphics.DrawRectangle(pen, 270, 170, 120, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(270, 160f, 80f, 50f), stringFormat);
                        }
                        if (dataGridViewColumn.HeaderText == "出库数量")
                        {
                            e.Graphics.DrawRectangle(pen, 390, 170, 120, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(390, 160f, 80f, 50f), stringFormat);
                        }
                        if (dataGridViewColumn.HeaderText == "单位")
                        {
                            e.Graphics.DrawRectangle(pen, 510, 170, 60, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(500, 160f, 80f, 50f), stringFormat);
                        }
                        if (dataGridViewColumn.HeaderText == "备注")
                        {
                            e.Graphics.DrawRectangle(pen, 570, 170, 200, 70);
                            e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(630, 160f, 80f, 50f), stringFormat);
                        }
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            if (j == 3)
                            {
                                e.Graphics.DrawRectangle(pen, 50, num1, 220, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(50f, (float)num1, 200f, 50f), stringFormat);
                            }
                            if (j == 4)
                            {
                                e.Graphics.DrawRectangle(pen, 270, num1, 120, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(270f, (float)num1, 100f, 50f), stringFormat);
                            }
                            if (j == 7)
                            {
                                e.Graphics.DrawRectangle(pen, 390, num1, 120, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(390f, (float)num1, 100f, 50f), stringFormat);
                            }
                            if (j == 9)
                            {
                                e.Graphics.DrawRectangle(pen, 510, num1, 60, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(490f, (float)num1, 100f, 50f), stringFormat);
                            }
                            if (j == 13)
                            {
                                e.Graphics.DrawRectangle(pen, 570, num1, 200, 40);
                                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF(570f, (float)num1, 100f, 50f), stringFormat);
                            }
                        }
                        num1 += 40;
                    }
                    e.Graphics.DrawString("记账：", font2, black, 50f, num1 + 10);
                    e.Graphics.DrawString(txtJz.Text, font2, black, 100f, num1 + 10);
                    e.Graphics.DrawString("领料：", font2, black, 220f, num1 + 10);
                    e.Graphics.DrawString(txtLl.Text, font2, black, 270f, num1 + 10);
                    e.Graphics.DrawString("制单：", font2, black, 650f, num1 + 10);
                    e.Graphics.DrawString(User, font2, black, 700f, num1 + 10);
                    /*foreach (object obj in dataGridView2.Columns)
                    {
                        DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
                        bool flag2 = !dataGridViewColumn.Visible;
                        if (!flag2)
                        {
                            bool flag3 = dataGridViewColumn.HeaderText != "合同编号";
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
                                                                    e.Graphics.DrawRectangle(pen, num, 170, 120, 70);
                                                                    e.Graphics.DrawString(dataGridViewColumn.HeaderText, new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF((float)num, 170f, 80f, 50f), stringFormat);
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
                    num = 50;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            if (j == 3 || j == 4 || j == 7 || j == 9 || j == 13)
                            {
                                e.Graphics.DrawRectangle(pen, num, num2, 120, 40);
                                e.Graphics.DrawString(this.dataGridView2.Rows[i].Cells[j].Value.ToString(), new Font("楷体", 12f, FontStyle.Regular), Brushes.Black, new RectangleF((float)num, (float)num2, 120f, 40f), stringFormat);
                                num += 120;
                            }
                        }
                        num = 50;
                        num2 += 40;
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //button3.PerformClick();
            
            printPreviewDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool flag = this.printDialog1.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                printDocument1.Print();
            }
            //更新到领料单表
            
        }

        private void button6_Click(object sender, EventArgs e)
        { 
        }
    }
}
