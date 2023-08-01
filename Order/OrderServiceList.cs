using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Order
{
    public partial class OrderServiceList : Form
    {
        public OrderServiceList()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        DataTable dt;
        SqlDataAdapter da;

        private string del = "";

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        public string OSL_User { get; set; }
        public string OSL_Group { get; set; }

        #region
        private void SX_Click(object sender, EventArgs e)
        {
            if(CKLB.Text == "")
            {
                MessageBox.Show("请选择查看类别");
            }
            else
            {
                dataGridView1.DataSource = null;
                string htbh = HTBH.Text.Trim();
                string aa = RQ.Text.Trim();
                string bb = RQ1.Text.Trim();
                string cc = GDY.Text.Trim();
                string dd = GSMC.Text.Trim();
                string ee = SHZT.Text.Trim();
                string ff = YWY.Text.Trim();
                string gg = QJ.Text.Trim();
                string ckzt = CKZT.Text.Trim();
                if (CKLB.Text == "销售订单主数据")
                {
                    审核ToolStripMenuItem.Enabled = false;
                    反审核ToolStripMenuItem.Enabled = true;
                    删除ToolStripMenuItem.Enabled = true;
                    收款单修改ToolStripMenuItem.Enabled = false;
                    收款单保存ToolStripMenuItem.Enabled = false;
                    批量审核ToolStripMenuItem.Enabled = false;
                    导出ToolStripMenuItem.Enabled = true;
                    发货申请ToolStripMenuItem.Enabled = false;

                    try
                    {
                        string sql = String.Format("select id,orderid as 单据编号,contractid as 合同编号,date as 日期,service as 跟单员,desgin as 设计员,company as 公司名,project as 项目名称,con_date as 合同日期,seller as 业务员,person as 联系人,phone as 电话,delivery as 交期,color as 颜色,longmetre as 最长米,quantity as 总米数,tax as 税率,htje as 合同金额,sjje as 实际金额,wsje as 无税金额,azf as 安装费,ywf as 业务费,huokuan as 货款,dj as 定金,hk as 回扣,remarks as 备注,examine as 审核状态,qj as 期间 from [dbo].[Order_h] " +
                            "where  contractid like '%" + htbh + "%' and service like '%" + cc + "%' and seller like '%" + ff + "%' and company like '%" + dd + "%' and examine like '%" + ee + "%' and qj like '%" + gg + "%' and date between '" + aa + "' and '" + bb + "'");

                        da = new SqlDataAdapter(sql, SQL);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["id"].Visible = false;
                        decimal sum = 0;
                        decimal sum1 = 0;
                        decimal sum2 = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["实际金额"].Value);
                            sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["总米数"].Value);
                            sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["无税金额"].Value);
                            if (dataGridView1.Rows[i].Cells[26].Value.ToString() == "已审核")
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                            }
                        }
                        string ssum = sum.ToString();
                        string ssum1 = sum1.ToString();
                        string ssum2 = sum2.ToString();
                        string[] row = { "1", "合计", "", "", "", "", "", "", "", "", "", "", "", "", "", ssum1, "", "", ssum, ssum2, "", "", "", "", "", "", "" };
                        ((DataTable)dataGridView1.DataSource).Rows.Add(row);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (CKLB.Text == "销售订单详细数据")
                {
                    审核ToolStripMenuItem.Enabled = false;
                    反审核ToolStripMenuItem.Enabled = false;
                    删除ToolStripMenuItem.Enabled = false;
                    收款单修改ToolStripMenuItem.Enabled = false;
                    收款单保存ToolStripMenuItem.Enabled = false;
                    批量审核ToolStripMenuItem.Enabled = false;
                    导出ToolStripMenuItem.Enabled = true;
                    发货申请ToolStripMenuItem.Enabled = true;
                    //批量发货申请ToolStripMenuItem_Click = true;
                    try
                    {
                        string sql = String.Format("select id,orderid as 单据编号,contractid as 合同编号,date as 日期,service as 跟单员,company as 公司名,project as 项目名称,sub as 内容,quantity as 数量,unit as 单位,price as 单价,meters as 米数,amount as 金额,productname as 产品名称,ident as 出库状态 from [dbo].[Order_b] where  contractid like '%" + htbh + "%' and service like '%" + cc + "%' and company like '%" + dd + "%' and ident like '%" + ckzt + "%' and  date between '" + aa + "' and '" + bb + "'");

                        da = new SqlDataAdapter(sql, SQL);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["id"].Visible = false;
                        decimal sum = 0;
                        decimal sum1 = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["米数"].Value);
                            sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["金额"].Value);
                        }
                        string ssum = sum.ToString();
                        string ssum1 = sum1.ToString();
                        string[] row = { "1", "合计", "", "", "", "", "", "", "0", "", "", ssum, ssum1, "", "" };
                        ((DataTable)dataGridView1.DataSource).Rows.Add(row);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (CKLB.Text == "收款单")
                {
                    审核ToolStripMenuItem.Enabled = true;
                    反审核ToolStripMenuItem.Enabled = true;
                    删除ToolStripMenuItem.Enabled = true;
                    收款单修改ToolStripMenuItem.Enabled = true;
                    收款单保存ToolStripMenuItem.Enabled = true;
                    批量审核ToolStripMenuItem.Enabled = true;
                    导出ToolStripMenuItem.Enabled = true;
                    发货申请ToolStripMenuItem.Enabled = false;
                    try
                    {
                        string sql = String.Format("select id,orderid as 单据编号,contractid as 合同编号,date as 日期,company as 公司名,project as 项目名称,bank as 银行,skje as 收款,seller as 业务员,area as 区域,service as 跟单员,remake as 备注,examine as 审核状态 " +
                            "from [dbo].[Receipt] where  service like '%" + cc + "%' and company like '%" + dd + "%' and  date between '" + aa + "' and '" + bb + "'and examine like '%" + ee + "%'");

                        da = new SqlDataAdapter(sql, SQL);
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["id"].Visible = false;
                        decimal sum = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                            if (dataGridView1.Rows[i].Cells["审核状态"].Value.ToString() == "已审核")
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                            }
                        }
                        string ssum = sum.ToString();
                        string[] row = { "1", "合计","", "", "", "", "", ssum , "", "", "", "", "" };
                        ((DataTable)dataGridView1.DataSource).Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "操作有误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
            
        }

        private void 审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "收款单")
            {
                if (OSL_Group == "财务部")
                {
                    string a = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString().Trim();
                    SqlConnection conn = new SqlConnection(SQL);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE [dbo].[Receipt] SET examine = '已审核' where orderid like '%" + a + "%'";
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
                    MessageBox.Show("对不起你没有权限");
                }

            }
            if (CKLB.Text == "销售订单主数据")
            {
                string a = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString().Trim();
                SqlConnection conn = new SqlConnection(SQL);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE [dbo].[Order_h] SET examine = '已审核' where orderid like '%" + a + "%'";
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
            
            if (CKLB.Text == "收款单")
            {
                if (OSL_Group == "财务部" || OSL_Group == "Administrators"|| OSL_Group == "客服部")
                {
                    string a = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString().Trim();
                    SqlConnection conn = new SqlConnection(SQL);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE [dbo].[Receipt] SET examine = '未审核' where orderid like '%" + a + "%'";
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
                    MessageBox.Show("对不起，无权反审核");
                }

            }
            if (CKLB.Text == "销售订单主数据")
            {
                string a = dataGridView1.CurrentRow.Cells["单据编号"].Value.ToString().Trim();
                SqlConnection conn1 = new SqlConnection(SQL);
                conn1.Open();
                SqlCommand cmd1 = conn1.CreateCommand();
                string strsql = "select * from ProductIn where orderid = '" + a + "'";
                cmd1.CommandText = strsql;
                int i = Convert.ToInt32(cmd1.ExecuteScalar());
                SqlDataAdapter da = new SqlDataAdapter(strsql,SQL);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count == 0)
                {
                    if (OSL_Group == "财务部" || OSL_Group == "Administrators" || OSL_Group == "客服部")
                    {
                        if(i == 0)
                        {
                            SqlConnection conn = new SqlConnection(SQL);
                            conn.Open();
                            SqlCommand cmd = conn.CreateCommand();
                            cmd.CommandText = "UPDATE [dbo].[Order_h] SET examine = '未审核' where orderid like '%" + a + "%'";
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
                            MessageBox.Show("订单已入库，无法反审核");
                        }  
                    }
                    else
                    {
                        MessageBox.Show("财务，客服才能反审核，去找他们。");
                    }
                    conn1.Close();
                }
                else
                {
                    MessageBox.Show("产品已入库，无法反审核");
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "销售订单主数据")
            {
                if (OSL_Group == "财务部" || OSL_Group == "Administrators" || OSL_Group == "客服部") {
                    if (dataGridView1.CurrentRow.Cells["审核状态"].Value.ToString() == "已审核")
                    {
                        MessageBox.Show("已审核，无法删除");
                    }
                    else
                    {
                        string htbh = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
                        SqlConnection conn = new SqlConnection(SQL);
                        conn.Open();
                        SqlCommand cmmd = conn.CreateCommand();
                        cmmd.CommandText = "select * from [dbo].[ProductIn] where contractid ='" + htbh + "'";
                        SqlDataReader sdr = cmmd.ExecuteReader();
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            MessageBox.Show("订单已入库，无法删除。", "警告");
                        }
                        else
                        {
                            sdr.Close();
                            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == OSL_User)
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
                                dataGridView1.ReadOnly = true;
                                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                if (MessageBox.Show("是否一并删除详细数据", "提示!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    SqlCommand cmd = conn.CreateCommand();
                                    cmd.CommandText = "DELETE FROM [dbo].[Order_b] WHERE orderid = '" + del + "'";
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
                            else
                            {
                                MessageBox.Show("无法删除别人的单据");
                            }
                        }
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("权限不够，无法删除！");
                }
            }
            if (CKLB.Text == "收款单")
            {
                if (dataGridView1.CurrentRow.Cells[12].Value.ToString() == "已审核")
                {
                    MessageBox.Show("已审核，无法删除");
                }
                else
                {
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
                    dataGridView1.ReadOnly = true;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
        }

        private void 收款单修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CKLB.Text == "收款单")
            {
                if (dataGridView1.CurrentRow.Cells["审核状态"].Value.ToString() == "已审核")
                {
                    MessageBox.Show("已审核，无法修改");
                }
                else
                {

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                    dataGridView1.ReadOnly = false;
                    dataGridView1.AllowUserToDeleteRows = true;
                }
            }

        }

        private void 批量审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "销售订单主数据")
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
            if (CKLB.Text == "收款单")
            {
                if (OSL_Group == "财务部" || OSL_Group == "Administrators")
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
                else
                {
                    MessageBox.Show("对不起，无权审核");
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CKLB.Text == "销售订单主数据")
            {
                //获取索引为1的第二个字段订单号
                string a = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                OrderServiceR orderserviceR = new OrderServiceR();
                // 给窗体的公共属性赋值
                orderserviceR.OSR_Ord = a;
                orderserviceR.OSR_User = OSL_User;
                orderserviceR.OSR_Group = OSL_Group;
                // 显示子窗体
                orderserviceR.Show();
            }
        }

        private void 收款单保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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

        #endregion
        private void 发货申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "销售订单详细数据")
            {
                if (dataGridView1.CurrentRow.Cells["出库状态"].Value.ToString() == "N")
                {
                    if (MessageBox.Show("是否要提交发货申请到财务！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {

                        string htbh = dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
                        string gdy = dataGridView1.CurrentRow.Cells["跟单员"].Value.ToString();
                        string gsm = dataGridView1.CurrentRow.Cells["公司名"].Value.ToString();
                        string xmmc = dataGridView1.CurrentRow.Cells["项目名称"].Value.ToString();
                        string cpmc = dataGridView1.CurrentRow.Cells["产品名称"].Value.ToString();
                        string nr = dataGridView1.CurrentRow.Cells["内容"].Value.ToString();
                        string sl = dataGridView1.CurrentRow.Cells["数量"].Value.ToString();
                        string dw = dataGridView1.CurrentRow.Cells["单位"].Value.ToString();
                        string je = dataGridView1.CurrentRow.Cells["金额"].Value.ToString();

                        Orderxz orderxz = new Orderxz();
                        orderxz.OXZ_Htbh = htbh;
                        orderxz.OXZ_Gdy = gdy;
                        orderxz.OXZ_Gsm = gsm;
                        orderxz.OXZ_Xmmc = xmmc;
                        orderxz.OXZ_Cpmc = cpmc;
                        orderxz.OXZ_Nr = nr;
                        orderxz.OXZ_Sl = sl;
                        orderxz.OXZ_Dw = dw;
                        orderxz.OXZ_Je = je;
                        orderxz.Show();
                    }
                }
                else
                {
                    MessageBox.Show("已经出库，无法申请");
                }
            }
        }

        private void OrderServiceList_Load(object sender, EventArgs e)
        {
            RQ.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(-2);
            RQ1.Value = DateTime.Now;
            asc.controllInitializeSize(this);

        }

        private void OrderServiceList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void 批量发货申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CKLB.Text == "销售订单详细数据")
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        int m = dataGridView1.SelectedRows[i].Index;

                        if (dataGridView1.Rows[m].Cells["出库状态"].Value.ToString() == "N")
                        {
                            string htbh = dataGridView1.Rows[m].Cells["合同编号"].Value.ToString();
                            string gdy = dataGridView1.Rows[m].Cells["跟单员"].Value.ToString();
                            string gsm = dataGridView1.Rows[m].Cells["公司名"].Value.ToString();
                            string xmmc = dataGridView1.Rows[m].Cells["项目名称"].Value.ToString();
                            string cpmc = dataGridView1.Rows[m].Cells["产品名称"].Value.ToString();
                            string nr = dataGridView1.Rows[m].Cells["内容"].Value.ToString();
                            string sl = dataGridView1.Rows[m].Cells["数量"].Value.ToString();
                            string dw = dataGridView1.Rows[m].Cells["单位"].Value.ToString();
                            string je = dataGridView1.Rows[m].Cells["金额"].Value.ToString();

                            SqlConnection con = new SqlConnection(SQL);

                            try
                            {
                                string sqsj = DateTime.Now.ToString("G");
                                con.Open();
                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "INSERT INTO Message_FHSQ ([contractid],[applytime],[service],[company],[project],[productname],[sub],[quantity],[unit],[amount],[fhck],[fhwl],[examine],[checkout],[readzt]) VALUES('" + htbh + "','" + sqsj + "','" + gdy + "','" + gsm + "','" + xmmc + "','" + cpmc + "','" + nr + "','" + sl + "','" + dw + "','" + je + "','一线成品仓','装车','未审核','未出库','未读')";
                                cmd.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message.ToString());

                            }
                            finally
                            {
                                con.Close();
                            }
                            try
                            {
                                con.Open();
                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "UPDATE Order_b SET ident = 'Y' WHERE productname = '" + cpmc + "' and sub = '" + nr + "'";
                                cmd.ExecuteNonQuery();
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
                        else
                        {
                            string cpmc = dataGridView1.Rows[m].Cells["产品名称"].Value.ToString();
                            string nr = dataGridView1.Rows[m].Cells["内容"].Value.ToString();
                            string ts = "该产品" + cpmc + "-" + nr + "产品已出库，无法申请";
                            MessageBox.Show(ts);
                            break;
                        }

                    }
                    MessageBox.Show("申请成功，请到主界面小蓝标查看");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}