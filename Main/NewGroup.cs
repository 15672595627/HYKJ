using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Main
{
    public partial class NewGroup : Form
    {
        public NewGroup()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string aa = QZ.Text.Trim();

            if (aa == "")
            {
                MessageBox.Show("群组不得为空", "警告");
            }
            else
            {
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from [dbo].[User_Group] where name='" + aa + "'", conn);
                cmd.Connection = conn;
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("该群组已存在", "警告");
                }
                else
                {
                    sdr.Close();
                    string myInsert = "INSERT INTO [dbo].[User_Group] ([name]) VALUES ('" + aa + "')";
                    SqlCommand myCom = new SqlCommand(myInsert, conn);
                    myCom.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    MessageBox.Show("添加成功");
                    this.Close();
                }
            }
        }
    }
}
