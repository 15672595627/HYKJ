using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1.Main
{
    public partial class NewProduct : Form
    {
        public NewProduct()
        {
            InitializeComponent();
        }

        private static string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string zl = textBox1.Text;

            if (zl == "")
            {
                MessageBox.Show("用户名或密码不得为空", "警告");
            }
            else
            {
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from [dbo].[Product_category] where category='" + zl.Trim() + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("该用户名已存在", "警告");
                }
                else
                {
                    sdr.Close();
                    string myInsert = "INSERT INTO [dbo].[Product_category] ([category]) VALUES ('" + zl + "')";
                    SqlCommand myCom = new SqlCommand(myInsert, conn);
                    myCom.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    MessageBox.Show("注册成功");
                    this.Close();
                }
            }
        }
    }
}