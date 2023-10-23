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
using WindowsFormsApp1.EngineeringDepartment;

namespace WindowsFormsApp1.FinanceDepartment
{
    public partial class CWBBudget : Form
    {
        public CWBBudget()
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
        private void CWBBudget_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void CWBBudget_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            string findSj = "select id,date as 时间 ,state as 状态 from CWBcgxys";
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
                int ygrs = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                decimal zyrj = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value);
                decimal qdmb = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                decimal xdmb = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                decimal chmb = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                decimal hkmb = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                decimal dj = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                decimal bych = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                decimal sqqqk = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                decimal tgzk = Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                if (rq == date && zt == 1)
                {
                    DialogResult res = MessageBox.Show("该月已经录入过数据,是否修改数据", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        CWBUpdateBudget updateCGXBBudget = new CWBUpdateBudget();
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
                    cmd.CommandText = "INSERT INTO [dbo].[CWBcgxys]([employee], [monthlySigningAmountPerEmployee], [signingTarget], [OrderTarget],[shippingTarget], [paymentTarget], [deposit ], [currentMonthShipmentReceipt], [collectionEarlyArrears], [refundAccounts],[date],[state]) VALUES ('" + ygrs + "', '" + zyrj + "', '" + qdmb + "','" + xdmb + "', '" + chmb + "', '" + hkmb + "', '" + dj + "', '" + bych + "', '" + sqqqk + "', '" + tgzk + "','" + date + "',1)";
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
