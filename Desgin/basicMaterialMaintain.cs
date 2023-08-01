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

namespace WindowsFormsApp1.Desgin
{
    public partial class basicMaterialMaintain : Form
    {
        public basicMaterialMaintain()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da;
        private DataTable dt;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private int rowIndex = 0;
        private string del = "";
        private void basicMaterialMaintain_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void basicMaterialMaintain_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();
            string text2 = textBox2.Text.Trim();
            string text3 = textBox3.Text.Trim();
            string str = "select [id],[pinName] as 品名,[materialId] as 物料编码,[materialName] as 材料名称,[materialSpecs] as 材料规格 from basicMaterial where materialName like '%"+text+ "%' and materialSpecs like '%"+text2+ "%' and materialId like '%"+text3+ "%' and delState = 'N'";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            {
                try
                {
                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.da);
                    this.da.Update(this.dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("保存失败");
                    return;
                }
                this.dataGridView1.ReadOnly = true;
                this.button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button3.Enabled = true;
            this.dataGridView1.ReadOnly = false;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            {
                this.del = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.da);
                this.da.Update(this.dt);
                bool flag = !this.dataGridView1.Rows[this.rowIndex].IsNewRow;
                if (flag)
                {
                    this.dataGridView1.Rows.RemoveAt(this.rowIndex);
                    SqlConnection sqlConnection = new SqlConnection(basicMaterialMaintain.SQL);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandText = "update [dbo].[basicMaterial] set delState = 'Y' WHERE id = '" + this.del + "'";
                    int num = sqlCommand.ExecuteNonQuery();
                    bool flag2 = num > 0;
                    if (flag2)
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

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            {
                bool flag = e.Button == MouseButtons.Right;
                if (flag)
                {
                    this.dataGridView1.Rows[e.RowIndex].Selected = true;
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                    this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                    this.contextMenuStrip1.Show(Cursor.Position);
                    this.rowIndex = e.RowIndex;
                }
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
