using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.MarketingDepartment
{
    public partial class SEmployeePlan : Form
    {
        public SEmployeePlan()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            SAddEmployee sAddEmployee = new SAddEmployee();
            sAddEmployee.Username = Username;       
            sAddEmployee.Group = Group;
            sAddEmployee.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SReduceEmployee sReduceEmployee = new SReduceEmployee();
            sReduceEmployee.Username = Username;
            sReduceEmployee.Group = Group;
            sReduceEmployee.ShowDialog();
        }
    }
}
