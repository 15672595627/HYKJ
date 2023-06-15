using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1.Main
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string yh = textBox1.Text.Trim();
            string mm = textBox2.Text.Trim();
            string qz = QZ.Text.Trim();

            if (yh == "" || mm == "")
            {
                MessageBox.Show("用户名或密码不得为空", "警告");
            }
            else
            {
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from [dbo].[User] where name='" + yh.Trim() + "'", conn);
                cmd.Connection = conn;
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("该用户名已存在", "警告");
                }
                else
                {
                    sdr.Close();
                    string myInsert = "INSERT INTO [dbo].[User] ([name],[groups],[password]) VALUES ('" + yh + "','" + qz + "','" + mm + "')";
                    SqlCommand myCom = new SqlCommand(myInsert, conn);
                    myCom.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    MessageBox.Show("注册成功");
                    this.Close();
                }
            }
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.user_GroupTableAdapter.FillBy1(this.hyerpDataSet.User_Group);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“hyerpDataSet.User_Group”中。您可以根据需要移动或移除它。
            this.user_GroupTableAdapter.Fill(this.hyerpDataSet.User_Group);

        }
    }
}