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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1.GeneralManager
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button19_Click(object sender, EventArgs e)
        {
            CGXBudget cGXBudget = new CGXBudget();
            cGXBudget.Username = Username;
            cGXBudget.Group = Group;
            cGXBudget.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GSummaryBudget gSummary = new GSummaryBudget();
            gSummary.Username = Username;
            gSummary.Group = Group;
            gSummary.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeePlan employeePlan = new EmployeePlan();
            employeePlan.Username = Username;
            employeePlan.Group = Group;
            employeePlan.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FixedAssetBudget fixedAssetBudget = new FixedAssetBudget();
            fixedAssetBudget.Username = Username;
            fixedAssetBudget.Group = Group;
            fixedAssetBudget.ShowDialog();
        }
    }
}
