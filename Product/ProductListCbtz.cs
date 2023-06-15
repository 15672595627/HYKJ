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
using WindowsFormsApp1.PO;

namespace WindowsFormsApp1.Product
{
    public partial class ProductListCbtz : Form
    {
        public ProductListCbtz()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        public string PLCB_User { get; set; }
        public string PLCB_Group { get; set; }

        DataTable dt;
        SqlDataAdapter da;


        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void SX_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string htbh = HTBH.Text.Trim();
            string shzt = ZT.Text.Trim();
            string shck = CK.Text.Trim();
            string rq = RQ.Text.Trim();
            string rq1 = RQ1.Text.Trim();
            string strsql = "SELECT id,orderid as 单据编号,contractid as 合同编号,date as 单据日期,staff as 录单员,Product as 产品,norms as 规格,shck as 收货仓库,cbdj as 成本单价,cbamount as 成本金额,num as 库存数量,amount as 库存金额,dw as 单位,fhsl as 发货数量,fhamount as 发货金额,fhcbamount as 发货成本金额,examine as 审核状态 from ProductCbtz where  date BETWEEN '" + rq + "' and '" + rq1 + "' and contractid like '%" + htbh + "%' and examine like '%" + shzt + "%' and shck like '%" + shck + "%'";
            da = new SqlDataAdapter(strsql, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            /*decimal sum1 = 0;
            decimal sum2 = 0;
            decimal sum3 = 0;
            decimal sum4 = 0;
            decimal sum5 = 0;
            decimal sum6 = 0;
            decimal sum7 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
                sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[12].Value);
                sum3 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[15].Value);
                sum4 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[16].Value);
                sum5 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[17].Value);
                sum6 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[18].Value);
                sum7 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[22].Value);
                if (dataGridView1.Rows[i].Cells[23].Value.ToString() == "已审核")
                {
                    if (dataGridView1.Rows[i].Cells[23].Value.ToString() == "已审核" && dataGridView1.Rows[i].Cells[22].Value.ToString() == "已出库")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                    }
                    if (dataGridView1.Rows[i].Cells[23].Value.ToString() == "已审核" && dataGridView1.Rows[i].Cells[22].Value.ToString() == "部分出库")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Plum;
                    }
                }
            }
            string ssum1 = sum1.ToString();
            string ssum2 = sum2.ToString();
            string ssum3 = sum3.ToString();
            string ssum4 = sum4.ToString();
            string ssum5 = sum5.ToString();
            string ssum6 = sum6.ToString();
            string ssum7 = sum7.ToString();
            string[] row = { "1", "合计", "", "", "", "", "", "", "", "", ssum1, "", ssum2, "", "", ssum3, ssum4, ssum5, ssum6, "0", "", "0", ssum7, "", "" };
            ((DataTable)dataGridView1.DataSource).Rows.Add(row);

            */
        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string djbh = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString();
                string cpmc = dataGridView1.CurrentRow.Cells["产品"].Value.ToString();

                SqlConnection con = new SqlConnection(SQL);
                //
                //修改应发数量，修改出库单审核状态
                //
                try
                {
                    con.Open();
                    decimal kcsl = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["库存数量"].Value);
                    decimal fhsl = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["发货数量"].Value);
                    decimal kcje = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["库存金额"].Value);
                    decimal fhcbje = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["发货成本金额"].Value);
                    if(fhcbje == 0) 
                    {
                        MessageBox.Show("出库成本金额为零!");
                    }
                    else
                    {

                        decimal newkcsl = kcsl - fhsl;
                        decimal newkcje = kcje - fhcbje;
                        if (newkcsl < 0 || newkcje < 0)
                        {
                            if (MessageBox.Show("审核将导致库存数量/金额为零或负数", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "UPDATE ProductCbtz SET examine = '已审核' WHERE product = '" + cpmc + "'";
                                int cot1 = cmd.ExecuteNonQuery();

                                cmd.CommandText = "UPDATE Stock SET num = '" + newkcsl + "',amount = '" + fhcbje + "' WHERE product = '" + cpmc + "'";
                                int cot = cmd.ExecuteNonQuery();

                                if (cot1 > 0)
                                {
                                    MessageBox.Show("审核成功");
                                }
                                else
                                {
                                    MessageBox.Show("审核失败");
                                }
                            }

                        }
                        else
                        {
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = "UPDATE ProductCbtz SET examine = '已审核' WHERE product = '" + cpmc + "'";
                            int cot1 = cmd.ExecuteNonQuery();

                            cmd.CommandText = "UPDATE Stock SET num = '" + newkcsl + "',amount = '" + fhcbje + "' WHERE product = '" + cpmc + "'";
                            int cot = cmd.ExecuteNonQuery();

                            if (cot1 > 0)
                            {
                                MessageBox.Show("审核成功");
                            }
                            else
                            {
                                MessageBox.Show("审核失败");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void 反审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string djbh = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString();
                string cpmc = dataGridView1.CurrentRow.Cells["产品"].Value.ToString();

                SqlConnection con = new SqlConnection(SQL);
                //
                //修改应发数量，修改出库单审核状态
                //
                try
                {
                    con.Open();
                    decimal kcsl = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["库存数量"].Value);
                    decimal fhsl = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["发货数量"].Value);
                    decimal kcje = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["库存金额"].Value);
                    decimal fhcbje = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["发货成本金额"].Value);

                    decimal newkcsl = kcsl + fhsl;
                    decimal newkcje = kcje + fhcbje;
                    if (newkcsl < 0 || newkcje < 0)
                    {
                        if (MessageBox.Show("反审核将导致库存数量/金额为零或负数", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = "UPDATE ProductCbtz SET examine = '已审核' WHERE product = '" + cpmc + "'";
                            int cot1 = cmd.ExecuteNonQuery();

                            cmd.CommandText = "UPDATE Stock SET num = '" + newkcsl + "',amount = '" + fhcbje + "' WHERE product = '" + cpmc + "'";
                            int cot = cmd.ExecuteNonQuery();

                            if (cot1 > 0)
                            {
                                MessageBox.Show("审核成功");
                            }
                            else
                            {
                                MessageBox.Show("审核失败");
                            }
                        }

                    }
                    else
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "UPDATE ProductCbtz SET examine = '已审核' WHERE product = '" + cpmc + "'";
                        int cot1 = cmd.ExecuteNonQuery();

                        cmd.CommandText = "UPDATE Stock SET num = '" + newkcsl + "',amount = '" + fhcbje + "' WHERE product = '" + cpmc + "'";
                        int cot = cmd.ExecuteNonQuery();

                        if (cot1 > 0)
                        {
                            MessageBox.Show("审核成功");
                        }
                        else
                        {
                            MessageBox.Show("审核失败");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.Columns["单据编号"].ReadOnly = true;
            dataGridView1.Columns["合同编号"].ReadOnly = true;
            dataGridView1.Columns["单据日期"].ReadOnly = true;
            dataGridView1.Columns["录单员"].ReadOnly = true;
            BC.Enabled = true;
            删除ToolStripMenuItem.Enabled = true;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
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
            BC.Enabled = false;
            dataGridView1.ReadOnly = true;
            删除ToolStripMenuItem.Enabled = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ProductListCbtz_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void ProductListCbtz_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }

}

