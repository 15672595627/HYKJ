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

namespace WindowsFormsApp1.Goods

{
    public partial class NewMaterial : Form
    {
        public NewMaterial()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void button1_Click(object sender, EventArgs e)
        {
            string aa = textBox1.Text.Trim();
            string bb = textBox2.Text.Trim();
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [dbo].[Material] ([no1],[name1]) VALUES ('" + aa + "','" + bb + "')";
            int cnt = cmd.ExecuteNonQuery();
            if (cnt > 0)
            {
                MessageBox.Show("保存成功");
                this.Close();
            }
        }
    }
}
