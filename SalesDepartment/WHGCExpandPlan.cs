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

namespace WindowsFormsApp1.SalesDepartment
{
    public partial class WHGCExpandPlan : Form
    {
        public WHGCExpandPlan()
        {
            InitializeComponent();
        }
        public string UserName { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        string rq;
        int Iid;
        int zt;
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void WHGCExpandPlan_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void WHGCExpandPlan_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            string findSj = "select id, date as 时间 ,state as 状态 from SalesExpandPlan where state = 1 and company = '武汉工程'";
            da = new SqlDataAdapter(findSj, SQL);
            dt = new DataTable();
            da.Fill(dt);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                Iid = Convert.ToInt32(dt.Rows[j]["id"]);
                zt = Convert.ToInt32(dt.Rows[j]["状态"]);
                rq = dt.Rows[j]["时间"].ToString();
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                string date = DateTime.Now.ToString("yyyy-MM");
                string qy = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string sf = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string s = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string qx = dataGridView1.Rows[i].Cells[3].Value.ToString();
                int rs = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                string yf = dataGridView1.Rows[i].Cells[5].Value.ToString();
                int qd = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                int ch = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                string bz = dataGridView1.Rows[i].Cells[8].Value.ToString();
                if (rq == date && zt == 1)
                {
                    DialogResult res = MessageBox.Show("该月已经录入过数据,是否修改数据", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        WHGCUpdateExpandPlan updateCGXBBudget = new WHGCUpdateExpandPlan();
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
                    cmd.CommandText = "INSERT INTO [dbo].[SalesExpandPlan]([region], [province], [market], [county], [number], [yuefen], [target1], [target2], [remark], [date], [state],[company]) VALUES ('" + qy + "', '" + sf + "', '" + s + "', '" + qx + "', '" + rs + "','" + yf + "','" + qd + "','" + ch + "','" + bz + "','" + date + "','1','武汉工程')";
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
