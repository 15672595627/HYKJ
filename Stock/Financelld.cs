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
using WindowsFormsApp1.Scheduling;

namespace WindowsFormsApp1.Stock
{
    public partial class Financelld : Form
    {
        public Financelld()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da = null;
        private DataTable dt = null;

        private SqlDataAdapter da1 = null;
        private DataTable dt1 = null;

        private SqlDataAdapter da2 = null;
        private DataTable dt2 = null;
        DataRow dr;
        decimal zcje;
        decimal fcje;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void button1_Click(object sender, EventArgs e)
        {
            string sj1 = dateTimePicker1.Text;
            //string sj2 = dateTimePicker2.Text;
            string str = "select id,date as 时间,contactId as 合同编号,materialsId as 物料编号,company as 客户 ,wsje as 无税金额 from linliaodan where contactId like '%" + textBox1.Text + "%' and date like '%"+sj1+ "%'";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);

            string str1 = "select id,date as 时间,contactId as 合同编号,materialsId as 物料编号,company as 客户 ,wsje as 无税金额, je as 主材金额 from linliaodan where stockName like '%主材%' and contactId like '%" + textBox1.Text + "%' and date like '%"+sj1+ "%'";
            da1 = new SqlDataAdapter(str1, SQL);
            dt1 = new DataTable();
            da1.Fill(dt1);

            string str2 = "select id,date as 时间,contactId as 合同编号,materialsId as 物料编号,company as 客户 ,wsje as 无税金额, je as 辅材金额 from linliaodan where stockName like '%辅材%' and contactId like '%" + textBox1.Text + "%' and date  like '%"+sj1+ "%'";
            da2 = new SqlDataAdapter(str2, SQL);
            dt2 = new DataTable();
            da2.Fill(dt2);

            DataTable dtt = new DataTable();
            dtt.Columns.Add("时间", typeof(string));
            dtt.Columns.Add("合同编号", typeof(string));
            dtt.Columns.Add("物料编号", typeof(string));
            dtt.Columns.Add("客户", typeof(string));
            dtt.Columns.Add("无税金额", typeof(string));
            dtt.Columns.Add("主材金额", typeof(string));
            dtt.Columns.Add("辅材金额", typeof(string));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dtt.NewRow();
                string sj = dt.Rows[i]["时间"].ToString();
                string htbh = dt.Rows[i]["合同编号"].ToString();
                string wlbh = dt.Rows[i]["物料编号"].ToString();
                string kh = dt.Rows[i]["客户"].ToString();
                if (dt.Rows[i]["无税金额"] == DBNull.Value)
                    dt.Rows[i]["无税金额"] = 0;
                decimal wsje = Convert.ToDecimal(dt.Rows[i]["无税金额"]);
                dr["时间"] = sj;
                dr["合同编号"] = htbh;
                dr["物料编号"] = wlbh;
                dr["客户"] = kh;
                dr["无税金额"] = wsje;
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    string wlbh1 = dt1.Rows[j]["物料编号"].ToString();
                    if (wlbh.Equals(wlbh1))
                    {
                        zcje = Convert.ToDecimal(dt1.Rows[j]["主材金额"]);
                        dr["主材金额"] = zcje;
                    }
                }
                for (int k = 0; k < dt2.Rows.Count; k++)
                {
                    string wlbh2 = dt2.Rows[k]["物料编号"].ToString();
                    if (wlbh.Equals(wlbh2))
                    {
                        fcje = Convert.ToDecimal(dt2.Rows[k]["辅材金额"]);
                        dr["辅材金额"] = fcje;
                    }
                }

                dtt.Rows.Add(dr);
                if (dtt.Rows.Count > 0)
                {
                    for (int x = 0; x < dtt.Rows.Count; x++)
                    {
                        if (dtt.Rows[x]["无税金额"] == DBNull.Value)
                            dtt.Rows[x]["无税金额"] = 0;
                        decimal a = Convert.ToDecimal(dtt.Rows[x]["无税金额"]);

                        if (dtt.Rows[x]["主材金额"] == DBNull.Value)
                            dtt.Rows[x]["主材金额"] = 0;
                        decimal b = Convert.ToDecimal(dtt.Rows[x]["主材金额"]);

                        if (dtt.Rows[x]["辅材金额"] == DBNull.Value)
                            dtt.Rows[x]["辅材金额"] = 0;
                        decimal c = Convert.ToDecimal(dtt.Rows[x]["辅材金额"]);
                    }
                }
            }
            dataGridView1.DataSource = dtt;
            //decimal sum1 = 0;
            decimal sum2 = 0;
            decimal sum3 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["无税金额"].Value);
                sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["主材金额"].Value);
                sum3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["辅材金额"].Value);
            }
            //string ssum1 = sum1.ToString();
            string ssum2 = sum2.ToString();
            string ssum3 = sum3.ToString();
            string[] row = { "合计", "","","", "0", ssum2, ssum3 };
            ((DataTable)dataGridView1.DataSource).Rows.Add(row);
        }

        private void Financelld_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
        }

        private void Financelld_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
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
