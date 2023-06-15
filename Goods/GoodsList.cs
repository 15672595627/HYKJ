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

namespace WindowsFormsApp1.Goods
{
    public partial class GoodsList : Form
    {
        public GoodsList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        DataTable dt;
        SqlDataAdapter da;

        private void SX_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string aa = WLZLCX.Text.Trim();
            string bb = WLGGCX.Text.Trim();
            string cc = WLMCCX.Text.Trim();
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            string sql = "select goodsid as 物料编号,goodsname as 物料名称,goodsnorms as 物料规格,goodsunit as 物料单位,goodsnum as 物料数量,goodsprice as 物料单价,goodsamount as 物料金额,warehouse as 物料仓库,kinds as 物料类别,location as 库位 from [dbo].[Goods] where kinds like '%" + aa + "%' and goodsnorms like '%" + bb + "%' and goodsname like '%" + cc + "%'";
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string aa = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            GoodsRead goodsRead = new GoodsRead();
            goodsRead.g_id = aa;
            goodsRead.ShowDialog();

        }

        private void XZ_Click(object sender, EventArgs e)
        {
           SingleGoods goods = new SingleGoods();
           goods.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

        }
    }
}