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

namespace WindowsFormsApp1.Main
{
    public partial class NewSupplier : Form
    {
        public NewSupplier()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void button1_Click(object sender, EventArgs e)
        {
            if(GSMC.Text == ""|| GHLB.Text == "")
            {
                MessageBox.Show("请填写完整", "警告");
            }
            else
            {
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from [dbo].[Supplier] where company ='" + GSMC.Text.Trim() + "'";
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("供应商已存在", "警告");
                }
                else
                {
                    cmd.CommandText = "insert into [dbo].[Supplier] ([company],[type]) values ('" + GSMC.Text.Trim() + "','" + GHLB.Text.Trim() + "')";
                    int cot = cmd.ExecuteNonQuery();
                    if (cot > 0)
                    {
                        MessageBox.Show("保存成功", "警告");
                    }
                    else
                    {
                        MessageBox.Show("保存失败", "警告");

                    }
                }
            }
        }
    }
}
