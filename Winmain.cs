using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Calc;
using WindowsFormsApp1.Main;
using WindowsFormsApp1.Order;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using WindowsFormsApp1.Goods;
using WindowsFormsApp1.Product;
using WindowsFormsApp1.Stock;
using System.Windows.Interop;
using WindowsFormsApp1.Class;
using WindowsFormsApp1.Properties;
using WindowsFormsApp1.OrderReport;
using WindowsFormsApp1.Platform;

namespace WindowsFormsApp1
{
    public partial class Winmain : Form
    {
        public Winmain()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];

        public string Username { get; set; }
        public string Group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private void Winmain_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

            toolStripStatusLabel4.Text = Username;
            string aa = Username.Trim();

            SqlConnection con = new SqlConnection(SQL);
            string strsql = "select * from [dbo].[User] where name = '" + aa + "'";
            SqlDataAdapter da = new SqlDataAdapter(strsql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Group = ds.Tables[0].Rows[0][2].ToString().Trim();
            toolStripStatusLabel7.Text = Group;
        }



        private void Winmain_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        //获取网络时间

        public static string GetNetDateTime()
        {
            WebRequest request = null;
            WebResponse response = null;
            WebHeaderCollection headerCollection = null;
            string datetime = string.Empty;
            try
            {
                request = WebRequest.Create("https://www.baidu.com");
                request.Timeout = 3000;
                request.Credentials = CredentialCache.DefaultCredentials;
                response = request.GetResponse();
                headerCollection = response.Headers;
                foreach (var h in headerCollection.AllKeys)
                {
                    if (h == "Date")
                    {
                        datetime = headerCollection[h];
                    }
                }
                return datetime;
            }
            catch (Exception) { return datetime; }
            finally
            {
                if (request != null)
                { request.Abort(); }
                if (response != null)
                { response.Close(); }
                if (headerCollection != null)
                { headerCollection.Clear(); }
            }
        }

