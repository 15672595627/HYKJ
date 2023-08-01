using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Purchase
{
    // Token: 0x02000016 RID: 22
    public partial class PurchaseSQ : Form
    {
        // Token: 0x06000114 RID: 276 RVA: 0x000153F1 File Offset: 0x000135F1
        public PurchaseSQ()
        {
            this.InitializeComponent();
        }

        private SqlDataAdapter da;
        private DataTable dt;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private string rq;
        public string User { get; set; }
        public string Group { get; set; }
        private void PurchaseSQ_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
            this.rq = DateTime.Now.ToString("yyyy-MM-dd");
            string str = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.txtDdbh.Text = "CGSQD" + str;
        }

        private void PurchaseSQ_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.txtHtbh.Text.Trim();
            string text2 = this.txtKh.Text.Trim();
            string text3 = this.txtXm.Text.Trim();
            string text4 = this.txtDdbh.Text.Trim();
            string selectCommandText = string.Concat(new string[]
            {
                "select id,contactId as 合同编号,company as 客户, project as 项目,materialsId as 物料代码, materialsName as 物料名称, specification as 规格型号,unitNumber as 库存数量,purchaseNumber as 采购数量,unit as 单位,stockName as 仓库名称 ,kuwei as 库位,weight as 重量,weightUnit as 重量单位,remark as 备注 from purchaseRequest where contactId like '%",
                text,
                "%' and company like '%",
                text2,
                "%' and project like '%",
                text3,
                "%' and state = 'N'"
            });
            this.da = new SqlDataAdapter(selectCommandText, PurchaseSQ.SQL);
            this.dt = new DataTable();
            this.da.Fill(this.dt);
            this.dataGridView1.DataSource = this.dt;
            this.dataGridView1.Columns["id"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(PurchaseSQ.SQL);
            int num = 0;
            sqlConnection.Open();
            foreach (object obj in ((IEnumerable)this.dataGridView1.Rows))
            {
                DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
                string text = this.dt1.Text.Trim();
                string cmdText = string.Concat(new string[]
                {
                    "update purchaseRequest set applicant = '",
                    this.User,
                    "' , date = '",
                    this.rq,
                    "',ddId = '",
                    this.txtDdbh.Text,
                    "',date2 = '",
                    text,
                    "',state = 'Y'"
                });
                SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                num = sqlCommand.ExecuteNonQuery();
            }
            bool flag = num <= 0;
            if (flag)
            {
                MessageBox.Show("保存失败！");
            }
            else
            {
                MessageBox.Show("保存成功！");
            }
            try
            {
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(this.da);
                this.da.Update(this.dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.button1.PerformClick();
        }

    }
}
