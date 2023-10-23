using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.GeneralManager
{
    public partial class EmployeePlan : Form
    {
        public EmployeePlan()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Username= Username;
            addEmployee.Group= Group;
            addEmployee.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReduceEmployee reduceEmployee = new ReduceEmployee();
            reduceEmployee.Username= Username;
            reduceEmployee.Group= Group;
            reduceEmployee.ShowDialog();
        }
    }
}
