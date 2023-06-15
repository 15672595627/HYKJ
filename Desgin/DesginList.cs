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
using System.IO;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Desgin
{
    public partial class DesginList : Form
    {
        public DesginList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        SqlDataAdapter da;
        DataTable dt;

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void DesginList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void DesginList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void SX_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            string htbh = HTBH.Text.Trim();
            string gsm = GSMC.Text.Trim();
            string rq = KSRQ.Text.Trim();
            string rq1 = JSRQ.Text.Trim();
            string sjy = SJY.Text.Trim();

            string sql = String.Format("select id,orderid as 单据编号,contractid as 合同编号,date as 日期,desgin as 下单员,company as 客户名,project as 项目名称,color as 颜色,product as 产品,sfyl as 塑粉用量,meters as 米数,clid as 材料ID,clmc as 材料名称,clgg as 材料规格,cllb as 材料类别,ccpf as 尺寸喷粉,zs as 支数,bz as 备注,status as 状态,examine as 审核状态,examine1 as 生产部审核状态 from [dbo].[DesginBom] where contractid like '%" + htbh + "%' and company like '%" + gsm + "%' and desgin like '%" + sjy + "%' and date between '" + rq + "'and '" + rq1 + "'");
            da = new SqlDataAdapter(sql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;

            DataGridViewButtonColumn px = new DataGridViewButtonColumn();
            px.Text = "上传图片";
            px.HeaderText = "附件";
            px.Name = "附件";
            px.UseColumnTextForButtonValue= true;
            dataGridView1.Columns.Add(px);

        }

        private void BC_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            MessageBox.Show("更新成功!");
            dataGridView1.ReadOnly = true;
            删除ToolStripMenuItem.Enabled = false;
            插入ToolStripMenuItem.Enabled = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void 打开图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BomPxList pxList = new BomPxList();
            pxList.BPL_Ord = dataGridView1.CurrentRow.Cells["订单编号"].Value.ToString();
            pxList.BPL_Clid = dataGridView1.CurrentRow.Cells["材料ID"].Value.ToString();
            pxList.ShowDialog();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.Columns["单据编号"].ReadOnly = true;
            dataGridView1.Columns["合同编号"].ReadOnly = true;
            dataGridView1.Columns["日期"].ReadOnly = true;
            BC.Enabled = true;
            删除ToolStripMenuItem.Enabled = true;
            插入ToolStripMenuItem.Enabled = true;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {

                string a = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE [dbo].[Desgin_h] SET examine = '已审核' where orderid like '%" + a + "%'";
                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("审核成功");
                }
                else
                {
                    MessageBox.Show("审核失败");
                }
                conn.Close();
            
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
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

        private void 反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {

                string a = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE [dbo].[Desgin_h] SET examine = '未审核' where orderid like '%" + a + "%'";
                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("反审核成功");
                }
                else
                {
                    MessageBox.Show("反审核失败");
                }
                conn.Close();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell.OwningColumn.Name == "附件")
            {
                BomPx px = new BomPx();
                px.BP_Ord = dataGridView1.CurrentRow.Cells["订单编号"].Value.ToString();
                px.BP_Clid = dataGridView1.CurrentRow.Cells["材料ID"].Value.ToString();
                px.ShowDialog();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }


    }
}