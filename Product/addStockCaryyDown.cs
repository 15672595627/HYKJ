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

namespace WindowsFormsApp1.Product
{
    public partial class addStockCaryyDown : Form
    {
        public addStockCaryyDown()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da = null;
        private DataTable dt = null;

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void button1_Click(object sender, EventArgs e)
        {
            string sj = dateTimePicker1.Text.Trim();
            string htbh = textBox1.Text.Trim();
            string product = textBox2.Text.Trim();
            string str = "select id ,contractid as 合同编号,product as 产品,sl as 数量,kfje as 金额,dw as 单位,shck as 仓库,date as 结转时间 ,oldDate as 时间 from ProductInJZ where contractid like '%"+htbh+ "%' and product like '%" + product + "%' and  date like '%" + sj+ "%'";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;

            decimal sum1 = 0;
            decimal sum2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["数量"].Value);
                sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["金额"].Value);
            }
            string ssum1 = sum1.ToString();
            string ssum2 = sum2.ToString();
            string[] row = { "0","合计", "", ssum1, ssum2, "","" ,"" ,""};
            ((DataTable)dataGridView1.DataSource).Rows.Add(row);
        }

        private void addStockCaryyDown_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void addStockCaryyDown_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        }
    }
}
