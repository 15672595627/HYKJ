using System.Windows.Forms;

namespace WindowsFormsApp1.Calc
{
    public partial class PDFoundation : Form
    {
        public PDFoundation()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Foundation foundation = new Foundation();
            foundation.Show();
        }
    }
}