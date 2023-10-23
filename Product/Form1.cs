using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Product
{
    public partial class Form1 : Form
    {
        public Form1()
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
        decimal sl1;
        decimal je1;
        decimal sl2;
        decimal je2;
        decimal sl3;
        decimal je3;
        decimal sl4;
        decimal je4;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button1_Click(object sender, EventArgs e)
        {
            //拿到datatimepiker控件的值
            string yue = dateTimePicker1.Text.Trim();


            //得到上个月最后一天
            string tian = Convert.ToDateTime(yue).AddMonths(0).AddDays(-1).ToString("yyyy-MM-dd");
            Console.WriteLine(yue);
            Console.WriteLine(tian);
            dataGridView1.Columns.Clear();

            //即时库存
            string ss = "select contractid as 合同编号,product as 产品名称,sub as 内容 ,num as 数量,warehouse as 仓库 from Stock ";
            da = new SqlDataAdapter(ss, SQL);
            dt = new DataTable();
            da.Fill(dt);

            //期初入库
            string str = "select contractid as 合同编号,company as 公司名,project as 项目 ,product as 产品名称 ,substance as 内容 ,sum(sl) as 数量,sum(kfje) as 金额 from ProductIn where caiwuRiqi like '%" + tian + "%' group by contractid,company,project,product,substance";
            da1 = new SqlDataAdapter(str, SQL);
            dt1 = new DataTable();
            da1.Fill(dt1);

            //期初出库
            string str1 = "select contractid as 合同编号,company as 公司名,project as 项目 ,product as 产品名称 ,substance as 内容 ,sum(sl) as 数量,sum(kfje) as 金额 from ProductOut where caiwuRiqi like '%" + tian + "%' group by contractid,company,project,product,substance";
            da2 = new SqlDataAdapter(str1, SQL);
            dt2 = new DataTable();
            da2.Fill(dt2);

            //本期收入
            string str2 = "select contractid as 合同编号,company as 公司名,project as 项目 ,product as 产品名称 ,substance as 内容 ,sum(sl) as 数量,sum(kfje) as 金额 from ProductIn where caiwuRiqi like '%" + yue + "%' group by contractid,company,project,product,substance";
            da3 = new SqlDataAdapter(str2, SQL);
            dt3 = new DataTable();
            da3.Fill(dt3);

            //本期发出
            string str3 = "select contractid as 合同编号,company as 公司名,project as 项目 ,product as 产品名称 ,substance as 内容 ,sum(sl) as 数量,sum(kfje) as 金额 from ProductOut where caiwuRiqi like '%" + yue + "%' group by contractid,company,project,product,substance";
            da4 = new SqlDataAdapter(str3, SQL);
            dt4 = new DataTable();
            da4.Fill(dt4);

            //添加列名称
            DataTable dtt = new DataTable();
            dtt.Columns.Add("时间", typeof(string));
            dtt.Columns.Add("合同编号", typeof(string));
            dtt.Columns.Add("产品名称", typeof(string));
            dtt.Columns.Add("内容", typeof(string));

            dtt.Columns.Add("期初收入数量", typeof(int));
            dtt.Columns.Add("期初收入单价", typeof(decimal));
            dtt.Columns.Add("期初收入金额", typeof(decimal));

            dtt.Columns.Add("期初发出数量", typeof(int));
            dtt.Columns.Add("期初发出单价", typeof(decimal));
            dtt.Columns.Add("期初发出金额", typeof(decimal));

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
                //期初入
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    htbh1 = dt1.Rows[j]["合同编号"].ToString();
                    cpmc1 = dt1.Rows[j]["产品名称"].ToString();
                    nr1 = dt1.Rows[j]["内容"].ToString();
                    if (htbh == htbh1 || cpmc == cpmc1 || nr == nr1)
                    {
                        sl1 = Convert.ToInt32(dt1.Rows[j]["数量"]);
                        je1 = Convert.ToDecimal(dt1.Rows[j]["金额"]);
                        dr["期初收入数量"] = sl1;
                        //dr["期初收入单价"] = djR;
                        dr["期初收入金额"] = je1;
                    }
                }
                //期初出  
                if(dt1.Rows.Count>0)
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
                            dr["期初发出数量"] = sl2;
                            //dr["期初发出单价"] = djC;
                            dr["期初发出金额"] = je2;
                        }
                    }
                }
                
                //本期收入
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
                            dr["本期收入数量"] = sl3;
                            //dr["本期收入单价"] = dj1;
                            dr["本期收入金额"] = je3;
                        }
                    }
                }

                //本期发出
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
                        dr["本期发出数量"] = sl4;
                        //dr["本期发出单价"] = dj2;
                        dr["本期发出金额"] = je4;
                    }
                }

                dtt.Rows.Add(dr);
                if (dtt.Rows.Count > 0)
                {
                    for (int x = 0; x < dtt.Rows.Count; x++)
                    {
                        if (dtt.Rows[x]["期初收入数量"] == DBNull.Value)
                            dtt.Rows[x]["期初收入数量"] = 0;
                        int a = Convert.ToInt32(dtt.Rows[x]["期初收入数量"]);

                        if (dtt.Rows[x]["期初收入单价"] == DBNull.Value)
                            dtt.Rows[x]["期初收入单价"] = 0;
                        decimal b = Convert.ToDecimal(dtt.Rows[x]["期初收入单价"]);

                        if (dtt.Rows[x]["期初收入金额"] == DBNull.Value)
                            dtt.Rows[x]["期初收入金额"] = 0;
                        decimal c = Convert.ToDecimal(dtt.Rows[x]["期初收入金额"]);

                        if (dtt.Rows[x]["期初发出数量"] == DBNull.Value)
                            dtt.Rows[x]["期初发出数量"] = 0;
                        int a1 = Convert.ToInt32(dtt.Rows[x]["期初发出数量"]);

                        if (dtt.Rows[x]["期初发出单价"] == DBNull.Value)
                            dtt.Rows[x]["期初发出单价"] = 0;
                        decimal b1 = Convert.ToDecimal(dtt.Rows[x]["期初发出单价"]);

                        if (dtt.Rows[x]["期初发出金额"] == DBNull.Value)
                            dtt.Rows[x]["期初发出金额"] = 0;
                        decimal c1 = Convert.ToDecimal(dtt.Rows[x]["期初发出金额"]);

                        if (dtt.Rows[x]["本期收入数量"] == DBNull.Value)
                            dtt.Rows[x]["本期收入数量"] = 0;
                        decimal a2 = Convert.ToDecimal(dtt.Rows[x]["本期收入数量"]);

                        if (dtt.Rows[x]["本期收入单价"] == DBNull.Value)
                            dtt.Rows[x]["本期收入单价"] = 0;
                        decimal b2 = Convert.ToDecimal(dtt.Rows[x]["本期收入单价"]);

                        if (dtt.Rows[x]["本期收入金额"] == DBNull.Value)
                            dtt.Rows[x]["本期收入金额"] = 0;
                        decimal c2 = Convert.ToDecimal(dtt.Rows[x]["本期收入金额"]);

                        if (dtt.Rows[x]["本期发出数量"] == DBNull.Value)
                            dtt.Rows[x]["本期发出数量"] = 0;
                        decimal a3 = Convert.ToDecimal(dtt.Rows[x]["本期发出数量"]);

                        if (dtt.Rows[x]["本期发出单价"] == DBNull.Value)
                            dtt.Rows[x]["本期发出单价"] = 0;
                        decimal b3 = Convert.ToDecimal(dtt.Rows[x]["本期发出单价"]);

                        if (dtt.Rows[x]["本期发出金额"] == DBNull.Value)
                            dtt.Rows[x]["本期发出金额"] = 0;
                        decimal c3 = Convert.ToDecimal(dtt.Rows[x]["本期发出金额"]);

                        dtt.Rows[x]["期初结存数量"] = a - a1;
                        dtt.Rows[x]["期初结存单价"] = b - b1;
                        dtt.Rows[x]["期初结存金额"] = c - c1;

                        decimal aaa = (a2 - a3) + (a - a1);
                        if (aaa < 0)
                        {
                            dtt.Rows[x]["期末结存数量"] = 0;
                        }
                        else
                        {
                            dtt.Rows[x]["期末结存数量"] = (a2 - a3) + (a - a1);
                        }
                        dtt.Rows[x]["期末结存单价"] = (b2 - b3) + (b - b1);
                        decimal ccc = (c2 - c3) + (c - c1);
                        if (ccc <= 0)
                        {
                            dtt.Rows[x]["期末结存金额"] = 0.00;
                        }
                        else
                        {
                            dtt.Rows[x]["期末结存金额"] = (c2 - c3) + (c - c1);
                        }
                    }
                }
            }
            dataGridView1.DataSource = dtt;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["期初收入数量"].Visible = false;
                dataGridView1.Columns["期初收入单价"].Visible = false;
                dataGridView1.Columns["期初收入金额"].Visible = false;
                dataGridView1.Columns["期初发出数量"].Visible = false;
                dataGridView1.Columns["期初发出单价"].Visible = false;
                dataGridView1.Columns["期初发出金额"].Visible = false;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
