using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Calc
{
    public partial class PDAssembly : Form
    {
        public PDAssembly()
        {
            InitializeComponent();
        }

        #region 翻页

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            linkLabel1.Visible = false;
            pictureBox2.Visible = false;
            linkLabel2.Visible = false;
            pictureBox3.Visible = false;
            linkLabel3.Visible = false;
            pictureBox4.Visible = false;
            linkLabel4.Visible = false;

            pictureBox5.Visible = true;
            linkLabel5.Visible = true;
            pictureBox6.Visible = true;
            linkLabel6.Visible = true;
            pictureBox7.Visible = true;
            linkLabel7.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            linkLabel1.Visible = true;
            pictureBox2.Visible = true;
            linkLabel2.Visible = true;
            pictureBox3.Visible = true;
            linkLabel3.Visible = true;
            pictureBox4.Visible = true;
            linkLabel4.Visible = true;

            pictureBox5.Visible = false;
            linkLabel5.Visible = false;
            pictureBox6.Visible = false;
            linkLabel6.Visible = false;
            pictureBox7.Visible = false;
            linkLabel7.Visible = false;
        }

        #endregion 翻页

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Balcony balcony = new Balcony();
            balcony.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Air air = new Air();
            air.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Air1 air1 = new Air1();
            air1.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Baywindow baywindow = new Baywindow();
            baywindow.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Grass grass = new Grass();
            grass.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Stairs stairs = new Stairs();
            stairs.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Air2 air2 = new Air2();
            air2.Show();
        }
    }
}