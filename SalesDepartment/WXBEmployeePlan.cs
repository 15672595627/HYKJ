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
    public partial class WXBEmployeePlan : Form
    {
        public WXBEmployeePlan()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void WXBEmployeePlan_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void WXBEmployeePlan_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WXBAddEmployee jZQYAddEmployee = new WXBAddEmployee();
            jZQYAddEmployee.Username = Username;
            jZQYAddEmployee.Group = Group;
            jZQYAddEmployee.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WXBReduceEmployee jZQYReduceEmployee = new WXBReduceEmployee();
            jZQYReduceEmployee.Username = Username;
            jZQYReduceEmployee.Group = Group;
            jZQYReduceEmployee.ShowDialog();
        }
    }
}
