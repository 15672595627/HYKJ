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

namespace WindowsFormsApp1.Desgin
{
    public partial class GroupList : Form
    {
        public GroupList()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da;
        private DataTable dt;
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        public static string[] a;

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string text = this.txtContaxctId.Text.Trim();
            string text2 = this.txtName.Text.Trim();
            string text3 = this.KSRQ.Text.Trim();
            string text4 = this.JSRQ.Text.Trim();
            string selectCommandText = string.Format(string.Concat(new string[]
            {
                "SELECT contractid AS 合同编号,company AS 客户名称 ,[date] as 日期 FROM [dbo].[DesginBom] where [date] between '",
                text3,
                "'and '",
                text4,
                "' and contractid like '%",
                text,
                "%' and company like '%",
                text2,
                "%' GROUP BY contractid,company ,[date]"
            }), Array.Empty<object>());
            this.da = new SqlDataAdapter(selectCommandText, GroupList.SQL);
            this.dt = new DataTable();
            this.da.Fill(this.dt);
            this.dataGridView1.DataSource = this.dt;
        }

        private void GroupList_Load(object sender, EventArgs e)
        {
            this.asc.controllInitializeSize(this);
        }

        private void GroupList_SizeChanged(object sender, EventArgs e)
        {
            this.asc.controlAutoSize(this);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GroupListDetial groupListDetial = new GroupListDetial();
            string cId = this.dataGridView1.CurrentRow.Cells["合同编号"].Value.ToString();
            groupListDetial.cId = cId;
            groupListDetial.Show();
        }
    }
}
