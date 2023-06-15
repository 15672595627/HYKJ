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

namespace WindowsFormsApp1.Product
{
    public partial class ImportProIn : Form
    {
        public ImportProIn()
        {
            InitializeComponent();
        }

        private static string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            //打开文件，获取到文件存储路径，并保存在textBox中
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;

            //导入文件，读取文件的路径，并将其导入到DataGridView中
            string fileName = "";
            fileName = textBox1.Text;
            if (textBox1.Text != "")
            {
                try
                {
                    string strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + fileName + " ;Extended Properties=Excel 8.0";
                    System.Data.OleDb.OleDbConnection myConn = new System.Data.OleDb.OleDbConnection(strCon);
                    string strCom = " SELECT * FROM [sheet1$] ";
                    //sheet1为对应表名，如果不是初始默认的，记得更改
                    System.Data.OleDb.OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter(strCom, myConn);
                    DataTable dt = new DataTable();
                    myCommand.Fill(dt);
                    //importExcel为DataGridView的Name
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请选择Excel文件");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string aa = this.dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                string bb = this.dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                string cc = this.dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                string dd = this.dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                string ee = this.dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                string ff = this.dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                string gg = this.dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();
                string hh = this.dataGridView1.Rows[i].Cells[7].Value.ToString().Trim();
                string ii = this.dataGridView1.Rows[i].Cells[8].Value.ToString().Trim();
                string jj = this.dataGridView1.Rows[i].Cells[9].Value.ToString().Trim();
                string kk = this.dataGridView1.Rows[i].Cells[10].Value.ToString().Trim();
                string ll = this.dataGridView1.Rows[i].Cells[11].Value.ToString().Trim();
                string mm = this.dataGridView1.Rows[i].Cells[12].Value.ToString().Trim();
                decimal nn = Convert.ToDecimal(dataGridView1.Rows[i].Cells[13].Value);
                decimal oo = Convert.ToDecimal(dataGridView1.Rows[i].Cells[14].Value);
                decimal pp = Convert.ToDecimal(dataGridView1.Rows[i].Cells[15].Value);
                decimal qq = Convert.ToDecimal(dataGridView1.Rows[i].Cells[16].Value);
                decimal rr = Convert.ToDecimal(dataGridView1.Rows[i].Cells[17].Value);
                string ss = this.dataGridView1.Rows[i].Cells[18].Value.ToString().Trim();
                decimal tt = Convert.ToDecimal(dataGridView1.Rows[i].Cells[19].Value);
                decimal uu = Convert.ToDecimal(dataGridView1.Rows[i].Cells[20].Value);
                string vv = this.dataGridView1.Rows[i].Cells[21].Value.ToString().Trim();
                string ww = this.dataGridView1.Rows[i].Cells[22].Value.ToString().Trim();


                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                string myInsert = "INSERT INTO [dbo].[ProductIn]([orderid],[contractid],[date],[staffin],[staffout],[company],[project],[product],[norms],[kfcz],[sjcz],[ydh],[dw],[yssl],[sssl],[zsms],[fhsl],[scdj],[shck],[cbdj],[cbje],[state],[examine]) VALUES('" + aa + "', '" + bb + "', '" + cc + "', '" + dd + "', '" + ee + "', '" + ff + "', '" + gg + "', '" + hh + "', '" + ii + "', '" + jj + "', '" + kk + "', '" + ll + "', '" + mm + "', '" + nn + "', '" + oo + "', '" + pp + "', '" + qq + "', '" + rr + "', '" + ss + "', '" + tt + "', '" + uu + "', '" + vv + "', '" + ww + "')";
                SqlCommand myCom = new SqlCommand(myInsert, con);
                int cot = myCom.ExecuteNonQuery();
                if (cot == 0)
                {
                    MessageBox.Show("失败");
                }
                con.Close();

            }


        
        }
    }
}