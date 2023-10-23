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

namespace WindowsFormsApp1.CustomerServiceDepartment
{
    public partial class CEmployeePlan : Form
    {
        public CEmployeePlan()
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
            CAddEmployee cAdd = new CAddEmployee();
            cAdd.Username= Username;
            cAdd.Group= Group;
            cAdd.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CReduceEmployee cAdd = new CReduceEmployee();
            cAdd.Username = Username;
            cAdd.Group = Group;
            cAdd.ShowDialog();
        }
    }
}
