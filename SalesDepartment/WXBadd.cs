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

namespace WindowsFormsApp1.SalesDepartment
{
    public partial class WXBadd : Form
    {
        public WXBadd()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private void WXBadd_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }
        private void WXBadd_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button7_Click(object sender, EventArgs e)
        {
            WXBEmployeePlan wXBEmployeePlan = new WXBEmployeePlan();
            wXBEmployeePlan.Username = Username;
            wXBEmployeePlan.Group= Group;
            wXBEmployeePlan.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WXBEmployeeList wXBEmployeeList = new WXBEmployeeList();
            wXBEmployeeList.Username = Username;
            wXBEmployeeList.Group = Group;
            wXBEmployeeList.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WXBCgxBudget wXBCgxBudget = new WXBCgxBudget();
            wXBCgxBudget.Username = Username;
            wXBCgxBudget.Group = Group;
            wXBCgxBudget.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WXBCgxBudgetList wXBCgxBudgetList = new WXBCgxBudgetList();
            wXBCgxBudgetList.Username = Username;
            wXBCgxBudgetList.Group = Group;
            wXBCgxBudgetList.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WXBExpandPlan wXBExpandPlan = new WXBExpandPlan();
            wXBExpandPlan.UserName = Username;
            wXBExpandPlan.Group = Group; 
            wXBExpandPlan.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WXBExpandPlanList wXBExpandPlanList = new WXBExpandPlanList();
            wXBExpandPlanList.Username = Username;
            wXBExpandPlanList.Group = Group;
            wXBExpandPlanList.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WXBFixedAssetBudget wXBFixedAssetBudget = new WXBFixedAssetBudget();
            wXBFixedAssetBudget.Username = Username;
            wXBFixedAssetBudget.Group = Group;
            wXBFixedAssetBudget.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            WXBFixedAssetBudgetList wXBFixedAssetBudgetList = new WXBFixedAssetBudgetList();
            wXBFixedAssetBudgetList.Username = Username;
            wXBFixedAssetBudgetList.Group= Group;
            wXBFixedAssetBudgetList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WXBSummaryBudget wXBSummaryBudget = new WXBSummaryBudget();
            wXBSummaryBudget.Username = Username;
            wXBSummaryBudget.Group = Group;
            wXBSummaryBudget.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WXBSummaryBudgetList wXBSummaryBudgetList = new WXBSummaryBudgetList();
            wXBSummaryBudgetList.Username = Username;
            wXBSummaryBudgetList.Group = Group;
            wXBSummaryBudgetList.ShowDialog();
        }
    }
}
