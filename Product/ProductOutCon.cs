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

namespace WindowsFormsApp1.Product
{
    public partial class ProductOutCon : Form
    {
        public ProductOutCon()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        DataTable dt = new DataTable();


        private void Button1_Click(object sender, EventArgs e)
        {

            string aa = CP.Text.Trim();
            string bb = GSM.Text.Trim();
            string cc = XMMC.Text.Trim();
            string strsql = "select orderid as 销售订单,contractid as 合同编号,company as 公司名,project as 项目名称,productname as 产品,sub as 内容,quantity as 数量,unit as 单位,price as 单价,meters as 米数,amount as 金额 from [dbo].[Order_b] where productname like '%" + aa + "%' and company like '%" + bb + "%'  and project like '%" + cc + "%'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int count = 0; count < dataGridView1.Columns.Count; count++)
                {
                    DataColumn dc = new DataColumn(dataGridView1.Columns[count].Name.ToString());
                    dt.Columns.Add(dc);
                }
                // 循环行
                for (int count = 0; count < dataGridView1.SelectedRows.Count; count++)
                {
                    DataRow dr = dt.NewRow();
                    int m = dataGridView1.SelectedRows[count].Index;
                    for (int countsub = 0; countsub < dataGridView1.Columns.Count; countsub++)
                    {
                        dr[countsub] = Convert.ToString(dataGridView1.Rows[m].Cells[countsub].Value);
                    }
                    dt.Rows.Add(dr);
                }

                ProductOut proout = (ProductOut)this.Owner;
                proout.PDO = dt;
                this.Close();
            }
        }


    }
}
