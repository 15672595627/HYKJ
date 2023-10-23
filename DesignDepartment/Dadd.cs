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

namespace WindowsFormsApp1.DesignDepartment
{
    public partial class Dadd : Form
    {
        public Dadd()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button15_Click(object sender, EventArgs e)
        {
            DCGXBudget dCGXBudget = new DCGXBudget();
            dCGXBudget.Username= Username;
            dCGXBudget.Group= Group;
            dCGXBudget.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DSummaryBudget dSummaryBudget = new DSummaryBudget();
            dSummaryBudget.Username= Username;
            dSummaryBudget.Group= Group;
            dSummaryBudget.ShowDialog();
                
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DEmployeePlan dEmployeePlanplan = new DEmployeePlan();  
            dEmployeePlanplan.Username= Username;
            dEmployeePlanplan.Group= Group;
            dEmployeePlanplan.ShowDialog();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            DFixedAssetBudget dFixedAssetBudget = new DFixedAssetBudget();
            dFixedAssetBudget.Username= Username;
            dFixedAssetBudget.Group= Group;
            dFixedAssetBudget.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DCGXBudgetList dCGXBudgetList = new DCGXBudgetList();
            dCGXBudgetList.Username= Username;
            dCGXBudgetList.Group= Group;
            dCGXBudgetList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DSummaryBudgetList dSummaryBudget = new DSummaryBudgetList();
            dSummaryBudget.Username= Username;
            dSummaryBudget.Group= Group;
            dSummaryBudget.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            DEmployeeList dEmployeeList = new DEmployeeList();
            dEmployeeList.Username= Username;
            dEmployeeList.Group= Group;
            dEmployeeList.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DFixedAssetBudgetList dFixedAssetBudget = new DFixedAssetBudgetList();
            dFixedAssetBudget.Username= Username;
            dFixedAssetBudget.Group= Group;
            dFixedAssetBudget.ShowDialog();
        }
    }
}
