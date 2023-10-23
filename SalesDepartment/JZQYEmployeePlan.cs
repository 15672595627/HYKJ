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
using WindowsFormsApp1.MarketingDepartment;

namespace WindowsFormsApp1.SalesDepartment
{
    public partial class JZQYEmployeePlan : Form
    {
        public JZQYEmployeePlan()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void JZQYEmployeePlan_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void JZQYEmployeePlan_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JZQYAddEmployee jZQYAddEmployee = new JZQYAddEmployee();
            jZQYAddEmployee.Username = Username;
            jZQYAddEmployee.Group = Group;
            jZQYAddEmployee.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JZQYReduceEmployee jZQYReduceEmployee = new JZQYReduceEmployee();
            jZQYReduceEmployee.Username = Username;
            jZQYReduceEmployee.Group = Group;
            jZQYReduceEmployee.ShowDialog();
        }
    }
}
