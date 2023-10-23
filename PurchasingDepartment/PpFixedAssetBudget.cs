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
using WindowsFormsApp1.FinanceDepartment;

namespace WindowsFormsApp1.PurchasingDepartment
{
    public partial class PpFixedAssetBudget : Form
    {
        public PpFixedAssetBudget()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        string rq;
        int Iid;
        int zt;
        DataTable dt;
        SqlDataAdapter da;
        private void PFixedAssetBudget_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void PFixedAssetBudget_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            string findSj = "select id,date as 时间,state as 状态 from CGBFixedAssetBudget";
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
                string bm = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string xm = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string yt = dataGridView1.Rows[i].Cells[2].Value.ToString();
                decimal dj = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                int sl = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                if (rq == date && zt == 1)
                {
                    DialogResult res = MessageBox.Show("该月已经录入过数据,是否修改数据", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        PpUpdateFixedAssetBudget updateCGXBBudget = new PpUpdateFixedAssetBudget();
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
                    cmd.CommandText = "INSERT INTO [dbo].[CGBFixedAssetBudget]([apartment], [name], [purpose], [price], [number], [date],state) VALUES ('" + bm + "', '" + xm + "', '" + yt + "', '" + dj + "', '" + sl + "', '" + date + "',1)";
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
