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

namespace WindowsFormsApp1.Date
{
    public partial class Dis_Date : Form
    {
        public Dis_Date()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            if (LCDZ.Text == "")
            {
                MessageBox.Show("请输入拉尺的地点");
            }
            else
            {
                SqlConnection con = new SqlConnection(SQL);
                try
                {
                    string aa = DJBH.Text;
                    string bb = HTBH.Text;
                    string cc = LDRQ.Text;
                    string dd = GCMC.Text;
                    string ee = LCDZ.Text;
                    string ff = YWY.Text;
                    string gg = BZ.Text;

                    con.Open();
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        SqlCommand cmd = new SqlCommand();
                        string mc = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                        string ms = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                        string sqlstr = "INSERT INTO [dbo].[Dis_Date] ([orderid],[contractid],[date],[project],[address],[seller],[title],[meters],[remarks]) VALUES ('" + aa + "','" + bb + "','" + cc + "','" + dd + "','" + ee + "','" + ff + "','" + mc + "','" + ms + "','" + gg + "',)";
                        cmd.CommandText = sqlstr;
                        cmd.Connection = con;
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            MessageBox.Show("保存成功");
                        }
                        else
                        {
                            MessageBox.Show("保存失败");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败，失败原因" + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }



        private void Distributiondate_Load(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            string  date = DateTime.Now.ToString("d");
            DJBH.Text = "LCSJ" + time;
            LDRQ.Text = date;

        }

        private void HTBH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Dis_Contract dis_Contract = new Dis_Contract();
            dis_Contract.Show(this);
        }

        private void HTBH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(HTBH.Text == "")
                {
                    MessageBox.Show("请输入合同编号");
                }
                else
                {
                    string aa = HTBH.Text.Trim();
                    string strsql = "select contractid as 合同编号,company as 公司名称 from [dbo].[Contract_h] where contractid = '" + aa + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GCMC.Text = ds.Tables[0].Rows[0][1].ToString();
                }
            }
        }
    }
}