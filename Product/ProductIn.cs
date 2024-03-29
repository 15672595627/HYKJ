﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography;
using System.Windows.Controls;
using WindowsFormsApp1.Class;
using System.Data.Common;
using DataTable = System.Data.DataTable;

namespace WindowsFormsApp1.Product
{
    public partial class ProductIn : Form
    {
        public ProductIn()
        {
            InitializeComponent();
            dataGridView1.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e) { };
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string PI_user { get; set; }
        public string PI_group { get; set; }

        public DataTable PDI;

        DataTable dt1;
        SqlDataAdapter da1;
        DataTable dt2;
        SqlDataAdapter da2;
        DataTable dt3;
        SqlDataAdapter da3;
        DataTable dt4;
        SqlDataAdapter da4;

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void ProductIn_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            DJBH.Text = "CPRK" + time;
            DJRQ.Text = DateTime.Now.ToString("yyyy-MM-dd");
            toolStripStatusLabel2.Text = PI_user;
            toolStripStatusLabel5.Text = PI_group;
            LDY.Text = PI_user;
        }

        private void BC_Click(object sender, EventArgs e)
        {
            string djbh = DJBH.Text.Trim();
            string djrq = DJRQ.Text.Trim();
            string ldy = LDY.Text.Trim();
            string sj = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection(SQL);

            try
            {
                con.Open();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    string xsdj = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string htbh = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string gsm = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string xmmc = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string cpmc = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string nr = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    decimal sl = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value.ToString());
                    string dw = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    string kfdj = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    string ms = dataGridView1.Rows[i].Cells[9].Value.ToString();
                    string kfje = dataGridView1.Rows[i].Cells[10].Value.ToString();
                    string wscz = dataGridView1.Rows[i].Cells["无税金额"].Value.ToString();
                    string xdrq = dataGridView1.Rows[i].Cells["下单日期"].Value.ToString();
                    string jesl = dataGridView1.Rows[i].Cells[13].Value.ToString();
                    decimal sssl = Convert.ToDecimal(dataGridView1.Rows[i].Cells[14].Value.ToString());
                    string zsms = dataGridView1.Rows[i].Cells[15].Value.ToString();
                    string sjdj = dataGridView1.Rows[i].Cells[16].Value.ToString();
                    string shck = dataGridView1.Rows[i].Cells[17].Value.ToString();
                    string cbdj = dataGridView1.Rows[i].Cells[18].Value.ToString();
                    string cbje = dataGridView1.Rows[i].Cells[19].Value.ToString();
                    //string xdrq = dataGridView1.Rows[i].Cells["下单日期"].Value.ToString();
                    //string cwrq = dataGridView1.Rows[i].Cells["caiwuRiqi"].Value.ToString();
                    double sda = Math.Round(Convert.ToDouble(wscz), 0);
                    string str = "select contractid as 合同编号,product as 产品,sub as 内容,num as 数量,amount as 金额 from [dbo].[Stock] where product = '" + cpmc + "' and  sub = '" + nr + "' and contractid = '" + htbh + "' ";
                    da1 = new SqlDataAdapter(str, SQL);
                    dt1 = new DataTable();
                    da1.Fill(dt1);
                    string str1 = "select contractid as 合同编号,productname as 产品,sub as 内容,quantity as 数量,amount as 金额 from [dbo].[Order_b] where productname = '" + cpmc + "' and sub = '" + nr + "' and contractid = '" + htbh + "' and quantity = '" + sssl + "'and date = '" + xdrq + "'";
                    da2 = new SqlDataAdapter(str1, SQL);
                    dt2 = new DataTable();
                    da2.Fill(dt2);
                    string str2 = "select contractid as 合同编号,productname as 产品,sub as 内容,quantity as 数量,amount as 金额 from [dbo].[Order_b] where productname = '" + cpmc + "' and sub = '" + nr + "' and contractid = '" + htbh + "' and quantity > '" + sssl + "'";
                    da3 = new SqlDataAdapter(str2, SQL);
                    dt3 = new DataTable();
                    da3.Fill(dt3);

                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        /*cmd.CommandText = "select * from [dbo].[ProductIn] where product = '" + cpmc + "' and  substance = '" + nr + "' and contractid = '" + htbh + "'and sl = '" + sssl + "'and xdrq = '" + xdrq + "'";
                        SqlDataReader sdr = cmd.ExecuteReader();
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            sdr.Close();
                            string ts = "此产品" + cpmc + "-" + nr + "已入库，保存跳过此行";
                            MessageBox.Show(ts);
                            continue;
                        }
                        else*/
                        {
                            //sdr.Close();
                            SqlCommand cmmd = con.CreateCommand();
                            cmmd.CommandText = "INSERT INTO [dbo].[ProductIn] ([orderid],[date],[caiwuRiqi],[staffin],[sorderid],[contractid],[company],[project],[product],[substance],[sl],[dw],[kfdj],[meters],[kfje],[tax],[wscz],[sssl],[zsms],[sjdj],[shck],[cbdj],[cbje],[state],[examine],[sent],cwsh,xdrq,productionScheduling,state1) VALUES ('" + djbh + "','" + djrq + "','" + djrq + "','" + ldy + "','" + xsdj + "','" + htbh + "','" + gsm + "','" + xmmc + "','" + cpmc + "','" + nr + "','" + sl + "','" + dw + "','" + kfdj + "','" + ms + "','" + kfje + "','" + jesl + "','" + sda + "','" + sssl + "','" + zsms + "','" + sjdj + "','" + shck + "','" + cbdj + "','" + cbje + "','已入库','已审核','0','未审核','" + xdrq + "','未排产','1')";
                            int cot = cmmd.ExecuteNonQuery();
                            if (cot == 0)
                            {
                                MessageBox.Show("保存失败");
                            }
                        }
                    }
                    if (dt1.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt1.Rows.Count; j++)
                        {
                            string htbh1 = dt1.Rows[j]["合同编号"].ToString();
                            string cp1 = dt1.Rows[j]["产品"].ToString();
                            string nr1 = dt1.Rows[j]["内容"].ToString();
                            decimal sl1 = Convert.ToDecimal(dt1.Rows[j]["数量"]);
                            decimal je1 = Convert.ToDecimal(dt1.Rows[j]["金额"]);
                            //库存在,追加库存（到底是金额还是数量，还是一起）
                            if (htbh == htbh1 && cpmc == cp1 && nr1 == nr)
                            {
                                decimal sumSl = sl1 + sssl;
                                decimal sumje = Convert.ToDecimal(kfje) + je1;

                                SqlCommand cmd1 = con.CreateCommand();
                                cmd1.CommandText = "update Stock set num = '" + sumSl + "',amount = '" + sumje + "',updatetime = '" + sj + "' where contractid = '" + htbh + "' and product = '" + cpmc + "' and sub = '" + nr + "'";
                                cmd1.ExecuteNonQuery();
                            }
                            //不存在库存，添加库存
                            else
                            {
                                SqlCommand cmd2 = con.CreateCommand();
                                cmd2.CommandText = "insert into Stock(date,contractid,product,sub,norm,unit,num,amount,warehouse,createtime) VALUES ('" + sj + "','" + htbh + "','" + cpmc + "','" + nr + "','','" + dw + "','" + sl + "','" + kfje + "','" + shck + "','" + sj + "')";
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        SqlCommand cmd3 = con.CreateCommand();
                        cmd3.CommandText = "insert into Stock(date,contractid,product,sub,norm,unit,num,amount,warehouse,createtime) VALUES ('" + sj + "','" + htbh + "','" + cpmc + "','" + nr + "','','" + dw + "','" + sl + "','" + kfje + "','" + shck + "','" + sj + "')";
                        cmd3.ExecuteNonQuery();
                    }
                    if (dt2.Rows.Count > 0)
                    {
                        SqlCommand cmmd1 = con.CreateCommand();
                        cmmd1.CommandText = "update Order_b set rkzt = '已入库',rksj = '" + djrq + "' where productname = '" + cpmc + "' and sub = '" + nr + "' and contractid = '" + htbh + "'";
                        int cot2 = cmmd1.ExecuteNonQuery();
                    }
                    if (dt3.Rows.Count > 0)
                    {
                        SqlCommand cmmd2 = con.CreateCommand();
                        cmmd2.CommandText = "update Order_b set rkzt = '部分入库',rksj = '" + djrq + "' where productname = '" + cpmc + "' and sub = '" + nr + "' and contractid = '" + htbh + "'";
                        int cot3 = cmmd2.ExecuteNonQuery();
                    }

                    string str3 = "select contractid as 合同编号,product as 产品,nr as 内容 from [dbo].[Plan] where product = '" + cpmc + "' and nr = '" + nr + "' and contractid = '" + htbh + "'";
                    da4 = new SqlDataAdapter(str3, ProductIn.SQL);
                    dt4 = new DataTable();
                    da4.Fill(this.dt4);
                    for (int k = 0; k < this.dt4.Rows.Count; k++)
                    {
                        string b3 = dt4.Rows[k]["合同编号"].ToString();
                        string b4 = dt4.Rows[k]["产品"].ToString();
                        string a2 = dt4.Rows[k]["内容"].ToString();
                        if (htbh == b3 && cpmc == b4 && a2 == nr)
                        {
                            SqlCommand cmd111 = con.CreateCommand();
                            cmd111.CommandText = "update ProductIn set productionScheduling = '已排产'where contractid = '" + htbh + "' and product = '" + cpmc + "' and substance = '" + nr + "'";
                            cmd111.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand cmd222 = con.CreateCommand();
                            cmd222.CommandText = "update ProductIn set productionScheduling = '未排产''";
                            cmd222.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("保存成功");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "你还有没填完的数据。");
            }
            finally
            {
                con.Close();
            }
        }

