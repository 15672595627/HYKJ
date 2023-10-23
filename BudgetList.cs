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
using WindowsFormsApp1.CustomerServiceDepartment;
using WindowsFormsApp1.DesignDepartment;
using WindowsFormsApp1.EngineeringDepartment;
using WindowsFormsApp1.GeneralManager;
using WindowsFormsApp1.MarketingDepartment;
using WindowsFormsApp1.PersonnelDepartment;

namespace WindowsFormsApp1
{
    public partial class BudgetList : Form
    {
        public BudgetList()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        
        private void BudgetList_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            CGXBudgetList cGXBudgetList = new CGXBudgetList();  
            cGXBudgetList.Username= Username;
            cGXBudgetList.Group= Group;
            cGXBudgetList.ShowDialog();

        }

        private void BudgetList_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GSummaryBudgetList budgetList = new GSummaryBudgetList();
            budgetList.Username = Username;
            budgetList.Group= Group;
            budgetList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEmployeeList addEmployee = new AddEmployeeList();
            addEmployee.Username = Username;
            addEmployee.Group= Group;
            addEmployee.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FixedAssetBudgetList fixedAssetBudget = new FixedAssetBudgetList();
            fixedAssetBudget.Username = Username;
            fixedAssetBudget.Group= Group;
            fixedAssetBudget.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SCGXBudgetList sCGX = new SCGXBudgetList();
            sCGX.Username = Username;
            sCGX.Group= Group;
            sCGX.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SGSummaryBudgetList sGSummary = new SGSummaryBudgetList();
            sGSummary.Username = Username;
            sGSummary.Group= Group;
            sGSummary.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SEmployeeList sEmployeeList = new SEmployeeList();
            sEmployeeList.Username = Username;
            sEmployeeList.Group= Group;
            sEmployeeList.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SFixedAssetBudgetList sFixedAsset = new SFixedAssetBudgetList();
            sFixedAsset.Username = Username;
            sFixedAsset.Group= Group;
            sFixedAsset.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SExpandPlanList sExpand = new SExpandPlanList();
            sExpand.Username = Username;
            sExpand.Group= Group;
            sExpand.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PSummaryBudgetList pSummary = new PSummaryBudgetList();
            pSummary.Username = Username;
            pSummary.Group= Group;
            pSummary.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PSalaryDetailsList pSalary = new PSalaryDetailsList();
            pSalary.Username = Username;
            pSalary.Group= Group;
            pSalary.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            PEmployeeList pEmployee = new PEmployeeList();
            pEmployee.Username = Username;
            pEmployee.Group= Group;
            pEmployee.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PFixedAssetBudgetList pFixedAsset = new PFixedAssetBudgetList();
            pFixedAsset.Username = Username;
            pFixedAsset.Group= Group;
            pFixedAsset.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CCGXBudgetList cCGX = new CCGXBudgetList();
            cCGX.Username = Username;
            cCGX.Group= Group;
            cCGX.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            CUpdateSummaryBudget cUpdateSummary = new CUpdateSummaryBudget();
            cUpdateSummary.Username = Username;
            cUpdateSummary.Group= Group;
            cUpdateSummary.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            CEmployeeList cEmployeeList = new CEmployeeList();
            cEmployeeList.Username = Username;
            cEmployeeList.Group= Group;
            cEmployeeList.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CFixedAssetBudgetList cFixedAsset = new CFixedAssetBudgetList();
            cFixedAsset.Username = Username;
            cFixedAsset.Group= Group;
            cFixedAsset.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DCGXBudgetList dCGX = new DCGXBudgetList();
            dCGX.Username = Username;
            dCGX.Group= Group;
            dCGX.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DSummaryBudgetList dSummary = new DSummaryBudgetList();
            dSummary.Username = Username;
            dSummary.Group = Group;
            dSummary.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            DEmployeeList dEmployeeList = new DEmployeeList();
            dEmployeeList.Username = Username;
            dEmployeeList.Group= Group;
            dEmployeeList.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DFixedAssetBudgetList dFixedAssetBudget = new DFixedAssetBudgetList();
            dFixedAssetBudget.Username = Username;
            dFixedAssetBudget.Group= Group;
            dFixedAssetBudget.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            ECGXBudgetList eCGXBudget = new ECGXBudgetList();
            eCGXBudget.Username = Username;
            eCGXBudget.Group= Group;
            eCGXBudget.ShowDialog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            ECGXBudgetList eCGXBudget = new ECGXBudgetList();
            eCGXBudget.Username = Username;
            eCGXBudget.Group= Group;
            eCGXBudget.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ESalaryDetailsList eSalaryDetails = new ESalaryDetailsList();
            eSalaryDetails.Username = Username;
            eSalaryDetails.Group= Group;
            eSalaryDetails.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            EEmployeeList eEmployee = new EEmployeeList();
            eEmployee.Username = Username;
            eEmployee.Group= Group;
            eEmployee.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            EFixedAssetBudgetList eFixedAsset = new EFixedAssetBudgetList();
            eFixedAsset.Username = Username;
            eFixedAsset.Group= Group;
            eFixedAsset.ShowDialog();
        }
    }
}
