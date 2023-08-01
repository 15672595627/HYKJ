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
    public partial class GroupListDetial : Form
    {
        public GroupListDetial()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da;
        private DataTable dt;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        public static string[] a;

        private void GroupListDetial_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
        }

        private void GroupListDetial_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }
        public string cId { get; set; }
        private void SX_Click(object sender, EventArgs e)
        {

            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.Columns.Clear();
                string text = this.txtCcpf.Text.Trim();
                string text2 = this.txtName.Text.Trim();
                string text3 = this.txtlb.Text.Trim();
                string text4 = this.txtNorms.Text.Trim();
                string selectCommandText = string.Format(string.Concat(new string[]
                {
                "select id,orderid as 单据编号,contractid as 合同编号,date as 日期,desgin as 下单员,company as 客户名,project as 项目名称,color as 颜色,product as 产品,sfyl as 塑粉用量,meters as 米数,clid as 材料ID,clmc as 材料名称,clgg as 材料规格,cllb as 材料类别,ccpf as 尺寸喷粉,zs as 支数,bz as 备注,status as 状态,examine as 审核状态,examine1 as 生产部审核状态 from [dbo].[DesginBom] where ccpf like '%",
                text,
                "%' and clmc like '%",
                text2,
                "%' and cllb like '%",
                text3,
                "%' and clgg like '%",
                text4,
                "%' and contractid = '",
                this.cId,
                "'"
                }), Array.Empty<object>());
                this.da = new SqlDataAdapter(selectCommandText, GroupListDetial.SQL);
                this.dt = new DataTable();
                this.da.Fill(this.dt);
                this.dataGridView1.DataSource = this.dt;
                this.dataGridView1.Columns["id"].Visible = false;
                DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
                dataGridViewButtonColumn.Text = "上传图片";
                dataGridViewButtonColumn.HeaderText = "附件";
                dataGridViewButtonColumn.Name = "附件";
                dataGridViewButtonColumn.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(dataGridViewButtonColumn);
            }
        }

        private void BC_Click(object sender, EventArgs e)
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
                    return;
                }
                MessageBox.Show("更新成功!");
                this.dataGridView1.ReadOnly = true;
                this.删除ToolStripMenuItem.Enabled = false;
                this.插入ToolStripMenuItem.Enabled = false;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.AllowUserToDeleteRows = true;
            this.dataGridView1.Columns["单据编号"].ReadOnly = true;
            this.dataGridView1.Columns["合同编号"].ReadOnly = true;
            this.dataGridView1.Columns["日期"].ReadOnly = true;
            this.BC.Enabled = true;
            this.删除ToolStripMenuItem.Enabled = true;
            this.插入ToolStripMenuItem.Enabled = true;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BomPxList
            {
                BPL_Ord = this.dataGridView1.CurrentRow.Cells["订单编号"].Value.ToString(),
                BPL_Clid = this.dataGridView1.CurrentRow.Cells["材料ID"].Value.ToString()
            }.ShowDialog();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Remove(this.dataGridView1.CurrentRow);
        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = this.dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            SqlConnection sqlConnection = new SqlConnection(GroupListDetial.SQL);
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "UPDATE [dbo].[Desgin_h] SET examine = '已审核' where orderid like '%" + str + "%'";
            int num = sqlCommand.ExecuteNonQuery();
            bool flag = num > 0;
            if (flag)
            {
                MessageBox.Show("审核成功");
            }
            else
            {
                MessageBox.Show("审核失败");
            }
            sqlConnection.Close();
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
            string str = this.dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            SqlConnection sqlConnection = new SqlConnection(GroupListDetial.SQL);
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "UPDATE [dbo].[Desgin_h] SET examine = '未审核' where orderid like '%" + str + "%'";
            int num = sqlCommand.ExecuteNonQuery();
            bool flag = num > 0;
            if (flag)
            {
                MessageBox.Show("反审核成功");
            }
            else
            {
                MessageBox.Show("反审核失败");
            }
            sqlConnection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool flag = this.dataGridView1.CurrentCell.OwningColumn.Name == "附件";
            if (flag)
            {
                new BomPx
                {
                    BP_Ord = this.dataGridView1.CurrentRow.Cells["订单编号"].Value.ToString(),
                    BP_Clid = this.dataGridView1.CurrentRow.Cells["材料ID"].Value.ToString()
                }.ShowDialog();
            }
        }
    }
}
