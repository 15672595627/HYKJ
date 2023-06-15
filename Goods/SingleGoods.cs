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
using System.IO;

namespace WindowsFormsApp1.Goods
{
    public partial class SingleGoods : Form
    {
        public SingleGoods()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void CK_TextChanged(object sender, EventArgs e)
        {
            if (CK.Text == "")
            {
                return;
            }
            else
            {
                if (CK.Text == "原材料仓库")
                {
                    CKID.Text = "10";
                }
                if (CK.Text == "产成品仓库")
                {
                    CKID.Text = "20";
                }
                if (CK.Text == "半成品仓库")
                {
                    CKID.Text = "30";
                }
            }

        }

        private void ZL_TextChanged(object sender, EventArgs e)
        {
            if (ZL.Text == "")
            {
                return;
            }
            else
            {
                if (ZL.Text == "锌钢主材")
                {
                    ZLID.Text = "10";
                }
                if (ZL.Text == "铝艺主材")
                {
                    ZLID.Text = "20";
                }
                if (ZL.Text == "锌钢配件")
                {
                    ZLID.Text = "30";
                }
                if (ZL.Text == "铝艺配件")
                {
                    ZLID.Text = "40";
                }
                if (ZL.Text == "色粉")
                {
                    ZLID.Text = "50";
                }
                if (ZL.Text == "燃料")
                {
                    ZLID.Text = "60";
                }
                if (ZL.Text == "包装物")
                {
                    ZLID.Text = "70";
                }
                if (ZL.Text == "低值易耗品")
                {
                    ZLID.Text = "80";
                }
                string aa = ZL.Text.Trim();
                string strsql = "SELECT RANK() OVER (ORDER BY id DESC) AS [RANK],* FROM [dbo].[Goods] where kinds = '" + aa + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(strsql, SQL);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    ZX.Text = ds.Tables[0].Rows[0][2].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BH.Text == "" || WLDW.Text == "" || WLGG.Text == "" || WLMC.Text == "" || ZL.Text == "" || CK.Text == "" || WLCW.Text == "")
            {
                MessageBox.Show("请填写完整的物料信息", "警告");
            }
            else
            {
                string aa = CK.Text.Trim();
                string bb = ZL.Text.Trim();
                string cc = BH.Text.Trim();
                string dd = WLMC.Text.Trim();
                string ee = WLGG.Text.Trim();
                string ff = WLDW.Text.Trim();
                string gg = WLCW.Text.Trim();

                string ckid = CKID.Text.Trim();
                string zlid = ZLID.Text.Trim();

                string id = ckid + "." + zlid + "." + cc;

                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from [dbo].[Goods] where goodsid ='" + id + "'";
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("编码已存在", "警告");
                }
                else
                {
                    sdr.Close();
                    string path = label7.Text.Trim();

                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    byte[] bytefile = new byte[fs.Length];
                    fs.Read(bytefile, 0, (int)fs.Length);
                    fs.Close();

                    try
                    {

                        SqlParameter[] parameters = new SqlParameter[2];

                        parameters[0] = new SqlParameter("@FileName", SqlDbType.NVarChar, 200);

                        parameters[0].Value = path;

                        parameters[1] = new SqlParameter("@Img", SqlDbType.Image, int.MaxValue);

                        parameters[1].Value = bytefile;

                        cmd.Parameters.AddRange(parameters);

                        cmd.CommandText = "INSERT INTO [dbo].[Goods] ([goodsid],[goodsname],[goodsnorms],[goodsunit],[goodsnum],[warehouse],[kinds],[location],[photo],[photoname]) VALUES ('" + id + "','" + dd + "','" + ee + "','" + ff + "','0','" + aa + "','" + bb + "','" + gg + "',@Img,@FileName)";

                        cmd.ExecuteNonQuery();

                        conn.Close();

                        MessageBox.Show("保存成功");

                    }
                    catch

                    {

                        conn.Close();

                        MessageBox.Show("保存失败！");

                    }

                    
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(BH.Text == "")
            {
                MessageBox.Show("请先输入编号");
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files(*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    label7.Text = openFileDialog.FileName.ToString();
                   
                }
            }
        }
    }
}
