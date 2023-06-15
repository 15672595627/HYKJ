using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1.Calc
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private static string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SQL);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string sql = String.Format("select uid as 编号,Seller as 业务员,Company as 公司名称,Product as 产品,High as 高,Long as 长,Steel as 钢材价格,Freight as 运输费,Amount as 金额,AmountTAX as 含税金额,create_time as 报价时间 from[dbo].[Price_h] ");
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string a = BH.Text;
            SqlConnection con = new SqlConnection(SQL);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string sql = String.Format("select uid as 编号,Seller as 业务员,Company as 公司名称,Product as 产品,High as 高,Long as 长,Steel as 钢材价格,Freight as 运输费,Amount as 金额,AmountTAX as 含税金额,create_time as 报价时间 from [dbo].[Price_h] where uid like '%" + @a + "%' ");
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            //查询出来的公司名称
            //
            string kh = dataGridView1.Rows[0].Cells[2].Value.ToString();
            string time = DateTime.Now.ToString("yyyy-MM-dd");

            //
            //查询sql中的数据
            //
            SqlConnection con = new SqlConnection(SQL);//实例化一个连接
            con.Open();//打开数据库连接
            SqlDataAdapter da = new SqlDataAdapter();//实例化sqldataadpter
            SqlCommand cmd = new SqlCommand("SELECT * from [dbo].[Price_e] WHERE Company ='" + kh + "'", con);//sql语句
            da.SelectCommand = cmd;//设置为已实例化SqlDataAdapter的查询命令
            DataSet ds = new DataSet();//实例化dataset
            da.Fill(ds);//把数据填充到dataset

            if (ds == null)
            {
                MessageBox.Show("数据库为空");
            }

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = xlApp.Workbooks.Open("D:\\book.xls");

            Sheets shs = workbook.Sheets;
            Worksheet worksheet = (Worksheet)shs.get_Item(1);
            worksheet.Cells[3, 2] = kh;
            worksheet.Cells[3, 6] = time;
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }
            else
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    for (int i = 3; i < ds.Tables[0].Columns.Count; i++)
                    {
                        worksheet.Cells[r + 6, i - 1] = ds.Tables[0].Rows[r][i];
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                //worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
                string saveFileName = "C:\\" + "报价单" + kh + ".xls"; ;
                MessageBox.Show("资料保存成功", "提示", MessageBoxButtons.OK);
                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);  //fileSaved = true;
                    }
                    catch (Exception ex)
                    {//fileSaved = false;
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = KH.Text;

            SqlConnection con = new SqlConnection(SQL);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string sql = String.Format("select uid as 编号,Seller as 业务员,Company as 公司名称,Product as 产品,High as 高,Long as 长,Steel as 钢材价格,Freight as 运输费,Amount as 金额,AmountTAX as 含税金额,create_time as 报价时间 from[dbo].[Price_h] where Company like '%" + @a + "%' ");
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = YWY.Text;
            SqlConnection con = new SqlConnection(SQL);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string sql = String.Format("select uid as 编号,Seller as 业务员,Company as 公司名称,Product as 产品,High as 高,Long as 长,Steel as 钢材价格,Freight as 运输费,Amount as 金额,AmountTAX as 含税金额,create_time as 报价时间 from[dbo].[Price_h] where Seller like '%" + @a + "%' ");
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            SqlConnection con = new SqlConnection(SQL);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string sql = String.Format("select uid as 编号,Project as 项目名称,Specification as 规格,Perimeter as 周长,Thickness as 厚度,Quantity as 数量,Meterweight as 米重,Unitprice as 单价,Thicknessd as 厚薄差,Expense as 费用率,Amount as 金额,AmountTAX as 含税金额,create_time as 创建时间 from[dbo].[Price_b] where uid = '" + a + "'");

            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Details details = new Details();
            // 给窗体的公共属性赋值
            details.StrMessage = a;
            // 显示子窗体
            details.Show();
        }
    }
}