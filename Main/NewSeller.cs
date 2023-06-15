using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1.Main
{
    public partial class NewSeller : Form
    {
        public NewSeller()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string ywy = YWY.Text.Trim();
            string gs = GS.Text.Trim();
            string qy = QY.Text.Trim();
            string ymb = YMB.Text.Trim();
            string nmb = NMB.Text.Trim();

            if (ywy == ""|| gs == "" || qy == "" || ymb == "" || nmb == "")
            {
                MessageBox.Show("不得为空", "警告");
            }
            else
            {
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from [dbo].[Seller] where seller = '" + ywy + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("该用户名已存在", "警告");
                }
                else
                {
                    sdr.Close();
                    string myInsert = "INSERT INTO [dbo].[Seller] ([seller],[company],[area],[m_target],[y_target]) VALUES ('" + ywy + "','" + gs + "','" + qy + "','" + ymb + "','" + nmb + "')";
                    SqlCommand myCom = new SqlCommand(myInsert, conn);
                    myCom.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    MessageBox.Show("新增成功");
                    this.Close();
                }
            }
        }
    }
}