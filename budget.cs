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
using WindowsFormsApp1.FinanceDepartment;
using WindowsFormsApp1.GeneralManager;
using WindowsFormsApp1.MarketingDepartment;
using WindowsFormsApp1.PersonnelDepartment;
using WindowsFormsApp1.PurchasingDepartment;
using WindowsFormsApp1.SalesDepartment;

namespace WindowsFormsApp1
{
    public partial class budget : Form
    {
        public budget()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void button1_Click(object sender, EventArgs e)
        {
            GSummaryBudget gSummary = new GSummaryBudget();
            gSummary.Username= Username;
            gSummary.Group= Group;
            gSummary.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            CGXBudget cGXBudget = new CGXBudget();
            cGXBudget.Username= Username;
            cGXBudget.Group= Group;
            cGXBudget.ShowDialog();
        }

        private void budget_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void budget_StyleChanged(object sender, EventArgs e)
        {

        }

        private void budget_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeePlan employeePlan = new EmployeePlan();
            employeePlan.Username= Username;
            employeePlan.Group= Group;
            employeePlan.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FixedAssetBudget fixedAssetBudget = new FixedAssetBudget();
            fixedAssetBudget.Username= Username;
            fixedAssetBudget.Group= Group;
            fixedAssetBudget.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SCGXBudget sCGXBudget = new SCGXBudget();
            sCGXBudget.Username= Username;
            sCGXBudget.Group= Group;
            sCGXBudget.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SGSummaryBudget sGSummary = new SGSummaryBudget();
            sGSummary.Username= Username;
            sGSummary.Group= Group;
            sGSummary.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SEmployeePlan sEmployeePlan = new SEmployeePlan();
            sEmployeePlan.Username= Username;
            sEmployeePlan.Group= Group;
            sEmployeePlan.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SFixedAssetBudget sFixedAsset = new SFixedAssetBudget();
            sFixedAsset.Username= Username;
            sFixedAsset.Group= Group;
            sFixedAsset.ShowDialog();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SExpandPlan sExpand = new SExpandPlan();
            sExpand.UserName= Username;
            sExpand.Group= Group;
            sExpand.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*PSummaryBudget pSummary = new PSummaryBudget();
            pSummary.Username= Username;
            pSummary.Group= Group;
            pSummary.ShowDialog();*/
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PSalaryDetails pSalary = new PSalaryDetails();
            pSalary.Username= Username;
            pSalary.Group= Group;
            pSalary.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            PEmployeePlan pEmployee = new PEmployeePlan();
            pEmployee.Username = Username;
            pEmployee.Group = Group;
            pEmployee.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PFixedAssetBudget pFixedAsset = new PFixedAssetBudget();
            pFixedAsset.Username = Username;
            pFixedAsset.Group = Group;
            pFixedAsset.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CCGXBudget cCGX = new CCGXBudget();
            cCGX.Username = Username;
            cCGX.Group = Group;
            cCGX.ShowDialog();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            CSummaryBudget cSummary = new CSummaryBudget();
            cSummary.Username = Username;
            cSummary.Group = Group;
            cSummary.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            CEmployeePlan cEmployeePlan = new CEmployeePlan();
            cEmployeePlan.Username = Username;
            cEmployeePlan.Group = Group;
            cEmployeePlan.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CFixedAssetBudget cFixedAsset = new CFixedAssetBudget();
            cFixedAsset.Username = Username;
            cFixedAsset.Group = Group;
            cFixedAsset.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DCGXBudget dCGX = new DCGXBudget();
            dCGX.Username = Username;
            dCGX.Group = Group;
            dCGX.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DSummaryBudget dSummary = new DSummaryBudget();
            dSummary.Username = Username;
            dSummary.Group = Group;
            dSummary.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DEmployeePlan dEmployeePlan = new DEmployeePlan();
            dEmployeePlan.Username = Username;
            dEmployeePlan.Group = Group;
            dEmployeePlan.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DFixedAssetBudget dFixedAssetBudget = new DFixedAssetBudget();
            dFixedAssetBudget.Username = Username;
            dFixedAssetBudget.Group = Group;
            dFixedAssetBudget.ShowDialog();
        }

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
            EEmployeePlan eEmployee = new EEmployeePlan();
            eEmployee.Username = Username;
            eEmployee.Group = Group;
            eEmployee.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            EFixedAssetBudget eFixedAsset = new EFixedAssetBudget();
            eFixedAsset.Username = Username;
            eFixedAsset.Group = Group;
            eFixedAsset.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "销售模块")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("荆州区域");
                comboBox2.Items.Add("武汉区域");
                comboBox2.Items.Add("武汉工程");
                comboBox2.Items.Add("网销区域");
            }
            else if (comboBox1.Text == "管理模块")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("总经办");
                comboBox2.Items.Add("人事部");
                comboBox2.Items.Add("采购部");
                comboBox2.Items.Add("客服部");
                comboBox2.Items.Add("工程部");
                comboBox2.Items.Add("设计部");
                comboBox2.Items.Add("财务部");
                comboBox2.Items.Add("市场部");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "总经办")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new add();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "市场部")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new Sadd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "客服部")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new Cadd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "设计部")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new Dadd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "工程部")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new Eadd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "人事部")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new Padd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "采购部")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new Ppadd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "财务部")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new CWBadd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "荆州区域")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new JZQYadd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "武汉区域")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new WHQYadd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "武汉工程")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new WHGCadd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
            else if (comboBox2.Text == "网销区域")
            {
                this.panel1.Controls.Clear();
                this.Refresh();
                var frm = new WXBadd();
                frm.TopLevel = false;
                this.panel1.Controls.Add(frm);
                frm.Show();
            }
        }
    }
}
