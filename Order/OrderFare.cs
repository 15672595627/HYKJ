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

namespace WindowsFormsApp1.Order
{
    public partial class OrderFare : Form
    {
        public OrderFare()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string OF_HTBH { get; set; }
        public string OF_GSM { get; set; }
        public string OF_XMMC { get; set; }

        private void OrderFare_Load(object sender, EventArgs e)
        {
            HTBH.Text = OF_HTBH;
            GSM.Text = OF_GSM;
            XMMC.Text = OF_XMMC;
        }

        private void BC_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert INTO [dbo].[Order_h] ([ysf]) VALUES ('" + YF.Text.Trim() + "') where contractid = '" + HTBH.Text.Trim() + "'";
            int cot = cmd.ExecuteNonQuery();
            if (cot > 0)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}
