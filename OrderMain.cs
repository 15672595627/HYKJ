using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Contract;
using WindowsFormsApp1.Date;
using WindowsFormsApp1.Order;
using WindowsFormsApp1.Desgin;
using WindowsFormsApp1.Scheduling;
using WindowsFormsApp1.PO;
using WindowsFormsApp1.Purchase;
using WindowsFormsApp1.Bill;
using WindowsFormsApp1.Plan;
using WindowsFormsApp1.Product;
using WindowsFormsApp1.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class OrderMain : Form
    {
        public OrderMain()
        {
            InitializeComponent();
        }

        public string Username1 { get; set; }
        public string Group1 { get; set; }


        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void OrderMain_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            toolStripStatusLabel4.Text = Username1;
            toolStripStatusLabel7.Text = Group1;
        }

        private void OrderMain_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }



        #region 边框颜色

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Red, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Red, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Red, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Red, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Red, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Red, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox7_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Red, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Red, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Red, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox5_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Red, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Red, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Red, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Red, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox9_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox10_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox8_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox11_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Blue, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Blue, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox6_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Purple, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Purple, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Purple, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Purple, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Purple, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        private void groupBox12_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gbx = sender as GroupBox;
            e.Graphics.DrawLine(Pens.Purple, 1, 7, 8, 7);
            e.Graphics.DrawLine(Pens.Purple, 1, 7, 1, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Purple, e.Graphics.MeasureString(gbx.Text, gbx.Font).Width + 8, 7, gbx.Width - 2, 7);
            e.Graphics.DrawLine(Pens.Purple, 1, gbx.Height - 2, gbx.Width - 2, gbx.Height - 2);
            e.Graphics.DrawLine(Pens.Purple, gbx.Width - 2, 7, gbx.Width - 2, gbx.Height - 2);
        }

        #endregion


        #region 功能按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Form NewContract = Application.OpenForms["NewContract"];  //查找是否打开过about窗体 
            if ((NewContract == null) || (NewContract.IsDisposed)) //如果没有打开过
            {
                NewContract newContract = new NewContract();
                newContract.con_user = Username1;
                newContract.con_group = Group1;
                newContract.Show();  //打开子窗体出来

                //ContractAlert contractAlert = new ContractAlert();
                //contractAlert.ShowDialog();
            }
            else
            {
                NewContract.Activate(); //如果已经打开过就让其获得焦点  
                NewContract.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ContractList contractList = new ContractList();
            contractList.conlist_user = Username1;
            contractList.conlist_group = Group1;
            contractList.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form OrderService = Application.OpenForms["OrderService"];  //查找是否打开过about窗体 
            if ((OrderService == null) || (OrderService.IsDisposed)) //如果没有打开过
            {
                OrderService orderservice = new OrderService();
                orderservice.ord_user = Username1;
                orderservice.ord_group = Group1;
                orderservice.Show();  //打开子窗体出来

                //ContractAlert contractAlert = new ContractAlert();
                //contractAlert.ShowDialog();
            }
            else
            {
                OrderService.Activate(); //如果已经打开过就让其获得焦点  
                OrderService.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OrderServiceList orderservicelist = new OrderServiceList();
            orderservicelist.OSL_User = Username1;
            orderservicelist.OSL_Group = Group1;
            orderservicelist.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispatch distribution = new Dispatch();
            distribution.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dis_Date distributiondate = new Dis_Date();
            distributiondate.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form NewDesgin = Application.OpenForms["NewDesgin"];  //查找是否打开过about窗体 
            if ((NewDesgin == null) || (NewDesgin.IsDisposed)) //如果没有打开过
            {
                NewDesgin newDesgin = new NewDesgin();
                newDesgin.Des_User = Username1;
                newDesgin.Des_Group = Group1;
                newDesgin.Show(); //打开子窗体出来

                //ContractAlert contractAlert = new ContractAlert();
                //contractAlert.ShowDialog();
            }
            else
            {
                NewDesgin.Activate(); //如果已经打开过就让其获得焦点  
                NewDesgin.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            DesginList desginlist = new DesginList();
            desginlist.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MaterialCheck materialCheck = new MaterialCheck();
            materialCheck.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PurchaseApply purchaseApply = new PurchaseApply();
            purchaseApply.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            POApplyList purchaseApplyList = new POApplyList();
            purchaseApplyList.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            NewPO newPO = new NewPO();
            newPO.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            NewPOList newPOList = new NewPOList();
            newPOList.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Insourcing insourcing = new Insourcing();
            insourcing.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            InsourcingList insourcingList = new InsourcingList();
            insourcingList.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Outsourcing outsourcing = new Outsourcing();
            outsourcing.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OutsourcingList outsourcingList = new OutsourcingList();
            outsourcingList.Show();
        }




        private void button14_Click(object sender, EventArgs e)
        {
            ShortAgeApply shortAgeApply = new ShortAgeApply();
            shortAgeApply.Show();
        }


        private void button21_Click(object sender, EventArgs e)
        {
            PlanList planList = new PlanList();
            planList.PLL_User = Username1;
            planList.PLL_Group = Group1;
            planList.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            ProductIn productIn = new ProductIn();
            productIn.PI_user = Username1;
            productIn.PI_group = Group1;
            productIn.Show();
        }



        #endregion


        #region 实时时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            string nettime =  Winmain.GetNetDateTime();
            if (nettime != "")
            {
                toolStripStatusLabel1.Text = Convert.ToDateTime(nettime).ToString("G");
            }
            else
            {
                toolStripStatusLabel1.Text = DateTime.Now.ToString("G");
            }
        }

        #endregion

        #region 权限控制
        private void button19_Click(object sender, EventArgs e)
        {
            if(Group1 == "PMC部" || Group1 == "Administrators" || Group1 == "财务部")
            {
                Form ProductionPlan = Application.OpenForms["ProductionPlan"];  //查找是否打开过about窗体 
                if ((ProductionPlan == null) || (ProductionPlan.IsDisposed)) //如果没有打开过
                {
                    ProductionPlan productionPlan = new ProductionPlan();
                    productionPlan.PDP_User = Username1;
                    productionPlan.PDP_Group = Group1;
                    productionPlan.Show(); //打开子窗体出来

                    //ContractAlert contractAlert = new ContractAlert();
                    //contractAlert.ShowDialog();
                }
                else
                {
                    ProductionPlan.Activate(); //如果已经打开过就让其获得焦点  
                    ProductionPlan.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
                }

            }
            else
            {
                MessageBox.Show("用户权限不足");
            }

        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (Group1 == "生产部" || Group1 == "Administrators")
            {
                Form ProductionPlan = Application.OpenForms["ProductionPlan"];  //查找是否打开过about窗体 
                if ((ProductionPlan == null) || (ProductionPlan.IsDisposed)) //如果没有打开过
                {
                    ProductionPlan productionPlan = new ProductionPlan();
                    productionPlan.PDP_User = Username1;
                    productionPlan.PDP_Group = Group1;
                    productionPlan.Show(); //打开子窗体出来

                    //ContractAlert contractAlert = new ContractAlert();
                    //contractAlert.ShowDialog();
                }
                else
                {
                    ProductionPlan.Activate(); //如果已经打开过就让其获得焦点  
                    ProductionPlan.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
                }
            }
            else
            {
                MessageBox.Show("用户权限不足");
            }
        }




        #endregion


        private void button26_Click(object sender, EventArgs e)
        {
            Form Receipt = Application.OpenForms["Receipt"];  //查找是否打开过about窗体 
            if ((Receipt == null) || (Receipt.IsDisposed)) //如果没有打开过
            {

                Receipt receipt = new Receipt();
                receipt.Rec_user = Username1;
                receipt.Rec_group = Group1;
                receipt.Show();//打开子窗体出来

                //ContractAlert contractAlert = new ContractAlert();
                //contractAlert.ShowDialog();
            }
            else
            {
                Receipt.Activate(); //如果已经打开过就让其获得焦点  
                Receipt.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }

        }

        private void button28_Click(object sender, EventArgs e)
        {
            ProductListIn productlistin = new ProductListIn();
            productlistin.Group1 = Group1;
            productlistin.Username1 = Username1;
            productlistin.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            ProductOut productOut = new ProductOut();
            productOut.PO_user = Username1;
            productOut.PO_group = Group1;
            productOut.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ProductListOut listOut = new ProductListOut();
            listOut.Group1 = Group1;
            listOut.Username1 = Username1;
            listOut.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ProductCBTZ cBTZ = new ProductCBTZ();
            cBTZ.PCB_User= Username1;
            cBTZ.PCB_Group= Group1;
            cBTZ.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ProductListCbtz listCbtz = new ProductListCbtz();
            listCbtz.PLCB_User = Username1;
            listCbtz.PLCB_Group = Group1;
            listCbtz.Show();
        }


    }
}