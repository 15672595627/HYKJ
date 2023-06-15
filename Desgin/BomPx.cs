using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Desgin
{
    public partial class BomPx : Form
    {
        public BomPx()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string BP_Ord { get; set; }
        public string BP_Clid { get; set; }


        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void SCTP_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.JPEG)|*.BMP;*.JPG;*.GIF;*.JPEG|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                label1.Text = openFileDialog.FileName.ToString();
            }
        }

        private void BC_Click(object sender, EventArgs e)
        {
            string path = label1.Text.Trim();
            SqlConnection conn = new SqlConnection(SQL);
            conn.Open();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] bytefile = new byte[fs.Length];
            fs.Read(bytefile, 0, (int)fs.Length);
            fs.Close();

            try
            {
                SqlCommand cmd = conn.CreateCommand();

                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@Img", SqlDbType.Image, int.MaxValue);

                parameters[0].Value = bytefile;

                cmd.Parameters.AddRange(parameters);

                cmd.CommandText = "UPDATE DesginBom SET Image = @Img WHERE orderid = '" + BP_Ord + "' and clid = '" + BP_Clid + "'";
                
                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("保存成功");

            }
            catch(Exception ex)
            {

                conn.Close();

                MessageBox.Show("保存失败！" + ex.ToString());
                

            }
        }

        private void BomPx_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void BomPx_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
