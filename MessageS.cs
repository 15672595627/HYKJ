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
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Product;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class MessageS : Form
    {
        public MessageS()
        {
            InitializeComponent();
        }
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string MSS_User { get; set; }
        public string MSS_Group { get; set; }

        SqlDataAdapter da1;
        DataTable dt1;
        SqlDataAdapter da2;
        DataTable dt2;

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void Messages_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            toolStripStatusLabel2.Text = MSS_User;
            toolStripStatusLabel5.Text = MSS_Group;
            if (MSS_Group == "财务部" || MSS_Group == "Administrators")
            {
                dataGridView1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void MessageS_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell.OwningColumn.Name == "审核")
            {
                if(MSS_Group == "财务部" || MSS_Group == "Administrators")
                {
                    if (MessageBox.Show("是否审核该申请？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        string cpmc = dataGridView1.CurrentRow.Cells["产品名称"].Value.ToString();
                        string nr = dataGridView1.CurrentRow.Cells["内容"].Value.ToString();
                        string time = DateTime.Now.ToString("G");
                        SqlConnection con = new SqlConnection(SQL);
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "UPDATE Message_FHSQ SET examine = '已审核',checker = '" + MSS_User + "',checkdate = '" + time + "',readfh = '未读' WHERE productname = '" + cpmc + "' and sub = '" + nr + "'";
                        int cot = cmd.ExecuteNonQuery();
                        if (cot > 0)
                        {
                            MessageBox.Show("审核成功");

                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请等待财务室审核");
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentCell.OwningColumn.Name == "出库")
            {
                if (MSS_Group == "资材部" || MSS_Group == "Administrators")
                {
                    if (MessageBox.Show("是否已出库？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        string cpmc = dataGridView2.CurrentRow.Cells["产品名称"].Value.ToString();
                        string nr = dataGridView2.CurrentRow.Cells["内容"].Value.ToString();
                        SqlConnection con = new SqlConnection(SQL);
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "UPDATE Message_FHSQ SET checkout='已出库',checkouter = '" + MSS_User + "' WHERE productname = '" + cpmc + "' and sub = '" + nr + "'";
                        int cot = cmd.ExecuteNonQuery();
                        if (cot > 0)
                        {
                            MessageBox.Show("出库已完成");

                            if(MessageBox.Show("是否生成出库单？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                string htbh = dataGridView2.CurrentRow.Cells["合同编号"].Value.ToString();
                                string gdy = dataGridView2.CurrentRow.Cells["跟单员"].Value.ToString();
                                string gsm = dataGridView2.CurrentRow.Cells["公司名称"].Value.ToString();
                                string xmmc = dataGridView2.CurrentRow.Cells["项目名称"].Value.ToString();
                                string sl = dataGridView2.CurrentRow.Cells["数量"].Value.ToString();
                                string dw = dataGridView2.CurrentRow.Cells["单位"].Value.ToString();
                                string je = dataGridView2.CurrentRow.Cells["金额"].Value.ToString();

                                QuickOut quick = new QuickOut();
                                quick.QO_User = MSS_User;
                                quick.QO_Group= MSS_Group;
                                quick.QO_CPMC = cpmc;
                                quick.QO_NR = nr;
                                quick.QO_HTBH = htbh;
                                quick.QO_GDY= gdy;
                                quick.QO_GSM = gsm;
                                quick.QO_XMMC = xmmc;
                                quick.QO_SL = sl;
                                quick.QO_DW = dw;
                                quick.QO_JE = je;
                                quick.ShowDialog();

                                
                            }

                            dataGridView2.Rows.Remove(dataGridView2.CurrentRow);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("请等待资材部出库");
                }
            }
        }

        private void KFH_Enter(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Columns.Clear();
            string strsql = "select id,contractid as 合同编号,service as 跟单员,company as 公司名称,project as 项目名称,productname as 产品名称,sub as 内容,quantity as 数量,unit as 单位,amount as 金额,fhck as 发货仓库,fhwl as 发货物流,checker as 审核人,examine,checkout from [dbo].[Message_FHSQ] where examine = '已审核' and checkout = '未出库' ORDER BY id DESC ";
            da2 = new SqlDataAdapter(strsql, SQL);
            dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                dataGridView2.DataSource = dt2;
                dataGridView2.Columns["id"].Visible = false;
                dataGridView2.Columns["examine"].Visible = false;
                dataGridView2.Columns["checkout"].Visible = false;
                dataGridView2.Columns["金额"].Visible = false;

                DataGridViewButtonColumn ck = new DataGridViewButtonColumn();
                ck.Text = "出库";
                ck.HeaderText = "出库";
                ck.Name = "出库";
                ck.UseColumnTextForButtonValue = true;
                dataGridView2.Columns.Add(ck);
            }

        }

        private void SQFH_Enter(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            string strsql = "select id,contractid as 合同编号,applytime as 申请时间,service as 跟单员,company as 公司名称,project as 项目名称,productname as 产品名称,sub as 内容,quantity as 数量,unit as 单位,amount as 金额,examine from [dbo].[Message_FHSQ] where examine = '未审核' ORDER BY id DESC";
            da1 = new SqlDataAdapter(strsql, SQL);
            dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["examine"].Visible = false;

                DataGridViewButtonColumn sh = new DataGridViewButtonColumn();
                sh.Text = "审核";
                sh.HeaderText = "审核";
                sh.Name = "审核";
                sh.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(sh);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

            try
            {
                SqlCommandBuilder SCB1 = new SqlCommandBuilder(da1);
                da1.Update(dt1);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            MessageBox.Show("更新成功!");

        }

        private void 批量审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MSS_Group == "财务部" || MSS_Group == "Administrators")
            {
                if(dataGridView1.Rows.Count > 0)
                {
                    if (MessageBox.Show("是否审核所选择的申请？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        
                        for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        {
                            
                            int m = dataGridView1.SelectedRows[i].Index;
                            string cpmc = dataGridView1.Rows[m].Cells["产品名称"].Value.ToString();
                            string nr = dataGridView1.Rows[m].Cells["内容"].Value.ToString();
                            SqlConnection con = new SqlConnection(SQL);
                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = "UPDATE Message_FHSQ SET examine='已审核',checker = '" + MSS_User + "',readfh = '未读' WHERE productname = '" + cpmc + "' and sub = '" + nr + "'";
                            int cot = cmd.ExecuteNonQuery();
                            if (cot == 0)
                            {
                                MessageBox.Show("审核失败");
                            }
                            dataGridView1.Rows.Remove(dataGridView1.Rows[m]);
                        }                      
                    }
                }
               
            }
            else
            {
                MessageBox.Show("请等待财务室审核");
            }
        }

        private void CX_Click(object sender, EventArgs e)
        {
            if(CXLX.Text == "申请发货")
            {
                string htbh = HTBH.Text.Trim();
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                string strsql = "select id,contractid as 合同编号,service as 跟单员,company as 公司名称,project as 项目名称,productname as 产品名称,sub as 内容,quantity as 数量,unit as 单位,amount as 金额,examine from [dbo].[Message_FHSQ] where examine = '未审核' and contractid like '%" + htbh + "%' ORDER BY id DESC";
                da1 = new SqlDataAdapter(strsql, SQL);
                dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt1;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["examine"].Visible = false;

                    DataGridViewButtonColumn sh = new DataGridViewButtonColumn();
                    sh.Text = "审核";
                    sh.HeaderText = "审核";
                    sh.Name = "审核";
                    sh.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(sh);
                }
            }
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

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
