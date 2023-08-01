using Microsoft.SqlServer.Server;
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
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.OrderReport
{
    public partial class Mss : Form
    {
        public Mss()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        SqlDataAdapter da;
        DataTable dt;

        public string MSS_User { get; set; }
        public string MSS_Group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void SX_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            string htbh = HTBH.Text.Trim();
            string rq =  RQ.Text.Trim();
            string rq1 = RQ1.Text.Trim();
            string gdy = txtgdy.Text.Trim();    
            string strsql = "select id,contractid as 合同编号,applytime as 申请时间,service as 跟单员,company as 公司名称,project as 项目名称,productname as 产品名称,sub as 内容,quantity as 数量,unit as 单位,price as 价格,amount as 金额,checkdate as 审核时间,fhck as 发货仓库,fhwl as 发货物流,examine as 财务审核,checker as 财务审核人,checkdate as 审核时间,checkout as 发货审核,checkouter as 发货审核人 from [dbo].[Message_FHSQ] where contractid like '%" + htbh + "%' and service like '%"+gdy+ "%' and CONVERT(nvarchar(10),checkdate,120)between  '" + rq+ "' and  '" + rq1+ "'";
            da = new SqlDataAdapter(strsql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
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

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MSS_Group == "财务部")
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToDeleteRows = true;
            }
            else
            {
                MessageBox.Show("权限不足，请联系财务室！");
            }

        }

        private void Mss_Load(object sender, EventArgs e)
        {
            RQ.Value = DateTime.Now;
            RQ1.Value = DateTime.Now;
            asc.controllInitializeSize(this);
        }

        private void Mss_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void BC_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;

            try
            {
                SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("保存失败");
                return;
            }
            MessageBox.Show("保存成功");
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["财务审核"].Value.ToString() == "已审核")
            {
                MessageBox.Show("财务已审核，无法删除");
            }
            else
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }
    }
}
