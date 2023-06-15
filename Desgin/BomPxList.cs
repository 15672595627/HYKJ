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

namespace WindowsFormsApp1.Desgin
{
    public partial class BomPxList : Form
    {
        public BomPxList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        public string BPL_Ord { get; set; }
        public string BPL_Clid { get; set; }

        private void BomPxList_Load(object sender, EventArgs e)
        {
            string strsql = "SELECT orderid,clid,image FROM [dbo].[DesginBom] where orderid = '" + BPL_Ord + "' and  clid = '" + BPL_Clid + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][2].ToString() != "")
            {
                Byte[] bytefile = (Byte[])dt.Rows[0][2];
                MemoryStream stream = new MemoryStream(bytefile, 0, bytefile.Length);
                pictureBox1.Image = Image.FromStream(stream);
                stream.Close();
            }
        }
    }
}
