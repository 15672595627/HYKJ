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
    public partial class JZQYadd : Form
    {
        public JZQYadd()
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
            JZQYCgxBudget jZQYCgx = new JZQYCgxBudget();
            jZQYCgx.Username = Username;
            jZQYCgx.Group = Group;
            jZQYCgx.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            JZQYCgxBudgetList jZQYCgx = new JZQYCgxBudgetList();
            jZQYCgx.Username = Username;
            jZQYCgx.Group = Group;
            jZQYCgx.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JZQYSummaryBudget jZQYSummary = new JZQYSummaryBudget();
            jZQYSummary.Username = Username;
            jZQYSummary.Group = Group;
            jZQYSummary.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JZQYSummaryBudgetList jZQYSummary = new JZQYSummaryBudgetList();
            jZQYSummary.Username = Username;
            jZQYSummary.Group = Group;
            jZQYSummary.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            JZQYExpandPlan jZQYExpandPlan = new JZQYExpandPlan();
            jZQYExpandPlan.UserName = Username;
            jZQYExpandPlan.Group = Group;
            jZQYExpandPlan.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            JZQYExpandPlanList zQYExpandPlanList = new JZQYExpandPlanList();
            zQYExpandPlanList.Username = Username;
            zQYExpandPlanList.Group = Group;
            zQYExpandPlanList.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            JZQYEmployeePlan jZQYEmployeePlan = new JZQYEmployeePlan();
            jZQYEmployeePlan.Username = Username;
            jZQYEmployeePlan.Group = Group;
            jZQYEmployeePlan.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            JZQYEmployeeList jZQYEmployeeList = new JZQYEmployeeList();
            jZQYEmployeeList.Username = Username;
            jZQYEmployeeList.Group = Group;
            jZQYEmployeeList.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            JZQYFixedAssetBudget jZQYFixedAssetBudget = new JZQYFixedAssetBudget();
            jZQYFixedAssetBudget.Username = Username;
            jZQYFixedAssetBudget.Group = Group;
            jZQYFixedAssetBudget.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            JZQYFixedAssetBudgetList jZQYFixedAssetBudgetList = new JZQYFixedAssetBudgetList();
            jZQYFixedAssetBudgetList.Username = Username;
            jZQYFixedAssetBudgetList.Group = Group;
            jZQYFixedAssetBudgetList.ShowDialog();
        }
    }
}