        //正常菜单
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            Report report = new Report();
            report.Show();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Calemain calemain = new Calemain();
            calemain.Show();
        }

        private void 用户新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser newuser = new NewUser();
            newuser.Show();
        }

        private void 客户新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCustomer newcustomer = new NewCustomer();
            newcustomer.Show();
        }

        private void 产品类别新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProduct newproduct = new NewProduct();
            newproduct.Show();
        }

        private void 业务员新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSeller newseller = new NewSeller();
            newseller.Show();
        }

        #region groupbox红框红字

        private void GroupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;

            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Red, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }

        private void GroupBox2_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gBox = (GroupBox)sender;

            e.Graphics.Clear(gBox.BackColor);
            e.Graphics.DrawString(gBox.Text, gBox.Font, Brushes.Red, 10, 1);
            var vSize = e.Graphics.MeasureString(gBox.Text, gBox.Font);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, vSize.Width + 8, vSize.Height / 2, gBox.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(Pens.Red, 1, vSize.Height / 2, 1, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, 1, gBox.Height - 2, gBox.Width - 2, gBox.Height - 2);
            e.Graphics.DrawLine(Pens.Red, gBox.Width - 2, vSize.Height / 2, gBox.Width - 2, gBox.Height - 2);
        }

        #endregion groupbox红框红字

        private void Button2_Click(object sender, EventArgs e)
        {
            Form OrderMain = Application.OpenForms["OrderMain"];  //查找是否打开过about窗体 
            if ((OrderMain == null) || (OrderMain.IsDisposed)) //如果没有打开过
            {
                OrderMain ordermain = new OrderMain();
                ordermain.Username1 = Username;
                ordermain.Group1 = Group;
                ordermain.Show();   //打开子窗体出来

                //ContractAlert contractAlert = new ContractAlert();
                //contractAlert.ShowDialog();
            }
            else
            {
                OrderMain.Activate(); //如果已经打开过就让其获得焦点  
                OrderMain.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string nettime = GetNetDateTime();
            if (nettime != "")
            {
                toolStripStatusLabel1.Text = Convert.ToDateTime(nettime).ToString("G");
            }
            else
            {
                toolStripStatusLabel1.Text = DateTime.Now.ToString("G");
            }

        }

        private void 群组新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGroup newGroup = new NewGroup();
            newGroup.Show();
        }

        private void 物料新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleGoods singleGoods = new SingleGoods();
            singleGoods.Show();
        }

        private void 物料导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGoods newGoods = new NewGoods();
            newGoods.Show();
        }

        private void 物料清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoodsList goodsList = new GoodsList();
            goodsList.Show();
        }

        private void XFJ_Click(object sender, EventArgs e)
        {
            MessageS messageS = new MessageS();
            messageS.MSS_User = Username;
            messageS.MSS_Group = Group;
            messageS.Show();
        }

        private void 用户列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasisList basisList = new BasisList();
            basisList.Show();
        }

        private void 产品导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportPro importPro = new ImportPro();
            importPro.Show();
        }

        private void 即时库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JIT jIT = new JIT();
            jIT.Show();
        }

        private void 成品入库单导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportProIn importProIn = new ImportProIn();
            importProIn.Show();
        }

        private void Winmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否关闭窗口，关闭此窗口将退出全部程序", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            /*
            if(Group == "财务部" || Group == "Administrators")
            {
                string strsql = "select * from [dbo].[Message_FHSQ] where examine = '未审核' and readzt = '未读' ";
                SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form Mss_Fhsq = Application.OpenForms["Mss_Fhsq"];
                    //MssForm msg = new MssForm();//将窗口Messages 实例化
                    if ((Mss_Fhsq == null) || (Mss_Fhsq.IsDisposed)) //如果没有打开过
                    {
                        Mss_Fhsq msg = new Mss_Fhsq();
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - msg.Width, Screen.PrimaryScreen.WorkingArea.Height);
                        msg.PointToClient(p);
                        msg.Location = p;
                        msg.Show();
                        for (int i = 0; i < msg.Height; i++)
                        {
                            msg.Location = new Point(p.X, p.Y - i);
                            System.Threading.Thread.Sleep(0);//消息框弹出速度，数值越大越慢
                        }
                        msg.Show();   //打开子窗体出来

                        //ContractAlert contractAlert = new ContractAlert();
                        //contractAlert.ShowDialog();
                    }
                    else
                    {
                        Mss_Fhsq.Activate(); //如果已经打开过就让其获得焦点  
                        Mss_Fhsq.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
                    }
                }
            }
            if (Group == "资材部" || Group == "Administrators")
            {
                string strsql = "select * from [dbo].[Message_FHSQ] where examine = '已审核' and readfh = '未读' ";
                SqlDataAdapter da = new SqlDataAdapter(strsql, SQL);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Form Mss_Cksq = Application.OpenForms["Mss_Cksq"];
                    //MssForm msg = new MssForm();//将窗口Messages 实例化
                    if ((Mss_Cksq == null) || (Mss_Cksq.IsDisposed)) //如果没有打开过
                    {
                        Mss_Cksq msg = new Mss_Cksq();
                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - msg.Width, Screen.PrimaryScreen.WorkingArea.Height);
                        msg.PointToClient(p);
                        msg.Location = p;
                        msg.Show();
                        for (int i = 0; i < msg.Height; i++)
                        {
                            msg.Location = new Point(p.X, p.Y - i);
                            System.Threading.Thread.Sleep(0);//消息框弹出速度，数值越大越慢
                        }
                        msg.Show();   //打开子窗体出来

                        //ContractAlert contractAlert = new ContractAlert();
                        //contractAlert.ShowDialog();
                    }
                    else
                    {
                        Mss_Cksq.Activate(); //如果已经打开过就让其获得焦点  
                        Mss_Cksq.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
                    }
                }
            }
            */
            
        }

        private void 关闭弹窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer2.Enabled = false;
        }

        private void 开启弹窗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer2.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Group == "Administrators" || Username == "蒋程" || Username == "刘超溶" || Username == "张慧" || Username == "邓园园")
            {
                Form ORMain = Application.OpenForms["ORMain"];  //查找是否打开过about窗体 
                if ((ORMain == null) || (ORMain.IsDisposed)) //如果没有打开过
                {
                    ORMain ormain = new ORMain();
                    ormain.ORM_User = Username;
                    ormain.ORM_Group = Group;
                    ormain.Show();  //打开子窗体出来

                    //ContractAlert contractAlert = new ContractAlert();
                    //contractAlert.ShowDialog();
                }
                else
                {
                    ORMain.Activate(); //如果已经打开过就让其获得焦点  
                    ORMain.WindowState = FormWindowState.Normal;//使Form恢复正常窗体大小
                }
            }
            else
            {
                MessageBox.Show("对不起，你没有权限！");
            }

        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OrderReceiving orderReceiving = new OrderReceiving();
            orderReceiving.ORI_User= Username;
            orderReceiving.ORI_Group= Group;
            orderReceiving.Show();
        }

    }
}