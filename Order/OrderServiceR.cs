using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Main;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics.Contracts;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp1.Order
{
    public partial class OrderServiceR : Form
    {
        public OrderServiceR()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];
        public string OSR_Ord { get; set; }
        public string OSR_User { get; set; }
        public string OSR_Group { get; set; }

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        SqlDataAdapter da;
        DataTable dt;
        private void OrderServiceR_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

            string aa = OSR_Ord;

            toolStripStatusLabel2.Text = OSR_User;
            toolStripStatusLabel5.Text = OSR_Group;

            string strsql = String.Format("select * from [dbo].[Order_h]  where orderid like '%" + aa + "%'");
            string strsql1 = String.Format("select id,orderid,contractid,sub as 内容,quantity as 数量,unit as 单位,price as 单价,meters as 米数,amount as 金额,productname as 产品名称 from [dbo].[Order_b] where orderid like '%" + aa + "%'");

            SqlDataAdapter adapter = new SqlDataAdapter(strsql, SQL);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DDBH.Text = ds.Tables[0].Rows[0][1].ToString();
            HTBH.Text = ds.Tables[0].Rows[0][2].ToString();
            XDRQ.Text = ds.Tables[0].Rows[0][3].ToString();
            GDY.Text = ds.Tables[0].Rows[0][4].ToString();
            GSM.Text = ds.Tables[0].Rows[0][5].ToString();
            XMMC.Text = ds.Tables[0].Rows[0][6].ToString();
            QDRQ.Text = ds.Tables[0].Rows[0][7].ToString();
            YWY.Text = ds.Tables[0].Rows[0][8].ToString();
            LXR.Text = ds.Tables[0].Rows[0][9].ToString();
            LXFS.Text = ds.Tables[0].Rows[0][10].ToString();
            QY.Text = ds.Tables[0].Rows[0][11].ToString();
            JQ.Text = ds.Tables[0].Rows[0][12].ToString();
            XDY.Text = ds.Tables[0].Rows[0][13].ToString();
            YS.Text = ds.Tables[0].Rows[0][14].ToString();
            ZCM.Text = ds.Tables[0].Rows[0][15].ToString();
            ZMS.Text = ds.Tables[0].Rows[0][16].ToString();
            JESL.Text = ds.Tables[0].Rows[0][17].ToString();
            HTJE.Text = ds.Tables[0].Rows[0][18].ToString();
            SJJE.Text = ds.Tables[0].Rows[0][19].ToString();
            WSJE.Text = ds.Tables[0].Rows[0][20].ToString();
            AZF.Text = ds.Tables[0].Rows[0][21].ToString();
            YWF.Text = ds.Tables[0].Rows[0][22].ToString();
            HUOK.Text = ds.Tables[0].Rows[0][23].ToString();
            DJ.Text = ds.Tables[0].Rows[0][25].ToString();
            HK.Text = ds.Tables[0].Rows[0][26].ToString();
            BZ.Text = ds.Tables[0].Rows[0][27].ToString();
            string b = ds.Tables[0].Rows[0][28].ToString();

            if (b == "已审核")
            {
                pictureBox1.Visible = true;
                XG.Enabled = false;
            }
            else
            {
                pictureBox1.Visible = false;
                XG.Enabled = true;
            }

            da = new SqlDataAdapter(strsql1, SQL);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["orderid"].Visible = false;
            dataGridView1.Columns["contractid"].Visible = false;
        }

        //增加运费
        private void button3_Click(object sender, EventArgs e)
        {
            OrderFare orderFare = new OrderFare();
            orderFare.OF_HTBH = HTBH.Text.Trim();
            orderFare.OF_GSM = GSM.Text.Trim();
            orderFare.OF_XMMC = XMMC.Text.Trim();
            orderFare.Show();
        }

        private void XG_Click(object sender, EventArgs e)
        {
            if(GDY.Text == OSR_User || OSR_Group == "Administrators")
            {
                BC.Enabled = true;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                YS.ReadOnly = false;
                ZCM.ReadOnly = false;
                JESL.ReadOnly = false;
                AZF.ReadOnly = false;
                YWF.ReadOnly = false;
                HK.ReadOnly = false;
                DJ.ReadOnly = false;
                BZ.ReadOnly = false;

            }
            else
            {
                MessageBox.Show("无法修改其他人的订单");
            }

        }

        private void BC_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder SCB = new SqlCommandBuilder(da);
                da.Update(dt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("保存失败");
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Order_h SET color = '" + YS.Text.Trim() + "',longmetre = '" + ZCM.Text.Trim() + "',quantity = '" + ZMS.Text.Trim() + "',sjje = '" + SJJE.Text.Trim() + "',wsje = '" + WSJE.Text.Trim() + "',azf = '" + AZF.Text.Trim() + "',ywf = '" + YWF.Text.Trim() + "',huokuan = '" + HUOK.Text.Trim() + "',dj = '" + DJ.Text.Trim() + "',hk = '" + HK.Text.Trim() + "',remarks = '" + BZ.Text.Trim() + "',examine = '已审核' WHERE orderid = '" + OSR_Ord + "'";
                int cot = cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE Order_b SET date = '" + XDRQ.Text.Trim() + "',service = '" + GDY.Text.Trim() + "',company = '" + GSM.Text.Trim() + "',project = '" + XMMC.Text.Trim() + "',ident = 'N',pmc = 'N' WHERE orderid = '" + OSR_Ord + "'";
                int cot1 = cmd.ExecuteNonQuery();
                if (cot > 0 || cot1 > 0) 
                {
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                SqlConnection con = new SqlConnection(SQL);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Order_b WHERE sub is NULL";
                int cot = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BC.Enabled = false;
            dataGridView1.ReadOnly = true;
            YS.ReadOnly = true;
            ZCM.ReadOnly = true;
            JESL.ReadOnly = true;
            AZF.ReadOnly = true;
            YWF.ReadOnly = true;
            HK.ReadOnly = true;
            DJ.ReadOnly = true;
            BZ.ReadOnly = true;
        }

        private void DJ_TextChanged(object sender, EventArgs e)
        {
            if (DJ.Text == "")
            {
                return;
            }
            else
            {
                decimal aa = Convert.ToDecimal(SJJE.Text.Trim());
                Decimal bb = Convert.ToDecimal(DJ.Text.Trim());
                HUOK.Text = (aa - bb).ToString();
            }
        }

        private void dataGridView1_Validated(object sender, EventArgs e)
        {
            decimal sum = 0;
            decimal sum1 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["金额"].Value);
                sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells["米数"].Value);
            }

            SJJE.Text = sum.ToString("0.00");
            ZMS.Text = sum1.ToString("0.00");
        }

        private void JESL_TextChanged(object sender, EventArgs e)
        {
            if (HTJE.Text == "")
            {
                return;
            }
            else
            {
                if (SJJE.Text == "" || AZF.Text == "" || YWF.Text == "" || HK.Text == "")
                {
                    MessageBox.Show("请输入：安装费！业务费！回扣");
                    return;
                }
                else
                {

                    decimal ab = Convert.ToDecimal(JESL.Text.Trim());
                    decimal aa = Convert.ToDecimal(SJJE.Text.Trim());
                    decimal bb = Convert.ToDecimal(AZF.Text.Trim());
                    decimal cc = Convert.ToDecimal(YWF.Text.Trim());
                    decimal dd = Convert.ToDecimal(HK.Text.Trim());
                    if((aa - bb - cc - dd) / (1 + ab / 100) > 0)
                    {
                        WSJE.Text = ((aa - bb - cc - dd) / (1 + ab / 100)).ToString("0.00");
                    }
                    else
                    {
                        WSJE.Text = Convert.ToString(0);
                    }
                    
                }
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentRow.Index;
            if (r > 0)
            {
                dataGridView1.Rows[r].Cells[1].Value = dataGridView1.Rows[r - 1].Cells[1].Value;
                dataGridView1.Rows[r].Cells[2].Value = dataGridView1.Rows[r - 1].Cells[2].Value;
            }
            
        }

        private void OrderServiceR_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}