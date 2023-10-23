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

namespace WindowsFormsApp1.EngineeringDepartment
{
    public partial class Eadd : Form
    {
        public Eadd()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button26_Click(object sender, EventArgs e)
        {
            ECGXBudget eCGXBudget = new ECGXBudget();
            eCGXBudget.Username = Username;
            eCGXBudget.Group = Group;
            eCGXBudget.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ESummaryBudget eSummaryBudget = new ESummaryBudget();
            eSummaryBudget.Username = Username;
            eSummaryBudget.Group = Group;
            eSummaryBudget.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ESalaryDetails eSalaryDetails = new ESalaryDetails();
            eSalaryDetails.Username = Username;
            eSalaryDetails.Group = Group;
            eSalaryDetails.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            EEmployeePlan eEmployeePlan = new EEmployeePlan();
            eEmployeePlan.Username = Username;
            eEmployeePlan.Group = Group;
            eEmployeePlan.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            EFixedAssetBudget eFixedAssetBudget = new EFixedAssetBudget();
            eFixedAssetBudget.Username = Username;
            eFixedAssetBudget.Group = Group;
            eFixedAssetBudget.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            ECGXBudgetList eCGXBudgetList = new ECGXBudgetList();
            eCGXBudgetList.Username = Username;
            eCGXBudgetList.Group = Group;
            eCGXBudgetList.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ESummaryBudgetList eSummaryBudget = new ESummaryBudgetList();
            eSummaryBudget.Username = Username;
            eSummaryBudget.Group = Group;
            eSummaryBudget.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ESalaryDetailsList eSalaryDetails = new ESalaryDetailsList();
            eSalaryDetails.Username = Username;
            eSalaryDetails.Group = Group;
            eSalaryDetails.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EEmployeeList eEmployeeList = new EEmployeeList();
            eEmployeeList.Username = Username;
            eEmployeeList.Group = Group;
            eEmployeeList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EFixedAssetBudgetList eFixedAssetBudget = new EFixedAssetBudgetList();
            eFixedAssetBudget.Username = Username;
            eFixedAssetBudget.Group = Group;
            eFixedAssetBudget.ShowDialog();
        }
    }
}
