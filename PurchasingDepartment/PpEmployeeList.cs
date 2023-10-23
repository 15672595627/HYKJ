﻿using System;
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
using WindowsFormsApp1.FinanceDepartment;

namespace WindowsFormsApp1.PurchasingDepartment
{
    public partial class PpEmployeeList : Form
    {
        public PpEmployeeList()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da = null;
        private DataTable dt = null;
        int cot = 0;
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void PEmployeeList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void PEmployeeList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请输入查看类别！");
            }
            else
            {
                if (comboBox1.Text == "新增人员")
                {
                    string str = "select id,[position] as 岗位名称, [reason] as 原因, [numberPeople] as 计划入职人数, [date] as 月份 ,state2 as 状态 from [dbo].[CGBPersonnelDetails] where date like '%" + dateTimePicker1.Text.Trim() + "%' and state = 1 and state2 = 1 order by date desc";
                    da = new SqlDataAdapter(str, SQL);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["状态"].Visible = false;
                    int sum1 = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells["计划入职人数"].Value);
                    }
                    string ssum1 = sum1.ToString();
                    string[] row = { "1", "合计", "", ssum1, "" };
                    ((DataTable)dataGridView1.DataSource).Rows.Add(row);
                }
                else if (comboBox1.Text == "减少人员")
                {
                    string str = "select id,[position] as 岗位名称, [reason] as 原因, [numberPeople] as 计划入职人数, [date] as 月份 ,state2 as 状态 from [dbo].[CGBPersonnelDetails] where date like '%" + dateTimePicker1.Text.Trim() + "%' and state = -1 and state2 = 1 order by date desc";
                    da = new SqlDataAdapter(str, SQL);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["状态"].Visible = false;
                    int sum1 = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells["计划入职人数"].Value);
                    }
                    string ssum1 = sum1.ToString();
                    string[] row = { "1", "合计", "", ssum1, "", };
                    ((DataTable)dataGridView1.DataSource).Rows.Add(row);
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (comboBox1.Text == "新增人员")
            {
                string iId = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                PUpdateAddEmployee updateCGXBBudget = new PUpdateAddEmployee();
                updateCGXBBudget.id = iId;
                updateCGXBBudget.Username = Username;
                updateCGXBBudget.Group = Group;
                updateCGXBBudget.ShowDialog();
            }
            else
            {
                string iId = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                PUpdateReduceEmployee updateCGXBBudget = new PUpdateReduceEmployee();
                updateCGXBBudget.id = iId;
                updateCGXBBudget.Username = Username;
                updateCGXBBudget.Group = Group;
                updateCGXBBudget.ShowDialog();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                int m = dataGridView1.SelectedRows[i].Index;
                int id = Convert.ToInt32(dataGridView1.Rows[m].Cells["id"].Value);
                decimal zt = Convert.ToDecimal(dataGridView1.Rows[m].Cells["状态"].Value);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update CGBPersonnelDetails set  state = -1 where id = '" + id + "'";
                cot = cmd.ExecuteNonQuery();
            }
            if (cot > 0)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            conn.Close();
            this.Close();
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
    }
}
