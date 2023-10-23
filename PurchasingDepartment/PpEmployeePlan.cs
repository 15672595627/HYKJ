using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.FinanceDepartment;
using WindowsFormsApp1.PersonnelDepartment;

namespace WindowsFormsApp1.PurchasingDepartment
{
    public partial class PpEmployeePlan : Form
    {
        public PpEmployeePlan()
        {
            InitializeComponent();
        }
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public string Username { get; set; }
        public string Group { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            PpAddEmployee pAddEmployee = new PpAddEmployee();
            pAddEmployee.Username = Username;
            pAddEmployee.Group = Group;
            pAddEmployee.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PReduceEmployee pReduceEmployee = new PReduceEmployee();
            pReduceEmployee.Username = Username;
            pReduceEmployee.Group = Group;
            pReduceEmployee.ShowDialog();
        }
    }
}
