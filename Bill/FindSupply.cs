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
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Order;

namespace WindowsFormsApp1.Bill
{
    public partial class FindSupply : Form
    {
        public FindSupply()
        {
            InitializeComponent();
        }

        private SqlDataAdapter da = null;
        private DataTable dt = null;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select id, name as 供应商,contact as 联系人,tel as 电话号码 from Supplier where name like '%" + textBox1.Text+"%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            string b = dataGridView1.Rows[rowindex].Cells["供应商"].Value.ToString();
            outSouringAdd outSouring = (outSouringAdd)this.Owner;
            outSouring.Controls["textBox1"].Text = b;
            this.Close();
        }
    }
}
