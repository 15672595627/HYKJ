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

namespace WindowsFormsApp1.PersonnelDepartment
{
    public partial class Padd : Form
    {
        public Padd()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button9_Click(object sender, EventArgs e)
        {
            PSummaryBudget pSummaryBudget = new PSummaryBudget();
            pSummaryBudget.Username= Username;
            pSummaryBudget.Group= Group;
            pSummaryBudget.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PSalaryDetails pSalaryDetails = new PSalaryDetails();
            pSalaryDetails.Username= Username;
            pSalaryDetails.Group= Group;
            pSalaryDetails.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            PEmployeePlan pEmployeePlan = new PEmployeePlan();
            pEmployeePlan.Username= Username;
            pEmployeePlan.Group= Group;
            pEmployeePlan.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PFixedAssetBudget pFixedAssetBudget = new PFixedAssetBudget();
            pFixedAssetBudget.Username= Username;
            pFixedAssetBudget.Group= Group;
            pFixedAssetBudget.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PSummaryBudgetList pSummaryBudget = new PSummaryBudgetList();
            pSummaryBudget.Username= Username;
            pSummaryBudget.Group= Group;
            pSummaryBudget.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PSalaryDetailsList pSalaryDetails = new PSalaryDetailsList();
            pSalaryDetails.Username= Username;
            pSalaryDetails.Group= Group;
            pSalaryDetails.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            PEmployeeList pEmployeeList = new PEmployeeList();
            pEmployeeList.Username= Username;
            pEmployeeList.Group= Group;
            pEmployeeList.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PFixedAssetBudgetList pFixedAssetBudget = new PFixedAssetBudgetList();
            pFixedAssetBudget.Username= Username;
            pFixedAssetBudget.Group= Group;
            pFixedAssetBudget.ShowDialog();
        }
    }
}
