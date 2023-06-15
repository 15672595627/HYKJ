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
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Contract
{
    public partial class ContractList : Form
    {
        public ContractList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string conlist_user { get; set; }
        public string conlist_group { get; set; }


        SqlDataAdapter da;
        DataTable dt ;

        private string del = "";

        private void SX_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            string a = RQ.Text.Trim();
            string b = RQ1.Text.Trim();
            string aa = HTBH.Text.Trim();
            string bb = GSMC.Text.Trim();
            string ywy = YWY.Text.Trim();
            string cc = QJ.Text.Trim();
            string dd = SHZT.Text.Trim();
            if(CKLB.Text == "")
            {
                MessageBox.Show("请选择查看类别");
            }
            else
            {
                
                if (CKLB.Text == "合同数据主数据")
                {
                    审核ToolStripMenuItem.Enabled = false;
                    反审核ToolStripMenuItem.Enabled = true;
                    批量审核ToolStripMenuItem.Enabled = false;
                    string strsql = String.Format("select orderid as 单据编号,contractid as 合同编号,date as 日期,company as 公司,project as 项目名称,sub as 分公司 ,con_cate as 合同类别,kh_type as 客户类别,kh_cate as 客户类型,seller as 业务员,cost as 钢材,area as 地区,place as 产地,tax as 税率,amount as 金额,examine as 审核状态,qj as 期间 from [dbo].[Contract_h] where contractid like '%" + aa + "%' and company like '%" + bb + "%' and seller like '%" + ywy + "%' and qj like '%" + cc + "%' and examine like '%" + dd + "%' and date between '" + a + "' and '" + b + "'");
                    try
                    {
                        
                        da = new SqlDataAdapter(strsql, SQL);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;

                        decimal sum = 0;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            //sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["金额"].Value);
                            if (dataGridView1.Rows[i].Cells["金额"].Value == DBNull.Value)
                            {
                                dataGridView1.Rows[i].Cells["金额"].Value = "0";
                            }
                            else
                            {
                                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["金额"].Value);
                            }
                            if (dataGridView1.Rows[i].Cells["审核状态"].Value.ToString() == "已审核")
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                            }
                        }

                        string ssum = sum.ToString();

                        string[] row = { "", "合计", "", "", "", "", "", "", "", "", "", "", "", "", ssum, "", "" };
                        ((DataTable)dataGridView1.DataSource).Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                if (CKLB.Text == "合同数据详细数据")
                {
                    审核ToolStripMenuItem.Enabled = false;
                    反审核ToolStripMenuItem.Enabled = false;
                    批量审核ToolStripMenuItem.Enabled = false;
                    
                    string strsql = String.Format("select id,orderid as 单据编号,contractid as 合同编号,date as 日期,company as 公司,project as 项目,pd_kind as 产品类型,pd_cate as 产品类别,product as 产品,norms as 规格,high as 高度,price as 价格,s_amount as 核算价格,amount as 金额 from [dbo].[Contract_b] where contractid like '%" + aa + "%' and company like '%" + bb + "%' and date between '" + a + "' and '" + b + "'");
                    try
                    {

                        da = new SqlDataAdapter(strsql, SQL);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["id"].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        
        //只允许本部门进行删除
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(conlist_group == "市场部" || conlist_group == "Administrators") {
                if (CKLB.Text == "合同数据主数据")
                {
                    if (dataGridView1.CurrentRow.Cells[14].Value.ToString() == "已审核")
                    {
                        MessageBox.Show("已审核无法删除");
                    }
                    else
                    {
                        del = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
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
                        if (MessageBox.Show("是否一并删除详细数据", "提示!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            SqlConnection con = new SqlConnection(SQL);
                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = "DELETE FROM [dbo].[Contract_b] WHERE contractid = '" + del + "'";
                            int cot = cmd.ExecuteNonQuery();
                            if (cot > 0)
                            {
                                MessageBox.Show("删除成功");
                            }
                            else
                            {
                                MessageBox.Show("删除失败");
                            }
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("您没有权限进行删除，请联系市场部！");
            }
        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string a = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE [dbo].[Contract_h] SET examine = '已审核' where contractid like '%" + a + "%'";
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
            else
            {
                return;
            }
        }

        //只允许本们进行
        private void 反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conlist_group == "市场部" || conlist_group == "财务部" || conlist_group == "Administrators") 
            { 
                if (dataGridView1.Rows.Count > 0)
                {
                    string a = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    SqlConnection conn = new SqlConnection(SQL);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE [dbo].[Contract_h] SET examine = '未审核' where contractid like '%" + a + "%'";
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
                else
                {
                    return;

                }
            }
            else
            {
                MessageBox.Show("对不起你没有权限进行反审核，请联系市场部或财务部！");
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

        private void 批量审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "合同数据主数据")
            {

                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    int m = dataGridView1.SelectedRows[i].Index;
                    dataGridView1.Rows[m].Cells["审核状态"].Value = "已审核";
                }

                try
                {
                    SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                    da.Update(dt);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("审核失败");
                    return;
                }
                MessageBox.Show("审核成功!");
            }
        }

        //跳转到审核界面
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CKLB.Text == "合同数据主数据")
            {
                string aa = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ContractRead contractRead = new ContractRead();
                contractRead.conr_user = conlist_user;
                contractRead.conr_group = conlist_group;
                contractRead.ConR_ORD = aa;
                contractRead.Show();
            }
        }

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void ContractList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            RQ.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day); //'设置为本月第一天
        }

        private void ContractList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}