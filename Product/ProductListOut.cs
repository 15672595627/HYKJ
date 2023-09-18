using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using WindowsFormsApp1.Class;
using System.Web;

namespace WindowsFormsApp1.Product
{
    public partial class ProductListOut : Form
    {
        public ProductListOut()
        {
            InitializeComponent();
        }
        public string Username1 { get; set; }
        public string Group1 { get; set; }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        DataTable dt;
        SqlDataAdapter da;


        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void SX_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string htbh = HTBH.Text.Trim();
            string gsm = GSMC.Text.Trim();
            string shzt = ZT.Text.Trim();
            string rq = RQ.Text.Trim();
            string rq1 = RQ1.Text.Trim();
            string strsql = "SELECT p.id,p.orderid as 单据编号,p.date as 单据日期,p.caiwuRiqi as 财务日期, p.staffout as 录单员,p.sorderid as 销售订单,p.contractid as 合同编号,p.service as 跟单员,p.seller as 业务员,p.company as 公司名,p.project as 项目名,p.Product as 产品,p.substance as 内容,p.sl as 数量,p.dw as 单位,p.kfdj as 客服单价,p.meters as 米数,p.kfje as 客服金额含税,p.tax as 税率,p.wscz as 无税产值,p.fhsl as 发货数量,p.fhamount as 发货金额,p.fhcbamount as 发货成本金额,p.shck as 收货仓库,p.sent as 已发数量,p.examine as 审核状态,o.examine as 财务审核 from ProductOut p LEFT JOIN Order_b o ON o.contractid = p.contractid where o.contractid = p.contractid and o.company = p.company and o.quantity = p.sl and o.project = p.project and o.price = p.kfdj and o.meters = p.meters and o.sub = p.substance and p.date BETWEEN '" + rq + "' and '" + rq1 + "' and p.contractid like '%" + htbh + "%' and  p.company like '%" + gsm + "%' and o.examine like '%" + shzt + "%'";
            da = new SqlDataAdapter(strsql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            decimal sum1 = 0;
            decimal sum2 = 0;
            decimal sum3 = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["无税产值"].Value);
                sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["发货金额"].Value);
                sum3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["发货成本金额"].Value);


                if (dataGridView1.Rows[i].Cells["审核状态"].Value.ToString() == "已审核")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                }


            }
            string ssum1 = sum1.ToString();
            string ssum2 = sum2.ToString();
            string ssum3 = sum3.ToString();

            string[] row = { "1", "合计", "", "", "", "", "", "", "", "", "", "", "", "0", "", "", "0", "0", "0", ssum1, "0", ssum2, ssum3, "0", "0", "0" , "0" };
            ((DataTable)dataGridView1.DataSource).Rows.Add(row);

            
        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string cpmc = dataGridView1.CurrentRow.Cells["产品"].Value.ToString();
                string nr = dataGridView1.CurrentRow.Cells["内容"].Value.ToString();
                
                SqlConnection con = new SqlConnection(SQL);
                //
                //修改应发数量，修改出库单审核状态
                //
                try
                {
                    con.Open();
                    decimal oldyf = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["已发数量"].Value);
                    decimal fhsl = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["发货数量"].Value);
                    decimal newyf = oldyf + fhsl;

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE ProductIn SET sent = '" + newyf + "' WHERE product = '" + cpmc + "' and substance = '" + nr + "'";
                    int cot = cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE ProductOut SET examine = '已审核' WHERE product = '" + cpmc + "' and substance = '" + nr + "'";
                    int cot1 = cmd.ExecuteNonQuery();

                    if (cot > 0 || cot1 > 0)
                    {
                        MessageBox.Show("审核成功");
                    }
                    else
                    {
                        MessageBox.Show("审核失败");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                //
                //修改库存数量金额
                //
                try
                {
                    con.Open();

                    string strsql = "select product,num from Stock where product = '" + cpmc + "' and sub = '" + nr + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    decimal oldkcsl = Convert.ToDecimal(dt.Rows[0][1]);

                    decimal fhsl = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["发货数量"].Value);

                    decimal newkcsl = oldkcsl - fhsl;


                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE Stock SET num = '" + newkcsl + "' WHERE product = '" + cpmc + "' and sub = '" + nr + "'";
                    int cot = cmd.ExecuteNonQuery();

                    if (cot > 0)
                    {
                        MessageBox.Show("库存修改成功");
                    }
                    else
                    {
                        MessageBox.Show("库存修改失败");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            SX.PerformClick();
            
        }

        private void 财务审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string cpmc = dataGridView1.CurrentRow.Cells["产品"].Value.ToString();
                string nr = dataGridView1.CurrentRow.Cells["内容"].Value.ToString();
                SqlConnection con = new SqlConnection(SQL);
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE ProductOut SET examine1 = '已审核' WHERE product = '" + cpmc + "' and substance = '" + nr + "'";
                    int cot1 = cmd.ExecuteNonQuery();

                    if (cot1 > 0)
                    {
                        MessageBox.Show("审核成功");
                    }
                    else
                    {
                        MessageBox.Show("审核失败");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            SX.PerformClick();
        }

        private void 反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string nr = dataGridView1.CurrentRow.Cells["内容"].Value.ToString();
                string cpmc = dataGridView1.CurrentRow.Cells["产品"].Value.ToString();
                SqlConnection con = new SqlConnection(SQL);
                //
                //修改应发数量，修改出库单审核状态
                //
                try
                {
                    con.Open();
                    string strsql = "select product,sent from ProductIn where product = '" + cpmc + "' and substance = '" + nr + "' ";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    decimal yfsl = Convert.ToDecimal(dt.Rows[0][1]);
                    decimal fhsl = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["发货数量"].Value);
                    decimal newyf = yfsl - fhsl;

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE ProductIn SET sent = '" + newyf + "' WHERE product = '" + cpmc + "' and substance = '" + nr + "'";
                    int cot = cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE ProductOut SET examine = '未审核' WHERE product = '" + cpmc + "' and substance = '" + nr + "'";
                    int cot1 = cmd.ExecuteNonQuery();

                    if (cot > 0 || cot1 > 0)
                    {
                        MessageBox.Show("反审核成功");

                    }
                    else
                    {
                        MessageBox.Show("反审核失败");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                //
                //修改库存数量金额
                //
                try
                {

                    con.Open();
                    string strsql = "select product,num from Stock where product = '" + cpmc + "' and sub = '" + nr + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    decimal aa = Convert.ToDecimal(dt.Rows[0][1]);

                    decimal fhsl = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["发货数量"].Value);

                    decimal kcsl = aa + fhsl;


                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE Stock SET num = '" + kcsl + "' WHERE product = '" + cpmc + "' and sub = '" + nr + "'";
                    int cot = cmd.ExecuteNonQuery();

                    if (cot > 0)
                    {
                        MessageBox.Show("库存修改成功");
                    }
                    else
                    {
                        MessageBox.Show("库存修改失败");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void 财务反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string cpmc = dataGridView1.CurrentRow.Cells["产品"].Value.ToString();
                string nr = dataGridView1.CurrentRow.Cells["内容"].Value.ToString();
                SqlConnection con = new SqlConnection(SQL);
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE ProductOut SET examine1 = '未审核' WHERE product = '" + cpmc + "' and substance = '" + nr + "'";
                    int cot1 = cmd.ExecuteNonQuery();

                    if (cot1 > 0)
                    {
                        MessageBox.Show("反审核成功");
                    }
                    else
                    {
                        MessageBox.Show("反审核失败");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.Columns["单据编号"].ReadOnly = true;
            dataGridView1.Columns["合同编号"].ReadOnly = true;
            dataGridView1.Columns["单据日期"].ReadOnly = true;
            dataGridView1.Columns["录单员"].ReadOnly = true;
            dataGridView1.Columns["跟单员"].ReadOnly = true;
            dataGridView1.Columns["业务员"].ReadOnly = true;
            BC.Enabled = true;
            删除ToolStripMenuItem.Enabled = true;
            粘贴ToolStripMenuItem.Enabled = true;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Execl files (*.xls)|*.xls";
                sfd.FilterIndex = 0;
                sfd.RestoreDirectory = true;
                sfd.CreatePrompt = true;
                sfd.Title = "Export Excel File";
                sfd.ShowDialog();

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName == "")
                    {
                        MessageBox.Show("请输入保存名");
                        return;
                    }
                    else
                    {
                        Stream mystream = sfd.OpenFile();
                        StreamWriter sw = new StreamWriter(mystream, System.Text.Encoding.GetEncoding(-0));
                        string str = "";
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            if (i > 0)
                            {
                                str += "\t";
                            }
                            str += dataGridView1.Columns[i].HeaderText;
                        }
                        sw.WriteLine(str);
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            string tempStr = "";
                            for (int k = 0; k < dataGridView1.Columns.Count; k++)
                            {
                                if (k > 0)
                                {
                                    tempStr += "\t";
                                }
                                tempStr += dataGridView1.Rows[j].Cells[k].Value.ToString();
                            }
                            sw.WriteLine(tempStr);
                        }
                        sw.Close();
                        mystream.Close();
                    }
                }
            }*/
            
            string fileName = "";//可以在这里设置默认文件名
            string saveFileName = "";//文件保存名
            SaveFileDialog saveDialog = new SaveFileDialog();//实例化文件对象
            saveDialog.DefaultExt = "xlsx";//文件默认扩展名
            saveDialog.Filter = "Excel文件|*.xlsx";//获取或设置当前文件名筛选器字符串，该字符串决定对话框的“另存为文件类型”或“文件类型”框中出现的选择内容。
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();//打开保存窗口给你选择路径和设置文件名
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;//Workbooks代表一个 Microsoft Excel 工作簿
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);//新建一个工作表。 新工作表将成为活动工作表。
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
                                                                                                                                  //写入标题             
            for (int i = 0; i < dataGridView1.ColumnCount; i++)//遍历循环获取DataGridView标题
            { worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText; }// worksheet.Cells[1, i + 1]表示工作簿第一行第i+1列，Columns[i].HeaderText表示第i列的表头
            //写入数值
            for (int r = 0; r < dataGridView1.Rows.Count; r++)//这里表示数据的行标,dataGridView1.Rows.Count表示行数
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)//遍历r行的列数
                {
                    worksheet.Cells[r + 2, i + 1] = dataGridView1.Rows[r].Cells[i].Value;//Cells[r + 2, i + 1]表示工作簿从第二行开始第一行保存为表头了，dataGridView1.Rows[r].Cells[i].Value获取列的r行i值
                }
                System.Windows.Forms.Application.DoEvents();//实时更新表格
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);//提示保存成功
            if (saveFileName != "")//saveFileName保存文件名不为空
            {
                try
                {
                    workbook.Saved = true;//获取或设置一个值，该值指示工作簿自上次保存以来是否进行了更改
                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;将工作簿副本保存到文件中，但不修改内存中打开的工作簿                 
                }
                catch (Exception ex)
                {//fileSaved = false;                      
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁           
        }

    
    

        private void BC_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            MessageBox.Show("更新成功!");
            BC.Enabled = false;
            dataGridView1.ReadOnly = true;
            删除ToolStripMenuItem.Enabled = false;
            粘贴ToolStripMenuItem.Enabled = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void JZ_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string ts = "是否要结转" + RQ.Text.Trim() + "到" + RQ1.Text.Trim() + "的成本单价和金额";
                if (MessageBox.Show(ts, "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    try
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            string htbh = dataGridView1.Rows[i].Cells["合同编号"].Value.ToString();
                            string cpmc = dataGridView1.Rows[i].Cells["产品"].Value.ToString();
                            string nr = dataGridView1.Rows[i].Cells["内容"].Value.ToString();
                            decimal sl = Convert.ToDecimal(dataGridView1.Rows[i].Cells["发货数量"].Value);
                            string strsql = "select contractid,product,substance,cbdj from ProductIn where contractid = '" + htbh + "' and product = '" + cpmc + "' and substance = '" + nr + "'";
                            SqlDataAdapter da1 = new SqlDataAdapter(strsql, SQL);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            if(dt1.Rows.Count > 0)
                            {
                                decimal dj = Convert.ToDecimal(dt1.Rows[0][3]);
                                decimal je = sl * dj;
                                dataGridView1.Rows[i].Cells["发货成本金额"].Value = je;
                            }
                            else
                            {
                                continue;
                            }

                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    try
                    {
                        SqlCommandBuilder SCB1 = new SqlCommandBuilder(da);
                        da.Update(dt);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        MessageBox.Show("更新失败");
                        return;
                    }
                    MessageBox.Show("更新成功!");
                }
            }

        }

        private void JZ1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string ts = "是否要结转" + RQ.Text.Trim() + "到" + RQ1.Text.Trim() + "的出货的减库存金额。";
                if (MessageBox.Show(ts, "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    SqlConnection con = new SqlConnection(SQL);
                    con.Open();
                    try
                    {

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            string htbh = dataGridView1.Rows[i].Cells["合同编号"].Value.ToString();
                            string cpmc = dataGridView1.Rows[i].Cells["产品"].Value.ToString();
                            string nr = dataGridView1.Rows[i].Cells["内容"].Value.ToString();
                            decimal fhcbje = Convert.ToDecimal(dataGridView1.Rows[i].Cells["发货成本金额"].Value);
                            string strsql = "select product,amount from Stock where contractid = '" + htbh + "' and product = '" + cpmc + "' and sub = '" + nr + "'";
                            SqlDataAdapter da1 = new SqlDataAdapter(strsql, SQL);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            if(dt1.Rows.Count > 0)
                            {
                                decimal oldkcje = Convert.ToDecimal(dt1.Rows[0][1]);

                                decimal newkcje = oldkcje - fhcbje;


                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "UPDATE Stock SET amount = '" + newkcje + "' WHERE contractid = '" + htbh + "' and  product = '" + cpmc + "' and sub = '" + nr + "'";
                                int cot = cmd.ExecuteNonQuery();
                                if (cot == 0)
                                {
                                    string ms = cpmc + nr + "更新失败";
                                    MessageBox.Show(ms);
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            } 
                        }
                        MessageBox.Show("更新成功");

                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        MessageBox.Show("更新失败");
                        return;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void 批量审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = this.dataGridView1.Rows.Count > 0;
            if (flag)
            {
                SqlConnection sqlConnection = new SqlConnection(ProductListOut.SQL);
                try
                {
                    sqlConnection.Open();
                    for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                    {
                        int index = this.dataGridView1.SelectedRows[i].Index;
                        string text = this.dataGridView1.Rows[index].Cells["单据编号"].Value.ToString();
                        string text2 = this.dataGridView1.Rows[index].Cells["产品"].Value.ToString();
                        string text3 = this.dataGridView1.Rows[index].Cells["内容"].Value.ToString();
                        string text4 = this.dataGridView1.Rows[index].Cells["合同编号"].Value.ToString();
                        decimal d = Convert.ToDecimal(this.dataGridView1.Rows[index].Cells["已发数量"].Value);
                        decimal d2 = Convert.ToDecimal(this.dataGridView1.Rows[index].Cells["发货数量"].Value);
                        decimal num = d + d2;
                        SqlCommand sqlCommand = sqlConnection.CreateCommand();
                        sqlCommand.CommandText = string.Concat(new string[]
                        {
                            "UPDATE ProductIn SET sent = '",
                            num.ToString(),
                            "' WHERE contractid = '",
                            text4,
                            "' and product = '",
                            text2,
                            "' and substance = '",
                            text3,
                            "'"
                        });
                        int num2 = sqlCommand.ExecuteNonQuery();
                        sqlCommand.CommandText = string.Concat(new string[]
                        {
                            "UPDATE ProductOut SET examine = '已审核' WHERE product = '",
                            text2,
                            "' and orderid = '",
                            text,
                            "' and substance = '",
                            text3,
                            "'"
                        });
                        int num3 = sqlCommand.ExecuteNonQuery();
                        bool flag2 = num2 == 0 || num3 == 0;
                        if (flag2)
                        {
                            MessageBox.Show("审核失败");
                        }
                    }
                    MessageBox.Show("审核成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
                try
                {
                    sqlConnection.Open();
                    for (int j = 0; j < this.dataGridView1.SelectedRows.Count; j++)
                    {
                        int index2 = this.dataGridView1.SelectedRows[j].Index;
                        string text5 = this.dataGridView1.Rows[index2].Cells["单据编号"].Value.ToString();
                        string text6 = this.dataGridView1.Rows[index2].Cells["产品"].Value.ToString();
                        string text7 = this.dataGridView1.Rows[index2].Cells["内容"].Value.ToString();
                        string text8 = this.dataGridView1.Rows[index2].Cells["合同编号"].Value.ToString();
                        string selectCommandText = string.Concat(new string[]
                        {
                            "select * from Stock where contractid = '",
                            text8,
                            "' and product = '",
                            text6,
                            "' and sub = '",
                            text7,
                            "'"
                        });
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, ProductListOut.SQL);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        decimal d3 = Convert.ToDecimal(dataTable.Rows[0][7]);
                        decimal d4 = Convert.ToDecimal(this.dataGridView1.Rows[index2].Cells["发货数量"].Value);
                        decimal num4 = d3 - d4;
                        SqlCommand sqlCommand2 = sqlConnection.CreateCommand();
                        sqlCommand2.CommandText = string.Concat(new string[]
                        {
                            "UPDATE Stock SET num = '",
                            num4.ToString(),
                            "' WHERE contractid = '",
                            text8,
                            "' and product = '",
                            text6,
                            "' and sub = '",
                            text7,
                            "'"
                        });
                        int num5 = sqlCommand2.ExecuteNonQuery();
                        bool flag3 = num5 == 0;
                        if (flag3)
                        {
                            string text9 = text6 + text7 + "失败";
                        }
                    }
                    MessageBox.Show("成功");
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void XZL_Click(object sender, EventArgs e)
        {

        }

        private void ProductListOut_Load(object sender, EventArgs e)
        {
            RQ.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(0);
            RQ1.Value = DateTime.Now;
            asc.controllInitializeSize(this);
        }

        private void ProductListOut_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (Group1 == "财务部" || Group1 == "Administrators")
            {
                try
                {
                    /*int index = dataGridView1.CurrentRow.Index;
                    a = new string[dataGridView1.ColumnCount];
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        a[i] = dataGridView1.Rows[index].Cells[i].Value.ToString();
                    }*/
                    productOutUpdate productOutUpdate = new productOutUpdate();
                    productOutUpdate.Username = Username1;
                    productOutUpdate.Group = Group1;
                    string aa = dataGridView1.CurrentRow.Cells["单据日期"].Value.ToString();
                    string bb = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString();
                    string cc = dataGridView1.CurrentRow.Cells["销售订单"].Value.ToString();
                    string dd = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
                    productOutUpdate.djrq = aa;
                    productOutUpdate.djId = bb;
                    productOutUpdate.xsId = cc;
                    productOutUpdate.htId = dd;
                    productOutUpdate.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("对不起，你没有权限！");
            }
        }
    }
}
