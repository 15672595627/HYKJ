using Microsoft.Win32;
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

namespace WindowsFormsApp1
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void button1_Click(object sender, EventArgs e)
        {
            string nr = richTextBox1.Text.Trim();
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into [dbo].[Feedback] ([sub]) values ('" + nr + "')";
            int cot = cmd.ExecuteNonQuery();
            if (cot > 0)
            {
                MessageBox.Show("保存成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}
