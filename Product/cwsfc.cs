using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Product
{
    public partial class cwsfc : Form
    {
        public cwsfc()
        {
            InitializeComponent();
        }
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        SqlDataAdapter da;
        DataTable dt;
        SqlDataAdapter da1;
        DataTable dt1;
        SqlDataAdapter da2;
        DataTable dt2;
        SqlDataAdapter da3;
        DataTable dt3;
        SqlDataAdapter da4;
        DataTable dt4;
        SqlDataAdapter da5;
        DataTable dt5;
        SqlDataAdapter da6;
        DataTable dt6;
        DataRow dr;
        string htbh1;
        string cpmc1;
        string nr1;
        string htbh2;
        string cpmc2;
        string nr2;
        string htbh3;
        string cpmc3;
        string nr3;
        string htbh4;
        string cpmc4;
        string nr4;
        string htbh5;
        string cpmc5;
        string nr5;
        string htbh6;
        string cpmc6;
        string nr6;
        decimal sl1;
        decimal je1;
        decimal sl2;
        decimal je2;
        decimal sl3;
        decimal je3;
        decimal sl4;
        decimal je4;
        decimal sl5;
        decimal je5;
        decimal sl6;
        decimal je6;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button1_Click(object sender, EventArgs e)
        {

            {
                //上个月
                string yue1 = RQ.Value.AddMonths(-1).ToString("yyyy-MM");
                //得到上上个月最后一天
                string tian1 = Convert.ToDateTime(yue1).AddMonths(0).AddDays(-1).ToString("yyyy-MM-dd");

                //拿到datatimepiker控件的值
                string yue = RQ.Text.Trim();
                //得到上个月最后一天
                string tian = Convert.ToDateTime(yue).AddMonths(0).AddDays(-1).ToString("yyyy-MM-dd");

                dataGridView1.Columns.Clear();

                //即时库存
                string ss = "select contractid as 合同编号,product as 产品名称,sub as 内容 ,num as 数量,warehouse as 仓库 from Stock ";
                da = new SqlDataAdapter(ss, SQL);
                dt = new DataTable();
                da.Fill(dt);

                //上期初入库
                string str = "select contractid as 合同编号,company as 公司名,project as 项目 ,product as 产品名称 ,substance as 内容 ,sum(sl) as 数量,sum(kfje) as 金额 from ProductIn where caiwuRiqi like '%" + tian1 + "%' group by contractid,company,project,product,substance";
                da1 = new SqlDataAdapter(str, SQL);
                dt1 = new DataTable();
                da1.Fill(dt1);

                //上期初出库
                string str1 = "select contractid as 合同编号,company as 公司名,project as 项目 ,product as 产品名称 ,substance as 内容 ,sum(sl) as 数量,sum(kfje) as 金额 from ProductOut where caiwuRiqi like '%" + tian1 + "%' group by contractid,company,project,product,substance";
                da2 = new SqlDataAdapter(str1, SQL);
                dt2 = new DataTable();
                da2.Fill(dt2);

                //上本期收入
                string str2 = "select contractid as 合同编号,company as 公司名,project as 项目 ,product as 产品名称 ,substance as 内容 ,sum(sl) as 数量,sum(kfje) as 金额 from ProductIn where caiwuRiqi like '%" + yue1 + "%' group by contractid,company,project,product,substance";
                da3 = new SqlDataAdapter(str2, SQL);
                dt3 = new DataTable();
                da3.Fill(dt3);

                //上本期发出
                string str3 = "select contractid as 合同编号,company as 公司名,project as 项目 ,product as 产品名称 ,substance as 内容 ,sum(sl) as 数量,sum(kfje) as 金额 from ProductOut where caiwuRiqi like '%" + yue1 + "%' group by contractid,company,project,product,substance";
                da4 = new SqlDataAdapter(str3, SQL);
                dt4 = new DataTable();
                da4.Fill(dt4);

                 //本期收入
                string str4 = "select contractid as 合同编号,company as 公司名,project as 项目 ,product as 产品名称 ,substance as 内容 ,sum(sl) as 数量,sum(kfje) as 金额 from ProductIn where caiwuRiqi like '%" + yue + "%' group by contractid,company,project,product,substance";
                da5 = new SqlDataAdapter(str4, SQL);
                dt5 = new DataTable();
                da5.Fill(dt5);

                //本期发出
                string str5 = "select contractid as 合同编号,company as 公司名,project as 项目 ,product as 产品名称 ,substance as 内容 ,sum(sl) as 数量,sum(kfje) as 金额 from ProductOut where caiwuRiqi like '%" + yue + "%' group by contractid,company,project,product,substance";
                da6 = new SqlDataAdapter(str5, SQL);
                dt6 = new DataTable();
                da6.Fill(dt6);

                //添加列名称
                DataTable dtt = new DataTable();
                dtt.Columns.Add("时间", typeof(string));
                dtt.Columns.Add("合同编号", typeof(string));
                dtt.Columns.Add("产品名称", typeof(string));
                dtt.Columns.Add("内容", typeof(string));

                dtt.Columns.Add("上期初收入数量", typeof(int));
                dtt.Columns.Add("上期初收入单价", typeof(decimal));
                dtt.Columns.Add("上期初收入金额", typeof(decimal));

                dtt.Columns.Add("上期初发出数量", typeof(int));
                dtt.Columns.Add("上期初发出单价", typeof(decimal));
                dtt.Columns.Add("上期初发出金额", typeof(decimal));

                dtt.Columns.Add("上期初结存数量", typeof(int));
                dtt.Columns.Add("上期初结存单价", typeof(decimal));
                dtt.Columns.Add("上期初结存金额", typeof(decimal));

                dtt.Columns.Add("上本期收入数量", typeof(int));
                dtt.Columns.Add("上本期收入单价", typeof(decimal));
                dtt.Columns.Add("上本期收入金额", typeof(decimal));

                dtt.Columns.Add("上本期发出数量", typeof(int));
                dtt.Columns.Add("上本期发出单价", typeof(decimal));
                dtt.Columns.Add("上本期发出金额", typeof(decimal));

                dtt.Columns.Add("期初结存数量", typeof(int));
                dtt.Columns.Add("期初结存单价", typeof(decimal));
                dtt.Columns.Add("期初结存金额", typeof(decimal));

                dtt.Columns.Add("本期收入数量", typeof(int));
                dtt.Columns.Add("本期收入单价", typeof(decimal));
                dtt.Columns.Add("本期收入金额", typeof(decimal));

                dtt.Columns.Add("本期发出数量", typeof(int));
                dtt.Columns.Add("本期发出单价", typeof(decimal));
                dtt.Columns.Add("本期发出金额", typeof(decimal));

                dtt.Columns.Add("期末结存数量", typeof(int));
                dtt.Columns.Add("期末结存单价", typeof(decimal));
                dtt.Columns.Add("期末结存金额", typeof(decimal));
                //添加行内容
                //库存表
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dtt.NewRow();
                    string htbh = dt.Rows[i]["合同编号"].ToString();
                    string cpmc = dt.Rows[i]["产品名称"].ToString();
                    string nr = dt.Rows[i]["内容"].ToString();
                    dr["时间"] = yue;
                    dr["合同编号"] = htbh;
                    dr["产品名称"] = cpmc;
                    dr["内容"] = nr;
                    //上期初入
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        htbh1 = dt1.Rows[j]["合同编号"].ToString();
                        cpmc1 = dt1.Rows[j]["产品名称"].ToString();
                        nr1 = dt1.Rows[j]["内容"].ToString();
                        if (htbh == htbh1 || cpmc == cpmc1 || nr == nr1)
                        {
                            sl1 = Convert.ToInt32(dt1.Rows[j]["数量"]);
                            je1 = Convert.ToDecimal(dt1.Rows[j]["金额"]);
                            dr["上期初收入数量"] = sl1;
                            //dr["期初收入单价"] = djR;
                            dr["上期初收入金额"] = je1;
                        }
                    }
                    //上期初出  
                    if (dt1.Rows.Count > 0)
                    {
                        for (int k = 0; k < dt2.Rows.Count; k++)
                        {
                            htbh2 = dt2.Rows[k]["合同编号"].ToString();
                            cpmc2 = dt2.Rows[k]["产品名称"].ToString();
                            nr2 = dt2.Rows[k]["内容"].ToString();
                            if (htbh == htbh2 || cpmc == cpmc2 || nr == nr2)
                            {
                                sl2 = Convert.ToInt32(dt2.Rows[k]["数量"]);
                                //djC = Convert.ToDecimal(dt2.Rows[k]["单价"]);
                                je2 = Convert.ToDecimal(dt2.Rows[k]["金额"]);
                                dr["上期初发出数量"] = sl2;
                                //dr["期初发出单价"] = djC;
                                dr["上期初发出金额"] = je2;
                            }
                        }
                    }

                    //上本期收入
                    if (dt3.Rows.Count > 0)
                    {
                        for (int ii = 0; ii < dt3.Rows.Count; ii++)
                        {
                            htbh4 = dt3.Rows[ii]["合同编号"].ToString();
                            cpmc4 = dt3.Rows[ii]["产品名称"].ToString();
                            nr4 = dt3.Rows[ii]["内容"].ToString();
                            if (htbh == htbh4 || cpmc == cpmc4 || nr == nr4)
                            {
                                sl3 = Convert.ToInt32(dt3.Rows[ii]["数量"]);
                                //dj1 = Convert.ToDecimal(dt3.Rows[ii]["单价"]);
                                je3 = Convert.ToDecimal(dt3.Rows[ii]["金额"]);
                                dr["上本期收入数量"] = sl3;
                                //dr["本期收入单价"] = dj1;
                                dr["上本期收入金额"] = je3;
                            }
                        }
                    }

                    //上本期发出
                    for (int jj = 0; jj < dt4.Rows.Count; jj++)
                    {
                        htbh3 = dt4.Rows[jj]["合同编号"].ToString();
                        cpmc3 = dt4.Rows[jj]["产品名称"].ToString();
                        nr3 = dt4.Rows[jj]["内容"].ToString();
                        if (htbh == htbh3 || cpmc == cpmc3 || nr == nr3)
                        {
                            sl4 = Convert.ToInt32(dt4.Rows[jj]["数量"]);
                            //dj2 = Convert.ToDecimal(dt4.Rows[jj]["单价"]);
                            je4 = Convert.ToDecimal(dt4.Rows[jj]["金额"]);
                            dr["上本期发出数量"] = sl4;
                            //dr["本期发出单价"] = dj2;
                            dr["上本期发出金额"] = je4;
                        }
                    }
                    //本期收入
                    if (dt5.Rows.Count > 0)
                    {
                        for (int iii = 0; iii < dt5.Rows.Count; iii++)
                        {
                            htbh5 = dt5.Rows[iii]["合同编号"].ToString();
                            cpmc5 = dt5.Rows[iii]["产品名称"].ToString();
                            nr5 = dt5.Rows[iii]["内容"].ToString();
                            if (htbh == htbh5 || cpmc == cpmc5 || nr == nr5)
                            {
                                sl5 = Convert.ToInt32(dt5.Rows[iii]["数量"]);
                                //dj1 = Convert.ToDecimal(dt3.Rows[ii]["单价"]);
                                je5 = Convert.ToDecimal(dt5.Rows[iii]["金额"]);
                                dr["本期收入数量"] = sl5;
                                //dr["本期收入单价"] = dj1;
                                dr["本期收入金额"] = je5;
                            }
                        }
                    }

                    //本期发出
                    for (int jjj = 0; jjj < dt6.Rows.Count; jjj++)
                    {
                        htbh6 = dt6.Rows[jjj]["合同编号"].ToString();
                        cpmc6 = dt6.Rows[jjj]["产品名称"].ToString();
                        nr6 = dt6.Rows[jjj]["内容"].ToString();
                        if (htbh == htbh6 || cpmc == cpmc6 || nr == nr6)
                        {
                            sl6 = Convert.ToInt32(dt6.Rows[jjj]["数量"]);
                            //dj2 = Convert.ToDecimal(dt4.Rows[jj]["单价"]);
                            je6 = Convert.ToDecimal(dt6.Rows[jjj]["金额"]);
                            dr["本期发出数量"] = sl6;
                            //dr["本期发出单价"] = dj2;
                            dr["本期发出金额"] = je6;
                        }
                    }

                    dtt.Rows.Add(dr);
                    if (dtt.Rows.Count > 0)
                    {
                        for (int x = 0; x < dtt.Rows.Count; x++)
                        {
                            if (dtt.Rows[x]["上期初收入数量"] == DBNull.Value)
                                dtt.Rows[x]["上期初收入数量"] = 0;
                            int a = Convert.ToInt32(dtt.Rows[x]["上期初收入数量"]);

                            if (dtt.Rows[x]["上期初收入单价"] == DBNull.Value)
                                dtt.Rows[x]["上期初收入单价"] = 0;
                            decimal b = Convert.ToDecimal(dtt.Rows[x]["上期初收入单价"]);

                            if (dtt.Rows[x]["上期初收入金额"] == DBNull.Value)
                                dtt.Rows[x]["上期初收入金额"] = 0;
                            decimal c = Convert.ToDecimal(dtt.Rows[x]["上期初收入金额"]);

                            if (dtt.Rows[x]["上期初发出数量"] == DBNull.Value)
                                dtt.Rows[x]["上期初发出数量"] = 0;
                            int a1 = Convert.ToInt32(dtt.Rows[x]["上期初发出数量"]);

                            if (dtt.Rows[x]["上期初发出单价"] == DBNull.Value)
                                dtt.Rows[x]["上期初发出单价"] = 0;
                            decimal b1 = Convert.ToDecimal(dtt.Rows[x]["上期初发出单价"]);

                            if (dtt.Rows[x]["上期初发出金额"] == DBNull.Value)
                                dtt.Rows[x]["上期初发出金额"] = 0;
                            decimal c1 = Convert.ToDecimal(dtt.Rows[x]["上期初发出金额"]);

                            if (dtt.Rows[x]["上本期收入数量"] == DBNull.Value)
                                dtt.Rows[x]["上本期收入数量"] = 0;
                            decimal a2 = Convert.ToDecimal(dtt.Rows[x]["上本期收入数量"]);

                            if (dtt.Rows[x]["上本期收入单价"] == DBNull.Value)
                                dtt.Rows[x]["上本期收入单价"] = 0;
                            decimal b2 = Convert.ToDecimal(dtt.Rows[x]["上本期收入单价"]);

                            if (dtt.Rows[x]["上本期收入金额"] == DBNull.Value)
                                dtt.Rows[x]["上本期收入金额"] = 0;
                            decimal c2 = Convert.ToDecimal(dtt.Rows[x]["上本期收入金额"]);

                            if (dtt.Rows[x]["上本期发出数量"] == DBNull.Value)
                                dtt.Rows[x]["上本期发出数量"] = 0;
                            decimal a3 = Convert.ToDecimal(dtt.Rows[x]["上本期发出数量"]);

                            if (dtt.Rows[x]["上本期发出单价"] == DBNull.Value)
                                dtt.Rows[x]["上本期发出单价"] = 0;
                            decimal b3 = Convert.ToDecimal(dtt.Rows[x]["上本期发出单价"]);

                            if (dtt.Rows[x]["上本期发出金额"] == DBNull.Value)
                                dtt.Rows[x]["上本期发出金额"] = 0;
                            decimal c3 = Convert.ToDecimal(dtt.Rows[x]["上本期发出金额"]);

                            if (dtt.Rows[x]["本期收入数量"] == DBNull.Value)
                                dtt.Rows[x]["本期收入数量"] = 0;
                            decimal a4 = Convert.ToDecimal(dtt.Rows[x]["本期收入数量"]);

                            if (dtt.Rows[x]["本期收入单价"] == DBNull.Value)
                                dtt.Rows[x]["本期收入单价"] = 0;
                            decimal b4 = Convert.ToDecimal(dtt.Rows[x]["本期收入单价"]);

                            if (dtt.Rows[x]["本期收入金额"] == DBNull.Value)
                                dtt.Rows[x]["本期收入金额"] = 0;
                            decimal c4 = Convert.ToDecimal(dtt.Rows[x]["本期收入金额"]);

                            if (dtt.Rows[x]["本期发出数量"] == DBNull.Value)
                                dtt.Rows[x]["本期发出数量"] = 0;
                            decimal a5 = Convert.ToDecimal(dtt.Rows[x]["本期发出数量"]);

                            if (dtt.Rows[x]["本期发出单价"] == DBNull.Value)
                                dtt.Rows[x]["本期发出单价"] = 0;
                            decimal b5 = Convert.ToDecimal(dtt.Rows[x]["本期发出单价"]);

                            if (dtt.Rows[x]["本期发出金额"] == DBNull.Value)
                                dtt.Rows[x]["本期发出金额"] = 0;
                            decimal c5 = Convert.ToDecimal(dtt.Rows[x]["本期发出金额"]);

                            dtt.Rows[x]["上期初结存数量"] = a - a1;
                            dtt.Rows[x]["上期初结存单价"] = b - b1;
                            dtt.Rows[x]["上期初结存金额"] = c - c1;

                            decimal aaa = (a2 - a3) + (a - a1);
                            if (aaa < 0)
                            {
                                dtt.Rows[x]["期初结存数量"] = 0;
                            }
                            else
                            {
                                dtt.Rows[x]["期初结存数量"] = (a2 - a3) + (a - a1);
                            }
                            dtt.Rows[x]["期初结存单价"] = (b2 - b3) + (b - b1);
                            decimal ccc = (c2 - c3) + (c - c1);
                            if (ccc <= 0)
                            {
                                dtt.Rows[x]["期初结存金额"] = 0.00;
                            }
                            else
                            {
                                dtt.Rows[x]["期初结存金额"] = (c2 - c3) + (c - c1);
                            }

                            decimal aaaa = (a4 - a5) + (a2 - a3) + (a - a1);
                            if (aaaa < 0)
                            {
                                dtt.Rows[x]["期末结存数量"] = 0;
                            }
                            else
                            {
                                dtt.Rows[x]["期末结存数量"] = (a4 - a5) + (a2 - a3) + (a - a1);
                            }
                            dtt.Rows[x]["期末结存单价"] = (b4 - b5) + (b2 - b3) + (b - b1);
                            decimal cccc = (c4 - c5) + (c2 - c3) + (c - c1);
                            if (cccc <= 0)
                            {
                                dtt.Rows[x]["期末结存金额"] = 0.00;
                            }
                            else
                            {
                                dtt.Rows[x]["期末结存金额"] = (c4 - c5) + (c2 - c3) + (c - c1);
                            }
                        }
                    }
                }
                dataGridView1.DataSource = dtt;
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns["上期初结存数量"].Visible = false;
                    dataGridView1.Columns["上期初结存单价"].Visible = false;
                    dataGridView1.Columns["上期初结存金额"].Visible = false;

                    dataGridView1.Columns["上期初收入数量"].Visible = false;
                    dataGridView1.Columns["上期初收入单价"].Visible = false;
                    dataGridView1.Columns["上期初收入金额"].Visible = false;
                    dataGridView1.Columns["上期初发出数量"].Visible = false;
                    dataGridView1.Columns["上期初发出单价"].Visible = false;
                    dataGridView1.Columns["上期初发出金额"].Visible = false;

                    dataGridView1.Columns["上本期收入数量"].Visible = false;
                    dataGridView1.Columns["上本期收入单价"].Visible = false;
                    dataGridView1.Columns["上本期收入金额"].Visible = false;
                    dataGridView1.Columns["上本期发出数量"].Visible = false;
                    dataGridView1.Columns["上本期发出单价"].Visible = false;
                    dataGridView1.Columns["上本期发出金额"].Visible = false;

                    
                }

            }
        }

        private void cwsfc_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void cwsfc_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
