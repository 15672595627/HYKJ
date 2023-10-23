using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.SalesDepartment
{
    public partial class WHGCEmployeePlan : Form
    {
        public WHGCEmployeePlan()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void WHGCEmployeePlan_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void WHGCEmployeePlan_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WHGCAddEmployee jZQYAddEmployee = new WHGCAddEmployee();
            jZQYAddEmployee.Username = Username;
            jZQYAddEmployee.Group = Group;
            jZQYAddEmployee.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WHGCReduceEmployee jZQYReduceEmployee = new WHGCReduceEmployee();
            jZQYReduceEmployee.Username = Username;
            jZQYReduceEmployee.Group = Group;
            jZQYReduceEmployee.ShowDialog();
        }
    }
}
