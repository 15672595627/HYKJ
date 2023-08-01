using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Purchase
{
    // Token: 0x02000013 RID: 19
    public partial class cgwh : Form
    {
        // Token: 0x060000FC RID: 252 RVA: 0x000138A3 File Offset: 0x00011AA3
        public cgwh()
        {
            this.InitializeComponent();
        }

        // Token: 0x060000FD RID: 253 RVA: 0x000138BC File Offset: 0x00011ABC
        private void button2_Click(object sender, EventArgs e)
        {
            POApplyList poapplyList = new POApplyList();
            poapplyList.Show();
        }

        // Token: 0x060000FE RID: 254 RVA: 0x000138D8 File Offset: 0x00011AD8
        private void button1_Click(object sender, EventArgs e)
        {
            PurchaseList purchaseList = new PurchaseList();
            purchaseList.Show();
        }
    }
}
