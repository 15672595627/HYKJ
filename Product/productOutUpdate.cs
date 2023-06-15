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

namespace WindowsFormsApp1.Product
{
    public partial class productOutUpdate : Form
    {
        public productOutUpdate()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        public string djrq { get; set; }//单据日期
        public string djId { get; set; }//单据编号
        public string xsId { get; set; }//销售订单
        public string htId { get; set; }//合同编号
        private void productOutUpdate_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
        }

        private void btnModifiy_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string SQLstr = "select caiwuRiqi from ProductOut where orderid = '" + djId + "' and date = '" + djrq + "' and sorderid = '" + xsId + "' and contractid = '" + htId + "'";
            Convert.ToString(SQLstr);
            /*SqlDataAdapter da = new SqlDataAdapter(SQLstr, SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);*/
            if (SQLstr == "")
            {
                SqlConnection conn = new SqlConnection(SQL);
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    string str = "insert into ProductOut caiwuRiqi values ('" + dateTimePicker1.Text + "') where orderid = '" + djId + "' and date = '" + djrq + "' and sorderid = '" + xsId + "' and contractid = '" + htId + "'";
                    cmd.CommandText = str;
                    int i = cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        MessageBox.Show("更新失败！");
                    }
                    else
                    {
                        MessageBox.Show("更新成功！");
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (SQLstr != "")
            {
                SqlConnection conn = new SqlConnection(SQL);
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    string str = "update ProductOut set caiwuRiqi = '" + dateTimePicker1.Text + "' where orderid = '" + djId + "' and date = '" + djrq + "' and sorderid = '" + xsId + "' and contractid = '" + htId + "'";
                    cmd.CommandText = str;
                    int i = cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        MessageBox.Show("更新失败！");
                    }
                    else
                    {
                        MessageBox.Show("更新成功！");
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
