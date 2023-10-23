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
using WindowsFormsApp1.CustomerServiceDepartment;

namespace WindowsFormsApp1.DesignDepartment
{
    public partial class DSummaryBudget : Form
    {
        public DSummaryBudget()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        int Iid;
        int zt;
        string rq;
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void DSummaryBudget_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void DSummaryBudget_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            string findSj = "select id ,date as 时间 ,state as 状态 from SJBBudget";
            da = new SqlDataAdapter(findSj, SQL);
            dt = new DataTable();
            da.Fill(dt);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                Iid = Convert.ToInt32(dt.Rows[j]["id"]);
                rq = dt.Rows[j]["时间"].ToString();
                zt = Convert.ToInt32(dt.Rows[j]["状态"]);
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string date = DateTime.Now.ToString("yyyy-MM");
                //Console.WriteLine(date);
                decimal gz = Convert.ToDecimal(dataGridView1.Rows[i].Cells[0].Value);
                decimal jt = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value);
                decimal sb = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                decimal gjj = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                decimal hsf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                decimal flf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                decimal sybx = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                decimal jyjj = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                decimal hjwjg = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                decimal jgf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                decimal bgf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
                decimal txf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[11].Value);
                decimal clf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[12].Value);
                decimal qckz = Convert.ToDecimal(dataGridView1.Rows[i].Cells[13].Value);
                decimal dzyhp = Convert.ToDecimal(dataGridView1.Rows[i].Cells[14].Value);
                decimal sdf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[15].Value);
                decimal rqf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[16].Value);
                decimal yf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[17].Value);
                decimal tgf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[18].Value);
                decimal ywf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[19].Value);
                decimal zdf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[20].Value);
                decimal fz = Convert.ToDecimal(dataGridView1.Rows[i].Cells[21].Value);
                decimal wxf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[22].Value);
                decimal gdkz = Convert.ToDecimal(dataGridView1.Rows[i].Cells[23].Value);
                decimal yp = Convert.ToDecimal(dataGridView1.Rows[i].Cells[24].Value);
                decimal bd = Convert.ToDecimal(dataGridView1.Rows[i].Cells[25].Value);
                decimal zpf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[26].Value);
                decimal lxzc = Convert.ToDecimal(dataGridView1.Rows[i].Cells[27].Value);
                decimal sxf = Convert.ToDecimal(dataGridView1.Rows[i].Cells[28].Value);
                decimal sj = Convert.ToDecimal(dataGridView1.Rows[i].Cells[29].Value);
                decimal qt = Convert.ToDecimal(dataGridView1.Rows[i].Cells[30].Value);

                if (rq == date && zt == 1)
                {
                    DialogResult res = MessageBox.Show("该月已经录入过数据,是否修改数据", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        DUpdateSummaryBudget updateCGXBBudget = new DUpdateSummaryBudget();
                        //updateCGXBBudget.id = Iid.ToString();
                        updateCGXBBudget.ShowDialog();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO [dbo].[SJBBudget]( [wages], [awardRaising], [socialSecurity], [accumulationFund], [boardExpenses ], [benefit], [commercialInsurance], [educationFund], [weldingExternalProcessing], [processingFee], [officeExpenses], [communicationFee], [travelExpenses], [automobileExpenses], [lowValueConsumables], [waterAndElectricityExpenses], [gasCost], [freight], [PromotionFee], [costOfOperation], [entertainmentExpenses], [rent], [maintenanceCost], [constructionSiteExpenses], [sample], [supplementaryOrde], [recruitmentFees], [interestExpense], [commission], [taxes], [other],[date],[state]) VALUES ('" + gz + "', '" + jt + "', '" + sb + "', '" + gjj + "', '" + hsf + "', '" + flf + "', '" + sybx + "', '" + jyjj + "', '" + hjwjg + "', '" + jgf + "', '" + bgf + "', '" + txf + "', '" + clf + "', '" + qckz + "', '" + dzyhp + "', '" + sdf + "', '" + rqf + "', '" + yf + "', '" + tgf + "', '" + ywf + "', '" + zdf + "', '" + fz + "', '" + wxf + "', '" + gdkz + "', '" + yp + "', '" + bd + "', '" + zpf + "', '" + lxzc + "', '" + sxf + "', '" + sj + "', '" + qt + "','" + date + "',1)";
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
            }
            con.Close();
        }
    }
}
