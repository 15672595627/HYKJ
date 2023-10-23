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

namespace WindowsFormsApp1.CustomerServiceDepartment
{
    public partial class Cadd : Form
    {
        public Cadd()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button12_Click(object sender, EventArgs e)
        {
            CCGXBudget cCGXBudget = new CCGXBudget();
            cCGXBudget.Username = Username;
            cCGXBudget.Group = Group;
            cCGXBudget.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            CSummaryBudget cSummaryBudget = new CSummaryBudget();
            cSummaryBudget.Username = Username;
            cSummaryBudget.Group = Group;
            cSummaryBudget.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            CEmployeePlan cEmployeePlan = new CEmployeePlan();
            cEmployeePlan.Username = Username;
            cEmployeePlan.Group = Group;
            cEmployeePlan.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CCGXBudgetList cCGXBudget = new CCGXBudgetList();
            cCGXBudget.Username = Username;
            cCGXBudget.Group = Group;
            cCGXBudget.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            CSummaryBudgetList cSummaryBudget = new CSummaryBudgetList();
            cSummaryBudget.Username = Username;
            cSummaryBudget.Group = Group;
            cSummaryBudget.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CEmployeeList cEmployeeList = new CEmployeeList();
            cEmployeeList.Username = Username;
            cEmployeeList.Group = Group;
            cEmployeeList.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CFixedAssetBudgetList cFixedAssetBudgetList = new CFixedAssetBudgetList();
            cFixedAssetBudgetList.Username = Username;
            cFixedAssetBudgetList.Group = Group;
            cFixedAssetBudgetList.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CFixedAssetBudget cFixedAssetBudgetList = new CFixedAssetBudget();
            cFixedAssetBudgetList.Username = Username;
            cFixedAssetBudgetList.Group = Group;
            cFixedAssetBudgetList.ShowDialog();
        }
    }
}
