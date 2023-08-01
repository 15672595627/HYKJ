using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Purchase
{
    // Token: 0x02000015 RID: 21
    public partial class PurchaseList : Form
    {
        public PurchaseList()
        {
            this.InitializeComponent();
        }

        public string User { get; set; }

        public string Group { get; set; }
        private SqlDataAdapter da;

        DataTable dt;

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.cbXtzt.Text.Trim();
            string text2 = this.txtHtbh.Text.Trim();
            string text3 = this.txtKh.Text.Trim();
            string text4 = this.txtXm.Text.Trim();
            string text5 = this.txtDdbh.Text.Trim();
            string selectCommandText = string.Concat(new string[]
            {
                "select id,ddId as 订单编号,contactId as 合同编号,company as 客户, project as 项目,materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,stockName as 仓库名称 ,unitNumber as 库存数量,unit as 单位,purchaseNumber as 采购数量,kuwei as 库位,weight as 重量,weightUnit as 重量单位,remark as 备注,xtState as 下推状态 from purchaseRequest where contactId like '%",
                text2,
                "%' and company like '%",
                text3,
                "%' and project like '%",
                text4,
                "%'and state = 'Y' and xtState like '%",
                text,
                "%'order by Date DESC"
            });
            this.da = new SqlDataAdapter(selectCommandText, PurchaseList.SQL);
            this.dt = new DataTable();
            this.da.Fill(this.dt);
            this.dataGridView1.DataSource = this.dt;
            this.dataGridView1.Columns["id"].Visible = false;
            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                bool flag = this.dataGridView1.Rows[i].Cells["下推状态"].Value.ToString() == "已下推";
                if (flag)
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = this.dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
            this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
            try
            {
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.da);
                this.da.Update(this.dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            MessageBox.Show("更新成功!");
            bool flag = MessageBox.Show("是否删除", "提示!", MessageBoxButtons.OKCancel) == DialogResult.OK;
            if (flag)
            {
                SqlConnection sqlConnection = new SqlConnection(PurchaseList.SQL);
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM [dbo].[purchaseRequest] WHERE contractid = '" + str + "'";
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

        private void 下推ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                int index = this.dataGridView1.SelectedRows[i].Index;
                SqlConnection sqlConnection = new SqlConnection(PurchaseList.SQL);
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "update purchaseRequest set xtState = '已下推'";
                int num = sqlCommand.ExecuteNonQuery();
                bool flag = num == 0;
                if (flag)
                {
                    MessageBox.Show("下推失败");
                }
                sqlConnection.Close();
            }
        }
        private void PurchaseList_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
            {
                bool flag = this.dataGridView1.CurrentRow.Cells["下推状态"].Value.ToString().Trim() == "已下推";
                if (flag)
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
            }
        }
    }
}
