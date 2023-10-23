using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.PurchasingDepartment;

namespace WindowsFormsApp1.Produce
{
    public partial class ProductionBudget : Form
    {
        public ProductionBudget()
        {
            InitializeComponent();
        }
        int a = 0;
        int b = 0;
        int Iid;
        int zt;
        string rq;
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public string Username { get; set; }
        public string Group { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == ""){
                MessageBox.Show("请输入白班几条线");
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入白班前工段工时");
            }
            if (textBox3.Text.Trim() == "")
            {
                MessageBox.Show("请输入白班前工段计件人数");
            }
            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("请输入白班后工段计件人数");
            }
            if (textBox5.Text.Trim() == "")
            {
                MessageBox.Show("请输入白班喷粉工时");
            }
            if (textBox6.Text.Trim() == "")
            {
                MessageBox.Show("请输入白班前工段人数");
            }
            if (textBox7.Text.Trim() == "")
            {
                MessageBox.Show("请输入白班后工段人数");
            }
            if (textBox8.Text.Trim() == "")
            {
                MessageBox.Show("请输入白班总人数");
            }
            if (textBox9.Text.Trim() == "")
            {
                MessageBox.Show("请输入夜班几条线");
            }
            if (textBox10.Text.Trim() == "")
            {
                MessageBox.Show("请输入夜班前工段工时");
            }
            if (textBox11.Text.Trim() == "")
            {
                MessageBox.Show("请输入夜班前工段计件人数");
            }
            if (textBox12.Text.Trim() == "")
            {
                MessageBox.Show("请输入夜班后工段计件人数");
            }
            if (textBox13.Text.Trim() == "")
            {
                MessageBox.Show("请输入夜班喷粉工时");
            }
            if (textBox14.Text.Trim() == "")
            {
                MessageBox.Show("请输入夜班前工段人数");
            }
            if (textBox15.Text.Trim() == "")
            {
                MessageBox.Show("请输入夜班后工段人数");
            }
            if (textBox16.Text.Trim() == "")
            {
                MessageBox.Show("请输入夜班总人数");
            }
            if (textBox17.Text.Trim() == "")
            {
                MessageBox.Show("请输入日入库目标");
            }
            if (textBox18.Text.Trim() == "")
            {
                MessageBox.Show("请输入日入库产值目标");
            }
            if (textBox20.Text.Trim() == "")
            {
                MessageBox.Show("请输入型材");
            }
            if (textBox21.Text.Trim() == "")
            {
                MessageBox.Show("请输入配件");
            }
            if (textBox22.Text.Trim() == "")
            {
                MessageBox.Show("请输入塑粉");
            }
            if (textBox24.Text.Trim() == "")
            {
                MessageBox.Show("请输入包装");
            }
            if (textBox25.Text.Trim() == "")
            {
                MessageBox.Show("请输入消耗品、低耗");
            }
            if (textBox26.Text.Trim() == "")
            {
                MessageBox.Show("请输入基本工资");
            }
            if (textBox27.Text.Trim() == "")
            {
                MessageBox.Show("请输入加班工资");
            }
            if (textBox28.Text.Trim() == "")
            {
                MessageBox.Show("请输入夜班补贴");
            }
            if (textBox29.Text.Trim() == "")
            {
                MessageBox.Show("请输入计件工资");
            }
            if (textBox30.Text.Trim() == "")
            {
                MessageBox.Show("请输入福利-餐费");
            }
            if (textBox31.Text.Trim() == "")
            {
                MessageBox.Show("请输入水电费");
            }
            if (textBox32.Text.Trim() == "")
            {
                MessageBox.Show("请输入天然气");
            }
            if (textBox33.Text.Trim() == "")
            {
                MessageBox.Show("请输入CO2");
            }
            int RJTX = Convert.ToInt32(textBox1.Text.Trim());
            decimal RQGDGS = Convert.ToDecimal(textBox2.Text.Trim());//前工段工时
            int RQGDJJRS = Convert.ToInt32(textBox3.Text.Trim());//前工段计件人数
            int RHGDJJRS = Convert.ToInt32(textBox4.Text.Trim());//后工段计件人数
            decimal RPFGS = Convert.ToDecimal(textBox5.Text.Trim());//喷粉工时
            int RQGDRS = Convert.ToInt32(textBox6.Text.Trim());//前工段人数
            int RHGDRS = Convert.ToInt32(textBox7.Text.Trim());//后工段人数
            int RZRS = Convert.ToInt32(textBox8.Text.Trim());//总人数

