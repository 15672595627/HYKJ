using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Stock
{
    public partial class JIT : Form
    {
        public JIT()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        DataTable dt;
        SqlDataAdapter da;

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void JIT_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void SX_Click(object sender, EventArgs e)
        {

            string mc = MC.Text.Trim();


            if (CKLB.Text == "")
            {
                MessageBox.Show("请选择查看类别");
            }
            else
            {
                if (CKLB.Text == "原材料")
                {
                    dataGridView1.DataSource = null;
                    string strsql = "select goodsid as 物料编号,goodsname as 物料名称,goodsnorms as 物料规格,goodsunit as 物料单位,goodsnum as 物料数量,goodsprice as 物料单价,goodsamount as 物料金额,warehouse as 物料仓库,kinds as 物料类别,location as 库位 from [dbo].[Goods] where  goodsname like '%" + mc + "%'";
                    da = new SqlDataAdapter(strsql, SQL);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                if (CKLB.Text == "产成品")
                {
                    dataGridView1.DataSource = null;
                    string strsql = "select id,date as 会计期间,contractid as 合同编号,product as 物料名称,sub as 内容,norm as 物料规格,unit as 物料单位,num as 物料数量,amount as 物料金额,warehouse as 物料仓库 from [dbo].[Stock] where product like '%" + mc + "%'";
                    da = new SqlDataAdapter(strsql, SQL);
                    dt = new DataTable();
                    da.Fill(dt);
                    decimal sum = 0;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].Visible= false;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["物料金额"].Value);
                    }
                    string ssum = sum.ToString();   
                    string[] row = {"0","合计", "", "", "", "", "", "", ssum, "",};
                    ((DataTable)dataGridView1.DataSource).Rows.Add(row);
                }
            }
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("请先查询数据");
            }
            else
            {

                SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "Execl files (*.xls)|*.xls";
                sfd.FilterIndex = 0;
                sfd.RestoreDirectory = true;
                sfd.CreatePrompt = true;
                sfd.Title = "Export Excel File";
                sfd.ShowDialog();

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName == "")
                    {
                        MessageBox.Show("请输入保存名");
                        return;
                    }
                    else
                    {
                        Stream mystream = sfd.OpenFile();
                        StreamWriter sw = new StreamWriter(mystream, System.Text.Encoding.GetEncoding(-0));
                        string str = "";
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            if (i > 0)
                            {
                                str += "\t";
                            }
                            str += dataGridView1.Columns[i].HeaderText;
                        }
                        sw.WriteLine(str);
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            string tempStr = "";
                            for (int k = 0; k < dataGridView1.Columns.Count; k++)
                            {
                                if (k > 0)
                                {
                                    tempStr += "\t";
                                }
                                tempStr += dataGridView1.Rows[j].Cells[k].Value.ToString();
                            }
                            sw.WriteLine(tempStr);
                        }
                        sw.Close();
                        mystream.Close();
                    }
                }
            }
        }

        private void BC_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            BC.Enabled= false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void XG_Click(object sender, EventArgs e)
        {
            BC.Enabled= true;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToDeleteRows= true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        private void JIT_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
