using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.FinanceDepartment
{
    public partial class CWBadd : Form
    {
        public CWBadd()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        public static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        private void button1_Click(object sender, EventArgs e)
        {
            CWBBudget cWBBudget = new CWBBudget();
            cWBBudget.Username= Username;   
            cWBBudget.Group= Group;
            cWBBudget.ShowDialog();
        }

        private void CWBadd_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void CWBadd_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CWBBudgetList cWBBudgetList = new CWBBudgetList();
            cWBBudgetList.Username= Username;
            cWBBudgetList.Group= Group;
            cWBBudgetList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CWBSummaryBudget cWBSummaryBudget = new CWBSummaryBudget();
            cWBSummaryBudget.Username= Username;
            cWBSummaryBudget.Group= Group;
            cWBSummaryBudget.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CWBSummaryBudgetList cWBSummaryBudgetList = new CWBSummaryBudgetList();
            cWBSummaryBudgetList.Username= Username;
            cWBSummaryBudgetList.Group= Group;
            cWBSummaryBudgetList.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CWBFixedAssetBudget cWBFixedAssetBudget = new CWBFixedAssetBudget();
            cWBFixedAssetBudget.Username= Username;
            cWBFixedAssetBudget.Group= Group;
            cWBFixedAssetBudget.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CWBFixedAssetBudgetList cWBFixedAssetBudgetList  = new CWBFixedAssetBudgetList();  
            cWBFixedAssetBudgetList.Username= Username;
            cWBFixedAssetBudgetList.Group= Group;
            cWBFixedAssetBudgetList.ShowDialog();
        }
    }
}