            int YJTX = Convert.ToInt32(textBox9.Text.Trim());
            decimal YQGDGS = Convert.ToDecimal(textBox10.Text.Trim());//前工段工时
            int YQGDJJRS = Convert.ToInt32(textBox11.Text.Trim());//前工段计件人数
            int YHGDJJRS = Convert.ToInt32(textBox12.Text.Trim());//后工段计件人数
            decimal YPFGS = Convert.ToDecimal(textBox13.Text.Trim());//喷粉工时
            int YQGDRS = Convert.ToInt32(textBox14.Text.Trim());//前工段人数
            int YHGDRS = Convert.ToInt32(textBox15.Text.Trim());//后工段人数
            int YZRS = Convert.ToInt32(textBox16.Text.Trim());//总人数
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            string findSj = "select id,date as 时间 ,state as 状态 from ProductionWorkshopBudget";
            da = new SqlDataAdapter(findSj, SQL);
            dt = new DataTable();
            da.Fill(dt);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                Iid = Convert.ToInt32(dt.Rows[j]["id"]);
                rq = dt.Rows[j]["时间"].ToString();
                zt = Convert.ToInt32(dt.Rows[j]["状态"]);
            }
                decimal RKMB = Convert.ToDecimal(textBox17.Text.Trim());
                decimal RKCZMB = Convert.ToDecimal(textBox18.Text.Trim());
                //int ZLCB = Convert.ToInt32(textBox19.Text.Trim());//主料成本
                int XC = Convert.ToInt32(textBox20.Text.Trim());;
                int PJ = Convert.ToInt32(textBox21.Text.Trim());
                int SF = Convert.ToInt32(textBox22.Text.Trim());
                //int FLCB = Convert.ToInt32(textBox23.Text.Trim());//辅料成本
                int BZ = Convert.ToInt32(textBox24.Text.Trim());
                int XHP = Convert.ToInt32(textBox25.Text.Trim());
                decimal JBGZ = Convert.ToDecimal(textBox26.Text.Trim());
                decimal JBGZz = Convert.ToDecimal(textBox27.Text.Trim());
                decimal YBBT = Convert.ToDecimal(textBox28.Text.Trim());
                decimal JJGZ = Convert.ToDecimal(textBox29.Text.Trim());
                decimal FL = Convert.ToDecimal(textBox30.Text.Trim());
                decimal SDF = Convert.ToDecimal(textBox31.Text.Trim());
                decimal TRQ = Convert.ToDecimal(textBox32.Text.Trim());
                decimal CO2 = Convert.ToDecimal(textBox33.Text.Trim());
                if (rq == date && zt == 1)
                {
                    DialogResult res = MessageBox.Show("今天已经录入过数据,是否修改数据", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        ProductionUpdateBudget updateCGXBBudget = new ProductionUpdateBudget();
                        updateCGXBBudget.ShowDialog();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    a = XC + PJ + SF;
                    b = BZ+XHP;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO [dbo].[ProductionWorkshopBudget] ([dayLineNumber],[dayDusting],[dayBeforeWorkshopSection],[dayBeforeWorkshopSectionNumber],[dayBeforePieceCount],[dayAfterWorkshopSectionNumber],[dayAfterPieceCount],[dayTotalNumber],[nightLineNumber],[nightDusting],[nightBeforeWorkshopSection],[nightBeforeWorkshopSectionNumber],[nightBeforePieceCount],[nightAfterWorkshopSectionNumber],[nightAfterPieceCount],[nightTotalNumber],[aDayWarehousingTarget],[aDayOutputValueWarehousingTarget],[mainMaterialCostProfile],[profiles],[accessory],[plasticPowder],[accessories],[package],[consumables],[baseWages],[workOvertimeWages],[nightShiftWages],[pieceRate],[welfareMealExpenses],[waterAndElectricityExpenses],[naturalGas],[CO2],[date],[state] ) VALUES ('" + RJTX + "', '" + RPFGS + "', '" + RQGDGS + "','" + RQGDRS + "', '" + RQGDJJRS + "', '" + RHGDRS + "', '" + RHGDJJRS + "','" + RZRS + "','" + YJTX + "', '" + YPFGS + "', '" + YQGDGS + "','" + YQGDRS + "', '" + YQGDJJRS + "', '" + YHGDRS + "', '" + YHGDJJRS + "', '" + YZRS + "', '" + RKMB + "', '" + RKCZMB + "','"+ a + "','"+ XC + "','"+ PJ + "','"+ SF + "','"+ b + "','"+ BZ + "','"+ XHP + "','"+ JBGZ + "','"+ JBGZz + "','"+ YBBT + "','"+ JJGZ + "','"+ FL + "','"+ SDF + "','"+ TRQ + "','"+ CO2 + "','" + date + "','1')";
                    int cot = cmd.ExecuteNonQuery();
                    if (cot < 1)
                    {
                        MessageBox.Show("保存失败！");
                    }
                    else
                    {
                        MessageBox.Show("保存成功！");
                    }
                }
            
            con.Close();
        }

        private void ProductionBudget_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void ProductionBudget_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
