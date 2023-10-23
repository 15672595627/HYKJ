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

namespace WindowsFormsApp1.MarketingDepartment
{
    public partial class Sadd : Form
    {
        public Sadd()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button20_Click(object sender, EventArgs e)
        {
            SCGXBudget sCGXBudget = new SCGXBudget();
            sCGXBudget.Username = Username;
            sCGXBudget.Group = Group;
            sCGXBudget.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SGSummaryBudget sGSummaryBudget = new SGSummaryBudget();
            sGSummaryBudget.Username = Username;
            sGSummaryBudget.Group = Group;
            sGSummaryBudget.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SEmployeePlan sEmployeePlan = new SEmployeePlan();
            sEmployeePlan.Username= Username;
            sEmployeePlan.Group = Group;
            sEmployeePlan.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SFixedAssetBudget sFixedAssetBudget = new SFixedAssetBudget();
            sFixedAssetBudget.Username = Username;
            sFixedAssetBudget.Group = Group;
            sFixedAssetBudget.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SExpandPlan sExpandPlan = new SExpandPlan();
            sExpandPlan.UserName = Username;
            sExpandPlan.Group = Group;
            sExpandPlan.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SCGXBudgetList sCGXBudgetList = new SCGXBudgetList();
            sCGXBudgetList.Username = Username;
            sCGXBudgetList.Group = Group;
            sCGXBudgetList.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SGSummaryBudgetList sGSummaryBudget = new SGSummaryBudgetList();
            sGSummaryBudget.Username = Username;
            sGSummaryBudget.Group = Group;
            sGSummaryBudget.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SEmployeeList sEmployeeList = new SEmployeeList();
            sEmployeeList.Username = Username;
            sEmployeeList.Group = Group;
            sEmployeeList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SFixedAssetBudgetList sFixedAssetBudget = new SFixedAssetBudgetList();
            sFixedAssetBudget.Username = Username;
            sFixedAssetBudget.Group = Group;
            sFixedAssetBudget.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SExpandPlanList sExpandPlan = new SExpandPlanList();
            sExpandPlan.Username = Username;
            sExpandPlan.Group = Group;
            sExpandPlan.ShowDialog();
        }
    }
}
