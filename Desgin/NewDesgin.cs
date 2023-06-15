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
using WindowsFormsApp1.Main;
using System.Security.Policy;
using System.Net;
using Microsoft.Win32;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Desgin
{
    public partial class NewDesgin : Form
    {
        public NewDesgin()
        {
            InitializeComponent();
            //this.dataGridView1.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e) { };
        }



        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public static string WL = "";

        public string Des_User { get; set; }
        public string Des_Group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void NewDesgin_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            DJRQ.Text = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "XLD"+ time;
            toolStripStatusLabel2.Text = Des_User;
            toolStripStatusLabel5.Text = Des_Group;
            SJY.Text = Des_User;
        }

        private void BC_Click(object sender, EventArgs e)
        {
            if (HTBH.Text == ""||MS.Text =="")
            {
                MessageBox.Show("请选择合同/输入米数");
            }
            else
            {
                string djbh = DJBH.Text.Trim();
                string djrq = DJRQ.Text.Trim();
                string ms = MS.Text.Trim();
                string htbh = HTBH.Text.Trim();
                string gsm = GSM.Text.Trim();
                string xmmc = XMMC.Text.Trim();
                string ys = CPYS.Text.Trim();
                string sjy = SJY.Text.Trim();
                string cp = CP.Text.Trim();
                string sf = SF.Text.Trim();


                SqlConnection con = new SqlConnection(SQL);
                try
                {

                    con.Open();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string clid = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                        string clgg = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                        string clmc = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                        string cllb = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                        string ccpf = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                        string zs = dataGridView1.Rows[i].Cells[5].Value.ToString().Trim();
                        string bz = dataGridView1.Rows[i].Cells[6].Value.ToString().Trim();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO [dbo].[DesginBom] ([orderid],[contractid],[date],[desgin],[company],[project],[color],[product],[sfyl],[meters],[clid],[clmc],[clgg],[cllb],[ccpf],[zs],[bz],[status],[examine],[examine1]) VALUES ('" + djbh + "','" + htbh + "','" + djrq + "','" + sjy + "','" + gsm + "','" + xmmc + "','" + ys + "','" + cp + "','" + sf + "','" + ms + "','" + clid + "','" + clmc + "','" + clgg + "','" + cllb + "','" + ccpf + "','" + zs + "','" + bz + "','未知','未审核','未审核')";
                        int cot = cmd.ExecuteNonQuery();

                        if (cot == 0)
                        {
                            MessageBox.Show("保存失败");
                        }

                    }
                    MessageBox.Show("保存成功");
                    BC.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新失败，失败原因" + ex.Message + "空白行全部删掉，空白要输完整！");

                }
                finally
                {
                    con.Close();
                }         
                this.Close();
            }

        }

        private void HTBH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (HTBH.Text == "")
                {
                    MessageBox.Show("请输入合同编号");
                }
                else
                {
                    string aa = HTBH.Text.Trim();
                    string strsql = String.Format("select contractid as 合同编号,company as 公司,project as 项目名称 from [dbo].[Contract_h] where contractid = '" + aa + "' ");
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count > 0)
                    {
                        GSM.Text = dt.Rows[0][1].ToString().Trim();
                        XMMC.Text = dt.Rows[0][2].ToString().Trim();
                    }
                    else
                    {
                        MessageBox.Show("未查询到合同信息，内勤还未录入系统。");
                    }
                }
            }
        }

        private void DRMBXZ_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //设置保存文件对话框的标题
            saveFileDialog1.Title = "请选择要保存的文件路径";
            //初始化保存目录，默认exe文件目录
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            //设置保存文件的类型
            saveFileDialog1.Filter = "Excel 工作簿（*.xls）|*.xls";
            saveFileDialog1.FileName = "下料单主材导入";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                try
                {
                    System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("http://192.168.0.250/%E4%B8%8B%E6%96%99%E5%8D%95%E5%AF%BC%E5%85%A51201.xls");
                    System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                    System.IO.Stream st = myrp.GetResponseStream();
                    System.IO.Stream so = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
                    byte[] by = new byte[1024];
                    int osize = st.Read(by, 0, (int)by.Length);
                    while (osize > 0)
                    {
                        so.Write(by, 0, osize);
                        osize = st.Read(by, 0, (int)by.Length);
                    }
                    so.Close();
                    st.Close();
                    myrp.Close();
                    Myrq.Abort();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void SJDR_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
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

        private void NewDesgin_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void HTBH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Desgin_Con desgin_Con = new Desgin_Con();
            desgin_Con.ShowDialog(this);
        }

        private void MS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
        }
    }
}