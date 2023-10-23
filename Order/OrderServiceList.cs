using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using WindowsFormsApp1.Class;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using WindowsFormsApp1.Bill;
using System.ComponentModel;
using System.Configuration.Internal;
using static WindowsFormsApp1.Order.Orderxz;

namespace WindowsFormsApp1.Order
{
    public partial class OrderServiceList : Form
    {
        public OrderServiceList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        DataTable dt;
        SqlDataAdapter da;

        private string del = "";

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        public string OSL_User { get; set; }
        public string OSL_Group { get; set; }

        #region
        protected void SX_Click(object sender, EventArgs e)
        {
            if(CKLB.Text == "")
            {
                MessageBox.Show("请选择查看类别");
            }
            else
            {
                dataGridView1.DataSource = null;
                string htbh = HTBH.Text.Trim();
                string aa = RQ.Text.Trim();
                string bb = RQ1.Text.Trim();
                string cc = GDY.Text.Trim();
                string dd = GSMC.Text.Trim();
                string ee = SHZT.Text.Trim();
                string ff = YWY.Text.Trim();
                string gg = QJ.Text.Trim();
                string ckzt = CKZT.Text.Trim();
                if (CKLB.Text == "销售订单主数据")
                {
                    审核ToolStripMenuItem.Enabled = false;
                    反审核ToolStripMenuItem.Enabled = true;
                    删除ToolStripMenuItem.Enabled = true;
                    收款单修改ToolStripMenuItem.Enabled = false;
                    收款单保存ToolStripMenuItem.Enabled = false;
                    批量审核ToolStripMenuItem.Enabled = false;
                    导出ToolStripMenuItem.Enabled = true;
                    发货申请ToolStripMenuItem.Enabled = false;

                    try
                    {
                        string sql = String.Format("select id,orderid as 单据编号,contractid as 合同编号,date as 日期,service as 跟单员,desgin as 设计员,company as 公司名,project as 项目名称,con_date as 合同日期,seller as 业务员,person as 联系人,phone as 电话,delivery as 交期,color as 颜色,longmetre as 最长米,quantity as 总米数,tax as 税率,htje as 合同金额,sjje as 总金额,amount as 实际金额,wsje as 无税金额,azf as 安装费,ywf as 业务费,huokuan as 货款,dj as 定金,hk as 回扣,remarks as 备注,examine as 审核状态,qj as 期间 from [dbo].[Order_h] " +
                            "where  contractid like '%" + htbh + "%' and service like '%" + cc + "%' and seller like '%" + ff + "%' and company like '%" + dd + "%' and examine like '%" + ee + "%' and qj like '%" + gg + "%' and date between '" + aa + "' and '" + bb + "'");

                        da = new SqlDataAdapter(sql, SQL);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["id"].Visible = false;
                        decimal sum = 0;
                        decimal sum1 = 0;
                        decimal sum2 = 0;
                        decimal sum3 = 0;
                        decimal sum4 = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["总金额"].Value);
                            sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["总米数"].Value);
                            sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["无税金额"].Value);
                            sum3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["实际金额"].Value);
                            sum4 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["安装费"].Value);
                            if (dataGridView1.Rows[i].Cells[26].Value.ToString() == "已审核")
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                            }
                        }
                        string ssum = sum.ToString();
                        string ssum1 = sum1.ToString();
                        string ssum2 = sum2.ToString();
                        string ssum3 = sum3.ToString();
                        string ssum4 = sum4.ToString();
                        string[] row = { "1", "合计", "", "", "", "", "", "", "", "", "", "", "", "", "", ssum1, "", "", ssum, ssum3, ssum2, ssum4, "", "0", "", "", "","" ,""};
                        ((DataTable)dataGridView1.DataSource).Rows.Add(row);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (CKLB.Text == "销售订单详细数据")
                {
                    审核ToolStripMenuItem.Enabled = false;
                    反审核ToolStripMenuItem.Enabled = true;
                    删除ToolStripMenuItem.Enabled = false;
                    收款单修改ToolStripMenuItem.Enabled = false;
                    收款单保存ToolStripMenuItem.Enabled = false;
                    批量审核ToolStripMenuItem.Enabled = false;
                    导出ToolStripMenuItem.Enabled = true;
                    发货申请ToolStripMenuItem.Enabled = true;
                    批量发货申请ToolStripMenuItem.Enabled = true;
                    try
                    {
                        string sql = String.Format("select id,orderid as 单据编号,contractid as 合同编号,date as 日期,service as 跟单员,company as 公司名,project as 项目名称,sub as 内容,quantity as 数量,unit as 单位,price as 单价,meters as 米数,amount as 总金额,azf as 安装费,hk as 回扣,yf as 运费 ,sjje as 实际金额,wsje as 无税金额,ywy as 业务员,qy as 区域,productname as 产品名称,ident as 发货状态,ckzt as 出库状态,examine as 审核状态,rkzt as 入库状态,rksj as 入库时间 from [dbo].[Order_b] where contractid like '%" + htbh + "%' and service like '%" + cc + "%' and company like '%" + dd + "%' and ident like '%" + ckzt + "%' and ckzt like '%" + comboBox1.Text.Trim() + "%' and  date between '" + aa + "' and '" + bb + "'and examine like '%"+ee+ "%' and rkzt like '%"+comboBox2.Text+"%'");

                        da = new SqlDataAdapter(sql, SQL);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        //dataGridView1.Columns["id"].Visible = false;
                        decimal sum0 = 0;
                        decimal sum = 0;
                        decimal sum1 = 0;
                        decimal sum2 = 0;
                        decimal sum3 = 0;
                        decimal sum4 = 0;
                        decimal sum5 = 0;
                        decimal sum6 = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            sum0 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["单价"].Value);
                            sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["米数"].Value);
                            sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["总金额"].Value);
                            if(dataGridView1.Rows[i].Cells["安装费"].Value == DBNull.Value)
                            {
                                dataGridView1.Rows[i].Cells["安装费"].Value = 0.00;
                            }
                            else
                            {
                                sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["安装费"].Value);
                            }
                            if (dataGridView1.Rows[i].Cells["回扣"].Value == DBNull.Value)
                            {
                                dataGridView1.Rows[i].Cells["回扣"].Value = 0.00;
                            }
                            else
                            {
                                sum3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["回扣"].Value);
                            }
                            if (dataGridView1.Rows[i].Cells["运费"].Value == DBNull.Value)
                            {
                                dataGridView1.Rows[i].Cells["运费"].Value = 0.00;
                            }
                            else
                            {
                                sum4 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["运费"].Value);
                            }
                            if (dataGridView1.Rows[i].Cells["实际金额"].Value == DBNull.Value)
                            {
                                dataGridView1.Rows[i].Cells["实际金额"].Value = 0.00;
                            }
                            else
                            {
                                sum5 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["实际金额"].Value);
                            }
                            if (dataGridView1.Rows[i].Cells["无税金额"].Value == DBNull.Value)
                            {
                                dataGridView1.Rows[i].Cells["无税金额"].Value = 0.00;
                            }
                            else
                            {
                                sum6 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["无税金额"].Value);
                            }
                            /*sum3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["回扣"].Value);
                            sum4 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["运费"].Value);
                            sum5 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["实际金额"].Value);
                            sum6 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["无税金额"].Value);*/

                        }
                        string ssum0 = sum0.ToString();
                        string ssum = sum.ToString();
                        string ssum1 = sum1.ToString();
                        string ssum2 = sum2.ToString();
                        string ssum3 = sum3.ToString();
                        string ssum4 = sum4.ToString();
                        string ssum5 = sum5.ToString();
                        string ssum6 = sum6.ToString();
                        string[] row = { "0", "合计", "", "", "", "", "", "", "0", "", ssum0,ssum, ssum1, ssum2, ssum3, ssum4, ssum5, ssum6, "","","","" };
                        ((DataTable)dataGridView1.DataSource).Rows.Add(row);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (CKLB.Text == "收款单")
                {
                    审核ToolStripMenuItem.Enabled = true;
                    反审核ToolStripMenuItem.Enabled = true;
                    删除ToolStripMenuItem.Enabled = true;
                    收款单修改ToolStripMenuItem.Enabled = true;
                    收款单保存ToolStripMenuItem.Enabled = true;
                    批量审核ToolStripMenuItem.Enabled = true;
                    导出ToolStripMenuItem.Enabled = true;
                    发货申请ToolStripMenuItem.Enabled = false;
                    try
                    {
                        string sql = String.Format("select id,orderid as 单据编号,contractid as 合同编号,date as 日期,company as 公司名,project as 项目名称,bank as 银行,skje as 收款,seller as 业务员,area as 区域,service as 跟单员,remake as 备注,examine as 审核状态 " +
                            "from [dbo].[Receipt] where  service like '%" + cc + "%' and company like '%" + dd + "%' and  date between '" + aa + "' and '" + bb + "'and examine like '%" + ee + "%' and seller like '%"+ff+"%'");

                        da = new SqlDataAdapter(sql, SQL);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["id"].Visible = false;
                        decimal sum = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                            if (dataGridView1.Rows[i].Cells["审核状态"].Value.ToString() == "已审核")
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                            }
                        }
                        string ssum = sum.ToString();
                        string[] row = { "1", "合计","", "", "", "", "", ssum , "", "", "", "", "" };
                        ((DataTable)dataGridView1.DataSource).Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
            
        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "收款单")
            {
                if (OSL_Group == "财务部"|| OSL_Group == "Administrators")
                {
                    string a = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString().Trim();
                    SqlConnection conn = new SqlConnection(SQL);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE [dbo].[Receipt] SET examine = '已审核' where orderid like '%" + a + "%'";
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        MessageBox.Show("审核成功");
                    }
                    else
                    {
                        MessageBox.Show("审核失败");
                    }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("对不起你没有权限");
                }

            }
            if (CKLB.Text == "销售订单主数据")
            {
                string a = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString().Trim();
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE [dbo].[Order_h] SET examine = '已审核' where orderid like '%" + a + "%'";
                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("审核成功");
                }
                else
                {
                    MessageBox.Show("审核失败");
                }
                conn.Close();
            }

        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void 反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (CKLB.Text == "收款单")
            {
                if (OSL_Group == "财务部" || OSL_Group == "Administrators"|| OSL_Group == "客服部")
                {
                    string a = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString().Trim();
                    SqlConnection conn = new SqlConnection(SQL);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE [dbo].[Receipt] SET examine = '未审核' where orderid like '%" + a + "%'";
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        MessageBox.Show("反审核成功");
                    }
                    else
                    {
                        MessageBox.Show("反审核失败");
                    }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("对不起，无权反审核");
                }

            }
            if (CKLB.Text == "销售订单主数据")
            {
                string a = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString().Trim();
                SqlConnection conn1 = new SqlConnection(SQL);
                conn1.Open();
                SqlCommand cmd1 = conn1.CreateCommand();
                string strsql = "select * from ProductIn where orderid = '" + a + "'";
                cmd1.CommandText = strsql;
                int i = Convert.ToInt32(cmd1.ExecuteScalar());
                SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count == 0)
                {
                    if (OSL_Group == "财务部" || OSL_Group == "Administrators" || OSL_Group == "客服部")
                    {
                        if(i == 0)
                        {
                            SqlConnection conn = new SqlConnection(SQL);
                            conn.Open();
                            SqlCommand cmd = conn.CreateCommand();
                            cmd.CommandText = "UPDATE [dbo].[Order_h] SET examine = '未审核' where orderid like '%" + a + "%'";
                            int count = cmd.ExecuteNonQuery();

                            if (count > 0)
                            {
                                MessageBox.Show("反审核成功");
                            }
                            else
                            {
                                MessageBox.Show("反审核失败");
                            }
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("订单已入库，无法反审核");
                        }  
                    }
                    else
                    {
                        MessageBox.Show("财务，客服才能反审核，去找他们。");
                    }
                    conn1.Close();
                }
                else
                {
                    MessageBox.Show("产品已入库，无法反审核");
                }
            }
            if(CKLB.Text == "销售订单详细数据")
            {
                if (OSL_Group == "财务部" || OSL_Group == "Administrators"|| OSL_Group == "客服部")
                {
                    string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString().Trim();
                    SqlConnection conn = new SqlConnection(SQL);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE [dbo].[Order_b] SET examine = '未审核' where id like '%" + id + "%'";
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        MessageBox.Show("反审核成功");
                    }
                    else
                    {
                        MessageBox.Show("反审核失败");
                    }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("你没有权限进行反审核，请通知财务或管理员进行反审核！");
                }
                
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "销售订单主数据")
            {
                if (OSL_Group == "财务部" || OSL_Group == "Administrators" || OSL_Group == "客服部") {
                    if (dataGridView1.CurrentRow.Cells["审核状态"].Value.ToString() == "已审核")
                    {
                        MessageBox.Show("已审核，无法删除");
                    }
                    else
                    {
                        string htbh = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
                        SqlConnection conn = new SqlConnection(SQL);
                        conn.Open();
                        SqlCommand cmmd = conn.CreateCommand();
                        cmmd.CommandText = "select * from [dbo].[ProductIn] where contractid ='" + htbh + "'";
                        SqlDataReader sdr = cmmd.ExecuteReader();
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("订单已入库，无法删除。", "警告");
                        }
                        else
                        {
                            sdr.Close();
                            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == OSL_User)
                            {
                                del = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
                                dataGridView1.ReadOnly = true;
                                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                if (MessageBox.Show("是否一并删除详细数据", "提示!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    SqlCommand cmd = conn.CreateCommand();
                                    cmd.CommandText = "DELETE FROM [dbo].[Order_b] WHERE orderid = '" + del + "'";
                                    int cot = cmd.ExecuteNonQuery();
                                    if (cot > 0)
                                    {
                                        MessageBox.Show("删除成功");
                                    }
                                    else
                                    {
                                        MessageBox.Show("删除失败");
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("无法删除别人的单据");
                            }
                        }
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("权限不够，无法删除！");
                }
            }
            if (CKLB.Text == "收款单")
            {
                if (dataGridView1.CurrentRow.Cells[12].Value.ToString() == "已审核")
                {
                    MessageBox.Show("已审核，无法删除");
                }
                else
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
                    dataGridView1.ReadOnly = true;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
        }

        private void 收款单修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CKLB.Text == "收款单")
            {
                if (dataGridView1.CurrentRow.Cells["审核状态"].Value.ToString() == "已审核")
                {
                    MessageBox.Show("已审核，无法修改");
                }
                else
                {

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                    dataGridView1.ReadOnly = false;
                    dataGridView1.AllowUserToDeleteRows = true;
                }
            }

        }

        private void 批量审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "销售订单主数据")

            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    int m = dataGridView1.SelectedRows[i].Index;
                    dataGridView1.Rows[m].Cells["审核状态"].Value = "已审核";
                }
                try
                {
                    SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                    da.Update(dt);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("审核失败");
                    return;
                }
                MessageBox.Show("审核成功!");
            }
            if (CKLB.Text == "收款单")
            {
                if (OSL_Group == "财务部" || OSL_Group == "Administrators")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        int m = dataGridView1.SelectedRows[i].Index;
                        dataGridView1.Rows[m].Cells["审核状态"].Value = "已审核";
                    }
                    try
                    {
                        SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                        da.Update(dt);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        MessageBox.Show("审核失败");
                        return;
                    }
                    MessageBox.Show("审核成功!");
                }
                else
                {
                    MessageBox.Show("对不起，无权审核");
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CKLB.Text == "销售订单主数据")
            {
                //获取索引为1的第二个字段订单号
                string a = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                OrderServiceR orderserviceR = new OrderServiceR();
                // 给窗体的公共属性赋值
                orderserviceR.OSR_Ord = a;
                orderserviceR.OSR_User = OSL_User;
                orderserviceR.OSR_Group = OSL_Group;
                // 显示子窗体
                orderserviceR.Show();
            }else if (CKLB.Text == "销售订单详细数据")
            {
                string htbh = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();

                if (dataGridView1.CurrentRow.Cells["审核状态"].Value.ToString() == "未审核")
                {
                    string b = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    string o = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    ModifyDetialOrder modify = new ModifyDetialOrder();
                    modify.UId = b;
                    modify.OId = o;
                    modify.OSL_Group = OSL_Group;
                    modify.OSL_User = OSL_User;
                    modify.Show();
                }
                else
                {
                    MessageBox.Show("该htbh:'"+ htbh + "' 财务已经审核，请联系财务反审核后在进行修改");
                }
                
            }
        }

        private void 收款单保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("保存失败");
                return;
            }
            MessageBox.Show("保存成功");
        }
        public void aa(string bb)
        {
            this.SX.Text = bb;
        }        
        #endregion
        private void 发货申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "销售订单详细数据")
            {
                if (dataGridView1.CurrentRow.Cells["发货状态"].Value.ToString() == "N")
                {
                    if (MessageBox.Show("是否要提交发货申请到财务！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                        string htbh = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
                        string gdy = dataGridView1.CurrentRow.Cells["跟单员"].Value.ToString();
                        string gsm = dataGridView1.CurrentRow.Cells["公司名"].Value.ToString();
                        string xmmc = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
                        string cpmc = dataGridView1.CurrentRow.Cells["产品名称"].Value.ToString();
                        string nr = dataGridView1.CurrentRow.Cells["内容"].Value.ToString();
                        string sl = dataGridView1.CurrentRow.Cells["数量"].Value.ToString();
                        string dw = dataGridView1.CurrentRow.Cells["单位"].Value.ToString();
                        string je = dataGridView1.CurrentRow.Cells["总金额"].Value.ToString();

                        Orderxz orderxz = new Orderxz();
                        orderxz.Owner= this;
                        orderxz.aa += new Delegateaa (aa);
                        orderxz.OXZ_id = id;
                        orderxz.OXZ_Htbh = htbh;
                        orderxz.OXZ_Gdy = gdy;
                        orderxz.OXZ_Gsm = gsm;
                        orderxz.OXZ_Xmmc = xmmc;
                        orderxz.OXZ_Cpmc = cpmc;
                        orderxz.OXZ_Nr = nr;
                        orderxz.OXZ_Sl = sl;
                        orderxz.OXZ_Dw = dw;
                        orderxz.OXZ_Je = je;
                        orderxz.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("已经出库，无法申请");
                }
            }
            
        }

        private void OrderServiceList_Load(object sender, EventArgs e)
        {
            RQ.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(-2);
            RQ1.Value = DateTime.Now;
            asc.controllInitializeSize(this);

        }

        private void OrderServiceList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void 批量发货申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "销售订单详细数据")
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        int m = dataGridView1.SelectedRows[i].Index;

                        if (dataGridView1.Rows[m].Cells["发货状态"].Value.ToString() == "N")
                        {
                            string htbh = dataGridView1.Rows[m].Cells["合同编号"].Value.ToString();
                            string gdy = dataGridView1.Rows[m].Cells["跟单员"].Value.ToString();
                            string gsm = dataGridView1.Rows[m].Cells["公司名"].Value.ToString();
                            string xmmc = dataGridView1.Rows[m].Cells["项目名称"].Value.ToString();
                            string cpmc = dataGridView1.Rows[m].Cells["产品名称"].Value.ToString();
                            string nr = dataGridView1.Rows[m].Cells["内容"].Value.ToString();
                            string sl = dataGridView1.Rows[m].Cells["数量"].Value.ToString();
                            string dw = dataGridView1.Rows[m].Cells["单位"].Value.ToString();
                            string je = dataGridView1.Rows[m].Cells["总金额"].Value.ToString();

                            SqlConnection con = new SqlConnection(SQL);

                            try
                            {
                                string sqsj = DateTime.Now.ToString("G");
                                con.Open();
                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "INSERT INTO Message_FHSQ ([contractid],[applytime],[service],[company],[project],[productname],[sub],[quantity],[unit],[amount],[fhck],[fhwl],[examine],[checkout],[readzt]) VALUES('" + htbh + "','" + sqsj + "','" + gdy + "','" + gsm + "','" + xmmc + "','" + cpmc + "','" + nr + "','" + sl + "','" + dw + "','" + je + "','一线成品仓','装车','未审核','未出库','未读')";
                                cmd.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message.ToString());

                            }
                            finally
                            {
                                con.Close();
                            }
                            try
                            {
                                con.Open();
                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "UPDATE Order_b SET ident = 'Y' WHERE productname = '" + cpmc + "' and sub = '" + nr + "'";
                                cmd.ExecuteNonQuery();
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
                        else
                        {
                            string cpmc = dataGridView1.Rows[m].Cells["产品名称"].Value.ToString();
                            string nr = dataGridView1.Rows[m].Cells["内容"].Value.ToString();
                            string ts = "该产品" + cpmc + "-" + nr + "产品已出库，无法申请";
                            MessageBox.Show(ts);
                            break;
                        }

                    }
                    MessageBox.Show("申请成功，请到主界面小蓝标查看");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int cot;
        int cot1;
        private void 财务审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            if (CKLB.Text == "销售订单详细数据")
            {
                if (OSL_Group == "财务部"|| OSL_Group == "Administrators")
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        int m = dataGridView1.SelectedRows[i].Index;
                        if (dataGridView1.Rows[m].Cells["审核状态"].Value.ToString() == "未审核")
                        {
                            string id = dataGridView1.Rows[m].Cells["id"].Value.ToString().Trim();
                            string djbh = dataGridView1.Rows[m].Cells["单据编号"].Value.ToString().Trim();
                            string htbh = dataGridView1.Rows[m].Cells["合同编号"].Value.ToString().Trim();
                            string rq = dataGridView1.Rows[m].Cells["日期"].Value.ToString().Trim();
                            string gdy = dataGridView1.Rows[m].Cells["跟单员"].Value.ToString().Trim();
                            string gsm = dataGridView1.Rows[m].Cells["公司名"].Value.ToString().Trim();
                            string xmmc = dataGridView1.Rows[m].Cells["项目名称"].Value.ToString().Trim();
                            string nr = dataGridView1.Rows[m].Cells["内容"].Value.ToString().Trim();
                            string sl = dataGridView1.Rows[m].Cells["数量"].Value.ToString().Trim();
                            string dw = dataGridView1.Rows[m].Cells["单位"].Value.ToString().Trim();
                            string dj = dataGridView1.Rows[m].Cells["单价"].Value.ToString().Trim();
                            string ms = dataGridView1.Rows[m].Cells["米数"].Value.ToString().Trim();
                            string zje = dataGridView1.Rows[m].Cells["总金额"].Value.ToString().Trim();
                            string azf = dataGridView1.Rows[m].Cells["安装费"].Value.ToString().Trim();
                            string hk = dataGridView1.Rows[m].Cells["回扣"].Value.ToString().Trim();
                            string yf = dataGridView1.Rows[m].Cells["运费"].Value.ToString().Trim();
                            string sjje = dataGridView1.Rows[m].Cells["实际金额"].Value.ToString().Trim();
                            string wsje = dataGridView1.Rows[m].Cells["无税金额"].Value.ToString().Trim();
                            string ywy = dataGridView1.Rows[m].Cells["业务员"].Value.ToString().Trim();
                            string qy = dataGridView1.Rows[m].Cells["区域"].Value.ToString().Trim();
                            string cpmc = dataGridView1.Rows[m].Cells["产品名称"].Value.ToString().Trim();
                            string fhzt = dataGridView1.Rows[m].Cells["发货状态"].Value.ToString().Trim();
                            string ckzt = dataGridView1.Rows[m].Cells["出库状态"].Value.ToString().Trim();
                            string sh = dataGridView1.Rows[m].Cells["审核状态"].Value.ToString().Trim();
                            string sj = DateTime.Now.ToString("yyyy-MM-dd");

                            string str11 = "insert into Order_b_cw (oId,orderid,contractid,date,service,company,project,sub,quantity,unit,price,meters,amount,azf,hk,yf,sjje,wsje,ywy,qy,productname,ident,ckzt,shDate)Values('"+id+"','" + djbh + "','" + htbh + "','" + rq + "','" + gdy + "','" + gsm + "','" + xmmc + "','" + nr + "','" + sl + "','" + dw + "','" + dj + "','" + ms + "','" + zje + "','" + azf + "','" + hk + "','" + yf + "','" + sjje + "','" + wsje + "','" + ywy + "','" + qy + "','" + cpmc + "','" + fhzt + "','" + ckzt + "','" + sj + "')";
                            SqlCommand cmd = new SqlCommand(str11, conn);
                            cot = cmd.ExecuteNonQuery();

                            string str12 = "update Order_b set examine = '已审核' where id = '" + id + "'";
                            SqlCommand cmd1 = new SqlCommand(str12, conn);
                            cot1 = cmd1.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("该订单已经审核");
                        }
                        dataGridView1.Rows[m].DefaultCellStyle.BackColor = Color.Red;
                    }
                    if (cot < 1 && cot1 < 1)
                    {
                        MessageBox.Show("保存失败");
                    }
                    else
                    {
                        MessageBox.Show("保存成功");
                    }
                }
                else
                {
                    MessageBox.Show("能没有权限");
                }
            }
            MessageBox.Show("点击主页面加号小图标进行查看");
            conn.Close();
        }
        private void OrderServiceList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)//按下ESC //27
            {
                this.Close();
            }
        }
    }
}