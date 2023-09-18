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
using DataTable = System.Data.DataTable;

namespace WindowsFormsApp1.Order
{
    public partial class OderCKZT : Form
    {
        public OderCKZT()
        {
            InitializeComponent();
        }
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void OderCKZT_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
        SqlDataAdapter da;
        DataTable dt;
        private string del = "";
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = String.Format("select id,oId,orderid as 单据编号,contractid as 合同编号,date as 日期,shDate as 审核时间 ,service as 跟单员,company as 公司名,project as 项目名称,sub as 内容,quantity as 数量,unit as 单位,price as 单价,meters as 米数,amount as 总金额,azf as 安装费,hk as 回扣,yf as 运费 ,sjje as 实际金额,wsje as 无税金额,ywy as 业务员,qy as 区域,productname as 产品名称,ident as 发货状态,ckzt as 出库状态 from [dbo].[Order_b_cw] where contractid like '%" + textBox1.Text+ "%' and ckzt like '%"+comboBox1.Text+ "%'and shDate between '"+dt1.Text+"'and '"+dt2.Text+"'");
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            
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
                
                if (dataGridView1.Rows[i].Cells["安装费"].Value == DBNull.Value)
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
            }
            string ssum0 = sum0.ToString();
            string ssum = sum.ToString();
            string ssum1 = sum1.ToString();
            string ssum2 = sum2.ToString();
            string ssum3 = sum3.ToString();
            string ssum4 = sum4.ToString();
            string ssum5 = sum5.ToString();
            string ssum6 = sum6.ToString();
            string[] row = { "1", "0","合计", "", "","", "", "", "", "", "0", "", ssum0, ssum, ssum1, ssum2, ssum3, ssum4, ssum5, ssum6, "", "", "", "" };
            ((DataTable)dataGridView1.DataSource).Rows.Add(row);
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
        }
        private void OderCKZT_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string a = dataGridView1.Rows[i].Cells["出库状态"].Value.ToString();
                if (a == "已出库")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (a == "未出库")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (a == "部分出库")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }  
        }

        private void OderCKZT_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[22].Value.ToString() == "已出库")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green; ;
                }
                else if (dataGridView1.Rows[i].Cells[22].Value.ToString() == "未出库")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (dataGridView1.Rows[i].Cells[22].Value.ToString() == "部分出库")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            del = dataGridView1.CurrentRow.Cells[0].Value.ToString();
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
            if (MessageBox.Show("是否一并删除详细数据", "提示!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM [dbo].[Order_b_cw] WHERE id = '" + del + "'";
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
    }
}
