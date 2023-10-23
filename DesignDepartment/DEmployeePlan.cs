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
    public partial class DEmployeePlan : Form
    {
        public DEmployeePlan()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da = null;
        private DataTable dt = null;
        int cot = 0;
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private void button1_Click(object sender, EventArgs e)
        {
            DAddEmployee cAdd = new DAddEmployee();
            cAdd.Username = Username;
            cAdd.Group = Group;
            cAdd.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DReduceEmployee cAdd = new DReduceEmployee();
            cAdd.Username = Username;
            cAdd.Group = Group;
            cAdd.ShowDialog();
        }
    }
}
