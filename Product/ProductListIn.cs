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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace WindowsFormsApp1.Product
{
    public partial class ProductListIn : Form
    {
        public ProductListIn()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        DataTable dt;
        SqlDataAdapter da;

        DataTable dt1;
        SqlDataAdapter da1;

        DataTable dt2;
        SqlDataAdapter da2;

        DataTable dt3;
        SqlDataAdapter da3;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public string Username1 { get; set; }
        public string Group1 { get; set; }
        private void ProductListIn_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            RQ.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(-3); //'设置为本月第一天
            
        }

        private void SX_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            string htbh = HTBH.Text.Trim();
            string gsm = GSMC.Text.Trim();
            string shzt = ZT.Text.Trim();
            string rq = RQ.Text.Trim();
            string rq1 = RQ1.Text.Trim();
            string ck = CK.Text.Trim();
            string strsql = "SELECT id,orderid as 单据编号,date as 单据日期,caiwuRiqi as 财务日期,staffin as 录单员,sorderid as 销售订单,contractid as 合同编号,company as 公司名,project as 项目名,product as 产品名称,substance as 内容,sl as 数量,dw as 单位,kfdj as 客服单价,meters as 米数,kfje as 客服金额,tax as 税率,wscz as 无税产值,sssl as 实收数量,zsms as 折算米数,sjdj as 实际单价,shck as 收货仓库,cbdj as 成本单价, cbje as 成本金额,state as 状态,examine as 审核状态,cwsh as 财务审核 from ProductIn where  caiwuRiqi BETWEEN '" + rq + "' and '" + rq1 + "' and contractid like '%" + htbh + "%' and  company like '%" + gsm + "%' and cwsh like '%" + shzt + "%'  and  shck like '%" + ck + "%'";
            da = new SqlDataAdapter(strsql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            

            decimal sum1 = 0;
            decimal sum2 = 0;
            decimal sum3 = 0;
            decimal sum4 = 0; 
            decimal sum5 = 0;
            decimal sum6 = 0;
            decimal sum7 = 0;
            decimal sum8 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["无税产值"].Value);
                sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["成本金额"].Value);
                sum3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["客服单价"].Value);
                sum4 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["米数"].Value);
                sum5 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["客服金额"].Value);
                sum6 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["实收数量"].Value);
                sum7 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["折算米数"].Value);
                sum8 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["实际单价"].Value);


                if (dataGridView1.Rows[i].Cells["审核状态"].Value.ToString() == "已审核")
                {
                    if (dataGridView1.Rows[i].Cells["审核状态"].Value.ToString() == "已审核" && dataGridView1.Rows[i].Cells["状态"].Value.ToString() == "已出库")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                    }
                }
            }
            string ssum1 = sum1.ToString();
            string ssum2 = sum2.ToString();
            string ssum3 = sum3.ToString();
            string ssum4 = sum4.ToString();
            string ssum5 = sum5.ToString();
            string ssum6 = sum6.ToString();
            string ssum7 = sum7.ToString();
            string ssum8 = sum8.ToString();

            string[] row = { "1", "合计", "","", "", "", "", "", "", "", "", "0", "", ssum3, ssum4, ssum5, "0", ssum1, ssum6, ssum7, ssum8, "", "0", ssum2, "", "" };
            ((DataTable)dataGridView1.DataSource).Rows.Add(row);
        }


        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.ReadOnly = false;
            dataGridView1.Columns["单据编号"].ReadOnly = true;
            dataGridView1.Columns["合同编号"].ReadOnly = true;
            dataGridView1.Columns["单据日期"].ReadOnly = true;
            dataGridView1.Columns["销售订单"].ReadOnly = true;
            dataGridView1.Columns["录单员"].ReadOnly = true;
            BC.Enabled = true;
            删除ToolStripMenuItem.Enabled = true;
            粘贴ToolStripMenuItem.Enabled = true;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cpmc = dataGridView1.CurrentRow.Cells["产品名称"].Value.ToString();
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from [dbo].[ProductOut] where Product ='" + cpmc + "'";
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                MessageBox.Show("已出库，无法删除", "警告");
            }
            else
            {
                if(MessageBox.Show("你确定要删除吗？","警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
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
                }
            }
        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                string nr = dataGridView1.CurrentRow.Cells["内容"].Value.ToString();
                string cpmc = dataGridView1.CurrentRow.Cells["产品名称"].Value.ToString();
                SqlConnection conn = new SqlConnection(SQL);
                try
                {

                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE [dbo].[ProductIn] SET examine = '已审核' where Product = '" + cpmc + "' and substance = '" + nr + "'";
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        MessageBox.Show("审核成功");
                    }
                    else
                    {
                        MessageBox.Show("审核失败");
                    }
                    
                }
                catch(System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
                try
                {
                    string djrq = dataGridView1.CurrentRow.Cells["单据日期"].Value.ToString();
                    string htbh = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
                    string zsms = dataGridView1.CurrentRow.Cells["实收数量"].Value.ToString();
                    string dw = dataGridView1.CurrentRow.Cells["单位"].Value.ToString();
                    string cbje = dataGridView1.CurrentRow.Cells["成本金额"].Value.ToString();
                    string shck = dataGridView1.CurrentRow.Cells["收货仓库"].Value.ToString();

                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO [dbo].[Stock] ([date],[contractid],[product],[sub],[unit],[num],[amount],[warehouse]) VALUES ('" + djrq + "','" + htbh + "','" + cpmc + "','" + nr + "','" + dw + "','" + zsms + "','" + cbje + "','" + shck + "')";
                    int cot1 = cmd.ExecuteNonQuery();

                    if (cot1 > 0)
                    {
                        MessageBox.Show("库存修改成功");
                    }
                    else
                    {
                        MessageBox.Show("库存修改失败");
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                return;
            }
        }

        private void 反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                string nr = dataGridView1.CurrentRow.Cells["内容"].Value.ToString();
                string cpmc = dataGridView1.CurrentRow.Cells["产品名称"].Value.ToString();
                SqlConnection conn = new SqlConnection(SQL);
                try
                {

                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE [dbo].[ProductIn] SET examine = '未审核' where Product = '" + cpmc + "' and substance = '" + nr + "'";
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        MessageBox.Show("反审核成功");
                    }
                    else
                    {
                        MessageBox.Show("反审核失败");
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM [dbo].[Stock] where product = '" + cpmc + "' and sub = '" + nr + "'";
                    int cot1 = cmd.ExecuteNonQuery();

                    if (cot1 > 0)
                    {
                        MessageBox.Show("库存删除成功");
                    }
                    else
                    {
                        MessageBox.Show("库存删除失败");
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                return;
            }


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
            string fileName = "IC00";//可以在这里设置默认文件名
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

            dataGridView1.ReadOnly = true;
            删除ToolStripMenuItem.Enabled = false;
            粘贴ToolStripMenuItem.Enabled = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText(); //获取剪贴板中的内容
            if (string.IsNullOrEmpty(clipboardText))
            {
                return;
            }
            int colnum = 0;
            int rownum = 0;
            for (int i = 0; i < clipboardText.Length; i++)
            {
                if (clipboardText.Substring(i, 1) == "\t")
                {
                    colnum++;
                }
                if (clipboardText.Substring(i, 1) == "\n")
                {
                    rownum++;
                }
            }
            colnum = colnum / rownum + 1;
            int selectedRowIndex, selectedColIndex;
            selectedRowIndex = this.dataGridView1.CurrentRow.Index;
            selectedColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            if (selectedRowIndex + rownum > dataGridView1.RowCount || selectedColIndex + colnum > dataGridView1.ColumnCount)
            {
                MessageBox.Show("粘贴区域大小不一致");
                return;
            }
            String[][] temp = new String[rownum][];
            for (int i = 0; i < rownum; i++)
            {
                temp[i] = new String[colnum];
            }
            int m = 0, n = 0, len = 0;
            while (len != clipboardText.Length)
            {
                String str = clipboardText.Substring(len, 1);
                if (str == "\t")
                {
                    n++;
                }
                else if (str == "\n")
                {
                    m++;
                    n = 0;
                }
                else
                {
                    temp[m][n] += str;
                }
                len++;
            }
            for (int i = selectedRowIndex; i < selectedRowIndex + rownum; i++)
            {
                for (int j = selectedColIndex; j < selectedColIndex + colnum; j++)
                {
                    this.dataGridView1.Rows[i].Cells[j].Value = temp[i - selectedRowIndex][j - selectedColIndex];
                }
            }
        }

        private void ProductListIn_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);

        }

        private void 批量审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SqlConnection conn = new SqlConnection(SQL);
                for (int i = 0;i< dataGridView1.SelectedRows.Count; i++)
                {
                    int m = dataGridView1.SelectedRows[i].Index;
                    string nr = dataGridView1.Rows[m].Cells["内容"].Value.ToString();
                    string cpmc = dataGridView1.Rows[m].Cells["产品名称"].Value.ToString();
                    
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "UPDATE [dbo].[ProductIn] SET examine = '已审核' where Product = '" + cpmc + "' and substance = '" + nr + "'";
                        int count = cmd.ExecuteNonQuery();

                        if (count == 0)
                        {
                            MessageBox.Show("审核失败");

                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                    try
                    {
                        string djrq = dataGridView1.Rows[m].Cells["单据日期"].Value.ToString();
                        string htbh = dataGridView1.Rows[m].Cells["合同编号"].Value.ToString();
                        string zsms = dataGridView1.Rows[m].Cells["实收数量"].Value.ToString();
                        string dw = dataGridView1.Rows[m].Cells["单位"].Value.ToString();
                        string cbje = dataGridView1.Rows[m].Cells["成本金额"].Value.ToString();
                        string shck = dataGridView1.Rows[m].Cells["收货仓库"].Value.ToString();

                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "INSERT INTO [dbo].[Stock] ([date],[contractid],[product],[sub],[unit],[num],[amount],[warehouse]) VALUES ('" + djrq + "','" + htbh + "','" + cpmc + "','" + nr + "','" + dw + "','" + zsms + "','" + cbje + "','" + shck + "')";
                        int cot1 = cmd.ExecuteNonQuery();

                        if (cot1 == 0)
                        {
                            MessageBox.Show("库存修改失败");
                            continue;
                        }


                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                MessageBox.Show("审核成功");
               
            }
            else
            {
                return;
            }
        }

        private void WSCZ_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    decimal kfje = Convert.ToDecimal(dataGridView1.Rows[i].Cells["客服金额"].Value);
                    decimal sl = Convert.ToDecimal(dataGridView1.Rows[i].Cells["税率"].Value);
                    decimal wscz = kfje / (1 + (sl / 100));
                    string wscz1 = wscz.ToString("0.00");
                    dataGridView1.Rows[i].Cells["无税产值"].Value = wscz1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        int cot1;
        private void button1_Click(object sender, EventArgs e)
        {
            string d = DateTime.Now.ToString("yyyy-MM");
            /*SqlConnection con = new SqlConnection(SQL);
            con.Open();
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string htbh = dataGridView1.Rows[i].Cells["合同编号"].Value.ToString();
                    string cpmc = dataGridView1.Rows[i].Cells["产品名称"].Value.ToString();
                    string nr = dataGridView1.Rows[i].Cells["内容"].Value.ToString();
                    string cbje = dataGridView1.Rows[i].Cells["成本金额"].Value.ToString();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE Stock SET amount = '" + cbje + "' WHERE contractid = '" + htbh + "' and product = '" + cpmc + "' and sub = '" + nr + "'";
                    int cot = cmd.ExecuteNonQuery();

                    if (cot == 0)
                    {
                        string ms = cpmc + nr + "更新失败";
                        MessageBox.Show(ms);
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }*/
            
            string htbh1 = HTBH.Text.Trim();
            string gsm = GSMC.Text.Trim();
            string shzt = ZT.Text.Trim();
            string rq = RQ.Text.Trim();
            string rq1 = RQ1.Text.Trim();
            string ck = CK.Text.Trim();
            string str1 = "SELECT date as 日期,contractid as 合同编号,product as 产品,sum(sl) as 数量,sum(kfje) as 金额,dw as 单位,shck as 仓库 from ProductIn where caiwuRiqi BETWEEN '" + rq + "' and '" + rq1 + "' and contractid like '%" + htbh1 + "%' and  company like '%" + gsm + "%' and examine like '%" + shzt + "%'  and  shck like '%" + ck + "%' GROUP BY contractid,product,dw,shck,date";
            da1 = new SqlDataAdapter(str1, SQL);
            dt1 = new DataTable();
            da1.Fill(dt1);

            string str2 = "select * from ProductInJZ where oldDate BETWEEN '" + rq + "' and '" + rq1 + "' ";
            da2 = new SqlDataAdapter(str2, SQL);
            dt2 = new DataTable();
            da2.Fill(dt2);
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            if (dt2.Rows.Count < 1)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string DD = dt1.Rows[i]["日期"].ToString();
                    string CID = dt1.Rows[i]["合同编号"].ToString();
                    int SL = Convert.ToInt32(dt1.Rows[i]["数量"]);
                    decimal JE = Convert.ToDecimal(dt1.Rows[i]["金额"]);
                    string DW = dt1.Rows[i]["单位"].ToString();
                    string CK = dt1.Rows[i]["仓库"].ToString();
                    string CP = dt1.Rows[i]["产品"].ToString();

                    
                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "INSERT INTO [dbo].[ProductInJZ] ([contractid],[sl],[dw],[kfje],[shck],[date],product,oldDate) VALUES ('" + CID + "','" + SL + "','" + DW + "','" + JE + "','" + CK + "','" + d + "','" + CP + "','" + DD + "')";
                    cot1 = cmd1.ExecuteNonQuery();
                    
                }
            }
            else
            {
                MessageBox.Show("该月已经结转，请勿重复结转!");
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string htbh = dataGridView1.Rows[i].Cells["合同编号"].Value.ToString();
                string cpmc = dataGridView1.Rows[i].Cells["产品名称"].Value.ToString();
                string nr = dataGridView1.Rows[i].Cells["内容"].Value.ToString();
                string cbje = dataGridView1.Rows[i].Cells["成本金额"].Value.ToString();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Stock SET amount = '" + cbje + "' WHERE contractid = '" + htbh + "' and product = '" + cpmc + "' and sub = '" + nr + "'";
                int cot = cmd.ExecuteNonQuery();

                if (cot == 0)
                {
                    string ms = cpmc + nr + "更新失败";
                    MessageBox.Show(ms);
                    continue;
                }
            }
            conn.Close();
            /* string str3 = "select contractid as 合同编号,sl as 数量,kfje as 金额,dw as 单位,product as 产品名称,shck as 仓库,oldDate as 时间 from ProductInJZ where oldDate BETWEEN '" + rq + "' and '" + rq1 + "'";
             da3 = new SqlDataAdapter(str3, SQL);
             dt3 = new DataTable();
             da3.Fill(dt3);

             for (int i = 0; i < dt3.Rows.Count; i++)
             {
                 string htbh1 = dt1.Rows[i]["合同编号"].ToString();
                 string dw1 = dt1.Rows[i]["单位"].ToString();
                 string cpmc1 = dt1.Rows[i]["产品名称"].ToString();
                 string ck1 = dt1.Rows[i]["仓库"].ToString();
                 string sj1 = dt1.Rows[i]["时间"].ToString();
                 int sl1 = Convert.ToInt32(dt1.Rows[i]["数量"]);
                 decimal je1 = Convert.ToDecimal(dt1.Rows[i]["金额"]);

                 SqlCommand cmd2 = conn.CreateCommand();
                 cmd2.CommandText = "UPDATE Stock SET amount = '" + je1 + "' WHERE contractid = '" + htbh1 + "' and product = '" + cpmc1 + "' and warehouse = '" + ck1 + "'and unit = '" + dw1 + "'";
                 cmd2.ExecuteNonQuery();
             }*/
        }

        private void btndjrq_Click(object sender, EventArgs e)
        {
            

        }

        //双击一条记录将要修改的值传入另外一个窗体中
        public static string[] a;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(Group1== "财务部" || Group1== "Administrators")
            {
                try
                {
                    /*int index = dataGridView1.CurrentRow.Index;
                    a = new string[dataGridView1.ColumnCount];
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        a[i] = dataGridView1.Rows[index].Cells[i].Value.ToString();
                    }*/
                    modifydanjuriqi modifydanjuriqi = new modifydanjuriqi();
                    modifydanjuriqi.Username = Username1;
                    modifydanjuriqi.Group = Group1;
                    string aa = dataGridView1.CurrentRow.Cells["单据日期"].Value.ToString();
                    string bb = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString();
                    string cc = dataGridView1.CurrentRow.Cells["销售订单"].Value.ToString();
                    string dd = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
                    modifydanjuriqi.djrq = aa;
                    modifydanjuriqi.djId= bb;
                    modifydanjuriqi.xsId= cc;
                    modifydanjuriqi.htId = dd;
                    modifydanjuriqi.Show();

                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("对不起，你没有权限！");
            }
        }
        int aa = 0;
        private void 财务审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int m = dataGridView1.SelectedRows[i].Index;
                if (dataGridView1.Rows[m].Cells["财务审核"].Value.ToString() == "未审核")
                {
                    string id = dataGridView1.Rows[m].Cells["id"].Value.ToString().Trim();
                    string str = "update ProductIn set cwsh = '已审核' where id = '" + id + "'and caiwuRiqi BETWEEN '" + RQ.Text.Trim() + "' and '" + RQ1.Text.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    aa = cmd.ExecuteNonQuery();
                }
            }
            if (aa > 0)
            {
                MessageBox.Show("审核成功！");
            }
            conn.Close();
            SX.PerformClick();
        }
        
    }
}
