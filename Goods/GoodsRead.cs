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
    public partial class GoodsRead : Form
    {
        public GoodsRead()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        public string g_id { get; set; }

        private void GoodsRead_Load(object sender, EventArgs e)
        {
            string aa = g_id.Trim();
            string strsql = "select * from [dbo].[Goods] where goodsid = '" + aa + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            CK.Text = ds.Tables[0].Rows[0][8].ToString();
            ZL.Text = ds.Tables[0].Rows[0][9].ToString();
            BH.Text = ds.Tables[0].Rows[0][1].ToString();
            WLMC.Text = ds.Tables[0].Rows[0][2].ToString();
            WLGG.Text = ds.Tables[0].Rows[0][3].ToString();
            WLDW.Text = ds.Tables[0].Rows[0][4].ToString();
            WLCW.Text = ds.Tables[0].Rows[0][10].ToString();
            if (ds.Tables[0].Rows[0][11].ToString() != "")
            {
                Byte[] bytefile = (Byte[])ds.Tables[0].Rows[0][11];
                MemoryStream stream = new MemoryStream(bytefile, 0, bytefile.Length);
                pictureBox1.Image = Image.FromStream(stream);
                stream.Close();
            }

        }
    }
}
