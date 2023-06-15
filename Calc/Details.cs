using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1.Calc
{
    public partial class Details : Form
    {
        public Details()
        {
            InitializeComponent();
        }

        private static string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string StrMessage { get; set; }

        private void Details_Load(object sender, EventArgs e)
        {
            textBox1.Text = StrMessage;
            string a = textBox1.Text;
            byte[] bytFile;
            SqlConnection conn = new SqlConnection(SQL);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string strSql = "select Image from [dbo].[Price_h] where uid = '" + a + "'";
                cmd.Connection = conn;
                cmd.CommandText = strSql;
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    bytFile = (Byte[])sdr["Image"];
                }
                else
                {
                    bytFile = new byte[0];
                }
                sdr.Close();
                conn.Close();
                //通过内存流MemoryStream，
                //把byte[]数组fileContent加载到Image中并赋值给图片框的Image属性，
                //让数据库中的图片直接显示在窗体上。
                MemoryStream ms = new MemoryStream(bytFile, 0, bytFile.Length);
                this.pictureBox1.Image = Image.FromStream(ms);
                //关闭内存流
                ms.Close();
            }
            catch
            {
                conn.Close();
                MessageBox.Show("失败");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "";
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "Jpeg";
            saveDialog.Filter = "Jpg 图片|*.jpg|Bmp 图片|*.bmp|Gif 图片|*.gif|Png 图片|*.png|Wmf  图片|*.wmf"; ;
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("没有预览图片！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (pictureBox1.Image != null || saveFileName != null)
                {
                    pictureBox1.Image.Save(saveFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }


    }
}