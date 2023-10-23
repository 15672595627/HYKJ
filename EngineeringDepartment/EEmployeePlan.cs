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

namespace WindowsFormsApp1.EngineeringDepartment
{
    public partial class EEmployeePlan : Form
    {
        public EEmployeePlan()
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
            EAddEmployee eAddEmployee = new EAddEmployee();
            eAddEmployee.Username = Username;
            eAddEmployee.Group = Group;
            eAddEmployee.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EReduecEmployee eReduecEmployee = new EReduecEmployee();
            eReduecEmployee.Username = Username;
            eReduecEmployee.Group = Group;
            eReduecEmployee.ShowDialog();
        }

        private void EEmployeePlan_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void EEmployeePlan_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }
    }
}
