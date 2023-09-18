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
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Product
{
    public partial class ProductOut : Form
    {
        public ProductOut()
        {
            InitializeComponent();
        }


        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        public string PO_user { get; set; }
        public string PO_group { get; set; }
        int cot;
        int cot1;
        int cot2;
        int cot3;
        int cot4;
        int cot5;
        int cot6;
        public DataTable PDO;
        private void ProductOut_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "CPCK" + time;
            DJRQ.Text = DateTime.Now.ToString("yyyy-MM-dd");
            toolStripStatusLabel2.Text = PO_user;
            toolStripStatusLabel5.Text = PO_group;
            LDY.Text = PO_user;
        }
        decimal sl1;
        decimal je1;
        DataTable dt1;
        SqlDataAdapter da1;
        private void BC_Click(object sender, EventArgs e)
        {
            string sj = DateTime.Now.ToString("yyyy-MM-dd");
            string djbh = DJBH.Text.Trim();
            string djrq = DJRQ.Text.Trim();
            string ldy = LDY.Text.Trim();


            SqlConnection con = new SqlConnection(SQL);

            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    con.Open();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string id = dataGridView1.Rows[i].Cells["id"].Value.ToString();
                        string xsdj = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        string htbh = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        string gsm = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        string xmmc = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        string cpmc = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        string nr = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        decimal sl = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                        string dw = dataGridView1.Rows[i].Cells[8].Value.ToString();
                        string kfdj = dataGridView1.Rows[i].Cells[9].Value.ToString();
                        string ms = dataGridView1.Rows[i].Cells[10].Value.ToString();
                        string kfje = dataGridView1.Rows[i].Cells[11].Value.ToString();

                        string jesl = dataGridView1.Rows[i].Cells[12].Value.ToString();

                        string wscz = dataGridView1.Rows[i].Cells[13].Value.ToString();

                        decimal fhsl = Convert.ToDecimal(dataGridView1.Rows[i].Cells[14].Value);
                        string fhje = dataGridView1.Rows[i].Cells[15].Value.ToString();
                        string fhcbje = dataGridView1.Rows[i].Cells[16].Value.ToString();

                        string gdy = dataGridView1.Rows[i].Cells[17].Value.ToString();
                        string ywy = dataGridView1.Rows[i].Cells[18].Value.ToString();

                        string shck = dataGridView1.Rows[i].Cells[19].Value.ToString();
                        //string cwrq = dataGridView1.Rows[i].Cells["caiwuRiqi"].Value.ToString();

                        
                        SqlCommand cmmd = con.CreateCommand();
                        cmmd.CommandText = "select * from [dbo].[ProductOut] where product = '" + cpmc + "' and  substance = '" + nr + "' and kfdj = '" + kfdj + "' and fhsl = '" + fhsl + "' and fhamount = '" + fhje + "'";
                        SqlDataReader sdr = cmmd.ExecuteReader();
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            sdr.Close();
                            string ts = "此产品" + cpmc + "-" + nr + "已出库，请删除后重新保存";
                            MessageBox.Show(ts);
                            return;

                        }
                        else
                        {
                            sdr.Close();
                            SqlCommand cmmmd = con.CreateCommand();
                            cmmmd.CommandText = "select * from [dbo].[ProductIn] where product = '" + cpmc + "' and  substance = '" + nr + "' and kfje = '" + fhsl + "'";
                            SqlDataReader ssdr = cmmmd.ExecuteReader();
                            ssdr.Read();
                            if (ssdr.HasRows)
                            {
                                ssdr.Close();
                                string ts = "此产品" + cpmc + "-" + nr + "未入库，请先入库,是否打开入库界面";
                                if (MessageBox.Show(ts, "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                {

                                    ProductIn productIn = new ProductIn();
                                    productIn.ShowDialog();
                                    return;
                                }
                                else
                                {
                                    return;
                                }

                            }
                            else
                            {
                                ssdr.Close();
                                //匹配库存，减库存
                                string st = "select contractid as 合同编号,product as 产品,sub as 内容,num as 数量,amount as 金额 from [dbo].[Stock] where product = '" + cpmc + "' and  sub = '" + nr + "' and  contractid = '" + htbh + "'";
                                da1 = new SqlDataAdapter(st, SQL);
                                dt1 = new DataTable();
                                da1.Fill(dt1);

                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = st;
                                SqlDataReader sdr1 = cmd.ExecuteReader();
                                sdr1.Read();
                                if (!sdr1.HasRows)
                                {
                                    sdr1.Close();


                                    string ts = "此产品" + cpmc + "-" + nr + "库存不存在，请添加库存后进行出库！";
                                    MessageBox.Show(ts);
                                    continue;
                                }
                                for (int j = 0; j < dt1.Rows.Count; j++)
                                {
                                    string htbh1 = dt1.Rows[j]["合同编号"].ToString();
                                    string cp1 = dt1.Rows[j]["产品"].ToString();
                                    string nr1 = dt1.Rows[j]["内容"].ToString();
                                    sl1 = Convert.ToDecimal(dt1.Rows[j]["数量"]);
                                    je1 = Convert.ToDecimal(dt1.Rows[j]["金额"]);
                                    if (htbh == htbh1 && cpmc == cp1 && nr1 == nr && sl1 >= fhsl)
                                    {
                                        decimal sumSl = sl1 - fhsl;
                                        decimal sumje = je1 - Convert.ToDecimal(kfje);

                                        SqlCommand cmd1 = con.CreateCommand();
                                        cmd1.CommandText = "update Stock set num = '" + sumSl + "',amount = '" + sumje + "',updatetime = '" + sj + "' where contractid = '" + htbh + "' and product = '" + cpmc + "' and sub = '" + nr + "'";
                                        cmd1.ExecuteNonQuery();

                                        SqlCommand cmd2 = con.CreateCommand();
                                        cmd2.CommandText = "INSERT INTO [dbo].[ProductOut] ([orderid],[date],[caiwuRiqi],[staffout],[sorderid],[contractid],[service],[seller],[company],[project],[product],[substance],[sl],[dw],[kfdj],[meters],[kfje],[tax],[wscz],[fhsl],[fhamount],[fhcbamount],[shck],[sent],[examine],[examine1]) values ('" + djbh + "','" + djrq + "','" + djrq + "','" + ldy + "','" + xsdj + "','" + htbh + "','" + gdy + "','" + ywy + "','" + gsm + "','" + xmmc + "','" + cpmc + "','" + nr + "','" + sl + "','" + dw + "','" + kfdj + "','" + ms + "','" + kfje + "','" + jesl + "','" + wscz + "','" + fhsl + "','" + fhje + "','" + fhcbje + "','" + shck + "','0','已审核','未审核')";
                                        cmd2.ExecuteNonQuery();
                                    }
                                    else if (htbh == htbh1 && cpmc == cp1 && nr1 == nr && sl1 < fhsl)
                                    {
                                        MessageBox.Show("该产品" + cpmc + "库存量不够，请补充库存量后进行出库操作！");
                                    }
                                    
                                    if (sl == fhsl)
                                    {
                                        SqlCommand cmd1 = con.CreateCommand();
                                        cmd1.CommandText = "update Order_b set ckzt = '已出库' where id = '" + id + "'";
                                        cot1 = cmd1.ExecuteNonQuery();

                                        SqlCommand cmd4 = con.CreateCommand();
                                        cmd4.CommandText = "update Order_b_cw set ckzt = '已出库' where oId = '" + id + "'";
                                        cot4 = cmd4.ExecuteNonQuery();
                                    }
                                    else if (fhsl == 0)
                                    {
                                        SqlCommand cmd2 = con.CreateCommand();
                                        cmd2.CommandText = "update Order_b set ckzt = '未出库' where id = '" + id + "'";
                                        cot2 = cmd2.ExecuteNonQuery();

                                        SqlCommand cmd5 = con.CreateCommand();
                                        cmd5.CommandText = "update Order_b_cw set ckzt = '未出库' where oId = '" + id + "'";
                                        cot5 = cmd5.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        SqlCommand cmd3 = con.CreateCommand();
                                        cmd3.CommandText = "update Order_b set ckzt = '部分出库' where id = '" + id + "'";
                                        cot3 = cmd3.ExecuteNonQuery();

                                        SqlCommand cmd6 = con.CreateCommand();
                                        cmd6.CommandText = "update Order_b_cw set ckzt = '部分出库' where oId = '" + id + "'";
                                        cot6 = cmd6.ExecuteNonQuery();
                                    }

                                    if (cot1 < 1 && cot2 < 1 && cot3 < 1)
                                    {
                                        MessageBox.Show("保存失败");
                                    }
                                }
                                MessageBox.Show("保存成功");
                            }
                        }
                    }
                    this.Close();
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
        /*
        private void GSM_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource= null;
                string cpmc = CPMC.Text.Trim();
                string strsql = "select  contractid as 合同编号,product as 产品,norms as 规格,shck as 收货仓库,cbdj as 成本单价,cbje as 成本金额,kfcz as 总产值含税,sjcz as 总产值无税,scdj as 单价,dw as 单位,sssl as 应发数量,sent as 已发数量 from [dbo].[ProductIn] where product = '" + cpmc + "'";
                da = new SqlDataAdapter(strsql, SQL);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns.Add("发货数量", "发货数量");
                dataGridView1.Columns.Add("发货金额", "发货金额");
                dataGridView1.Columns.Add("发货成本金额", "发货成本金额");
                dataGridView1.Columns["应发数量"].ReadOnly = true;
                string aa = dataGridView1.Rows[0].Cells["应发数量"].Value.ToString();
                string bb = dataGridView1.Rows[0].Cells["已发数量"].Value.ToString();
                if(aa == bb)
                {
                    dataGridView1.Rows[0].Cells["发货数量"].ReadOnly = true;
                    dataGridView1.Rows[0].Cells["发货数量"].Style.BackColor = Color.Red;
                    
                    BC.Enabled = false;
                }
                dataGridView1.Rows[0].Cells["发货数量"].Value = dataGridView1.Rows[0].Cells["应发数量"].Value;
                dataGridView1.Rows[0].Cells["发货金额"].Value = dataGridView1.Rows[0].Cells["总产值无税"].Value;
                dataGridView1.Rows[0].Cells["发货成本金额"].Value = "0";
            }

        }

        private void HTBH_TextChanged(object sender, EventArgs e)
        {
            if(HTBH.Text == "")
            {
                return;
            }
            else
            {
                string strsql = "select contractid,service,seller from [dbo].[Order_h] where contractid = '" + HTBH.Text.Trim() + "'";
                SqlDataAdapter da =  new SqlDataAdapter(strsql,SQL);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GDY.Text = dt.Rows[0][1].ToString();
                YWY.Text = dt.Rows[0][2].ToString();
            }
        }
        */
        private void XZ_Click(object sender, EventArgs e)
        {
            ProductOutCon outCon = new ProductOutCon();
            outCon.Show(this);
        }

        private void ProductOut_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = PDO;

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["销售订单"].Visible = false;
                dataGridView1.Columns["合同编号"].Visible = false;
                dataGridView1.Columns["公司名"].Visible = false;
                dataGridView1.Columns["项目名称"].Visible = false;
                

                DataGridViewComboBoxColumn ck = new DataGridViewComboBoxColumn();
                ck.Items.Add("一线成品仓");
                ck.Items.Add("二线成品仓");
                ck.Items.Add("三线成品仓");
                ck.Items.Add("仓库");
                ck.Items.Add("重庆公司");
                ck.Items.Add("安徽公司");
                ck.Items.Add("云南公司");
                ck.HeaderText = "发货仓库";
                ck.Name = "发货仓库";

                dataGridView1.Columns.Add("税率", "税率");
                dataGridView1.Columns.Add("无税产值", "无税产值");
                dataGridView1.Columns.Add("发货数量", "发货数量");
                dataGridView1.Columns.Add("发货金额", "发货金额");
                dataGridView1.Columns.Add("发货成本金额", "发货成本金额");
                dataGridView1.Columns.Add("跟单员", "跟单员");
                dataGridView1.Columns.Add("业务员", "业务员");
                dataGridView1.Columns.Add(ck);

                dataGridView1.Columns["跟单员"].Visible = false;
                dataGridView1.Columns["业务员"].Visible = false;

                dataGridView1.Columns["产品"].ReadOnly = true;
                dataGridView1.Columns["内容"].ReadOnly = true;
                dataGridView1.Columns["数量"].ReadOnly = true;
                dataGridView1.Columns["单位"].ReadOnly = true;
                dataGridView1.Columns["单价"].ReadOnly = true;
                dataGridView1.Columns["米数"].ReadOnly = true;
                dataGridView1.Columns["金额"].ReadOnly = true;
                dataGridView1.Columns["税率"].ReadOnly = true;

                if (PO_group == "资材部")
                {
                    dataGridView1.Columns["单价"].Visible = false;
                    dataGridView1.Columns["金额"].Visible = false;
                    dataGridView1.Columns["税率"].Visible = false;
                    dataGridView1.Columns["无税产值"].Visible = false;
                    dataGridView1.Columns["发货金额"].Visible = false;
                    dataGridView1.Columns["发货成本金额"].Visible = false;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++) 
                {
                    string xsdj = dataGridView1.Rows[i].Cells["销售订单"].Value.ToString();
                    string strsql = "select orderid,service,seller,tax from Order_h  WHERE orderid = '" + xsdj + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["跟单员"].Value = dt.Rows[0][1].ToString();
                        dataGridView1.Rows[i].Cells["业务员"].Value = dt.Rows[0][2].ToString();
                        dataGridView1.Rows[i].Cells["税率"].Value = dt.Rows[0][3].ToString();

                    }

                    dataGridView1.Rows[i].Cells["无税产值"].Value = "0";
                    dataGridView1.Rows[i].Cells["发货数量"].Value = "0";
                    dataGridView1.Rows[i].Cells["发货金额"].Value = "0";
                    dataGridView1.Rows[i].Cells["发货成本金额"].Value = "0";
                    
                }
                //dataGridView1.Columns["id"].Visible = false;
            }
        }

        private void ProductOut_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

    }
}
