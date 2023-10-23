using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.PersonnelDepartment;

namespace WindowsFormsApp1.PurchasingDepartment
{
    public partial class Ppadd : Form
    {
        public Ppadd()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private void button7_Click(object sender, EventArgs e)
        {
            PpEmployeePlan pEmployeePlan  = new PpEmployeePlan();
            pEmployeePlan.Username = Username;
            pEmployeePlan.Group = Group;
            pEmployeePlan.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        { 
            PpEmployeeList pEmployeeList = new PpEmployeeList();
            pEmployeeList.Username = Username;
            pEmployeeList.Group = Group;
            pEmployeeList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PSummaryBudget pSummaryBudget = new PSummaryBudget();
            pSummaryBudget.Username = Username;
            pSummaryBudget.Group = Group;
            pSummaryBudget.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PSummaryBudgetList pSummaryBudgetList = new PSummaryBudgetList();
            pSummaryBudgetList.Username = Username;
            pSummaryBudgetList.Group = Group;
            pSummaryBudgetList.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PpBudget pBudget = new PpBudget();
            pBudget.Username = Username;
            pBudget.Group = Group;
            pBudget.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PpBudgetList pBudgetList = new PpBudgetList();
            pBudgetList.Username = Username;
            pBudgetList.Group = Group;
            pBudgetList.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PpFixedAssetBudget pFixedAssetBudget = new PpFixedAssetBudget();
            pFixedAssetBudget.Username = Username;
            pFixedAssetBudget.Group = Group;
            pFixedAssetBudget.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PpFixedAssetBudgetList pFixedAssetBudgetList = new PpFixedAssetBudgetList();
            pFixedAssetBudgetList.Username = Username;
            pFixedAssetBudgetList.Group = Group;
            pFixedAssetBudgetList.ShowDialog();
        }
    }
}
