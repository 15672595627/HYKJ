using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Calc
{
    public partial class Calemain : Form
    {
        public Calemain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            PDAssembly pDAssembly = new PDAssembly();
            pDAssembly.TopLevel = false;
            pDAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            pDAssembly.FormBorderStyle = FormBorderStyle.None;
            pDAssembly.TopLevel = false;
            splitContainer1.Panel2.Controls.Add(pDAssembly);
            pDAssembly.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            PDWelding pDWelding = new PDWelding();
            pDWelding.TopLevel = false;
            pDWelding.Dock = System.Windows.Forms.DockStyle.Fill;
            pDWelding.FormBorderStyle = FormBorderStyle.None;
            pDWelding.TopLevel = false;
            splitContainer1.Panel2.Controls.Add(pDWelding);
            pDWelding.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            PDFoundation pDFoundation = new PDFoundation();
            pDFoundation.TopLevel = false;
            pDFoundation.Dock = System.Windows.Forms.DockStyle.Fill;
            pDFoundation.FormBorderStyle = FormBorderStyle.None;
            pDFoundation.TopLevel = false;
            splitContainer1.Panel2.Controls.Add(pDFoundation);
            pDFoundation.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            PDTransportation pDTransportation = new PDTransportation();
            pDTransportation.TopLevel = false;
            pDTransportation.Dock = System.Windows.Forms.DockStyle.Fill;
            pDTransportation.FormBorderStyle = FormBorderStyle.None;
            pDTransportation.TopLevel = false;
            splitContainer1.Panel2.Controls.Add(pDTransportation);
            pDTransportation.Show();
        }
    }
}