using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace WindowsFormsApp1.Main
{
    public partial class NewCustomer : Form
    {
        public NewCustomer()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            string aa = GSMC.Text.Trim();
            string bb = XMMC.Text.Trim();
            string dd = KHLX.Text.Trim();
            string gg = YWY.Text.Trim();
            if (aa == "" || bb == "" || dd == "" || gg == "")
            {
                MessageBox.Show("输入不得为空", "警告");
            }
            else
            {
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmmd = conn.CreateCommand();
                cmmd.CommandText = "select * from [dbo].[Customer] where company ='" + GSMC.Text.Trim() + "' and project = '%" + XMMC.Text.Trim() + "%'";
                SqlDataReader sdr = cmmd.ExecuteReader();
                sdr.Read();
                if (sdr.HasRows)
                {
                    MessageBox.Show("重复", "警告");
                }
                else
                {
                    sdr.Close();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO [dbo].[Customer] ([company],[project],[type],[seller]) VALUES ('" + aa + "','" + bb + "','" + dd + "','" + gg + "')";
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("添加成功");
                        conn.Close();
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                }

            }
        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“hyerpDataSet.Seller”中。您可以根据需要移动或移除它。
            this.sellerTableAdapter.Fill(this.hyerpDataSet.Seller);

        }

        private void YWY_DrawItem(object sender, DrawItemEventArgs e)
        {


            if (e.Index < 0)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(YWY.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y + 3);
        }

        private void XMMC_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("请输入项目名称，若没有请输入/");
        }

        /*private void XMMC_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("请");
        }*/
    }
}