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

namespace WindowsFormsApp1.Main
{
    public partial class BasisList : Form
    {
        public BasisList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        SqlDataAdapter dayh;
        DataTable dtyh = new DataTable();
        SqlDataAdapter daywy;
        DataTable dtywy = new DataTable();
        SqlDataAdapter dakh;
        DataTable dtkh = new DataTable();
        SqlDataAdapter dagys;
        DataTable dtgys = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string mz = MZ.Text.Trim();
            if(ZLZL.Text == "用户")
            {
                
                string strsql = "select name as 姓名,groups as 群组 from [dbo].[User] where name like '%" + mz + "%'";
                dayh = new SqlDataAdapter(strsql, SQL);
                dayh.Fill(dtyh);
                dataGridView1.DataSource = dtyh;
            }
            if (ZLZL.Text == "业务员")
            {
                
                string strsql = "select id,seller as 姓名,company as 所属公司,area as 所属区域,m_target as 月目标 ,y_target as 年目标 from [dbo].[Seller] where seller like '%" + mz + "%' ";
                daywy = new SqlDataAdapter(strsql, SQL);
                daywy.Fill(dtywy);
                dataGridView1.DataSource = dtywy;
                dataGridView1.Columns["id"].Visible = false;
            }
            if (ZLZL.Text == "客户")
            {
                
                string strsql = "select id,company as 公司名,project as 项目名称,type as 种类,seller as 业务员 from [dbo].[Customer] where company like '%" + mz + "%'";
                dakh = new SqlDataAdapter(strsql, SQL);
                dakh.Fill(dtkh);
                dataGridView1.DataSource = dtkh;
                dataGridView1.Columns["id"].Visible = false;
            }
            if (ZLZL.Text == "供应商")
            {
                
                string strsql = "select id,company as 公司名,type as 种类 from [dbo].[Supplier] where company like '%" + mz + "%' ";
                dagys = new SqlDataAdapter(strsql, SQL);
                dagys.Fill(dtgys);
                dataGridView1.DataSource = dtgys;
                dataGridView1.Columns["id"].Visible = false;
            }
        }

        private void XG_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            BC.Enabled = true;
            SC.Enabled = true;
            dataGridView1.AllowUserToDeleteRows = true;

        }

        private void BC_Click(object sender, EventArgs e)
        {
            BC.Enabled = false;
            if (ZLZL.Text == "用户")
            {
                SqlCommandBuilder scbyh = new SqlCommandBuilder(dayh);
                dayh.Update(dtyh);
                MessageBox.Show("修改成功");
            }
            if (ZLZL.Text == "业务员")
            {
                SqlCommandBuilder scbywy = new SqlCommandBuilder(daywy);
                daywy.Update(dtywy);
                MessageBox.Show("修改成功");
            }
            if (ZLZL.Text == "客户")
            {
                SqlCommandBuilder scbkh = new SqlCommandBuilder(dakh);
                dakh.Update(dtkh);
                MessageBox.Show("修改成功");
            }
            if (ZLZL.Text == "供应商")
            {
                SqlCommandBuilder scbgys = new SqlCommandBuilder(dagys);
                dagys.Update(dtgys);
                MessageBox.Show("修改成功");
            }
        }

        private void SC_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }
    }
}
