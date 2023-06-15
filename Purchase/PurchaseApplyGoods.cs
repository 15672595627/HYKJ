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
using WindowsFormsApp1.Desgin;


namespace WindowsFormsApp1.Purchase
{
    public partial class PurchaseApplyGoods : Form
    {
        public PurchaseApplyGoods()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        private void SX_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string aa = WLZLCX.Text.Trim();
            string bb = WLBMCX.Text.Trim();
            string cc = WLMCCX.Text.Trim();
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            string sql = "select goodsid as 物料编号,goodsname as 物料名称,goodsnorms as 物料规格,goodsunit as 物料单位,warehouse as 物料仓库,kinds as 物料类别,location as 库位 from [dbo].[Goods] where kinds like '%" + aa + "%' and goodsid like '%" + bb + "%' and goodsname like '%" + cc + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            string aa = dataGridView1.Rows[row].Cells[0].Value.ToString();
            PurchaseApply.PAGoods = aa;
            this.Close();

        }
    }
}