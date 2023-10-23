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

namespace WindowsFormsApp1.SalesDepartment
{
    public partial class WHGCSummaryBudgetList : Form
    {
        public WHGCSummaryBudgetList()
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
        private void WHGCSummaryBudgetList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void WHGCSummaryBudgetList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select [id], [date] as 月份,[wages] as 工资, [awardRaising] as 提奖, [socialSecurity] as 社保, [accumulationFund] as 公积金, [boardExpenses ] as 伙食费, [benefit] as 福利费, [commercialInsurance] as 商业保险, [educationFund] as 教育基金, [weldingExternalProcessing] as 焊接外加工, [processingFee] as加工费, [officeExpenses] as 办公费, [communicationFee] as 通讯费, [travelExpenses] as 差旅费, [automobileExpenses] as 汽车开支, [lowValueConsumables] as 低值易耗品, [waterAndElectricityExpenses] as 水电费, [gasCost] as 燃气费, [freight] as 运费, [PromotionFee] as 推广费, [costOfOperation] as 业务费, [entertainmentExpenses] as 招待费, [rent] as 房租, [maintenanceCost] as 维修费, [constructionSiteExpenses] as 工地开支, [sample] as 样品, [supplementaryOrde] as 补单, [recruitmentFees] as 招聘费, [interestExpense] as 利息支出, [commission] as 手续费, [taxes] as 税金, [other] as 其他, [state] as 状态 from SalesBudget where date like '%" + dateTimePicker1.Text.Trim() + "%' and company = '武汉工程' and state = 1 order by date desc";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["状态"].Visible = false;
            decimal sum1 = 0;
            decimal sum2 = 0;
            decimal sum3 = 0;
            decimal sum4 = 0;
            decimal sum5 = 0;
            decimal sum6 = 0;
            decimal sum7 = 0;
            decimal sum8 = 0;
            decimal sum9 = 0;
            decimal sum10 = 0;
            decimal sum11 = 0;
            decimal sum12 = 0;
            decimal sum13 = 0;
            decimal sum14 = 0;
            decimal sum15 = 0;
            decimal sum16 = 0;
            decimal sum17 = 0;
            decimal sum18 = 0;
            decimal sum19 = 0;
            decimal sum20 = 0;
            decimal sum21 = 0;
            decimal sum22 = 0;
            decimal sum23 = 0;
            decimal sum24 = 0;
            decimal sum25 = 0;
            decimal sum26 = 0;
            decimal sum27 = 0;
            decimal sum28 = 0;
            decimal sum29 = 0;
            decimal sum30 = 0;
            decimal sum31 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                sum3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                sum4 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                sum5 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                sum6 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                sum7 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                sum8 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                sum9 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
                sum10 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[11].Value);
                sum11 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[12].Value);
                sum12 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[13].Value);
                sum13 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[14].Value);
                sum14 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[15].Value);
                sum15 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[16].Value);
                sum16 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[17].Value);
                sum17 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[18].Value);
                sum18 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[19].Value);
                sum19 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[20].Value);
                sum20 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[21].Value);
                sum21 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[22].Value);
                sum22 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[23].Value);
                sum23 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[24].Value);
                sum24 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[25].Value);
                sum25 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[26].Value);
                sum26 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[27].Value);
                sum27 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[28].Value);
                sum28 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[29].Value);
                sum29 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[30].Value);
                sum30 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[31].Value);
                sum31 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[32].Value);

            }
            string ssum1 = sum1.ToString();
            string ssum2 = sum2.ToString();
            string ssum3 = sum3.ToString();
            string ssum4 = sum4.ToString();
            string ssum5 = sum5.ToString();
            string ssum6 = sum6.ToString();
            string ssum7 = sum7.ToString();
            string ssum8 = sum8.ToString();
            string ssum9 = sum9.ToString();
            string ssum10 = sum10.ToString();
            string ssum11 = sum11.ToString();
            string ssum12 = sum12.ToString();
            string ssum13 = sum13.ToString();
            string ssum14 = sum14.ToString();
            string ssum15 = sum15.ToString();
            string ssum16 = sum16.ToString();
            string ssum17 = sum17.ToString();
            string ssum18 = sum18.ToString();
            string ssum19 = sum19.ToString();
            string ssum20 = sum20.ToString();
            string ssum21 = sum21.ToString();
            string ssum22 = sum22.ToString();
            string ssum23 = sum23.ToString();
            string ssum24 = sum24.ToString();
            string ssum25 = sum25.ToString();
            string ssum26 = sum26.ToString();
            string ssum27 = sum27.ToString();
            string ssum28 = sum28.ToString();
            string ssum29 = sum29.ToString();
            string ssum30 = sum30.ToString();
            string ssum31 = sum31.ToString();
            string[] row = { "1", "合计", ssum1, ssum2, ssum3, ssum4, ssum5, ssum6, ssum7, ssum8, ssum9, ssum10, ssum11, ssum12, ssum13, ssum14, ssum15, ssum16, ssum17, ssum18, ssum19, ssum20, ssum21, ssum22, ssum23, ssum24, ssum25, ssum26, ssum27, ssum28, ssum29, ssum30, ssum31 };
            ((DataTable)dataGridView1.DataSource).Rows.Add(row);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string iId = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            WHGCUpdateSummaryBudget updateCGXBBudget = new WHGCUpdateSummaryBudget();
            updateCGXBBudget.id = iId;
            updateCGXBBudget.Username = Username;
            updateCGXBBudget.Group = Group;
            updateCGXBBudget.ShowDialog();
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
                cmd.CommandText = "update SalesBudget set  state = -1 where id = '" + id + "'";
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