        private void ProductIn_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = PDI;


            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["销售订单"].Visible = false;
                dataGridView1.Columns["合同编号"].Visible = false;
                dataGridView1.Columns["公司名"].Visible = false;
                dataGridView1.Columns["项目名称"].Visible = false;

                DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn();
                cb.Items.Add("一线成品仓");
                cb.Items.Add("二线成品仓");
                cb.Items.Add("三线成品仓");
                cb.Items.Add("重庆公司");
                cb.Items.Add("安徽公司");
                cb.Items.Add("云南公司");
                cb.HeaderText = "收货仓库";
                cb.Name = "收货仓库";

                dataGridView1.Columns.Add("税率", "税率");
                //dataGridView1.Columns.Add("无税产值", "无税产值");
                dataGridView1.Columns.Add("实收数量", "实收数量");
                dataGridView1.Columns.Add("折算米数", "折算米数");
                dataGridView1.Columns.Add("实际单价", "实际单价");
                dataGridView1.Columns.Add(cb);
                dataGridView1.Columns.Add("成本单价", "成本单价");
                dataGridView1.Columns.Add("成本金额", "成本金额");

                dataGridView1.Columns["产品"].ReadOnly = true;
                dataGridView1.Columns["内容"].ReadOnly = true;
                dataGridView1.Columns["数量"].ReadOnly = true;
                dataGridView1.Columns["单位"].ReadOnly = true;
                dataGridView1.Columns["单价"].ReadOnly = true;
                dataGridView1.Columns["米数"].ReadOnly = true;
                dataGridView1.Columns["总金额"].ReadOnly = true;
                dataGridView1.Columns["税率"].ReadOnly = true;
                dataGridView1.Columns["无税金额"].ReadOnly = true;

                if (PI_group == "资材部")
                {
                    dataGridView1.Columns["单价"].Visible = false;
                    dataGridView1.Columns["总金额"].Visible = false;
                    dataGridView1.Columns["税率"].Visible = false;
                    dataGridView1.Columns["无税金额"].Visible = false;
                    dataGridView1.Columns["实际单价"].Visible = false;
                    dataGridView1.Columns["成本单价"].Visible = false;
                    dataGridView1.Columns["成本金额"].Visible = false;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string xsdj = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string strsql = "select orderid,tax from Order_h  WHERE orderid = '" + xsdj + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["税率"].Value = dt.Rows[0][1].ToString();
                    }

                    //dataGridView1.Rows[i].Cells["无税产值"].Value = "0";
                    dataGridView1.Rows[i].Cells["实际单价"].Value = "0";
                    dataGridView1.Rows[i].Cells["成本单价"].Value = "0";
                    dataGridView1.Rows[i].Cells["成本金额"].Value = "0";
                }
            }
        }

        private void XZ_Click(object sender, EventArgs e)
        {
            ProductInCon pcon = new ProductInCon();
            pcon.Show(this);
        }

        private void ProductIn_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
