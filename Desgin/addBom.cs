using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Desgin
{
    public partial class addBom : Form
    {
        public addBom()
        {
            InitializeComponent();
            base.KeyPreview = true;
        }
        private DataTable dt;
        private SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public string User { get; set; }
        public string Group { get; set; }
        private void addBom_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this); 
        }

        private void addBom_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select id,materialsId as 物料编码,unitNumber as 库存数量,unit as 单位,materialsName as 物料名称 ,specification as 规格型号,stockName as 仓库名称,stockId as 仓库代码 from MaterialStock where materialsName like '%" + txtWlmc.Text+"%'and specification like '%"+txtGgxh.Text+"%'and stockName like '%"+comboBox1.Text+"%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, addBom.SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void txtConId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string str1 = "select contractid as 合同编号,company as 客户,project as 项目 from [dbo].[Contract_h] where contractid like '%" + txtConId.Text + "%'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str1, addBom.SQL);
                dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtGSMC.Text = dt.Rows[0]["客户"].ToString();
                    txtXMMC.Text = dt.Rows[0]["项目"].ToString();
                }
            }
        }
        private string iid;
        private string iiid;
        private void button3_Click(object sender, EventArgs e)
        {
            string str2 = "select id,wlbm as 物料编码,kc as 库存数量,unit as 单位,wlmc as 物料名称 ,ggxh as 规格型号,ckmc as 仓库名称,ckdm as 仓库代码 from Bom where [user] = '" + User + "' and state = 'Y'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str2, SQL);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }
        int cot11;
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SqlConnection sqlConnection = new SqlConnection(SQL);
                sqlConnection.Open();
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    int index = dataGridView1.SelectedRows[i].Index;
                    iid = dataGridView1.Rows[index].Cells["id"].Value.ToString();
                    string wlbm = dataGridView1.Rows[index].Cells["物料编码"].Value.ToString();
                    string wlmc = dataGridView1.Rows[index].Cells["物料名称"].Value.ToString();
                    string ggxh = dataGridView1.Rows[index].Cells["规格型号"].Value.ToString();
                    string kcsl = dataGridView1.Rows[index].Cells["库存数量"].Value.ToString();
                    string ckmc = dataGridView1.Rows[index].Cells["仓库名称"].Value.ToString();
                    string dw = dataGridView1.Rows[index].Cells["单位"].Value.ToString();
                    string ckdm = dataGridView1.Rows[index].Cells["仓库代码"].Value.ToString();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandText = "insert into [dbo].[Bom] ([iid],[wlbm],[wlmc],[ggxh],[kc],[ckmc],[user],[state],[unit],[ckdm]) VALUES ('" + iid+"','"+wlbm+"','"+wlmc+"','"+ggxh+"','"+kcsl+"','"+ckmc+"','"+User+"','Y','"+dw+"','"+ ckdm + "')";
                    cot11 = sqlCommand.ExecuteNonQuery();
                    if (cot11 < 1)
                    {
                        MessageBox.Show("保存失败");
                    }
                    button3.PerformClick();
                }   
            }
        }

        private void addBom_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.S) 
            {
                button2.PerformClick();
            }
        }
        private string bz;
        private decimal cc;

        private string Oid;
        private int sssssssl;
        private int cot1;
        private int cot4;
        private int cot5;
        private int sssl;
        private string bh;
        private void button2_Click(object sender, EventArgs e)
        {
            
            string text = comboBox2.Text.Trim();
            SqlConnection sqlConnection = new SqlConnection(addBom.SQL);
            sqlConnection.Open();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                
                string str3 = "select iid from Bom where [user] = '" + User + "' and state = 'Y'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str3, addBom.SQL);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    for (int j = 0; j < dataTable.Rows.Count; j++)
                    {
                        Oid = dataTable.Rows[j]["iid"].ToString();
                    }
                }
                string str4 = "select iid from Bom where [user] = '" + User + "' and state = 'Y'";
                using (SqlCommand sqlCommand = new SqlCommand(str4, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        sqlDataReader.Read();
                        bool hasRows = sqlDataReader.HasRows;
                        if (hasRows)
                        {
                            sqlDataReader.Close();
                            string text2 = dataGridView2.Rows[i].Cells["id"].Value.ToString();
                            string str = DateTime.Now.ToString("yyyyMMddHHmmss");
                            string text3 = "XLD" + str;
                            string text4 = DateTime.Now.ToString("yyyy-MM-dd");
                            string text5 = txtConId.Text;
                            string text6 = txtGSMC.Text;
                            string text7 = txtXMMC.Text;
                            string text8 = txtCP.Text;
                            string text9 = txtCPYS.Text;
                            string text10 = txtSFSL.Text;
                            string ck = dataGridView2.Rows[i].Cells["仓库名称"].Value.ToString();
                            string kc = dataGridView2.Rows[i].Cells["库存数量"].Value.ToString();
                            string text11 = dataGridView2.Rows[i].Cells["物料编码"].Value.ToString();
                            string text12 = dataGridView2.Rows[i].Cells["物料名称"].Value.ToString();
                            string text13 = dataGridView2.Rows[i].Cells["规格型号"].Value.ToString();
                            string dw = dataGridView2.Rows[i].Cells["单位"].Value.ToString();
                            string ckdm = dataGridView2.Rows[i].Cells["仓库代码"].Value.ToString();
                            if (dataGridView2.Rows[i].Cells["尺寸"].Value == null)
                            {
                                cc = 0;
                            }
                            else
                            {
                                cc = Convert.ToDecimal(dataGridView2.Rows[i].Cells["尺寸"].Value.ToString());
                            }
                            string text14 = dataGridView2.Rows[i].Cells["材质"].Value.ToString();
                            int num = Convert.ToInt32(dataGridView2.Rows[i].Cells["数量"].Value.ToString());
                            if (dataGridView2.Rows[i].Cells["备注"].Value == null)
                            {
                                bz = "无";
                            }
                            else
                            {
                                bz = dataGridView2.Rows[i].Cells["备注"].Value.ToString();
                            }
                            //string 
                            decimal num2 = Convert.ToDecimal(txtCPMS.Text);
                            string selectCommandText2 = "select id,materialsId,unitNumber as 数量 from MaterialStock where id = '" + Oid + "'";
                            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, addBom.SQL);
                            DataTable dataTable2 = new DataTable();
                            sqlDataAdapter2.Fill(dataTable2);
                            if (dataTable2.Rows.Count > 0)
                            {
                                for (int k = 0; k < dataTable2.Rows.Count; k++)
                                {
                                    iiid = dataTable2.Rows[k]["id"].ToString();
                                    sssl = Convert.ToInt32(dataTable2.Rows[k]["数量"].ToString());
                                    bh = dataTable2.Rows[k]["materialsId"].ToString();
                                }
                            }
                            SqlCommand sqlCommand2 = sqlConnection.CreateCommand();
                            sqlCommand2.CommandText = "UPDATE Bom set state = 'N' where iid = '" + Oid + "'";
                            cot4 = sqlCommand2.ExecuteNonQuery();
                            SqlCommand sqlCommand3 = sqlConnection.CreateCommand();
                            sqlCommand3.CommandText = string.Concat(new string[]
                            {
                                "insert into [dbo].[DesginBom] ([orderid],[contractid],[date],[desgin],[company],[project],[color],[product],[sfyl],[meters],[clid],[clmc],[clgg],[cllb],[ccpf],[zs],[bz],[status],[examine],[examine1],[size],[state],[rkzt],[kcsl],[ck],[unit],[ckdm]) VALUES ('"+text3+"','"+text5+"','"+text4+"','"+User+"','"+text6+"','"+text7+"','"+text9+"','"+text8+"','"+text10+"','"+num2+"','"+text11+"','"+text12+"','"+text13+"','"+text14+"','"+text+"','"+num+"','"+bz+"','未知','未审核','未审核','"+cc+"','N','未出库','"+kc+"','"+ck+"','"+dw+"','"+ckdm+"')"
                            });
                            cot1 = sqlCommand3.ExecuteNonQuery();
                            bool flag5 = !button2.Enabled;
                            if (flag5)
                            {

                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("该原材料没有添加");
                        }
                    }
                }
            }
            if (cot1 > 0 && cot4 > 0)
            {
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
            sqlConnection.Close();
            
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(addBom.SQL);
            sqlConnection.Open();
            for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
            {
                int index = dataGridView2.SelectedRows[i].Index;
                string str = dataGridView2.Rows[index].Cells["id"].Value.ToString();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "delete from Bom where id = '" + str + "'";
                cot5 = sqlCommand.ExecuteNonQuery();
            }
            sqlConnection.Close();
            bool flag = cot5 > 0;
            if (flag)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            button3.PerformClick();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Clipboard.GetText();
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            bool flag = rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count;
            if (flag)
            {
                dataGridView2.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        private void txtWlmc_KeyDown(object sender, KeyEventArgs e)
        {
            button1.PerformClick();
        }

        private void txtGgxh_KeyDown(object sender, KeyEventArgs e)
        {
            button1.PerformClick();
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            button3.PerformClick();
        }
    }
}
