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

namespace WindowsFormsApp1.PersonnelDepartment
{
    public partial class PSalaryDetails : Form
    {
        public PSalaryDetails()
        {
            InitializeComponent();
        }
        int Iid;
        int zt;
        string rq;
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public string Username { get; set; }
        public string Group { get; set; }

        private void PSalaryDetails_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void PSalaryDetails_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SQL);
            con.Open();
            string findSj = "select id ,date as 时间 ,state as 状态 from RSBSalaryDetails";
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
                string bm = dataGridView1.Rows[i].Cells[0].Value.ToString();
                decimal zrs = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value);
                decimal zje = Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                decimal yy = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                decimal ey = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                decimal sy = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                decimal siy = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                decimal wy = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                decimal ly = Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                decimal qy = Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                decimal by = Convert.ToDecimal(dataGridView1.Rows[i].Cells[10].Value);
                decimal jy = Convert.ToDecimal(dataGridView1.Rows[i].Cells[11].Value);
                decimal shiy = Convert.ToDecimal(dataGridView1.Rows[i].Cells[12].Value);
                decimal syy = Convert.ToDecimal(dataGridView1.Rows[i].Cells[13].Value);
                decimal sey = Convert.ToDecimal(dataGridView1.Rows[i].Cells[14].Value);
                if (rq == date && zt == 1)
                {
                    DialogResult res = MessageBox.Show("该月已经录入过数据,是否修改数据", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        PUpdateSalaryDetails updateCGXBBudget = new PUpdateSalaryDetails();
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
                    cmd.CommandText = "INSERT INTO [dbo].[RSBSalaryDetails]([DepartMent], [Number], [Amount], [January], [February], [March], [April], [May], [June], [July], [August], [September], [October], [November], [December], [date], [state]) VALUES ('"+bm+"', '"+zrs+"', '"+zje+"', '"+yy+"', '"+ey+"', '"+sy+"', '"+siy+"', '"+wy+"', '"+ly+"', '"+qy+"', '"+by+"', '"+jy+"', '"+shiy+"', '"+syy+"', '"+sey+"', '"+date+"', 1)";
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
