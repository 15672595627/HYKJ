using System.Windows.Forms;

namespace WindowsFormsApp1.Calc
{
    public partial class PDWelding : Form
    {
        public PDWelding()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Weldedbalcony weldedbalcony = new Weldedbalcony();
            weldedbalcony.Show();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Weldedgrass weldedgrass = new Weldedgrass();
            weldedgrass.Show();
        }
    }
}