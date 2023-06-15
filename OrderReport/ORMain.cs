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

namespace WindowsFormsApp1.OrderReport
{
    public partial class ORMain : Form
    {
        public ORMain()
        {
            InitializeComponent();
        }

        public string ORM_User { get; set; }
        public string ORM_Group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private void button1_Click(object sender, EventArgs e)
        {
            Daily daily = new Daily();
            daily.DY_User= ORM_User;
            daily.DY_Group= ORM_Group;
            daily.Show();
        }

        private void ORMain_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void ORMain_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderTrack orderTrack = new OrderTrack();
            orderTrack.OTK_User = ORM_User;
            orderTrack.OTK_Group= ORM_Group;
            orderTrack.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Month month = new Month();
            month.MH_User= ORM_User;
            month.MH_Group= ORM_Group;
            month.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mss mss = new Mss();
            mss.MSS_User = ORM_User;
            mss.MSS_Group = ORM_Group;
            mss.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Amount amount = new Amount();
            amount.Show();
        }
    }
}
