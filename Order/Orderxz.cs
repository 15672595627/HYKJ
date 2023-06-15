using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Order
{
    public partial class Orderxz : Form
    {
        public Orderxz()
        {
            InitializeComponent();
        }

        private static readonly string SQL = ConfigurationManager.AppSettings["connectionstring"];


        public string OXZ_Htbh { get; set; }
        public string OXZ_Gdy { get; set; }
        public string OXZ_Gsm { get; set; }
        public string OXZ_Xmmc { get; set; }
        public string OXZ_Cpmc { get; set; }
        public string OXZ_Nr { get; set; }
        public string OXZ_Sl { get; set; }
        public string OXZ_Dw { get; set; }
        public string OXZ_Je { get; set; }

        private void QD_Click(object sender, EventArgs e)
        {
            if(FHCK.Text == "" || WL.Text == "")
            {
                MessageBox.Show("请选择发货仓库和物流方式！");
            }
            else
            {
                SqlConnection con = new SqlConnection(SQL);

                try
                {
                    con.Open();
                    string fhck = FHCK.Text.Trim();
                    string fhwl = WL.Text.Trim();
                    string sqsj = DateTime.Now.ToString("G");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Message_FHSQ ([contractid],[applytime],[service],[company],[project],[productname],[sub],[quantity],[unit],[amount],[fhck],[fhwl],[examine],[checkout],[readzt]) VALUES('" + OXZ_Htbh + "','" + sqsj + "','" + OXZ_Gdy + "','" + OXZ_Gsm + "','" + OXZ_Xmmc + "','" + OXZ_Cpmc + "','" + OXZ_Nr + "','" + OXZ_Sl + "','" + OXZ_Dw + "','" + OXZ_Je + "','" + fhck + "','" + fhwl + "','未审核','未出库','未读')";
                    int cot = cmd.ExecuteNonQuery();
                    if (cot > 0)
                    {
                        MessageBox.Show("申请成功，请到主界面小蓝标查看");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());

                }
                finally
                {
                    con.Close();
                }
                try
                {
                    con.Open();
                    string fhck = FHCK.Text.Trim();
                    string fhwl = WL.Text.Trim();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE Order_b SET ident = 'Y' WHERE contractid = '" + OXZ_Htbh + "' and productname = '" + OXZ_Cpmc + "' and sub = '" + OXZ_Nr + "'";
                    int cot = cmd.ExecuteNonQuery();
                    if (cot > 0)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());

                }
                finally
                {
                    con.Close();
                }
            }
           
        }

        private void Orderxz_Load(object sender, EventArgs e)
        {

        }
    }
}
