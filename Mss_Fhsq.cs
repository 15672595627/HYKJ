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
    public partial class Mss_Fhsq : Form
    {
        public Mss_Fhsq()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void MssForm_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            label4.Parent = pictureBox1;
            button1.Parent = pictureBox1;

            string strsql = "select id,contractid as 合同编号,service as 跟单员,company as 公司名称,project as 项目名称,productname as 产品名称,sub as 内容,quantity as 数量,unit as 单位,price as 单价,amount as 金额 from [dbo].[Message_FHSQ] where examine = '未审核'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                string cot = dt.Rows.Count.ToString();

                label3.Text = cot;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Message_FHSQ SET readzt = '已读' WHERE examine = '未审核'";
            cmd.ExecuteNonQuery();
            button2.Enabled= false;
        }
    }
}
