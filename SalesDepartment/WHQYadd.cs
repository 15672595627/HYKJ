using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.SalesDepartment
{
    public partial class WHQYadd : Form
    {
        public WHQYadd()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        int Iid;
        int zt;
        string rq;
        DataTable dt;
        SqlDataAdapter da;
        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button1_Click(object sender, EventArgs e)
        {
            WHQYCgxBudget wHQYCgxBudget = new WHQYCgxBudget();
            wHQYCgxBudget.Username = Username;
            wHQYCgxBudget.Group = Group;
            wHQYCgxBudget.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WHQYCgxBudgetList wHQYCgxBudgetList = new WHQYCgxBudgetList();
            wHQYCgxBudgetList.Username = Username;
            wHQYCgxBudgetList.Group = Group;
            wHQYCgxBudgetList.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WHQYEmployeePlan wHQYEmployeePlan = new WHQYEmployeePlan();
            wHQYEmployeePlan.Username = Username;
            wHQYEmployeePlan.Group = Group;
            wHQYEmployeePlan.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WHQYEmployeeList wHQYEmployeeList = new WHQYEmployeeList();
            wHQYEmployeeList.Username = Username;
            wHQYEmployeeList.Group = Group;
            wHQYEmployeeList.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WHQYExpandPlan wHQYExpandPlan = new WHQYExpandPlan();
            wHQYExpandPlan.UserName= Username;
            wHQYExpandPlan.Group = Group;
            wHQYExpandPlan.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WHQYExpandPlanList wHQYExpandPlanList = new WHQYExpandPlanList();
            wHQYExpandPlanList.Username = Username;
            wHQYExpandPlanList.Group = Group;
            wHQYExpandPlanList.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WHQYFixedAssetBudget wHQYFixedAssetBudget = new WHQYFixedAssetBudget();
            wHQYFixedAssetBudget.Username = Username;
            wHQYFixedAssetBudget.Group = Group;
            wHQYFixedAssetBudget.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            WHQYFixedAssetBudgetList wHQYFixedAssetBudgetList = new WHQYFixedAssetBudgetList();
            wHQYFixedAssetBudgetList.Username = Username;
            wHQYFixedAssetBudgetList.Group= Group;
            wHQYFixedAssetBudgetList.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WHQYSummaryBudget wHQYSummaryBudget = new WHQYSummaryBudget();
            wHQYSummaryBudget.Username = Username;
            wHQYSummaryBudget.Group = Group;
            wHQYSummaryBudget.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WHQYSummaryBudgetList wHQYSummaryBudgetList = new WHQYSummaryBudgetList();
            wHQYSummaryBudgetList.Username = Username;
            wHQYSummaryBudgetList.Group = Group;
            wHQYSummaryBudgetList.ShowDialog();
        }
    }
}
