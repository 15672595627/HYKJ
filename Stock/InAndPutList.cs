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
using System.Xaml.Permissions;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Scheduling;

namespace WindowsFormsApp1.Stock
{
    public partial class InAndPutList : Form
    {
        public InAndPutList()
        {
            InitializeComponent();
        }
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        SqlDataAdapter da;
        DataTable dt;
        SqlDataAdapter da1;
        DataTable dt1;
        SqlDataAdapter da2;
        DataTable dt2;
        SqlDataAdapter da3;
        DataTable dt3;
        SqlDataAdapter da4;
        DataTable dt4;
        public string con_user { get; set; }
        public string con_group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void InAndPutList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

        }
        private void InAndPutList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
        int slR;
        decimal djR;
        decimal jeR;
        List<DataRow> ls = new List<DataRow>();
        int slC;
        decimal djC;
        decimal jeC;

        int sl1;
        decimal dj1;
        decimal je1;

        int sl2;
        decimal dj2;
        decimal je2;

        string id1;
        string id2;
        DataRow dr;

        
        //上月最后一天
        //string sj = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(0).AddDays(-1).ToString("yyyy-MM-dd");
        //本月时间
        //string shijian = DateTime.Now.ToString("yyyy-MM");
        private void button1_Click(object sender, EventArgs e)
        {
            string yue = dateTimePicker1.Text.Trim();//拿到datatimepiker控件的值

            string tian = Convert.ToDateTime(yue).AddMonths(0).AddDays(-1).ToString("yyyy-MM-dd");//得到上个月最后一天
            Console.WriteLine(yue);
            Console.WriteLine(tian);
            dataGridView1.Columns.Clear();

            //即时库存
            string ss = "select materialsId as 物料编码,materialsName as 物料名称,specification as 规格型号 ,unit as 单位  from MaterialStock ";
            da = new SqlDataAdapter(ss, SQL);
            dt = new DataTable();
            da.Fill(dt);

            //期初入库
            string str = "select materialsId as 物料编码,materialsName as 物料名称,specification as 规格型号 ,unit as 单位 ,sum(unitNumber) as 数量 ,sum(purchasingPrice) as 单价,sum(stockAmount) as 金额 from PutStockDetial where date like '%" + tian + "%' group by materialsId,materialsName,specification,unit";
            da1 = new SqlDataAdapter(str, SQL);
            dt1 = new DataTable();
            da1.Fill(dt1);

            //期初出库
            string str1 = "select materialsId as 物料编码,materialsName as 物料名称,specification as 规格型号 ,unit as 单位 ,sum(unitNumber) as 数量 ,sum(purchasingPrice) as 单价,sum(stockAmount) as 金额 from OutStockDetial where date like '%" + tian + "%' group by materialsId,materialsName,specification,unit";
            da2 = new SqlDataAdapter(str1, SQL);
            dt2 = new DataTable();
            da2.Fill(dt2);

            //本期收入
            string str2 = "select materialsId as 物料编码,materialsName as 物料名称,specification as 规格型号 ,unit as 单位 ,sum(unitNumber) as 数量 ,sum(purchasingPrice) as 单价,sum(stockAmount) as 金额 from PutStockDetial where date like '%" + yue + "%' group by materialsId,materialsName,specification,unit";
            da3 = new SqlDataAdapter(str2, SQL);
            dt3 = new DataTable();
            da3.Fill(dt3);

            //本期发出
            string str3 = "select materialsId as 物料编码,materialsName as 物料名称,specification as 规格型号 ,unit as 单位 ,sum(unitNumber) as 数量 ,sum(purchasingPrice) as 单价,sum(stockAmount) as 金额 from OutStockDetial where date like '%" + yue + "%' group by materialsId,materialsName,specification,unit";
            da4 = new SqlDataAdapter(str3, SQL);
            dt4 = new DataTable();
            da4.Fill(dt4);

            //添加列名称
            DataTable dtt = new DataTable();
            dtt.Columns.Add("时间", typeof(string));
            dtt.Columns.Add("物料编码", typeof(string));
            dtt.Columns.Add("物料名称", typeof(string));
            dtt.Columns.Add("规格型号", typeof(string));
            dtt.Columns.Add("单位", typeof(string));

            dtt.Columns.Add("期初收入数量", typeof(int));
            dtt.Columns.Add("期初收入单价", typeof(decimal));
            dtt.Columns.Add("期初收入金额", typeof(decimal));

            dtt.Columns.Add("期初发出数量", typeof(int));
            dtt.Columns.Add("期初发出单价", typeof(decimal));
            dtt.Columns.Add("期初发出金额", typeof(decimal));

            dtt.Columns.Add("期初结存数量", typeof(int));
            dtt.Columns.Add("期初结存单价", typeof(decimal));
            dtt.Columns.Add("期初结存金额", typeof(decimal));

            dtt.Columns.Add("本期收入数量", typeof(int));
            dtt.Columns.Add("本期收入单价", typeof(decimal));
            dtt.Columns.Add("本期收入金额", typeof(decimal));

            dtt.Columns.Add("本期发出数量", typeof(int));
            dtt.Columns.Add("本期发出单价", typeof(decimal));
            dtt.Columns.Add("本期发出金额", typeof(decimal));

            dtt.Columns.Add("期末结存数量", typeof(int));
            dtt.Columns.Add("期末结存单价", typeof(decimal));
            dtt.Columns.Add("期末结存金额", typeof(decimal));
            //添加行内容
            //库存表
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dtt.NewRow();
                string wlbm = dt.Rows[i]["物料编码"].ToString();
                string wlmc = dt.Rows[i]["物料名称"].ToString();
                string gg = dt.Rows[i]["规格型号"].ToString();
                string dw = dt.Rows[i]["单位"].ToString();
                dr["时间"] = yue;
                dr["物料编码"] = wlbm;
                dr["物料名称"] = wlmc;
                dr["规格型号"] = gg;
                dr["单位"] = dw;
                //期初入
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    id1 = dt1.Rows[j]["物料编码"].ToString();
                    if (wlbm == id1)
                    {
                        slR = Convert.ToInt32(dt1.Rows[j]["数量"]);
                        djR = Convert.ToDecimal(dt1.Rows[j]["单价"]);
                        jeR = Convert.ToDecimal(dt1.Rows[j]["金额"]);
                        dr["期初收入数量"] = slR;
                        dr["期初收入单价"] = djR;
                        dr["期初收入金额"] = jeR;
                    }
                }
                //期初出  
                for (int k = 0; k < dt2.Rows.Count; k++)
                {
                    id2 = dt2.Rows[k]["物料编码"].ToString();
                    if (wlbm == id2)
                    {
                        slC = Convert.ToInt32(dt2.Rows[k]["数量"]);
                        djC = Convert.ToDecimal(dt2.Rows[k]["单价"]);
                        jeC = Convert.ToDecimal(dt2.Rows[k]["金额"]);
                        dr["期初发出数量"] = slC;
                        dr["期初发出单价"] = djC;
                        dr["期初发出金额"] = jeC;
                    }
                }
                //本期收入
                if (dt3.Rows.Count > 0)
                {
                    for (int ii = 0; ii < dt3.Rows.Count; ii++)
                    {
                        if (wlbm == dt3.Rows[ii]["物料编码"].ToString())
                        {
                            sl1 = Convert.ToInt32(dt3.Rows[ii]["数量"]);
                            dj1 = Convert.ToDecimal(dt3.Rows[ii]["单价"]);
                            je1 = Convert.ToDecimal(dt3.Rows[ii]["金额"]);
                            dr["本期收入数量"] = sl1;
                            dr["本期收入单价"] = dj1;
                            dr["本期收入金额"] = je1;
                        }
                        /*else
                        {
                            dr["本期收入数量"] = 0;
                            dr["本期收入单价"] = 0;
                            dr["本期收入金额"] = 0;
                        }*/
                    }
                }
                
