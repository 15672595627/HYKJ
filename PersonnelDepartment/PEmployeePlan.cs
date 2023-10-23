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
    public partial class PEmployeePlan : Form
    {
        public PEmployeePlan()
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
        private void button1_Click(object sender, EventArgs e)
        {
            PAddEmployee pAdd = new PAddEmployee();
            pAdd.Username= Username;    
            pAdd.Group= Group;
            pAdd.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PReduceEmployee pReduce = new PReduceEmployee();
            pReduce.Username= Username;
            pReduce.Group= Group;
            pReduce.ShowDialog();
        }

        private void PEmployeePlan_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void PEmployeePlan_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
