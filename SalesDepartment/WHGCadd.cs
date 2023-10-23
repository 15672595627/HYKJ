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
    public partial class WHGCadd : Form
    {
        public WHGCadd()
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
        private void button7_Click(object sender, EventArgs e)
        {
            WHGCEmployeePlan wHGCEmployeePlan = new WHGCEmployeePlan();
            wHGCEmployeePlan.Username = Username;
            wHGCEmployeePlan.Group= Group;
            wHGCEmployeePlan.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WHGCEmployeeList wHGCEmployeeList = new WHGCEmployeeList();
            wHGCEmployeeList.Username = Username;
            wHGCEmployeeList.Group= Group;
            wHGCEmployeeList.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WHGCCgxBudget wHGCCgxBudget = new WHGCCgxBudget();
            wHGCCgxBudget.Username = Username;
            wHGCCgxBudget.Group= Group;
            wHGCCgxBudget.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WHGCCgxBudgetList wHGCCgxBudgetList = new WHGCCgxBudgetList();
            wHGCCgxBudgetList.Username = Username;
            wHGCCgxBudgetList.Group= Group;
            wHGCCgxBudgetList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WHGCSummaryBudget wHGCSummaryBudget = new WHGCSummaryBudget();
            wHGCSummaryBudget.Username = Username;
            wHGCSummaryBudget.Group= Group;
            wHGCSummaryBudget.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WHGCExpandPlan wHGCExpandPlan = new WHGCExpandPlan();
            wHGCExpandPlan.UserName= Username;
            wHGCExpandPlan.Group= Group;
            wHGCExpandPlan.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WHGCExpandPlanList wHGCExpandPlanList = new WHGCExpandPlanList();
            wHGCExpandPlanList.Username = Username;
            wHGCExpandPlanList.Group= Group;    
            wHGCExpandPlanList.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WHGCFixedAssetBudget wHGCFixedAssetBudget = new WHGCFixedAssetBudget();
            wHGCFixedAssetBudget.Username = Username;   
            wHGCFixedAssetBudget.Group= Group;
            wHGCFixedAssetBudget.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            WHGCFixedAssetBudgetList wHGCFixedAssetBudgetList = new WHGCFixedAssetBudgetList();
            wHGCFixedAssetBudgetList.Username = Username;
            wHGCFixedAssetBudgetList.Group= Group;
            wHGCFixedAssetBudgetList.ShowDialog(this);
        }
    }
}
