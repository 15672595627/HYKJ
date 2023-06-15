using System.Windows.Forms;

namespace WindowsFormsApp1.Calc
{
    public partial class PDTransportation : Form
    {
        public PDTransportation()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Economical economical = new Economical();
            economical.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Gradient gradient = new Gradient();
            gradient.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Beijing beijing = new Beijing();
            beijing.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Advertisement advertisement = new Advertisement();
            advertisement.Show();
        }
    }
}