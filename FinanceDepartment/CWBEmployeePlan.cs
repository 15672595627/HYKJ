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

namespace WindowsFormsApp1.FinanceDepartment
{
    public partial class CWBEmployeePlan : Form
    {
        public CWBEmployeePlan()
        {
            InitializeComponent();
        }
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public string Username { get; set; }
        public string Group { get; set; }

        private void CWBEmployeePlan_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void CWBEmployeePlan_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CWBAddEmployee cWBAddEmployee = new CWBAddEmployee();
            cWBAddEmployee.Username= Username;
            cWBAddEmployee.Group= Group;
            cWBAddEmployee.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CWBReduceEmployee cWBReduceEmployee = new CWBReduceEmployee();
            cWBReduceEmployee.ShowDialog();
        }
    }
}
