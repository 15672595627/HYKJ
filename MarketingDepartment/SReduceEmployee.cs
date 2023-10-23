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
using WindowsFormsApp1.GeneralManager;

namespace WindowsFormsApp1.MarketingDepartment
{
    public partial class SReduceEmployee : Form
    {
        public SReduceEmployee()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        string rq;
        int Iid;
        int zt;
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void SReduceEmployee_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void SReduceEmployee_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
