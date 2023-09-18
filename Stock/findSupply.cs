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
using WindowsFormsApp1.Scheduling;

namespace WindowsFormsApp1.Stock
{
    public partial class findSupply : Form
    {
        public findSupply()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da;
        private DataTable dt;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        public string con_user { get; set; }
        public string con_group { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Select id, name as 供应商 from Supplier";
            da = new SqlDataAdapter(str, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void findSupply_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void findSupply_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            string a = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            updateStock update = (updateStock)this.Owner;
            update.Controls["textBox1"].Text = a;

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