                //本期发出
                for (int jj = 0; jj < dt4.Rows.Count; jj++)
                {
                    if (wlbm == dt4.Rows[jj]["物料编码"].ToString())
                    {
                        sl2 = Convert.ToInt32(dt4.Rows[jj]["数量"]);
                        dj2 = Convert.ToDecimal(dt4.Rows[jj]["单价"]);
                        je2 = Convert.ToDecimal(dt4.Rows[jj]["金额"]);
                        dr["本期发出数量"] = sl2;
                        dr["本期发出单价"] = dj2;
                        dr["本期发出金额"] = je2;
                    }
                    /*else
                    {
                        dr["本期发出数量"] = 0;
                        dr["本期发出单价"] = 0;
                        dr["本期发出金额"] = 0;
                    }*/
                }
                
                dtt.Rows.Add(dr);
                if (dtt.Rows.Count > 0)
                {
                    for (int x = 0; x < dtt.Rows.Count; x++)
                    {
                        if (dtt.Rows[x]["期初收入数量"] == DBNull.Value)
                            dtt.Rows[x]["期初收入数量"] = 0;
                        int a = Convert.ToInt32(dtt.Rows[x]["期初收入数量"]);

                        if (dtt.Rows[x]["期初收入单价"] == DBNull.Value)
                            dtt.Rows[x]["期初收入单价"] = 0;
                        decimal b = Convert.ToDecimal(dtt.Rows[x]["期初收入单价"]);

                        if (dtt.Rows[x]["期初收入金额"] == DBNull.Value)
                            dtt.Rows[x]["期初收入金额"] = 0;
                        decimal c = Convert.ToDecimal(dtt.Rows[x]["期初收入金额"]);

                        if (dtt.Rows[x]["期初发出数量"] == DBNull.Value)
                            dtt.Rows[x]["期初发出数量"] = 0;
                        int a1 = Convert.ToInt32(dtt.Rows[x]["期初发出数量"]);

                        if (dtt.Rows[x]["期初发出单价"] == DBNull.Value)
                            dtt.Rows[x]["期初发出单价"] = 0;
                        decimal b1 = Convert.ToDecimal(dtt.Rows[x]["期初发出单价"]);

                        if (dtt.Rows[x]["期初发出金额"] == DBNull.Value)
                            dtt.Rows[x]["期初发出金额"] = 0;
                        decimal c1 = Convert.ToDecimal(dtt.Rows[x]["期初发出金额"]);

                        if (dtt.Rows[x]["本期收入数量"] == DBNull.Value)
                            dtt.Rows[x]["本期收入数量"] = 0;
                        decimal a2 = Convert.ToDecimal(dtt.Rows[x]["本期收入数量"]);

                        if (dtt.Rows[x]["本期收入单价"] == DBNull.Value)
                            dtt.Rows[x]["本期收入单价"] = 0;
                        decimal b2 = Convert.ToDecimal(dtt.Rows[x]["本期收入单价"]);

                        if (dtt.Rows[x]["本期收入金额"] == DBNull.Value)
                            dtt.Rows[x]["本期收入金额"] = 0;
                        decimal c2 = Convert.ToDecimal(dtt.Rows[x]["本期收入金额"]);

                        if (dtt.Rows[x]["本期发出数量"] == DBNull.Value)
                            dtt.Rows[x]["本期发出数量"] = 0;
                        decimal a3 = Convert.ToDecimal(dtt.Rows[x]["本期发出数量"]);

                        if (dtt.Rows[x]["本期发出单价"] == DBNull.Value)
                            dtt.Rows[x]["本期发出单价"] = 0;
                        decimal b3 = Convert.ToDecimal(dtt.Rows[x]["本期发出单价"]);

                        if (dtt.Rows[x]["本期发出金额"] == DBNull.Value)
                            dtt.Rows[x]["本期发出金额"] = 0;
                        decimal c3 = Convert.ToDecimal(dtt.Rows[x]["本期发出金额"]);

                        dtt.Rows[x]["期初结存数量"] = a - a1;
                        dtt.Rows[x]["期初结存单价"] = b - b1;
                        dtt.Rows[x]["期初结存金额"] = c - c1;

                        dtt.Rows[x]["期末结存数量"] = (a2 - a3) + (a - a1);
                        dtt.Rows[x]["期末结存单价"] = (b2 - b3) + (b - b1);
                        dtt.Rows[x]["期末结存金额"] = (c2 - c3) + (c - c1);

                    }
                }
            }
            
            dataGridView1.DataSource = dtt;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["期初收入数量"].Visible = false;
                dataGridView1.Columns["期初收入单价"].Visible = false;
                dataGridView1.Columns["期初收入金额"].Visible = false;
                dataGridView1.Columns["期初发出数量"].Visible = false;
                dataGridView1.Columns["期初发出单价"].Visible = false;
                dataGridView1.Columns["期初发出金额"].Visible = false;
            }
            int sum0 = 0;
            decimal sum1 = 0;
            decimal sum2 = 0;
            int sum3 = 0;
            decimal sum4 = 0;
            decimal sum5 = 0;
            int sum6 = 0;
            decimal sum7 = 0;
            decimal sum8 = 0;
            int sum9 = 0;
            decimal sum10 = 0;
            decimal sum11 = 0;
            int aa = 0;
            decimal bb = 0;
            decimal cc = 0;
            int dd = 0;
            decimal ee = 0;
            decimal ff = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                aa += Convert.ToInt32(dataGridView1.Rows[i].Cells["期初收入数量"].Value);
                bb += Convert.ToDecimal(dataGridView1.Rows[i].Cells["期初收入单价"].Value);
                cc += Convert.ToDecimal(dataGridView1.Rows[i].Cells["期初收入金额"].Value);

                dd += Convert.ToInt32(dataGridView1.Rows[i].Cells["期初发出数量"].Value);
                ee += Convert.ToDecimal(dataGridView1.Rows[i].Cells["期初发出单价"].Value);
                ff += Convert.ToDecimal(dataGridView1.Rows[i].Cells["期初发出金额"].Value);

                sum0 += Convert.ToInt32(dataGridView1.Rows[i].Cells["期初结存数量"].Value);
                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["期初结存单价"].Value);
                sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["期初结存金额"].Value);

                sum3 += Convert.ToInt32(dataGridView1.Rows[i].Cells["本期收入数量"].Value);
                sum4 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["本期收入单价"].Value);
                sum5 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["本期收入金额"].Value);

                sum6 += Convert.ToInt32(dataGridView1.Rows[i].Cells["本期发出数量"].Value);
                sum7 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["本期发出单价"].Value);
                sum8 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["本期发出金额"].Value);

                sum9 += Convert.ToInt32(dataGridView1.Rows[i].Cells["期末结存数量"].Value);
                sum10 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["期末结存单价"].Value);
                sum11 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["期末结存金额"].Value);
            }
            string aaa = aa.ToString();
            string bbb = bb.ToString();
            string ccc = cc.ToString();
            string ddd = dd.ToString();
            string eee = ee.ToString();
            string fff = ff.ToString();
            string ssum0 = sum0.ToString();
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
            string[] row = { "合计", "","","","",aaa, bbb,ccc,ddd,eee,fff,ssum0 , ssum1 , ssum2 , ssum3 , ssum4 , ssum5 , ssum6 , ssum7 , ssum8 , ssum9 , ssum10 , ssum11 };
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
    }
}
