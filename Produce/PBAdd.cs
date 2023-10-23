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

namespace WindowsFormsApp1.Produce
{
    public partial class PBAdd : Form
    {
        public PBAdd()
        {
            InitializeComponent();
        }
        public string Username { get; set; }
        public string Group { get; set; }
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void PBAdd_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductionBudget productionBudget = new ProductionBudget();
            productionBudget.Username = Username;
            productionBudget.Group = Group;
            productionBudget.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductionBudgetList productionBudgetList = new ProductionBudgetList();
            productionBudgetList.Username = Username;
            productionBudgetList.Group = Group;
            productionBudgetList.ShowDialog();
        }

        private void PBAdd_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductionUpdateBudget productionUpdateBudget = new ProductionUpdateBudget();
            productionUpdateBudget.Username = Username;
            productionUpdateBudget.Group = Group;
            productionUpdateBudget.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PBListByMonth pBListByMonth = new PBListByMonth();
            pBListByMonth.Username = Username;
            pBListByMonth.Group = Group;
            pBListByMonth.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PBListByYear pBListByYear = new PBListByYear();
            pBListByYear.Username = Username;
            pBListByYear.Group = Group;
            pBListByYear.ShowDialog();
        }
    }
}
